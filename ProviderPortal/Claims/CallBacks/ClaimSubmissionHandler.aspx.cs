using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

public partial class HomeHealth_EpisodeClaims_CallBacks_ClaimSubmissionHandler : System.Web.UI.Page
{
    private string _fileText = string.Empty;
    private int _segmtCount = 11;
    private int _hlCount = 1;
    private string _hlParentCount = "";
    private DateTime _currentDate = DateTime.Now;
    private string _tscnNo = string.Empty;
    private int _subscriberLoopCount = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        var serializer = new JavaScriptSerializer();
        var claimsSubmittedList = serializer.Deserialize<List<ClaimsSubmitted>>(Request.Form["SubmissionList"]);

        try
        {
            string fileName = GenerateEdiFile(claimsSubmittedList);
            var submissionFile = new SubmissionFiles()
                                     {
                                         FileName = fileName,
                                         PracticeId = Convert.ToInt64(Profile.PracticeId),
                                         FileStatus = "Undownloaded",
                                         CreatedById = Profile.UserId,
                                         CreatedDate = DateTime.Now
                                     };
            var objSubmissionFileDb = new SubmissionFilesDB();
            Int64 longSubmissionFileId = objSubmissionFileDb.Add(submissionFile);

            var objClaimsSubmittedDb = new ClaimsSubmittedDB();
            var objClaimDb = new ClaimDB();

            foreach (var claimsSubmitted in claimsSubmittedList)
            {
                var claimsSubmittedobj = new ClaimsSubmitted()
                                             {
                                                 ClaimsSubmissionId = claimsSubmitted.ClaimsSubmissionId,
                                                 PatientAccount = claimsSubmitted.PatientAccount,
                                                 PracticeId = Convert.ToInt64(Profile.PracticeId),
                                                 LocationId = claimsSubmitted.LocationId,                                                 
                                                 ClaimNo = claimsSubmitted.ClaimNo,
                                                 InsuranceId = claimsSubmitted.InsuranceId,
                                                 SubmissionFileId = longSubmissionFileId,
                                                 SubmissionDate = DateTime.Now,
                                                 ClaimWorkDate = DateTime.Now,
                                                 CreatedDate = DateTime.Now,
                                                 CreatedById = Profile.UserId
                                             };
                objClaimsSubmittedDb.Add(claimsSubmittedobj);
                objClaimDb.ChangeClaimStatus(claimsSubmitted.ClaimNo, 102, Profile.UserId);

            }
        }
        catch (Exception)
        {
            //lblMsg.Text = "Error";
        }
    }
    private string GenerateEdiFile(IEnumerable<ClaimsSubmitted> claimsSubmittedList)
    {
        Guid identifier = Guid.NewGuid();
        string agencyTaxId = "1234";

        _fileText += "ST*837*" + GetTscnNo(9) + "*005010x223A1~";
        _fileText += "BHT*0019*00*" + identifier + "*" + GetDate() + "*" + _currentDate.Hour.ToString() + _currentDate.Minute.ToString() + "*CH~";

        var objPracticesDb = new PracticesDB();
        DataTable dtAgency = objPracticesDb.GetPracticeDetails(Convert.ToInt64(Profile.PracticeId));
        _fileText += "NM1*41*2*" + dtAgency.Rows[0]["PracticeName"].ToString() + "*****46*" + dtAgency.Rows[0]["CMSCertificationNumber"].ToString() + "~";

        //var objAgentDb = new AgentDB();
        //DataTable dtAgent = objAgentDb.AgencyAgent_GetByPracticeId(Profile.PracticeId);
        //_fileText += "PER*IC*" + dtAgent.Rows[0]["Name"].ToString() + "*TE*" + dtAgent.Rows[0]["ContactPerson"].ToString() + "*Ext*" + dtAgent.Rows[0]["AgentExt"].ToString() + "~";

        _fileText += "NMI*40*2*Insurance Name*****46*TaxId~";
        _fileText += "HL*" + _hlCount + "**20*0~";
        _fileText += "PRV*BI*PXC*251E00000X~";
        _fileText += "NM1*85*2*" + dtAgency.Rows[0]["AgencyName"].ToString() + "*****XX*" + dtAgency.Rows[0]["NPI"].ToString() + "~";
        _fileText += "N3*" + dtAgency.Rows[0]["Address"].ToString() + "~";
        _fileText += "N4*" + dtAgency.Rows[0]["City"].ToString() + "*" + dtAgency.Rows[0]["StateName"].ToString() + "*" + dtAgency.Rows[0]["ZipCode"].ToString() + "~";
        _fileText += "REF*EI*" + agencyTaxId + "~";
        _hlCount++;
        _hlParentCount = _hlParentCount == "" ? "1" : (int.Parse(_hlParentCount) + 1).ToString();

        var claimsList = (from x in claimsSubmittedList orderby x.PatientAccount select x).ToList<ClaimsSubmitted>();
        int previousPatAccount = 0;
        foreach (var claim in claimsList)
        {
            if (previousPatAccount != claim.PatientAccount)
            {
                previousPatAccount = int.Parse(claim.PatientAccount.ToString());

                AddSubscriberDetails(previousPatAccount);
                AddInsuranceDetails(claim.InsuranceId);
                AddClaimDetails(claim.ClaimNo);
            }
            else
            {
                AddClaimDetails(claim.ClaimNo);
            }
        }
        _segmtCount++;
        _fileText += "SE*" + _segmtCount + "*" + _tscnNo + "~";

        string fileName = _currentDate.Day.ToString() + _currentDate.Month.ToString() + _currentDate.Year.ToString() +
                          _currentDate.Hour.ToString() + _currentDate.Minute;
        SaveSubmissionFile(fileName, _fileText);
        return fileName;
    }
    private void AddSubscriberDetails(int patientAccount)
    {
        string Medicare = "MA";
        string policyNo = "123";
        var objpatient = new PatientDB();
        DataTable dtPatient = objpatient.Patient_GetInfoById(patientAccount);
        _fileText += "HL*" + _hlCount + "*" + _hlParentCount + "*22*" + _subscriberLoopCount + "~";
        _fileText += "SBR*P*18*******" + Medicare + "~";
        _fileText += "NM1*IL*1*" + dtPatient.Rows[0]["LastName"].ToString() + "*" + dtPatient.Rows[0]["FirstName"].ToString() + "****MI*" + policyNo + "~";
        DateTime dob = DateTime.Parse(dtPatient.Rows[0]["DateOfBirth"].ToString());
        string[] dOB = dob.ToString("yyyy/MM/dd").Split('/');
        string gender = dtPatient.Rows[0]["Gender"].ToString().ToLower() == "male" ? "M" : "F";
        _fileText += "DMG*D8*" + dOB[0] + dOB[1] + dOB[2] + "*" + gender + "~";

        _segmtCount += 4;
        _hlCount++;
        _subscriberLoopCount++;
        _hlParentCount = _hlParentCount == "" ? "1" : (int.Parse(_hlParentCount) + 1).ToString();
    }
    private void AddInsuranceDetails(Int64 insuranceId)
    {
        var objInsurance = new InsuranceDB();
        DataTable dtInsurance = objInsurance.GetInsuranceDetails(insuranceId);
        _fileText += "NM1*PR*2*" + dtInsurance.Rows[0]["InsuranceName"].ToString() + "*****PI*" + insuranceId + "~";
        _segmtCount++;
    }
    private void AddClaimDetails(Int64 claimNo)
    {
        _fileText += "CLM*" + claimNo + "~";
        _segmtCount++;
    }
    private string GetTscnNo(int length)
    {
        _tscnNo = _currentDate.Day.ToString() + _currentDate.Month.ToString() + _currentDate.Year.ToString() + _currentDate.Hour.ToString() + _currentDate.Minute.ToString() + _currentDate.Second.ToString() + _currentDate.Millisecond;
        _tscnNo = _tscnNo.Substring(0, length);
        return _tscnNo;
    }
    private string GetDate()
    {
        string date = _currentDate.Year.ToString();
        if (_currentDate.Month.ToString().Length == 1)
            date += "0" + _currentDate.Month.ToString();
        else
            date += _currentDate.Month.ToString();

        if (_currentDate.Day.ToString().Length == 1)
            date += "0" + _currentDate.Day.ToString();
        else
            date += _currentDate.Day.ToString();

        return date;
    }
    private void SaveSubmissionFile(string fileName, string fileText)
    {
        string path = "";
        string savepath = "";
        fileName = fileName + ".txt";
        path = ConfigurationManager.AppSettings["PatientPhoto"] + "/SubmissionFiles/" + Profile.PracticeId;
        savepath = HttpContext.Current.Server.MapPath(path);
        if (!Directory.Exists(savepath))
            Directory.CreateDirectory(savepath);
        try
        {
            System.IO.File.WriteAllText(savepath + "/" + fileName, fileText);
        }
        catch
        {
            ;
        }
    }

}