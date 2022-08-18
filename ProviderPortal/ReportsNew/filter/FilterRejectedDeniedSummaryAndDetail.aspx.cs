using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EMR_ReportsNew_filter_FilterRejectedDeniedClaims : System.Web.UI.Page
{
    ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();
    DataSet dsReportData = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.Form["Action"];
        if (action == "Filter")
        {
            //mainRejectedDenied();
            long PracticeId = Profile.PracticeId;

            string Insurance = Request.Form["Insurance"];

            string BilledAs = Request.Form["BilledAs"];
            string ProviderId = Request.Form["ProviderId"];
            string Location = Request.Form["Location"];
            string Aging = Request.Form["RDAging"];
             hdnAging.Value = Aging;
            hdnBilledAs.Value = BilledAs;
            hdnProviderId.Value = ProviderId;
            hdnLocation.Value = Location;
            hdnPayer.Value = Insurance;

            dsReportData = objPatientReportsDB.GetRejectedDeniedClaims(Profile.PracticeId, Insurance, BilledAs, "", Aging, null, Location, ProviderId);
            LoadSummary(PracticeId, Insurance, BilledAs, "", Aging);
            GetTotal(PracticeId, Insurance, BilledAs, "", Aging);
        }
        else
        {
            LoadReport();
        }
        
    }

    private void LoadReport()
    {
        
        long PracticeId = Profile.PracticeId;

        string Payer = Request.Form["payer"];
        string ProviderId = Request.Form["ProviderId"];
        string Location = Request.Form["Location"];
        string status = Request.Form["status"];
        string Aging = Request.Form["aging"];
        string BilledAs = Request.Form["BilledAs"];
        bool? IsImportedDataOnly = null;
        if (!string.IsNullOrEmpty(Session["IsImported"] as string))
        {

            if (Session["IsImported"].ToString() == "2") { IsImportedDataOnly = true; }
            else if (Session["IsImported"].ToString() == "1") { IsImportedDataOnly = false; }
            else { IsImportedDataOnly = null; }
        }
        dsReportData = objPatientReportsDB.GetRejectedDeniedClaims(PracticeId, Payer, BilledAs, status, Aging, IsImportedDataOnly, Location, ProviderId);

        rptRDC.DataSource = dsReportData.Tables[1];
        rptRDC.DataBind();
      

    }
    public void mainRejectedDenied()
    {

        long PracticeId = Profile.PracticeId;

        string Insurance = Request.Form["Insurance"];

        string BilledAs = Request.Form["BilledAs"];

        string Aging = Request.Form["RDAging"];
        hdnAging.Value = Aging;
        hdnBilledAs.Value = BilledAs;
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
}