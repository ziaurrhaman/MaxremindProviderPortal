using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class BillingManager_Dashboard : System.Web.UI.Page
{
    string PostStartDate = "";
    string PostEndDate = "";

    string StartDate = "";
    string EndDate = "";
    string DateType = "";
  
    protected void Page_Load(object sender, EventArgs e)
    {

        string LocationId = Request.QueryString["Location"] == "All" ? "" : Request.QueryString["Location"];
        string ProviderId = Request.QueryString["Provider"] == "All" ? "" : Request.QueryString["Provider"];
        DateType = Request.QueryString["DateType"] == "All" ? "" : Request.QueryString["DateType"];
       
        string RadioBtn = Request.QueryString["Radiobtn"];

       
        if (RadioBtn == "Post")
        {
            PostStartDate = Request.QueryString["StartDate"];
            PostEndDate = Request.QueryString["EndDate"];
            PostDate();
            DOSRb.Checked = false;
            PostRb.Checked = true;
            spndate.InnerText = PostStartDate + " - " + PostEndDate;
        }

        else if (RadioBtn == "DOS")
        {
            StartDate = Request.QueryString["StartDate"];
            EndDate = Request.QueryString["EndDate"];
            DOSDate();
            DOSRb.Checked = true;
            PostRb.Checked = false;
            spndate.InnerText = StartDate + " - " + EndDate;
        }

        else
        {
            DateTime Date = DateTime.Now;


            PostStartDate = Date.AddDays(-90).ToString("M/d/yyyy");
            PostEndDate = DateTime.Today.ToString("M/d/yyyy");

            Label.Text = "Last 90 Days (Post)";
            spndate.InnerText = PostStartDate + " - " + PostEndDate;
        }

        ///Modified By Irfan Mahmood 14/July/2022
        ReportsDB ReportsDB = new ReportsDB();
        ServiceProviderDB serviceProviderDB = new ServiceProviderDB();
        DataTable dtPayerName = ReportsDB.GetProvidersByDefault(Profile.PracticeId);
        ddlBillingProvider.DataSource = dtPayerName;
        ddlBillingProvider.DataTextField = "StaffName";
        ddlBillingProvider.DataValueField = "StaffNPI";
        ddlBillingProvider.DataBind();
        ///Modified By Irfan Mahmood 14/July/2022
        //PracticeStaffDB objPracticeStaffDB = new PracticeStaffDB();

        //ddlBillingProvider.DataSource = objPracticeStaffDB.GetProvidersByPracticeForPP(Profile.PracticeId);
        //ddlBillingProvider.DataValueField = "PracticeStaffId";
        //ddlBillingProvider.DataTextField = "Name";
        //ddlBillingProvider.DataBind();

        ddlBillingProvider.SelectedValue = ProviderId;

        PracticeLocationsDB objPracticeLocationsDB = new PracticeLocationsDB();
        DataTable dtLocations = objPracticeLocationsDB.GetPracticeLocationsByPractice(Profile.PracticeId);

        ddlLocation.DataSource = dtLocations;
        ddlLocation.DataTextField = "Name";
        ddlLocation.DataValueField = "PracticeLocationsId";
        ddlLocation.DataBind();
        ddlLocation.SelectedValue = LocationId;

        /***start***/
        bool? IsImportedDataOnly = null;
        if (!string.IsNullOrEmpty(Session["IsImported"] as string))
        {
            if (Session["IsImported"].ToString() == "2") { IsImportedDataOnly = true; }
            else if (Session["IsImported"].ToString() == "1") { IsImportedDataOnly = false; }
            else { IsImportedDataOnly = null; }
        }
        /***End***/



        ClaimChargesDB objClaimChargesDB = new ClaimChargesDB();
        // Charges Payment Adjustment Due
        DataSet dsChargesPaymentsAdjustmentBalanceDue = objClaimChargesDB.GetPaymentChargesAdjustmentBalanceDue(Profile.PracticeId, LocationId, StartDate, EndDate, PostStartDate, PostEndDate, ProviderId, IsImportedDataOnly);
        string Charges = "";
        string Payments = "";
        string Adjustment = "";
        string Balance = "";
        if (dsChargesPaymentsAdjustmentBalanceDue.Tables.Count > 0)
        {
            Charges = dsChargesPaymentsAdjustmentBalanceDue.Tables[0].Rows[0]["Charges"].ToString();
            Payments = dsChargesPaymentsAdjustmentBalanceDue.Tables[1].Rows[0]["Payments"].ToString();
            Adjustment = dsChargesPaymentsAdjustmentBalanceDue.Tables[4].Rows[0]["PatientPaidAmt"].ToString();
            Balance = dsChargesPaymentsAdjustmentBalanceDue.Tables[3].Rows[0]["BalanceDue"].ToString();
        }


        if (string.IsNullOrEmpty(Charges))
        {
            lblCharges.Text = "0";
        }
        else
        {
            decimal charges = Convert.ToDecimal(dsChargesPaymentsAdjustmentBalanceDue.Tables[0].Rows[0]["Charges"].ToString());
            string chargesString = String.Format("{0:C}", charges);
            lblCharges.Text = chargesString;
        }

        if (string.IsNullOrEmpty(Payments))
        {
            lblPayments.Text = "0";
        }
        else
        {
            decimal payment = Convert.ToDecimal(dsChargesPaymentsAdjustmentBalanceDue.Tables[1].Rows[0]["Payments"].ToString());
            string paymentString = String.Format("{0:C}", payment);
            lblPayments.Text = paymentString;
        }





        if (string.IsNullOrEmpty(Adjustment))
        {
            lblAdjustments.Text = "0";
        }
        else
        {
            decimal Adjustments = Convert.ToDecimal(dsChargesPaymentsAdjustmentBalanceDue.Tables[4].Rows[0]["PatientPaidAmt"].ToString());
            string AdjustmentsString = String.Format("{0:C}", Adjustments);
            string adjustments = AdjustmentsString.Trim(new Char[] { ' ', '(', ')' });
            string adjustment1 = "-" + " " + adjustments;
            if (Adjustments > 0)
            {
                lblAdjustments.Text = AdjustmentsString;
            }
            else
            {
                lblAdjustments.Text = adjustment1;
            }

        }



        if (string.IsNullOrEmpty(Balance))
        {
            lblBalanceDue.Text = "0";
        }
        else
        {
            decimal BalanceDue = Convert.ToDecimal(dsChargesPaymentsAdjustmentBalanceDue.Tables[3].Rows[0]["BalanceDue"].ToString());
            string BalanceDueString = String.Format("{0:C}", BalanceDue);
            string balance = BalanceDueString.Trim(new Char[] { ' ', '(', ')' });
            string blance1 = "-" + " " + balance;
            if (BalanceDue > 0)
            {
                lblBalanceDue.Text = balance;
            }
            else
            {
                lblBalanceDue.Text = blance1;
            }

        }
      
        //Claim_BAAR_CHART
        DataTable dtClaimChargesAdjustment = objClaimChargesDB.ClaimChargesPaymentAdjustment(Profile.PracticeId, LocationId, StartDate, EndDate, ProviderId, PostStartDate, PostEndDate);


        string script = "<script type='text/javascript'>";
        //Payment and Adjustment Charges ratio graph
        DataTable dtPaymentChargesAdjustmentRatio = objClaimChargesDB.PaymentChargesAdjustmentRatio(Profile.PracticeId, LocationId, StartDate, EndDate, PostStartDate, PostEndDate, ProviderId);



        script += "var PaymentChargesAdjustmentRatio = new Array();";
        script += "PaymentChargesAdjustmentRatio.push(['Date','Payment Charges Ratio','Adjustment Charges Ratio']);";
        for (int i = 0; i < dtPaymentChargesAdjustmentRatio.Rows.Count; i++)
        {
            script += "PaymentChargesAdjustmentRatio.push(['" + DateTime.Parse(dtPaymentChargesAdjustmentRatio.Rows[i]["ServiceDate"].ToString()).ToString("M/d/yyyy") + "'," + dtPaymentChargesAdjustmentRatio.Rows[i]["PaymentChargesRatio"].ToString() + "," + dtPaymentChargesAdjustmentRatio.Rows[i]["ChargesAdjustmentRatio"].ToString() + "]);";
        }



        //claim pie charts

        if (dtClaimChargesAdjustment.Rows.Count < 1)
            script += "PaymentChargesAdjustmentRatio.push(['', 0, 0]);";

        script += "var ClaimChargesAdjustment = new Array();";
        script += "ClaimChargesAdjustment.push(['Date','Charges','Payments','Adjustments']);";
        for (int i = 0; i < dtClaimChargesAdjustment.Rows.Count; i++)
        {
            script += "ClaimChargesAdjustment.push(['" + DateTime.Parse(dtClaimChargesAdjustment.Rows[i]["ServiceDate"].ToString()).ToString("M/d/yyyy") + "'," + dtClaimChargesAdjustment.Rows[i]["TotalCharges"].ToString() + "," + dtClaimChargesAdjustment.Rows[i]["PaidAmount"].ToString() + "," + dtClaimChargesAdjustment.Rows[i]["AdjustedAmount"].ToString() + "]);";
        }

        if (dtClaimChargesAdjustment.Rows.Count < 1)
            script += "ClaimChargesAdjustment.push(['', 0, 0, 0]);";


        ClaimDB objClaimDB = new ClaimDB();
        script += "var ClaimSubmissionStatus = new Array();";
        script += "ClaimSubmissionStatus.push(['Status','Count']);";

        DataTable dtClaimSubmissionStatus = objClaimDB.ClaimSubmissionStatus(Profile.PracticeId, LocationId, StartDate, EndDate, ProviderId, PostStartDate, PostEndDate);

        for (int i = 0; i < dtClaimSubmissionStatus.Rows.Count; i++)
        {
            script += "ClaimSubmissionStatus.push(['" + dtClaimSubmissionStatus.Rows[i]["SubmissionStatus"].ToString() + "'," + dtClaimSubmissionStatus.Rows[i]["NumberOfClaims"].ToString() + "]);";
        }

        if (dtClaimChargesAdjustment.Rows.Count < 1)
            script += "ClaimSubmissionStatus.push(['', 0, 0, 0]);";



        script += "var ClaimSubmissionStatusAging = new Array();";
        script += "ClaimSubmissionStatusAging.push(['Status','0 to 7','8 to 15','16 to 21','21+']);";

        DataTable dtClaimSubmissionStatusAging = objClaimDB.ClaimSubmissionStatusAging(Profile.PracticeId, LocationId, StartDate, EndDate, ProviderId, PostStartDate, PostEndDate);

        for (int i = 0; i < dtClaimSubmissionStatus.Rows.Count; i++)
        {
            script += "ClaimSubmissionStatusAging.push(['" + dtClaimSubmissionStatusAging.Rows[i]["SubmissionStatus"].ToString() + "'," + dtClaimSubmissionStatusAging.Rows[i]["ZeroSeven"].ToString() + "," + dtClaimSubmissionStatusAging.Rows[i]["EightFifteen"].ToString() + "," + dtClaimSubmissionStatusAging.Rows[i]["SixteenTwentyOne"].ToString() + "," + dtClaimSubmissionStatusAging.Rows[i]["ABOVETWENTYONE"].ToString() + "]);";
        }

        if (dtClaimChargesAdjustment.Rows.Count < 1)
            script += "ClaimSubmissionStatusAging.push(['', 0, 0, 0, 0]);";


        script += "var ClaimPayerDistribution = new Array();";
        script += "ClaimPayerDistribution.push(['Insurance','Count']);";

        DataTable dtClaimPayerDistribution = objClaimDB.ClaimPayerDistribution(Profile.PracticeId, LocationId, StartDate, EndDate, ProviderId, PostStartDate, PostEndDate);

        for (int i = 0; i < dtClaimPayerDistribution.Rows.Count; i++)
        {
            script += "ClaimPayerDistribution.push(['" + dtClaimPayerDistribution.Rows[i]["Name"].ToString() + "'," + dtClaimPayerDistribution.Rows[i]["NumberOfClaims"].ToString() + "]);";
        }

        script += "</script>";

        ltrlScript.Text = script;
    }

    protected void DOSDate()
    {
        txtFromDate.Text = StartDate;
        txtToDate.Text = EndDate;

        if (!string.IsNullOrEmpty(DateType))
        {
            if (DateType == "MonthToDate")
            {
                DateTime Date = DateTime.Now;


                StartDate = new DateTime(Date.Year, Date.Month, 1).ToString("M/d/yyyy"); ;
                EndDate = Date.AddDays(1).ToString("M/d/yyyy"); ;

                //chkMonthToDate.Checked = true;
                Label.Text = " Month To Date (Dos)";
            }

            else if (DateType == "LastMonth")
            {
                DateTime Date = DateTime.Now;

                if (Date.Month == 1)
                {
                    StartDate = new DateTime(Date.Year - 1, 12, 1).ToString("M/d/yyyy"); ;
                    EndDate = new DateTime(Date.Year - 1, Date.AddMonths(-1).Month, DateTime.DaysInMonth(Date.Year - 1, 12)).ToString("M/d/yyyy"); ;
                    // EndDate = new DateTime(Date.Year, Date.Month, 1).ToString("M/d/yyyy");;
                }
                else
                {
                    StartDate = new DateTime(Date.Year, Date.Month - 1, 1).ToString("M/d/yyyy"); ;
                    EndDate = new DateTime(Date.Year, Date.Month - 1, DateTime.DaysInMonth(Date.Year, Date.Month - 1)).ToString("M/d/yyyy"); ;
                    //  EndDate=new DateTime(Date.Year, Date.Month, 1).ToString("M/d/yyyy");;
                }


                //chkLastMonth.Checked = true;
                Label.Text = " Last Month (Dos)";

            }
            else if (DateType == "Last3Month")
            {
                DateTime Date = DateTime.Now;

                if (Date.Month == 3)
                {
                    StartDate = Date.AddDays(-90).ToString("M/d/yyyy"); ;
                    EndDate = DateTime.Today.ToString("M/d/yyyy"); ;
                   
                    // EndDate = new DateTime(Date.Year, Date.Month, 1).ToString("M/d/yyyy");;
                }
                else
                {
                    StartDate = Date.AddDays(-90).ToString("M/d/yyyy"); ;
                    EndDate = DateTime.Today.ToString("M/d/yyyy"); ;
                   
                    //  EndDate=new DateTime(Date.Year, Date.Month, 1).ToString("M/d/yyyy");;
                }


                //chkLastMonth.Checked = true;
                Label.Text = " Last 90 Days (Dos)";

            }


            else if (DateType == "YearToDate")
            {
                DateTime Date = DateTime.Now;

                StartDate = new DateTime(Date.Year, 1, 1).ToString("M/d/yyyy"); ;
                EndDate = Date.AddDays(1).ToString("M/d/yyyy"); ;
                //chkYearToDate.Checked = true;
                Label.Text = "Year To Date (Dos)";
            }


            else if (DateType == "Select")
            {
                //chkSelectDate.Checked = true;
                txtFromDate.Enabled = true;
                txtToDate.Enabled = true;

                Label.Text = "(DOS) ";
            }
            else
            {
                DateTime Date = DateTime.Now;


                StartDate = Date.AddDays(-90).ToString("M/d/yyyy"); ;
                EndDate = DateTime.Today.ToString("M/d/yyyy"); ;
                Label.Text = "Last 90 Days (Dos)";
            }


        }
    }
    protected void PostDate()
    {
        txtFromDate.Text = PostStartDate;
        txtToDate.Text = PostEndDate;

        if (!string.IsNullOrEmpty(DateType))
        {
            if (DateType == "MonthToDate")
            {
                DateTime Date = DateTime.Now;

                PostStartDate = new DateTime(Date.Year, Date.Month, 1).ToString("M/d/yyyy"); ;
                PostEndDate = Date.AddDays(1).ToString("M/d/yyyy"); ;

                //chkMonthToDate.Checked = true;
                Label.Text = " Month To Date (Post)";
            }

            else if (DateType == "LastMonth")
            {
                DateTime Date = DateTime.Now;

                if (Date.Month == 1)
                {
                    PostStartDate = new DateTime(Date.Year - 1, 12, 1).ToString("M/d/yyyy"); ;

                    PostEndDate = new DateTime(Date.Year - 1, Date.AddMonths(-1).Month, DateTime.DaysInMonth(Date.Year - 1, 12)).ToString("M/d/yyyy"); ;
                }
                else
                {
                    PostStartDate = new DateTime(Date.Year, Date.Month - 1, 1).ToString("M/d/yyyy"); ;

                    PostEndDate = new DateTime(Date.Year, Date.Month - 1, DateTime.DaysInMonth(Date.Year, Date.Month - 1)).ToString("M/d/yyyy"); ;
                }

                //chkLastMonth.Checked = true;
                Label.Text = " Last Month (Post)";

            }
            else if (DateType == "Last3Month")
            {
                DateTime Date = DateTime.Now;

                if (Date.Month == 3)
                {
                    PostStartDate = Date.AddDays(-90).ToString("M/d/yyyy"); ;
                    PostEndDate = DateTime.Today.ToString("M/d/yyyy"); ;
                    
                }
                else
                {
                    PostStartDate = Date.AddDays(-90).ToString("M/d/yyyy"); ;
                    PostEndDate = DateTime.Today.ToString("M/d/yyyy"); ;
                   
                }

                //chkLastMonth.Checked = true;
                Label.Text = " Last 90 Days (Post)";

            }


            else if (DateType == "YearToDate")
            {
                DateTime Date = DateTime.Now;

                PostStartDate = new DateTime(Date.Year, 1, 1).ToString("M/d/yyyy"); ;
                PostEndDate = Date.AddDays(1).ToString("M/d/yyyy"); ;
                //chkYearToDate.Checked = true;
                Label.Text = "Year To Date (Post)";
            }


            else if (DateType == "Select")
            {
                //chkSelectDate.Checked = true;
                txtFromDate.Enabled = true;
                txtToDate.Enabled = true;
                Label.Text = "(Post) ";
            }

            else if (DateType == "Last3Month")
            {
                DateTime Date = DateTime.Now;

                //StartDate = new DateTime(Date.Year, 1, 1).ToString("M/d/yyyy");;
                PostStartDate = Date.AddDays(-90).ToString("M/d/yyyy"); ;
                PostEndDate = DateTime.Today.ToString("M/d/yyyy"); ;
                Label.Text = "Last 90 Days (Post)";
            }

        }
    }
}