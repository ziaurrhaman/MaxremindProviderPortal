using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProviderPortal_Reports_CheckSummary : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ERAMasterDB objERAMasterDB = new ERAMasterDB();
        // DataSet dsERAList = objERAMasterDB.PatientPayment_GetByPracticeId(Profile.PracticeId, "", "", "", "", "", true, 10, 0, "");

        DataSet dsERAList = objERAMasterDB.GetBySearchCriteria(Profile.PracticeId, "", "", "", "","", "", 10, 0, "CheckIssueDate Desc", false, false, false,"");

        DataTable dtERA = dsERAList.Tables[0];
        DataTable dtERATotalCount = dsERAList.Tables[1];

        rptClaimCheck.DataSource = dtERA;
        rptClaimCheck.DataBind();
        hdnTotalRowsClaimList.Value = dtERATotalCount.Rows[0]["TotalRows"].ToString();
        hdnTotalRows.Value = dtERATotalCount.Rows[0]["TotalRows"].ToString();
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

}