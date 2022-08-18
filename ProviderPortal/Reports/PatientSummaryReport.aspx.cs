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

public partial class ProviderPortal_Reports_PatientSummaryReport : System.Web.UI.Page
{
    string _DateFrom = "";
    string _DateTo = "";
    string _TimeSpan = "";
    ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();
 
    protected void Page_Load(object sender, EventArgs e)
    {
        long PracticeId = Profile.PracticeId;
        hdnPracticeId.Value = Convert.ToString(Profile.PracticeId);
        string DateType = Request.Form["DateType"];
        string ProviderId = Request.Form["ProviderId"];
        string PracticeLocationId = Request.Form["PracticeLocationId"];
        string PayerId = Request.Form["PayerId"];
        string DateFrom = Request.Form["BillDateFrom"];
        string DateTo = Request.Form["BillDateTo"];

        hdnPayer.Value = PayerId;
        hdnProvider.Value = ProviderId;
        hdnLocation.Value = PracticeLocationId;

        DataSet dsReportData = objPatientReportsDB.PatientSummary(PracticeId, 10, 0, "Payer ASC", DateType, ProviderId, PracticeLocationId, PayerId, DateFrom, DateTo);
        // string subTotal = dtReportData.Rows[1]["TotalPatient"].ToString();

        rptPatientSummary.DataSource = dsReportData.Tables[0];
        rptPatientSummary.DataBind();
        //Control FooterTemplate = rptPatientSummary.Controls[rptPatientSummary.Controls.Count - 1].Controls[0];
        //Label lblPracticeName = FooterTemplate.FindControl("lblPracticeName") as Label;
        lblPracticeName.Text = Profile.PracticeName;
        hdnTotalRows.Value = dsReportData.Tables[1].Rows[0]["TotalRows"].ToString();
        int Rows = int.Parse(hdnTotalRows.Value);
        DataTable dtReportData = objPatientReportsDB.GetTotalPatientSummary(PracticeId, Rows, 0, "Payer ASC", DateType, ProviderId, PracticeLocationId, PayerId, DateFrom, DateTo);
        if (dtReportData.Rows.Count > 0)
        {
            if (!string.IsNullOrEmpty(dtReportData.Rows[0]["TotalPatient"].ToString()))
            {
                int Total = int.Parse(dtReportData.Compute("sum(TotalPatient)", string.Empty).ToString());
                //Label lblTotal = FooterTemplate.FindControl("lblTotal") as Label;
                lblTotal.Text = Convert.ToString(Total);
            }
        }
        SetDatesObjects();
        GetTotal();
    }





    public void GetTotal()
    {

       /* long PracticeId = Profile.PracticeId;
        hdnPracticeId.Value = Convert.ToString(Profile.PracticeId);
        string DateType = Request.QueryString["DateType"];
        string ProviderId = Request.QueryString["ProviderId"];
        string PracticeLocationId = Request.QueryString["PracticeLocationId"];
        string PayerId = Request.QueryString["PayerId"];
        string DateFrom = Request.QueryString["BillDateFrom"];
        string DateTo = Request.QueryString["BillDateTo"];

        int Rows = int.Parse(hdnTotalRows.Value);
        DataTable dtReportData = dtReportData = objPatientReportsDB.GetTotalPatientSummary(PracticeId, Rows, 0, "Payer ASC", DateType, ProviderId, PracticeLocationId, PayerId, DateFrom, DateTo);

        Control FooterTemplate = rptPatientSummary.Controls[rptPatientSummary.Controls.Count - 1].Controls[0];
        if (dtReportData.Rows.Count > 0)
        {
            Label lblPracticeName = FooterTemplate.FindControl("lblPracticeName") as Label;
            lblPracticeName.Text = "Total Universal EMR System";
            if (!string.IsNullOrEmpty(dtReportData.Rows[0]["TotalPatient"].ToString()))
            {
                float TotalUnits = float.Parse(dtReportData.Compute("sum(TotalPatient)", string.Empty).ToString());
                Label lblTotal = FooterTemplate.FindControl("lblTotal") as Label;
                lblTotal.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(TotalUnits));
            }
        }
        */

    }


    protected void ExportToExcel(object sender, EventArgs e)
    {

        int Rows = Convert.ToInt32(hdnTotalRows.Value);
        long PracticeId = Profile.PracticeId;
        ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();
        string DateType = Request.Form["DateType"];
        string ProviderId = Request.Form["ProviderId"];
        string PracticeLocationId = Request.Form["PracticeLocationId"];
        string PayerId = Request.Form["PayerId"];
        _DateFrom = Request.Form["BillDateFrom"];
        _DateTo = Request.Form["BillDateTo"];
        DataSet dsReportData = objPatientReportsDB.PatientSummary(PracticeId, Rows, 0, "Payer ASC", DateType, ProviderId, PracticeLocationId, PayerId, _DateFrom, _DateTo);
        rptPatientSummary.DataSource = dsReportData.Tables[0];
        rptPatientSummary.DataBind();
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=Patient-Summary-Report.xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";
        GetTotal();
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        rptPatientSummary.RenderControl(hw);
        Response.Output.Write(sw.ToString());
        Response.Flush();
        Response.End();
    }
    public void repeaterExportToPDF(object sender, EventArgs e)
    {
        /*int Rows = Convert.ToInt32(hdnTotalRows.Value);
        long PracticeId = Profile.PracticeId;
        ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();
        string DateType = Request.QueryString["DateType"];
        string ProviderId = Request.QueryString["ProviderId"];
        string PracticeLocationId = Request.QueryString["PracticeLocationId"];
        string PayerId = Request.QueryString["PayerId"];
        _DateFrom = Request.QueryString["BillDateFrom"];
        _DateTo = Request.QueryString["BillDateTo"];
        DataSet dsReportData = objPatientReportsDB.PatientSummary(PracticeId, Rows, 0, "Payer ASC", DateType, ProviderId, PracticeLocationId, PayerId, _DateFrom, _DateTo);
        rptPatientSummary.DataSource = dsReportData.Tables[0];
        rptPatientSummary.DataBind();*/
        Response.ContentType = "application/pdf";
        Response.AddHeader("content-disposition", "attachment;filename=Patient-Summary-Report.pdf");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        GetTotal();
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
    public void repeaterExportToWord(object sender, EventArgs e)
    {
        int Rows = Convert.ToInt32(hdnTotalRows.Value);
        long PracticeId = Profile.PracticeId;
        ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();
        string DateType = Request.Form["DateType"];
        string ProviderId = Request.Form["ProviderId"];
        string PracticeLocationId = Request.Form["PracticeLocationId"];
        string PayerId = Request.Form["PayerId"];
        _DateFrom = Request.Form["BillDateFrom"];
        _DateTo = Request.Form["BillDateTo"];
        DataSet dsReportData = objPatientReportsDB.PatientSummary(PracticeId, Rows, 0, "Payer ASC", DateType, ProviderId, PracticeLocationId, PayerId, _DateFrom, _DateTo);
        rptPatientSummary.DataSource = dsReportData.Tables[0];
        rptPatientSummary.DataBind();

        Response.Clear();
        Response.AddHeader("content-disposition", "attachment;filename=Patient-Summary-Report.doc");
        Response.Charset = "";
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = "application/vnd.word";
        GetTotal();
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
        rptPatientSummary.RenderControl(htmlWrite);
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
    private void SetDatesObjects()
    {

        _TimeSpan = Request.Form["NewTimeSpan"];
        _DateFrom = Request.Form["BillDateFrom"];
        _DateTo = Request.Form["BillDateTo"];

        hdnTimeSpan.Value = _TimeSpan;
        hdnDateFrom.Value = _DateFrom;
        hdnDateTo.Value = _DateTo;

        DateTime now = DateTime.Now;

        if (_TimeSpan == "All")
        {
            _DateFrom = "";
            _DateTo = "";
            lblReportTimeSpanFrom.Text = "All Records";
        }
        else if (_TimeSpan == "HasDate")
        {
            separateSpan.Style.Remove("display");
            lblReportTimeSpanFrom.Text = _DateFrom;
            lblReportTimeSpanTo.Text = _DateTo;
        }
    }
    protected void rptPatientSummary_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Footer)
        {
            /*DataRowView drv = (DataRowView)e.Item.DataItem;
            int subTotal =int.Parse(drv["TotalPatient"].ToString());
            Label lblPracticeName = (Label)e.Item.FindControl("lblPracticeName");
            lblPracticeName.Text = Profile.PracticeName;
            Label lblTotal = (Label)e.Item.FindControl("lblTotal");
            lblTotal.Text = Convert.ToString(subTotal += subTotal);*/

        }
    }
}