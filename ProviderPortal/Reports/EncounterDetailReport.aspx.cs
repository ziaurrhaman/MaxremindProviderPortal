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

public partial class ProviderPortal_Reports_EncounterDetailReport : System.Web.UI.Page
{
    string _DateTo = ""; string _DateFrom = "";
    string _TimeSpan = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();
        long PracticeId = Profile.PracticeId;
        string DateType = Request.Form["DateType"];
        _DateFrom = Request.Form["BillDateFrom"];
        _DateTo = Request.Form["BillDateTo"];
        string ProviderId = Request.Form["ProviderId"];
        string PracticeLocationId = Request.Form["PracticeLocationId"];
        string PayerId = Request.Form["PayerId"];
        string SubmissionStatusId = Request.Form["ddlSubmissionStatus"];


        hdnDateType.Value = Request.Form["DateType"];
        hdnProviderId.Value = Request.Form["ProviderId"];
        hdnPracticeLocationId.Value = Request.Form["PracticeLocationId"];
        hdnDateFrom.Value = Request.Form["BillDateFrom"];
        hdnDateTo.Value = Request.Form["BillDateTo"];
        hdnPayerId.Value = Request.Form["PayerId"];
        hdnSubmissionStatus.Value = SubmissionStatusId;
        DataSet dsReportData = objPatientReportsDB.GetEncounterDetail(PracticeId, 10, 0, "PostDate desc", DateType, SubmissionStatusId, _DateFrom, _DateTo, ProviderId, PracticeLocationId, PayerId);

        rptDenialsDetail.DataSource = dsReportData.Tables[0];
        rptDenialsDetail.DataBind();
        hdnTotalRows.Value = dsReportData.Tables[1].Rows[0]["TotalRows"].ToString();
        SetDatesObjects();
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
        _DateFrom = Request.Form["BillDateFrom"];
        _DateTo = Request.Form["BillDateTo"];

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
        string DateType = Request.Form["DateType"];
        _DateFrom = Request.Form["BillDateFrom"];
        _DateTo = Request.Form["BillDateTo"];
        string ProviderId = Request.Form["ProviderId"];
        string PracticeLocationId = Request.Form["PracticeLocationId"];
        string PayerId = Request.Form["PayerId"];
        string SubmissionStatusId = Request.Form["SubmissionStatusId"];

        hdnDateType.Value = Request.Form["DateType"];
        DataSet dsReportData = objPatientReportsDB.GetEncounterDetail(PracticeId, Rows, 0, "PostDate ASC", DateType, SubmissionStatusId, _DateFrom, _DateTo, ProviderId, PracticeLocationId, PayerId);
        rptDenialsDetail.DataSource = dsReportData.Tables[0];
        rptDenialsDetail.DataBind();
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=Encounter-Detail.xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        rptDenialsDetail.RenderControl(hw);
        Response.Output.Write(sw.ToString());
        Response.Flush();
        Response.End();
    }
    public void repeaterExportToPDF(object sender, EventArgs e)
    {
        int Rows = Convert.ToInt32(hdnTotalRows.Value);
        long PracticeId = Profile.PracticeId;
        ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();
        string DateType = Request.Form["DateType"];
        _DateFrom = Request.Form["BillDateFrom"];
        _DateTo = Request.Form["BillDateTo"];
        string ProviderId = Request.Form["ProviderId"];
        string PracticeLocationId = Request.Form["PracticeLocationId"];
        string Insurance = Request.Form["Insurance"];
        string PayerId = Request.Form["PayerId"];
        string SubmissionStatusId = Request.Form["SubmissionStatusId"];
        DataSet dsReportData = objPatientReportsDB.GetEncounterDetail(PracticeId, Rows, 0, "PostDate ASC", DateType, SubmissionStatusId, _DateFrom, _DateTo, ProviderId, PracticeLocationId, PayerId);
        Document document = new Document();
        Response.ContentType = "application/pdf"; Response.AddHeader("content-disposition", "attachment;filename=Encounter Details.pdf");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        PdfWriter.GetInstance(document, Response.OutputStream);
        document.Open();
        iTextSharp.text.Font font5 = iTextSharp.text.FontFactory.GetFont(FontFactory.HELVETICA, 8);

        PdfPTable table = new PdfPTable(dsReportData.Tables[0].Columns.Count);
        PdfPRow row = null;
        float[] widths = new float[] { 2f, 2f, 4f, 4f,4f,8f,4f,4f,4f,4f,4f,4f,4f };

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
        table.AddCell(new Phrase("Claim Id", font5));
        table.AddCell(new Phrase("Patient", font5));
        table.AddCell(new Phrase("Service Date", font5));
        table.AddCell(new Phrase("Render Provider", font5));
        table.AddCell(new Phrase("Procedure", font5));
        table.AddCell(new Phrase("Diag 1", font5));
        table.AddCell(new Phrase("Diag 2", font5));
        table.AddCell(new Phrase("Charges", font5));
        table.AddCell(new Phrase("Adjustment", font5));
        table.AddCell(new Phrase("Receipts", font5));
        table.AddCell(new Phrase("Balance", font5));

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
                table.AddCell(new Phrase(r[6].ToString(), font5));
                table.AddCell(new Phrase(r[7].ToString(), font5));
                table.AddCell(new Phrase( r[8].ToString(), font5));
                table.AddCell(new Phrase(r[9].ToString(), font5));
                table.AddCell(new Phrase(r[10].ToString(), font5));
                table.AddCell(new Phrase(r[11].ToString(), font5));
              
            }
        }


        document.Add(table);
        document.Close();
        Response.Write(document);
        Response.End();
        
       
    

    }
    public void repeaterExportToWord(object sender, EventArgs e)
    {
        int Rows = Convert.ToInt32(hdnTotalRows.Value);
        long PracticeId = Profile.PracticeId;
        ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();
        string DateType = Request.Form["DateType"];
        _DateFrom = Request.Form["BillDateFrom"];
        _DateTo = Request.Form["BillDateTo"];
        string ProviderId = Request.Form["ProviderId"];
        string PracticeLocationId = Request.Form["PracticeLocationId"];
        string PayerId = Request.Form["PayerId"];
        string SubmissionStatusId = Request.Form["SubmissionStatusId"];
        hdnDateType.Value = Request.Form["DateType"];
        DataSet dsReportData = objPatientReportsDB.GetEncounterDetail(PracticeId, Rows, 0, "PostDate ASC", DateType, SubmissionStatusId, _DateFrom, _DateTo, ProviderId, PracticeLocationId, PayerId);
        rptDenialsDetail.DataSource = dsReportData.Tables[0];
        rptDenialsDetail.DataBind();

        Response.Clear();
        Response.AddHeader("content-disposition", "attachment;filename=Encounter-Detail.doc");
        Response.Charset = "";
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = "application/vnd.word";
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
        rptDenialsDetail.RenderControl(htmlWrite);
        Response.Write(stringWrite.ToString());
        Response.End();
    }
    protected void rptDenialsDetail_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            //DataRowView drv = (DataRowView)e.Item.DataItem;
            //Label lblCharges = (Label)e.Item.FindControl("lblCharges");
            //Label lblDenied = (Label)e.Item.FindControl("lblDenied");

            //if (!string.IsNullOrEmpty(drv["Charges"].ToString()))
            //    lblCharges.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(drv["Charges"].ToString()));

            //if (!string.IsNullOrEmpty(drv["Denied"].ToString()))
            //    lblDenied.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(drv["Denied"].ToString()));
        }
    }
}