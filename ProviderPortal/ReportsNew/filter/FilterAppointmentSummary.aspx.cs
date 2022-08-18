using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class EMR_ReportsNew_filter_FilterAppointmentSummary : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        long Location = long.Parse(Request.Form["Location"]);
        string DateFrom = Request.Form["DateFrom"];
        string DateTo = Request.Form["DateTo"];
        int Rows = int.Parse(Request.Form["Rows"]);
        int PageNumber = int.Parse(Request.Form["PageNumber"]);
      //  string SortBy = Request.Form["SortBy"];

        ReportsSchedulingDB objDB = new ReportsSchedulingDB();

        DataSet dsReportData = objDB.AppointmentSummary(Profile.PracticeId, Location, DateFrom, DateTo, Rows, PageNumber, "");

        rptReportData.DataSource = dsReportData.Tables[0];
        rptReportData.DataBind();

        //ltrTotalRows.Text = dsReportData.Tables[1].Rows[0]["TotalRows"].ToString();
        ltrTotalRows.Text = dsReportData.Tables[1].Rows.Count.ToString();
    }
}