using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class EMR_ReportsNew_filter_FilterPatientPayments : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        long PracticeId = Profile.PracticeId;
        int Rows = int.Parse(Request.Form["Rows"]);
        int PageNumber = int.Parse(Request.Form["PageNumber"]);
        string SortBy = "";
        string DateType = Request.Form["DateType"].ToString();
        string DateFrom = Request.Form["DateFrom"].ToString();
        string DateTo = Request.Form["DateTo"].ToString();

        ERAMasterDB objERAMasterDB = new ERAMasterDB();

        DataSet dsReportData = objERAMasterDB.Report_PatientPayments(PracticeId, Rows, PageNumber, SortBy, DateType, DateFrom, DateTo);

        rptReportData.DataSource = dsReportData.Tables[0];
        rptReportData.DataBind();

        ltrTotalRows.Text = dsReportData.Tables[1].Rows[0]["TotalRows"].ToString();
    }
}