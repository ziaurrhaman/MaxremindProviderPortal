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
using System.Text.RegularExpressions;

public partial class EMR_Reports_ClaimsSubmissionStatusSummary : System.Web.UI.Page
{
    string _DateTo = ""; string _DateFrom = "";
    string _TimeSpan = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadDropDowns();
        LoadReport();
    }

    private void LoadDropDowns()
    {
        ReportsFinancialDB objDB = new ReportsFinancialDB();

        DataSet dsFilterData = objDB.LoadFilterDropDowns_ClaimSubmissionStatusSummary(Profile.PracticeId);

        DataTable dtLocations = dsFilterData.Tables[0];

        ddlPracticeLocations.DataSource = dtLocations;
        ddlPracticeLocations.DataValueField = "PracticeLocationsId";
        ddlPracticeLocations.DataTextField = "Name";
        ddlPracticeLocations.DataBind();
    }

    private void LoadReport()
    {
        ReportsFinancialDB objDB = new ReportsFinancialDB();

        DataSet dsReportData = objDB.ClaimSubmissionStatusSummary(Profile.PracticeId, Profile.PracticeLocationsId, 10, 0, "InsuranceName ASC");

        rptReportData.DataSource = dsReportData.Tables[0];
        rptReportData.DataBind();

        //hdnTotalRows.Value = dsReportData.Tables[1].Rows[0]["TotalRows"].ToString();
        hdnTotalRows.Value = dsReportData.Tables[1].Rows.Count.ToString();
    }

    protected void ddlExportTo_SelectedIndexChanged(object sender, EventArgs e)
    {
        Utility obj = new Utility();

        string html = hdnReportHtml.Value;
        string exportTo = ddlExportTo.SelectedValue;

        string FileName = "Patient Encounter Details";

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

    protected void ExportToExcel(object sender, EventArgs e)
    {

        int Rows = Convert.ToInt32(hdnTotalRows.Value);
        long PracticeId = Profile.PracticeId;
        ReportsFinancialDB objDB = new ReportsFinancialDB();
        string DateType = Request.QueryString["DateType"];
        _DateFrom = Request.QueryString["BillDateFrom"];
        _DateTo = Request.QueryString["BillDateTo"];
        string ProviderId = Request.QueryString["ProviderId"];
        string PracticeLocationId = Request.QueryString["PracticeLocationId"];
        string PayerId = Request.QueryString["PayerId"];
        string SubmissionStatusId = Request.QueryString["SubmissionStatusId"];
        DataSet dsReportData = objDB.ClaimSubmissionStatusSummary(Profile.PracticeId, Profile.PracticeLocationsId, Rows, 0, "InsuranceName ASC");
        rptReportData.DataSource = dsReportData.Tables[0];
        rptReportData.DataBind();
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=Encounter-Detail.xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        rptReportData.RenderControl(hw);
        Response.Output.Write(sw.ToString());
        Response.Flush();
        Response.End();
    }
    public void repeaterExportToPDF(object sender, EventArgs e)
    {
        int Rows = Convert.ToInt32(hdnTotalRows.Value);
        long PracticeId = Profile.PracticeId;
        ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();
        //  string PatientId = hdnPatientId.Value;
        _DateFrom = Request.QueryString["DateFrom"];
        _DateTo = Request.QueryString["DateTo"];
        ReportsFinancialDB objDB = new ReportsFinancialDB();

        DataSet dsReportData = objDB.ClaimSubmissionStatusSummary(Profile.PracticeId, Profile.PracticeLocationsId, Rows, 0, "InsuranceName ASC");
        rptReportData.DataSource = dsReportData.Tables[0];
        rptReportData.DataBind();
        Response.ContentType = "application/pdf";
        Response.AddHeader("content-disposition", "attachment;filename=Claim Submission Status Summary.pdf");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        rptReportData.DataBind();
        rptReportData.RenderControl(hw);
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
        ReportsFinancialDB objDB = new ReportsFinancialDB();
        string DateType = Request.QueryString["DateType"];
        _DateFrom = Request.QueryString["BillDateFrom"];
        _DateTo = Request.QueryString["BillDateTo"];
        string ProviderId = Request.QueryString["ProviderId"];
        string PracticeLocationId = Request.QueryString["PracticeLocationId"];
        string PayerId = Request.QueryString["PayerId"];
        string SubmissionStatusId = Request.QueryString["SubmissionStatusId"];
        // hdnDateType.Value = Request.QueryString["DateType"];
        DataSet dsReportData = objDB.ClaimSubmissionStatusSummary(Profile.PracticeId, Profile.PracticeLocationsId, Rows, 0, "InsuranceName ASC");
        rptReportData.DataSource = dsReportData.Tables[0];
        rptReportData.DataBind();

        Response.Clear();
        Response.AddHeader("content-disposition", "attachment;filename=Encounter-Detail.doc");
        Response.Charset = "";
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = "application/vnd.word";
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
        rptReportData.RenderControl(htmlWrite);
        Response.Write(stringWrite.ToString());
        Response.End();
    }


}