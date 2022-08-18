using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProviderPortal_Reports_CallBacks_PatientVitalSignHandler : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        PatientVitalsDb objPatientVitalsDb = new PatientVitalsDb();

        long PatientId = long.Parse(Request.Form["PatientId"]);
        string DateFrom = Request.Form["DateFrom"];
        string DateTo = Request.Form["DateTo"];

        DataSet dsVitalReport = objPatientVitalsDb.GetAllAsDataTable(PatientId, DateFrom, DateTo, 10, 0, "");

        string strReportPatientVitalSignGraphTable = Request.Form["objReportPatientVitalSignGraphTable"];
        
        JavaScriptSerializer objJavaScriptSerializer = new JavaScriptSerializer();
        
        ReportPatientVitalSignGraphTable objReportPatientVitalSignGraphTable = objJavaScriptSerializer.Deserialize<ReportPatientVitalSignGraphTable>(strReportPatientVitalSignGraphTable);

        if (objReportPatientVitalSignGraphTable.PulseTable)
        {
            rptPulse.DataSource = dsVitalReport.Tables[0];
            rptPulse.DataBind();
        }

        if (objReportPatientVitalSignGraphTable.TemperatureTable)
        {
            rptTemperature.DataSource = dsVitalReport.Tables[0];
            rptTemperature.DataBind();
        }

        if (objReportPatientVitalSignGraphTable.BloodPressureTable)
        {
            rptBloodPressure.DataSource = dsVitalReport.Tables[0];
            rptBloodPressure.DataBind();
        }

        if (objReportPatientVitalSignGraphTable.RespiratoryTable)
        {
            rptRespiratory.DataSource = dsVitalReport.Tables[0];
            rptRespiratory.DataBind();
        }

        if (objReportPatientVitalSignGraphTable.WeightTable)
        {
            rptWeight.DataSource = dsVitalReport.Tables[0];
            rptWeight.DataBind();
        }

        hdnTotalRowsPulse.Value = dsVitalReport.Tables[1].Rows[0]["TotalRows"].ToString();
        hdnTotalRowsTemperature.Value = dsVitalReport.Tables[1].Rows[0]["TotalRows"].ToString();
        hdnTotalRowsBloodPressure.Value = dsVitalReport.Tables[1].Rows[0]["TotalRows"].ToString();
        hdnTotalRowsRespiratory.Value = dsVitalReport.Tables[1].Rows[0]["TotalRows"].ToString();
        hdnTotalRowsWeight.Value = dsVitalReport.Tables[1].Rows[0]["TotalRows"].ToString();
    }
}