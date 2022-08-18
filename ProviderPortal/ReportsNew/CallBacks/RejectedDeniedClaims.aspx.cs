using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EMR_ReportsNew_CallBacks_RejectedDeniedClaims : System.Web.UI.Page
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
    }
    private void LoadReport()
    {
        ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();
        long PracticeId = Profile.PracticeId;

        string DateType = Request.Form["Datetype"];
        _DateFrom = Request.Form["DosDateFrom"];
        _DateTo = Request.Form["DosDateTo"];
        string Insurance = Request.Form["PayerId"];
        string ClaimStatus = Request.Form["ClaimStatus"];
        string BilledAs = Request.Form["BilledAs"];
        string POSCode = Request.Form["ProcedureCode"];
        hdnDateFrom.Value = _DateFrom;
        hdnDateTo.Value = _DateTo;
        hdnPayer.Value = Insurance;
        hdnBilledAs.Value = BilledAs;
        hdnClaimStatus.Value = ClaimStatus;
        hdnCptCode.Value = POSCode;
        hdnDateType.Value = DateType;

        DataSet dsReportData = objPatientReportsDB.GetRejectedDeniedClaims(PracticeId, Insurance, BilledAs, null, "ClaimId DESC");

        rptRDC.DataSource = dsReportData.Tables[0];
        rptRDC.DataBind();
        hdnTotalRows.Value = dsReportData.Tables[1].Rows[0]["TotalRows"].ToString();

        lblTotalClaims.Text = dsReportData.Tables[1].Rows[0]["TotalClaims"].ToString();
        lblTotalPatients.Text = dsReportData.Tables[1].Rows[0]["TotalPatients"].ToString();
    }


}