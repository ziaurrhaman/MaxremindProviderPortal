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

public partial class ProviderPortal_Reports_UnappliedAnalysisReport : System.Web.UI.Page
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
        DataSet dsReportData = objPatientReportsDB.GetUnappliedAnalysis(PracticeId, _DateFrom, _DateTo);

        rptUnappliedAnalysis.DataSource = dsReportData.Tables[0];
        rptUnappliedAnalysis.DataBind();

        DataTable dtReportData = objPatientReportsDB.GetTotalUnappliedAnalysis(PracticeId, _DateFrom, _DateTo);
        Control HeaderTemplate = rptUnappliedAnalysis.Controls[rptUnappliedAnalysis.Controls.Count - 1].Controls[0];
        Control FooterTemplate = rptUnappliedAnalysis.Controls[rptUnappliedAnalysis.Controls.Count - 1].Controls[0];

        if (dtReportData.Rows.Count > 0)
        {
            if (!string.IsNullOrEmpty(dtReportData.Rows[0]["Amt"].ToString()) && !string.IsNullOrEmpty(dtReportData.Rows[0]["UnappliedBalance"].ToString()))
            {
                string firstRow = dtReportData.Rows[0][0].ToString();
                if (firstRow != "")
                {

                    lblBeginingUnappliedBalance.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(decimal.Parse(dtReportData.Rows[0]["UnappliedBalance"].ToString()) - decimal.Parse(dtReportData.Rows[0]["Amt"].ToString().Replace("(", "").Replace(")", ""))));
                }
            }
            DataRow lastRow = dtReportData.Rows[dtReportData.Rows.Count - 1];
            if (!string.IsNullOrEmpty(lastRow["UnappliedBalance"].ToString()))
            {
                float LastTotalUnappliedBalance;
                LastTotalUnappliedBalance = float.Parse(lastRow["UnappliedBalance"].ToString());
                string ToatalChangeInUnapliedBallance = string.Format("{0:0,0.00}", Convert.ToDouble(decimal.Parse(lastRow["UnappliedBalance"].ToString()) - (decimal.Parse(dtReportData.Rows[0]["UnappliedBalance"].ToString()) - decimal.Parse(dtReportData.Rows[0]["Amt"].ToString().Replace("(", "").Replace(")", "")))).ToString());
               // Label lblChangeInUnapliedBallance = HeaderTemplate.FindControl("lblChangeInUnapliedBallance") as Label;
                lblChangeInUnapliedBallance.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(ToatalChangeInUnapliedBallance));
               // Label lblEndingUnappliedBalance = HeaderTemplate.FindControl("lblEndingUnappliedBalance") as Label;
                lblEndingUnappliedBalance.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(lastRow["UnappliedBalance"].ToString()));
            }

        }

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

        /*int Rows = Convert.ToInt32(hdnTotalRows.Value);
        long PracticeId = Profile.PracticeId;
        _DateFrom = Request.QueryString["DateFrom"];
        _DateTo = Request.QueryString["DateTo"];
        ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();
        DataSet dsReportData = objPatientReportsDB.GetUnappliedAnalysis(PracticeId, _DateFrom, _DateTo);
        rptUnappliedAnalysis.DataSource = dsReportData.Tables[0];
        rptUnappliedAnalysis.DataBind();*/
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=Unapplied-Analysis.xls");
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
        /*int Rows = Convert.ToInt32(hdnTotalRows.Value);
        long PracticeId = Profile.PracticeId;
        ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();
        _DateFrom = Request.QueryString["DateFrom"];
        _DateTo = Request.QueryString["DateTo"];
        DataSet dsReportData = objPatientReportsDB.GetUnappliedAnalysis(PracticeId, _DateFrom, _DateTo);
        rptUnappliedAnalysis.DataSource = dsReportData.Tables[0];
        rptUnappliedAnalysis.DataBind();*/
        Response.ContentType = "application/pdf";
        Response.AddHeader("content-disposition", "attachment;filename=Unapplied-Analysis.pdf");
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
        /*int Rows = Convert.ToInt32(hdnTotalRows.Value);
        long PracticeId = Profile.PracticeId;
        _DateFrom = Request.QueryString["DateFrom"];
        _DateTo = Request.QueryString["DateTo"];
        ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();
        DataSet dsReportData = objPatientReportsDB.GetUnappliedAnalysis(PracticeId, _DateFrom, _DateTo);
        rptUnappliedAnalysis.DataSource = dsReportData.Tables[0];
        rptUnappliedAnalysis.DataBind();*/

        Response.Clear();
        Response.AddHeader("content-disposition", "attachment;filename=Unapplied-Analysis.doc");
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
    protected void rptUnappliedAnalysis_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView drv = (DataRowView)e.Item.DataItem;
            int index = e.Item.ItemIndex;
            string amount = drv["Amt"].ToString();
            string ClaimId = drv["ClaimId"].ToString();
            Label lblClaimId = (Label)e.Item.FindControl("lblClaimId");
            if (ClaimId != "0")
            {
                lblClaimId.Text = ClaimId;
            }
            string UnappliedBalance = string.Format("{0:0,0.00}", Convert.ToDouble(drv["UnappliedBalance"].ToString()));
            Label lblAmt = (Label)e.Item.FindControl("lblAmt");
            if (amount != "")
            {
                if (amount.Contains("("))
                    lblAmt.Text = amount.Insert(1, "$");
                else
                    lblAmt.Text = "$" + amount;
            }
            Label lblUnappliedBalance = (Label)e.Item.FindControl("lblUnappliedBalance");
            if (UnappliedBalance != "")
                lblUnappliedBalance.Text = "$" + UnappliedBalance;

        }

    }
}