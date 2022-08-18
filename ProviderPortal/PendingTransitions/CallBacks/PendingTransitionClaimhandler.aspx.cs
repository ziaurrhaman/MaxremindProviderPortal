 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class ProviderPortal_PendingTransitions_CallBacks_PendingTransitionClaimhandler : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadClaims();
      
    }


    private void LoadClaims()
    {
        string ClaimId = Request.Form["ClaimId"];
        if (ClaimId == "") { ClaimId = null; }
        string PatientId = Request.Form["PatientId"];
        if (PatientId == "") { PatientId = null; }
        string PatientName = Request.Form["PatientName"];
        if (PatientName == "") { PatientName = null; }
        string DateOfService = Request.Form["DateOfService"];
        if (DateOfService == "") { DateOfService = null; }
        string BillDate = Request.Form["BillDate"];
        if (BillDate == "") { BillDate = null; }
        string InsuranceId = Request.Form["InsuranceId"];
        if (InsuranceId == "") { InsuranceId = null; }
        string SubmissionStatusId = Request.Form["SubmissionStatusId"];
        if (SubmissionStatusId == "") { SubmissionStatusId = null; }

        int Rows = int.Parse(Request.Form["Rows"]);
        int PageNumber = int.Parse(Request.Form["PageNumber"]);

        bool IsPTL = false;
        string PTLReasons = Request.Form["PTLReason"];
        if (PTLReasons == "") { PTLReasons = null; }
        if (Request.Form["IsPTL"] != null)
        {
            IsPTL = bool.Parse(Request.Form["IsPTL"]);
        }

        ClaimDB objClaimDB = new ClaimDB();
        /**********EDITED BY SHAHID KAZMI 1/22/2018*******/
        string SortBy = "";
        
        //string PTLReasons = "";
        string Location = "";
      
        string balanceDue = Request.Form["AmountDue"];
        string AmountPaid = Request.Form["AmountPaid"];
        /********END SHAHID KAZMI 1/22/2018*********/
        //DataSet dsClaims = objClaimDB.GetAllByPractice(Rows, PageNumber, Profile.PracticeId, SortBy, ClaimId, PatientId,  PatientName, DateOfService, BillDate, InsuranceId, SubmissionStatusId, true, PTLReasons, Location,  balanceDue, AmountPaid);
        DataSet dsClaims = objClaimDB.ShowPTlOfclaim(Profile.PracticeId, Rows, PageNumber, ClaimId, PatientId, PatientName, DateOfService, BillDate, InsuranceId, SubmissionStatusId, PTLReasons);

        rptClaims.DataSource = dsClaims.Tables[0];
        rptClaims.DataBind();

        ltrlRowsCountClaim.Text = dsClaims.Tables[1].Rows[0]["TotalRows"].ToString();
       hdnTotalRowsClaims.Value = dsClaims.Tables[1].Rows[0]["TotalRows"].ToString();
    }
    
}