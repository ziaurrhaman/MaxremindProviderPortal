using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EMR_ReportsNew_filter_FilterPatientContactList : System.Web.UI.Page
{
    string DiagnosisCode = ""; string Actuvity = ""; string ProviderId = ""; string ProcedureCode = "";
    string Gender = ""; string PayerId = ""; string DOB = "";
    string PatientId = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadReport();
    }

    private void LoadReport()
    {
        int Rows = int.Parse(Request.Form["Rows"]);
        int PageNumber = int.Parse(Request.Form["PageNumber"]);
        string SortBy = Request.Form["SortBy"];
        DiagnosisCode = Request.Form["DiagnosisCode"];
        Actuvity = Request.Form["Activity"];
        ProviderId = Request.Form["ProviderId"];
        ProcedureCode = Request.Form["ProcedureCode"];
        Gender = Request.Form["Gender"];
        PayerId = Request.Form["PayerId"];
        DOB = Request.Form["DOB"];
        PatientId = Request.Form["PatientId"];
        long PracticeId = Profile.PracticeId;
        ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();

        DataSet dsReportData = objPatientReportsDB.PatientClaimsList(PracticeId, Rows, PageNumber, SortBy, Actuvity, ProviderId, DiagnosisCode, ProcedureCode, Gender, PayerId, DOB, PatientId);

        rptReportData.DataSource = dsReportData.Tables[0];
        rptReportData.DataBind();

        ltrTotalRows.Text = dsReportData.Tables[1].Rows[0]["TotalRows"].ToString();
        hdnDiagnosisCode.Value = DiagnosisCode;
        hdnActuvity.Value = Actuvity;
        hdnProviderId.Value = ProviderId;
        hdnProcedureCode.Value = ProcedureCode;
        hdnGender.Value = Gender;
        hdnPayerId.Value = PayerId;
        hdnDOB.Value = DOB;
    }
}