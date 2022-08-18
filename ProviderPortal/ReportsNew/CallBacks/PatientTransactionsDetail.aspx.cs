using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EMR_ReportsNew_CallBacks_PatientTransactionsDetail : System.Web.UI.Page
{
    string _DateFrom = "";
    string _DateTo = "";
    string _DateType = "";
    string _TimeSpan = "";
    decimal _totalpayment = 0;
    string _patientid = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadReport();
        GetLocationsByDefault();
        GetProvidersByDefault();
        lbltotalPayment.Text = "$" + string.Format("{0:0,0.00}", _totalpayment);
       
    }
    private void LoadReport()
    {
        ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();
        long PracticeId = Profile.PracticeId;

        _DateFrom = Request.Form["DateFrom"];
        _DateTo = Request.Form["DateTo"];
        _DateType = "PostDate";

        hdnDateFrom.Value = Request.Form["DateFrom"];
        hdnDateTo.Value = Request.Form["DateTo"];
        if (_patientid == "")
        {
            _patientid = !string.IsNullOrEmpty(Request.Form["PatientIds"]) ? Request.Form["PatientIds"] : "";
            hdnPatientId.Value = _patientid;
        }
        DataSet dsReportData = objPatientReportsDB.GetPatientTransactionsDetail(PracticeId, 10, 0, "Patient ASC", _patientid.TrimEnd(','), _DateFrom, _DateTo, _DateType, "","","");

        rptPatientTransactionsDetail.DataSource = dsReportData.Tables[0];
        rptPatientTransactionsDetail.DataBind();
        hdnTotalRows.Value = dsReportData.Tables[1].Rows[0]["TotalRows"].ToString();
        hdnDateFrom.Value = _DateFrom.ToString();
        hdnDateTo.Value = _DateTo.ToString();
        hdnDateType.Value = _DateType.ToString();

        string[] DateFrom = _DateFrom.Split(new Char[] { '-' });
        string[] DateTo = _DateTo.Split(new Char[] { '-' });


        TimeSpan.Text = DateFrom[1] + "/" + DateFrom[2] + "/" + DateFrom[0] + "-" + DateTo[1] + "/" + DateTo[2] + "/" + DateTo[0];
    }
    public void GetLocationsByDefault()
    {
        long PracticeId = Profile.PracticeId;
        ReportsDB db = new ReportsDB();

        DataTable dtPracticeLocation = db.GetLocationsByDefault(PracticeId);
        rptLocation.DataSource = dtPracticeLocation;
        rptLocation.DataBind();
    }
    public void GetProvidersByDefault()
    {
        string PracticeLocationId = Request.Form["PracticeLocationId"];
        ReportsDB db = new ReportsDB();
        DataTable ds = db.GetProvidersByDefault(Profile.PracticeId);
        DynamicProviders.DataSource = ds;
        DynamicProviders.DataBind();
    }
    protected void rptPatientTransactionsDetail_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView drv = (DataRowView)e.Item.DataItem;
            Label lblPayment = (Label)e.Item.FindControl("lblPayment");
        if (!string.IsNullOrEmpty(drv["Payment"].ToString()))
            { lblPayment.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(drv["Payment"].ToString()));
            _totalpayment += Convert.ToDecimal(drv["Payment"]);
            }
        }
    }
}