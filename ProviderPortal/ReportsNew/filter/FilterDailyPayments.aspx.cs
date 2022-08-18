using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class EMR_ReportsNew_filter_FilterDailyPayments : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadReport();
    }
    private void LoadReport()
    {
        string CheckIssueDate = "";
        string PostDate = "";
        string Date = Request.Form["DateFrom"];
        int Rows = int.Parse(Request.Form["Rows"]);
        int PageNumber = int.Parse(Request.Form["PageNumber"]);
        string SortBy = Request.Form["SortBy"];
        string DateType = Request.Form["DateType"];

        if (DateType == "CheckIssueDate")
        {
            CheckIssueDate = Date;
        }
        else if (DateType == "PostDate")
        {
            PostDate = Date;
        }

        ERAMasterDB objERAMasterDB = new ERAMasterDB();

        DataSet dsReportData = objERAMasterDB.Report_DailyPayments(Profile.PracticeId, Rows, PageNumber, SortBy, DateType, CheckIssueDate, PostDate);

        rptReportData.DataSource = dsReportData.Tables[0];
        rptReportData.DataBind();

        ltrTotalRows.Text = dsReportData.Tables[1].Rows[0]["TotalRows"].ToString();
    }

    protected void rptReportData_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        DataRowView drv = (DataRowView)e.Item.DataItem;

        string PaymentType = drv["PaymentType"].ToString().Trim();

        if (PaymentType == "PAT")
        {
            PaymentType = "Patient";
        }
        else
        {
            PaymentType = "Insurance";
        }

        Label lblPaymentSource = (Label)e.Item.FindControl("lblPaymentSource");

        lblPaymentSource.Text = PaymentType;
    }
}