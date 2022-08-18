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

public partial class ProviderPortal_Reports_UnpaidInsuranceClaimsReport : System.Web.UI.Page
{
    int Balance = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadReport();
    }
    private void LoadReport()
    {
        ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();
        long PracticeId = Profile.PracticeId;
        string PayerId = Request.Form["PayerId"];
        string ProviderId = Request.Form["ProviderId"];
        string PracticeLocationId = Request.Form["PracticeLocationId"];
        if (!string.IsNullOrEmpty(Request.Form["Balance"]))
            Balance = int.Parse(Request.Form["Balance"]);
        string DateOfService = Request.Form["DateOfService"];
        string BillDateFrom = Request.Form["BillDateFrom"];
        string BillDateTo = Request.Form["BillDateTo"];
        hdnPayerId.Value = Request.Form["PayerId"];
        hdnProviderId.Value = Request.Form["ProviderId"];
        hdnPracticeLocationId.Value = Request.Form["PracticeLocationId"];
        hdnBalance.Value = Request.Form["Balance"];
        hdnDateOfService.Value = Request.Form["DateOfService"];
        hdnBillDateFrom.Value = Request.Form["BillDateFrom"];
        hdnBillDateTo.Value = Request.Form["BillDateTo"];
        DataSet dsReportData = objPatientReportsDB.GetUnpaidInsuranceClaims(PracticeId, 10, 0, "Patient ASC", PayerId, ProviderId, PracticeLocationId, Balance, DateOfService, BillDateFrom, BillDateTo);

        rptUnpaidInsuranceClaims.DataSource = dsReportData.Tables[0];
        rptUnpaidInsuranceClaims.DataBind();
        hdnTotalRows.Value = dsReportData.Tables[1].Rows[0]["TotalRows"].ToString();


    }
    protected void ExportToExcel(object sender, EventArgs e)
    {

        int Rows = Convert.ToInt32(hdnTotalRows.Value);
        long PracticeId = Profile.PracticeId;
        ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();
        string PayerId = Request.Form["PayerId"];
        string ProviderId = Request.Form["ProviderId"];
        string PracticeLocationId = Request.Form["PracticeLocationId"];
        if (!string.IsNullOrEmpty(Request.Form["Balance"]))
            Balance = int.Parse(Request.Form["Balance"]);
        string DateOfService = Request.Form["DateOfService"];
        string BillDateFrom = Request.Form["hdnBillDateFrom"];
        string BillDateTo = Request.Form["BillDateTo"];
        DataSet dsReportData = objPatientReportsDB.GetUnpaidInsuranceClaims(PracticeId, Rows, 0, "Patient ASC", PayerId, ProviderId, PracticeLocationId, Balance, DateOfService, BillDateFrom, BillDateTo);
        rptUnpaidInsuranceClaims.DataSource = dsReportData.Tables[0];
        rptUnpaidInsuranceClaims.DataBind();
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=Unpaid-Insurance-Claims.xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        rptUnpaidInsuranceClaims.RenderControl(hw);
        Response.Output.Write(sw.ToString());
        Response.Flush();
        Response.End();
    }
    public void repeaterExportToPDF(object sender, EventArgs e)
    {
        int Rows = Convert.ToInt32(hdnTotalRows.Value);
        long PracticeId = Profile.PracticeId;
        ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();
        string PayerId = Request.Form["PayerId"];
        string ProviderId = Request.Form["ProviderId"];
        string PracticeLocationId = Request.Form["PracticeLocationId"];
        if (!string.IsNullOrEmpty(Request.Form["Balance"]))
            Balance = int.Parse(Request.Form["Balance"]);
        string DateOfService = Request.Form["DateOfService"];
        string BillDateFrom = Request.Form["hdnBillDateFrom"];
        string BillDateTo = Request.Form["BillDateTo"];
        DataSet dsReportData = objPatientReportsDB.GetUnpaidInsuranceClaims(PracticeId, Rows, 0, "Patient ASC", PayerId, ProviderId, PracticeLocationId, Balance, DateOfService, BillDateFrom, BillDateTo);
        rptUnpaidInsuranceClaims.DataSource = dsReportData.Tables[0];
        rptUnpaidInsuranceClaims.DataBind();
        Response.ContentType = "application/pdf";
        Response.AddHeader("content-disposition", "attachment;filename=Unpaid-Insurance-Claims.pdf");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        rptUnpaidInsuranceClaims.DataBind();
        rptUnpaidInsuranceClaims.RenderControl(hw);
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
        iTextSharp.text.Font font5 = iTextSharp.text.FontFactory.GetFont(FontFactory.HELVETICA, 7);
        PdfPTable table = new PdfPTable(dsReportData.Tables[0].Columns.Count);
        PdfPRow row = null;
        float[] widths = new float[] { 2f, 5f, 5f, 2f, 2f, 3f, 2f, 4f, 3f, 3f, 3f, 3f, 3f };
        //table.SetWidths(widths);
        table.WidthPercentage = 100;
        PdfPCell cell = new PdfPCell(new Phrase("Products"));
        cell.Colspan = dsReportData.Tables[0].Columns.Count;
        table.AddCell(new Phrase("S.NO", font5));
        table.AddCell(new Phrase("Insurance", font5));
        table.AddCell(new Phrase("Patient", font5));
        table.AddCell(new Phrase("Encounter", font5));
        table.AddCell(new Phrase("Billing Date", font5));
        table.AddCell(new Phrase("Service Date", font5));
        table.AddCell(new Phrase("Procedure", font5));
        table.AddCell(new Phrase("Diag1", font5));
        table.AddCell(new Phrase("Diag2", font5));
        table.AddCell(new Phrase("Charges", font5));
        

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
              
                if (r[2].ToString() != "" && r[3].ToString() == "")
                {
                    table.AddCell(new Phrase("Total :", font5));
                }
                else if (r[2].ToString() == "" && r[3].ToString() == "")
                {
                    table.AddCell(new Phrase("Grand Total :", font5));
                }
                else
                {
                    table.AddCell(new Phrase(r[7].ToString(), font5));
                }
                if (r[8].ToString() != "")
                {
                    table.AddCell(new Phrase(r[8].ToString(), font5));
                }
                else
                {
                    table.AddCell(new Phrase("$0.00", font5));
                }

                if (r[9].ToString() != "")
                {
                    table.AddCell(new Phrase(r[9].ToString(), font5));
                }
                else
                {
                    table.AddCell(new Phrase("$0.00", font5));
                }
            }
        }
        /***************end footer***********/


      


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
        string PayerId = Request.Form["PayerId"];
        string ProviderId = Request.Form["ProviderId"];
        string PracticeLocationId = Request.Form["PracticeLocationId"];
        if (!string.IsNullOrEmpty(Request.Form["Balance"]))
            Balance = int.Parse(Request.Form["Balance"]);
        string DateOfService = Request.Form["DateOfService"];
        string BillDateFrom = Request.Form["hdnBillDateFrom"];
        string BillDateTo = Request.Form["BillDateTo"];
        DataSet dsReportData = objPatientReportsDB.GetUnpaidInsuranceClaims(PracticeId, Rows, 0, "Patient ASC", PayerId, ProviderId, PracticeLocationId, Balance, DateOfService, BillDateFrom, BillDateTo);
        rptUnpaidInsuranceClaims.DataSource = dsReportData.Tables[0];
        rptUnpaidInsuranceClaims.DataBind();

        Response.Clear();
        Response.AddHeader("content-disposition", "attachment;filename=Unpaid-Insurance-Claims.doc");
        Response.Charset = "";
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = "application/vnd.word";
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
        rptUnpaidInsuranceClaims.RenderControl(htmlWrite);
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
    protected void rptUnpaidInsuranceClaims_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView drv = (DataRowView)e.Item.DataItem;
            Label lblProcedures = (Label)e.Item.FindControl("lblProcedures");
            Label lblCharges = (Label)e.Item.FindControl("lblCharges");
            Label lblAdjust = (Label)e.Item.FindControl("lblAdjust");
            Label lblReceipts = (Label)e.Item.FindControl("lblBalance");
            Label lblBalance = (Label)e.Item.FindControl("lblBalance");
            if (!string.IsNullOrEmpty(drv["Patient"].ToString()) && string.IsNullOrEmpty(drv["Encounter"].ToString()))
            {
                lblProcedures.Style.Add("font-weight", "bold");
                lblProcedures.Style.Add("float", "left");
                lblProcedures.Text = "Total : ";
            }
            else if (string.IsNullOrEmpty(drv["Patient"].ToString()) && string.IsNullOrEmpty(drv["Encounter"].ToString()))
            {
                lblProcedures.Style.Add("font-weight", "bold");
                lblProcedures.Style.Add("float", "left");
                lblProcedures.Text = "Grand Total : ";
            }
            else
            {
                lblProcedures.Text = drv["Procedures"].ToString();
            }
            if (!string.IsNullOrEmpty(drv["Charges"].ToString()))
                lblCharges.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(drv["Charges"].ToString()));

            //if (!string.IsNullOrEmpty(drv["Adjust"].ToString()))
            //    lblAdjust.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(drv["Adjust"].ToString()));

            //if (!string.IsNullOrEmpty(drv["Receipts"].ToString()))
            //    lblReceipts.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(drv["Receipts"].ToString()));

            //if (!string.IsNullOrEmpty(drv["Balance"].ToString()))
            //    lblBalance.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(drv["Balance"].ToString()));
        }
    }
}