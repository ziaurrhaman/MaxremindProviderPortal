using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProviderPortal_Reports_ClaimStatus : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadReport();
    }

    protected void LoadReport()
    {
        ReportsFinancialDB objDB = new ReportsFinancialDB();

        DataSet dsReportData = objDB.ClaimPayments(Profile.PracticeId, 10, 0, "DOS ASC");



        rptReportData.DataSource = dsReportData.Tables[0];
        rptReportData.DataBind();

        hdnTotalRows.Value = dsReportData.Tables[1].Rows[0]["TotalRows"].ToString();
    }

    protected void ddlExportTo_SelectedIndexChanged(object sender, EventArgs e)
    {
        Utility obj = new Utility();

        string html = hdnReportHtml.Value;
        string exportTo = ddlExportTo.SelectedValue;

        string FileName = "Claim Payment";

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
    protected void rptReportData_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {

    }
}