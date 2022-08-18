using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class EMR_ReportsNew_CallBacks_PaymentsSummaryReport : System.Web.UI.Page
{
    string _DateFrom = "";
    string _DateTo = "";
    string _TimeSpan = "";
    ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();

    protected void Page_Load(object sender, EventArgs e)
    {
        LoadReport();
    }
    private void LoadReport()
    {
        long PracticeId = Profile.PracticeId;
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
        DataSet dsReportData = objPatientReportsDB.GetPaymentsSummary(PracticeId, _DateFrom, _DateTo,null,null,null,null);

        rptPaymentsSummary.DataSource = dsReportData.Tables[0];
        rptPaymentsSummary.DataBind();
        GetTotal();
        hdnTotalRows.Value = "NoRows";
       


    }
    public void GetTotal()
    {
        DataTable dtReportData = objPatientReportsDB.GetTotalPaymentsSummary(Profile.PracticeId, _DateFrom, _DateTo, null, null, null, null);
        Control FooterTemplate = rptPaymentsSummary.Controls[rptPaymentsSummary.Controls.Count - 1].Controls[0];
        if (dtReportData.Rows.Count > 0)
        {
            Label lblGrandTotal = FooterTemplate.FindControl("lblGrandTotal") as Label;
            lblGrandTotal.Text = "Grand Total";
            if (!string.IsNullOrEmpty(dtReportData.Rows[0]["Payment"].ToString()))
            {
                float TotalAmount = float.Parse(dtReportData.Compute("sum(Payment)", string.Empty).ToString());
                Label lblTotalAmount = FooterTemplate.FindControl("lblTotalAmount") as Label;
                lblTotalAmount.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(TotalAmount));
            }
            if (!string.IsNullOrEmpty(dtReportData.Rows[0]["Unapplied"].ToString()))
            {
                float TotalUnapplied = float.Parse(dtReportData.Compute("sum(Unapplied)", string.Empty).ToString());
                Label lblTotalUnapplied = FooterTemplate.FindControl("lblTotalUnapplied") as Label;
                lblTotalUnapplied.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(TotalUnapplied));
            }
        }
    }
    protected void rptPaymentsSummary_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView drv = (DataRowView)e.Item.DataItem;
            string Amount = drv["Payment"].ToString();
            Label lblAmount = (Label)e.Item.FindControl("lblAmount");
            if (Amount != "")
            {
                lblAmount.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(Amount));
            }
            string Unapplied = drv["Unapplied"].ToString();
            Label lblUnapplied = (Label)e.Item.FindControl("lblUnapplied");
            if (Unapplied != "")
            {
                lblUnapplied.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(Unapplied));
            }
        }
    }
}