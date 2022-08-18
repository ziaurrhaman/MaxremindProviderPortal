using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProviderPortal_Reports_CallBacks_FilterPatientTransactionsDetailReport : System.Web.UI.Page
{ 
    string _DateFrom = "";
    string _DateTo = "";
    string _TimeSpan = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();
        long PracticeId = Profile.PracticeId;
        int Rows = int.Parse(Request.Form["Rows"]);
        int PageNumber = int.Parse(Request.Form["PageNumber"]);
        string SortBy = Request.Form["SortBy"];
        _DateFrom = Request.Form["DateFrom"];
        _DateTo = Request.Form["DateTo"];
        string PatientId = Request.Form["PatientId"];
        DataSet dsReportData = objPatientReportsDB.GetPatientTransactionsDetail(PracticeId, Rows, PageNumber, SortBy,PatientId, _DateFrom, _DateTo);

        rptPatientTransactionsDetail.DataSource = dsReportData.Tables[0];
        rptPatientTransactionsDetail.DataBind();
        ltrTotalRows.Text = dsReportData.Tables[1].Rows[0]["TotalRows"].ToString();
    }
protected void rptPatientTransactionsDetail_ItemDataBound(object sender, RepeaterItemEventArgs e)
{
    if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
    {
        DataRowView drv = (DataRowView)e.Item.DataItem;
        Label lblCharges = (Label)e.Item.FindControl("lblCharges");
        Label lblPayment = (Label)e.Item.FindControl("lblPayment");

        if (!string.IsNullOrEmpty(drv["Charges"].ToString()))
            lblCharges.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(drv["Charges"].ToString()));
        if (!string.IsNullOrEmpty(drv["Payment"].ToString()))
            lblPayment.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(drv["Payment"].ToString()));
    }
}
}