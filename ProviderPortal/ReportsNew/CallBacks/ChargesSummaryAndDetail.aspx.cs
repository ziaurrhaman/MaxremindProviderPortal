using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProviderPortal_ReportsNew_CallBacks_ChargesSummaryAndDetail : System.Web.UI.Page
{
    string StartDate = "";
    string EndDate = ""; string claimid = "";
    string PracticeLocationId = ""; string ProviderId = ""; string payername = ""; string CPTcode = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        string Action = Request.Form["action"];


        string DateType = "";
        //Added by Khayyam ADeel desc Show filter in reports(Claim Summary and Details)

        if (Request.Form["DateType"] == "" || Request.Form["DateType"] == null)
        {
            DateType = "PostDate";
        }
        else
        {
            DateType = Request.Form["DateType"].ToString();
        }


        if (Request.Form["DateFrom"] != null)
        {
            StartDate = Request.Form["DateFrom"].ToString();
            //txtDateFrom.Text = StartDate;
        }
        if (Request.Form["DateTo"] != null)
        {
            EndDate = Request.Form["DateTo"].ToString();
            // txtDateTo.Text = EndDate;
        }

        if (Request.Form["DateFrom"] == null || Request.Form["DateFrom"] == "" || Request.Form["DateTo"] == null || Request.Form["DateTo"] == "")
        {
            DateTime curDate = DateTime.Now;
            DateTime StartDate1 = new DateTime(curDate.Year, curDate.Month, 1);
            DateTime EndDate1 = StartDate1.AddMonths(1).AddDays(-1);

            StartDate = StartDate1.ToShortDateString();
            EndDate = EndDate1.ToShortDateString();

        }

        if (StartDate != "" && EndDate != "")
        {

            //    TimeSpan.Text = StartDate + " - " + EndDate;
        }
        else
        {
            //  TimeSpan.Text = "All Records";
        }
        if (Request.Form["PracticeLocationId"] != null)
        {
            PracticeLocationId = Request.Form["PracticeLocationId"].ToString();

        }

        if (Request.Form["ProviderId"] != null)
        {
            ProviderId = Request.Form["ProviderId"].ToString();
        }

        if (Request.Form["payername"] != null)
        {
            payername = Request.Form["payername"].ToString();
        }

        if (Request.Form["payername"] != null)
        {
            payername = Request.Form["payername"].ToString();
        }
        if (Request.Form["claimid"] != null)
        {
            claimid = Request.Form["claimid"].ToString();
        }
        if (Request.Form["CPTcode"] != null)
        {
            CPTcode = Request.Form["CPTcode"].ToString();
        }
        bool? IsImportedDataOnly = null;
        if (!string.IsNullOrEmpty(Session["IsImported"] as string))
        {

            if (Session["IsImported"].ToString() == "2") { IsImportedDataOnly = true; }
            else if (Session["IsImported"].ToString() == "1") { IsImportedDataOnly = false; }
            else { IsImportedDataOnly = null; }
        }
        if (ProviderId == "")
        { ProviderId = null; }
        if (PracticeLocationId == "")
        { PracticeLocationId = null; }
        ReportsDB db = new ReportsDB();
        DataSet ds = db.GetClaimsDetails(Profile.PracticeId, 10, 0, "ClaimId DESC", DateType, StartDate, EndDate, PracticeLocationId, ProviderId, payername, claimid, IsImportedDataOnly, null, null, CPTcode);
        //if (Action == "FilterClaimSummary")
        //{
        //    rptFilter.DataSource = ds.Tables[0];
        //    rptFilter.DataBind();
        //    hdnFilterStartDate.Value = StartDate;
        //    hdnFilterEndDate.Value = EndDate;
        //    hdnFilterDateType.Value = DateType;
        //    hdnPracticeLocationIdCharges.Value = PracticeLocationId;
        //    hdnProviderIdCharges.Value = ProviderId;
        //    hdnCPT.Value = CPTcode;
        //    hdnpayername.Value = payername;
        //    hdnclaimidCharges.Value = claimid.ToString();

        //}
       
            rptReportData.DataSource = ds.Tables[0];
            rptReportData.DataBind();
            hdnStartDate.Value = StartDate;
            hdnEndDate.Value = EndDate;
            hdnDateType.Value = DateType;
            //hdnPracticeLocationIdCharges.Value = PracticeLocationId;
            //hdnProviderIdCharges.Value = ProviderId;
            //hdnCPT.Value = CPTcode;
            //hdnpayername.Value = payername;
            //hdnCPT.Value = claimid.ToString();
            LoadProvider();
            LoadPracticeLocation();
        LoadClaimStatus();
        LoadPayersFromClaim();
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
        rptClaimSummaryLocation.DataSource = dtPracticeLocation;
        rptClaimSummaryLocation.DataBind();
    }
}