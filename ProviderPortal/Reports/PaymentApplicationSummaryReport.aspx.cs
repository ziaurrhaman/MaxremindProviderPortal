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


public partial class ProviderPortal_Reports_PaymentApplicationSummaryReport : System.Web.UI.Page
{
    string _DateFrom = "";
    string _DateTo = "";
    string _TimeSpan = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadReport();
    }
    private void LoadReport()
    {
        ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();
        long PracticeId = Profile.PracticeId;
        _DateFrom = Request.Form["DateFrom"];
        _DateTo = Request.Form["DateTo"];
        DataSet dsReportData = objPatientReportsDB.GetPaymentApplicationSummary(PracticeId, _DateFrom, _DateTo);

        rptPaymentApplicationSummary.DataSource = dsReportData.Tables[0];
        rptPaymentApplicationSummary.DataBind();
        rptPaymentApplicationSummary1.DataSource = dsReportData.Tables[1];
        rptPaymentApplicationSummary1.DataBind();
        rptPaymentApplicationSummary2.DataSource = dsReportData.Tables[2];
        rptPaymentApplicationSummary2.DataBind();
        //hdnTotalRows.Value = dsReportData.Tables[1].Rows[0]["TotalRows"].ToString();


        SetDatesObjects();

    }
    private void SetDatesObjects()
    {

        _TimeSpan = Request.Form["TimeSpan"];
        _DateFrom = Request.Form["DateFrom"];
        _DateTo = Request.Form["DateTo"];

        hdnTimeSpan.Value = _TimeSpan;
        hdnDateFrom.Value = _DateFrom;
        hdnDateTo.Value = _DateTo;

        DateTime now = DateTime.Now;

        if (_TimeSpan == "Beginning")
        {
            //_DateFrom = "01/01/1900";
            //_DateTo = DateTime.Now.ToString("MM/dd/yyyy");
            _DateFrom = "";
            _DateTo = "";
            lblReportTimeSpanFrom.Text = "All Records";
            //lblReportTimeSpanTo.Text = "Till Date";
        }
        else
        {
            separateSpan.Style.Remove("display");
            if (_TimeSpan == "YearToDate")
            {
                _DateFrom = (new DateTime(DateTime.Now.Year, 1, 1)).ToString("MM/dd/yyyy");
                _DateTo = now.ToString("MM/dd/yyyy");
            }
            else if (_TimeSpan == "MonthToDate")
            {
                _DateFrom = (new DateTime(now.Year, now.Month, 1)).ToString("MM/dd/yyyy");
                _DateTo = now.ToString("MM/dd/yyyy");
            }
            else if (_TimeSpan == "LastMonth")
            {
                //Changes by Iftikhar Ahmed on 01-18-2016
                int year = now.Year;
                if (now.Month == 1)
                {
                    year = now.AddYears(-1).Year;
                }
                _DateFrom = (new DateTime(year, (now.AddMonths(-1).Month), 1)).ToString("MM/dd/yyyy");
                _DateTo = (new DateTime(year, (now.AddMonths(-1).Month), 1)).AddMonths(1).AddDays(-1).ToString("MM/dd/yyyy");
            }
            else if (_TimeSpan == "SpecificDates")
            {
                if (_DateFrom == "") _DateFrom = "01/01/1900";
                if (_DateTo == "") _DateTo = DateTime.Now.ToString("MM/dd/yyyy");
            }

            lblReportTimeSpanFrom.Text = _DateFrom;
            lblReportTimeSpanTo.Text = _DateTo;
        }
    }
    protected void ExportToExcel(object sender, EventArgs e)
    {
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=Payment-Application-Summary.xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        divReportListing.RenderControl(hw);
        Response.Output.Write(sw.ToString());
        Response.Flush();
        Response.End();
    }
    public void repeaterExportToPDF(object sender, EventArgs e)
    {

        Response.ContentType = "application/pdf";
        Response.AddHeader("content-disposition", "attachment;filename=Payment-Application-Summary.pdf");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        divReportListing.DataBind();
        divReportListing.RenderControl(hw);
        string result = "";
        if (sw.ToString().Contains("<table>"))
        {
            result = Regex.Replace(sw.ToString(), @"<table>", "<table border='1'>");
            result = Regex.Replace(result, @"<th>", "<th style='font-size:8px; font-weight:bold;'>");
            result = Regex.Replace(result, @"<td>", "<td style='font-size:8px; font-weight:normal !important;'>");
        }
        else
        {
            result = sw.ToString();
        }
        StringReader sr = new StringReader(result.ToString());
        Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
        HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
        PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
        pdfDoc.Open();
        htmlparser.Parse(sr);
        pdfDoc.Close();
        Response.Write(pdfDoc);
        Response.End();

    }
    public void repeaterExportToWord(object sender, EventArgs e)
    {


        Response.Clear();
        Response.AddHeader("content-disposition", "attachment;filename=Payment-Application-Summary.doc");
        Response.Charset = "";
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = "application/vnd.word";
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
        divReportListing.RenderControl(htmlWrite);
        Response.Write(stringWrite.ToString());
        Response.End();
    }
    protected void ddlExportTo_SelectedIndexChanged(object sender, EventArgs e)
    {
        Utility obj = new Utility();

        string html = hdnReportHtml.Value;
        string exportTo = ddlExportTo.SelectedValue;

        string FileName = "Patient Claims";

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
            repeaterExportToWord(sender, e);
        }
    }
    protected void rptPaymentApplicationSummary_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView drv = (DataRowView)e.Item.DataItem;
            string RenderingProvider = drv["RenderingProvider"].ToString();
            string PaymentMethod = drv["PaymentMethod"].ToString();
            Label lblPaymentMethod = (Label)e.Item.FindControl("lblPaymentMethod");
            Label lblSubTotal = (Label)e.Item.FindControl("lblSubTotal");
            Label lblGrandTotal = (Label)e.Item.FindControl("lblGrandTotal");
            if (PaymentMethod == "" && RenderingProvider != "")
            {
                lblSubTotal.Text = "Sub Total :";
            }
            else if (RenderingProvider == "")
            {
                lblGrandTotal.Text = "Grand Total :";
            }
            else
            {
                lblPaymentMethod.Text = PaymentMethod;
            }

            Label lblTotalSummary = (Label)e.Item.FindControl("lblTotalSummary");
            if (!string.IsNullOrEmpty(drv["Total"].ToString()))
            {
                string Total = drv["Total"].ToString();
                lblTotalSummary.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(Total));
            }
        }
    }
    protected void rptPaymentApplicationSummary2_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView drv = (DataRowView)e.Item.DataItem;
            string PaymentMethod = drv["PaymentMethod"].ToString();
            Label lblPaymentMethod = (Label)e.Item.FindControl("lblPaymentMethod3");
            Label lblGrandTotal = (Label)e.Item.FindControl("lblGrandTotal3");
            if (PaymentMethod == "")
            {
                lblGrandTotal.Text = "Grand Total :";
            }
            else
            {
                lblPaymentMethod.Text = PaymentMethod;
            }
            Label lblTotalAllRenderingProviders = (Label)e.Item.FindControl("lblTotalAllRenderingProviders");
            if (!string.IsNullOrEmpty(drv["Total"].ToString()))
            {
                string Total = drv["Total"].ToString();
                lblTotalAllRenderingProviders.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(Total));
            }
        }
    }
    protected void rptPaymentApplicationSummary1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView drv = (DataRowView)e.Item.DataItem;
            string total = drv["Total"].ToString();
            Label lblTotalUnappliedAnalysis = (Label)e.Item.FindControl("lblTotalUnappliedAnalysis");
            if (total != "")
            {
                lblTotalUnappliedAnalysis.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(total));
            }
        }
    }
}