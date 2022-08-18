using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EMR_ReportsNew_filter_FilterReportMonthlyReconciliation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();
        long PracticeId = Profile.PracticeId;
        int Rows = int.Parse(Request.Form["Rows"]);
        int PageNumber = int.Parse(Request.Form["PageNumber"]);
        string SortBy = Request.Form["SortBy"];
        string LocationId = Request.Form["LocationId"];
        string DateFrom = Request.Form["DateFrom"];
        string DateTo = Request.Form["DateTo"];
        string Provider = Request.Form["Provider"];
        string ProviderType = Request.Form["ProviderType"];

        DataSet dsReportData = objPatientReportsDB.GetMonthlyReconciliation(PracticeId, Rows, PageNumber, SortBy, ProviderType, long.Parse(LocationId), DateFrom, DateTo, Provider);

        rptMonthlyReconciliation.DataSource = dsReportData.Tables[0];
        rptMonthlyReconciliation.DataBind();
        ltrTotalRows.Text = dsReportData.Tables[1].Rows[0]["TotalRows"].ToString();
    }
    protected void rptMonthlyReconciliation_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView drv = (DataRowView)e.Item.DataItem;
            string checkNumber = drv["CheckNumber"].ToString();
            Label lblCheckNumber = (Label)e.Item.FindControl("lblCheckNumber");
            if (checkNumber == "")
            {
                lblCheckNumber.Style.Add("display", "none");
            }
            else
            {
                lblCheckNumber.Style.Add("display", "block");
            }
        }
    }
}