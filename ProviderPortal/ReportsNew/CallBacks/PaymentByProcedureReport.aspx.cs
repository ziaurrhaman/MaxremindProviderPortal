using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class EMR_ReportsNew_CallBacks_PaymentByProcedureReport : System.Web.UI.Page
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

        DataSet dsReportData = objPatientReportsDB.GetPaymentByProcedure(PracticeId, 10, 0, "Code asc", _DateFrom, _DateTo);

        rptPaymentByProcedure.DataSource = dsReportData.Tables[0];
        rptPaymentByProcedure.DataBind();
        hdnTotalRows.Value = dsReportData.Tables[1].Rows[0]["TotalRows"].ToString();
        int Rows = int.Parse(hdnTotalRows.Value);
        DataTable dtReportData = objPatientReportsDB.GetTotalPaymentByProcedure(PracticeId, Rows, 0, "PatientName asc", _DateFrom, _DateTo);


       
        Control FooterTemplate = rptPaymentByProcedure.Controls[rptPaymentByProcedure.Controls.Count - 1].Controls[0];
        if (dtReportData.Rows.Count > 0)
        {
            if (!string.IsNullOrEmpty(dtReportData.Rows[0]["AvgPaymentByPrimary"].ToString()))
            {
                float TotalAvgPaymentByPrimary = float.Parse(dtReportData.Compute("sum(AvgPaymentByPrimary)", string.Empty).ToString());
                Label lblTotaAvgPaymentByPrimary = FooterTemplate.FindControl("lblTotaAvgPaymentByPrimary") as Label;
                lblTotaAvgPaymentByPrimary.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(TotalAvgPaymentByPrimary));
            }
        }
        if (dtReportData.Rows.Count > 0)
        {
            if (!string.IsNullOrEmpty(dtReportData.Rows[0]["AvgPaymentBySecondary"].ToString()))
            {
                float TotalAvgPaymentBySecondary = float.Parse(dtReportData.Compute("sum(AvgPaymentBySecondary)", string.Empty).ToString());
                Label lblTotalAvgPaymentBySecondary = FooterTemplate.FindControl("lblTotalAvgPaymentBySecondary") as Label;
                lblTotalAvgPaymentBySecondary.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(TotalAvgPaymentBySecondary));
            }
        }

        if (dtReportData.Rows.Count > 0)
        {
            if (!string.IsNullOrEmpty(dtReportData.Rows[0]["AvgPaymentByPatient"].ToString()))
            {
                float TotalAvgPaymentByPatient = float.Parse(dtReportData.Compute("sum(AvgPaymentByPatient)", string.Empty).ToString());
                Label lblTotalAvgPaymentByPatient = FooterTemplate.FindControl("lblTotalAvgPaymentByPatient") as Label;
                lblTotalAvgPaymentByPatient.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(TotalAvgPaymentByPatient));
            }
        }
        if (dtReportData.Rows.Count > 0)
        {
            if (!string.IsNullOrEmpty(dtReportData.Rows[0]["AvgTotalPayment"].ToString()))
            {
                float TotalAvgTotalPayment = float.Parse(dtReportData.Compute("sum(AvgTotalPayment)", string.Empty).ToString());
                Label lblTotalAvgTotalPayment = FooterTemplate.FindControl("lblTotalAvgTotalPayment") as Label;
                lblTotalAvgTotalPayment.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(TotalAvgTotalPayment));
            }
        }
    }

    protected void rptPaymentByProcedure_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView drv = (DataRowView)e.Item.DataItem;
            string AvgPaymentByPrimary = drv["AvgPaymentByPrimary"].ToString();
            Label lblAvgPaymentByPrimary = (Label)e.Item.FindControl("lblAvgPaymentByPrimary");
            if (AvgPaymentByPrimary != "")
            {
                lblAvgPaymentByPrimary.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(AvgPaymentByPrimary));
            }
            string AvgPaymentBySecondary = drv["AvgPaymentBySecondary"].ToString();
            Label lblAvgPaymentBySecondary = (Label)e.Item.FindControl("lblAvgPaymentBySecondary");
            if (AvgPaymentBySecondary != "")
            {
                lblAvgPaymentBySecondary.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(AvgPaymentBySecondary));
            }
            string AvgPaymentByPatient = drv["AvgPaymentByPatient"].ToString();
            Label lblAvgPaymentByPatient = (Label)e.Item.FindControl("lblAvgPaymentByPatient");
            if (AvgPaymentByPatient != "")
            {
                lblAvgPaymentByPatient.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(AvgPaymentByPatient));
            }
            string AvgTotalPayment = drv["AvgTotalPayment"].ToString();
            Label lblAvgTotalPayment = (Label)e.Item.FindControl("lblAvgTotalPayment");
            if (AvgTotalPayment != "")
            {
                lblAvgTotalPayment.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(AvgTotalPayment));
            }
        }
    }


}