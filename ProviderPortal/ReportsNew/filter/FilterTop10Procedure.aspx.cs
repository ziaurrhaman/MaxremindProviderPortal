using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProviderPortal_ReportsNew_filter_FilterTop10Procedure : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int RowNumber = Convert.ToInt32(Request.Form["Rows"].ToString());
        int PageNumber = int.Parse(Request.Form["PageNumber"]);
        string CptCode = Request.Form["CptCode"];
        ClaimChargesDB objClaimChargesDB = new ClaimChargesDB();
        DataSet ds = objClaimChargesDB.TOPTENPROCEDURES_SUMMARYReport(RowNumber, PageNumber, Profile.PracticeId, CptCode);
        rptReportData.DataSource = ds.Tables[0];
        rptReportData.DataBind();

        ltrTotalRows.Text = ds.Tables[1].Rows[0]["TotalRows"].ToString();

    }
}