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
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public partial class ProviderPortal_Reports_PaymentByProcedureReport : System.Web.UI.Page
{
    string _DateFrom = "";
    string _DateTo = "";
    string _TimeSpan = "";
    ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadReport();
    }
    private void LoadReport()
    {
        long PracticeId = Profile.PracticeId;
        _DateFrom = Request.Form["DateFrom"];
        _DateTo = Request.Form["DateTo"];
        DataSet dsReportData = objPatientReportsDB.GetPaymentByProcedure(PracticeId, 10, 0, "Code asc", _DateFrom, _DateTo);

        rptPaymentByProcedure.DataSource = dsReportData.Tables[0];
        rptPaymentByProcedure.DataBind();
        hdnTotalRows.Value = dsReportData.Tables[1].Rows[0]["TotalRows"].ToString();
        int Rows = int.Parse(hdnTotalRows.Value);


        SetDatesObjects();
        GetTotal();
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
    public void GetTotal()
    {

        int Rows = Convert.ToInt32(hdnTotalRows.Value);
        _DateFrom = Request.Form["DateFrom"];
        _DateTo = Request.Form["DateTo"];
        DataTable dtReportData = objPatientReportsDB.GetTotalPaymentByProcedure(Profile.PracticeId, Rows, 0, "PatientName asc", _DateFrom, _DateTo);
        Control FooterTemplate = rptPaymentByProcedure.Controls[rptPaymentByProcedure.Controls.Count - 1].Controls[0];
        if (dtReportData.Rows.Count > 0)
        {
            Label lblTotalLabel = FooterTemplate.FindControl("lblTotalLabel") as Label;
            lblTotalLabel.Text = "Average Evaluatin and Management";
            if (!string.IsNullOrEmpty(dtReportData.Rows[0]["AvgPaymentByPrimary"].ToString()))
            {
                float TotalAvgPaymentByPrimary = float.Parse(dtReportData.Compute("sum(AvgPaymentByPrimary)", string.Empty).ToString());
                Label lblTotaAvgPaymentByPrimary = FooterTemplate.FindControl("lblTotaAvgPaymentByPrimary") as Label;
                lblTotaAvgPaymentByPrimary.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(TotalAvgPaymentByPrimary));
            }
            if (!string.IsNullOrEmpty(dtReportData.Rows[0]["AvgPaymentBySecondary"].ToString()))
            {
                float TotalAvgPaymentBySecondary = float.Parse(dtReportData.Compute("sum(AvgPaymentBySecondary)", string.Empty).ToString());
                Label lblTotalAvgPaymentBySecondary = FooterTemplate.FindControl("lblTotalAvgPaymentBySecondary") as Label;
                lblTotalAvgPaymentBySecondary.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(TotalAvgPaymentBySecondary));
            }
            if (!string.IsNullOrEmpty(dtReportData.Rows[0]["AvgPaymentByPatient"].ToString()))
            {
                float TotalAvgPaymentByPatient = float.Parse(dtReportData.Compute("sum(AvgPaymentByPatient)", string.Empty).ToString());
                Label lblTotalAvgPaymentByPatient = FooterTemplate.FindControl("lblTotalAvgPaymentByPatient") as Label;
                lblTotalAvgPaymentByPatient.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(TotalAvgPaymentByPatient));
            } if (!string.IsNullOrEmpty(dtReportData.Rows[0]["AvgTotalPayment"].ToString()))
            {
                float TotalAvgTotalPayment = float.Parse(dtReportData.Compute("sum(AvgTotalPayment)", string.Empty).ToString());
                Label lblTotalAvgTotalPayment = FooterTemplate.FindControl("lblTotalAvgTotalPayment") as Label;
                lblTotalAvgTotalPayment.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(TotalAvgTotalPayment));
            }
        }
    }
    protected void ExportToExcel(object sender, EventArgs e)
    {

        int Rows = Convert.ToInt32(hdnTotalRows.Value);
        long PracticeId = Profile.PracticeId;
        _DateFrom = Request.Form["DateFrom"];
        _DateTo = Request.Form["DateTo"];
        DataSet dsReportData = objPatientReportsDB.GetPaymentByProcedure(PracticeId, Rows, 0, "Code ASC", _DateFrom, _DateTo);
        rptPaymentByProcedure.DataSource = dsReportData.Tables[0];
        rptPaymentByProcedure.DataBind();
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=Payment-By-Procedure.xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";
        GetTotal();
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        rptPaymentByProcedure.RenderControl(hw);
        Response.Output.Write(sw.ToString());
        Response.Flush();
        Response.End();
    }
    public void repeaterExportToPDF(object sender, EventArgs e)
    {
        int Rows = Convert.ToInt32(hdnTotalRows.Value);
        _DateFrom = Request.Form["DateFrom"];
        _DateTo = Request.Form["DateTo"];
        DataTable dtReportData = objPatientReportsDB.GetTotalPaymentByProcedure(Profile.PracticeId, Rows, 0, "PatientName asc", _DateFrom, _DateTo);
        
        Document document = new Document();
        Response.ContentType = "application/pdf"; Response.AddHeader("content-disposition", "attachment;filename=Payment-By-Procedure.pdf");
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
        table.AddCell(new Phrase("Code", font5));
        table.AddCell(new Phrase("Description", font5));
        table.AddCell(new Phrase("Avg Payement By Primary", font5));
        table.AddCell(new Phrase("Avg Payement By Sacondary", font5));
        table.AddCell(new Phrase("Avg Payement By Patient", font5));
        table.AddCell(new Phrase("Avg Total Payment", font5));

        foreach (DataRow r in dtReportData.Rows)
        {
            if (dtReportData.Rows.Count > 0)
            {
                table.AddCell(new Phrase(r[0].ToString(), font5));
                table.AddCell(new Phrase(r[1].ToString(), font5));
                table.AddCell(new Phrase(r[2].ToString(), font5));
                table.AddCell(new Phrase("$" + r[3].ToString(), font5));
                table.AddCell(new Phrase("$" + r[4].ToString(), font5));
                table.AddCell(new Phrase("$" + r[5].ToString(), font5));
                table.AddCell(new Phrase("$" + r[6].ToString(), font5));
            }
        }
        /***************Footer************/
        Control FooterTemplate = rptPaymentByProcedure.Controls[rptPaymentByProcedure.Controls.Count - 1].Controls[0];
        if (dtReportData.Rows.Count > 0)
        {
            Label lblTotalLabel = FooterTemplate.FindControl("lblTotalLabel") as Label;
            lblTotalLabel.Text = "Average Evaluatin and Management";
            Label lblTotaAvgPaymentByPrimary = FooterTemplate.FindControl("lblTotaAvgPaymentByPrimary") as Label;
            Label lblTotalAvgPaymentBySecondary = FooterTemplate.FindControl("lblTotalAvgPaymentBySecondary") as Label;
            Label lblTotalAvgPaymentByPatient = FooterTemplate.FindControl("lblTotalAvgPaymentByPatient") as Label;
            Label lblTotalAvgTotalPayment = FooterTemplate.FindControl("lblTotalAvgTotalPayment") as Label;
            if (!string.IsNullOrEmpty(dtReportData.Rows[0]["AvgPaymentByPrimary"].ToString()))
            {
                float TotalAvgPaymentByPrimary = float.Parse(dtReportData.Compute("sum(AvgPaymentByPrimary)", string.Empty).ToString());
                lblTotaAvgPaymentByPrimary.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(TotalAvgPaymentByPrimary));
            }
            if (!string.IsNullOrEmpty(dtReportData.Rows[0]["AvgPaymentBySecondary"].ToString()))
            {
                float TotalAvgPaymentBySecondary = float.Parse(dtReportData.Compute("sum(AvgPaymentBySecondary)", string.Empty).ToString());
                lblTotalAvgPaymentBySecondary.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(TotalAvgPaymentBySecondary));
            }
            if (!string.IsNullOrEmpty(dtReportData.Rows[0]["AvgPaymentByPatient"].ToString()))
            {
                float TotalAvgPaymentByPatient = float.Parse(dtReportData.Compute("sum(AvgPaymentByPatient)", string.Empty).ToString());
                lblTotalAvgPaymentByPatient.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(TotalAvgPaymentByPatient));
            } if (!string.IsNullOrEmpty(dtReportData.Rows[0]["AvgTotalPayment"].ToString()))
            {
                float TotalAvgTotalPayment = float.Parse(dtReportData.Compute("sum(AvgTotalPayment)", string.Empty).ToString());
                lblTotalAvgTotalPayment.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(TotalAvgTotalPayment));
            }
            PdfPTable tableFooter = new PdfPTable(dtReportData.Columns.Count);
            float[] widthsFooter = new float[] { 10f, 10f, 10f, 0f };
            table.WidthPercentage = 100;
            PdfPCell cellFooter = new PdfPCell(new Phrase("Products"));
            table.AddCell(new Phrase("", font5));
            table.AddCell(new Phrase("", font5));
            table.AddCell(new Phrase(lblTotalLabel.Text, font5));
            table.AddCell(new Phrase(lblTotaAvgPaymentByPrimary.Text, font5));
            table.AddCell(new Phrase(lblTotalAvgPaymentBySecondary.Text, font5));
            table.AddCell(new Phrase(lblTotalAvgPaymentByPatient.Text, font5));
            table.AddCell(new Phrase(lblTotalAvgTotalPayment.Text, font5));

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
        _DateFrom = Request.Form["DateFrom"];
        _DateTo = Request.Form["DateTo"];
        DataSet dsReportData = objPatientReportsDB.GetPaymentByProcedure(PracticeId, Rows, 0, "Code ASC", _DateFrom, _DateTo);
        rptPaymentByProcedure.DataSource = dsReportData.Tables[0];
        rptPaymentByProcedure.DataBind();

        Response.Clear();
        Response.AddHeader("content-disposition", "attachment;filename=Payment-By-Procedure.doc");
        Response.Charset = "";
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = "application/vnd.word";
        GetTotal();
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
        rptPaymentByProcedure.RenderControl(htmlWrite);
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
    protected void rptPaymentByProcedure_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView drv = (DataRowView)e.Item.DataItem;
            string AvgPaymentByPrimary = drv["AvgPaymentByPrimary"].ToString();
            Label lblAvgPaymentByPrimary = (Label)e.Item.FindControl("lblAvgPaymentByPrimary");
            if (AvgPaymentByPrimary != "")
            {
                lblAvgPaymentByPrimary.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(AvgPaymentByPrimary));
            }
            string AvgPaymentBySecondary = drv["AvgPaymentBySecondary"].ToString();
            Label lblAvgPaymentBySecondary = (Label)e.Item.FindControl("lblAvgPaymentBySecondary");
            if (AvgPaymentBySecondary != "")
            {
                lblAvgPaymentBySecondary.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(AvgPaymentBySecondary));
            }
            string AvgPaymentByPatient = drv["AvgPaymentByPatient"].ToString();
            Label lblAvgPaymentByPatient = (Label)e.Item.FindControl("lblAvgPaymentByPatient");
            if (AvgPaymentByPatient != "")
            {
                lblAvgPaymentByPatient.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(AvgPaymentByPatient));
            }
            string AvgTotalPayment = drv["AvgTotalPayment"].ToString();
            Label lblAvgTotalPayment = (Label)e.Item.FindControl("lblAvgTotalPayment");
            if (AvgTotalPayment != "")
            {
                lblAvgTotalPayment.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(AvgTotalPayment));
            }
        }
    }
}