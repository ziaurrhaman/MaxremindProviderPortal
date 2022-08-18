using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProviderPortal_Reports_ERAEOBListReport : System.Web.UI.Page
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
        string Insurance = Request.Form["InsuranceName"];
        string PaymentType = Request.Form["PaymentType"];
        string PaymentMethod = Request.Form["PaymentMethod"];
        _DateFrom = Request.Form["DateFrom"];
        _DateTo = Request.Form["DateTo"];
        hdnInsurance.Value = Request.Form["InsuranceName"];
        hdnPaymentType.Value = Request.Form["PaymentType"];
        hdnPaymentMethod.Value = Request.Form["PaymentMethod"];
        hdnDateFrom.Value = Request.Form["DateFrom"];
        hdnDateTo.Value = Request.Form["DateTo"];
        DataSet dsReportData = objPatientReportsDB.GetBySearchCriteria(PracticeId, 10, 0, "CheckIssueDate DESC", Insurance, PaymentType, PaymentMethod, _DateFrom, _DateTo);

        rptERAEOBList.DataSource = dsReportData.Tables[0];
        rptERAEOBList.DataBind();
        hdnTotalRows.Value = dsReportData.Tables[1].Rows[0]["TotalRows"].ToString();
        SetDatesObjects();

    }
    protected void ExportToExcel(object sender, EventArgs e)
    {

        int Rows = Convert.ToInt32(hdnTotalRows.Value);
        long PracticeId = Profile.PracticeId;
        ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();

        string Insurance = Request.Form["InsuranceName"];
        string PaymentType = Request.Form["PaymentType"];
        string PaymentMethod = Request.Form["PaymentMethod"];
        _DateFrom = Request.Form["DateFrom"];
        _DateTo = Request.Form["DateTo"];
        DataSet dsReportData = objPatientReportsDB.GetBySearchCriteria(PracticeId, Rows, 0, "PaymentType ASC", Insurance, PaymentType, PaymentMethod, _DateFrom, _DateTo);
        rptERAEOBList.DataSource = dsReportData.Tables[0];
        rptERAEOBList.DataBind();
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=ERA-EOB.xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        rptERAEOBList.RenderControl(hw);
        Response.Output.Write(sw.ToString());
        Response.Flush();
        Response.End();
    }
    public void repeaterExportToPDF(object sender, EventArgs e)
    {
        int Rows = Convert.ToInt32(hdnTotalRows.Value);
        long PracticeId = Profile.PracticeId;
        ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();
        string Insurance = Request.Form["InsuranceName"];
        string PaymentType = Request.Form["PaymentType"];
        string PaymentMethod = Request.Form["PaymentMethod"];
        _DateFrom = Request.Form["DateFrom"];
        _DateTo = Request.Form["DateTo"];
        DataSet dsReportData = objPatientReportsDB.GetBySearchCriteria(PracticeId, Rows, 0, "PaymentType ASC", Insurance, PaymentType, PaymentMethod, _DateFrom, _DateTo);

        Document document = new Document();
        Response.ContentType = "application/pdf"; Response.AddHeader("content-disposition", "attachment;filename=Encounter Details.pdf");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        PdfWriter.GetInstance(document, Response.OutputStream);
        document.Open();
        iTextSharp.text.Font font5 = iTextSharp.text.FontFactory.GetFont(FontFactory.HELVETICA, 8);

        PdfPTable table = new PdfPTable(dsReportData.Tables[0].Columns.Count);
        PdfPRow row = null;
        float[] widths = new float[] { 2f, 2f, 4f, 4f, 4f, 8f, 4f, 4f, 4f, 4f, 4f, 4f, 4f };

        // table.SetWidths(widths);

        table.WidthPercentage = 100;
        int iCol = 0;
        string colname = "";
        PdfPCell cell = new PdfPCell(new Phrase("Products"));

        cell.Colspan = dsReportData.Tables[0].Columns.Count;

        /*foreach (DataColumn c in dtReportData.Columns)
        {

            table.AddCell(new Phrase(c.ColumnName, font5));
        }*/
        table.AddCell(new Phrase("S.NO", font5));
        table.AddCell(new Phrase("Payment Type", font5));
        table.AddCell(new Phrase("Insurance", font5));
        table.AddCell(new Phrase("Payment Method", font5));
        table.AddCell(new Phrase("Check Number", font5));
        table.AddCell(new Phrase("Payment Date", font5));
        table.AddCell(new Phrase("Check Amount", font5));
        table.AddCell(new Phrase("Payment Posted", font5));
        table.AddCell(new Phrase("Un-applied Amount", font5));
      

        foreach (DataRow r in dsReportData.Tables[0].Rows)
        {
            if (dsReportData.Tables[0].Rows.Count > 0)
            {
                table.AddCell(new Phrase(r[0].ToString(), font5));
                table.AddCell(new Phrase(r[1].ToString(), font5));
                table.AddCell(new Phrase(r[2].ToString(), font5));
                table.AddCell(new Phrase(r[3].ToString(), font5));
                table.AddCell(new Phrase(r[4].ToString(), font5));
                table.AddCell(new Phrase(r[5].ToString(), font5));
                table.AddCell(new Phrase("$" + r[6].ToString(), font5));
                table.AddCell(new Phrase("$" + r[7].ToString(), font5));
                table.AddCell(new Phrase("$" + r[8].ToString(), font5));
               

            }
        }


        document.Add(table);
        document.Close();
        Response.Write(document);
        Response.End();
        
        
        //rptERAEOBList.DataSource = dsReportData.Tables[0];
        //rptERAEOBList.DataBind();
        //Response.ContentType = "application/pdf";
        //Response.AddHeader("content-disposition", "attachment;filename=ERA-EOB.pdf");
        //Response.Cache.SetCacheability(HttpCacheability.NoCache);
        //StringWriter sw = new StringWriter();
        //HtmlTextWriter hw = new HtmlTextWriter(sw);
        //rptERAEOBList.DataBind();
        //rptERAEOBList.RenderControl(hw);
        //StringReader sr = new StringReader(sw.ToString());
        //Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
        //HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
        //PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
        //pdfDoc.Open();
        //htmlparser.Parse(sr);
        //pdfDoc.Close();
        //Response.Write(pdfDoc);
        //Response.End();

    }
    public void repeaterExportToWord(object sender, EventArgs e)
    {
        int Rows = Convert.ToInt32(hdnTotalRows.Value);
        long PracticeId = Profile.PracticeId;
        ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();
        string Insurance = Request.Form["InsuranceName"];
        string PaymentType = Request.Form["PaymentType"];
        string PaymentMethod = Request.Form["PaymentMethod"];
        _DateFrom = Request.Form["DateFrom"];
        _DateTo = Request.Form["DateTo"];
        DataSet dsReportData = objPatientReportsDB.GetBySearchCriteria(PracticeId, Rows, 0, "PaymentType ASC", Insurance, PaymentType, PaymentMethod, _DateFrom, _DateTo);
        rptERAEOBList.DataSource = dsReportData.Tables[0];
        rptERAEOBList.DataBind();

        Response.Clear();
        Response.AddHeader("content-disposition", "attachment;filename=ERA-EOB.doc");
        Response.Charset = "";
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = "application/vnd.word";
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
        rptERAEOBList.RenderControl(htmlWrite);
        Response.Write(stringWrite.ToString());
        Response.End();
    }
    protected void ddlExportTo_SelectedIndexChanged(object sender, EventArgs e)
    {
        Utility obj = new Utility();

        string html = hdnReportHtml.Value;
        string exportTo = ddlExportTo.SelectedValue;

        if (exportTo == "Excel")
        {
            ExportToExcel(sender, e);
        }
        else if (exportTo == "PDF")
        {
            repeaterExportToPDF(sender, e);
        }
        else if (exportTo == "Word")
        {
            repeaterExportToWord(sender, e);
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
    protected void rptERAEOBList_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView drv = (DataRowView)e.Item.DataItem;
            Label lblPaymentAmount = (Label)e.Item.FindControl("lblPaymentAmount");
            Label lblPaymentPosted = (Label)e.Item.FindControl("lblPaymentPosted");
            Label lblUnapplied = (Label)e.Item.FindControl("lblUnapplied");

            if (!string.IsNullOrEmpty(drv["PaymentAmount"].ToString()))
                lblPaymentAmount.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(drv["PaymentAmount"].ToString()));
            if (!string.IsNullOrEmpty(drv["PaymentPosted"].ToString()))
                lblPaymentPosted.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(drv["PaymentPosted"].ToString()));
            if (!string.IsNullOrEmpty(drv["Unapplied"].ToString()))
                lblUnapplied.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(drv["Unapplied"].ToString()));
        }
    }
}