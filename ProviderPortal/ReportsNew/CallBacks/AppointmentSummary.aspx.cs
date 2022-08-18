using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class EMR_ReportsNew_CallBacks_AppointmentSummary : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ReportsSchedulingDB objDB = new ReportsSchedulingDB();

        DataSet dsReportData = objDB.AppointmentSummary(Profile.PracticeId, Profile.PracticeLocationsId, "", "", 10, 0, "AppointmentDate ASC");

        rptReportData.DataSource = dsReportData.Tables[0];
        rptReportData.DataBind();

        //hdnTotalRows.Value = dsReportData.Tables[1].Rows[0]["TotalRows"].ToString();
        hdnTotalRows.Value = dsReportData.Tables[1].Rows.Count.ToString();

        ddlLocation();
      

    }
    protected void ddlLocation()
    {
        ReportsSchedulingDB objSchedulingReportsDB = new ReportsSchedulingDB();

        DataSet dsFilterData = objSchedulingReportsDB.LoadFilterDropDowns_AppointmentSummary(Profile.PracticeId);

        DataTable dtLocations = dsFilterData.Tables[0];

        ddlPracticeLocations.DataSource = dtLocations;
        ddlPracticeLocations.DataValueField = "PracticeLocationsId";
        ddlPracticeLocations.DataTextField = "Name";
        ddlPracticeLocations.DataBind();
    }
}