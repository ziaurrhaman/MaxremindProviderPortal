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

public partial class EMR_Reports_Report : System.Web.UI.Page
{
    ERAMasterDB objERAMasterDB = new ERAMasterDB();
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadReport();
    }
    private void LoadReport()
    {
        long PracticeId = Profile.PracticeId;
        DataSet dsReportData = objERAMasterDB.Report_PatientPayments(PracticeId, 10, 0, "PatientId ASC");

        rptReportData.DataSource = dsReportData.Tables[0];
        rptReportData.DataBind();

        hdnTotalRows.Value = dsReportData.Tables[1].Rows[0]["TotalRows"].ToString();
    }
    protected void ExportToExcel(object sender, EventArgs e)
    {

        int Rows = Convert.ToInt32(hdnTotalRows.Value);
        long PracticeId = Profile.PracticeId;
        DataSet dsReportData = objERAMasterDB.Report_PatientPayments(PracticeId, Rows, 0, "PatientId ASC");
        rptReportData.DataSource = dsReportData.Tables[0];
        rptReportData.DataBind();
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=Patient-Payments.xls");
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
        DataSet dsReportData = objERAMasterDB.Report_PatientPayments(PracticeId, Rows, 0, "PatientId ASC");
        rptReportData.DataSource = dsReportData.Tables[0];
        rptReportData.DataBind();
        Response.ContentType = "application/pdf";
        Response.AddHeader("content-disposition", "attachment;filename=Patient-Payments.pdf");
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
        DataSet dsReportData = objERAMasterDB.Report_PatientPayments(PracticeId, Rows, 0, "PatientId ASC");
        rptReportData.DataSource = dsReportData.Tables[0];
        rptReportData.DataBind();

        Response.Clear();
        Response.AddHeader("content-disposition", "attachment;filename=Adjustments-Detail.doc");
        Response.Charset = "";
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = "application/vnd.word";
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
        rptReportData.RenderControl(htmlWrite);
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