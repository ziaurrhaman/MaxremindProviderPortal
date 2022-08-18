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

public partial class ProviderPortal_Reports_AdjustmentsDetailReport : System.Web.UI.Page
{
    string _DateFrom = "";
    string _DateTo = "";
    string _TimeSpan = ""; string DateType; string ProviderId;
    string PracticeLocationId; string PayerId; string AdjustmentCode;
    string PatientId; string ProcedureCode;
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadReport();
    }
    private void LoadReport()
    {
        ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();
        long PracticeId = Profile.PracticeId;
        _DateFrom = Request.Form["BillDateFrom"];
        _DateTo = Request.Form["BillDateTo"];

        DateType = Request.Form["DateType"];
        ProviderId = Request.Form["ProviderId"];
        PracticeLocationId = Request.Form["PracticeLocationId"];
        PayerId = Request.Form["PayerId"];
        AdjustmentCode = Request.Form["AdjustmentCode"];
         if (AdjustmentCode == null)
         {
             AdjustmentCode = "";
         }
         else
         {
             AdjustmentCode = Request.Form["AdjustmentCode"];
         }
         PatientId = Request.Form["PatientIds"];
         hdnPatient.Value = PatientId;
         ProcedureCode = Request.Form["ProcedureCode"];

         hdnProviderId.Value = ProviderId;
         hdnPracticeLocationId.Value = PracticeLocationId;
         hdnPayerId.Value = PayerId;
         hdnAdjustmentCode.Value = AdjustmentCode;
         hdnProcedureCode.Value = ProcedureCode;
         hdnDateFrom.Value = _DateFrom;
         hdnDateTo.Value = _DateTo;
         hdnDateType.Value = DateType;

         DataSet dsReportData = objPatientReportsDB.AdjustmentsDetail(PracticeId, 10, 0, "PostDate DESC", DateType, ProviderId, PracticeLocationId, PayerId, AdjustmentCode, ProcedureCode, PatientId, _DateFrom, _DateTo);

        rptAdjustmentsDetail.DataSource = dsReportData.Tables[0];
        rptAdjustmentsDetail.DataBind();

        hdnTotalRows.Value = dsReportData.Tables[1].Rows[0]["TotalRows"].ToString();
        SetDatesObjects();
    }
    private void SetDatesObjects()
    {

        _TimeSpan = Request.Form["TimeSpan"];
        _DateFrom = Request.Form["BillDateFrom"];
        _DateTo = Request.Form["BillDateTo"];

        hdnTimeSpan.Value = _TimeSpan;
        hdnDateFrom.Value = _DateFrom;
        hdnDateTo.Value = _DateTo;

        if (_DateFrom != "")
        {
            _TimeSpan = "";
        }
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
        ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();
        int Rows = Convert.ToInt32(hdnTotalRows.Value);
        long PracticeId = Profile.PracticeId;
        _DateFrom = Request.Form["BillDateFrom"];
        _DateTo = Request.Form["BillDateTo"];

        DateType = Request.Form["DateType"];
        ProviderId = Request.Form["ProviderId"];
        PracticeLocationId = Request.Form["PracticeLocationId"];
        PayerId = Request.Form["PayerId"];
        AdjustmentCode = Request.Form["AdjustmentCode"];
        if (AdjustmentCode == null)
        {
            AdjustmentCode = "";
        }
        else
        {
            AdjustmentCode = Request.Form["AdjustmentCode"];
        }

        PatientId = Request.Form["PatientIds"];
        DataSet dsReportData = objPatientReportsDB.AdjustmentsDetail(PracticeId, Rows, 0, "PatientId ASC", DateType, ProviderId, PracticeLocationId, PayerId, AdjustmentCode, ProcedureCode, PatientId, _DateFrom, _DateTo);
        rptAdjustmentsDetail.DataSource = dsReportData.Tables[0];
        rptAdjustmentsDetail.DataBind();
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=Adjustments-Detail.xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        rptAdjustmentsDetail.RenderControl(hw);
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
        DataSet dsReportData = objPatientReportsDB.AdjustmentsDetail(PracticeId, Rows, 0, "PatientId ASC", "", "", "", "", "", "", "", "", "");
        rptAdjustmentsDetail.DataSource = dsReportData.Tables[0];
        rptAdjustmentsDetail.DataBind();
        Response.ContentType = "application/pdf";
        Response.AddHeader("content-disposition", "attachment;filename=Adjustments-Detail.pdf");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        rptAdjustmentsDetail.DataBind();
        rptAdjustmentsDetail.RenderControl(hw);
        string result = "";
        if (sw.ToString().Contains("<table class='clsborder'>"))
        {
            result = Regex.Replace(sw.ToString(), @"<table class='clsborder'>", "<table class='clsborder' border='1'>");
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
        int Rows = Convert.ToInt32(hdnTotalRows.Value);
        long PracticeId = Profile.PracticeId;
        ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();
        _DateFrom = Request.Form["BillDateFrom"];
        _DateTo = Request.Form["BillDateTo"];

        DateType = Request.Form["DateType"];
        ProviderId = Request.Form["ProviderId"];
        PracticeLocationId = Request.Form["PracticeLocationId"];
        PayerId = Request.Form["PayerId"];
        AdjustmentCode = Request.Form["AdjustmentCode"];
        if (AdjustmentCode == null)
        {
            AdjustmentCode = "";
        }
        else
        {
            AdjustmentCode = Request.Form["AdjustmentCode"];
        }

        PatientId = Request.Form["PatientIds"];
        DataSet dsReportData = objPatientReportsDB.AdjustmentsDetail(PracticeId, Rows, 0, "PatientId ASC", DateType, ProviderId, PracticeLocationId, PayerId, AdjustmentCode, ProcedureCode, PatientId, _DateFrom, _DateTo);
        rptAdjustmentsDetail.DataSource = dsReportData.Tables[0];
        rptAdjustmentsDetail.DataBind();

        Response.Clear();
        Response.AddHeader("content-disposition", "attachment;filename=Adjustments-Detail.doc");
        Response.Charset = "";
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = "application/vnd.word";
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
        rptAdjustmentsDetail.RenderControl(htmlWrite);
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
}