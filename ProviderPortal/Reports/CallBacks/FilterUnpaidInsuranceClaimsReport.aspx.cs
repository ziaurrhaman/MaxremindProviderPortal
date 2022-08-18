using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProviderPortal_Reports_CallBacks_FilterUnpaidInsuranceClaimsReport : System.Web.UI.Page
{
    int Balance = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();
        long PracticeId = Profile.PracticeId;
        string PayerId = Request.Form["PayerId"];
        string ProviderId = Request.Form["ProviderId"];
        string PracticeLocationId = Request.Form["PracticeLocationId"];
        if (!string.IsNullOrEmpty(Request.Form["Balance"]))
            Balance = int.Parse(Request.Form["Balance"]);
        string DateOfService = Request.Form["DateOfService"];
        string BillDateFrom = Request.Form["hdnBillDateFrom"];
        string BillDateTo = Request.Form["BillDateTo"];
        int Rows = int.Parse(Request.Form["Rows"]);
        int PageNumber = int.Parse(Request.Form["PageNumber"]);
        string SortBy = Request.Form["SortBy"];
        DataSet dsReportData = objPatientReportsDB.GetUnpaidInsuranceClaims(PracticeId, Rows, PageNumber, SortBy, PayerId, ProviderId, PracticeLocationId, Balance, DateOfService, BillDateFrom, BillDateTo);

        rptUnpaidInsuranceClaims.DataSource = dsReportData.Tables[0];
        rptUnpaidInsuranceClaims.DataBind();
        ltrTotalRows.Text = dsReportData.Tables[1].Rows[0]["TotalRows"].ToString();
    }
    protected void rptUnpaidInsuranceClaims_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView drv = (DataRowView)e.Item.DataItem;
            Label lblProcedures = (Label)e.Item.FindControl("lblProcedures");
            Label lblCharges = (Label)e.Item.FindControl("lblCharges");
            Label lblAdjust = (Label)e.Item.FindControl("lblAdjust");
            Label lblReceipts = (Label)e.Item.FindControl("lblBalance");
            Label lblBalance = (Label)e.Item.FindControl("lblBalance");
            if (!string.IsNullOrEmpty(drv["Patient"].ToString()) && string.IsNullOrEmpty(drv["Encounter"].ToString()))
            {
                lblProcedures.Style.Add("font-weight", "bold");
                lblProcedures.Style.Add("float", "left");
                lblProcedures.Text = "Total : ";
            }
            else if (string.IsNullOrEmpty(drv["Patient"].ToString()) && string.IsNullOrEmpty(drv["Encounter"].ToString()))
            {
                lblProcedures.Style.Add("font-weight", "bold");
                lblProcedures.Style.Add("float", "left");
                lblProcedures.Text = "Grand Total : ";
            }
            else
            {
                lblProcedures.Text = drv["Procedures"].ToString();
            }
            if (!string.IsNullOrEmpty(drv["Charges"].ToString()))
                lblCharges.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(drv["Charges"].ToString()));

            //if (!string.IsNullOrEmpty(drv["Adjust"].ToString()))
            //    lblAdjust.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(drv["Adjust"].ToString()));

            //if (!string.IsNullOrEmpty(drv["Receipts"].ToString()))
            //    lblReceipts.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(drv["Receipts"].ToString()));

            //if (!string.IsNullOrEmpty(drv["Balance"].ToString()))
            //    lblBalance.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(drv["Balance"].ToString()));
        }
    }
}