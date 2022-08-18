using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EMR_ReportsNew_CallBacks_DenialsSummaryReport : System.Web.UI.Page
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
        DataSet dsReportData = objPatientReportsDB.GetDenialsSummary(PracticeId, 10, 0, "ClaimId ASC", DateType, _DateFrom, _DateTo, ProviderId, PracticeLocationId, Insurance, AdjustmentCode);

        rptDenialsSummary.DataSource = dsReportData.Tables[0];
        rptDenialsSummary.DataBind();
        hdnTotalRows.Value = dsReportData.Tables[1].Rows[0]["TotalRows"].ToString();
      

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
