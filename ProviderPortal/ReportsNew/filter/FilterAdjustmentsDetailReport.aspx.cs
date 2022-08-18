using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EMR_ReportsNew_filter_FilterAdjustmentsDetailReport : System.Web.UI.Page
{
    string DateFrom = "";
    string DateTo = "";
    string _TimeSpan = ""; string DateType = ""; string ProviderId = "";
    string PracticeLocationId; string PayerId; string AdjustmentCode;
    string PatientId = ""; string ProcedureCode = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();
        PatientId = Request.Form["PatientIds"];
        long PracticeId = Profile.PracticeId;
        DateFrom = Request.Form["BillDateFrom"];
        DateTo = Request.Form["BillDateTo"];
        DateType = Request.Form["DateType"];
        ProviderId = Request.Form["ProviderId"];
        PracticeLocationId = Request.Form["PracticeLocationId"];
        PayerId = Request.Form["PayerId"];
        AdjustmentCode = Request.Form["AdjustmentCode"];

        int Rows = int.Parse(Request.Form["Rows"]);
        int PageNumber = int.Parse(Request.Form["PageNumber"]);
        string SortBy = Request.Form["SortBy"];
        if (AdjustmentCode == null)
        {
            AdjustmentCode = "";
        }
        else
        {
            AdjustmentCode = Request.Form["AdjustmentCode"];
        }

        ProcedureCode = Request.Form["ProcedureCode"];
        DataSet dsReportData = objPatientReportsDB.AdjustmentsDetail(PracticeId, Rows, PageNumber, SortBy, DateType, ProviderId, PracticeLocationId, PayerId, AdjustmentCode, ProcedureCode, PatientId, DateFrom, DateTo);

        rptReportData.DataSource = dsReportData.Tables[0];
        rptReportData.DataBind();
        ltrTotalRows.Text = dsReportData.Tables[1].Rows[0]["TotalRows"].ToString();
        hdnProviderId.Value = ProviderId;
        hdnPracticeLocationId.Value = PracticeLocationId;
        hdnPayerId.Value = PayerId;
        hdnAdjustmentCode.Value = AdjustmentCode;
        hdnProcedureCode.Value = ProcedureCode;
        hdnDateFrom.Value = DateFrom;
        hdnDateTo.Value = DateTo;
        hdnDateType.Value = DateType;
        string[] _DateFrom = DateFrom.Split(new Char[] { '-' });
        string[] _DateTo = DateTo.Split(new Char[] { '-' });
        TimeSpan.Text = _DateFrom[1] + "/" + _DateFrom[2] + "/" + _DateFrom[0] + "-" + _DateTo[1] + "/" + _DateTo[2] + "/" + _DateTo[0];
    }

}