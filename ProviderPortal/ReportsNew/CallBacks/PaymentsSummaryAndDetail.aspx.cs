using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.HtmlControls;
using System.Globalization;

public partial class EMR_ReportsNew_CallBacks_PaymentsSummaryReport : System.Web.UI.Page
{
    string _DateFrom = "";
    string _DateTo = "";
    string _TimeSpan = "";
    string DateType = "";
    string ProviderIdbYNPI = "";
    string Insurance = "";
    string Patient = "";
    ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();
  
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadReport();
        LoadPayersFromClaim();
        LoadProvider();
    }
    private void LoadReport()
    {
        long PracticeId = Profile.PracticeId;
        DateType = Request.Form["DateType"];
        _DateFrom = Request.Form["DateFrom"];
        _DateTo = Request.Form["DateTo"].ToString();

       


       

        if (DateType == "")
        {
            DateType = "PostDate";
        }
        //ProviderIdbYNPI =  Request.Form["ProviderIdbYNPI"];
        //if (ProviderIdbYNPI == "All")
        //{
        //    ProviderIdbYNPI = "";
        //}
        bool? IsImportedDataOnly = null;
        if (!string.IsNullOrEmpty(Session["IsImported"] as string))
        {

            if (Session["IsImported"].ToString() == "2") { IsImportedDataOnly = true; }
            else if (Session["IsImported"].ToString() == "1") { IsImportedDataOnly = false; }
            else { IsImportedDataOnly = null; }
        }

        DataSet dsReportData = objPatientReportsDB.GetPaymentsSummary(PracticeId, DateType, _DateFrom, _DateTo, "", Insurance, Patient, ProviderIdbYNPI, IsImportedDataOnly);

        rptPaymentsSummary.DataSource = dsReportData.Tables[0];
        rptPaymentsSummary.DataBind();

       
        hdnTotalRows.Value = "NoRows";
        hdnDateType.Value = DateType;
        hdnDateFrom.Value = _DateFrom;
        hdnDateTo.Value = _DateTo;

    }

    //public void LoadPracticeStaffOnNPI()
    //{
    //    ServiceProviderDB serviceProviderDB = new ServiceProviderDB();
    //    DataTable dtPayerName = serviceProviderDB.GetPracticeStaffonNPINum(Profile.PracticeId);
    //    ddlPracticeStaffOnNpiNum.DataSource = dtPayerName;
    //    ddlPracticeStaffOnNpiNum.DataTextField = "Providers";
    //    ddlPracticeStaffOnNpiNum.DataValueField = "StaffNPI";
    //    ddlPracticeStaffOnNpiNum.DataBind();
    //    ddlPracticeStaffOnNpiNum.Items.Insert(0, new ListItem("All", ""));
    //}

    public void LoadPayersFromClaim()
    {
        InsuranceDB insuranceDB = new InsuranceDB();
        long PracticeId = Profile.PracticeId;
        DataTable dtPatient = insuranceDB.GetPayersByPracticeId(PracticeId, "", "");
        rptPayerScenario.DataSource = dtPatient;
        rptPayerScenario.DataBind();

    }
    public void LoadProvider()
    {
        string PracticeLocationId = Request.Form["PracticeLocationId"];
        ReportsDB db = new ReportsDB();
        DataTable ds = db.GetProvidersByDefault(Profile.PracticeId);
        rptProviders.DataSource = ds;
        rptProviders.DataBind();
    }
}