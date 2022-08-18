using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProviderPortal_ReportsNew_filter_FilterMostCommonlyUsedDxCodes : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ReportsPatientDB Rptdb = new ReportsPatientDB();
        int RowNumber = Convert.ToInt32(Request.Form["Rows"]);
        int PageNumber = int.Parse(Request.Form["PageNumber"]);
        string DiagnosisCode = Request.Form["DiagnosisCode"];
        ClaimChargesDB objClaimChargesDB = new ClaimChargesDB();
        DataSet ds = Rptdb.Top10Diagnosis(RowNumber, PageNumber, Profile.PracticeId, DiagnosisCode);
        rptReport.DataSource = ds.Tables[0];
        rptReport.DataBind();

        ltrTotalRow.Text = ds.Tables[1].Rows[0]["TotalRows"].ToString();
    }
}