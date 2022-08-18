using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class EMR_ReportsNew_CallBacks_PatientBalanceDue : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();

        DataSet dsReportData = objPatientReportsDB.PatientBalanceDue(Profile.PracticeId, "", "", 10, 0, "");

        rptReportData.DataSource = dsReportData.Tables[0];
        rptReportData.DataBind();

      
        hdnTotalRows.Value = dsReportData.Tables[1].Rows[0]["TotalRows"].ToString();
    }
}