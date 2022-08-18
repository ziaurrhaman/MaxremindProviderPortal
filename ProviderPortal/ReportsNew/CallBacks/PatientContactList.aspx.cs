using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EMR_ReportsNew_CallBacks_PatientContactList : System.Web.UI.Page
{

    string DiagnosisCode = ""; string Actuvity = ""; string ProviderId = ""; string ProcedureCode = "";
    ReportsDB db = new ReportsDB();
    string Gender = ""; string PayerId = ""; string DOB = "";
    string PatientId = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadReport();
        LoadProvider();
        InsurancesFromInsurance();
    }
    public void LoadProvider()
    {
        ServiceProviderDB serviceProviderDB = new ServiceProviderDB();
        string PracticeLocationId = Request.Form["PracticeLocationId"];
        string PracticeId = Profile.PracticeId.ToString();
        DataTable ds = db.GetProvidersByDefault(Profile.PracticeId);
        rptProviders.DataSource = ds;
        rptProviders.DataBind();
    }
    private void LoadReport()
    {
        DiagnosisCode = Request.QueryString["DiagnosisCode"];
        Actuvity = Request.QueryString["Actuvity"];
        ProviderId = Request.QueryString["ProviderId"];
        ProcedureCode = Request.QueryString["ProcedureCode"];
        Gender = Request.QueryString["Gender"];
        PayerId = Request.QueryString["PayerId"];
        PatientId = (Request.Form["PatientId"]);
        if (Actuvity != "")
        {
            DOB = "";
        }
        else
        {
            DOB = Request.QueryString["DOB"];
        }

        //if (DOB != "")
        //{

        //    TimeSpan.Text = DOB;
        //}
        //else
        //{
        //    TimeSpan.Text = "All Records";
        //}
        hdnDiagnosisCode.Value = DiagnosisCode;
        hdnActuvity.Value = Actuvity;
        hdnProviderId.Value = ProviderId;
        hdnProcedureCode.Value = ProcedureCode;
        hdnGender.Value = Gender;
        hdnPayerId.Value = PayerId;
        hdnDOB.Value = DOB;





        ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();
        long PracticeId = Profile.PracticeId;
        DataSet dsReportData = objPatientReportsDB.PatientClaimsList(PracticeId, 10, 0, "PatientId desc", Actuvity, ProviderId, DiagnosisCode, ProcedureCode, Gender, PayerId, DOB, PatientId);

        rptPatientClaimList.DataSource = dsReportData.Tables[0];
        rptPatientClaimList.DataBind();

        hdnTotalRows.Value = dsReportData.Tables[1].Rows[0]["TotalRows"].ToString();
    }
    private void InsurancesFromInsurance()
    {
        InsuranceDB objInsuranceDB = new InsuranceDB();
        using (DataTable dtInsuranceDb = objInsuranceDB.Insurance_GetBySearchCriteria(Profile.PracticeId, "", "", "", "", 100, 0, "").Tables[0])
        {
            rptInsurance.DataSource = dtInsuranceDb;
            rptInsurance.DataBind();
        }

    }
}