using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class ProviderPortal_Reports_AppointmentSummary : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadDropDowns();
        LoadReport();
    }

    private void LoadDropDowns()
    {
        ReportsSchedulingDB objSchedulingReportsDB = new ReportsSchedulingDB();

        DataSet dsFilterData = objSchedulingReportsDB.LoadFilterDropDowns_AppointmentSummary(Profile.PracticeId);

        DataTable dtLocations = dsFilterData.Tables[0];

        ddlPracticeLocations.DataSource = dtLocations;
        ddlPracticeLocations.DataValueField = "PracticeLocationsId";
        ddlPracticeLocations.DataTextField = "Name";
        ddlPracticeLocations.DataBind();
    }

    private void LoadReport()
    {
        ReportsSchedulingDB objDB = new ReportsSchedulingDB();

        DataSet dsReportData = objDB.AppointmentSummary(Profile.PracticeId, Profile.PracticeLocationsId, "", "", 10, 0, "AppointmentDate ASC");

        rptReportData.DataSource = dsReportData.Tables[0];
        rptReportData.DataBind();

        //hdnTotalRows.Value = dsReportData.Tables[1].Rows[0]["TotalRows"].ToString();
        hdnTotalRows.Value = dsReportData.Tables[1].Rows.Count.ToString();
    }

    protected void ddlExportTo_SelectedIndexChanged(object sender, EventArgs e)
    {
        Utility obj = new Utility();

        string html = hdnReportHtml.Value;
        string exportTo = ddlExportTo.SelectedValue;

        string FileName = "Appointment Summary";

        if (exportTo == "Excel")
        {
            obj.ExportToExcel(ref html, FileName);
        }
        else if (exportTo == "PDF")
        {
            obj.ExportToPDF(ref html, FileName);
        }
        else if (exportTo == "Word")
        {
            obj.ExportToWord(html, FileName);
        }
    }
}