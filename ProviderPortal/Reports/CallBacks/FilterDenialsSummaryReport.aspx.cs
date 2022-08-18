using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
 
public partial class ProviderPortal_Reports_CallBacks_FilterDenialsSummaryReport : System.Web.UI.Page
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
        string DateType = Request.Form["DateType"];
        _DateFrom = Request.Form["DateFrom"];
        _DateTo = Request.Form["DateTo"];
        string ProviderId = Request.Form["ProviderId"];
        string PracticeLocationId = Request.Form["PracticeLocationId"];
        string Insurance = Request.Form["Insurance"];
        string AdjustmentCode = Request.Form["AdjustmentCode"];
        DataSet dsReportData = objPatientReportsDB.GetDenialsSummary(PracticeId, Rows, PageNumber, SortBy, DateType, _DateFrom, _DateTo, ProviderId, PracticeLocationId, Insurance, AdjustmentCode);

        rptDenialsSummary.DataSource = dsReportData.Tables[0];
        rptDenialsSummary.DataBind();
        ltrTotalRows.Text = dsReportData.Tables[1].Rows[0]["TotalRows"].ToString();
    }
    protected void rptDenialsSummary_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView drv = (DataRowView)e.Item.DataItem;
            Label lblTotal = (Label)e.Item.FindControl("lblTotal");

            if (!string.IsNullOrEmpty(drv["Total"].ToString()))
                lblTotal.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(drv["Total"].ToString()));
        }
    }
}