using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Script.Serialization;

public partial class ProviderPortal_PendingTransitions_CallBacks_PTLHandler : System.Web.UI.Page
{
    JavaScriptSerializer objJavaScriptSerializer = new JavaScriptSerializer();
    string patientId = null;
    string claimId = null;
    protected void Page_Load(object sender, EventArgs e)
    { 
        string action = Request.Form["action"]; 
        if (Request.Form["Patientid"] != null)
        {
            patientId = Request.Form["Patientid"].ToString();
        }

        if (Request.Form["ClaimId"] != null)
        {
            claimId = Request.Form["ClaimId"].ToString();
        }
        

        if (action == "PatientPart")
        {
            LoadForm_Patient();
        }

        if (action == "ClaimPart")
        {
            LoadForm_Claim();
        }

        if (action == "SavePTLPatient")
        {
            Save_Patient();
        }

        if (action == "SavePTLClaim")
        {
            Save_Claim(); 
        }

        if (action == "ResolveStatusPatient")
        {
            ResolveStatus_Patient();
        }
        if (action == "ResolveStatusClaim")
        {
            ResolveStatus_Claim();
        }


        LoadClaimsAFterDialogFunction();
        LoadPatientAFterDialogFunction();



    }


    private void LoadForm_Patient()
    {
        

        PTLReasonsDB objPTLReasonsDB = new PTLReasonsDB();

        DataSet dsPTLReasons = objPTLReasonsDB.PTL_LoadReasons_Patient(Convert.ToInt64(patientId), Profile.PracticeId);

        DataTable dtPTLReasons = dsPTLReasons.Tables[0];
        DataTable dtPatientPTLInfo = dsPTLReasons.Tables[1];

     

        if (dtPatientPTLInfo.Rows.Count > 0)
        {
            hdnPTLReasonsPatient.Value = dtPatientPTLInfo.Rows[0]["PTLReasons"].ToString();
            txtPTLNotesPatient.Text = dtPatientPTLInfo.Rows[0]["PTLNotes"].ToString();
        }

        

        rptPTLReasonsPatient.DataSource = dtPTLReasons;
        rptPTLReasonsPatient.DataBind();

       
    }


    private void Save_Patient()
    {
        Patient objPatient = objJavaScriptSerializer.Deserialize<Patient>(Request.Form["objPatient"]);

        objPatient.ModifiedById = Profile.UserId;
        objPatient.ModifiedDate = DateTime.Now;

        PatientDB objPatientDB = new PatientDB();

        objPatientDB.UpdatePTLInfo(objPatient);
    }

    private void ResolveStatus_Patient()
    {
        Patient objPatient = new Patient();

        objPatient.PatientId = Convert.ToInt64(Request.Form["Patientid"].ToString());

        objPatient.ModifiedById = Profile.UserId;
        objPatient.ModifiedDate = DateTime.Now;

        PatientDB objPatientDB = new PatientDB();

        objPatientDB.ResolvePTLStatus(objPatient);
    }

    private void ResolveStatus_Claim()
    {
        Claim objClaim = new Claim();

        objClaim.ClaimId = long.Parse(Request.Form["ClaimId"]);

        objClaim.ModifiedById = Profile.UserId;
        objClaim.ModifiedDate = DateTime.Now;

        ClaimDB objClaimDB = new ClaimDB();

        objClaimDB.ResolvePTLStatus(objClaim);
    }

    private void LoadForm_Claim()
    { 
        long ClaimId = long.Parse(Request.Form["ClaimId"]);

        PTLReasonsDB objPTLReasonsDB = new PTLReasonsDB();

        DataSet dsPTLReasons = objPTLReasonsDB.PTL_LoadReasons_Claim(ClaimId, Profile.PracticeId);

        DataTable dtPTLReasons = dsPTLReasons.Tables[0];
        DataTable dtPTLInfo = dsPTLReasons.Tables[1];

        #region Claim PTL Info

        if (dtPTLInfo.Rows.Count > 0)
        {
            hdnPTLReasonsClaim.Value = dtPTLInfo.Rows[0]["PTLReasons"].ToString();
            txtPTLNotesClaim.Text = dtPTLInfo.Rows[0]["PTLNotes"].ToString();
        }

        #endregion

        #region PTL Reasons

        rptPTLReasonsClaim.DataSource = dtPTLReasons;
        rptPTLReasonsClaim.DataBind();

        #endregion
    }

    private void Save_Claim()
    {
        Claim objClaim=null;
     
       objClaim = objJavaScriptSerializer.Deserialize<Claim>(Request.Form["objclaim"]);

     
          objClaim.ModifiedById = Profile.UserId;
        objClaim.ModifiedDate = DateTime.Now;

        ClaimDB objClaimDB = new ClaimDB();

        objClaimDB.UpdatePTLInfo(objClaim);
    }



    private void LoadClaimsAFterDialogFunction()
    {
        ClaimDB objClaimDB = new ClaimDB();

        DataSet dsClaims = objClaimDB.GetAllByPractice(10, 0, Profile.PracticeId, "",  "", "", "", "", "", "", "", true, "", "", "", "");
            //GetAllByPractice(Profile.PracticeId,"", "", "", "", "", "", "", "", 10, 0, true);

        rptClaims.DataSource = dsClaims.Tables[0];
        rptClaims.DataBind();

      ltrlRowsCountClaim.Text = dsClaims.Tables[1].Rows[0]["TotalRows"].ToString();
      hdnTotalRowsClaims.Value = dsClaims.Tables[1].Rows[0]["TotalRows"].ToString();
    }
    public void LoadPatientAFterDialogFunction()
    {
        PatientDB ObjPatientDB = new PatientDB();
        long PracticeId = Profile.PracticeId;

      //  DataSet dsPatientRecord = ObjPatientDB.PendingTransitionFilterPatients(0, "", "", "", "", "", "", "", PracticeId, 10, 0, "");    //FirstName
        DataSet dsPatientRecord = ObjPatientDB.FilterPatients(0, "", "", "", "", "", "", "", PracticeId, 10, 0, "LastName", true);
        rptPatients.DataSource = dsPatientRecord.Tables[0];
        rptPatients.DataBind();
        //hdnTotalRowsPatients.Value = dsPatientRecord.Tables[1].Rows[0]["TotalRows"].ToString();
        ltrlPatientRowsCount.Text = dsPatientRecord.Tables[1].Rows[0]["TotalRows"].ToString();
        hdnTotalRowsPatients.Value = dsPatientRecord.Tables[1].Rows[0]["TotalRows"].ToString();  


    }


}