using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI.WebControls;

public partial class HomeHealth_EpisodeClaims_CallBacks_UnProcessedClaimsHandler : System.Web.UI.Page
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
        string action = Request.Form["Action"];
        var objClaimDb = new ClaimDB();
        if (action.Equals("Generate File"))
        {
            //var serializer = new JavaScriptSerializer();
            //var claimsSubmittedList = serializer.Deserialize<List<ClaimsSubmitted>>(Request.Form["SubmissionList"]);
            string submittedClaims = Request.Form["claims"];
            ClaimsSubmission objClaimsSubmission = new ClaimsSubmission();
            
            try
            {

                objClaimsSubmission.GenerateEdiFile(submittedClaims.TrimEnd(','),"");
                string sData = objClaimsSubmission.claimSubmissionFile;
                string sFileName = "Test";

                SaveSubmissionFile(sFileName, sData);
                
            }
            catch (Exception)
            {
                hdnMsg.Value = "Error";
            }
        }

        int rows = Int32.Parse(Request.Form["Rows"]);
        int pageNo = Int32.Parse(Request.Form["PageNumber"]);
        string PatientName = Request.Form["PatientName"];
        string InsuranceName = Request.Form["InsuranceName"];
        string ClaimNumber = Request.Form["ClaimNumber"];

        var dsUnProcessedClaims = objClaimDb.GetUnProcessedClaims(Convert.ToInt64(Profile.PracticeId), rows, pageNo,  PatientName, InsuranceName, ClaimNumber);
        rptUnProcessedClaims.DataSource = dsUnProcessedClaims.Tables[0];
        rptUnProcessedClaims.DataBind();
        hdnUnProcessedClaimsCount.Value = dsUnProcessedClaims.Tables[1].Rows[0]["TotalRows"].ToString();
    }

    protected void rptUnProcessedClaims_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView drv = (DataRowView)e.Item.DataItem;

            string InsuranceId = drv["InsuranceId"].ToString();
            string Name = drv["InsuranceName"].ToString();

            Label lblInsuranceName = (Label)e.Item.FindControl("lblInsuranceName");

            if (InsuranceId == "0")
            {
                lblInsuranceName.Text = "Self Pay";
            }
            else
            {
                lblInsuranceName.Text = Name;
            }
        }
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

        System.IO.File.WriteAllText(savepath + "/" + fileName, fileText);
    }
}