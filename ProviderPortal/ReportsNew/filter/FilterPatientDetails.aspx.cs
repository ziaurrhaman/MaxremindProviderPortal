using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EMR_ReportsNew_filter_FilterPatientDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();
        string PatientIds = Request.Form["PatientIds"].ToString();
        long PracticeId = Profile.PracticeId;
        DataSet dsReportData = objPatientReportsDB.PatientDetail(PracticeId, PatientIds, "PatientInfo");

        rptReportData.DataSource = dsReportData.Tables[0];
        rptReportData.DataBind();

        DataSet dsInsuranceReportData = objPatientReportsDB.PatientDetail(PracticeId, PatientIds, "");

        rptPatientInsurance.DataSource = dsInsuranceReportData.Tables[0];
        rptPatientInsurance.DataBind();
        hdnPatientId.Value = PatientIds;
    }
}