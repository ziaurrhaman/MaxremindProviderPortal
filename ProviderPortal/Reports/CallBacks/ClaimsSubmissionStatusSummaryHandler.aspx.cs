using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class EMR_Reports_CallBacks_ClaimsSubmissionStatusSummaryHandler : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string ClaimId = Request.Form["ClaimId"];
        string PatientName = Request.Form["PatientName"];
        string DateOfService = Request.Form["DateOfService"];
        string BillDate = Request.Form["BillDate"];
        string InsuranceId = Request.Form["InsuranceId"];
        string SubmissionStatusId = Request.Form["SubmissionStatusId"];
        string PracticeLocationsId = Request.Form["PracticeLocationsId"];

        int Rows = int.Parse(Request.Form["Rows"]);
        int PageNumber = int.Parse(Request.Form["PageNumber"]);

        ReportsDB objReportsDB = new ReportsDB();

        DataSet dsClaimReport = objReportsDB.FilterClaimSubmissionStatusSummary(ClaimId, PatientName, DateOfService, BillDate, InsuranceId, SubmissionStatusId, Profile.PracticeId,PracticeLocationsId, Rows, PageNumber);

        rptClaims.DataSource = dsClaimReport.Tables[0];
        rptClaims.DataBind();
        ltrRowsCount.Text = dsClaimReport.Tables[1].Rows[0]["TotalRows"].ToString();
    }
    protected void rptClaims_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView drv = (DataRowView)e.Item.DataItem;

            string InsuranceId = drv["InsuranceId"].ToString();
            string Name = drv["Name"].ToString();

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
}