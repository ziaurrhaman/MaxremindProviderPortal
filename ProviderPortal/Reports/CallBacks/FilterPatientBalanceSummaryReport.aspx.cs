using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProviderPortal_Reports_CallBacks_FilterPatientBalanceSummaryReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ReportsPatientDB objPatientReportsDB = new ReportsPatientDB(); 
        long PracticeId = Profile.PracticeId; 
        int Rows = int.Parse(Request.Form["Rows"]);
        int PageNumber = int.Parse(Request.Form["PageNumber"]);
        string SortBy = Request.Form["SortBy"];
        DataSet dsReportData = objPatientReportsDB.GetTotalRowsPatientBalanceSummary(PracticeId, Rows, PageNumber, SortBy,"","","");

        rptPatientBalanceSummary.DataSource = dsReportData.Tables[0];
        rptPatientBalanceSummary.DataBind();
        ltrTotalRows.Text = dsReportData.Tables[1].Rows[0]["TotalRows"].ToString();
    }
}