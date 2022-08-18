using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProviderPortal_Reports_CallBacks_FilterPatientBalanceDetailsReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();
        long PatientIds = long.Parse(Request.Form["PatientId"].ToString());
        long PracticeId = Profile.PracticeId;
        string ProcedureCode = Request.Form["ProcedureCode"];
        string DOB = Request.Form["DOB"];
        string CustomDate = Request.Form["CustomDate"];
        int Rows = int.Parse(Request.Form["Rows"]);
        int PageNumber = int.Parse(Request.Form["PageNumber"]);
        string SortBy = Request.Form["SortBy"];
        DataSet dtReportData = objPatientReportsDB.dsPatientBalanceDetail(PracticeId, Rows, PageNumber, SortBy, PatientIds, ProcedureCode, CustomDate, DOB);

        rptPatientBalanceDetail.DataSource = dtReportData;
        rptPatientBalanceDetail.DataBind();

        ltrTotalRows.Text = dtReportData.Tables[1].Rows[0]["TotalRows"].ToString();
    }
    protected void rptPatientBalanceDetail_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView drv = (DataRowView)e.Item.DataItem;
            if (!string.IsNullOrEmpty(drv["charges"].ToString()))
            {
                string charges = string.Format("{0:0,0.00}", Convert.ToDouble(drv["charges"].ToString()));
                Label lblCharges = (Label)e.Item.FindControl("lblCharges");
                lblCharges.Text = "$" + charges;
            }
            if (!string.IsNullOrEmpty(drv["adjustments"].ToString()))
            {
                string adjustments = string.Format("{0:0,0.00}", Convert.ToDouble(drv["adjustments"].ToString()));
                Label lbladjustments = (Label)e.Item.FindControl("lbladjustments");
                lbladjustments.Text = "$" + adjustments;
            }
            if (!string.IsNullOrEmpty(drv["Insurancepmt"].ToString()))
            {
                string Insurancepmt = string.Format("{0:0,0.00}", Convert.ToDouble(drv["Insurancepmt"].ToString()));
                Label lblInsurancepmt = (Label)e.Item.FindControl("lblInsurancepmt");
                lblInsurancepmt.Text = "$" + Insurancepmt;
            }
            if (!string.IsNullOrEmpty(drv["PatientPmt"].ToString()))
            {
                string PatientPmt = string.Format("{0:0,0.00}", Convert.ToDouble(drv["PatientPmt"].ToString()));
                Label lblPatientPmt = (Label)e.Item.FindControl("lblPatientPmt");
                lblPatientPmt.Text = "$" + PatientPmt;
            }
            if (!string.IsNullOrEmpty(drv["TotalBalance"].ToString()))
            {
                string TotalBalance = string.Format("{0:0,0.00}", Convert.ToDouble(drv["TotalBalance"].ToString()));
                Label lblTotalBalance = (Label)e.Item.FindControl("lblTotalBalance");
                lblTotalBalance.Text = "$" + TotalBalance;
            }
            if (!string.IsNullOrEmpty(drv["PendingIns"].ToString()))
            {
                string PendingIns = string.Format("{0:0,0.00}", Convert.ToDouble(drv["PendingIns"].ToString()));
                Label lblPendingIns = (Label)e.Item.FindControl("lblPendingIns");
                lblPendingIns.Text = "$" + PendingIns;
            }
            if (!string.IsNullOrEmpty(drv["Patientbalance"].ToString()))
            {
                string Patientbalance = string.Format("{0:0,0.00}", Convert.ToDouble(drv["Patientbalance"].ToString()));
                Label lblPatientbalance = (Label)e.Item.FindControl("lblPatientbalance");
                lblPatientbalance.Text = "$" + Patientbalance;
            }
        }
    }
}