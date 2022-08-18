using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class EMR_ReportsNew_filter_FilterClaimsSubmissionStatusSummary : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadReport();
    }
    private void LoadReport()
    {
        string PracticeLocationsId = (Request.Form["Location"]);

        int Rows = int.Parse(Request.Form["Rows"]);
        int PageNumber = int.Parse(Request.Form["PageNumber"]);
        string SortBy = Request.Form["SortBy"];
        string DateFrom = Request.Form["Datefrom"];
        string DateTo = Request.Form["DateTo"];
        string DateType = Request.Form["DateType"];
        if (DateType == "" || DateType == null)
        {
            DateType = "PostDate";
        }

        ReportsFinancialDB objDB = new ReportsFinancialDB();

        DataSet dsReportData = objDB.ClaimSubmissionStatusSummary(Profile.PracticeId, PracticeLocationsId, Rows, PageNumber, SortBy, DateFrom, DateTo, DateType);

        rptReportData.DataSource = dsReportData.Tables[0];
        rptReportData.DataBind();

        //ltrTotalRows.Text = dsReportData.Tables[1].Rows[0]["TotalRows"].ToString();
        ltrTotalRows.Text = dsReportData.Tables[1].Rows[0]["TotalRows"].ToString();
        string[] _DateFrom = DateFrom.Split(new Char[] { '-' });
        string[] _DateTo = DateTo.Split(new Char[] { '-' });
        TimeSpan.Text = _DateFrom[1] + "/" + _DateFrom[2] + "/" + _DateFrom[0] + "-" + _DateTo[1] + "/" + _DateTo[2] + "/" + _DateTo[0];
        hdnDateFrom.Value = DateFrom;
        hdnDateTo.Value = DateTo;
        hdnDateType.Value = DateType;
        hdnLocations.Value = PracticeLocationsId;
        //hdnTotalRows.Value = Rows.ToString();

    }

}