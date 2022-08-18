using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProviderPortal_ReportsNew_CallBacks_PatientTransactionsSummaryDetail : System.Web.UI.Page
{
    string _DateFrom = "";
    string _DateTo = "";
    string _DateType = "";
    string _TimeSpan = "";
    decimal _totalpayment = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
       
        string _patientid = Request.Form["PatientId"];
        ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();
        long PracticeId = Profile.PracticeId;

        string SortBy = Request.Form["SortBy"];
        string Providerid = Request.Form["Providerid"];
        string PracticeLocationId = Request.Form["PracticeLocationId"];
        string CPTCode = Request.Form["CPTCode"];
        _DateFrom = Request.Form["DateFrom"];
        _DateTo = Request.Form["DateTo"];
        _DateType = Request.Form["DateType"];

        DataSet dsReportData = objPatientReportsDB.GetPatientTransactionsDetail(PracticeId, 10000, 0, "PatientId ASC", _patientid, _DateFrom, _DateTo, _DateType, "", "", "");

        rptPatientTransactionsDetail.DataSource = dsReportData.Tables[0];
        rptPatientTransactionsDetail.DataBind();
        lbltotalPayment.Text = "$" + string.Format("{0:0,0.00}", _totalpayment);

    }
    protected void rptPatientTransactionsDetail_ItemDataBound(object sender, RepeaterItemEventArgs e)
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