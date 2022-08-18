using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class ProviderPortal_Patient_PatientClaimFilterHandler : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
   {
        PatientDB db = new PatientDB();
        int row = Convert.ToInt32(Request.Form["Rows"].ToString());
        int PatientId = int.Parse(Request.Form["PatientId"].ToString());
        int PractiseId = int.Parse(Request.Form["PractiseId"].ToString());
        long ClaimId = long.Parse(Request.Form["ClaimId"].ToString());
        int PageNumber = Convert.ToInt32(Request.Form["PageNumber"].ToString());
        string TotalCharges = Request.Form["TotalCharges"].ToString();
        //string SortBy = Request.Form["SortBy"].ToString();
        
        string DOS = Request.Form["DOS"].ToString();
    
        
     string AmountPaid = Request.Form["AmountPaid"].ToString();     
     
       string Adjusted = Request.Form["Adjusted"].ToString();

         string BalanceDue = Request.Form["BalanceDue"].ToString();
          
     string InsurancesNamesddl = Request.Form["InsurancesNamesddl"].ToString();
        string SubmissionStatusddl = Request.Form["SubmissionStatusddl"].ToString();
        string PtlReasonsddl = Request.Form["PtlReasonsddl"].ToString();

        DataSet dsClaimFilter = db.FilterClaims(PractiseId, PatientId, row, PageNumber, PtlReasonsddl, SubmissionStatusddl, DOS, ClaimId, AmountPaid, TotalCharges, Adjusted, BalanceDue, InsurancesNamesddl);

        rptclaims.DataSource = dsClaimFilter.Tables[0];
        rptclaims.DataBind();
        ltrlPatientRowsCount.Text = dsClaimFilter.Tables[1].Rows[0]["TotalRows"].ToString();
    }
}