using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EMR_ReportsNew_filter_FilterRejectedDeniedClaims : System.Web.UI.Page
{
    string _DateTo = ""; string _DateFrom = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadReport();
    }

    private void LoadReport()
    {
        ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();
        long PracticeId = Profile.PracticeId;

        string DateType = Request.Form["Datetype"];
        _DateFrom = Request.Form["DateFrom"];
        _DateTo = Request.Form["DateTo"];
        string Insurance = Request.Form["Insurance"];
        string ClaimStatus = Request.Form["ClaimStatus"];
        string BilledAs = Request.Form["BilledAs"]; //
        string POSCode = Request.Form["POSCode"];
        int Rows = int.Parse(Request.Form["Rows"]);
        int PageNumber = int.Parse(Request.Form["PageNumber"]);
        string SortBy = Request.Form["SortBy"];
         bool? IsImportedDataOnly = null;
        
        
        if (!string.IsNullOrEmpty(Session["IsImported"] as string))
        {
            
            if (Session["IsImported"].ToString() == "2") { IsImportedDataOnly = true; }
            else if (Session["IsImported"].ToString() == "1") { IsImportedDataOnly = false; }
            else { IsImportedDataOnly = null; }
        }
        string Aging = Request.Form["aging"];


        DataSet dsReportData = objPatientReportsDB.GetRejectedDeniedClaims(PracticeId, Insurance, BilledAs, ClaimStatus, Aging, IsImportedDataOnly);

        rptReportData.DataSource = dsReportData.Tables[0];
        rptReportData.DataBind();
        ltrTotalRows.Text = dsReportData.Tables[1].Rows[0]["TotalRows"].ToString();

    }
}