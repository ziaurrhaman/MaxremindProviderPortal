using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EMR_ReportsNew_CallBacks_SettledChargesSummaryReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();
        long PracticeId = Profile.PracticeId;
        string TimeSpan1 = Request.Form["TimeSpan"];
        string Patient = Request.Form["PatientIds"];
        string ProviderId = Request.Form["ProviderId"];
        string PracticeLocationId = Request.Form["PracticeLocationId"];
        string ProcedureCode = Request.Form["ProcedureCode"];
        string DateFrom = Request.Form["DateFrom"];
        string DateTo = Request.Form["DateTo"];




        DataSet dsReportData = objPatientReportsDB.SetteledChargesSummary(PracticeId, DateFrom, DateTo, Patient, ProviderId, PracticeLocationId, ProcedureCode);

        Charges.Text = dsReportData.Tables[0].Rows[0]["TotalCharges"].ToString();
        TotalCharges.Text = dsReportData.Tables[0].Rows[0]["TotalCharges"].ToString();

        ContractualAdjustments.Text = dsReportData.Tables[0].Rows[0]["ContractualAdjustment"].ToString();
        SecondaryAdjustments.Text = dsReportData.Tables[0].Rows[0]["SecondAdjustment"].ToString();
        OtherAdjustments.Text = dsReportData.Tables[0].Rows[0]["OtherAdjustments"].ToString();
        TotalAdjustments.Text = dsReportData.Tables[0].Rows[0]["TotalAdjustment"].ToString();

        PatientPayments.Text = dsReportData.Tables[0].Rows[0]["PatientPayment"].ToString();
        InsurancePayments.Text = dsReportData.Tables[0].Rows[0]["InsurancePayments"].ToString();
        TotalPayments.Text = dsReportData.Tables[0].Rows[0]["TotalPayment"].ToString();


        if (TimeSpan1 == "SpecificDates")
        {
            TimeSpan.Text = DateFrom + '-' + DateTo;
        }
        else
        {
            TimeSpan.Text = TimeSpan1;
        }
        hdnTotalRows.Value = "NoRows";
    }
}