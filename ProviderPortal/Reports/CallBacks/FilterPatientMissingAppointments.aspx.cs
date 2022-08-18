using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class ProviderPortal_Reports_CallBacks_FilterPatientMissingAppointments : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.Form["action"];

        if (action == "Filter")
        {
            LoadReport();
        }
    }

    private void LoadReport()
    {
        long PatientId = long.Parse(Request.Form["PatientId"]);
        string PatientName = Request.Form["PatientName"];

        int Rows = int.Parse(Request.Form["Rows"]);
        int PageNumber = int.Parse(Request.Form["PageNumber"]);
        string SortBy = Request.Form["SortBy"];

        ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();

        DataSet dsReportData = objPatientReportsDB.PatientMissingAppointments(Profile.PracticeId, PatientId, PatientName, Rows, PageNumber, SortBy);

        rptReportData.DataSource = dsReportData.Tables[0];
        rptReportData.DataBind();

        //ltrTotalRows.Text = dsReportData.Tables[1].Rows[0]["TotalRows"].ToString();
        ltrTotalRows.Text = dsReportData.Tables[1].Rows.Count.ToString();
    }
}