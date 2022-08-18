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


public partial class ProviderPortal_Reports_PaymentsSummaryReport : System.Web.UI.Page
{
    string _DateFrom = "";
    string _DateTo = "";
    string _TimeSpan = "";
    ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();

    protected void Page_Load(object sender, EventArgs e)
    {
        LoadReport();
        
    }
    private void LoadReport()
    {
        long PracticeId = Profile.PracticeId;
        _DateFrom = Request.Form["DateFrom"];
        _DateTo = Request.Form["DateTo"];
        DataSet dsReportData = objPatientReportsDB.GetPaymentsSummary(PracticeId, _DateFrom, _DateTo,null,null,null,null);

        rptPaymentsSummary.DataSource = dsReportData.Tables[0];
        rptPaymentsSummary.DataBind();
        GetTotal();

        SetDatesObjects();
       
        
    }
    public void GetTotal()
    {
        DataTable dtReportData = objPatientReportsDB.GetTotalPaymentsSummary(Profile.PracticeId, _DateFrom, _DateTo,null,null,null,null);
        Control FooterTemplate = rptPaymentsSummary.Controls[rptPaymentsSummary.Controls.Count - 1].Controls[0];
        if (dtReportData.Rows.Count > 0)
        {
            Label lblGrandTotal = FooterTemplate.FindControl("lblGrandTotal") as Label;
            lblGrandTotal.Text = "Grand Total";
            if (!string.IsNullOrEmpty(dtReportData.Rows[0]["Payment"].ToString()))
            {
                float TotalAmount = float.Parse(dtReportData.Compute("sum(Payment)", string.Empty).ToString());
                Label lblTotalAmount = FooterTemplate.FindControl("lblTotalAmount") as Label;
                lblTotalAmount.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(TotalAmount));
            }
            if (!string.IsNullOrEmpty(dtReportData.Rows[0]["Unapplied"].ToString()))
            {
                float TotalUnapplied = float.Parse(dtReportData.Compute("sum(Unapplied)", string.Empty).ToString());
                Label lblTotalUnapplied = FooterTemplate.FindControl("lblTotalUnapplied") as Label;
                lblTotalUnapplied.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(TotalUnapplied));
            }
        }
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
        Response.AddHeader("content-disposition", "attachment;filename=Payment-Summary.xls");
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

        //Response.ContentType = "application/pdf";
        //Response.AddHeader("content-disposition", "attachment;filename=Payment-Summary.pdf");
        //Response.Cache.SetCacheability(HttpCacheability.NoCache);
        //StringWriter sw = new StringWriter();
        //HtmlTextWriter hw = new HtmlTextWriter(sw);
        //divReportListing.DataBind();
        //divReportListing.RenderControl(hw);
        //StringReader sr = new StringReader(sw.ToString());
        //Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
        //HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
        //PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
        //pdfDoc.Open();

        //htmlparser.Parse(sr);
        //pdfDoc.Close();
        //Response.Write(pdfDoc);
        //Response.End();
        string attachment = "attachment; filename=Payment By Procedure.pdf";
        Response.ClearContent();
        Response.AddHeader("content-disposition", attachment);
        Response.ContentType = "application/pdf";
        StringWriter stw = new StringWriter();
        HtmlTextWriter htextw = new HtmlTextWriter(stw);
        divReportListing.RenderControl(htextw);
        Document document = new Document();
        PdfWriter.GetInstance(document, Response.OutputStream);
        document.Open();
        string result = "";
        if (stw.ToString().Contains("<table>"))
        {
            result = Regex.Replace(stw.ToString(), @"<table>", "<table border='1'>");
            result = Regex.Replace(result, @"<th>", "<th style='font-size:8px; font-weight:bold;'>");
            result = Regex.Replace(result, @"<td>", "<td style='font-size:8px; font-weight:normal !important;'>");
        }
        StringReader str = new StringReader(result.ToString());
        HTMLWorker htmlworker = new HTMLWorker(document);
        htmlworker.Parse(str);
        document.Close();
        Response.Write(document);
        Response.End();
    }
    public void repeaterExportToWord(object sender, EventArgs e)
    {

        Response.Clear();
        Response.AddHeader("content-disposition", "attachment;filename=Payment-Summary.doc");
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

        string FileName = "Payment Summary";

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
    protected void rptPaymentsSummary_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView drv = (DataRowView)e.Item.DataItem;
            string Amount = drv["Payment"].ToString();
            Label lblAmount = (Label)e.Item.FindControl("lblAmount");
            if (Amount != "")
            {
                lblAmount.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(Amount));
            }
            string Unapplied = drv["Unapplied"].ToString();
            Label lblUnapplied = (Label)e.Item.FindControl("lblUnapplied");
            if (Unapplied != "")
            {
                lblUnapplied.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(Unapplied));
            }
        }
    }
}