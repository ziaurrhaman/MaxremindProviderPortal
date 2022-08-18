using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EMR_ReportsNew_CallBacks_PatientTransactionsSummaryReport : System.Web.UI.Page
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
        string _DateType = "PostDate";

            
 


        DataSet dsReportData = objPatientReportsDB.PatientTransactionsSummary(PracticeId, 10, 0, "PatientId ASC", _DateFrom, _DateTo , _DateType);

        rptPatientTransactionsSummary.DataSource = dsReportData.Tables[0];
        rptPatientTransactionsSummary.DataBind();

        hdnTotalRows.Value = dsReportData.Tables[1].Rows[0]["TotalRows"].ToString();
        hdnDateType.Value = _DateType;
        string[] DateFrom = _DateFrom.Split(new Char[] { '-' });
        string[] DateTo = _DateTo.Split(new Char[] { '-' });


        TimeSpan.Text = DateFrom[1] + "/" + DateFrom[2] + "/" + DateFrom[0] +"-"+ DateTo[1] + "/" + DateTo[2] + "/" + DateTo[0];
    }
}