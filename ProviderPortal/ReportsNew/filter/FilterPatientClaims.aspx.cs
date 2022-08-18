using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EMR_ReportsNew_filter_FilterPatientClaims : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadReport();
    }

    private void LoadReport()
    {
        int Rows = int.Parse(Request.Form["Rows"]);
        int PageNumber = int.Parse(Request.Form["PageNumber"]);
        string SortBy = "";
        if (Request.Form["SortBy"] == "" || Request.Form["SortBy"] == null)
        {
            SortBy = "DOS DESC";
        }
        else
        {
            SortBy = Request.Form["SortBy"];
        }

        ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();

        long PracticeId = Profile.PracticeId;
        DataSet dsReportData = objPatientReportsDB.PatientClaims(PracticeId, 0, "", Rows, PageNumber, SortBy);

        rptReportData.DataSource = dsReportData.Tables[0];
        rptReportData.DataBind();

        ltrTotalRows.Text = dsReportData.Tables[1].Rows[0]["TotalRows"].ToString();
    }
}