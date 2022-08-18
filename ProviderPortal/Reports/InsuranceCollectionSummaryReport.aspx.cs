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

public partial class ProviderPortal_Reports_InsuranceCollectionSummaryReport : System.Web.UI.Page
{
    int countLabel = 0;
    string nextClaimStatus = "";
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
        DataSet dsReportData = objPatientReportsDB.GetInsuranceCollectionSummary(PracticeId, 10, 0, "ClaimStatus ASC", AgingType, AgingDate, PracticeLocationId, ProviderId, PayerId, ClaimStatus);

        rptInsuranceCollectionSummary.DataSource = dsReportData.Tables[0];
        rptInsuranceCollectionSummary.DataBind();
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
        DataSet dsReportData = objPatientReportsDB.GetInsuranceCollectionSummary(PracticeId, Rows, 0, "ClaimStatus ASC", AgingType, AgingDate, PracticeLocationId, ProviderId, PayerId, ClaimStatus);
        rptInsuranceCollectionSummary.DataSource = dsReportData.Tables[0];
        rptInsuranceCollectionSummary.DataBind();
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=Insurance-Collection-Summary.xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        rptInsuranceCollectionSummary.RenderControl(hw);
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
        DataSet dsReportData = objPatientReportsDB.GetInsuranceCollectionSummary(PracticeId, Rows, 0, "ClaimStatus ASC", AgingType, AgingDate, PracticeLocationId, ProviderId, PayerId, ClaimStatus);
        rptInsuranceCollectionSummary.DataSource = dsReportData.Tables[0];
        rptInsuranceCollectionSummary.DataBind();
        Document document = new Document();
        Response.ContentType = "application/pdf";
        Response.AddHeader("content-disposition", "attachment;filename=Insurance-Collection-Summary.pdf");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        PdfWriter.GetInstance(document, Response.OutputStream);
        document.Open();
        iTextSharp.text.Font font5 = iTextSharp.text.FontFactory.GetFont(FontFactory.HELVETICA, 8);

        PdfPTable table = new PdfPTable(dsReportData.Tables[0].Columns.Count);
        PdfPRow row = null;
        float[] widths = new float[] { 10f, 10f, 10f, 0f };

        // table.SetWidths(widths);

        table.WidthPercentage = 100;
        int iCol = 0;
        string colname = "";
        PdfPCell cell = new PdfPCell(new Phrase("Products"));

        cell.Colspan = dsReportData.Tables[0].Columns.Count;

        table.AddCell(new Phrase("S.No", font5));
        table.AddCell(new Phrase("Claim Status", font5));
        table.AddCell(new Phrase("Period", font5));
        table.AddCell(new Phrase("Encounters", font5));
        table.AddCell(new Phrase("Procedures", font5));
        table.AddCell(new Phrase("Value", font5));
       
        table.AddCell(new Phrase("A/R", font5));
        table.AddCell(new Phrase("% Of A/R", font5));
        table.AddCell(new Phrase("Age", font5));

        Control findlabel = rptInsuranceCollectionSummary.Controls[rptInsuranceCollectionSummary.Controls.Count - 1].Controls[0];
       

        string period="";
        foreach (DataRow r in dsReportData.Tables[0].Rows) 
        {
            if (dsReportData.Tables[0].Rows.Count > 0)
            {
               
                table.AddCell(new Phrase(r[0].ToString(), font5));
                table.AddCell(new Phrase(r[1].ToString(), font5));
                period = r[2].ToString();
                string status = r[1].ToString();
                if (period == "")
                {


                    period = "Total " + status;
                    if (status == "")
                    {
                        period = "Grand Total";
                    }
                    else
                    {
                        period = "Total " + status;
                    }
                    table.AddCell(new Phrase(period, font5));



                }
                else
                {
                    table.AddCell(new Phrase(r[2].ToString(), font5));
                }
                
                table.AddCell(new Phrase(r[3].ToString(), font5));
                table.AddCell(new Phrase(r[4].ToString(), font5));
                table.AddCell(new Phrase("$" + r[5].ToString(), font5));
                table.AddCell(new Phrase("$" + r[6].ToString(), font5));
                table.AddCell(new Phrase(r[7] + "%".ToString(), font5));
                table.AddCell(new Phrase(r[8].ToString(), font5));

               
                }
             
                
            

            }
       
      
        document.Add(table);
        document.Close();
        Response.Write(document);
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
        DataSet dsReportData = objPatientReportsDB.GetInsuranceCollectionSummary(PracticeId, Rows, 0, "ClaimStatus ASC", AgingType, AgingDate, PracticeLocationId, ProviderId, PayerId, ClaimStatus);
        rptInsuranceCollectionSummary.DataSource = dsReportData.Tables[0];
        rptInsuranceCollectionSummary.DataBind();

        Response.Clear();
        Response.AddHeader("content-disposition", "attachment;filename=Insurance-Collection-Summary.doc");
        Response.Charset = "";
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = "application/vnd.word";
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
        rptInsuranceCollectionSummary.RenderControl(htmlWrite);
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
    protected void rptInsuranceCollectionSummary_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView drv = (DataRowView)e.Item.DataItem;
            int rptIndex = e.Item.ItemIndex;
            //******For 0 Index******/
            HtmlTableRow trClaimStatus = (HtmlTableRow)e.Item.FindControl("trClaimStatus");
            HtmlTableCell thClaimStatus = (HtmlTableCell)e.Item.FindControl("thClaimStatus");
            Label lblClaimStatus = (Label)e.Item.FindControl("lblClaimStatus");
            Label lblPeriod = (Label)e.Item.FindControl("lblPeriod");
            Label lblTotalPeriod = (Label)e.Item.FindControl("lblTotalPeriod");
            /******for other than 0 index***********/
            HtmlTableRow trLastClaimStatus = (HtmlTableRow)e.Item.FindControl("trLastClaimStatus");
            HtmlTableCell thLastClaimStatus = (HtmlTableCell)e.Item.FindControl("thLastClaimStatus");
            Label lblLastClaimStatus = (Label)e.Item.FindControl("lblLastClaimStatus");
            Label lblEncounters = (Label)e.Item.FindControl("lblEncounters");
            Label lblProcedures = (Label)e.Item.FindControl("lblProcedures");
            Label lblValue = (Label)e.Item.FindControl("lblValue");
            Label lblARBalance = (Label)e.Item.FindControl("lblARBalance");
            Label lblPercentageOfAR = (Label)e.Item.FindControl("lblPercentageOfAR");
            Label lblAge = (Label)e.Item.FindControl("lblAge");
            Label lblGranTotalPeriod = (Label)e.Item.FindControl("lblGranTotalPeriod");
            if (string.IsNullOrEmpty(drv["Period"].ToString()))
                countLabel++;
            if (!string.IsNullOrEmpty(drv["ClaimStatus"].ToString()))
            {
                if (string.IsNullOrEmpty(drv["Period"].ToString()) || rptIndex == 0)
                {
                    string ClaimStatus = "";
                    if (!string.IsNullOrEmpty(drv["ClaimStatus"].ToString()))
                        ClaimStatus = drv["ClaimStatus"].ToString();
                    if (rptIndex == 0)
                    {
                        /*lblClaimStatus.Style.Add("float", "left");
                        trClaimStatus.Style.Remove("display");
                        trClaimStatus.Style.Add("border-top", "1px solid #ccc");
                        lblClaimStatus.Text = ClaimStatus;*/
                    }
                    else if (string.IsNullOrEmpty(drv["Period"].ToString()))
                    {
                        lblTotalPeriod.Style.Add("font-weight", "bold");
                        lblTotalPeriod.Text = "Total " + ClaimStatus;
                        /* lblLastClaimStatus.Style.Add("float", "left");
                         trLastClaimStatus.Style.Remove("display");
                         trLastClaimStatus.Style.Add("border-top", "1px solid #ccc");
                         lblLastClaimStatus.Text = ClaimStatus;*/
                    }

                }
            }
            else
            {
                lblGranTotalPeriod.Style.Add("font-weight", "bold");
                lblGranTotalPeriod.Text = "Grand Total";
            }
            if (!string.IsNullOrEmpty(drv["ClaimStatus"].ToString()))
                lblClaimStatus.Text = drv["ClaimStatus"].ToString();

            if (!string.IsNullOrEmpty(drv["Period"].ToString()))
                lblPeriod.Text = drv["Period"].ToString();

            if (!string.IsNullOrEmpty(drv["Encounters"].ToString()))
                lblEncounters.Text = drv["Encounters"].ToString();

            if (!string.IsNullOrEmpty(drv["Procedures"].ToString()))
                lblProcedures.Text = drv["Procedures"].ToString();

            if (!string.IsNullOrEmpty(drv["Value"].ToString()))
                lblValue.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(drv["Value"].ToString()));

            if (!string.IsNullOrEmpty(drv["ARBalance"].ToString()))
                lblARBalance.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(drv["ARBalance"].ToString()));

            if (!string.IsNullOrEmpty(drv["%ofAR"].ToString()))
                lblPercentageOfAR.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(drv["%ofAR"].ToString())) + "%";

            if (!string.IsNullOrEmpty(drv["Age"].ToString()))
                lblAge.Text = drv["Age"].ToString();
        }
    }
}