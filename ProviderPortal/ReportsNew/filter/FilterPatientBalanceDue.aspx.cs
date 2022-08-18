using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class EMR_ReportsNew_filter_FilterPatientBalanceDue : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string Rows = Request.Form["Rows"].ToString();
        string PageNumber = Request.Form["PageNumber"].ToString();
       
        string PatientId = ""; string PatientName = "";
        if (!string.IsNullOrEmpty(Request.Form["patientId"]))
        {
            PatientId = Request.Form["patientId"].ToString();
        }
        else
        {
            PatientId = "";
        }
        if (!string.IsNullOrEmpty(Request.Form["patientName"]))
        {
            PatientName = Request.Form["patientName"];
        }
        else
        {
            PatientName = "";
        }
        
         ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();

        DataSet dsReportData = objPatientReportsDB.PatientBalanceDue(Profile.PracticeId,PatientId,PatientName, Convert.ToInt32(Rows),Convert.ToInt32(PageNumber), "");

        rptReportData.DataSource = dsReportData.Tables[0];
        rptReportData.DataBind(); 


       ltrTotalRows.Text   = dsReportData.Tables[1].Rows[0]["TotalRows"].ToString();
    }
}