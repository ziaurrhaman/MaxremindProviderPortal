using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class ProviderPortal_Reports_CallBacks_FilterPatientContactList : System.Web.UI.Page
{
    string DiagnosisCode = ""; string Actuvity = ""; string ProviderId = ""; string ProcedureCode = "";
    string Gender = ""; string PayerId = ""; string DOB = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.Form["action"];

        if (action == "Filter")
        {
            LoadReport();
        }
    }
    private void LoadReport()
    {
        int Rows = int.Parse(Request.Form["Rows"]);
        int PageNumber = int.Parse(Request.Form["PageNumber"]);
        string SortBy = "PatientId desc";
        DiagnosisCode = Request.Form["DiagnosisCode"];
        Actuvity = Request.Form["Actuvity"];
        ProviderId = Request.Form["ProviderId"];
        ProcedureCode = Request.Form["ProcedureCode"];
        Gender = Request.Form["Gender"];
        PayerId = Request.Form["PayerId"];
        DOB = Request.Form["DOB"];
        long PracticeId = Profile.PracticeId;
        ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();

        DataSet dsReportData = objPatientReportsDB.PatientClaimsList(PracticeId, Rows, PageNumber, SortBy, Actuvity, ProviderId, DiagnosisCode, ProcedureCode, Gender, PayerId, DOB);

        rptPatientClaimList.DataSource = dsReportData.Tables[0];
        rptPatientClaimList.DataBind();

        ltrTotalRows.Text = dsReportData.Tables[1].Rows[0]["TotalRows"].ToString();
    }
}