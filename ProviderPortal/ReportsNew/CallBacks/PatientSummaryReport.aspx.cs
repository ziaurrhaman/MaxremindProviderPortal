using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EMR_ReportsNew_CallBacks_PatientSummaryReport : System.Web.UI.Page
{
    string _DateFrom = "";
    string _DateTo = "";
    string _TimeSpan = "";
    ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();

    protected void Page_Load(object sender, EventArgs e)
    {
        long PracticeId = Profile.PracticeId;
       // hdnPracticeId.Value = Convert.ToString(Profile.PracticeId);
        string DateType = Request.Form["DateType"];
        string ProviderId = Request.Form["ProviderId"];
        string PracticeLocationId = Request.Form["PracticeLocationId"];
        string PayerId = Request.Form["PayerId"];
        string DateFrom = Request.Form["Datefrom"];
        string DateTo = Request.Form["Dateto"];
        hdnDateFrom.Value = DateFrom;
        hdnDateTo.Value = DateTo;
        hdnDateType.Value = DateType;

        hdnPayer.Value = PayerId;
        hdnProvider.Value = ProviderId;
        hdnLocation.Value = PracticeLocationId;

        DataSet dsReportData = objPatientReportsDB.PatientSummary(PracticeId, 10, 0, "Payer ASC", DateType, ProviderId, PracticeLocationId, PayerId, DateFrom, DateTo);
        // string subTotal = dtReportData.Rows[1]["TotalPatient"].ToString();

        rptPatientSummary.DataSource = dsReportData.Tables[0];
        rptPatientSummary.DataBind();
        //Control FooterTemplate = rptPatientSummary.Controls[rptPatientSummary.Controls.Count - 1].Controls[0];
        //Label lblPracticeName = FooterTemplate.FindControl("lblPracticeName") as Label;
        lblPracticeName.Text = Profile.PracticeName;
        hdnTotalRows.Value = dsReportData.Tables[1].Rows[0]["TotalRows"].ToString();
        int Rows = int.Parse(hdnTotalRows.Value);
        DataTable dtReportData = dsReportData.Tables[0];
        if (dtReportData.Rows.Count > 0)
        {
            if (!string.IsNullOrEmpty(dtReportData.Rows[0]["TotalPatient"].ToString()))
            {
                int Total = int.Parse(dtReportData.Compute("sum(TotalPatient)", string.Empty).ToString());
                //Label lblTotal = FooterTemplate.FindControl("lblTotal") as Label;
                lblTotal.Text = Convert.ToString(Total);
            }
        }
        string[] _DateFrom = DateFrom.Split(new Char[] { '-' });
        string[] _DateTo = DateTo.Split(new Char[] { '-' });
        TimeSpan.Text = _DateFrom[1] + "/" + _DateFrom[2] + "/" + _DateFrom[0] + "-" + _DateTo[1] + "/" + _DateTo[2] + "/" + _DateTo[0];
        LoadPayersFromClaim();
        LoadPracticeLocation();
        LoadProvider();
    }
    public void LoadPayersFromClaim()
    {
        InsuranceDB insuranceDB = new InsuranceDB();
        long PracticeId = Profile.PracticeId;
        DataTable dtPatient = insuranceDB.GetPayersByPracticeId(PracticeId, "", "");
        rptPayerScenario.DataSource = dtPatient;
        rptPayerScenario.DataBind();

    }
    public void LoadPracticeLocation()
    {
        long PracticeId = Profile.PracticeId;
        ReportsDB db = new ReportsDB();

        DataTable dtPracticeLocation = db.GetLocationsByDefault(PracticeId);
        rptLocation.DataSource = dtPracticeLocation;
        rptLocation.DataBind();
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