using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EMR_ReportsNew_filter_FilterPatientTransactionsDetail : System.Web.UI.Page
{
    string _DateFrom = "";
    string _DateTo = "";
    string _DateType = "";
    string _TimeSpan = "";
    decimal _totalpayment = 0;
    string _patientid = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();
        long PracticeId = Profile.PracticeId;
        int Rows = int.Parse(Request.Form["Rows"]);
        int PageNumber = int.Parse(Request.Form["PageNumber"]);
        string SortBy = Request.Form["SortBy"];
        string Providerid = Request.Form["Providerid"];
        string PracticeLocationId = Request.Form["PracticeLocationId"];
        string CPTCode = Request.Form["CPTCode"];
        _DateFrom = Request.Form["DateFrom"];
        _DateTo = Request.Form["DateTo"];
        _DateType = Request.Form["DateType"];

        if (_patientid == "")
        { _patientid = !string.IsNullOrEmpty(Request.Form["PatientIds"]) ? Request.Form["PatientIds"] : "";
        
        }
        DataSet dsReportData = objPatientReportsDB.GetPatientTransactionsDetail(PracticeId, Rows, PageNumber, SortBy, _patientid, _DateFrom, _DateTo, _DateType, Providerid, PracticeLocationId, CPTCode);

        rptReportData.DataSource = dsReportData.Tables[0];
        rptReportData.DataBind();
        ltrTotalRows.Text = dsReportData.Tables[1].Rows[0]["TotalRows"].ToString();
        lbltotalPayment.Text = "$" + string.Format("{0:0,0.00}", _totalpayment);
        hdnDateFrom.Value = _DateFrom.ToString();
        hdnDateTo.Value = _DateTo.ToString();
        hdnDateType.Value = _DateType.ToString();
        hdnLocation.Value = PracticeLocationId;
        hdnPatientId.Value = _patientid;
        hdnProvider.Value = Providerid;
        hdnProcedure.Value = CPTCode;
        string[] DateFrom = _DateFrom.Split(new Char[] { '-' });
        string[] DateTo = _DateTo.Split(new Char[] { '-' });


        TimeSpan.Text = DateFrom[1] + "/" + DateFrom[2] + "/" + DateFrom[0] + "-" + DateTo[1] + "/" + DateTo[2] + "/" + DateTo[0];
    }
    protected void rptReportData_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView drv = (DataRowView)e.Item.DataItem;
            Label lblPayment = (Label)e.Item.FindControl("lblPayment");
            if (!string.IsNullOrEmpty(drv["Payment"].ToString()))
            {
                lblPayment.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(drv["Payment"].ToString()));
                _totalpayment += Convert.ToDecimal(drv["Payment"]);
            }
        }
    }
}