using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI; 
using System.Web.UI.WebControls;

public partial class ProviderPortal_Reports_CallBacks_FilterPatientSummaryReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();
        long PracticeId = Profile.PracticeId;
        string DateType = Request.Form["DateType"];
        string ProviderId = Request.Form["ProviderId"];
        string PracticeLocationId = Request.Form["LocationId"];
        string PayerId = Request.Form["PayerId"];
        string DateFrom = Request.Form["DateFrom"];
        string DateTo = Request.Form["DateTo"];
        int Rows = int.Parse(Request.Form["Rows"]);
        int PageNumber = int.Parse(Request.Form["PageNumber"]);
        string SortBy = Request.Form["SortBy"];
        DataSet dsReportData = objPatientReportsDB.PatientSummary(PracticeId, Rows, PageNumber, SortBy, DateType, ProviderId, PracticeLocationId, PayerId, DateFrom, DateTo);

        rptPatientSummary.DataSource = dsReportData.Tables[0];
        rptPatientSummary.DataBind();
        ltrTotalRows.Text = dsReportData.Tables[1].Rows[0]["TotalRows"].ToString();
    }
}