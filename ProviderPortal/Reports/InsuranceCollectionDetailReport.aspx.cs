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
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public partial class ProviderPortal_Reports_InsuranceCollectionDetailReport : System.Web.UI.Page
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
        string ClaimStatus = Request.Form["ClaimStatus"];
        hdnAgingDate.Value = Request.Form["AgingDate"];
        hdnAgingType.Value = Request.Form["AgingType"];
        hdnPracticeLocationId.Value = Request.Form["PracticeLocationId"];
        hdnPayerId.Value = Request.Form["PayerId"];
        hdnClaimStatus.Value = Request.Form["ClaimStatus"];
        hdnProviderId.Value = Request.Form["ProviderId"];
        DataSet dsReportData = objPatientReportsDB.GetInsuranceCollectionDetail(PracticeId, 10, 0, "ClaimStatus ASC", AgingType, AgingDate, PracticeLocationId, ProviderId, PayerId, ClaimStatus);

        rptInsuranceCollectionDetail.DataSource = dsReportData.Tables[0];
        rptInsuranceCollectionDetail.DataBind();
        hdnTotalRows.Value = dsReportData.Tables[1].Rows[0]["TotalRows"].ToString();


    }
    protected void ExportToExcel(object sender, EventArgs e)
    {

        int Rows = Convert.ToInt32(hdnTotalRows.Value);
        long PracticeId = Profile.PracticeId;
        ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();
        string AgingDate = Request.Form["AgingDate"];
        string AgingType = Request.Form["AgingType"];
        string PracticeLocationId = Request.Form["PracticeLocationId"];
        string ProviderId = Request.Form["ProviderId"];
        string PayerId = Request.Form["PayerId"];
        string ClaimStatus = Request.Form["ClaimStatus"];
        DataSet dsReportData = objPatientReportsDB.GetInsuranceCollectionDetail(PracticeId, Rows, 0, "ClaimStatus ASC", AgingType, AgingDate, PracticeLocationId, ProviderId, PayerId, ClaimStatus);
        rptInsuranceCollectionDetail.DataSource = dsReportData.Tables[0];
        rptInsuranceCollectionDetail.DataBind();
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=Insurance-Collection-Detail.xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        rptInsuranceCollectionDetail.RenderControl(hw);
        Response.Output.Write(sw.ToString());
        Response.Flush();
        Response.End();
    }
    public void repeaterExportToPDF(object sender, EventArgs e)
    {
        int Rows = Convert.ToInt32(hdnTotalRows.Value);
        long PracticeId = Profile.PracticeId;
        ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();
        string AgingDate = Request.Form["AgingDate"];
        string AgingType = Request.Form["AgingType"];
        string PracticeLocationId = Request.Form["PracticeLocationId"];
        string ProviderId = Request.Form["ProviderId"];
        string PayerId = Request.Form["PayerId"];
        string ClaimStatus = Request.Form["ClaimStatus"];
        DataSet dsReportData = objPatientReportsDB.GetInsuranceCollectionDetail(PracticeId, Rows, 0, "ClaimStatus ASC", AgingType, AgingDate, PracticeLocationId, ProviderId, PayerId, ClaimStatus);
        rptInsuranceCollectionDetail.DataSource = dsReportData.Tables[0];
        rptInsuranceCollectionDetail.DataBind();
        Response.ContentType = "application/pdf";
        Response.AddHeader("content-disposition", "attachment;filename=Insurance-Collection-Detail.pdf");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        rptInsuranceCollectionDetail.DataBind();
        rptInsuranceCollectionDetail.RenderControl(hw);
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
        string AgingDate = Request.Form["AgingDate"];
        string AgingType = Request.Form["AgingType"];
        string PracticeLocationId = Request.Form["PracticeLocationId"];
        string ProviderId = Request.Form["ProviderId"];
        string PayerId = Request.Form["PayerId"];
        string ClaimStatus = Request.Form["ClaimStatus"];
        DataSet dsReportData = objPatientReportsDB.GetInsuranceCollectionDetail(PracticeId, Rows, 0, "ClaimStatus ASC", AgingType, AgingDate, PracticeLocationId, ProviderId, PayerId, ClaimStatus);
        rptInsuranceCollectionDetail.DataSource = dsReportData.Tables[0];
        rptInsuranceCollectionDetail.DataBind();

        Response.Clear();
        Response.AddHeader("content-disposition", "attachment;filename=Insurance-Collection-Detail.doc");
        Response.Charset = "";
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = "application/vnd.word";
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
        rptInsuranceCollectionDetail.RenderControl(htmlWrite);
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
    protected void rptInsuranceCollectionDetail_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView drv = (DataRowView)e.Item.DataItem;
            int rptIndex = e.Item.ItemIndex;
            //******For 0 Index******/
            HtmlTableRow trClaimStatus = (HtmlTableRow)e.Item.FindControl("trClaimStatus");
            HtmlTableRow trPeriod = (HtmlTableRow)e.Item.FindControl("trPeriod");
            HtmlTableCell thClaimStatus = (HtmlTableCell)e.Item.FindControl("thClaimStatus");
            HtmlTableCell thPeriod = (HtmlTableCell)e.Item.FindControl("thPeriod");
            Label lblClaimStatus = (Label)e.Item.FindControl("lblClaimStatus");
            Label lblPeriod = (Label)e.Item.FindControl("lblPeriod");
            /******for other than 0 index***********/
            HtmlTableRow trLastClaimStatus = (HtmlTableRow)e.Item.FindControl("trLastClaimStatus");
            HtmlTableRow trLastPeriod = (HtmlTableRow)e.Item.FindControl("trLastPeriod");
            HtmlTableCell thLastClaimStatus = (HtmlTableCell)e.Item.FindControl("thLastClaimStatus");
            HtmlTableCell thLastPeriod = (HtmlTableCell)e.Item.FindControl("thLastPeriod");
            Label lblLastClaimStatus = (Label)e.Item.FindControl("lblLastClaimStatus");
            Label lblLastPeriod = (Label)e.Item.FindControl("lblLastPeriod");
            Label lblAdcharges = (Label)e.Item.FindControl("lblAdcharges");
            Label lblPayment = (Label)e.Item.FindControl("lblPayment");
            Label lblARBalance = (Label)e.Item.FindControl("lblARBalance");
            Label lblBilledTo = (Label)e.Item.FindControl("lblBilledTo");
            Label lblSubBilledTo = (Label)e.Item.FindControl("lblSubBilledTo");
            Label lblGrandBilledTo = (Label)e.Item.FindControl("lblGrandBilledTo");
            Label lblTotalBilledTo = (Label)e.Item.FindControl("lblTotalBilledTo");
            if (!string.IsNullOrEmpty(drv["ClaimStatus"].ToString()))
            {
                if (string.IsNullOrEmpty(drv["ClaimId"].ToString()) || string.IsNullOrEmpty(drv["Period"].ToString()) || rptIndex == 0)
                {
                    string ClaimStatus = "";
                    if (!string.IsNullOrEmpty(drv["ClaimStatus"].ToString()))
                        ClaimStatus = drv["ClaimStatus"].ToString();

                    string Period = "";
                    if (!string.IsNullOrEmpty(drv["Period"].ToString()))
                        Period = drv["Period"].ToString();
                    if (rptIndex == 0)
                    {
                        lblPeriod.Style.Add("float", "left");
                        trPeriod.Style.Remove("display");
                        trPeriod.Style.Add("border-top", "1px solid #ccc");
                        lblPeriod.Text = Period;
                        lblClaimStatus.Style.Add("float", "left");
                        trClaimStatus.Style.Remove("display");
                        trClaimStatus.Style.Add("border-top", "1px solid #ccc");
                        lblClaimStatus.Text = ClaimStatus;
                    }
                    else if (string.IsNullOrEmpty(drv["ClaimId"].ToString()) && !string.IsNullOrEmpty(drv["Period"].ToString()))
                    {
                        lblLastPeriod.Style.Add("float", "left");
                        trLastPeriod.Style.Remove("display");
                        trLastPeriod.Style.Add("border-top", "1px solid #ccc");
                        lblLastPeriod.Text = Period;
                    }
                    else if (string.IsNullOrEmpty(drv["Period"].ToString()))
                    {
                        lblLastClaimStatus.Style.Add("float", "left");
                        trLastClaimStatus.Style.Remove("display");
                        trLastClaimStatus.Style.Add("border-top", "1px solid #ccc");
                        lblLastClaimStatus.Text = ClaimStatus;
                    }

                }
            }
            if (!string.IsNullOrEmpty(drv["Adcharges"].ToString()))
                lblAdcharges.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(drv["Adcharges"].ToString()));
            if (!string.IsNullOrEmpty(drv["Payment"].ToString()))
                lblPayment.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(drv["Payment"].ToString()));
            if (!string.IsNullOrEmpty(drv["Adcharges"].ToString()))
                lblARBalance.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(drv["Adcharges"].ToString()));
            if (!string.IsNullOrEmpty(drv["ClaimStatus"].ToString()) && string.IsNullOrEmpty(drv["Period"].ToString()))
            {
                lblSubBilledTo.Style.Add("font-weight", "bold");
                lblSubBilledTo.Text = "Sub Grand Total";
            }
            else if (!string.IsNullOrEmpty(drv["Period"].ToString()) && string.IsNullOrEmpty(drv["ClaimId"].ToString()))
            {
                lblTotalBilledTo.Style.Add("font-weight", "bold");
                lblTotalBilledTo.Text = "Total";
            }
            else if (string.IsNullOrEmpty(drv["ClaimStatus"].ToString()))
            {
                lblGrandBilledTo.Style.Add("font-weight", "bold");
                lblGrandBilledTo.Text = "Grand Total";
            }
            else
            {
                lblBilledTo.Text = drv["BilledTo"].ToString();
            }
        }
    }
}