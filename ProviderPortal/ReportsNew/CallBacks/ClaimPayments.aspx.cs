using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class EMR_ReportsNew_CallBacks_ClaimPayments : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ReportsFinancialDB objDB = new ReportsFinancialDB();

        DataSet dsReportData = objDB.ClaimPayments(Profile.PracticeId, 10, 0, "DOS ASC");



        rptReportData.DataSource = dsReportData.Tables[0];
        rptReportData.DataBind();

        hdnTotalRows.Value = dsReportData.Tables[1].Rows[0]["TotalRows"].ToString();
    }
}