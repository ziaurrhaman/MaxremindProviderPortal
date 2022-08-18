using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EMR_ReportsNew_CallBacks_PatientBalanceDetailReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();
        //long PatientIds = long.Parse(Request.Form["PatientIds"].ToString());
        string PatientIds = "";
       // hdnPatientId.Value = Request.Form["PatientIds"].ToString();
       // hdnProcedureCode.Value = Request.Form["ProcedureCode"].ToString();
        string DOB = Request.Form["DateTo"];
        string CustomDate = "Today";
        hdnDOB.Value = DOB;
        hdnCustomDate.Value = CustomDate;
        if (CustomDate != "")
        {
            TimeSpan.Text = DOB;
        }
        else
        {
            if (DOB != "")
            {
                TimeSpan.Text = DOB;
            }
            else
            {
                TimeSpan.Text = "All Records";
            }
        }
        long PracticeId = Profile.PracticeId;
        string ProcedureCode = Request.Form["ProcedureCode"];
        //string DOB = Request.Form["AsOf"];
        //string CustomDate = Request.Form["CustomDate"];
        DataSet dsReportData = objPatientReportsDB.dsPatientBalanceDetail(PracticeId, 10, 0, "servicedate asc", PatientIds, ProcedureCode, CustomDate, DOB);
        DataTable dtReportData = dsReportData.Tables[0];

        rptPatientBalanceDetail.DataSource = dsReportData;
        rptPatientBalanceDetail.DataBind();
        // Control FooterTemplate = rptPatientBalanceDetail.Controls[rptPatientBalanceDetail.Controls.Count - 1].Controls[0];
        if (dtReportData.Rows.Count > 0)
        {
            if (!string.IsNullOrEmpty(dtReportData.Rows[0]["charges"].ToString()))
            {
                float TotalCharges = float.Parse(dtReportData.Compute("sum(charges)", string.Empty).ToString());
                //Label lblTotalCharges = FooterTemplate.FindControl("lblTotalCharges") as Label;
                lblTotalCharges.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(TotalCharges));
            }
        }
        if (dtReportData.Rows.Count > 0)
        {
            if (!string.IsNullOrEmpty(dtReportData.Rows[0]["adjustments"].ToString()))
            {
                float TotalAdjustments = float.Parse(dtReportData.Compute("sum(adjustments)", string.Empty).ToString());
                //Label lblTotalAdjustments = FooterTemplate.FindControl("lblTotalAdjustments") as Label;
                lblTotalAdjustments.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(TotalAdjustments));
            }
        }

        if (dtReportData.Rows.Count > 0)
        {
            if (!string.IsNullOrEmpty(dtReportData.Rows[0]["Insurancepmt"].ToString()))
            {
                float TotalInsurancePayments = float.Parse(dtReportData.Compute("sum(Insurancepmt)", string.Empty).ToString());
                //Label lblTotalInsurancePayments = FooterTemplate.FindControl("lblTotalInsurancePayments") as Label;
                lblTotalInsurancePayments.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(TotalInsurancePayments));
            }
        }
        if (dtReportData.Rows.Count > 0)
        {
            if (!string.IsNullOrEmpty(dtReportData.Rows[0]["PatientPmt"].ToString()))
            {
                float TotalPatientPayments = float.Parse(dtReportData.Compute("sum(PatientPmt)", string.Empty).ToString());
                //Label lblTotalPatientPayments = FooterTemplate.FindControl("lblTotalPatientPayments") as Label;
                lblTotalPatientPayments.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(TotalPatientPayments));
            }
        }

        if (dtReportData.Rows.Count > 0)
        {
            if (!string.IsNullOrEmpty(dtReportData.Rows[0]["PatientPmt"].ToString()))
            {
                float TotalBalance = float.Parse(dtReportData.Compute("sum(TotalBalance)", string.Empty).ToString());
                //Label lblTotalBalance = FooterTemplate.FindControl("lblGrandTotalBalance") as Label;
                lblGrandTotalBalance.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(TotalBalance));
            }
        }
        if (dtReportData.Rows.Count > 0)
        {
            if (!string.IsNullOrEmpty(dtReportData.Rows[0]["PendingIns"].ToString()))
            {
                float TotalPendingIns = float.Parse(dtReportData.Compute("sum(PendingIns)", string.Empty).ToString());
                //Label lblPendingIns = FooterTemplate.FindControl("lblPendingIns") as Label;
                lblPendingIns.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(TotalPendingIns));
            }
        }

        if (dtReportData.Rows.Count > 0)
        {
            if (!string.IsNullOrEmpty(dtReportData.Rows[0]["Patientbalance"].ToString()))
            {
                float TotalPatientbalance = float.Parse(dtReportData.Compute("sum(Patientbalance)", string.Empty).ToString());
                //Label lblPatientbalance = FooterTemplate.FindControl("lblPatientbalance") as Label;
                lblPatientbalance.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(TotalPatientbalance));
            }
        }

        hdnTotalRows.Value = dsReportData.Tables[1].Rows[0]["TotalRows"].ToString();
        string[] date = DOB.Split(new Char[] { '-' });
        //string MonthName = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(int.Parse(date[1]));
        TimeSpan.Text = date[1] + "/" + date[2] + "/" + date[0];
    }
    protected void rptPatientBalanceDetail_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView drv = (DataRowView)e.Item.DataItem;
            if (!string.IsNullOrEmpty(drv["charges"].ToString()))
            {
                string charges = string.Format("{0:0,0.00}", Convert.ToDouble(drv["charges"].ToString()));
                Label lblCharges = (Label)e.Item.FindControl("lblCharges");
                lblCharges.Text = "$" + charges;
            }
            if (!string.IsNullOrEmpty(drv["adjustments"].ToString()))
            {
                string adjustments = string.Format("{0:0,0.00}", Convert.ToDouble(drv["adjustments"].ToString()));
                Label lbladjustments = (Label)e.Item.FindControl("lbladjustments");
                lbladjustments.Text = "$" + adjustments;
            }
            if (!string.IsNullOrEmpty(drv["Insurancepmt"].ToString()))
            {
                string Insurancepmt = string.Format("{0:0,0.00}", Convert.ToDouble(drv["Insurancepmt"].ToString()));
                Label lblInsurancepmt = (Label)e.Item.FindControl("lblInsurancepmt");
                lblInsurancepmt.Text = "$" + Insurancepmt;
            }
            if (!string.IsNullOrEmpty(drv["PatientPmt"].ToString()))
            {
                string PatientPmt = string.Format("{0:0,0.00}", Convert.ToDouble(drv["PatientPmt"].ToString()));
                Label lblPatientPmt = (Label)e.Item.FindControl("lblPatientPmt");
                lblPatientPmt.Text = "$" + PatientPmt;
            }
            if (!string.IsNullOrEmpty(drv["TotalBalance"].ToString()))
            {
                string TotalBalance = string.Format("{0:0,0.00}", Convert.ToDouble(drv["TotalBalance"].ToString()));
                Label lblTotalBalance = (Label)e.Item.FindControl("lblTotalBalance");
                lblTotalBalance.Text = "$" + TotalBalance;
            }
            if (!string.IsNullOrEmpty(drv["PendingIns"].ToString()))
            {
                string PendingIns = string.Format("{0:0,0.00}", Convert.ToDouble(drv["PendingIns"].ToString()));
                Label lblPendingIns = (Label)e.Item.FindControl("lblPendingIns");
                lblPendingIns.Text = "$" + PendingIns;
            }
            if (!string.IsNullOrEmpty(drv["Patientbalance"].ToString()))
            {
                string Patientbalance = string.Format("{0:0,0.00}", Convert.ToDouble(drv["Patientbalance"].ToString()));
                Label lblPatientbalance = (Label)e.Item.FindControl("lblPatientbalance");
                lblPatientbalance.Text = "$" + Patientbalance;
            }

        }
    }
}