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


public partial class ProviderPortal_Reports_PatientCollectionDetail : System.Web.UI.Page
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
        string PracticeLocationId = Request.Form["PracticeLocationId"].ToString();
        string ProviderId = Request.Form["ProviderId"].ToString();
        string PatientId = Request.Form["PatientId"].ToString();
        hdnAgingDate.Value = Request.Form["AgingDate"];
        hdnAgingType.Value = Request.Form["AgingType"];
        hdnPracticeLocationId.Value = Request.Form["PracticeLocationId"].ToString();
        hdnPatientId.Value = Request.Form["PatientId"].ToString();
        hdnProviderId.Value = Request.Form["ProviderId"].ToString();
        DataSet dsReportData = objPatientReportsDB.GetPatientCollectionDetail(PracticeId, 10, 0, "PatientId desc", AgingType, AgingDate, PracticeLocationId, ProviderId, PatientId);

        rptPatientCollectionDetail.DataSource = dsReportData.Tables[0];
        rptPatientCollectionDetail.DataBind();
        hdnTotalRows.Value = dsReportData.Tables[1].Rows[0]["TotalRows"].ToString();


    }
    protected void ExportToExcel(object sender, EventArgs e)
    {
        int Rows = Convert.ToInt32(hdnTotalRows.Value);
        long PracticeId = Profile.PracticeId;
        ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();
        string AgingDate = hdnAgingDate.Value;
        string AgingType = hdnAgingType.Value;
        string PracticeLocationId = hdnPracticeLocationId.Value;
        string PatientId = hdnPatientId.Value;
        string ProviderId = hdnProviderId.Value;
        DataSet dsReportData = objPatientReportsDB.GetPatientCollectionDetail(PracticeId, Rows, 0, "PatientId ASC", AgingType, AgingDate, PracticeLocationId, ProviderId, PatientId);
        rptPatientCollectionDetail.DataSource = dsReportData.Tables[0];
        rptPatientCollectionDetail.DataBind();
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=Patient-Collection-Detail.xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        rptPatientCollectionDetail.RenderControl(hw);
        Response.Output.Write(sw.ToString());
        Response.Flush();
        Response.End();
    }
    public void rptExportToPDF(object sender, EventArgs e)
    {
        int Rows = Convert.ToInt32(hdnTotalRows.Value);
        long PracticeId = Profile.PracticeId;
        ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();
        string AgingDate = hdnAgingDate.Value;
        string AgingType = hdnAgingType.Value;
        string PracticeLocationId = hdnPracticeLocationId.Value;
        string PatientId = hdnPatientId.Value;
        string ProviderId = hdnProviderId.Value;
        DataSet dsReportData = objPatientReportsDB.GetPatientCollectionDetail(PracticeId, Rows, 0, "PatientId ASC", AgingType, AgingDate, PracticeLocationId, ProviderId, PatientId);
        rptPatientCollectionDetail.DataSource = dsReportData.Tables[0];
        rptPatientCollectionDetail.DataBind();
        Response.ContentType = "application/pdf";
        Response.AddHeader("content-disposition", "attachment;filename=Patient-Collection-Detail.pdf");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        rptPatientCollectionDetail.DataBind();
        rptPatientCollectionDetail.RenderControl(hw);
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
    public void rptExportToWord(object sender, EventArgs e)
    {
        int Rows = Convert.ToInt32(hdnTotalRows.Value);
        long PracticeId = Profile.PracticeId;
        ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();
        string AgingDate = hdnAgingDate.Value;
        string AgingType = hdnAgingType.Value;
        string PracticeLocationId = hdnPracticeLocationId.Value;
        string PatientId = hdnPatientId.Value;
        string ProviderId = hdnProviderId.Value;
        DataSet dsReportData = objPatientReportsDB.GetPatientCollectionDetail(PracticeId, Rows, 0, "PatientId ASC", AgingType, AgingDate, PracticeLocationId, ProviderId, PatientId);
        rptPatientCollectionDetail.DataSource = dsReportData.Tables[0];
        rptPatientCollectionDetail.DataBind();
        Response.Clear();
        Response.AddHeader("content-disposition", "attachment;filename=Patient-Collection-Detail.doc");
        Response.Charset = "";
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = "application/vnd.word";
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
        rptPatientCollectionDetail.RenderControl(htmlWrite);
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
            rptExportToPDF(sender, e);
        }
        else if (exportTo == "Word")
        {
            rptExportToWord(sender, e);
        }
    }
    protected void rptPatientCollectionDetail_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView drv = (DataRowView)e.Item.DataItem;
            Label lblBalanceOver90 = (Label)e.Item.FindControl("lblBalanceOver90");
            Label lblTotalBalance = (Label)e.Item.FindControl("lblTotalBalance");

            if (!string.IsNullOrEmpty(drv["BalanceOver90"].ToString()))
                lblBalanceOver90.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(drv["BalanceOver90"].ToString()));

            if (!string.IsNullOrEmpty(drv["TotalBalance"].ToString()))
                lblTotalBalance.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(drv["TotalBalance"].ToString()));
        }
    }
}