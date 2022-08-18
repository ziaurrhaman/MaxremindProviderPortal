using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class EMR_ReportsNew_CallBacks_ContractManagementSummaryReport : System.Web.UI.Page
{
    string _DateFrom = "";
    string _DateTo = "";
    string _TimeSpan = ""; string DateType = "";
    string ProviderId = "";
    string PracticeLocationId = ""; string PayerId = "";
    string PatientId = ""; string ProcedureCode = "";
    string InsuranceId = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadReport();
        LoadPracticeLocation();
        LoadPayersFromClaim();
        LoadProvider();
    }
    private void LoadReport()
    {
        //lblInsuranceName.Text = Request.Form["InsuranceName"];
        ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();
        long PracticeId = Profile.PracticeId;
        _DateFrom = Request.Form["DateFrom"];
        _DateTo = Request.Form["DateTo"];
        if (Request.Form["DateType"] == "0")
        {
            DateType = "";
        }
        else
        {
            DateType = Request.Form["DateType"];
        }
        if (_DateFrom != "" && _DateTo != "")
        {

            TimeSpan.Text = _DateFrom + "-" + _DateTo;
        }
        else
        {
            TimeSpan.Text = "All Records";
        }

        ProviderId = Request.Form["ProviderId"];
        PracticeLocationId = Request.Form["PracticeLocationId"];
        hdnDateFrom.Value = _DateFrom;
        hdnDateTo.Value = _DateTo;
        PatientId = Request.Form["PatientIds"];
        ProcedureCode = Request.Form["ProcedureCode"];
        hdnPatId.Value = PatientId;
        hdnProviderId.Value = ProviderId;
        hdnPracticeLocationId.Value = PracticeLocationId;
        hdnProcedureCode.Value = ProcedureCode;

        if (!string.IsNullOrEmpty(Request.Form["InsuranceId"]))
        {
            InsuranceId = (Request.Form["InsuranceId"]);
            hdnInsuranceId.Value = Request.Form["InsuranceId"];
        }
        DataSet dsReportData = objPatientReportsDB.GetContractManagementSummary(PracticeId, 10, 0, "Procedure asc", DateType, ProviderId, PracticeLocationId, ProcedureCode, PatientId, _DateFrom, _DateTo, InsuranceId);

        rptContractManagementSummary.DataSource = dsReportData.Tables[0];
        rptContractManagementSummary.DataBind();
        hdnTotalRows.Value = dsReportData.Tables[1].Rows[0]["TotalRows"].ToString();
       // int Rows = int.Parse(hdnTotalRows.Value);
        //DataTable dtReportData = objPatientReportsDB.GetTotalContractManagementSummary(PracticeId, Rows, 0, "Procedure asc", DateType, ProviderId, PracticeLocationId, ProcedureCode, PatientId, _DateFrom, _DateTo, InsuranceId);
        DataTable dtReportData = dsReportData.Tables[0];
        string[] DateFrom = _DateFrom.Split(new Char[] { '-' });
        string[] DateTo = _DateTo.Split(new Char[] { '-' });


        TimeSpan.Text = DateFrom[1] + "/" + DateFrom[2] + "/" + DateFrom[0] + "-" + DateTo[1] + "/" + DateTo[2] + "/" + DateTo[0];
        hdnDateType.Value = DateType;
        lblPracticeName.Text = Profile.PracticeName;
        if (dtReportData.Rows.Count > 0)
        {
            if (!string.IsNullOrEmpty(dtReportData.Rows[0]["AllowedAmount"].ToString()))
            {
                float TotalAllowedAmount = float.Parse(dtReportData.Compute("sum(AllowedAmount)", string.Empty).ToString());
               // Label lblTotalAllowedAmount = FooterTemplate.FindControl("lblTotalAllowedAmount") as Label;
                lblTotalAllowedAmount.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(TotalAllowedAmount));
            }
        }
        if (dtReportData.Rows.Count > 0)
        {
            if (!string.IsNullOrEmpty(dtReportData.Rows[0]["AVGPayment"].ToString()))
            {
                float TotalAVGPayment = float.Parse(dtReportData.Compute("sum(AVGPayment)", string.Empty).ToString());
                //Label lblTotalAVGPayment = FooterTemplate.FindControl("lblTotalAVGPayment") as Label;
                lblTotalAVGPayment.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(TotalAVGPayment));
            }
        }


       

    }
    protected void rptContractManagementSummary_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView drv = (DataRowView)e.Item.DataItem;
            string AllowedAmount = drv["AllowedAmount"].ToString();
            Label lblAllowedAmount = (Label)e.Item.FindControl("lblAllowedAmount");
            if (AllowedAmount != "")
            {
                lblAllowedAmount.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(AllowedAmount));
            }
            string AVGPayment = drv["AVGPayment"].ToString();
            Label lblAVGPayment = (Label)e.Item.FindControl("lblAVGPayment");
            if (AVGPayment != "")
            {
                lblAVGPayment.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(AVGPayment));
            }
        }
    }
    public void LoadPracticeLocation()
    {
        long PracticeId = Profile.PracticeId;
        ReportsDB db = new ReportsDB();

        DataTable dtPracticeLocation = db.GetLocationsByDefault(PracticeId);
        rptLocation.DataSource = dtPracticeLocation;
        rptLocation.DataBind();
    }
    public void LoadPayersFromClaim()
    {
        InsuranceDB insuranceDB = new InsuranceDB();
        long PracticeId = Profile.PracticeId;
        DataTable dtPatient = insuranceDB.GetPayersByPracticeId(PracticeId, "", "");
        rptPayerScenario.DataSource = dtPatient;
        rptPayerScenario.DataBind();

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