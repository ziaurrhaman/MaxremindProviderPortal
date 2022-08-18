using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class EMR_ReportsNew_filter_FilterPatientCollectionDetail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();
        long PracticeId = Profile.PracticeId;
        string AgingType = Request.Form["AgingType"];
        string AgingDate = Request.Form["AgingDate"];
        string PracticeLocationId = Request.Form["PracticeLocationId"];
        string ProviderId = Request.Form["ProviderId"];
        string PatientId = Request.Form["PatientId"];
        int Rows = int.Parse(Request.Form["Rows"]);
        int PageNumber = int.Parse(Request.Form["PageNumber"]);
        string SortBy = Request.Form["SortBy"];
        DataSet dsReportData = objPatientReportsDB.GetPatientCollectionDetail(PracticeId, Rows, PageNumber, SortBy, AgingType, AgingDate, PracticeLocationId, ProviderId, PatientId);

        rptReportData.DataSource = dsReportData.Tables[0];
        rptReportData.DataBind();
        ltrTotalRows.Text = dsReportData.Tables[1].Rows[0]["TotalRows"].ToString();
    }
    protected void rptReportData_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView drv = (DataRowView)e.Item.DataItem;
            Label lblBalanceOver90 = (Label)e.Item.FindControl("lblBalanceOver90");
            Label lblTotalBalance = (Label)e.Item.FindControl("lblTotalBalance");

            if (!string.IsNullOrEmpty(drv["BalanceOver90"].ToString()))
                lblBalanceOver90.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(drv["BalanceOver90"].ToString()));

            if (!string.IsNullOrEmpty(drv["TotalBalance"].ToString()))
                lblTotalBalance.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(drv["TotalBalance"].ToString()));
        }
    }
   
}