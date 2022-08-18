using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using System.Data;
public partial class HomeHealth_EpisodeClaims_CallBacks_AddNewEOBHandler : System.Web.UI.Page
{
    ERANotes Objcs = new ERANotes();
    ERANotesDB ObjDb = new ERANotesDB();
    string ERAMasterId = "";
    string ERANotesId = "";
    string PatientName = "";
    string a = "";
    ERAMasterDB objERAMasterDB = new ERAMasterDB();
    ERAMaster objERAMaster = new ERAMaster();
    protected void Page_Load(object sender, EventArgs e)
    {
        JavaScriptSerializer serializer = new JavaScriptSerializer();
        #region EOBCode

        objERAMaster = serializer.Deserialize<ERAMaster>(Request.Form["NewEOB"]);
        PatientName = Request.Form["Payerid"];
        objERAMaster.PracticeId = Profile.PracticeId;
        var PaymentType = objERAMaster.PaymentType;
        //Added By Syed Sajid Ali Date:09/04/2018 Des:Get PayerID837,PayerName and PayerIdentifier
        long PayerId = Convert.ToInt64(objERAMaster.PatientId);
        ERAMasterDB objERAMasterDB = new ERAMasterDB();
        DataTable dtPayerInformation = objERAMasterDB.GetPayerInformationForERA(PayerId, PaymentType);
        DataTable dtERAMasterCheck = objERAMasterDB.GetByCheckNumber(objERAMaster.CheckNumber, objERAMaster.PaymentType, Profile.PracticeId);
        if (dtPayerInformation.Rows.Count > 0)
        {
            objERAMaster.PayerID837 = dtPayerInformation.Rows[0]["PayerID837"].ToString();
            objERAMaster.PayerName = dtPayerInformation.Rows[0]["PayerName"].ToString();
            objERAMaster.PayerIdentifier = PayerId.ToString();
        }
        int _isCheckExists = Convert.ToInt32(Request.Form["_isCheckExists"]);
        if (dtERAMasterCheck.Rows.Count > 0 && _isCheckExists == 0 && objERAMaster.ERAMasterId == 0)
        {
            ltrIfCheckExists.Text = "true";
        }
        else
        {
            //End by Syed Sajid Ali 
            Int64 result = 0;
            if (objERAMaster.ERAMasterId == 0)
            {
                objERAMaster.CreatedById = Convert.ToInt64(Profile.UserId);
                objERAMaster.CreatedDate = DateTime.Now;
                if (PaymentType == "PAT")
                {
                    //a = PatientName.Trim().TrimEnd(':');
                    //objERAMaster.PayerName = PatientName;
                }
                if (!string.IsNullOrEmpty(Request.Form["UploadFileId"]))
                {
                    long uploadfileid = long.Parse(Request.Form["UploadFileId"]);
                    result = objERAMasterDB.Add(objERAMaster, uploadfileid);
                }
                else
                {
                    result = objERAMasterDB.Add(objERAMaster);
                }


                //Added By Rizwan kharal 24April2018
                AddERANote();
                AddERAAttachFiles(objERAMaster.ERAMasterId);
                AddEOBMultiplePatients(objERAMaster.ERAMasterId);
                //Added by Syed Sajid Ali

            }
            else
            {
                objERAMaster.ModifiedById = Convert.ToInt64(Profile.UserId);
                objERAMaster.ModifiedDate = DateTime.Now;
                if (PaymentType == "PAT")
                {
                    //a = PatientName.Trim().TrimEnd(':');
                    //objERAMaster.PayerName = a;
                }
                result = objERAMaster.ERAMasterId;
                if (!string.IsNullOrEmpty(Request.Form["UploadFileId"]))
                {
                    long uploadfileid = long.Parse(Request.Form["UploadFileId"]);
                    objERAMasterDB.Update(objERAMaster, uploadfileid);
                }
                else
                {
                    objERAMasterDB.Update(objERAMaster);
                }


                //UpdateERANotes();
                AddERANote();
                //Added by Syed Sajid Ali
                AddERAAttachFiles(objERAMaster.ERAMasterId);
                if (PaymentType == "PAT")
                {
                    AddEOBMultiplePatients(objERAMaster.ERAMasterId);
                }

            }


            ltrResult.Text = result.ToString();
        }

    }
   #endregion
    public void AddERANote()
    {

        if (Request.Form["Notes"] != null && Request.Form["Notes"] != "")
        {

            Objcs.Comments = Request.Form["Notes"].ToString();
            Objcs.PracticeId = Profile.PracticeId;

            if (Request.Form["ERAMasterId"] != null)
            {
                ERAMasterId = Request.Form["ERAMasterId"].ToString();
                if (ERAMasterId != "")
                {
                    ERAMasterId = Request.Form["ERAMasterId"].ToString();
                }
                else
                {
                    ERAMasterId = objERAMaster.ERAMasterId.ToString();
                }
            }
            else
            {
                ERAMasterId = objERAMaster.ERAMasterId.ToString();
            }

            Objcs.ERAMasterId = Convert.ToInt64(ERAMasterId);
            Objcs.CreatedById = Profile.UserId;
            Objcs.CreatedOn = DateTime.Now;
            Objcs.Deleted = false;

            ObjDb.Add(Objcs);
            DataTable dt = ObjDb.GetAllERANotes(Profile.PracticeId, 10, 0, "", Convert.ToInt64(ERAMasterId));
            //RptNotes.DataSource = dt;
            //RptNotes.DataBind();

        }

    }
    private void AddERAAttachFiles(long ERAMasterId)
    {
        var serializer = new JavaScriptSerializer();
        var listUploadFiles = serializer.Deserialize<List<ERAAttachFile>>(Request.Form["listUploadFiles"]);

        var objERAAttachFilesDB = new ERAAttachFilesDB();

        foreach (var objUploadFiles in listUploadFiles)
        {

            if (objUploadFiles.ERAAttachfileId == 0)
            {
                objUploadFiles.PracticeId = Profile.PracticeId;
                objUploadFiles.ERAMasterId = ERAMasterId;
                objUploadFiles.CreatedById = Profile.UserId;
                objUploadFiles.CreatedDate = DateTime.Now;

                objERAAttachFilesDB.Add(objUploadFiles);
            }
            else
            {
                objUploadFiles.PracticeId = Profile.PracticeId;
                objUploadFiles.ERAMasterId = ERAMasterId;
                objUploadFiles.ModifiedById = Profile.UserId;
                objUploadFiles.ModifiedDate = DateTime.Now;

                //objERAAttachFilesDB.Update(objUploadFiles);
            }
        }

        //LoadClaimCharges(ClaimId);
    }


    //Function for Add Patients in EOBPatient Table Date:01-24-2018

    private void AddEOBMultiplePatients(long ERAMasterId)
    {
        var serializer = new JavaScriptSerializer();
        var listPatientIds = serializer.Deserialize<List<EOBPatients>>(Request.Form["listPatientIds"]);

        var objERAAttachFilesDB = new ERAAttachFilesDB();

        foreach (var objEOBPatients in listPatientIds)
        {

            if (objEOBPatients.EOBPatientId == 0)
            {
                objEOBPatients.PracticeId = Profile.PracticeId;
                objEOBPatients.ERAMasterId = ERAMasterId;
                objEOBPatients.CreatedById = Profile.UserId;
                objEOBPatients.CreatedDate = DateTime.Now;
                

                objERAAttachFilesDB.AddEOBPatients(objEOBPatients);
            }
            else
            {
                objEOBPatients.PracticeId = Profile.PracticeId;
                objEOBPatients.ERAMasterId = ERAMasterId;
                objEOBPatients.ModifiedById = Profile.UserId;
                objEOBPatients.ModifiedDate = DateTime.Now;

                //objERAAttachFilesDB.Update(objUploadFiles);
            }
        }
    }

}