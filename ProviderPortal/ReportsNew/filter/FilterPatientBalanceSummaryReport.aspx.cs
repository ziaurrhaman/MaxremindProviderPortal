using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EMR_ReportsNew_filter_FilterPatientBalanceSummaryReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();
        long PracticeId = Profile.PracticeId;
        int Rows = int.Parse(Request.Form["Rows"]);
        int PageNumber = int.Parse(Request.Form["PageNumber"]);
        string SortBy = Request.Form["SortBy"];
        string AssignedTo = Request.Form["AssignedTo"];
        string AsOf = Request.Form["AsOf"];
        string CustomDate = Request.Form["CustomDate"];
        if (CustomDate == "yesterday" || CustomDate == "today")
        {
            //AsOf = "";
        }
        else
        {
            AsOf = Request.Form["AsOf"];
            CustomDate = "Custom";
        }
        DataSet dsReportData = objPatientReportsDB.GetTotalRowsPatientBalanceSummary(PracticeId, Rows, PageNumber, SortBy, AssignedTo, CustomDate, AsOf);

        rptReportData.DataSource = dsReportData.Tables[0];
        rptReportData.DataBind();
        ltrTotalRows.Text = dsReportData.Tables[1].Rows[0]["TotalRows"].ToString();
        hdnAssignedTo.Value = AssignedTo;
        hdnDOB.Value = AsOf;
        hdnCustomDate.Value = CustomDate;
        AsOf = Request.Form["AsOf"];
        string[] date = AsOf.Split(new Char[] { '-' });
        //string MonthName = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(int.Parse(date[1]));
        TimeSpan.Text = date[1] + "/" + date[2] + "/" + date[0];
    }
}