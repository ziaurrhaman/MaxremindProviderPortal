using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EMR_ReportsNew_CallBacks_PatientBalanceSummaryReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();
        long PracticeId = Profile.PracticeId;
        string AsOf = Request.Form["DateTo"];

        hdnAssignedTo.Value = "Insurance";
        hdnDOB.Value = AsOf;
        hdnCustomDate.Value = "Today";


        DataSet dsReportData = objPatientReportsDB.GetTotalRowsPatientBalanceSummary(PracticeId, 10, 0, "PatientId ASC", "Insurance", "Today", AsOf);

        rptPatientBalanceSummary.DataSource = dsReportData.Tables[0];
        rptPatientBalanceSummary.DataBind();
     

        hdnTotalRows.Value = dsReportData.Tables[1].Rows[0]["TotalRows"].ToString();
   
        string[] date = AsOf.Split(new Char[] { '-' });
        //string MonthName = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(int.Parse(date[1]));
        TimeSpan.Text = date[1] + "/" + date[2] + "/" + date[0];

    }
}