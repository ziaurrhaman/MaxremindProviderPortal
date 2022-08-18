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
public partial class ProviderPortal_Reports_ContractManagementSummaryReport : System.Web.UI.Page
{
    string _DateFrom = "";
    string _DateTo = "";
    string _TimeSpan = ""; string DateType; string ProviderId;
    string PracticeLocationId; string PayerId;
    string PatientId; string ProcedureCode;
    ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadReport();
    }
    private void LoadReport()
    {
        lblInsuranceName.Text = Request.Form["InsuranceName"];
        string insuid = Request.Form["insuid"];
        long PracticeId = Profile.PracticeId;
        _DateFrom = Request.Form["BillDateFrom"];
        _DateTo = Request.Form["BillDateTo"];
        if (Request.Form["DateType"] == "0")
        {
            DateType = "";
        }
        else
        {
            DateType = Request.Form["DateType"];
        }


        ProviderId = Request.Form["ProviderId"];
        PracticeLocationId = Request.Form["PracticeLocationId"];

        PatientId = Request.Form["PatientId"].ToString();
        ProcedureCode = Request.QueryString["ProcedureCode"];
        hdnPatId.Value = PatientId;
        hdnDateType.Value = DateType;
        hdnProviderId.Value = ProviderId;
        hdnPracticeLocationId.Value = PracticeLocationId;
        hdnProcedureCode.Value = ProcedureCode;


        long InsuranceId = Convert.ToInt64(Request.Form["insuid"]);
        hdnInsuranceId.Value = InsuranceId.ToString();
            //;DateType, ProviderId, PracticeLocationId, PayerId, ProcedureCode, PatientId, _DateFrom, _DateTo
        DataSet dsReportData = objPatientReportsDB.GetContractManagementSummary(PracticeId, 10, 0, "Procedure asc", DateType, ProviderId, PracticeLocationId, ProcedureCode, PatientId, _DateFrom, _DateTo, InsuranceId);

        rptContractManagementSummary.DataSource = dsReportData.Tables[0];
        rptContractManagementSummary.DataBind();
        hdnTotalRows.Value = dsReportData.Tables[1].Rows[0]["TotalRows"].ToString();

        GetTotal();
        SetDatesObjects();

    }

    private void SetDatesObjects()
    {

        _TimeSpan = Request.QueryString["TimeSpan"];
        _DateFrom = Request.QueryString["BillDateFrom"];
        _DateTo = Request.QueryString["BillDateTo"];

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
    protected void GetTotal()
    {
        int Rows = int.Parse(hdnTotalRows.Value);
        long InsuranceId = Convert.ToInt64(Request.Form["insuid"]);
        _DateFrom = Request.Form["BillDateFrom"];
        _DateTo = Request.Form["BillDateTo"];
        string insuid = Request.Form["insuid"];
        long PracticeId = Profile.PracticeId;
        _DateFrom = Request.Form["BillDateFrom"];
        _DateTo = Request.Form["BillDateTo"];
        if (Request.Form["DateType"] == "0")
        {
            DateType = "";
        }
        else
        {
            DateType = Request.Form["DateType"];
        }


        ProviderId = Request.Form["ProviderId"];
        PracticeLocationId = Request.Form["PracticeLocationId"];

        PatientId = Request.Form["PatientId"].ToString();
        ProcedureCode = Request.Form["ProcedureCode"];
        DataTable dtReportData = objPatientReportsDB.GetTotalContractManagementSummary(Profile.PracticeId, Rows, 0, "Procedure asc", DateType, ProviderId, PracticeLocationId, ProcedureCode, PatientId, _DateFrom, _DateTo, InsuranceId);
        Control FooterTemplate = rptContractManagementSummary.Controls[rptContractManagementSummary.Controls.Count - 1].Controls[0];
        Label lblTotal = FooterTemplate.FindControl("lblTotal") as Label;
        lblTotal.Text = "Total";

        Label lblPracticeName = FooterTemplate.FindControl("lblPracticeName") as Label;
        lblPracticeName.Text = Profile.PracticeName;

        if (dtReportData.Rows.Count > 0)
        {
            if (!string.IsNullOrEmpty(dtReportData.Rows[0]["AllowedAmount"].ToString()))
            {
                float TotalAllowedAmount = float.Parse(dtReportData.Compute("sum(AllowedAmount)", string.Empty).ToString());
                Label lblTotalAllowedAmount = FooterTemplate.FindControl("lblTotalAllowedAmount") as Label;
                lblTotalAllowedAmount.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(TotalAllowedAmount));
            }
            if (!string.IsNullOrEmpty(dtReportData.Rows[0]["AVGPayment"].ToString()))
            {
                float TotalAVGPayment = float.Parse(dtReportData.Compute("sum(AVGPayment)", string.Empty).ToString());
                Label lblTotalAVGPayment = FooterTemplate.FindControl("lblTotalAVGPayment") as Label;
                lblTotalAVGPayment.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(TotalAVGPayment));
            }
        }

    }
    protected void ExportToExcel(object sender, EventArgs e)
    {

        int Rows = Convert.ToInt32(hdnTotalRows.Value);
        long PracticeId = Profile.PracticeId;
        string insuid = Request.Form["insuid"];
        _DateFrom = Request.Form["BillDateFrom"];
        _DateTo = Request.Form["BillDateTo"];
        if (Request.Form["DateType"] == "0")
        {
            DateType = "";
        }
        else
        {
            DateType = Request.Form["DateType"];
        }


        ProviderId = Request.Form["ProviderId"];
        PracticeLocationId = Request.Form["PracticeLocationId"];

        PatientId = Request.Form["PatientId"].ToString();
        ProcedureCode = Request.Form["ProcedureCode"];
        long InsuranceId = long.Parse(Request.QueryString["insuid"]);
        DataSet dsReportData = objPatientReportsDB.GetContractManagementSummary(PracticeId, Rows, 0, "Procedure asc", DateType, ProviderId, PracticeLocationId, ProcedureCode, PatientId, _DateFrom, _DateTo, InsuranceId);
        rptContractManagementSummary.DataSource = dsReportData.Tables[0];
        rptContractManagementSummary.DataBind();
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=Contract-Management-Summary.xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";
        GetTotal();
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        rptContractManagementSummary.RenderControl(hw);
        Response.Output.Write(sw.ToString());
        Response.Flush();
        Response.End();
    }
    public void repeaterExportToPDF(object sender, EventArgs e)
    {
        
        int Rows = int.Parse(hdnTotalRows.Value);
        long InsuranceId = Convert.ToInt64(Request.Form["insuid"]);
        _DateFrom = Request.Form["BillDateFrom"];
        _DateTo = Request.Form["BillDateTo"];
        string insuid = Request.Form["insuid"];
        long PracticeId = Profile.PracticeId;
        _DateFrom = Request.Form["BillDateFrom"];
        _DateTo = Request.Form["BillDateTo"];
        if (Request.Form["DateType"] == "0")
        {
            DateType = "";
        }
        else
        {
            DateType = Request.Form["DateType"];
        }


        ProviderId = Request.Form["ProviderId"];
        PracticeLocationId = Request.Form["PracticeLocationId"];

        PatientId = Request.Form["PatientId"].ToString();
        ProcedureCode = Request.Form["ProcedureCode"];
        DataTable dtReportData = objPatientReportsDB.GetTotalContractManagementSummary(Profile.PracticeId, Rows, 0, "Procedure asc", DateType, ProviderId, PracticeLocationId, ProcedureCode, PatientId, _DateFrom, _DateTo, InsuranceId);
        
        Document document = new Document();
        Response.ContentType = "application/pdf"; Response.AddHeader("content-disposition", "attachment;filename=Contract-Management-Summary.pdf");
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
        table.AddCell(new Phrase("Procedure", font5));
        table.AddCell(new Phrase("Average Allowed", font5));
        table.AddCell(new Phrase("Average Payment", font5));

        foreach (DataRow r in dtReportData.Rows)
        {
            if (dtReportData.Rows.Count > 0)
            {
                
                table.AddCell(new Phrase(r[0].ToString(), font5));
                table.AddCell(new Phrase(r[1].ToString(), font5));
                table.AddCell(new Phrase("$" + r[2].ToString(), font5));
                table.AddCell(new Phrase("$" + r[3].ToString(), font5));
            }
        }
        /***************Footer************/
        Control FooterTemplate = rptContractManagementSummary.Controls[rptContractManagementSummary.Controls.Count - 1].Controls[0];
        Label lblTotal = FooterTemplate.FindControl("lblTotal") as Label;
        lblTotal.Text = "Total";
        Label lblPracticeName = FooterTemplate.FindControl("lblPracticeName") as Label;
        lblPracticeName.Text = Profile.PracticeName;
        if (dtReportData.Rows.Count > 0)
        {
            Label lblTotalAllowedAmount = FooterTemplate.FindControl("lblTotalAllowedAmount") as Label;
            Label lblTotalAVGPayment = FooterTemplate.FindControl("lblTotalAVGPayment") as Label;
            if (!string.IsNullOrEmpty(dtReportData.Rows[0]["AllowedAmount"].ToString()))
            {
                float TotalAllowedAmount = float.Parse(dtReportData.Compute("sum(AllowedAmount)", string.Empty).ToString());
                lblTotalAllowedAmount.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(TotalAllowedAmount));
            }
            if (!string.IsNullOrEmpty(dtReportData.Rows[0]["AVGPayment"].ToString()))
            {
                float TotalAVGPayment = float.Parse(dtReportData.Compute("sum(AVGPayment)", string.Empty).ToString());
                lblTotalAVGPayment.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(TotalAVGPayment));
            }
            PdfPTable tableFooter = new PdfPTable(dtReportData.Columns.Count);
            float[] widthsFooter = new float[] { 10f, 10f, 10f, 0f };
            table.WidthPercentage = 100;
            PdfPCell cellFooter = new PdfPCell(new Phrase("Products"));
            table.AddCell(new Phrase("", font5));
            table.AddCell(new Phrase(lblTotal.Text + " " + lblPracticeName.Text, font5));
            table.AddCell(new Phrase(lblTotalAllowedAmount.Text, font5));
            table.AddCell(new Phrase(lblTotalAVGPayment.Text, font5));

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
        _DateFrom = Request.Form["BillDateFrom"];
        _DateTo = Request.Form["BillDateTo"];
        long InsuranceId = long.Parse(Request.Form["insuid"]);
        string insuid = Request.Form["insuid"];
        _DateFrom = Request.Form["BillDateFrom"];
        _DateTo = Request.Form["BillDateTo"];
        if (Request.Form["DateType"] == "0")
        {
            DateType = "";
        }
        else
        {
            DateType = Request.Form["DateType"];
        }


        ProviderId = Request.Form["ProviderId"];
        PracticeLocationId = Request.Form["PracticeLocationId"];

        PatientId = Request.Form["PatientId"].ToString();
        ProcedureCode = Request.Form["ProcedureCode"];
        DataSet dsReportData = objPatientReportsDB.GetContractManagementSummary(PracticeId, Rows, 0, "Procedure asc", DateType, ProviderId, PracticeLocationId, ProcedureCode, PatientId, _DateFrom, _DateTo, InsuranceId);
        rptContractManagementSummary.DataSource = dsReportData.Tables[0];
        rptContractManagementSummary.DataBind();

        Response.Clear();
        Response.AddHeader("content-disposition", "attachment;filename=Contract-Management-Summary.doc");
        Response.Charset = "";
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = "application/vnd.word";
        GetTotal();
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
        rptContractManagementSummary.RenderControl(htmlWrite);
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
    protected void rptContractManagementSummary_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView drv = (DataRowView)e.Item.DataItem;
            string AllowedAmount = drv["AllowedAmount"].ToString();
            Label lblAllowedAmount = (Label)e.Item.FindControl("lblAllowedAmount");
            if (AllowedAmount != "")
            {
                lblAllowedAmount.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(AllowedAmount));
            }
            string AVGPayment = drv["AVGPayment"].ToString();
            Label lblAVGPayment = (Label)e.Item.FindControl("lblAVGPayment");
            if (AVGPayment != "")
            {
                lblAVGPayment.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(AVGPayment));
            }
        }
    }
}