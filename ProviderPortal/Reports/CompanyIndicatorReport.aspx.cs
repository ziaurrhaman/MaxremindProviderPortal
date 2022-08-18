using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CompanyIndicatorReport : System.Web.UI.Page
{
    string PostStartDate = "";
    string PostEndDate = "";

    string StartDate = "";
    string EndDate = "";
    string DateType = ""; 
    protected void Page_Load(object sender, EventArgs e)
    {
        DateType = Request.QueryString["DateType"] == "All" ? "" : Request.QueryString["DateType"];
        string RadioBtn = Request.QueryString["Radiobtn"];



        if (RadioBtn == "Post")
        {
            PostStartDate = Request.QueryString["StartDate"];
            PostEndDate = Request.QueryString["EndDate"];
            PostDate();
            DOSRb.Checked = false;
            PostRb.Checked = true;

        }

        else if (RadioBtn == "DOS")
        {
            StartDate = Request.QueryString["StartDate"];
            EndDate = Request.QueryString["EndDate"];
            DOSDate();
            DOSRb.Checked = true;
            PostRb.Checked = false;
        }

        else
        {
            DateTime Date = DateTime.Now;

            //StartDate = new DateTime(Date.Year, 1, 1).ToShortDateString();
            PostStartDate = Date.AddDays(-90).ToShortDateString();
            PostEndDate = DateTime.Today.ToShortDateString();
            Label.Text = "Last 90 Days (Post)";
        }




        ReportsDB db = new ReportsDB();
        // Charges Payment Adjustment Due
        
        DataSet dsChargesPaymentsAdjustmentBalanceDue = db.GetCompanyIndicatorReport(Profile.PracticeId, StartDate, EndDate, PostStartDate, PostEndDate);

        string Charges = dsChargesPaymentsAdjustmentBalanceDue.Tables[0].Rows[0]["Charges"].ToString();

        if (string.IsNullOrEmpty(Charges))
        {
            lblCharges.Text = "0";
            lblCharges1.Text = "0";
        }
        else
        {
            decimal charges = Convert.ToDecimal(dsChargesPaymentsAdjustmentBalanceDue.Tables[0].Rows[0]["Charges"].ToString());
            string chargesString = String.Format("{0:C}", charges);
            lblCharges.Text = chargesString;
            lblCharges1.Text = chargesString;

        }


        string Payments = dsChargesPaymentsAdjustmentBalanceDue.Tables[1].Rows[0]["Payments"].ToString();

        if (string.IsNullOrEmpty(Payments))
        {
            lblPayments.Text = "0";
            lblPayments1.Text = "0";
        }
        else
        {
            decimal payment = Convert.ToDecimal(dsChargesPaymentsAdjustmentBalanceDue.Tables[1].Rows[0]["Payments"].ToString());
            string paymentString = String.Format("{0:C}", payment);
            lblPayments.Text = paymentString;
            lblPayments1.Text = paymentString;
        }



        string Adjustment = dsChargesPaymentsAdjustmentBalanceDue.Tables[2].Rows[0]["Adjustments"].ToString();

        if (string.IsNullOrEmpty(Adjustment))
        {
            lblAdjustments.Text = "0";
            lblAdjustments1.Text = "0";
        }
        else
        {
            decimal Adjustments = Convert.ToDecimal(dsChargesPaymentsAdjustmentBalanceDue.Tables[2].Rows[0]["Adjustments"].ToString());
            string AdjustmentsString = String.Format("{0:C}", Adjustments);
            string adjustments = AdjustmentsString.Trim(new Char[] { ' ', '(', ')' });
            string adjustment1 = "-" + " " + adjustments;
            if (Adjustments > 0)
            {
                lblAdjustments.Text = AdjustmentsString;
                lblAdjustments1.Text = AdjustmentsString;
            }
            else
            {
                lblAdjustments.Text = adjustment1;
                lblAdjustments1.Text = adjustment1;
            }

        }

        string Balance = dsChargesPaymentsAdjustmentBalanceDue.Tables[3].Rows[0]["BalanceDue"].ToString();

        if ((Balance == "0.0000") || (string.IsNullOrEmpty(Balance)))
        {
            lblBalanceDue.Text = "0";
            lblBalanceDue1.Text = "0";
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
                lblBalanceDue1.Text = balance;
            }
            else
            {
                lblBalanceDue.Text = blance1;
                lblBalanceDue1.Text = blance1;
            }

        }

        if (dsChargesPaymentsAdjustmentBalanceDue.Tables[4].Rows.Count > 0)
        {
            Practice.Text = dsChargesPaymentsAdjustmentBalanceDue.Tables[4].Rows[0]["PracticeName"].ToString();
            Procedures.Text = dsChargesPaymentsAdjustmentBalanceDue.Tables[4].Rows[0]["Procedures"].ToString();
            Procedures1.Text = dsChargesPaymentsAdjustmentBalanceDue.Tables[4].Rows[0]["Procedures"].ToString();
        }
        else
        {
            Practice.Text = "";
            Procedures.Text = "0";
            Procedures1.Text = "0";
        }
      
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


                StartDate = new DateTime(Date.Year, Date.Month, 1).ToShortDateString();
                EndDate = Date.AddDays(1).ToShortDateString();

                chkMonthToDate.Checked = true;
                Label.Text = " Month To Date (Dos)";
            }

            else if (DateType == "LastMonth")
            {
                DateTime Date = DateTime.Now;

                if (Date.Month == 1)
                {
                    StartDate = new DateTime(Date.Year - 1, 12, 1).ToShortDateString();
                    // EndDate = new DateTime(Date.Year, Date.Month - 1, DateTime.DaysInMonth(Date.Year - 1, 12)).ToShortDateString();
                    EndDate = new DateTime(Date.Year, Date.Month, 1).ToShortDateString();
                }
                else
                {
                    StartDate = new DateTime(Date.Year, Date.Month - 1, 1).ToShortDateString();
                    //  EndDate = new DateTime(Date.Year, Date.Month - 1, DateTime.DaysInMonth(Date.Year, Date.Month - 1)).ToShortDateString();
                    EndDate = new DateTime(Date.Year, Date.Month, 1).ToShortDateString();
                }


                chkLastMonth.Checked = true;
                Label.Text = " Last Month (Dos)";

            }


            else if (DateType == "YearToDate")
            {
                DateTime Date = DateTime.Now;

                StartDate = new DateTime(Date.Year, 1, 1).ToShortDateString();
                EndDate = Date.AddDays(1).ToShortDateString();
                chkYearToDate.Checked = true;
                Label.Text = "Year To Date (Dos)";
            }


            else if (DateType == "Select")
            {
                chkSelectDate.Checked = true;
                txtFromDate.Enabled = true;
                txtToDate.Enabled = true;
                Label.Text = txtFromDate.Text + "-" + txtToDate.Text + " (Dos)";
            }
            else
            {
                DateTime Date = DateTime.Now;

                //StartDate = new DateTime(Date.Year, 1, 1).ToShortDateString();
                StartDate = Date.AddDays(-90).ToShortDateString();
                EndDate = DateTime.Today.ToShortDateString();
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

                PostStartDate = new DateTime(Date.Year, Date.Month, 1).ToShortDateString();
                PostEndDate = Date.AddDays(1).ToShortDateString();

                chkMonthToDate.Checked = true;
                Label.Text = " Month To Date (Post)";
            }

            else if (DateType == "LastMonth")
            {
                DateTime Date = DateTime.Now;

                if (Date.Month == 1)
                {
                    PostStartDate = new DateTime(Date.Year - 1, 12, 1).ToShortDateString();
                    //PostEndDate = new DateTime(Date.Year, Date.Month - 1, DateTime.DaysInMonth(Date.Year - 1, 12)).ToShortDateString();
                    PostEndDate = new DateTime(Date.Year, Date.Month, 1).ToShortDateString();
                }
                else
                {
                    PostStartDate = new DateTime(Date.Year, Date.Month - 1, 1).ToShortDateString();
                    PostEndDate = new DateTime(Date.Year, Date.Month, 1).ToShortDateString();
                    // PostEndDate = new DateTime(Date.Year, Date.Month - 1, DateTime.DaysInMonth(Date.Year, Date.Month - 1)).ToShortDateString();
                }

                chkLastMonth.Checked = true;
                Label.Text = " Last Month (Post)";

            }


            else if (DateType == "YearToDate")
            {
                DateTime Date = DateTime.Now;

                PostStartDate = new DateTime(Date.Year, 1, 1).ToShortDateString();
                PostEndDate = Date.AddDays(1).ToShortDateString();
                chkYearToDate.Checked = true;
                Label.Text = "Year To Date (Post)";
            }


            else if (DateType == "Select")
            {
                chkSelectDate.Checked = true;
                txtFromDate.Enabled = true;
                txtToDate.Enabled = true;
                Label.Text = txtFromDate.Text + "-" + txtToDate.Text + " (Post)";
            }

            else
            {
                DateTime Date = DateTime.Now;

                //StartDate = new DateTime(Date.Year, 1, 1).ToShortDateString();
                PostStartDate = Date.AddDays(-90).ToShortDateString();
                PostEndDate = DateTime.Today.ToShortDateString();
                Label.Text = "Last 90 Days (Post)";
            }

        }
    }

    public void repeaterExportToPDF(object sender, EventArgs e)
    {
        Response.ContentType = "application/pdf";

        Response.AddHeader("content-disposition", "attachment;filename=Company Indicator.pdf");

        Response.Cache.SetCacheability(HttpCacheability.NoCache);

        StringWriter sw = new StringWriter();

        HtmlTextWriter hw = new HtmlTextWriter(sw);

        divReportListing.RenderControl(hw);

        StringReader sr = new StringReader(sw.ToString());

        Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 100f, 0f);

        HTMLWorker htmlparser = new HTMLWorker(pdfDoc);

        PdfWriter.GetInstance(pdfDoc, Response.OutputStream);

        pdfDoc.Open();

        htmlparser.Parse(sr);

        pdfDoc.Close();

        Response.Write(pdfDoc);

        Response.End();
    
    }

    public void repeaterExportToDoc(object sender, EventArgs e)
    {
       

        Response.Clear();
        Response.AddHeader("content-disposition", "attachment;filename=Company Indicator.doc");
        Response.Charset = "";
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = "application/vnd.word";
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
        divReportListing.RenderControl(htmlWrite);
        Response.Write(stringWrite.ToString());
        Response.End();

    }

    public void ExportToExcel(object sender, EventArgs e)
    {
        Response.Clear();
        Response.AddHeader("content-disposition", "attachment;filename=Company Indicator.xls");
        Response.Charset = "";
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = "application/vnd.ms-excel";
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
        divReportListing.RenderControl(htmlWrite);
        Response.Write(stringWrite.ToString());
        Response.End();

    }
    protected void ddlExportTo_SelectedIndexChanged(object sender, EventArgs e)
    {
        Utility obj = new Utility();

       
        string exportTo = ddlExportTo.SelectedValue;



        if (exportTo == "Excel")
        {
            //obj.ExportToExcel(ref html, FileName);
            ExportToExcel(sender, e);
        }
      
        else if (exportTo == "PDF")
        {
            //obj.ExportToPDF(ref html, FileName);
            repeaterExportToPDF(sender, e);
        }
        else if (exportTo == "Word")
        {
            //obj.ExportToWord(html, FileName);
            repeaterExportToDoc(sender, e);
        }
    }


}