using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EMR_ReportsNew_filter_FilterPatientVisits : System.Web.UI.Page
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
        int Rows = 0; int PageNumber = 0;
        //long PracticeLocationsId = long.Parse(Request.Form["PracticeLocationsId"]);
        long? PracticeLocationsId = null;
        //long ServiceProviderId = long.Parse(Request.Form["ServiceProviderId"]);
        long? ServiceProviderId = null;
        if (!string.IsNullOrEmpty(Request.Form["Rows"]))
        {
             Rows = int.Parse(Request.Form["Rows"]);
        }
        else
        {
             Rows = 10;
        }
       

        if (!string.IsNullOrEmpty(Request.Form["PageNumber"]))
        {
            PageNumber = int.Parse(Request.Form["PageNumber"]);
        }
        else
        {
             PageNumber = 0;
        }
        string SortBy = Request.Form["SortBy"];
        string DateFrom = Request.Form["DateFrom"];
        string DateTo = Request.Form["DateTo"];

        PatientDB objPatientDB = new PatientDB();

        DataSet dsReportData = objPatientDB.PATIENTVISITS(Rows, PageNumber, SortBy, Profile.PracticeId, PracticeLocationsId, ServiceProviderId,DateFrom, DateTo);

        rptReportData.DataSource = dsReportData.Tables[0];
        rptReportData.DataBind();

        ltrTotalRows.Text = dsReportData.Tables[1].Rows[0]["TotalRows"].ToString();
    }
}