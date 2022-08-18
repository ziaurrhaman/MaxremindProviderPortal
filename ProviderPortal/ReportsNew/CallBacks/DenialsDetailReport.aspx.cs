using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EMR_ReportsNew_CallBacks_DenialsDetailReport : System.Web.UI.Page
{
    string _DateFrom = "";
    string _DateTo = "";
    string _TimeSpan = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadReport();
    }
    private void LoadReport()
    {
        ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();
        long PracticeId = Profile.PracticeId;
        string DateType = Request.Form["DateType"];
        _DateFrom = Request.Form["DateFrom"];
        _DateTo = Request.Form["DateTo"];
        if (_DateFrom != "" && _DateTo != "")
        {

            TimeSpan.Text = _DateFrom + "-" + _DateTo;
        }
        else
        {
            TimeSpan.Text = "All Records";
        }

        string ProviderId = Request.Form["ProviderId"];
        string PracticeLocationId = Request.Form["PracticeLocationId"];
        string Insurance = Request.Form["Insurance"];
        string AdjustmentCode = Request.Form["AdjustmentCode"];
        hdnDateType.Value = Request.Form["DateType"];
        hdnProviderId.Value = Request.Form["ProviderId"];
        hdnPracticeLocationId.Value = Request.Form["PracticeLocationId"];
        hdnDateFrom.Value = Request.Form["DateFrom"];
        hdnDateTo.Value = Request.Form["DateTo"];
        hdnInsurance.Value = Request.Form["Insurance"];
        hdnAdjustmentCode.Value = Request.Form["AdjustmentCode"];
        DataSet dsReportData = objPatientReportsDB.GetDenialsDetail(PracticeId, 10, 0, "ClaimId ASC", DateType, _DateFrom, _DateTo, ProviderId, PracticeLocationId, Insurance, AdjustmentCode);

        rptDenialsDetail.DataSource = dsReportData.Tables[0];
        rptDenialsDetail.DataBind();
        hdnTotalRows.Value = dsReportData.Tables[1].Rows[0]["TotalRows"].ToString();
       

    }
    protected void rptDenialsDetail_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView drv = (DataRowView)e.Item.DataItem;
            Label lblCharges = (Label)e.Item.FindControl("lblCharges");
            Label lblDenied = (Label)e.Item.FindControl("lblDenied");

            if (!string.IsNullOrEmpty(drv["Charges"].ToString()))
                lblCharges.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(drv["Charges"].ToString()));

            if (!string.IsNullOrEmpty(drv["Denied"].ToString()))
                lblDenied.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(drv["Denied"].ToString()));
        }
    }
}