using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProviderPortal_ReportsNew_filter_FilterChargesSummaryAndDetail : System.Web.UI.Page
{

    string StartDate = ""; string MultipleCPTs = ""; string Bill = "";
    string ClaimStatus = "";
    string EndDate = ""; string claimid = "";
    string PracticeLocationId = ""; string ProviderId = ""; string CPTcode = ""; string DateType = ""; string payername = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        string Action = Request.Form["Action"];
        if (Action == "FilterClaimSummary")
        {
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
            if (Request.Form["MultipleClaims"] != null)
            {
                claimid = Request.Form["MultipleClaims"].ToString();
            }
            if (Request.Form["BillAs"] != null)
            {
                Bill = Request.Form["BillAs"];
            }
            if (Request.Form["CPTcode"] != null)
            {
                CPTcode = Request.Form["CPTcode"].ToString();
            }
            if (Request.Form["ClaimStatus"] != null)
            {
                ClaimStatus = Request.Form["ClaimStatus"];
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
            DataSet ds = db.GetClaimsDetails(Profile.PracticeId, 10, 0, "ClaimId DESC", DateType, StartDate, EndDate, PracticeLocationId, ProviderId, payername, claimid, IsImportedDataOnly, null, null, CPTcode, Bill, ClaimStatus);
            rptFilter.DataSource = ds.Tables[0];
            rptFilter.DataBind();
            hdnStartDate.Value = StartDate;
            hdnEndDate.Value = EndDate;
            hdnDateType.Value = DateType;
            hdnPracticeLocationIdCharges.Value = PracticeLocationId;
            hdnProviderIdCharges.Value = ProviderId;
            hdnCPT.Value = CPTcode;
            hdnBillAs.Value = Bill;
            hdnClaimStatus.Value = ClaimStatus;

            hdnclaimidCharges.Value = claimid;

        }
        else
        {
            if (!string.IsNullOrEmpty(Request.Form["CPTcode"]))
                CPTcode = Request.Form["CPTcode"];
            if (Request.Form["DateType"] == "" || Request.Form["DateType"] == null)
            {
                DateType = "PostDate";
            }
            else
            {
                DateType = Request.Form["DateType"]; //
            }


            if (Request.Form["DateFrom"] != null)
            {
                StartDate = Request.Form["DateFrom"].ToString();

            }
            if (Request.Form["DateTo"] != null)
            {
                EndDate = Request.Form["DateTo"].ToString();

            }
            if (Request.Form["DateFrom"] == null || Request.Form["DateFrom"] == "")
            {
                StartDate = "";
            }
            if (Request.Form["DateTo"] == null || Request.Form["DateTo"] == "")
            {
                EndDate = "";
            }

            if (Request.Form["PracticeLocationId"] != null)
            {
                PracticeLocationId = Request.Form["PracticeLocationId"].ToString();
            }

            if (Request.Form["ProviderId"] != null)
            {
                ProviderId = Request.Form["ProviderId"].ToString();
            }

            if (Request.Form["claimid"] != null)
            {
                claimid = (Request.Form["claimid"].ToString());
            }
            if (Request.Form["ClaimStatus"] != null)
            {
                ClaimStatus = Request.Form["ClaimStatus"];
            }
            if (Request.Form["BillAs"] != null)
            {
                Bill = Request.Form["BillAs"];
            }
            string level = "";
            string type = Request.Form["type"];
            if (ProviderId == "")
            { ProviderId = null; }
            if (PracticeLocationId == "")
            { PracticeLocationId = null; }
            bool? IsImportedDataOnly = null;
            if (Request.Form["CPTcode"] != null)
            {
                MultipleCPTs = Request.Form["CPTcode"].ToString();
            }
            if (!string.IsNullOrEmpty(Session["IsImported"] as string))
            {


                if (Session["IsImported"].ToString() == "2") { IsImportedDataOnly = true; }
                else if (Session["IsImported"].ToString() == "1") { IsImportedDataOnly = false; }
                else { IsImportedDataOnly = null; }
            }
            DataSet ds = new DataSet();

            ReportsDB db = new ReportsDB();
            if (type == "")
            {
                ds = db.GetClaimsDetail_ProviderPortalChargedCPT(Profile.PracticeId, 10, 0, "ClaimId DESC", DateType, StartDate, EndDate, PracticeLocationId, ProviderId, "", claimid, IsImportedDataOnly, level, type, MultipleCPTs, Bill, ClaimStatus);

            }
            if (type == "P")
            {
                ds = db.GetClaimsDetail_ProviderPortalPaidCPT(Profile.PracticeId, 10, 0, "ClaimId DESC", DateType, StartDate, EndDate, PracticeLocationId, ProviderId, "", claimid, IsImportedDataOnly, level, type, MultipleCPTs, Bill, ClaimStatus);

            }
            if (type == "U")
            {
                ds = db.GetClaimsDetail_ProviderPortalUnPaidCPT(Profile.PracticeId, 10, 0, "ClaimId DESC", DateType, StartDate, EndDate, PracticeLocationId, ProviderId, "", claimid, IsImportedDataOnly, level, type, MultipleCPTs, Bill, ClaimStatus);

            }
            rptReportData.DataSource = ds.Tables[0];
            rptReportData.DataBind();
        }
    }
}