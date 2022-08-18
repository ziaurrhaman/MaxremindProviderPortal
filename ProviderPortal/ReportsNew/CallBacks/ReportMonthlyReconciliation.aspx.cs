using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EMR_ReportsNew_CallBacks_ReportMonthlyReconciliation : System.Web.UI.Page
{
    string LocationId = "";
    string Location = "";
    string DateFrom = "";
    string DateTo = "";
    string month = "";
    string Year = "";
    int monthInDigit = 0;
    int lastDay = 0;
    string ProviderType = "";
    string Provider = "";
    ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadReport();
    }
    private void LoadReport()
    {
        ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();
        long PracticeId = Profile.PracticeId;
        if (!string.IsNullOrEmpty(Request.Form["Location"]))
        {
            Location = Request.Form["Location"];
            LblLocation.Text = Location;
        }
        if (!string.IsNullOrEmpty(Request.Form["LocationId"]))
        {
            LocationId = Request.Form["LocationId"];
            hdnLocationId.Value = Request.Form["LocationId"];
        }

        Provider = Request.Form["ProviderName"];
        ProviderType = Request.Form["ProviderType"];
        hdnProvider.Value = Provider;
        hdnProviderType.Value = ProviderType;
        if (!string.IsNullOrEmpty(Request.Form["Month"]))
        {
            month = Request.Form["Month"];
            if (month == "January")
            {
                month = "01";
            }
            else if (month == "February")
            {
                month = "02";
            }
            else if (month == "March")
            {
                month = "03";
            }
            else if (month == "April")
            {
                month = "04";
            }
            else if (month == "May")
            {
                month = "05";
            }
            else if (month == "June")
            {
                month = "06";
            }
            else if (month == "July")
            {
                month = "07";
            }
            else if (month == "August")
            {
                month = "08";
            }
            else if (month == "September")
            {
                month = "09";
            }
            else if (month == "October")
            {
                month = "10";
            }
            else if (month == "November")
            {
                month = "11";
            }
            else if (month == "December")
            {
                month = "12";
            }
            monthInDigit = int.Parse(month);
        }
        if (!string.IsNullOrEmpty(Request.Form["Year"]))
        {
            Year = Request.Form["Year"];
        }
        int getYear = int.Parse(Year);
        lastDay = DateTime.DaysInMonth(getYear, monthInDigit);
        DateFrom = Convert.ToString(monthInDigit) + "/" + "1/" + Year;
        hdnDateFrom.Value = DateFrom;
        DateTo = Convert.ToString(monthInDigit) + "/" + Convert.ToString(lastDay) + "/" + Year;
        TimeSpan.Text = DateFrom+" - "+DateTo ;
      
        hdnDateTo.Value = DateTo;
      
        DataSet dsReportData = objPatientReportsDB.GetMonthlyReconciliation(PracticeId, 10, 0, "", ProviderType, long.Parse(LocationId), DateFrom, DateTo, Provider);

        rptMonthlyReconciliation.DataSource = dsReportData.Tables[0];
        rptMonthlyReconciliation.DataBind();
        hdnTotalRows.Value = dsReportData.Tables[1].Rows[0]["TotalRows"].ToString();
        lblTotalClaims.Text = dsReportData.Tables[2].Rows[0]["TotalClaims"].ToString();
        lblTotalPatients.Text = dsReportData.Tables[2].Rows[0]["TotalPatients"].ToString();

    }

    protected void rptMonthlyReconciliation_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView drv = (DataRowView)e.Item.DataItem;
            string checkNumber = drv["CheckNumber"].ToString();
            Label lblCheckNumber = (Label)e.Item.FindControl("lblCheckNumber");
            if (checkNumber == "")
            {
                lblCheckNumber.Style.Add("display", "none");
            }
            else
            {
                lblCheckNumber.Style.Add("display", "block");
            }
        }
    }
}