using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class EMR_ReportsNew_CallBacks_ProcedurePaymentsSummaryReport : System.Web.UI.Page
{
    string _DateFrom = "";
    string _DateTo = "";
    string _TimeSpan = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadReport();
        InsurancesFromInsurance();
        LoadPracticeLocation();
        LoadProvider();
    }
    private void LoadReport()
    {
        ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();
        long PracticeId = Profile.PracticeId;
        string insurancetype= Request.Form["InsuranceType"];
        string insuranceIds= Request.Form["Insurance"];
        string CPTCodes = Request.Form["Cptcodes"];
        //hdnCPTs.Value = CPTCodes;
        //hdnInsuranceIds.Value = insuranceIds;
        //hdnInsurancetype.Value = insurancetype;
        bool? IsImportedDataOnly = null;
        if (!string.IsNullOrEmpty(Session["IsImported"] as string))
        {

            if (Session["IsImported"].ToString() == "2") { IsImportedDataOnly = true; }
            else if (Session["IsImported"].ToString() == "1") { IsImportedDataOnly = false; }
            else { IsImportedDataOnly = null; }
        }
        DataSet dsReportData = objPatientReportsDB.GetCPTwisePaymentDetailNEW(PracticeId,10,0, CPTCodes, insuranceIds, insurancetype, "", "", IsImportedDataOnly);
        hdnTotalRows.Value = dsReportData.Tables[1].Rows[0]["TotalRows"].ToString();
        rptProcedurePaymentsSummary.DataSource = dsReportData.Tables[0];
        rptProcedurePaymentsSummary.DataBind();
       
    }
    public void LoadProvider()
    {
        string PracticeLocationId = Request.Form["PracticeLocationId"];
        ReportsDB db = new ReportsDB();
        DataTable ds = db.GetProvidersByDefault(Profile.PracticeId);
        rptProviders.DataSource = ds;
        rptProviders.DataBind();
    }
    public void LoadPracticeLocation()
    {
        long PracticeId = Profile.PracticeId;
        ReportsDB db = new ReportsDB();

        DataTable dtPracticeLocation = db.GetLocationsByDefault(PracticeId);
        rptLocation.DataSource = dtPracticeLocation;
        rptLocation.DataBind();
    }
    private void InsurancesFromInsurance()
    {
        InsuranceDB objInsuranceDB = new InsuranceDB();
        using (DataTable dtInsuranceDb = objInsuranceDB.Insurance_GetBySearchCriteria(Profile.PracticeId, "", "", "", "", 100, 0, "").Tables[0])
        {
            //rptInsurances.DataSource = dtInsuranceDb;
           // rptInsurances.DataBind();
            PayersCustomize.DataSource = dtInsuranceDb;
            PayersCustomize.DataBind();
        }

    }
}