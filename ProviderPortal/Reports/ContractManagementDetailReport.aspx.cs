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

public partial class ProviderPortal_Reports_ContractManagementDetailReport : System.Web.UI.Page
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
        PayerId = Request.Form["PayerId"];
        PatientId = Request.Form["PatientId"].ToString();
        ProcedureCode = Request.Form["ProcedureCode"];

        hdnPatId.Value = PatientId;
        hdnDateType.Value = DateType;
        hdnProviderId.Value = ProviderId;
        hdnPracticeLocationId.Value = PracticeLocationId;
        hdnProcedureCode.Value = ProcedureCode;
        hdnPayerId.Value = PayerId;
          //PracticeId, 10, 0, "PatientName asc", "", ProviderId, PracticeLocationId, PayerId, ProcedureCode, "", _DateFrom, _DateTo
        DataSet dsReportData = objPatientReportsDB.GetContractManagementDetail(PracticeId, 10, 0, "PatientName asc", DateType, ProviderId, PracticeLocationId, PayerId, ProcedureCode, PatientId, _DateFrom, _DateTo);

        rptContractManagementDetail.DataSource = dsReportData.Tables[0];
        rptContractManagementDetail.DataBind();
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
        PayerId = Request.Form["PayerId"];
        PatientId = Request.Form["PatientId"].ToString();
        ProcedureCode = Request.Form["ProcedureCode"];
        DataTable dtReportData = objPatientReportsDB.GetTotalContractManagementDetail(Profile.PracticeId, Rows, 0, "PatientName asc", DateType, ProviderId, PracticeLocationId, PayerId, ProcedureCode, "", _DateFrom, _DateTo);
        Control FooterTemplate = rptContractManagementDetail.Controls[rptContractManagementDetail.Controls.Count - 1].Controls[0];
        if (dtReportData.Rows.Count > 0)
        {
            Label lblGranAverage = FooterTemplate.FindControl("lblGranAverage") as Label;
            lblGranAverage.Text = "Grand Average";
            if (!string.IsNullOrEmpty(dtReportData.Rows[0]["Charges"].ToString()))
            {
                float TotalCharges = float.Parse(dtReportData.Compute("sum(Charges)", string.Empty).ToString());
                Label lblTotalCharges = FooterTemplate.FindControl("lblTotalCharges") as Label;
                lblTotalCharges.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(TotalCharges));
            }
            if (!string.IsNullOrEmpty(dtReportData.Rows[0]["ActAllowed"].ToString()))
            {
                float TotalActAllowed = float.Parse(dtReportData.Compute("sum(ActAllowed)", string.Empty).ToString());
                Label lblTotalActAllowed = FooterTemplate.FindControl("lblTotalActAllowed") as Label;
                lblTotalActAllowed.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(TotalActAllowed));
            }
        }
    }

    private void SetDatesObjects()
    {

        _TimeSpan = Request.Form["TimeSpan"];
        _DateFrom = Request.Form["BillDateFrom"];
        _DateTo = Request.Form["BillDateTo"];

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
        PayerId = Request.Form["PayerId"];
        PatientId = Request.Form["PatientId"].ToString();
        ProcedureCode = Request.Form["ProcedureCode"];
        DataSet dsReportData = objPatientReportsDB.GetContractManagementDetail(PracticeId, Rows, 0, "PatientName asc", DateType, ProviderId, PracticeLocationId, PayerId, ProcedureCode, PatientId, _DateFrom, _DateTo);
        rptContractManagementDetail.DataSource = dsReportData.Tables[0];
        rptContractManagementDetail.DataBind();
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=Contract-Management-Detail.xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";
        GetTotal();
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        rptContractManagementDetail.RenderControl(hw);
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
        PayerId = Request.Form["PayerId"];
        PatientId = Request.Form["PatientId"].ToString();
        ProcedureCode = Request.Form["ProcedureCode"];
        DataTable dtReportData = objPatientReportsDB.GetTotalContractManagementDetail(Profile.PracticeId, Rows, 0, "PatientName asc", DateType, ProviderId, PracticeLocationId, PayerId, ProcedureCode, "", _DateFrom, _DateTo);
        
        Document document = new Document();
        Response.ContentType = "application/pdf"; Response.AddHeader("content-disposition", "attachment;filename=Contract-Management-Detail.pdf");
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
        table.AddCell(new Phrase("Sevice Date", font5));
        table.AddCell(new Phrase("Post Date", font5));
        table.AddCell(new Phrase("Patient Id", font5));
        table.AddCell(new Phrase("Patient Name", font5));
        table.AddCell(new Phrase("Code", font5));
        table.AddCell(new Phrase("Description", font5));
        table.AddCell(new Phrase("Privider", font5));
        table.AddCell(new Phrase("Charges", font5));
        table.AddCell(new Phrase("Act Allowed Amount", font5));

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
                table.AddCell(new Phrase("$" + r[8].ToString(), font5));
                table.AddCell(new Phrase("$" + r[9].ToString(), font5));
            }
        }
        /***************Footer************/
         Control FooterTemplate = rptContractManagementDetail.Controls[rptContractManagementDetail.Controls.Count - 1].Controls[0];
        if (dtReportData.Rows.Count > 0)
        {
            Label lblGranAverage = FooterTemplate.FindControl("lblGranAverage") as Label;
            lblGranAverage.Text = "Grand Average";
            Label lblTotalCharges = FooterTemplate.FindControl("lblTotalCharges") as Label;
            Label lblTotalActAllowed = FooterTemplate.FindControl("lblTotalActAllowed") as Label;
            if (!string.IsNullOrEmpty(dtReportData.Rows[0]["Charges"].ToString()))
            {
                float TotalCharges = float.Parse(dtReportData.Compute("sum(Charges)", string.Empty).ToString());
                lblTotalCharges.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(TotalCharges));
            }
            if (!string.IsNullOrEmpty(dtReportData.Rows[0]["ActAllowed"].ToString()))
            {
                float TotalActAllowed = float.Parse(dtReportData.Compute("sum(ActAllowed)", string.Empty).ToString());
                lblTotalActAllowed.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(TotalActAllowed));
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
            table.AddCell(new Phrase(lblGranAverage.Text, font5));
            table.AddCell(new Phrase(lblTotalCharges.Text, font5));
            table.AddCell(new Phrase(lblTotalActAllowed.Text, font5));

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
        PayerId = Request.Form["PayerId"];
        PatientId = Request.Form["PatientId"].ToString();
        ProcedureCode = Request.Form["ProcedureCode"];
        DataSet dsReportData = objPatientReportsDB.GetContractManagementDetail(PracticeId, Rows, 0, "PatientName asc", DateType, ProviderId, PracticeLocationId, PayerId, ProcedureCode, PatientId, _DateFrom, _DateTo);
        rptContractManagementDetail.DataSource = dsReportData.Tables[0];
        rptContractManagementDetail.DataBind();

        Response.Clear();
        Response.AddHeader("content-disposition", "attachment;filename=Contract-Management-Detail.doc");
        Response.Charset = "";
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = "application/vnd.word";
        GetTotal();
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
        rptContractManagementDetail.RenderControl(htmlWrite);
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
    protected void rptContractManagementDetail_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView drv = (DataRowView)e.Item.DataItem;
            string Charges = drv["Charges"].ToString();
            Label lblCharges = (Label)e.Item.FindControl("lblCharges");
            if (Charges != "")
            {
                lblCharges.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(Charges));
            }
            string ActAllowed = drv["ActAllowed"].ToString();
            Label lblActAllowed = (Label)e.Item.FindControl("lblActAllowed");
            if (ActAllowed != "")
            {
                lblActAllowed.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(ActAllowed));
            }
        }
    }
}