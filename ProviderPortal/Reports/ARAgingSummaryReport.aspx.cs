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

public partial class ProviderPortal_Reports_ARAgingSummaryReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadReport();
    }
    private void LoadReport()
    {
        ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();
        long PracticeId = Profile.PracticeId;
        string AgingDate = Request.Form["AgingDate"];
        string AgingType = Request.Form["AgingType"];
        string PracticeLocationId = Request.Form["PracticeLocationId"];
        string ProviderId = Request.Form["ProviderId"];
        string PayerId = Request.Form["PayerId"];
        hdnAgingDate.Value = Request.Form["AgingDate"];
        hdnAgingType.Value = Request.Form["AgingType"];
        hdnPracticeLocationId.Value = Request.Form["PracticeLocationId"];
        hdnAgingType.Value = Request.Form["ProviderId"];
        hdnPayerId.Value = Request.Form["PayerId"];
        DataSet dsReportData = objPatientReportsDB.GetARAgingSummary(PracticeId, AgingType, AgingDate, PracticeLocationId, ProviderId, PayerId);

        rptARAgingSummary.DataSource = dsReportData.Tables[0];
        rptARAgingSummary.DataBind();
        //hdnTotalRows.Value = dsReportData.Tables[1].Rows[0]["TotalRows"].ToString();


    }
    protected void ExportToExcel(object sender, EventArgs e)
    {

        //int Rows = Convert.ToInt32(hdnTotalRows.Value);
        long PracticeId = Profile.PracticeId;
        ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();
        string AgingDate = Request.Form["AgingDate"];
        string AgingType = Request.Form["AgingType"];
        string PracticeLocationId = Request.Form["PracticeLocationId"];
        string ProviderId = Request.Form["ProviderId"];
        string PayerId = Request.Form["PayerId"];
        DataSet dsReportData = objPatientReportsDB.GetARAgingSummary(PracticeId, AgingType, AgingDate, PracticeLocationId, ProviderId, PayerId);
        rptARAgingSummary.DataSource = dsReportData.Tables[0];
        rptARAgingSummary.DataBind();
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=A/R-Aging-Summary.xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        rptARAgingSummary.RenderControl(hw);
        Response.Output.Write(sw.ToString());
        Response.Flush();
        Response.End();
    }
    public void repeaterExportToPDF(object sender, EventArgs e)
    {
        //int Rows = Convert.ToInt32(hdnTotalRows.Value);
        long PracticeId = Profile.PracticeId;
        ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();
        string AgingDate = Request.Form["AgingDate"];
        string AgingType = Request.Form["AgingType"];
        string PracticeLocationId = Request.Form["PracticeLocationId"];
        string ProviderId = Request.Form["ProviderId"];
        string PayerId = Request.Form["PayerId"];
        DataSet dsReportData = objPatientReportsDB.GetARAgingSummary(PracticeId, AgingType, AgingDate, PracticeLocationId, ProviderId, PayerId);
        rptARAgingSummary.DataSource = dsReportData.Tables[0];
        rptARAgingSummary.DataBind();
        Response.ContentType = "application/pdf";
        Response.AddHeader("content-disposition", "attachment;filename=A/R-Aging-Summary.pdf");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        rptARAgingSummary.DataBind();
        rptARAgingSummary.RenderControl(hw);
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
        //int Rows = Convert.ToInt32(hdnTotalRows.Value);
        long PracticeId = Profile.PracticeId;
        ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();
        string AgingDate = Request.Form["AgingDate"];
        string AgingType = Request.Form["AgingType"];
        string PracticeLocationId = Request.Form["PracticeLocationId"];
        string ProviderId = Request.Form["ProviderId"];
        string PayerId = Request.Form["PayerId"];
        DataSet dsReportData = objPatientReportsDB.GetARAgingSummary(PracticeId, AgingType, AgingDate, PracticeLocationId, ProviderId, PayerId);
        rptARAgingSummary.DataSource = dsReportData.Tables[0];
        rptARAgingSummary.DataBind();

        Response.Clear();
        Response.AddHeader("content-disposition", "attachment;filename=A/R-Aging-Summary.doc");
        Response.Charset = "";
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = "application/vnd.word";
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
        rptARAgingSummary.RenderControl(htmlWrite);
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
    protected void rptARAgingSummary_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {

        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView drv = (DataRowView)e.Item.DataItem;

            string Payer = drv["Payer"].ToString();
            Label lblPayer = (Label)e.Item.FindControl("lblPayer");
            Label lblPecentage = (Label)e.Item.FindControl("lblPecentage");
            Label lblUnbilled = (Label)e.Item.FindControl("lblUnbilled");
            Label lblCurrent = (Label)e.Item.FindControl("lblCurrent");
            Label lbl3160 = (Label)e.Item.FindControl("lbl3160");
            Label lbl6190 = (Label)e.Item.FindControl("lbl6190");
            Label lbl91120 = (Label)e.Item.FindControl("lbl91120");
            Label lbl120 = (Label)e.Item.FindControl("lbl120");
            Label lblTotalBal = (Label)e.Item.FindControl("lblTotalBal");
            if (!string.IsNullOrEmpty(drv["Payer"].ToString()))
            {
                lblPayer.Text = Payer;
                if (!string.IsNullOrEmpty(drv["Unbilled"].ToString()))
                    lblUnbilled.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(drv["Unbilled"].ToString()));
                if (!string.IsNullOrEmpty(drv["Current"].ToString()))
                    lblCurrent.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(drv["Current"].ToString()));
                if (!string.IsNullOrEmpty(drv["31-60"].ToString()))
                    lbl3160.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(drv["31-60"].ToString()));
                if (!string.IsNullOrEmpty(drv["61-90"].ToString()))
                    lbl6190.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(drv["61-90"].ToString()));
                if (!string.IsNullOrEmpty(drv["91-120"].ToString()))
                    lbl91120.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(drv["91-120"].ToString()));
                if (!string.IsNullOrEmpty(drv["120+"].ToString()))
                    lbl120.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(drv["120+"].ToString()));
                if (!string.IsNullOrEmpty(drv["TotalBal"].ToString()))
                    lblTotalBal.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(drv["TotalBal"].ToString()));
            }
            else if (string.IsNullOrEmpty(drv["Payer"].ToString()) && drv["TotalBal"].ToString() == "100.0000")
            {
                lblPecentage.Style.Add("font-weight", "bold");
                lblPecentage.Text = "Pecentage";
                if (!string.IsNullOrEmpty(drv["Unbilled"].ToString()))
                    lblUnbilled.Text = string.Format("{0:0,0.00}", Convert.ToDouble(drv["Unbilled"].ToString())) + "%";
                if (!string.IsNullOrEmpty(drv["Current"].ToString()))
                    lblCurrent.Text = string.Format("{0:0,0.00}", Convert.ToDouble(drv["Current"].ToString())) + "%";
                if (!string.IsNullOrEmpty(drv["61-90"].ToString()))
                    lbl3160.Text = string.Format("{0:0,0.00}", Convert.ToDouble(drv["31-60"].ToString())) + "%";
                if (!string.IsNullOrEmpty(drv["61-90"].ToString()))
                    lbl6190.Text = string.Format("{0:0,0.00}", Convert.ToDouble(drv["61-90"].ToString())) + "%";
                if (!string.IsNullOrEmpty(drv["91-120"].ToString()))
                    lbl91120.Text = string.Format("{0:0,0.00}", Convert.ToDouble(drv["91-120"].ToString())) + "%";
                if (!string.IsNullOrEmpty(drv["120+"].ToString()))
                    lbl120.Text =string.Format("{0:0,0.00}", Convert.ToDouble (drv["120+"].ToString())) + "%";
                if (!string.IsNullOrEmpty(drv["TotalBal"].ToString()))
                    lblTotalBal.Text = string.Format("{0:0,0.00}", Convert.ToDouble(drv["TotalBal"].ToString())) + "%";
            }
            else
            {
                lblPayer.Style.Add("font-weight", "bold");
                lblPayer.Text = "Garand Total";
                if (!string.IsNullOrEmpty(drv["Unbilled"].ToString()))
                    lblUnbilled.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(drv["Unbilled"].ToString()));
                if (!string.IsNullOrEmpty(drv["Current"].ToString()))
                    lblCurrent.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(drv["Current"].ToString()));
                if (!string.IsNullOrEmpty(drv["31-60"].ToString()))
                    lbl3160.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(drv["31-60"].ToString()));
                if (!string.IsNullOrEmpty(drv["61-90"].ToString()))
                    lbl6190.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(drv["61-90"].ToString()));
                if (!string.IsNullOrEmpty(drv["91-120"].ToString()))
                    lbl91120.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(drv["91-120"].ToString()));
                if (!string.IsNullOrEmpty(drv["120+"].ToString()))
                    lbl120.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(drv["120+"].ToString()));
                if (!string.IsNullOrEmpty(drv["TotalBal"].ToString()))
                    lblTotalBal.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(drv["TotalBal"].ToString()));
            }

        }
    }
}