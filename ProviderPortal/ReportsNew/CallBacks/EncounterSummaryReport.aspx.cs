using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EMR_ReportsNew_CallBacks_EncounterSummaryReport : System.Web.UI.Page
{
    string _DateTo = ""; string _DateFrom = "";
    string _TimeSpan = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();
        long PracticeId = Profile.PracticeId;
        string DateType = Request.Form["DateType"];
        _DateFrom = Request.Form["BillDateFrom"];
        _DateTo = Request.Form["BillDateTo"];
        string ProviderId = Request.Form["ProviderId"];
        string PracticeLocationId = Request.Form["PracticeLocationId"];
        string PayerId = Request.Form["PayerId"];
        string SubmissionStatusId = Request.Form["ddlSubmissionStatus"];

        if (_DateFrom != "" && _DateTo != "")
        {

            lblTimeSpan.Text = _DateFrom + "-" + _DateTo;
        }
        else
        {
            lblTimeSpan.Text = "All Records";
        }


        hdnDateType.Value = Request.Form["DateType"];
        hdnProviderId.Value = Request.Form["ProviderId"];
        hdnPracticeLocationId.Value = Request.Form["PracticeLocationId"];
        hdnDateFrom.Value = Request.Form["BillDateFrom"];
        hdnDateTo.Value = Request.Form["BillDateTo"];
        hdnPayerId.Value = Request.Form["PayerId"];
        hdnSubmissionStatus.Value = SubmissionStatusId;
        DataSet dsReportData = objPatientReportsDB.GetEncounterSummary(PracticeId, 10, 0, "PostDate ASC", DateType, SubmissionStatusId, _DateFrom, _DateTo, ProviderId, PracticeLocationId, PayerId);

        rptDenialsDetail.DataSource = dsReportData.Tables[0];
        rptDenialsDetail.DataBind();
        hdnTotalRows.Value = dsReportData.Tables[1].Rows[0]["TotalRows"].ToString();
       
    }
}