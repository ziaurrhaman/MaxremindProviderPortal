using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text.html;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.Text.RegularExpressions;
public partial class ProviderPortal_Reports_PatientContactList : System.Web.UI.Page
{
    string DiagnosisCode = ""; string Actuvity = ""; string ProviderId = ""; string ProcedureCode = "";
    string Gender = ""; string PayerId = ""; string DOB = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadReport();
    }
    private void LoadReport()
    {
         DiagnosisCode = Request.Form["DiagnosisCode"];
         Actuvity = Request.Form["Actuvity"];
         ProviderId = Request.Form["ProviderId"];
         ProcedureCode = Request.Form["ProcedureCode"];
         Gender = Request.Form["Gender"];
         PayerId = Request.Form["PayerId"];
         if (Actuvity != "")
         {
             DOB = "";
         }
         else
         {
             DOB = Request.Form["DOB"];
         }
         lblReportTimeSpanFrom.Text = Request.Form["TimeSpan"];
         hdnDiagnosisCode.Value = DiagnosisCode;
         hdnActuvity.Value = Actuvity;
         hdnProviderId.Value = ProviderId;
         hdnProcedureCode.Value = ProcedureCode;
         hdnGender.Value = Gender;
         hdnPayerId.Value = PayerId;
         hdnDOB.Value = DOB;


        ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();
        long PracticeId = Profile.PracticeId;
        DataSet dsReportData = objPatientReportsDB.PatientClaimsList(PracticeId, 10, 0, "PatientId desc",Actuvity,ProviderId,DiagnosisCode,ProcedureCode,Gender,PayerId,DOB);

        rptPatientClaimList.DataSource = dsReportData.Tables[0];
        rptPatientClaimList.DataBind();

        hdnTotalRows.Value = dsReportData.Tables[1].Rows[0]["TotalRows"].ToString();
    }
    protected void ExportToExcel(object sender, EventArgs e)
    {

        int Rows = Convert.ToInt32(hdnTotalRows.Value);
        long PracticeId = Profile.PracticeId;
        ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();
        DataSet dsPatientRoaster = objPatientReportsDB.PatientClaimsList(PracticeId, Rows, 0, "PatientId desc", Actuvity, ProviderId, DiagnosisCode, ProcedureCode, Gender, PayerId, DOB);
        rptPatientClaimList.DataSource = dsPatientRoaster.Tables[0];
        rptPatientClaimList.DataBind();
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=Patient-Claims-List-Report.xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        rptPatientClaimList.RenderControl(hw);
        Response.Output.Write(sw.ToString());
        Response.Flush();
        Response.End();
    }
    public void repeaterExportToPDF(object sender, EventArgs e)
    {
        int Rows = Convert.ToInt32(hdnTotalRows.Value);
        long PracticeId = Profile.PracticeId;
        ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();
        DataSet dsPatientRoaster = objPatientReportsDB.PatientClaimsList(PracticeId, Rows, 0, "PatientId desc", Actuvity, ProviderId, DiagnosisCode, ProcedureCode, Gender, PayerId, DOB);
        rptPatientClaimList.DataSource = dsPatientRoaster.Tables[0];
        rptPatientClaimList.DataBind();
        Response.ContentType = "application/pdf";
        Response.AddHeader("content-disposition", "attachment;filename=PatientContactList.pdf");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        rptPatientClaimList.DataBind();
        rptPatientClaimList.RenderControl(hw);
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
        DataSet dsPatientRoaster = objPatientReportsDB.PatientClaimsList(PracticeId, Rows, 0, "PatientId desc", Actuvity, ProviderId, DiagnosisCode, ProcedureCode, Gender, PayerId, DOB);
        rptPatientClaimList.DataSource = dsPatientRoaster.Tables[0];
        rptPatientClaimList.DataBind();

        Response.Clear();
        Response.AddHeader("content-disposition", "attachment;filename=Patient-Contact-List.doc");
        Response.Charset = "";
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = "application/vnd.word";
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
        rptPatientClaimList.RenderControl(htmlWrite);
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