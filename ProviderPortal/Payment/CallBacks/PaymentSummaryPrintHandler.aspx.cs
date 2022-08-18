using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class ProviderPortal_Payment_CallBacks_PaymentSummaryPrintHandler : System.Web.UI.Page
{

    //Rizwan kharal
    //13 Nov 2017
    // For Payment Summary Report

  
    protected void Page_Load(object sender, EventArgs e)
    {
        string StartDate = null;
        string EndDate = null;
        ERAMasterDB db = new ERAMasterDB();
        DataSet ds = new DataSet();
        long PracticeId = Profile.PracticeId;

        decimal Insurance = 0; decimal UnAppliedPatient = 0; decimal Other = 0;
        decimal patient = 0; decimal UnAppliedInsurance = 0; decimal UnAppliedOther = 0;



        string action = Request.Form["action"];


        if (action == "action")
        {
            string query = Request.Form["ddldates"];
            if (Request.Form["ddldates"] != null)
            {
                if (query == "SelectDates")
                {

                    StartDate = Request.Form["startDate"];
                    EndDate = Request.Form["EndDate"];
                    DateTime Date = new DateTime();
                    txtfirst.Text = StartDate;
                    txtlast.Text = EndDate;


                }
                if (query == "MonthtoDate")
                {
                    DateTime Date = DateTime.Now;
                    StartDate = new DateTime(Date.Year, Date.Month, 1).ToShortDateString();
                    EndDate = Date.ToShortDateString();
                  //  EndDate = Date.AddDays(1).ToShortDateString();
                    string first = new DateTime(Date.Year, Date.Month, 1).ToString("MMMM dd yyyy");
                    string last = Date.ToString("MMMM dd yyyy"); 
                    txtfirst.Text = first;
                    txtlast.Text = last;



                }

                if (query == "LastMonth")
                {
                    DateTime Date = DateTime.Now;

                    if (Date.Month == 1)
                    {
                        StartDate = new DateTime(Date.Year - 1, 12, 1).ToShortDateString();
                         EndDate = new DateTime(Date.Year-1, Date.AddMonths(-1).Month, DateTime.DaysInMonth(Date.Year - 1, 12)).ToShortDateString();
                       // EndDate = new DateTime(Date.Year, Date.Month, 1).ToShortDateString();

                        string first = new DateTime(Date.Year - 1, 12, 1).ToString("MMMM dd yyyy");
                        string last = new DateTime(Date.Year-1, 12, 31).ToString("MMMM dd yyyy"); ;
                        txtfirst.Text = first;
                        txtlast.Text = last;
                    }
                    else
                    {
                        StartDate = new DateTime(Date.Year, Date.AddMonths(-1).Month, 1).ToShortDateString();
                          EndDate = new DateTime(Date.Year, Date.AddMonths(-1).Month, DateTime.DaysInMonth(Date.Year, Date.AddMonths(-1).Month)).ToShortDateString();
                        //EndDate = new DateTime(Date.Year, Date.Month, 1).ToShortDateString();

                        string first = new DateTime(Date.Year, Date.AddMonths(-1).Month, 1).ToString("MMMM dd yyyy");
                        string last = new DateTime(Date.Year, Date.AddMonths(-1).Month, DateTime.DaysInMonth(Date.Year, Date.AddMonths(-1).Month)).ToString("MMMM dd yyyy");;
                            //new DateTime(Date.Year, Date.Month, 1).ToString("MMMM dd yyyy"); ;
                        txtfirst.Text = first;
                        txtlast.Text = last;

                    }




                }



                if (query == "YearToDate")
                {
                    DateTime Date = DateTime.Now;

                    StartDate = new DateTime(Date.Year, 1, 1).ToShortDateString();
                    EndDate = Date.ToShortDateString();
                   // EndDate = Date.AddDays(1).ToShortDateString();
                    string first = new DateTime(Date.Year, 1, 1).ToString("MMMM dd yyyy");
                    string last = Date.ToString("MMMM dd yyyy"); ;
                    txtfirst.Text = first;
                    txtlast.Text = last;
                }

            }
        }

        if (StartDate == null && EndDate == null)
        {
            TxtInsurance.Text = "";
            TxtPatient.Text = "";
            TxtUinsu.Text = "";
            TxtUPatient.Text = "";
        }
        else
        {
            ds = db.PaymentSummary(PracticeId, "PostDate", StartDate, EndDate, "", "", "");
            string Insurances = ds.Tables[0].Rows[0]["PostedPmt"].ToString();
            if (string.IsNullOrEmpty(Insurances))
            {
                TxtInsurance.Text = "$0.00";
            }
            else
            {
                Insurance = Convert.ToDecimal(ds.Tables[0].Rows[0]["PostedPmt"].ToString());
                string chargesString = String.Format("{0:C}", Insurance);
                TxtInsurance.Text = chargesString;
            }


            string other = ds.Tables[0].Rows[1]["PostedPmt"].ToString();
            if (string.IsNullOrEmpty(other))
            {
                TxtOther.Text = "$0.00";
            }
            else
            {
                Other = Convert.ToDecimal(ds.Tables[0].Rows[1]["PostedPmt"].ToString());
                string chargesString = String.Format("{0:C}", Other);
                TxtOther.Text = chargesString;
            }


            string patients = ds.Tables[0].Rows[2]["PostedPmt"].ToString();
            if (string.IsNullOrEmpty(patients))
            {
                TxtPatient.Text = "$0.00";
            }
            else
            {
                patient = Convert.ToDecimal(ds.Tables[0].Rows[2]["PostedPmt"].ToString());
                string patientString = String.Format("{0:C}", patient);
                TxtPatient.Text = patientString;
            }


            string UnAppliedPatients = ds.Tables[0].Rows[2]["UnApplied"].ToString();
            if (string.IsNullOrEmpty(UnAppliedPatients))
            {
                TxtUPatient.Text = "$0.00";
            }

            else
            {
                UnAppliedPatient = Convert.ToDecimal(ds.Tables[0].Rows[2]["UnApplied"].ToString());
                string UnAppliedPatientString = String.Format("{0:C}", UnAppliedPatient);
                TxtUPatient.Text = UnAppliedPatientString;
            }


            string UnAppliedother = ds.Tables[0].Rows[1]["UnApplied"].ToString();
            if (string.IsNullOrEmpty(UnAppliedother))
            {
                TxtUOther.Text = "$0.00";
            }

            else
            {
                UnAppliedOther = Convert.ToDecimal(ds.Tables[0].Rows[1]["UnApplied"].ToString());
                string UnAppliedPatientString = String.Format("{0:C}", UnAppliedOther);
                TxtUOther.Text = UnAppliedPatientString;
            }



            string UnAppliedInsurances = ds.Tables[0].Rows[0]["UnApplied"].ToString();

            if (string.IsNullOrEmpty(UnAppliedInsurances))
            {
                TxtUinsu.Text = "$0.00";
            }

            else
            {
                UnAppliedInsurance = Convert.ToDecimal(ds.Tables[0].Rows[0]["UnApplied"].ToString());
                string UnAppliedInsuranceString = String.Format("{0:C}", UnAppliedInsurance);

                TxtUinsu.Text = UnAppliedInsuranceString;
            }

            if (Insurance == 0)
            {

                TxtInsurance.Text = "$0.00";
            }
            if (patient == 0)
            {
                TxtPatient.Text = "$0.00";
            }

            if (Other == 0)
            {

                TxtOther.Text = "$0.00";
            }
            if (UnAppliedPatient == 0)
            {

                TxtUPatient.Text = "$0.00";
            }
            if (UnAppliedInsurance == 0)
            {

                TxtUinsu.Text = "$0.00";

            }
            if (UnAppliedOther == 0)
            {

                TxtUOther.Text = "$0.00";

            }
            decimal total = Convert.ToDecimal(patient) + Convert.ToDecimal(Insurance) + Convert.ToDecimal(Other);
            string FinalTotal = String.Format("{0:C}", total);
            TxtTotal.Text = FinalTotal;

            decimal utotal = Convert.ToDecimal(UnAppliedPatient) + Convert.ToDecimal(UnAppliedInsurance) + Convert.ToDecimal(UnAppliedOther); ;
            string FinaluTotal = String.Format("{0:C}", utotal);
            UTotal.Text = FinaluTotal;

            AmountTotal.Text = FinalTotal;
            UnAppliedTotal.Text = FinaluTotal;

            decimal Grandtotal = Convert.ToDecimal(total) + Convert.ToDecimal(utotal);
            string GrandFinalTotal = String.Format("{0:C}", Grandtotal);
            GrandTotals.Text = GrandFinalTotal;
       


        }
    }
}
