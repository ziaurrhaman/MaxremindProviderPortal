using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class BillingManager_Home : System.Web.UI.Page
{
    string UserType = "";
    protected void Page_Load(object sender, EventArgs e) 
    {
        
        if (!IsPostBack)
        {
     
            if (Profile.PracticeId == 1026 || Profile.PracticeId == 1001)
            {
                //Added by Khayyam Adeel as per task reuirement dated 8/10/2021;
                RPMStyle.Visible = false;
                liRPMClaim.Visible = false;
                liRPMPatient.Visible = false;
            }
            else
            {
                RPMStyle.Visible = false;
                liRPMClaim.Visible = false;
                liRPMPatient.Visible = false;
            }
        }
        //if(Profile.RightsServer.PaymentView != true)
        //{
        //    Response.Redirect("FrontDesk.aspx");
        //}
        GetPracticesDetails();
        ShowpatienPTl(); 
        ShowclaimPtl();
        PTLReasonsLoad();
        ShowuploadedFiles();
        ERAMasterDB objERAMasterDB = new ERAMasterDB();
        /***start***/
        bool? IsImportedDataOnly = null;
        if (!string.IsNullOrEmpty(Session["IsImported"] as string))
        {
            if (Session["IsImported"].ToString() == "2") { IsImportedDataOnly = true; }
            else if (Session["IsImported"].ToString() == "1") { IsImportedDataOnly = false; }
            else { IsImportedDataOnly = null; }
        }
        /***End***/
        DataSet dsERAList = objERAMasterDB.GetBySearchCriteria(Profile.PracticeId, "", "", "", "", "", "", 50, 0, "CheckIssueDate Desc", false, false, false, "", IsImportedDataOnly);

        DataTable dtERA = dsERAList.Tables[0];
        DataTable dtERATotalCount = dsERAList.Tables[1];

        rptClaimCheck.DataSource = dtERA;
        rptClaimCheck.DataBind();
        DateTime DateFrom = DateTime.Now.AddDays(-30);
        DateTime DateTo = DateTime.Now;

     

        DataTable dtPaymentSummary = objERAMasterDB.GetChargesPaymentSummary(Profile.PracticeId, DateFrom, DateTo,0,0,0, IsImportedDataOnly);
        spnHomedates.InnerText = "["+DateFrom.ToShortDateString() +" - "+DateTo.ToShortDateString() + "]";
        if (dtPaymentSummary.Rows.Count > 0)
        {
            foreach (DataRow dr in dtPaymentSummary.Rows)
            {
                string _charges = dr["claimCharges"].ToString();
                if (string.IsNullOrEmpty(_charges))
                {
                    spnMTDCharges.Text = "0";
                }
                else
                {
                    decimal charges = Convert.ToDecimal(dr["claimCharges"].ToString());
                    string chargesString = String.Format("{0:C}", charges);
                    spnMTDCharges.Text = chargesString;
                }

                string _payment = dr["claimCharges"].ToString();
                if (string.IsNullOrEmpty(_payment))
                {
                    spnMTDPayments.Text = "0";
                }
                else
                {
                    decimal payment = Convert.ToDecimal(dr["EnteredPayments"].ToString());
                    string paymentString = String.Format("{0:C}", payment);
                    spnMTDPayments.Text = paymentString;
                }

               // spnMTDCharges.Text = "$" + dr["claimCharges"].ToString();
              //  spnMTDPayments.InnerText = "$" + dr["EnteredPayments"].ToString();

             //   spnMTDAdjustments.InnerText = "$" + dr["EnteredAdjustments"].ToString();
              //  spnMTDBalanceDue.InnerText = "$" + dr["claimCharges"].ToString();

            }

           


        }

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
        ds = db.ShowPTlOfclaim(practiceId,10000,0,null,null,null,null,null,null,null,null);
        rptclaim.DataSource = ds;
        rptclaim.DataBind();
    }
  
    public void ShowuploadedFiles()
    {

        long practiceId = Profile.PracticeId;
        DataSet dt = new DataSet();
        UploadFilesDB db = new UploadFilesDB();
        dt = db.ShowUploadedFiles(practiceId,6,0,"","","","","","");
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


    private void GetPracticesDetails()
    {
        PracticeUsersDB objPracticeUserDB = new PracticeUsersDB();
        DataTable objDataTable = objPracticeUserDB.GetUserProfile_WithSelectedPractice(Profile.UserId, Profile.PracticeId);
        if (objDataTable.Rows.Count > 0) { 
        UserType= objDataTable.Rows[0]["UserType"].ToString();
        }
    }
}