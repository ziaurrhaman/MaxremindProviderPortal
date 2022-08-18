using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class EMR_ReportsNew_filter_FilterPatientMissingAppointments : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string PatientId = ""; string PatientName = "";
        if (!string.IsNullOrEmpty(Request.Form["PatientId"]))
        {
             PatientId = Request.Form["PatientId"].ToString();
        }
        else
        {
            PatientId = "0";
        }
        if (!string.IsNullOrEmpty(Request.Form["PatientName"]))
        {
            PatientName = Request.Form["PatientName"];
        }
        else
        {
            PatientName = "";
        }
        
        

        int Rows = int.Parse(Request.Form["Rows"]);
        int PageNumber = int.Parse(Request.Form["PageNumber"]);
        string SortBy = Request.Form["SortBy"];

        ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();

        DataSet dsReportData = objPatientReportsDB.PatientMissingAppointments(Profile.PracticeId, Convert.ToInt64(PatientId), PatientName, Rows, PageNumber, SortBy);

        rptReportData.DataSource = dsReportData.Tables[0];
        rptReportData.DataBind();

        //ltrTotalRows.Text = dsReportData.Tables[1].Rows[0]["TotalRows"].ToString();
        ltrTotalRows.Text = dsReportData.Tables[1].Rows.Count.ToString();
    }
}