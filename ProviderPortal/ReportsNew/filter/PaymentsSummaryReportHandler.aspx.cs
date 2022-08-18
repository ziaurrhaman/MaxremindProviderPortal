using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProviderPortal_ReportsNew_filter_PaymentsSummaryReportHandler : System.Web.UI.Page
{

    string _DateFrom = "";
    string _DateTo = "";
    string _TimeSpan = "";
    string DateType = "";
    string PayerType = "";
    string Insurance = "";
    string ProviderIdbYNPI = "";
    string Patient = "";

    ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Request.Form["action"]))
        {

            long PracticeId = Profile.PracticeId;
            DateType = Request.Form["DateType"];
            _DateFrom = Request.Form["DateFrom"];
            PayerType = Request.Form["PayerType"];

            _DateTo = Request.Form["DateTo"];



            if (_DateFrom != "" && _DateTo != "")
            {

                TimeSpan1.Text = _DateFrom + "-" + _DateTo;
            }
            else
            {
                TimeSpan1.Text = "All Records";
            }

            if (!string.IsNullOrEmpty(Request.Form["InsuranceID"]))
            {
                Insurance = Request.Form["InsuranceID"];
            }

            if (DateType == "")
            {
                DateType = "PostDate";
            }
            ProviderIdbYNPI = Request.Form["ProviderIdbYNPI"];

            bool? IsImportedDataOnly = null;
            if (!string.IsNullOrEmpty(Session["IsImported"] as string))
            {

                if (Session["IsImported"].ToString() == "2") { IsImportedDataOnly = true; }
                else if (Session["IsImported"].ToString() == "1") { IsImportedDataOnly = false; }
                else { IsImportedDataOnly = null; }
            }

            DataSet dsReportData = objPatientReportsDB.GetPaymentsSummary(PracticeId, DateType, _DateFrom, _DateTo, PayerType, Insurance, Patient, ProviderIdbYNPI, IsImportedDataOnly);

            rptPaymentsSummary.DataSource = dsReportData.Tables[0];
            rptPaymentsSummary.DataBind();


            hdnTotalRows.Value = "NoRows";
            hdnDateType.Value = DateType;
            hdnDateFrom.Value = _DateFrom;
            hdnDateTo.Value = _DateTo;
        }
        else
        {
            LoadReport();
        }
    }

    private void LoadReport()
    {
        long PracticeId = Profile.PracticeId;

        DateType = Request.Form["DateType"];

        if (DateType == "")
        {
            DateType = "PostDate";
        }
        _DateFrom = Request.Form["DateFrom"];
        _DateTo = Request.Form["DateTo"];
         PayerType = Request.Form["PayerType"];
        string Provider = Request.Form["Provider"];
        string ProviderName = Request.Form["ProviderName"];


        if (ProviderName == "Total")
        {
            //Provider = "";
            Providerlbl.Text = ProviderName;
        }
        else
        {
            Providerlbl.Text = ProviderName;
        }

        if (_DateFrom != "" && _DateTo != "")
        {

            string[] DateFrom = _DateFrom.Split(new Char[] { '-' });
            string[] DateTo = _DateTo.Split(new Char[] { '-' });


            TimeSpan1.Text = DateFrom[1] + "/" + DateFrom[2] + "/" + DateFrom[0] + "-" + DateTo[1] + "/" + DateTo[2] + "/" + DateTo[0];
        }
        else
        {
            TimeSpan1.Text = "All Records";
        }

        bool? IsImportedDataOnly = null;
        if (!string.IsNullOrEmpty(Session["IsImported"] as string))
        {

            if (Session["IsImported"].ToString() == "2") { IsImportedDataOnly = true; }
            else if (Session["IsImported"].ToString() == "1") { IsImportedDataOnly = false; }
            else { IsImportedDataOnly = null; }
        }
        if (!string.IsNullOrEmpty(Request.Form["InsuranceID"]))
        {
            Insurance = Request.Form["InsuranceID"];
        }
        DataSet dsReportData = objPatientReportsDB.GetPaymentsSummary(PracticeId, DateType, _DateFrom, _DateTo, PayerType, Insurance, Patient, Provider, IsImportedDataOnly);

        rptPS.DataSource = dsReportData.Tables[1];
        rptPS.DataBind();

    }

}