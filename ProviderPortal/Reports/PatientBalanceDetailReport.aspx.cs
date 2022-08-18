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

public partial class ProviderPortal_Reports_PatientBalanceDetailReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();
        long PatientIds = long.Parse(Request.Form["SearchedPatientId"].ToString());
        hdnPatientId.Value = Request.Form["PatientIds"].ToString();
        hdnProcedureCode.Value = Request.Form["ProcedureCode"].ToString();
        hdnDOB.Value = Request.Form["AsOf"].ToString();
        hdnCustomDate.Value = Request.Form["CustomDate"].ToString();
        long PracticeId = Profile.PracticeId;
        string ProcedureCode = Request.Form["ProcedureCode"];
        string DOB = Request.Form["AsOf"];
        string CustomDate = Request.Form["CustomDate"];
        DataSet dsReportData = objPatientReportsDB.dsPatientBalanceDetail(PracticeId, 10, 0, "servicedate asc", PatientIds, ProcedureCode, CustomDate, DOB);
        DataTable dtReportData = objPatientReportsDB.PatientBalanceDetail(PracticeId, 10, 0, "servicedate asc", PatientIds, ProcedureCode, CustomDate, DOB);

        rptPatientBalanceDetail.DataSource = dsReportData;
        rptPatientBalanceDetail.DataBind();
        Control FooterTemplate = rptPatientBalanceDetail.Controls[rptPatientBalanceDetail.Controls.Count - 1].Controls[0];
        if (dtReportData.Rows.Count > 0)
        {
            if (!string.IsNullOrEmpty(dtReportData.Rows[0]["charges"].ToString()))
            {
                float TotalCharges = float.Parse(dtReportData.Compute("sum(charges)", string.Empty).ToString());
                Label lblTotalCharges = FooterTemplate.FindControl("lblTotalCharges") as Label;
                lblTotalCharges.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(TotalCharges));
            }
        }
        if (dtReportData.Rows.Count > 0)
        {
            if (!string.IsNullOrEmpty(dtReportData.Rows[0]["adjustments"].ToString()))
            {
                float TotalAdjustments = float.Parse(dtReportData.Compute("sum(adjustments)", string.Empty).ToString());
                Label lblTotalAdjustments = FooterTemplate.FindControl("lblTotalAdjustments") as Label;
                lblTotalAdjustments.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(TotalAdjustments));
            }
        }

        if (dtReportData.Rows.Count > 0)
        {
            if (!string.IsNullOrEmpty(dtReportData.Rows[0]["Insurancepmt"].ToString()))
            {
                float TotalInsurancePayments = float.Parse(dtReportData.Compute("sum(Insurancepmt)", string.Empty).ToString());
                Label lblTotalInsurancePayments = FooterTemplate.FindControl("lblTotalInsurancePayments") as Label;
                lblTotalInsurancePayments.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(TotalInsurancePayments));
            }
        }
        if (dtReportData.Rows.Count > 0)
        {
            if (!string.IsNullOrEmpty(dtReportData.Rows[0]["PatientPmt"].ToString()))
            {
                float TotalPatientPayments = float.Parse(dtReportData.Compute("sum(PatientPmt)", string.Empty).ToString());
                Label lblTotalPatientPayments = FooterTemplate.FindControl("lblTotalPatientPayments") as Label;
                lblTotalPatientPayments.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(TotalPatientPayments));
            }
        }

        if (dtReportData.Rows.Count > 0)
        {
            if (!string.IsNullOrEmpty(dtReportData.Rows[0]["PatientPmt"].ToString()))
            {
                float TotalBalance = float.Parse(dtReportData.Compute("sum(TotalBalance)", string.Empty).ToString());
                Label lblTotalBalance = FooterTemplate.FindControl("lblGrandTotalBalance") as Label;
                lblTotalBalance.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(TotalBalance));
            }
        }
        if (dtReportData.Rows.Count > 0)
        {
            if (!string.IsNullOrEmpty(dtReportData.Rows[0]["PendingIns"].ToString()))
            {
                float TotalPendingIns = float.Parse(dtReportData.Compute("sum(PendingIns)", string.Empty).ToString());
                Label lblPendingIns = FooterTemplate.FindControl("lblPendingIns") as Label;
                lblPendingIns.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(TotalPendingIns));
            }
        }

        if (dtReportData.Rows.Count > 0)
        {
            if (!string.IsNullOrEmpty(dtReportData.Rows[0]["Patientbalance"].ToString()))
            {
                float TotalPatientbalance = float.Parse(dtReportData.Compute("sum(Patientbalance)", string.Empty).ToString());
                Label lblPatientbalance = FooterTemplate.FindControl("lblPatientbalance") as Label;
                lblPatientbalance.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(TotalPatientbalance));
            }
        }


        hdnTotalRows.Value = dsReportData.Tables[1].Rows[0]["TotalRows"].ToString();
    }
    protected void divExportToExcel(object sender, EventArgs e)
    {
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=Patient-Balance-Claims-List-Report.xls");
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
        Response.AddHeader("content-disposition", "attachment;filename=Patient-Balance-Details.pdf");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        //rptPatientDetailGeneralInfo.DataBind();
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
        Response.AddHeader("content-disposition", "attachment;filename=Patient-Balance-Details.doc");
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

        if (exportTo == "Excel")
        {
            divExportToExcel(sender, e);
        }
        else if (exportTo == "PDF")
        {
            divExportToPDF(sender, e);
        }
        else if (exportTo == "Word")
        {
            divExportToWord(sender, e);
        }
    }
    protected void rptPatientBalanceDetail_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView drv = (DataRowView)e.Item.DataItem;
            if (!string.IsNullOrEmpty(drv["charges"].ToString()))
            {
                string charges = string.Format("{0:0,0.00}", Convert.ToDouble(drv["charges"].ToString()));
                Label lblCharges = (Label)e.Item.FindControl("lblCharges");
                lblCharges.Text = "$" + charges;
            }
            if (!string.IsNullOrEmpty(drv["adjustments"].ToString()))
            {
                string adjustments = string.Format("{0:0,0.00}", Convert.ToDouble(drv["adjustments"].ToString()));
                Label lbladjustments = (Label)e.Item.FindControl("lbladjustments");
                lbladjustments.Text = "$" + adjustments;
            }
            if (!string.IsNullOrEmpty(drv["Insurancepmt"].ToString()))
            {
                string Insurancepmt = string.Format("{0:0,0.00}", Convert.ToDouble(drv["Insurancepmt"].ToString()));
                Label lblInsurancepmt = (Label)e.Item.FindControl("lblInsurancepmt");
                lblInsurancepmt.Text = "$" + Insurancepmt;
            }
            if (!string.IsNullOrEmpty(drv["PatientPmt"].ToString()))
            {
                string PatientPmt = string.Format("{0:0,0.00}", Convert.ToDouble(drv["PatientPmt"].ToString()));
                Label lblPatientPmt = (Label)e.Item.FindControl("lblPatientPmt");
                lblPatientPmt.Text = "$" + PatientPmt;
            }
            if (!string.IsNullOrEmpty(drv["TotalBalance"].ToString()))
            {
                string TotalBalance = string.Format("{0:0,0.00}", Convert.ToDouble(drv["TotalBalance"].ToString()));
                Label lblTotalBalance = (Label)e.Item.FindControl("lblTotalBalance");
                lblTotalBalance.Text = "$" + TotalBalance;
            }
            if (!string.IsNullOrEmpty(drv["PendingIns"].ToString()))
            {
                string PendingIns = string.Format("{0:0,0.00}", Convert.ToDouble(drv["PendingIns"].ToString()));
                Label lblPendingIns = (Label)e.Item.FindControl("lblPendingIns");
                lblPendingIns.Text = "$" + PendingIns;
            }
            if (!string.IsNullOrEmpty(drv["Patientbalance"].ToString()))
            {
                string Patientbalance = string.Format("{0:0,0.00}", Convert.ToDouble(drv["Patientbalance"].ToString()));
                Label lblPatientbalance = (Label)e.Item.FindControl("lblPatientbalance");
                lblPatientbalance.Text = "$" + Patientbalance;
            }

        }
    }
}