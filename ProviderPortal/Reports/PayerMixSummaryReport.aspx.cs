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


public partial class ProviderPortal_Reports_PayerMixSummaryReport : System.Web.UI.Page
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
        hdnDateFrom.Value = Request.Form["DateFrom"];
        hdnDateTo.Value = Request.Form["DateTo"];
        DataSet dsReportData = objPatientReportsDB.GetPayerMixSummary(PracticeId, 10, 0, "PayerName asc");

        rptPayerMixSummary.DataSource = dsReportData.Tables[0];
        rptPayerMixSummary.DataBind();
        hdnTotalRows.Value = dsReportData.Tables[1].Rows[0]["TotalRows"].ToString();


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

        int Rows = Convert.ToInt32(hdnTotalRows.Value);
        long PracticeId = Profile.PracticeId;
        ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();
        _DateFrom = Request.Form["DateFrom"];
        _DateTo = Request.Form["DateTo"];
        DataSet dsReportData = objPatientReportsDB.GetPayerMixSummary(PracticeId, Rows, 0, "PayerName ASC");
        rptPayerMixSummary.DataSource = dsReportData.Tables[0];
        rptPayerMixSummary.DataBind();
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=Payer-Mix-Summary.xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        rptPayerMixSummary.RenderControl(hw);
        Response.Output.Write(sw.ToString());
        Response.Flush();
        Response.End();
    }
    public void repeaterExportToPDF(object sender, EventArgs e)
    {
        int Rows = Convert.ToInt32(hdnTotalRows.Value);
        long PracticeId = Profile.PracticeId;
        ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();
        _DateFrom = Request.Form["DateFrom"];
        _DateTo = Request.Form["DateTo"];
        DataSet dsReportData = objPatientReportsDB.GetPayerMixSummary(PracticeId, Rows, 0, "PayerName ASC");
        rptPayerMixSummary.DataSource = dsReportData.Tables[0];
        rptPayerMixSummary.DataBind();
        Response.ContentType = "application/pdf";
        Response.AddHeader("content-disposition", "attachment;filename=Payer-Mix-Summary.pdf");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        rptPayerMixSummary.DataBind();
        rptPayerMixSummary.RenderControl(hw);
        string result = "";
        if (sw.ToString().Contains("<table>"))
        {
            result = Regex.Replace(sw.ToString(), @"<table>", "<table border='1'>");
            result = Regex.Replace(result, @"<th>", "<th style='font-size:8px; font-weight:bold;'>");
            result = Regex.Replace(result, @"<td>", "<td style='font-size:8px; font-weight:normal !important;'>");
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
        int Rows = Convert.ToInt32(hdnTotalRows.Value);
        long PracticeId = Profile.PracticeId;
        ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();
        _DateFrom = Request.Form["DateFrom"];
        _DateTo = Request.Form["DateTo"];
        DataSet dsReportData = objPatientReportsDB.GetPayerMixSummary(PracticeId, Rows, 0, "PayerName ASC");
        rptPayerMixSummary.DataSource = dsReportData.Tables[0];
        rptPayerMixSummary.DataBind();

        Response.Clear();
        Response.AddHeader("content-disposition", "attachment;filename=Payer-Mix-Summary.doc");
        Response.Charset = "";
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = "application/vnd.word";
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
        rptPayerMixSummary.RenderControl(htmlWrite);
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
    protected void rptPayerMixSummary_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView drv = (DataRowView)e.Item.DataItem;
            Label lblPatient = (Label)e.Item.FindControl("lblPatient");
            if (!string.IsNullOrEmpty(drv["Patient"].ToString()))
            {
                string Patient = drv["Patient"].ToString();
                lblPatient.Text = Patient;
            }
            else
            {
                lblPatient.Text = "0";
            }

            Label lblPtnt = (Label)e.Item.FindControl("lblPtnt");
            if (!string.IsNullOrEmpty(drv["Ptnt"].ToString()))
            {
                string Ptnt = drv["Ptnt"].ToString();
                lblPtnt.Text = Ptnt;
            }
            else
            {
                lblPtnt.Text = "-";
            }

            Label lblEncounter = (Label)e.Item.FindControl("lblEncounter");
            if (!string.IsNullOrEmpty(drv["Encounter"].ToString()))
            {
                string Encounter = drv["Encounter"].ToString();
                lblEncounter.Text = Encounter;
            }
            else
            {
                lblEncounter.Text = "0";
            }

            Label lblEncntrs = (Label)e.Item.FindControl("lblEncntrs");
            if (!string.IsNullOrEmpty(drv["Encntrs"].ToString()))
            {
                string Encntrs = drv["Encntrs"].ToString();
                lblEncntrs.Text = Encntrs;
            }
            else
            {
                lblEncntrs.Text = "-";
            }

            Label lblProcedure = (Label)e.Item.FindControl("lblProcedure");
            if (!string.IsNullOrEmpty(drv["Procedure"].ToString()))
            {
                string Procedure = drv["Procedure"].ToString();
                lblProcedure.Text = Procedure;
            }
            else
            {
                lblProcedure.Text = "0";
            }

            Label lblProc = (Label)e.Item.FindControl("lblProc");
            if (!string.IsNullOrEmpty(drv["Proc"].ToString()))
            {
                string Proc = drv["Proc"].ToString();
                lblProc.Text = Proc;
            }
            else
            {
                lblProc.Text = "-";
            }

            Label lblCharges = (Label)e.Item.FindControl("lblCharges");
            if (!string.IsNullOrEmpty(drv["Charges"].ToString()))
            {
                string Charges = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(drv["Charges"].ToString()));
                lblCharges.Text = Charges;
            }
            else
            {
                lblCharges.Text = "$0";
            }

            Label lblChrgs = (Label)e.Item.FindControl("lblChrgs");
            if (!string.IsNullOrEmpty(drv["Chrgs"].ToString()))
            {
                string Chrgs = drv["Chrgs"].ToString();
                lblChrgs.Text = Chrgs;
            }
            else
            {
                lblChrgs.Text = "-";
            }

            Label lblReceipt = (Label)e.Item.FindControl("lblReceipt");
            if (!string.IsNullOrEmpty(drv["Receipt"].ToString()))
            {
                string Receipt = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(drv["Receipt"].ToString()));
                lblReceipt.Text = Receipt;
            }
            else
            {
                lblReceipt.Text = "$0";
            }

            Label lblRcpts = (Label)e.Item.FindControl("lblRcpts");
            if (!string.IsNullOrEmpty(drv["Rcpts"].ToString()))
            {
                string Rcpts = drv["Rcpts"].ToString();
                lblRcpts.Text = Rcpts;
            }
            else
            {
                lblRcpts.Text = "-";
            }
        }
    }
}