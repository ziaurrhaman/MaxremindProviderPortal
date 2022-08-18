using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class ProviderPortal_ReportsNew_CallBacks_OverPaidClaims : System.Web.UI.Page
{
    string DateFrom = "";
    string DateTo = "";
    string DateType = "";


    protected void Page_Load(object sender, EventArgs e)
    {
        LoadOverPaidClaims();
        LoadClaimStatus();
        LoadPayersFromClaim();
        LoadProvider();
        LoadPracticeLocation();
    }
    private void LoadOverPaidClaims()
    {
        ReportsDB objOverClaimDB = new ReportsDB();
        long PracticeId = Profile.PracticeId;
         DateFrom = Request.Form["DateFrom"];
         DateTo = Request.Form["DateTo"];
         DateType = Request.Form["DateType"];
        if(DateType == "" || DateType == null)
        {
            DateType = "BillDate";
        }

        DataSet dsReportData = objOverClaimDB.GetOverPaidClaims(PracticeId, 10, 0, "DOS ASC", DateFrom, DateTo, DateType, "", "", "", "", "");
        rptOverPaidClaimReport.DataSource = dsReportData.Tables[0];
        rptOverPaidClaimReport.DataBind();
        hdnTotalRows.Value = dsReportData.Tables[1].Rows[0]["TotalRows"].ToString();

        string[] _DateFrom = DateFrom.Split(new Char[] { '-' });
        string[] _DateTo = DateTo.Split(new Char[] { '-' });


        TimeSpan.Text = _DateFrom[1] + "/" + _DateFrom[2] + "/" + _DateFrom[0] + "-" + _DateTo[1] + "/" + _DateTo[2] + "/" + _DateTo[0];
        hdnDateFrom.Value = DateFrom;
        hdnDateTo.Value = DateTo;
        hdnDateType.Value = DateType;
    }
    public void LoadClaimStatus()
    {
        SubmissionStatusCodesDB objSubmissionStatusCodesDB = new SubmissionStatusCodesDB();
        DataTable dtSubmissionStatusCodes = objSubmissionStatusCodesDB.GetSubmissionStatusCodes();

        rptCalimStatus.DataSource = dtSubmissionStatusCodes;
        rptCalimStatus.DataBind();
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