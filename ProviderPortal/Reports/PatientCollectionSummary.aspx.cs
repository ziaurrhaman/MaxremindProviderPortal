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

public partial class ProviderPortal_Reports_PatientCollectionSummary : System.Web.UI.Page
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
        DataSet dsReportData = objPatientReportsDB.GetPatientCollectionSummary(PracticeId, AgingType, AgingDate, PracticeLocationId, ProviderId, PatientId);

        rptPatientCollectionSummary.DataSource = dsReportData.Tables[0];
        rptPatientCollectionSummary.DataBind();
        //hdnTotalRows.Value = dsReportData.Tables[1].Rows[0]["TotalRows"].ToString();


    }
    protected void ExportToExcel(object sender, EventArgs e)
    {
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=Patient-Collection-Summary.xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        divReportListing.RenderControl(hw);
        Response.Output.Write(sw.ToString());
        Response.Flush();
        Response.End();
    }
    public void divExportToPDF(object sender, EventArgs e)
    {
        Response.ContentType = "application/pdf";
        Response.AddHeader("content-disposition", "attachment;filename=Patient-Collection-Summary.pdf");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
       

        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        divReportListing.DataBind();
        divReportListing.RenderControl(hw);
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
    public void divExportToWord(object sender, EventArgs e)
    {
        Response.Clear();
        Response.AddHeader("content-disposition", "attachment;filename=Patient-Collection-Summary.doc");
        Response.Charset = "";
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = "application/vnd.word";
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
        divReportListing.RenderControl(htmlWrite);
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
            divExportToPDF(sender, e);
        }
        else if (exportTo == "Word")
        {
            //obj.ExportToWord(html, FileName);
            divExportToWord(sender, e);
        }
    }
    protected void rptPatientCollectionSummary_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView drv = (DataRowView)e.Item.DataItem;
            Label lblCollectionCategory = (Label)e.Item.FindControl("lblCollectionCategory");
            Label lblUnbilled = (Label)e.Item.FindControl("lblUnbilled");
            Label lblCurrent = (Label)e.Item.FindControl("lblCurrent");
            Label lbl3160 = (Label)e.Item.FindControl("lbl3160");
            Label lbl6190 = (Label)e.Item.FindControl("lbl6190");
            Label lbl91120 = (Label)e.Item.FindControl("lbl91120");
            Label lbl120 = (Label)e.Item.FindControl("lbl120");
            Label lblTotalBal = (Label)e.Item.FindControl("lblTotalBal");
            if (string.IsNullOrEmpty(drv["CollectionCategory"].ToString()))
            {
                if (!string.IsNullOrEmpty(drv["NoOfPatients"].ToString()))
                {
                    lblCollectionCategory.Style.Add("font-weight", "bold");
                    lblCollectionCategory.Text = "Grand Total";
                }
                else
                {
                    lblCollectionCategory.Style.Add("font-weight", "bold");
                    lblCollectionCategory.Text = "Grand Total(%)";
                }
            }
            else
            {
                lblCollectionCategory.Style.Add("font-weight", "bold");
                lblCollectionCategory.Text = drv["CollectionCategory"].ToString();
            }

            if (!string.IsNullOrEmpty(drv["Unbilled"].ToString()) && !string.IsNullOrEmpty(drv["NoOfPatients"].ToString()))
                lblUnbilled.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(drv["Unbilled"].ToString()));
            if (string.IsNullOrEmpty(drv["NoOfPatients"].ToString()) && !string.IsNullOrEmpty(drv["Unbilled"].ToString()))
                lblUnbilled.Text = drv["Unbilled"].ToString() + "%";

            if (!string.IsNullOrEmpty(drv["Current"].ToString()) && !string.IsNullOrEmpty(drv["NoOfPatients"].ToString()))
                lblCurrent.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(drv["Current"].ToString()));
            if (string.IsNullOrEmpty(drv["NoOfPatients"].ToString()) && !string.IsNullOrEmpty(drv["Current"].ToString()))
                lblCurrent.Text = drv["Current"].ToString() + "%";

            if (!string.IsNullOrEmpty(drv["31-60"].ToString()) && !string.IsNullOrEmpty(drv["NoOfPatients"].ToString()))
                lbl3160.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(drv["31-60"].ToString()));
            if (string.IsNullOrEmpty(drv["NoOfPatients"].ToString()) && !string.IsNullOrEmpty(drv["31-60"].ToString()))
                lbl3160.Text = drv["31-60"].ToString() + "%";

            if (!string.IsNullOrEmpty(drv["61-90"].ToString()) && !string.IsNullOrEmpty(drv["NoOfPatients"].ToString()))
                lbl6190.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(drv["61-90"].ToString()));
            if (string.IsNullOrEmpty(drv["NoOfPatients"].ToString()) && !string.IsNullOrEmpty(drv["61-90"].ToString()))
                lbl6190.Text = drv["61-90"].ToString() + "%";

            if (!string.IsNullOrEmpty(drv["91-120"].ToString()) && !string.IsNullOrEmpty(drv["NoOfPatients"].ToString()))
                lbl91120.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(drv["91-120"].ToString()));
            if (string.IsNullOrEmpty(drv["NoOfPatients"].ToString()) && !string.IsNullOrEmpty(drv["91-120"].ToString()))
                lbl91120.Text = drv["91-120"].ToString() + "%";

            if (!string.IsNullOrEmpty(drv["120+"].ToString()) && !string.IsNullOrEmpty(drv["NoOfPatients"].ToString()))
                lbl120.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(drv["120+"].ToString()));
            if (string.IsNullOrEmpty(drv["NoOfPatients"].ToString()) && !string.IsNullOrEmpty(drv["120+"].ToString()))
                lbl120.Text = drv["120+"].ToString() + "%";

            if (!string.IsNullOrEmpty(drv["TotalBal"].ToString()) && !string.IsNullOrEmpty(drv["NoOfPatients"].ToString()))
                lblTotalBal.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(drv["TotalBal"].ToString()));
            if (string.IsNullOrEmpty(drv["NoOfPatients"].ToString()) && !string.IsNullOrEmpty(drv["TotalBal"].ToString()))
                lblTotalBal.Text = drv["TotalBal"].ToString() + "%";
        }
    }

}