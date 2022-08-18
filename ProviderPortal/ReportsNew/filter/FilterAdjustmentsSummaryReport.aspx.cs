using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProviderPortal_ReportsNew_filter_FilterAdjustmentsSummaryReport : System.Web.UI.Page
{
    string _DateFrom = "";
    string _DateTo = "";
    string _TimeSpan = ""; string DateType = ""; string ProviderId = "";
    string PracticeLocationId = ""; string PayerId = ""; string AdjustmentCode = "";
    string PatientId = ""; string ProcedureCode = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();
        long PracticeId = Profile.PracticeId;
        _DateFrom = Request.Form["BillDateFrom"];
        _DateTo = Request.Form["BillDateTo"];

        DateType = Request.Form["DateType"];
        ProviderId = Request.Form["ProviderId"];
        PracticeLocationId = Request.Form["PracticeLocationId"];
        PayerId = Request.Form["PayerId"];
        AdjustmentCode = Request.Form["AdjustmentCode"];
        if (AdjustmentCode == null)
        {
            AdjustmentCode = "";
        }
        else
        {
            AdjustmentCode = Request.Form["AdjustmentCode"];
        }
        PatientId = Request.Form["PatientIds"];
        ProcedureCode = Request.Form["ProcedureCode"];
        DataSet dsReportData = objPatientReportsDB.AdjustmentsSummary(PracticeId, DateType, ProviderId, PracticeLocationId, PayerId, AdjustmentCode, ProcedureCode, PatientId, _DateFrom, _DateTo);

        rptAdjustmentsSummary.DataSource = dsReportData.Tables[0];
        rptAdjustmentsSummary.DataBind();

        // hdnTotalRows.Value = dsReportData.Tables[1].Rows[0]["TotalRows"].ToString();
        //SetDatesObjects();
        //Control FooterTemplate = rptAdjustmentsSummary.Controls[rptAdjustmentsSummary.Controls.Count - 1].Controls[0];
       // Label lblPracticeName = FooterTemplate.FindControl("lblPracticeName") as Label;
       // lblPracticeName.Text = Profile.PracticeName;
        //int Rows = int.Parse(hdnTotalRows.Value);
        DataTable dtReportData = dsReportData.Tables[0];
        if (dtReportData.Rows.Count > 0)
        {
            if (!string.IsNullOrEmpty(dtReportData.Rows[0]["TotalAdjustments"].ToString()))
            {
                float Total = float.Parse(dtReportData.Compute("sum(TotalAdjustments)", string.Empty).ToString());
               // Label lblTotal = FooterTemplate.FindControl("lblTotal") as Label;
                lblTotal.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(Total));
            }
        }
        TimeSpan.Text = _DateFrom + "-" + _DateTo;
        ltrTotalRows.Text = "0";
        //hdnTotalRows.Value = "0";
        hdnProviderId.Value = ProviderId;
        hdnPracticeLocationId.Value = PracticeLocationId;
        hdnPayerId.Value = PayerId;
        hdnAdjustmentCode.Value = AdjustmentCode;
        hdnProcedureCode.Value = ProcedureCode;
        hdnDateFrom.Value = _DateFrom;
        hdnDateTo.Value = _DateTo;
        hdnDateType.Value = DateType;
        string[] DateFrom = _DateFrom.Split(new Char[] { '-' });
        string[] DateTo = _DateTo.Split(new Char[] { '-' });
        TimeSpan.Text = DateFrom[1] + "/" + DateFrom[2] + "/" + DateFrom[0] + "-" + DateTo[1] + "/" + DateTo[2] + "/" + DateTo[0];

    }
    protected void rptAdjustmentsSummary_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView drv = (DataRowView)e.Item.DataItem;
            string total = drv["TotalAdjustments"].ToString();
            Label lblSubTotal = (Label)e.Item.FindControl("lblSubTotal");
            if (total != "")
            {
                lblSubTotal.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(total));
            }
        }
    }
}