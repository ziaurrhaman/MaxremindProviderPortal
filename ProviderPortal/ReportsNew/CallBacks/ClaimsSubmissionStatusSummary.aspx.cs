using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class EMR_ReportsNew_CallBacks_ClaimsSubmissionStatusSummary : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadReport();
        LoadPracticeLocation();
    }

    

    private void LoadReport()
    {
        ReportsFinancialDB objDB = new ReportsFinancialDB();
        string DateFrom = Request.Form["DateFrom"];
        string DateTo = Request.Form["DateTo"];
        string DateType = Request.Form["DateType"];
        if(DateType == "" || DateType == null)
        {
            DateType = "PostDate";
        }
        if (DateFrom != "" && DateTo != "")
        {

            string[] _DateFrom = DateFrom.Split(new Char[] { '-' });
            string[] _DateTo = DateTo.Split(new Char[] { '-' });
            TimeSpan.Text = _DateFrom[1] + "/" + _DateFrom[2] + "/" + _DateFrom[0] + "-" + _DateTo[1] + "/" + _DateTo[2] + "/" + _DateTo[0];
        }
        else
        {
            TimeSpan.Text = "All Records";
        }
        DataSet dsReportData = objDB.ClaimSubmissionStatusSummary(Profile.PracticeId, "", 10, 0, "InsuranceName ASC", DateFrom, DateTo, DateType);

        rptReportData.DataSource = dsReportData.Tables[0];
        rptReportData.DataBind();

        //hdnTotalRows.Value = dsReportData.Tables[1].Rows[0]["TotalRows"].ToString();
        hdnTotalRows.Value = dsReportData.Tables[1].Rows[0]["TotalRows"].ToString();
        hdnDateFrom.Value = DateFrom;
        hdnDateTo.Value = DateTo;
        hdnDateType.Value = DateType;
    }
    public void LoadPracticeLocation()
    {
        long PracticeId = Profile.PracticeId;
        ReportsDB db = new ReportsDB();

        DataTable dtPracticeLocation = db.GetLocationsByDefault(PracticeId);
        rptLocation.DataSource = dtPracticeLocation;
        rptLocation.DataBind();
    }
}