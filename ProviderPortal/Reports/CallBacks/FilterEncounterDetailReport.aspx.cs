using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class ProviderPortal_Reports_CallBacks_FilterEncounterDetailReport : System.Web.UI.Page
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
        string PayerId = Request.Form["PayerId"];
        string SubmissionStatusId = Request.Form["SubmissionStatus"];

        DataSet dsReportData = objPatientReportsDB.GetEncounterDetail(PracticeId, Rows, PageNumber, SortBy, DateType, SubmissionStatusId, _DateFrom, _DateTo, ProviderId, PracticeLocationId, PayerId);
        rptDenialsDetail.DataSource = dsReportData.Tables[0];
        rptDenialsDetail.DataBind();
        ltrTotalRows.Text = dsReportData.Tables[1].Rows[0]["TotalRows"].ToString();
    }

    protected void rptDenialsDetail_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        //if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        //{
        //    DataRowView drv = (DataRowView)e.Item.DataItem;
        //    Label lblCharges = (Label)e.Item.FindControl("lblCharges");
        //    Label lblDenied = (Label)e.Item.FindControl("lblDenied");

        //    if (!string.IsNullOrEmpty(drv["Charges"].ToString()))
        //        lblCharges.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(drv["Charges"].ToString()));

        //    if (!string.IsNullOrEmpty(drv["Denied"].ToString()))
        //        lblDenied.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(drv["Denied"].ToString()));
        //}
    }
}