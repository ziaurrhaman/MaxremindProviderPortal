using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EMR_ReportsNew_CallBacks_AdjustmentsDetailReport : System.Web.UI.Page
{
    string DateFrom = "";
    string DateTo = "";
    string _TimeSpan = ""; string DateType; string ProviderId;
    string PracticeLocationId; string PayerId; string AdjustmentCode;
    string PatientId; string ProcedureCode;
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadReport();
    }
    private void LoadReport()
    {
        ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();
        long PracticeId = Profile.PracticeId;
        DateFrom = Request.Form["DateFrom"];
        DateTo = Request.Form["DateTo"];

        DateType = Request.Form["DateType"];
        ProviderId = Request.Form["ProviderId"];
        PracticeLocationId = Request.Form["PracticeLocationId"];
        PayerId = Request.Form["PayerId"];
        AdjustmentCode = Request.Form["AdjustmentCode"];
        if (AdjustmentCode == null)
        {
            AdjustmentCode = "";
        }
        else
        {
            AdjustmentCode = Request.Form["AdjustmentCode"];
        }
        PatientId = Request.Form["PatientIds"];
        hdnPatient.Value = PatientId;
        ProcedureCode = Request.Form["ProcedureCode"];

        hdnProviderId.Value = ProviderId;
        hdnPracticeLocationId.Value = PracticeLocationId;
        hdnPayerId.Value = PayerId;
        hdnAdjustmentCode.Value = AdjustmentCode;
        hdnProcedureCode.Value = ProcedureCode;
        hdnDateFrom.Value = DateFrom;
        hdnDateTo.Value = DateTo;
        hdnDateType.Value = DateType;

        DataSet dsReportData = objPatientReportsDB.AdjustmentsDetail(PracticeId, 10, 0, "PostDate DESC", DateType, ProviderId, PracticeLocationId, PayerId, AdjustmentCode, ProcedureCode, PatientId, DateFrom, DateTo);

        rptAdjustmentsDetail.DataSource = dsReportData.Tables[0];
        rptAdjustmentsDetail.DataBind();

        hdnTotalRows.Value = dsReportData.Tables[1].Rows[0]["TotalRows"].ToString();
        //TimeSpan.Text = _DateFrom + _DateTo;
        LoadPayersFromClaim();
        LoadPracticeLocation();
        LoadAdjustmentCode();
        LoadProvider();

        string[] _DateFrom = DateFrom.Split(new Char[] { '-' });
        string[] _DateTo = DateTo.Split(new Char[] { '-' });


        TimeSpan.Text = _DateFrom[1] + "/" + _DateFrom[2] + "/" + _DateFrom[0] + "-" + _DateTo[1] + "/" + _DateTo[2] + "/" + _DateTo[0];
    }
    public void LoadPayersFromClaim()
    {
        InsuranceDB insuranceDB = new InsuranceDB();
        long PracticeId = Profile.PracticeId;
        DataTable dtPatient = insuranceDB.GetPayersByPracticeId(PracticeId, "", "");
        rptPayerScenario.DataSource = dtPatient;
        rptPayerScenario.DataBind();

    }
    public void LoadPracticeLocation()
    {
        long PracticeId = Profile.PracticeId;
        ReportsDB db = new ReportsDB();

        DataTable dtPracticeLocation = db.GetLocationsByDefault(PracticeId);
        rptLocation.DataSource = dtPracticeLocation;
        rptLocation.DataBind();
    }

    public void LoadAdjustmentCode()
    {
        AdjustmentCodesDB adjustmentCodeDB = new AdjustmentCodesDB();
        DataTable dtAdjustmentCode = adjustmentCodeDB.GetAdjustmentCode(Profile.PracticeId);
        rptAdjustmentCode.DataSource = dtAdjustmentCode;
        rptAdjustmentCode.DataBind();

    }
    public void LoadProvider()
    {
        string PracticeLocationId = Request.Form["PracticeLocationId"];
        ReportsDB db = new ReportsDB();
        DataTable ds = db.GetProvidersByDefault(Profile.PracticeId);
        rptProviders.DataSource = ds;
        rptProviders.DataBind();
    }
}