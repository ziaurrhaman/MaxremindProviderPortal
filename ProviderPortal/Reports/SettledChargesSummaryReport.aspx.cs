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

public partial class ProviderPortal_Reports_SettledChargesSummaryReport : System.Web.UI.Page
{
    string _DateFrom = "";
    string _DateTo = "";
    string _TimeSpan = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();
        long PracticeId = Profile.PracticeId;
        string TimeSpan = Request.Form["TimeSpan"];
        string Patient = Request.Form["PatientIds"];
        string ProviderId = Request.Form["ProviderId"];
        string PracticeLocationId = Request.Form["PracticeLocationId"];
        string ProcedureCode = Request.Form["ProcedureCode"];
        string DateFrom = Request.Form["DateFrom"];
        string DateTo = Request.Form["DateTo"];


  

        DataSet dsReportData = objPatientReportsDB.SetteledChargesSummary(PracticeId, DateFrom, DateTo, Patient, ProviderId, PracticeLocationId, ProcedureCode);

        Charges.Text = dsReportData.Tables[0].Rows[0]["TotalCharges"].ToString();
        TotalCharges.Text = dsReportData.Tables[0].Rows[0]["TotalCharges"].ToString();

        ContractualAdjustments.Text= dsReportData.Tables[0].Rows[0]["ContractualAdjustment"].ToString();
        SecondaryAdjustments.Text = dsReportData.Tables[0].Rows[0]["SecondAdjustment"].ToString();
        OtherAdjustments.Text = dsReportData.Tables[0].Rows[0]["OtherAdjustments"].ToString();
        TotalAdjustments.Text = dsReportData.Tables[0].Rows[0]["TotalAdjustment"].ToString();

        PatientPayments.Text = dsReportData.Tables[0].Rows[0]["PatientPayment"].ToString();
        InsurancePayments.Text = dsReportData.Tables[0].Rows[0]["InsurancePayments"].ToString();
        TotalPayments.Text = dsReportData.Tables[0].Rows[0]["TotalPayment"].ToString();


        if (TimeSpan == "SpecificDates")
        {
            lblReportTimeSpanFrom.Text=DateFrom+'-'+DateTo;
        }
        else
        {
            lblReportTimeSpanFrom.Text = TimeSpan;
        }
    }






    public void repeaterExportToPDF(object sender, EventArgs e)
    {
       
        string attachment = "attachment; filename=Settled Charges Summary.pdf";
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
        if (stw.ToString().Contains("<table style='width: 60%; font-size: 14px; margin-left: 3%;'>"))
        {
            result = Regex.Replace(stw.ToString(), @"<table style='width: 60%; font-size: 14px; margin-left: 3%;'>", "<table border='1' style='width: 60%; font-size: 14px; margin-left: 3%;'>");
            //result = Regex.Replace(result, @"<th>", "<th style='font-size:8px; font-weight:bold;'>");
            //result = Regex.Replace(result, @"<td>", "<td style='font-size:8px; font-weight:normal !important;'>");
        }
        StringReader str = new StringReader(result.ToString());
        HTMLWorker htmlworker = new HTMLWorker(document);
        htmlworker.Parse(str);
        document.Close();
        Response.Write(document);
        Response.End();

    }

    public void repeaterExportToDoc(object sender, EventArgs e)
    {


        Response.Clear();
        Response.AddHeader("content-disposition", "attachment;filename=Settled Charges Summary.doc");
        Response.Charset = "";
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = "application/vnd.word";
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
        divReportListing.RenderControl(htmlWrite);
        Response.Write(stringWrite.ToString());
        Response.End();

    }

    public void ExportToExcel(object sender, EventArgs e)
    {
        Response.Clear();
        Response.AddHeader("content-disposition", "attachment;filename=Settled Charges Summary.xls");
        Response.Charset = "";
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = "application/vnd.ms-excel";
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
        divReportListing.RenderControl(htmlWrite);
        Response.Write(stringWrite.ToString());
        Response.End();

    }
    protected void ddlExportTo_SelectedIndexChanged(object sender, EventArgs e)
    {
        Utility obj = new Utility();


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
            repeaterExportToDoc(sender, e);
        }
    }
}