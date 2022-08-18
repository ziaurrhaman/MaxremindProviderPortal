using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class EMR_ReportsNew_CallBacks_RejectedDeniedClaims : System.Web.UI.Page
{


    ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();
    DataSet dsReportData = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        long PracticeId = Profile.PracticeId;

        string Insurance = Request.Form["Insurance"];

        string BilledAs = Request.Form["BilledAs"];

        string Aging = Request.Form["RDAging"];
        hdnAging.Value = Aging;
        hdnBilledAs.Value = BilledAs;
        dsReportData = objPatientReportsDB.GetRejectedDeniedClaims(Profile.PracticeId, Insurance, BilledAs, "", Aging, null);

        LoadSummary(PracticeId, Insurance, BilledAs, "", Aging);
        GetTotal(PracticeId, Insurance, BilledAs, "", Aging);

        InsurancesFromInsurance();
        LoadProvider();
        LoadPracticeLocation();
    }
    public void mainRejectedDenied()
    {

        long PracticeId = Profile.PracticeId;

        string Insurance = Request.Form["Insurance"];

        string BilledAs = Request.Form["BilledAs"];

        string Aging = Request.Form["RDAging"];
        //hdnAging.Value = Aging.ToString();
        //hdnBilledAs.Value = BilledAs.ToString();
        LoadSummary(PracticeId, Insurance, BilledAs, "", Aging);
        GetTotal(PracticeId, Insurance, BilledAs, "", Aging);

    }
    private void LoadSummary(long practiceId, string insurance, string billedAs, string status, string Aging)
    {
        bool? IsImportedDataOnly = null;
        if (!string.IsNullOrEmpty(Session["IsImported"] as string))
        {

            if (Session["IsImported"].ToString() == "2") { IsImportedDataOnly = true; }
            else if (Session["IsImported"].ToString() == "1") { IsImportedDataOnly = false; }
            else { IsImportedDataOnly = null; }
        }

       // DataSet dsReportData = objPatientReportsDB.GetRejectedDeniedClaims(practiceId, insurance, billedAs, status, Aging, IsImportedDataOnly);

        rptSummary.DataSource = dsReportData.Tables[0];

        rptSummary.DataBind();
        hdnTotalRows.Value = "NoRows";
        hdnPayer.Value = insurance;
    }
    public void GetTotal(long practiceId, string insurance, string billedAs, string status, string Aging)
    {
        bool? IsImportedDataOnly = null;
        if (!string.IsNullOrEmpty(Session["IsImported"] as string))
        {

            if (Session["IsImported"].ToString() == "2") { IsImportedDataOnly = true; }
            else if (Session["IsImported"].ToString() == "1") { IsImportedDataOnly = false; }
            else { IsImportedDataOnly = null; }
        }

       // DataSet dsReportData = objPatientReportsDB.GetRejectedDeniedClaims(practiceId, insurance, billedAs, status, Aging, IsImportedDataOnly);
        Control FooterTemplate = rptSummary.Controls[rptSummary.Controls.Count - 1].Controls[0];
        if (dsReportData.Tables[0].Rows.Count > 0)
        {

            int Rejected = int.Parse(dsReportData.Tables[0].Compute("sum(Rejected)", string.Empty).ToString());
            Label lblRejectedTotal = FooterTemplate.FindControl("lblRejectedTotal") as Label;
            lblRejectedTotal.Text = Rejected.ToString();

            int Denied = int.Parse(dsReportData.Tables[0].Compute("sum(Denied)", string.Empty).ToString());
            Label lblDeniedTotal = FooterTemplate.FindControl("lblDeniedTotal") as Label;
            lblDeniedTotal.Text = Denied.ToString();




            int PartiallyPaid = int.Parse(dsReportData.Tables[0].Compute("sum(PaidUp)", string.Empty).ToString());
            Label lblPPaidTotal = FooterTemplate.FindControl("lblPPaidTotal") as Label;
            lblPPaidTotal.Text = PartiallyPaid.ToString();

            int total = int.Parse(dsReportData.Tables[0].Compute("sum(Total)", string.Empty).ToString());
            Label lblGrandTotal = FooterTemplate.FindControl("lblGrandTotal") as Label;
            lblGrandTotal.Text = total.ToString();
        }
    }
    protected void rptSummary_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {

        }



    }
    private void InsurancesFromInsurance()
    {
        InsuranceDB objInsuranceDB = new InsuranceDB();
        using (DataTable dtInsuranceDb = objInsuranceDB.Insurance_GetBySearchCriteria(Profile.PracticeId, "", "", "", "", 100, 0, "").Tables[0])
        {
            rptInsurances.DataSource = dtInsuranceDb;
            rptInsurances.DataBind();
        }

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