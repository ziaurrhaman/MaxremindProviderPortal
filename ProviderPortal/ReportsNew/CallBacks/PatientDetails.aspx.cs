using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EMR_ReportsNew_CallBacks_PatientDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        //if(!string.IsNullOrEmpty(Request.Form["PatientIds"]))
        //{
        //    long PracticeId = Profile.PracticeId;
        //    DataSet dsReportData = objPatientReportsDB.PatientDetail(PracticeId, PatientIds, "PatientInfo");

        //    rptPatientDetailGeneralInfo.DataSource = dsReportData.Tables[0];
        //    rptPatientDetailGeneralInfo.DataBind();

        //    DataSet dsInsuranceReportData = objPatientReportsDB.PatientDetail(PracticeId, PatientIds, "");

        //    rptPatientInsurance.DataSource = dsInsuranceReportData.Tables[0];
        //    rptPatientInsurance.DataBind();
        //}
        //else
        //{
        //    long PracticeId = Profile.PracticeId;
        //    DataSet dsReportData = objPatientReportsDB.PatientDetail(PracticeId, "", "PatientInfo");

        //    rptPatientDetailGeneralInfo.DataSource = dsReportData.Tables[0];
        //    rptPatientDetailGeneralInfo.DataBind();

        //    DataSet dsInsuranceReportData = objPatientReportsDB.PatientDetail(PracticeId, "", "");

        //    rptPatientInsurance.DataSource = dsInsuranceReportData.Tables[0];
        //    rptPatientInsurance.DataBind();
        //}
      

   
    }
}