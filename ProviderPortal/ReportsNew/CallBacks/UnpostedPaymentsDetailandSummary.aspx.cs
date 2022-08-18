using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EMR_ReportsNew_CallBacks_UnpostedPaymentsDetailandSummary : System.Web.UI.Page
{
    string _DateFrom = "";
    string _DateTo = "";
    string DateType = "";
    string PayerType = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        UnpostedPaymentsummary();
        InsurancesFromInsurance();
        LoadPracticeLocation();
        LoadProvider();
    }

    public void UnpostedPaymentsummary()
    {
       
        DateType = Request.Form["DateType"];
        _DateFrom = Request.Form["DateFrom"];
        _DateTo = Request.Form["DateTo"];
        PayerType = Request.Form["PayerType"];
        string checknumber= Request.Form["checknumber"];
        
        if (DateType == "")
        {
            DateType = "PostDate";
        }
        bool? IsImportedDataOnly = null;

        if (!string.IsNullOrEmpty(Session["IsImported"] as string))
        {

            if (Session["IsImported"].ToString() == "2") { IsImportedDataOnly = true; }
            else if (Session["IsImported"].ToString() == "1") { IsImportedDataOnly = false; }
            else { IsImportedDataOnly = null; }
        }

        ReportsPatientDB reportsPatientDB = new ReportsPatientDB();
        DataSet dsunpostedsummary = reportsPatientDB.GetUnpostedPaymentsSummary(Profile.PracticeId, PayerType, DateType, _DateFrom, _DateTo, checknumber, "", IsImportedDataOnly);

       rptUnpostedPayments.DataSource = dsunpostedsummary.Tables[0];
       rptUnpostedPayments.DataBind();

       rptCheckDetail.DataSource = dsunpostedsummary.Tables[1];
       rptCheckDetail.DataBind();
        string[] DateFrom = _DateFrom.Split(new Char[] { '-' });
        string[] DateTo = _DateTo.Split(new Char[] { '-' });
        TimeSpan.Text = DateFrom[1] + "/" + DateFrom[2] + "/" + DateFrom[0] + "-" + DateTo[1] + "/" + DateTo[2] + "/" + DateTo[0];
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
    private void InsurancesFromInsurance()
    {
        InsuranceDB objInsuranceDB = new InsuranceDB();
        using (DataTable dtInsuranceDb = objInsuranceDB.Insurance_GetBySearchCriteria(Profile.PracticeId, "", "", "", "", 100, 0, "").Tables[0])
        {
            rptPayerScenario.DataSource = dtInsuranceDb;
            rptPayerScenario.DataBind();
        }

    }
}