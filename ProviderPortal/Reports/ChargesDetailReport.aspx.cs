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

public partial class ProviderPortal_Reports_ChargesDetailReport : System.Web.UI.Page
{
    string _DateFrom = "";
    string _DateTo = "";
    string _TimeSpan = ""; string DateType; string ProviderId;
    string PracticeLocationId; string PayerId;
    string PatientId; string ProcedureCode; int Rows;
    ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadReport();
    }
    private void LoadReport()
    {
        long PracticeId = Profile.PracticeId;
        _DateFrom = Request.Form["BillDateFrom"];
        _DateTo = Request.Form["BillDateTo"];

        DateType = Request.Form["DateType"];
        ProviderId = Request.Form["ProviderId"];
        PracticeLocationId = Request.Form["PracticeLocationId"];
        PayerId = Request.Form["PayerId"];
        PatientId = Request.Form["PatientIds"];
        hdnPatId.Value = PatientId;
        ProcedureCode = Request.Form["ProcedureCode"];

        DataSet dsReportData = objPatientReportsDB.ChargesDetail(PracticeId, 10, 0, "PatientName asc", DateType, ProviderId, PracticeLocationId, PayerId, ProcedureCode, PatientId, _DateFrom, _DateTo);

        rptChargesDetail.DataSource = dsReportData.Tables[0];
        rptChargesDetail.DataBind();
        hdnTotalRows.Value = dsReportData.Tables[1].Rows[0]["TotalRows"].ToString();
        GetTotal();
        SetDatesObjects();
        
    }
    public void GetTotal()
    {
        int Rows = int.Parse(hdnTotalRows.Value);
        long PracticeId = Profile.PracticeId;
        _DateFrom = Request.Form["BillDateFrom"];
        _DateTo = Request.Form["BillDateTo"];

        DateType = Request.Form["DateType"];
        ProviderId = Request.Form["ProviderId"];
        PracticeLocationId = Request.Form["PracticeLocationId"];
        PayerId = Request.Form["PayerId"];
        PatientId = Request.Form["PatientIds"];
        hdnPatId.Value = PatientId;
        ProcedureCode = Request.Form["ProcedureCode"];
        DataTable dtReportData = objPatientReportsDB.GetTotalChargesDetail(PracticeId, Rows, 0, "PatientName asc", DateType, ProviderId, PracticeLocationId, PayerId, ProcedureCode, PatientId, _DateFrom, _DateTo);

        Control FooterTemplate = rptChargesDetail.Controls[rptChargesDetail.Controls.Count - 1].Controls[0];
        if (dtReportData.Rows.Count > 0)
        {
            Label lblGrandTotal = FooterTemplate.FindControl("lblGrandTotal") as Label;
            lblGrandTotal.Text = "Grand Total";
            if (!string.IsNullOrEmpty(dtReportData.Rows[0]["ServiceUnits"].ToString()))
            {
                float TotalUnits = float.Parse(dtReportData.Compute("sum(ServiceUnits)", string.Empty).ToString());
                Label lblTotalUnits = FooterTemplate.FindControl("lblTotalUnits") as Label;
                lblTotalUnits.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(TotalUnits));
            }
        }

        if (dtReportData.Rows.Count > 0)
        {
            if (!string.IsNullOrEmpty(dtReportData.Rows[0]["TotalCharges"].ToString()))
            {
                string TotalTotalCharges = dtReportData.Compute("sum(TotalCharges)", string.Empty).ToString();
                Label lblTotalCharges = FooterTemplate.FindControl("lblTotalCharges") as Label;
                lblTotalCharges.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(TotalTotalCharges));
            }
        }
    }
    private void SetDatesObjects()
    {

        _TimeSpan = Request.Form["TimeSpan"];
        _DateFrom = Request.Form["BillDateFrom"];
        _DateTo = Request.Form["BillDateTo"];

        if (_TimeSpan == null)
        {
            hdnTimeSpan.Value = "All Records";
        }
        else
        {
            hdnTimeSpan.Value = _TimeSpan;
        }
      
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
        _DateFrom = Request.Form["DateFrom"];
        _DateTo = Request.Form["DateTo"];
        DataSet dsReportData = objPatientReportsDB.ChargesDetail(PracticeId, Rows, 0, "PatientName asc", DateType, ProviderId, PracticeLocationId, PayerId, ProcedureCode, PatientId, _DateFrom, _DateTo);
        rptChargesDetail.DataSource = dsReportData.Tables[0];
        rptChargesDetail.DataBind();
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=Charges-Detail.xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";
        GetTotal();
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        rptChargesDetail.RenderControl(hw);
        Response.Output.Write(sw.ToString());
        Response.Flush();
        Response.End();
    }
    public void repeaterExportToPDF(object sender, EventArgs e)
    {
        int Rows = int.Parse(hdnTotalRows.Value);
        long PracticeId = Profile.PracticeId;
        _DateFrom = Request.Form["BillDateFrom"];
        _DateTo = Request.Form["BillDateTo"];

        DateType = Request.Form["DateType"];
        ProviderId = Request.Form["ProviderId"];
        PracticeLocationId = Request.Form["PracticeLocationId"];
        PayerId = Request.Form["PayerId"];
        PatientId = Request.Form["PatientIds"];
        hdnPatId.Value = PatientId;
        ProcedureCode = Request.QueryString["ProcedureCode"];
        DataTable dtReportData = objPatientReportsDB.GetTotalChargesDetail(PracticeId, Rows, 0, "PatientName asc", DateType, ProviderId, PracticeLocationId, PayerId, ProcedureCode, PatientId, _DateFrom, _DateTo);

        Document document = new Document();
        Response.ContentType = "application/pdf"; Response.AddHeader("content-disposition", "attachment;filename=Charges-Detail.pdf");
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
        table.AddCell(new Phrase("S.NO", font5));
        table.AddCell(new Phrase("Post Date", font5));
        table.AddCell(new Phrase("Service Date", font5));
        table.AddCell(new Phrase("Patient Id", font5));
        table.AddCell(new Phrase("Patient Name", font5));
        table.AddCell(new Phrase("Code", font5));
        table.AddCell(new Phrase("Description", font5));
        table.AddCell(new Phrase("Rend Povider", font5));
        table.AddCell(new Phrase("Location", font5));
        table.AddCell(new Phrase("Unit", font5));
        table.AddCell(new Phrase("Total Charges", font5));

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
                table.AddCell(new Phrase(r[7].ToString(), font5));
                table.AddCell(new Phrase(r[8].ToString(), font5));
                table.AddCell(new Phrase("$"+r[9].ToString(), font5));
                table.AddCell(new Phrase("$"+r[10].ToString(), font5));
            }
        } 
        /***************Footer************/
       Control FooterTemplate = rptChargesDetail.Controls[rptChargesDetail.Controls.Count - 1].Controls[0];
        if (dtReportData.Rows.Count > 0)
        {
            Label lblGrandTotal = FooterTemplate.FindControl("lblGrandTotal") as Label;
            lblGrandTotal.Text = "Grand Total";
            Label lblTotalUnits = FooterTemplate.FindControl("lblTotalUnits") as Label;
            Label lblTotalCharges = FooterTemplate.FindControl("lblTotalCharges") as Label;
            if (!string.IsNullOrEmpty(dtReportData.Rows[0]["ServiceUnits"].ToString()))
            {
                float TotalUnits = float.Parse(dtReportData.Compute("sum(ServiceUnits)", string.Empty).ToString());
                lblTotalUnits.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(TotalUnits));
            }
            if (!string.IsNullOrEmpty(dtReportData.Rows[0]["TotalCharges"].ToString()))
            {
                string TotalTotalCharges = dtReportData.Compute("sum(TotalCharges)", string.Empty).ToString();
                lblTotalCharges.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(TotalTotalCharges));
            }
            PdfPTable tableFooter = new PdfPTable(dtReportData.Columns.Count);
            float[] widthsFooter = new float[] { 10f, 10f, 10f, 0f };
            table.WidthPercentage = 100;
            PdfPCell cellFooter = new PdfPCell(new Phrase("Products"));
            table.AddCell(new Phrase("", font5));
            table.AddCell(new Phrase("", font5));
            table.AddCell(new Phrase("", font5));
            table.AddCell(new Phrase("", font5));
            table.AddCell(new Phrase("", font5));
            table.AddCell(new Phrase("", font5));
            table.AddCell(new Phrase("", font5));
            table.AddCell(new Phrase("", font5));
            table.AddCell(new Phrase(lblGrandTotal.Text, font5));
            table.AddCell(new Phrase(lblTotalUnits.Text, font5));
            table.AddCell(new Phrase(lblTotalCharges.Text, font5));

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
        DataSet dsReportData = objPatientReportsDB.ChargesDetail(PracticeId, Rows, 0, "PatientName asc", DateType, ProviderId, PracticeLocationId, PayerId, ProcedureCode, PatientId, _DateFrom, _DateTo);
        rptChargesDetail.DataSource = dsReportData.Tables[0];
        rptChargesDetail.DataBind();

        Response.Clear();
        Response.AddHeader("content-disposition", "attachment;filename=Charges-Detail.doc");
        Response.Charset = "";
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = "application/vnd.word";
        GetTotal();
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
        rptChargesDetail.RenderControl(htmlWrite);
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
    protected void rptChargesDetail_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView drv = (DataRowView)e.Item.DataItem;
            string ServiceUnits = drv["ServiceUnits"].ToString();
            Label lblServiceUnits = (Label)e.Item.FindControl("lblServiceUnits");
            if (ServiceUnits != "")
            {
                lblServiceUnits.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(ServiceUnits));
            }
            string TotalCharges = drv["TotalCharges"].ToString();
            Label lblTotalCharges = (Label)e.Item.FindControl("lblTotalCharges");
            if (TotalCharges != "")
            {
                lblTotalCharges.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(TotalCharges));
            }
        }
    }
}