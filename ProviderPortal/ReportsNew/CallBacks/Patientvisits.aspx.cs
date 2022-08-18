using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
public partial class EMR_ReportsNew_CallBacks_Patientvisits : System.Web.UI.Page
{
    PatientDB objPatientDB = new PatientDB();
    protected void Page_Load(object sender, EventArgs e)
    {

        LoadReport();
       
    }
    private void LoadReport()
    {

        if (!string.IsNullOrEmpty(Request.Form["action"]) && Request.Form["action"] == "PrintRequest")
        {
            string ExportTo = Request.Form["Export"].ToString();
            string ReportHtml = Request.Form["ReportHtml"].ToString();
   
        }
        DataSet ds = objPatientDB.PATIENTVISITS(10, 0, "", Profile.PracticeId, 0, 0, "","");

        rptReportData.DataSource = ds.Tables[0];
        rptReportData.DataBind();

        hdnTotalRows.Value = ds.Tables[1].Rows[0]["TotalRows"].ToString();






    }


   
}