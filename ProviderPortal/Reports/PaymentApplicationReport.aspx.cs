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
 
public partial class ProviderPortal_Reports_PaymentApplicationReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadReport();
    }
    private void LoadReport()
    {
        ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();
        long PracticeId = Profile.PracticeId;
        string payerName = Request.Form["payerName"];
        string checkNumber = Request.Form["checkNumber"];
        string postDate = Request.Form["postDate"];
        hdnPayerName.Value = Request.Form["payerName"];
        hdnCheckNumber.Value = Request.Form["checkNumber"];
        hdnPostDate.Value = Request.Form["postDate"];

        DataSet dsReportData = objPatientReportsDB.GetPaymentApplication(PracticeId, 10, 0, "", payerName, checkNumber, postDate);

        rptPaymentApplication.DataSource = dsReportData.Tables[0];
        rptPaymentApplication.DataBind();
        hdnTotalRows.Value = dsReportData.Tables[1].Rows[0]["TotalRows"].ToString();

    }
    protected void ExportToExcel(object sender, EventArgs e)
    {

        int Rows = Convert.ToInt32(hdnTotalRows.Value);
        long PracticeId = Profile.PracticeId;
        string payerName = Request.Form["payerName"];
        string checkNumber = Request.Form["checkNumber"];
        string postDate = Request.Form["postDate"];
        ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();
        DataSet dsReportData = objPatientReportsDB.GetPaymentApplication(PracticeId, Rows, 0, "", payerName, checkNumber, postDate);
        rptPaymentApplication.DataSource = dsReportData.Tables[0];
        rptPaymentApplication.DataBind();
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=Payment-Application.xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        rptPaymentApplication.RenderControl(hw);
        Response.Output.Write(sw.ToString());
        Response.Flush();
        Response.End();
    }
    public void repeaterExportToPDF(object sender, EventArgs e)
    {
        int Rows = Convert.ToInt32(hdnTotalRows.Value);
        long PracticeId = Profile.PracticeId;
        string payerName = Request.Form["payerName"];
        string checkNumber = Request.Form["checkNumber"];
        string postDate = Request.Form["postDate"];
        ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();
        DataSet dsReportData = objPatientReportsDB.GetPaymentApplication(PracticeId, Rows, 0, "", payerName, checkNumber, postDate);
        DataTable dtReportData = dsReportData.Tables[0];
        Document document = new Document();
        Response.ContentType = "application/pdf";
        Response.AddHeader("content-disposition", "attachment;filename=Payment-Application.pdf");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        PdfWriter.GetInstance(document, Response.OutputStream);
        document.Open();
        iTextSharp.text.Font font5 = iTextSharp.text.FontFactory.GetFont(FontFactory.HELVETICA, 7);
        PdfPTable table = new PdfPTable(dtReportData.Columns.Count);
        PdfPRow row = null;
        float[] widths = new float[] { 2f, 5f, 5f, 2f, 2f, 3f, 2f, 4f, 3f, 3f, 3f, 3f, 3f };
        table.SetWidths(widths);
        table.WidthPercentage = 100;
        PdfPCell cell = new PdfPCell(new Phrase("Products"));
        cell.Colspan = dtReportData.Columns.Count;
        table.AddCell(new Phrase("S.NO", font5));
        table.AddCell(new Phrase("Check Number", font5));
        table.AddCell(new Phrase("Patient Name", font5));
        table.AddCell(new Phrase("Patient Id", font5));
        table.AddCell(new Phrase("Claim Id", font5));
        table.AddCell(new Phrase("Service Date", font5));
        table.AddCell(new Phrase("Procedure Code", font5));
        table.AddCell(new Phrase("Post Date", font5));
        table.AddCell(new Phrase("Orig Charge", font5));
        table.AddCell(new Phrase("Balance Forward", font5));
        table.AddCell(new Phrase("Adjustment", font5));
        table.AddCell(new Phrase("Payment", font5));
        table.AddCell(new Phrase("Balance", font5));




        foreach (DataRow r in dtReportData.Rows)
        {
            if (dtReportData.Rows.Count > 0)
            {
                table.AddCell(new Phrase(r[0].ToString(), font5));
                table.AddCell(new Phrase(r[1].ToString(), font5));
                table.AddCell(new Phrase(r[2].ToString(), font5));
                table.AddCell(new Phrase(r[3].ToString(), font5));
                table.AddCell(new Phrase(r[4].ToString(), font5));
                table.AddCell(new Phrase(r[5].ToString(), font5));
                table.AddCell(new Phrase(r[6].ToString(), font5));
                if (r[1].ToString() != "" && r[3].ToString() == "")
                {
                    table.AddCell(new Phrase("Check Number's Grand Total :", font5));
                }
                else if (r[3].ToString() != "" && r[4].ToString() == "")
                {
                    table.AddCell(new Phrase("Sub Total :", font5));
                }
                else if (r[1].ToString() == "")
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
                if (r[10].ToString() != "")
                {
                    table.AddCell(new Phrase(r[10].ToString(), font5));
                }
                else
                {
                    table.AddCell(new Phrase("$0.00", font5));
                }
                if (r[11].ToString() != "")
                {
                    table.AddCell(new Phrase(r[11].ToString(), font5));
                }
                else
                {
                    table.AddCell(new Phrase("$0.00", font5));
                }
                if (r[12].ToString() != "")
                {
                    table.AddCell(new Phrase(r[12].ToString(), font5));
                }
                else
                {
                    table.AddCell(new Phrase("$0.00", font5));
                }
            }
        }
        /***************end footer***********/
        document.Add(table);
        document.Close();
        Response.Write(document);
        Response.End();

    }
    public void repeaterExportToWord(object sender, EventArgs e)
    {
        int Rows = Convert.ToInt32(hdnTotalRows.Value);
        long PracticeId = Profile.PracticeId;
        string payerName = Request.Form["payerName"];
        string checkNumber = Request.Form["checkNumber"];
        string postDate = Request.Form["postDate"];
        ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();
        DataSet dsReportData = objPatientReportsDB.GetPaymentApplication(PracticeId, Rows, 0, "", payerName, checkNumber, postDate);
        rptPaymentApplication.DataSource = dsReportData.Tables[0];
        rptPaymentApplication.DataBind();

        Response.Clear();
        Response.AddHeader("content-disposition", "attachment;filename=Payment-Application.doc");
        Response.Charset = "";
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = "application/vnd.word";
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
        rptPaymentApplication.RenderControl(htmlWrite);
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
    protected void rptPaymentApplication_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView drv = (DataRowView)e.Item.DataItem;
            string Patientid = drv["Patientid"].ToString();
            string CheckNumber = drv["CheckNumber"].ToString();
            string ClaimId = drv["ClaimId"].ToString();
            string PostDate = drv["PostDate"].ToString();
            Label lblPostDate = (Label)e.Item.FindControl("lblPostDate");
            //Label lblSubTotal = (Label)e.Item.FindControl("lblSubTotal");
            //Label lblChkGrandTotal = (Label)e.Item.FindControl("lblChkGrandTotal");
            //Label lblGrandTotal = (Label)e.Item.FindControl("lblGrandTotal");
            if (Patientid == "" && CheckNumber != "")
            {
                lblPostDate.Text = "Check Number's Grand Total :";
            }
            else if (Patientid != "" && ClaimId == "")
            {
                lblPostDate.Text = "Sub Total :";
            }
            else if (CheckNumber == "")
            {
                lblPostDate.Text = "Grand Total :";
            }
            else
            {
                lblPostDate.Text = PostDate;
            }
        }
    }
}