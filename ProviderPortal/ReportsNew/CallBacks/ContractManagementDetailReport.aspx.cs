using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class EMR_ReportsNew_ContractManagementDetailReport : System.Web.UI.Page
{
    string _DateFrom = "";
    string _DateTo = "";
    string _TimeSpan = "";
    string DateType;
    string PracticeLocationId = ""; string PayerId = "";
    string PatientId = ""; string ProcedureCode = "";
    string ProviderId = "";

    int Rows;
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadReport();
        LoadPracticeLocation();
        LoadPayersFromClaim();
        LoadProvider();
    }
    private void LoadReport()
    {
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
        string[] DateFrom = _DateFrom.Split(new Char[] { '-' });
        string[] DateTo = _DateTo.Split(new Char[] { '-' });


        TimeSpan.Text = DateFrom[1] + "/" + DateFrom[2] + "/" + DateFrom[0] + "-" + DateTo[1] + "/" + DateTo[2] + "/" + DateTo[0];

        ProviderId = Request.Form["ProviderId"];
        PracticeLocationId = Request.Form["PracticeLocationId"];
        PayerId = Request.Form["PayerId"];
        PatientId = Request.Form["PatientId"];
        ProcedureCode = Request.Form["ProcedureCode"];
        hdnDateFrom.Value = _DateFrom;
        hdnDateTo.Value = _DateTo;
        hdnPatId.Value = PatientId;
        hdnDateType.Value = DateType;
        hdnProviderId.Value = ProviderId;
        hdnPracticeLocationId.Value = PracticeLocationId;
        hdnProcedureCode.Value = ProcedureCode;
        hdnPayerId.Value = PayerId;
        DataSet dsReportData = objPatientReportsDB.GetContractManagementDetail(PracticeId, 10, 0, "PatientName asc", DateType, ProviderId, PracticeLocationId, PayerId, ProcedureCode, PatientId, _DateFrom, _DateTo);
        rptContractManagementDetail.DataSource = dsReportData.Tables[0];
        rptContractManagementDetail.DataBind();
        hdnTotalRows.Value = dsReportData.Tables[1].Rows[0]["TotalRows"].ToString();
        DataTable dtReportData = dsReportData.Tables[0];
       // Control FooterTemplate = rptContractManagementDetail.Controls[rptContractManagementDetail.Controls.Count - 1].Controls[0];
        if (dtReportData.Rows.Count > 0)
        {
            if (!string.IsNullOrEmpty(dtReportData.Rows[0]["Charges"].ToString()))
            {
                float TotalCharges = float.Parse(dtReportData.Compute("sum(Charges)", string.Empty).ToString());
                // Label lblTotalCharges = FooterTemplate.FindControl("lblTotalCharges") as Label;
                lblTotalCharges.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(TotalCharges));
            }
        }
        if (dtReportData.Rows.Count > 0)
        {
            if (!string.IsNullOrEmpty(dtReportData.Rows[0]["ActAllowed"].ToString()))
            {
                float TotalActAllowed = float.Parse(dtReportData.Compute("sum(ActAllowed)", string.Empty).ToString());
                //Label lblTotalActAllowed = FooterTemplate.FindControl("lblTotalActAllowed") as Label;
                lblTotalActAllowed.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(TotalActAllowed));
            }
        }

        
    }
    protected void rptContractManagementDetail_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView drv = (DataRowView)e.Item.DataItem;
            string Charges = drv["Charges"].ToString();
            Label lblCharges = (Label)e.Item.FindControl("lblCharges");
            if (Charges != "")
            {
                lblCharges.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(Charges));
            }
            string ActAllowed = drv["ActAllowed"].ToString();
            Label lblActAllowed = (Label)e.Item.FindControl("lblActAllowed");
            if (ActAllowed != "")
            {
                lblActAllowed.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(ActAllowed));
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