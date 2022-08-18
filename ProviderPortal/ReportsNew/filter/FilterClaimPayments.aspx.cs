using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class EMR_ReportsNew_filter_FilterClaimPayments : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadReport();
    }
    private void LoadReport()
    {
        int Rows = int.Parse(Request.Form["Rows"]);
        int PageNumber = int.Parse(Request.Form["PageNumber"]);
        string SortBy = Request.Form["SortBy"];

        ReportsFinancialDB objDB = new ReportsFinancialDB();

        DataSet dsReportData = objDB.ClaimPayments(Profile.PracticeId, Rows, PageNumber, SortBy);

        rptReportData.DataSource = dsReportData.Tables[0];
        rptReportData.DataBind();

        ltrTotalRows.Text = dsReportData.Tables[1].Rows[0]["TotalRows"].ToString();
     
    }
}