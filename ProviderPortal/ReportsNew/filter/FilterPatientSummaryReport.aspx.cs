using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EMR_ReportsNew_filter_FilterPatientSummaryReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();
        long PracticeId = Profile.PracticeId;
        string DateType = Request.Form["DateType"];
        string ProviderId = Request.Form["ProviderId"];
        string PracticeLocationId = Request.Form["PracticeLocationId"];
        string PayerId = Request.Form["PayerId"];
        string DateFrom = Request.Form["DateFrom"];
        string DateTo = Request.Form["DateTo"];
        int Rows = int.Parse(Request.Form["Rows"]);
        int PageNumber = int.Parse(Request.Form["PageNumber"]);
        string SortBy = Request.Form["SortBy"];
        DataSet dsReportData = objPatientReportsDB.PatientSummary(PracticeId, Rows, PageNumber, SortBy, DateType, ProviderId, PracticeLocationId, PayerId, DateFrom, DateTo);

        rptReportData.DataSource = dsReportData.Tables[0];
        rptReportData.DataBind();
        DataTable dtReportData = dsReportData.Tables[0];
        if (dtReportData.Rows.Count > 0)
        {
            if (!string.IsNullOrEmpty(dtReportData.Rows[0]["TotalPatient"].ToString()))
            {
                int Total = int.Parse(dtReportData.Compute("sum(TotalPatient)", string.Empty).ToString());
                //Label lblTotal = FooterTemplate.FindControl("lblTotal") as Label;
                lblTotal.Text = Convert.ToString(Total);
            }
        }
        ltrTotalRows.Text = dsReportData.Tables[1].Rows[0]["TotalRows"].ToString();
        string[] _DateFrom = DateFrom.Split(new Char[] { '-' });
        string[] _DateTo = DateTo.Split(new Char[] { '-' });


        TimeSpan.Text = _DateFrom[1] + "/" + _DateFrom[2] + "/" + _DateFrom[0] + "-" + _DateTo[1] + "/" + _DateTo[2] + "/" + _DateTo[0];
        hdnDateFrom.Value = DateFrom;
        hdnDateTo.Value = DateTo;
        hdnDateType.Value = DateType;

        hdnPayer.Value = PayerId;
        hdnProvider.Value = ProviderId;
        hdnLocation.Value = PracticeLocationId;


    }
}