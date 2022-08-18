using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProviderPortal_Reports_PayerSubmissionStatus : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    private void LoadDropDowns()
    {
        ReportsFinancialDB objDB = new ReportsFinancialDB();

        DataSet dsFilterData = objDB.LoadFilterDropDowns_ClaimSubmissionStatusSummary(Profile.PracticeId);

        DataTable dtLocations = dsFilterData.Tables[0];

        ddlPracticeLocations.DataSource = dtLocations;
        ddlPracticeLocations.DataValueField = "PracticeLocationsId";
        ddlPracticeLocations.DataTextField = "Name";
        ddlPracticeLocations.DataBind();
    }

    private void LoadReport()
    {
        ReportsFinancialDB objDB = new ReportsFinancialDB();

        DataSet dsReportData = objDB.ClaimSubmissionStatusSummary(Profile.PracticeId, Profile.PracticeLocationsId, 10, 0, "InsuranceName ASC");

        rptReportData.DataSource = dsReportData.Tables[0];
        rptReportData.DataBind();

        //hdnTotalRows.Value = dsReportData.Tables[1].Rows[0]["TotalRows"].ToString();
        hdnTotalRows.Value = dsReportData.Tables[1].Rows.Count.ToString();
    }

    protected void ddlExportTo_SelectedIndexChanged(object sender, EventArgs e)
    {
        Utility obj = new Utility();

        string html = hdnReportHtml.Value;
        string exportTo = ddlExportTo.SelectedValue;

        string FileName = "Submission Status Summary";

        if (exportTo == "Excel")
        {
            obj.ExportToExcel(ref html, FileName);
        }
        else if (exportTo == "PDF")
        {
            obj.ExportToPDF(ref html, FileName);
        }
        else if (exportTo == "Word")
        {
            obj.ExportToWord(html, FileName);
        }
    }
}