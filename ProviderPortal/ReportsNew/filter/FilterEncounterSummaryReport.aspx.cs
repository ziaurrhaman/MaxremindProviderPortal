using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EMR_ReportsNew_filter_FilterEncounterSummaryReport : System.Web.UI.Page
{
    string _DateFrom = "";
    string _DateTo = "";
    string _TimeSpan = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();
        long PracticeId = Profile.PracticeId;
        int Rows = int.Parse(Request.Form["Rows"]);
        int PageNumber = int.Parse(Request.Form["PageNumber"]);
        string SortBy = Request.Form["SortBy"];
        string DateType = Request.Form["DateType"];
        _DateFrom = Request.Form["DateFrom"];
        _DateTo = Request.Form["DateTo"];
        string ProviderId = Request.Form["ProviderId"];
        string PracticeLocationId = Request.Form["PracticeLocationId"];
        string PayerId = Request.Form["PayerId"];
        string SubmissionStatusId = Request.Form["SubmissionStatus"];
        
        DataSet dsReportData = objPatientReportsDB.GetEncounterSummary(PracticeId, Rows, PageNumber, SortBy, DateType, SubmissionStatusId, _DateFrom, _DateTo, ProviderId, PracticeLocationId, PayerId);
        rptReportData.DataSource = dsReportData.Tables[0];
        rptReportData.DataBind();
        ltrTotalRows.Text = dsReportData.Tables[1].Rows[0]["TotalRows"].ToString();
    }
}