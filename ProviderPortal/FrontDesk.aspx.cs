using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProviderPortal_FrontDesk : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ShowpatienPTl();
        ShowclaimPtl();
        PTLReasonsLoad();
        ShowuploadedFiles();
        ChargesAndPatients();
        long practiceId = Profile.PracticeId;

    }

    public void ShowpatienPTl()
    {
        long practiceId = Profile.PracticeId;

        PatientDB db = new PatientDB();
        DataSet ds = new DataSet();
        ds = db.ShowPTlOfpatient(practiceId);
        rptpatient.DataSource = ds;
        rptpatient.DataBind();
    }
    public void ShowclaimPtl()
    {
        long practiceId = Profile.PracticeId;
        ClaimDB db = new ClaimDB();
        DataSet ds = new DataSet();
        ds = db.ShowPTlOfclaim(practiceId,1000,10,null,null,null,null,null,null,null,null);
        rptclaim.DataSource = ds;
        rptclaim.DataBind();
    }
    public void ShowuploadedFiles()
    {

        long practiceId = Profile.PracticeId;
        DataSet dt = new DataSet();
        UploadFilesDB db = new UploadFilesDB();
        dt = db.ShowUploadedFiles(practiceId, 6, 0, "", "", "", "", "", "");
        rptUploadedFiles.DataSource = dt;
        rptUploadedFiles.DataBind();
    }
    public void PTLReasonsLoad()
    {
        PTLReasonsDB objPTLReasonsDB = new PTLReasonsDB();
        DataSet dsPTLReasons = objPTLReasonsDB.GetAllPTLReasons();

        rptPTLReasonsPatient.DataSource = dsPTLReasons.Tables[0];
        rptPTLReasonsPatient.DataBind();
        rptPTLReasonsClaim.DataSource = dsPTLReasons.Tables[1];
        rptPTLReasonsClaim.DataBind();

    }

    public void ChargesAndPatients() 
    {

        FrontDeskDB frontDeskDB = new FrontDeskDB();
        DataTable dt= frontDeskDB.GetCountPatientClaim(Profile.PracticeId);
        string totalclaims= dt.Rows[0]["TotalClaims"].ToString();
        string totalPatient = dt.Rows[0]["TotalPatients"].ToString();

        spnPatients.Text=totalPatient;
        spnClaims.Text = totalclaims;

    }
}