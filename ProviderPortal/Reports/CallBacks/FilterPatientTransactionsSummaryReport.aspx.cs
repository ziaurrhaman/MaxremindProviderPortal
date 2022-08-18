using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProviderPortal_Reports_CallBacks_FilterPatientTransactionsSummaryReport : System.Web.UI.Page
{
    string _DateFrom = "";
    string _DateTo = "";
    string _TimeSpan = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();
        long PracticeId = Profile.PracticeId;
        _DateFrom = Request.QueryString["DateFrom"];
        _DateTo = Request.QueryString["DateTo"];
        int Rows = int.Parse(Request.Form["Rows"]);
        int PageNumber = int.Parse(Request.Form["PageNumber"]);
        string SortBy= Request.Form["SortBy"];
        DataSet dsReportData = objPatientReportsDB.PatientTransactionsSummary(PracticeId, Rows, PageNumber, SortBy, _DateFrom, _DateTo);

        rptPatientTransactionsSummary.DataSource = dsReportData.Tables[0];
        rptPatientTransactionsSummary.DataBind();
        ltrTotalRows.Text = dsReportData.Tables[1].Rows[0]["TotalRows"].ToString();
    }
}