using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EMR_ReportsNew_CallBacks_ChargesDetailReport : System.Web.UI.Page
{
    string _DateFrom = "";
    string _DateTo = "";
    string _TimeSpan = ""; string DateType; string ProviderId;
    string PracticeLocationId; string PayerId;
    string PatientId; string ProcedureCode; int Rows;
    ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    private void LoadReport()
    {
        long PracticeId = Profile.PracticeId;
        _DateFrom = Request.QueryString["BillDateFrom"];
        _DateTo = Request.QueryString["BillDateTo"];

        DateType = Request.QueryString["DateType"];
        ProviderId = Request.QueryString["ProviderId"];
        PracticeLocationId = Request.QueryString["PracticeLocationId"];
        PayerId = Request.QueryString["PayerId"];
        PatientId = Request.QueryString["PatientIds"];
        hdnPatId.Value = PatientId;
        ProcedureCode = Request.QueryString["ProcedureCode"];

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
        _DateFrom = Request.QueryString["BillDateFrom"];
        _DateTo = Request.QueryString["BillDateTo"];

        DateType = Request.QueryString["DateType"];
        ProviderId = Request.QueryString["ProviderId"];
        PracticeLocationId = Request.QueryString["PracticeLocationId"];
        PayerId = Request.QueryString["PayerId"];
        PatientId = Request.QueryString["PatientIds"];
        hdnPatId.Value = PatientId;
        ProcedureCode = Request.QueryString["ProcedureCode"];
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

        _TimeSpan = Request.QueryString["TimeSpan"];
        _DateFrom = Request.QueryString["BillDateFrom"];
        _DateTo = Request.QueryString["BillDateTo"];

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
            TimeSpan.Text = "All Records";
            //lblReportTimeSpanTo.Text = "Till Date";
        }
        else
        {
            TimeSpan.Style.Remove("display");
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

            TimeSpan.Text = _DateFrom + "-" + _DateTo;
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