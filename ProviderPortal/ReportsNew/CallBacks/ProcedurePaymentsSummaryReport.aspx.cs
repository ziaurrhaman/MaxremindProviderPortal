using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class EMR_ReportsNew_CallBacks_ProcedurePaymentsSummaryReport : System.Web.UI.Page
{
    string _DateFrom = "";
    string _DateTo = "";
    string _TimeSpan = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadReport();
    }
    private void LoadReport()
    {
        ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();
        long PracticeId = Profile.PracticeId;
        _DateFrom = Request.Form["DateFrom"];
        _DateTo = Request.Form["DateTo"];
        if (_DateFrom != "" && _DateTo != "")
        {

            TimeSpan.Text = _DateFrom + "-" + _DateTo;
        }
        else
        {
            TimeSpan.Text = "All Records";
        }
        DataSet dsReportData = objPatientReportsDB.GetProcedurePaymentsSummary(PracticeId, 10, 0, "Code asc", _DateFrom, _DateTo);

        rptProcedurePaymentsSummary.DataSource = dsReportData.Tables[0];
        rptProcedurePaymentsSummary.DataBind();
        hdnTotalRows.Value = dsReportData.Tables[1].Rows[0]["TotalRows"].ToString();
    }
}