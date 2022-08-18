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

public partial class ProviderPortal_Reports_PatientBalanceSummaryReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();
        long PracticeId = Profile.PracticeId;
  

        string AssignedTo = Request.Form["AssignedTo"];
        string DOB = Request.Form["AsOf"];

        string CustomDate = Request.Form["CustomDate"];
        hdnAssignedTo.Value = AssignedTo;
        hdnDOB.Value = DOB;
        hdnCustomDate.Value = CustomDate;
        if(CustomDate!=""){
            lblReportTimeSpanFrom.Text = CustomDate;
        }
        else
        {
            if (DOB != "") {
                lblReportTimeSpanFrom.Text = DOB;
            }
            else
            {
                lblReportTimeSpanFrom.Text = "All Records";
            }
        }
            
        DataSet dsReportData = objPatientReportsDB.GetTotalRowsPatientBalanceSummary(PracticeId, 10, 0, "PatientId ASC", AssignedTo, CustomDate, DOB);

        rptPatientBalanceSummary.DataSource = dsReportData.Tables[0];
        rptPatientBalanceSummary.DataBind();
        /*Control FooterTemplate = rptPatientBalanceSummary.Controls[rptPatientBalanceSummary.Controls.Count - 1].Controls[0];
        float TotalCharges = float.Parse(dtReportData.Compute("sum(charges)", string.Empty).ToString());
        Label lblTotalCharges = FooterTemplate.FindControl("lblTotalCharges") as Label;
        lblTotalCharges.Text = Convert.ToString(TotalCharges);

        float TotalAdjustments = float.Parse(dtReportData.Compute("sum(adjustments)", string.Empty).ToString());
        Label lblTotalAdjustments = FooterTemplate.FindControl("lblTotalAdjustments") as Label;
        lblTotalAdjustments.Text = Convert.ToString(TotalAdjustments);

        float TotalInsurancePayments = float.Parse(dtReportData.Compute("sum(Insurancepmt)", string.Empty).ToString());
        Label lblTotalInsurancePayments = FooterTemplate.FindControl("lblTotalInsurancePayments") as Label;
        lblTotalInsurancePayments.Text = Convert.ToString(TotalInsurancePayments);

        float TotalPatientPayments = float.Parse(dtReportData.Compute("sum(PatientPmt)", string.Empty).ToString());
        Label lblTotalPatientPayments = FooterTemplate.FindControl("lblTotalPatientPayments") as Label;
        lblTotalPatientPayments.Text = Convert.ToString(TotalPatientPayments);

        float TotalBalance = float.Parse(dtReportData.Compute("sum(TotalBalance)", string.Empty).ToString());
        Label lblTotalBalance = FooterTemplate.FindControl("lblTotalBalance") as Label;
        lblTotalBalance.Text = Convert.ToString(TotalBalance);

        float TotalPendingInsurance = float.Parse(dtReportData.Compute("sum(PendingIns)", string.Empty).ToString());
        Label lblPendingInsurance = FooterTemplate.FindControl("lblPendingInsurance") as Label;
        lblPendingInsurance.Text = Convert.ToString(TotalPendingInsurance);

        float TotalPatientBalance = float.Parse(dtReportData.Compute("sum(Patientbalance)", string.Empty).ToString());
        Label lblPatientBalance = FooterTemplate.FindControl("lblPatientBalance") as Label;
        lblPatientBalance.Text = Convert.ToString(TotalPatientBalance);*/

        hdnTotalRows.Value = dsReportData.Tables[1].Rows[0]["TotalRows"].ToString();

    }
    protected void repeaterExportToExcel(object sender, EventArgs e)
    {
        ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();

        long PracticeId = Profile.PracticeId;
        int Rows = Convert.ToInt32(hdnTotalRows.Value);
        string AssignedTo = Request.Form["AssignedTo"];
        string DOB = Request.Form["AsOf"];
        string CustomDate = Request.Form["CustomDate"];
        DataTable dtReportData = objPatientReportsDB.PatientBalanceSummary(PracticeId, Rows, 0, "PatientId ASC", AssignedTo, CustomDate, DOB);
        rptPatientBalanceSummary.DataSource = dtReportData;
        rptPatientBalanceSummary.DataBind();
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=Patient-Balance-Claims-List-Report.xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        rptPatientBalanceSummary.RenderControl(hw);
        Response.Output.Write(sw.ToString());
        Response.Flush();
        Response.End();
    }
    public void repeaterExportToPDF(object sender, EventArgs e)
    {
        ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();
        long PracticeId = Profile.PracticeId;
        int Rows = Convert.ToInt32(hdnTotalRows.Value);
        string AssignedTo = Request.Form["AssignedTo"];
        string DOB = Request.Form["AsOf"];
        string CustomDate = Request.Form["CustomDate"];
        DataTable dtReportData = objPatientReportsDB.PatientBalanceSummary(PracticeId, Rows, 0, "PatientId ASC", AssignedTo, CustomDate, DOB);

        rptPatientBalanceSummary.DataSource = dtReportData;
        rptPatientBalanceSummary.DataBind();
        Response.Clear();
        Response.ContentType = "application/pdf";
        Response.AddHeader("content-disposition", "attachment;filename=Patient-Balance-Summary.pdf");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        //rptPatientDetailGeneralInfo.DataBind();
        rptPatientBalanceSummary.RenderControl(hw);

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
        ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();
        long PracticeId = Profile.PracticeId;
        int Rows = Convert.ToInt32(hdnTotalRows.Value);
        string AssignedTo = Request.Form["AssignedTo"];
        string DOB = Request.Form["AsOf"];
        string CustomDate = Request.Form["CustomDate"];
        DataTable dtReportData = objPatientReportsDB.PatientBalanceSummary(PracticeId, Rows, 0, "PatientId ASC", AssignedTo, CustomDate, DOB);

        rptPatientBalanceSummary.DataSource = dtReportData;
        rptPatientBalanceSummary.DataBind();
        Response.Clear();
        Response.AddHeader("content-disposition", "attachment;filename=Patient-Balance-Summary.doc");
        Response.Charset = "";
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = "application/vnd.word";
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
        rptPatientBalanceSummary.RenderControl(htmlWrite);
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
            repeaterExportToExcel(sender, e);
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