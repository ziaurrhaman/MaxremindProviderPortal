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
public partial class ProviderPortal_Reports_AdjustmentsSummaryReport : System.Web.UI.Page
{
    string _DateFrom = "";
    string _DateTo = "";
    string _TimeSpan = ""; string DateType; string ProviderId;
    string PracticeLocationId; string PayerId; string AdjustmentCode;
    string PatientId; string ProcedureCode;
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadReport();
    }
    private void LoadReport()
    {
        ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();
        long PracticeId = Profile.PracticeId;
        _DateFrom = Request.Form["BillDateFrom"];
        _DateTo = Request.Form["BillDateTo"];

        DateType = Request.Form["DateType"];
        ProviderId = Request.Form["ProviderId"];
        PracticeLocationId = Request.Form["PracticeLocationId"];
        PayerId = Request.Form["PayerId"];
        AdjustmentCode = Request.Form["AdjustmentCode"];
        if (AdjustmentCode == null)
        {
            AdjustmentCode = "";
        }
        else
        {
            AdjustmentCode = Request.Form["AdjustmentCode"];
        }
        PatientId = Request.Form["PatientIds"];
        ProcedureCode = Request.QueryString["ProcedureCode"];
        DataSet dsReportData = objPatientReportsDB.AdjustmentsSummary(PracticeId, DateType, ProviderId, PracticeLocationId, PayerId, AdjustmentCode, ProcedureCode, PatientId, _DateFrom, _DateTo);

        rptAdjustmentsSummary.DataSource = dsReportData.Tables[0];
        rptAdjustmentsSummary.DataBind();

        // hdnTotalRows.Value = dsReportData.Tables[1].Rows[0]["TotalRows"].ToString();
        SetDatesObjects();
        Control FooterTemplate = rptAdjustmentsSummary.Controls[rptAdjustmentsSummary.Controls.Count - 1].Controls[0];
        Label lblPracticeName = FooterTemplate.FindControl("lblPracticeName") as Label;
        lblPracticeName.Text = Profile.PracticeName;
        //int Rows = int.Parse(hdnTotalRows.Value);
        DataTable dtReportData = objPatientReportsDB.GetTotalAdjustmentsSummary(PracticeId, DateType, ProviderId, PracticeLocationId, PayerId, AdjustmentCode, ProcedureCode, PatientId, _DateFrom, _DateTo);
        if (dtReportData.Rows.Count > 0)
        {
            if (!string.IsNullOrEmpty(dtReportData.Rows[0]["Total"].ToString()))
            {
                float Total = float.Parse(dtReportData.Compute("sum(Total)", string.Empty).ToString());
                Label lblTotal = FooterTemplate.FindControl("lblTotal") as Label;
                lblTotal.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(Total));
            }
        }
    }
    private void SetDatesObjects()
    {

        _TimeSpan = Request.Form["TimeSpan"];
        _DateFrom = Request.Form["DateFrom"];
        _DateTo = Request.Form["DateTo"];

        hdnTimeSpan.Value = _TimeSpan;
        hdnDateFrom.Value = _DateFrom;
        hdnDateTo.Value = _DateTo;

        DateTime now = DateTime.Now;

        if (_TimeSpan == "Beginning")
        {
            //_DateFrom = "01/01/1900";
            //_DateTo = DateTime.Now.ToString("MM/dd/yyyy");
            _DateFrom = "";
            _DateTo = "";
            lblReportTimeSpanFrom.Text = "All Records";
            //lblReportTimeSpanTo.Text = "Till Date";
        }
        else
        {
            separateSpan.Style.Remove("display");
            if (_TimeSpan == "YearToDate")
            {
                _DateFrom = (new DateTime(DateTime.Now.Year, 1, 1)).ToString("MM/dd/yyyy");
                _DateTo = now.ToString("MM/dd/yyyy");
            }
            else if (_TimeSpan == "MonthToDate")
            {
                _DateFrom = (new DateTime(now.Year, now.Month, 1)).ToString("MM/dd/yyyy");
                _DateTo = now.ToString("MM/dd/yyyy");
            }
            else if (_TimeSpan == "LastMonth")
            {
                //Changes by Iftikhar Ahmed on 01-18-2016
                int year = now.Year;
                if (now.Month == 1)
                {
                    year = now.AddYears(-1).Year;
                }
                _DateFrom = (new DateTime(year, (now.AddMonths(-1).Month), 1)).ToString("MM/dd/yyyy");
                _DateTo = (new DateTime(year, (now.AddMonths(-1).Month), 1)).AddMonths(1).AddDays(-1).ToString("MM/dd/yyyy");
            }
            else if (_TimeSpan == "SpecificDates")
            {
                if (_DateFrom == "") _DateFrom = "01/01/1900";
                if (_DateTo == "") _DateTo = DateTime.Now.ToString("MM/dd/yyyy");
            }

            lblReportTimeSpanFrom.Text = _DateFrom;
            lblReportTimeSpanTo.Text = _DateTo;
        }
    }

    protected void ExportToExcel(object sender, EventArgs e)
    {

        int Rows = Convert.ToInt32(hdnTotalRows.Value);
        long PracticeId = Profile.PracticeId;
        ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();
        _DateFrom = Request.Form["BillDateFrom"];
        _DateTo = Request.Form["BillDateTo"];

        DateType = Request.Form["DateType"];
        ProviderId = Request.Form["ProviderId"];
        PracticeLocationId = Request.Form["PracticeLocationId"];
        PayerId = Request.Form["PayerId"];
        AdjustmentCode = Request.Form["AdjustmentCode"];
        if (AdjustmentCode == null)
        {
            AdjustmentCode = "";
        }
        else
        {
            AdjustmentCode = Request.Form["AdjustmentCode"];
        }
        PatientId = Request.Form["PatientIds"];
        ProcedureCode = Request.Form["ProcedureCode"];
        DataTable dtReportData = objPatientReportsDB.GetTotalAdjustmentsSummary(PracticeId, DateType, ProviderId, PracticeLocationId, PayerId, AdjustmentCode, ProcedureCode, PatientId, _DateFrom, _DateTo);
        rptAdjustmentsSummary.DataSource = dtReportData;
        rptAdjustmentsSummary.DataBind();
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=Adjustments-Summary.xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        rptAdjustmentsSummary.RenderControl(hw);
        Response.Output.Write(sw.ToString());
        Response.Flush();
        Response.End();
    }
    public void repeaterExportToPDF(object sender, EventArgs e)
    {
        int Rows = Convert.ToInt32(hdnTotalRows.Value);
        long PracticeId = Profile.PracticeId;
        ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();
        _DateFrom = Request.Form["BillDateFrom"];
        _DateTo = Request.Form["BillDateTo"];

        DateType = Request.Form["DateType"];
        ProviderId = Request.Form["ProviderId"];
        PracticeLocationId = Request.Form["PracticeLocationId"];
        PayerId = Request.Form["PayerId"];
        AdjustmentCode = Request.Form["AdjustmentCode"];
        if (AdjustmentCode == null)
        {
            AdjustmentCode = "";
        }
        else
        {
            AdjustmentCode = Request.Form["AdjustmentCode"];
        }
        PatientId = Request.Form["PatientIds"];
        ProcedureCode = Request.Form["ProcedureCode"];
        DataTable dtReportData = objPatientReportsDB.GetTotalAdjustmentsSummary(PracticeId, DateType, ProviderId, PracticeLocationId, PayerId, AdjustmentCode, ProcedureCode, PatientId, _DateFrom, _DateTo);
        Document document = new Document();
        Response.ContentType = "application/pdf"; Response.AddHeader("content-disposition", "attachment;filename=Adjustment-Summary.pdf");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        PdfWriter.GetInstance(document, Response.OutputStream);
        document.Open();
        iTextSharp.text.Font font5 = iTextSharp.text.FontFactory.GetFont(FontFactory.HELVETICA, 8);

        PdfPTable table = new PdfPTable(dtReportData.Columns.Count);
        PdfPRow row = null;
        float[] widths = new float[] { 10f, 10f, 10f, 0f };

        // table.SetWidths(widths);

        table.WidthPercentage = 100;
        int iCol = 0;
        string colname = "";
        PdfPCell cell = new PdfPCell(new Phrase("Products"));

        cell.Colspan = dtReportData.Columns.Count;

        /*foreach (DataColumn c in dtReportData.Columns)
        {

            table.AddCell(new Phrase(c.ColumnName, font5));
        }*/
     
        table.AddCell(new Phrase("Provider", font5));
        table.AddCell(new Phrase("Adjustment Amount", font5));
      

        foreach (DataRow r in dtReportData.Rows)
        {
            if (dtReportData.Rows.Count > 0)
            {

                table.AddCell(new Phrase(r[0].ToString(), font5));
                table.AddCell(new Phrase(r[1].ToString(), font5));
              //  table.AddCell(new Phrase("$" + r[2].ToString(), font5));
                
            }
        }
        /***************Footer************/
        Control FooterTemplate = rptAdjustmentsSummary.Controls[rptAdjustmentsSummary.Controls.Count - 1].Controls[0];
        Label lblTotal = FooterTemplate.FindControl("lblTotal") as Label;
        Label lblPracticeName = FooterTemplate.FindControl("lblPracticeName") as Label;
        lblPracticeName.Text = Profile.PracticeName;
        
       
        if (dtReportData.Rows.Count > 0)
        {
            if (!string.IsNullOrEmpty(dtReportData.Rows[0]["Total"].ToString()))
            {
                float Total = float.Parse(dtReportData.Compute("sum(Total)", string.Empty).ToString());
               
                lblTotal.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(Total));
            }
            PdfPTable tableFooter = new PdfPTable(dtReportData.Columns.Count);
            float[] widthsFooter = new float[] { 10f, 10f, 10f, 0f };
            table.WidthPercentage = 100;
            PdfPCell cellFooter = new PdfPCell(new Phrase("Products"));
            table.AddCell(new Phrase(lblPracticeName.Text, font5));
            table.AddCell(new Phrase(lblTotal.Text, font5));

            document.Add(tableFooter);
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
        ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();
        _DateFrom = Request.Form["DateFrom"];
        _DateTo = Request.Form["DateTo"];
        DataTable dtReportData = objPatientReportsDB.GetTotalAdjustmentsSummary(PracticeId, DateType, ProviderId, PracticeLocationId, PayerId, AdjustmentCode, ProcedureCode, PatientId, _DateFrom, _DateTo);
        rptAdjustmentsSummary.DataSource = dtReportData;
        rptAdjustmentsSummary.DataBind();

        Response.Clear();
        Response.AddHeader("content-disposition", "attachment;filename=Adjustments-Summary.doc");
        Response.Charset = "";
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = "application/vnd.word";
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
        rptAdjustmentsSummary.RenderControl(htmlWrite);
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
    protected void rptAdjustmentsSummary_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView drv = (DataRowView)e.Item.DataItem;
            string total = drv["Total"].ToString();
            Label lblSubTotal = (Label)e.Item.FindControl("lblSubTotal");
            if (total != "")
            {
                lblSubTotal.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(total));
            }
        }
    }
}