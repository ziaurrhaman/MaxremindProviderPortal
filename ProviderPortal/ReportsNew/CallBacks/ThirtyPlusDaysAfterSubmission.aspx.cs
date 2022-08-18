using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EMR_ReportsNew_CallBacks_ThirtyPlusDaysAfterSubmission : System.Web.UI.Page
{
    string _DateTo = ""; string _DateFrom = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        LoadReport();

        if (_DateFrom == "" && _DateTo == "")
        {
          TimeSpan.Text = "All Records";
        }
        else
        {
           TimeSpan.Text = _DateFrom + '-' + _DateTo;
        }
        //

    }
    private void LoadReport()
    {
        ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();
        long PracticeId = Profile.PracticeId;

        string DateType = Request.Form["Datetype"];
        _DateFrom = Request.Form["DosDateFrom"];
        _DateTo = Request.Form["DosDateTo"];
        string Insurance = Request.Form["InsuranceName"];
        string POSCode = Request.Form["POSCode"];
        hdnDateFrom.Value = _DateFrom;
        hdnDateTo.Value = _DateTo;
        hdnInsurance.Value = Insurance;
        hdnDateType.Value = DateType;

        DataSet dsReportData = objPatientReportsDB.GetThirtyPlusDaysAfterSubmission(PracticeId, 10, 0, "", Insurance, DateType, _DateFrom, _DateTo);

        rptTPDAS.DataSource = dsReportData.Tables[0];
        rptTPDAS.DataBind();
        hdnTotalRows.Value = dsReportData.Tables[1].Rows[0]["TotalRows"].ToString();

    }
}