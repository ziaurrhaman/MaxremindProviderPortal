using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class EMR_ReportsNew_CallBacks_PatientCollectionDetail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadReport();
    }
    private void LoadReport()
    {
        ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();
        long PracticeId = Profile.PracticeId;
        string AgingDate = Request.Form["AgingDate"];
        string AgingType = Request.Form["AgingType"];
        string PracticeLocationId = Request.Form["PracticeLocationId"].ToString();
        string ProviderId = Request.Form["ProviderId"].ToString();
        string PatientId = Request.Form["PatientId"].ToString();
        hdnAgingDate.Value = Request.Form["AgingDate"];
        hdnAgingType.Value = Request.Form["AgingType"];
        hdnPracticeLocationId.Value = Request.Form["PracticeLocationId"].ToString();
        hdnPatientId.Value = Request.Form["PatientId"].ToString();
        hdnProviderId.Value = Request.Form["ProviderId"].ToString();
        DataSet dsReportData = objPatientReportsDB.GetPatientCollectionDetail(PracticeId, 10, 0, "PatientId asc", AgingType, AgingDate, PracticeLocationId, ProviderId, PatientId);

        rptPatientCollectionDetail.DataSource = dsReportData.Tables[0];
        rptPatientCollectionDetail.DataBind();
        hdnTotalRows.Value = dsReportData.Tables[1].Rows[0]["TotalRows"].ToString();


    }
    protected void rptPatientCollectionDetail_ItemDataBound(object sender, RepeaterItemEventArgs e)
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