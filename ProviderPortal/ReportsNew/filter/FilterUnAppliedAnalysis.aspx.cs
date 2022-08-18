using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class ProviderPortal_ReportsNew_filter_FilterUnAppliedAnalysis : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();
        long PracticeId = Profile.PracticeId;
        string _DateFrom = "";
        string _DateTo = "";
        string _TimeSpan = "";
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
        string Payers = Request.Form["Insurance"];
        string PaymentType = Request.Form["PaymentType"];
        DataSet dsReportData = objPatientReportsDB.GetUnappliedAnalysis(PracticeId, _DateFrom, _DateTo, Payers, PaymentType);

        rptUnappliedAnalysis.DataSource = dsReportData.Tables[0];
        rptUnappliedAnalysis.DataBind();
        //ltrTotalRows.Text = "NoRows";
        DataTable dtReportData = dsReportData.Tables[0];
        Control HeaderTemplate = rptUnappliedAnalysis.Controls[rptUnappliedAnalysis.Controls.Count - 1].Controls[0];
        Control FooterTemplate = rptUnappliedAnalysis.Controls[rptUnappliedAnalysis.Controls.Count - 1].Controls[0];

        if (dtReportData.Rows.Count > 0)
        {
            if (!string.IsNullOrEmpty(dtReportData.Rows[0]["Amt"].ToString()) && !string.IsNullOrEmpty(dtReportData.Rows[0]["UnappliedBalance"].ToString()))
            {
                string firstRow = dtReportData.Rows[0][0].ToString();
                if (firstRow != "")
                {

                    lblBeginingUnappliedBalance.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(decimal.Parse(dtReportData.Rows[0]["UnappliedBalance"].ToString()) - decimal.Parse(dtReportData.Rows[0]["Amt"].ToString().Replace("(", "").Replace(")", ""))));
                }
            }
            DataRow lastRow = dtReportData.Rows[dtReportData.Rows.Count - 1];
            if (!string.IsNullOrEmpty(lastRow["UnappliedBalance"].ToString()))
            {
                float LastTotalUnappliedBalance;
                LastTotalUnappliedBalance = float.Parse(lastRow["UnappliedBalance"].ToString());
                string ToatalChangeInUnapliedBallance = string.Format("{0:0,0.00}", Convert.ToDouble(decimal.Parse(lastRow["UnappliedBalance"].ToString()) - (decimal.Parse(dtReportData.Rows[0]["UnappliedBalance"].ToString()) - decimal.Parse(dtReportData.Rows[0]["Amt"].ToString().Replace("(", "").Replace(")", "")))).ToString());
                Label lblChangeInUnapliedBallance = HeaderTemplate.FindControl("lblChangeInUnapliedBallance") as Label;
                lblChangeInUnapliedBallance.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(ToatalChangeInUnapliedBallance));
                Label lblEndingUnappliedBalance = HeaderTemplate.FindControl("lblEndingUnappliedBalance") as Label;
                lblEndingUnappliedBalance.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(lastRow["UnappliedBalance"].ToString()));
            }

        }
        TimeSpan.Text = _DateFrom + "-" + _DateTo;
        hdnDateFrom.Value = _DateFrom;
        hdnDateTo.Value = _DateTo;
        hdnInsuranceId.Value = Payers;
        hdnPaymentType.Value = PaymentType;
    }
    protected void rptUnappliedAnalysis_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView drv = (DataRowView)e.Item.DataItem;
            int index = e.Item.ItemIndex;
            string amount = drv["Amt"].ToString();
            string ClaimId = drv["ClaimId"].ToString();
            Label lblClaimId = (Label)e.Item.FindControl("lblClaimId");
            if (ClaimId != "0")
            {
                lblClaimId.Text = ClaimId;
            }
            string UnappliedBalance = string.Format("{0:0,0.00}", Convert.ToDouble(drv["UnappliedBalance"].ToString()));
            Label lblAmt = (Label)e.Item.FindControl("lblAmt");
            if (amount != "")
            {
                if (amount.Contains("("))
                    lblAmt.Text = amount.Insert(1, "$");
                else
                    lblAmt.Text = "$" + amount;
            }
            Label lblUnappliedBalance = (Label)e.Item.FindControl("lblUnappliedBalance");
            if (UnappliedBalance != "")
                lblUnappliedBalance.Text = "$" + UnappliedBalance;

        }

    }
}