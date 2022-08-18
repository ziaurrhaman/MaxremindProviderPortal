using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class EMR_ReportsNew_filter_FilterContractManagementDetailReport : System.Web.UI.Page
{
    string _DateFrom = "";
    string _DateTo = "";
    string _TimeSpan = ""; string DateType;
    string ProviderId;
    string PracticeLocationId;
    string PayerId;
    string PatientId;
    string ProcedureCode;
    protected void Page_Load(object sender, EventArgs e)
    {
        ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();
        long PracticeId = Profile.PracticeId;
        int Rows = int.Parse(Request.Form["Rows"]);
        int PageNumber = int.Parse(Request.Form["PageNumber"]);
        string SortBy = Request.Form["SortBy"];
        _DateFrom = Request.Form["StartDate"];
        _DateTo = Request.Form["EndDate"];
        if(_DateFrom == null || _DateFrom == "")
        {
            _DateFrom = Request.Form["DateFrom"];
        }
        if (_DateTo == null || _DateTo == "")
        {
            _DateTo = Request.Form["DateTo"];
        }
        DateType = Request.Form["DateType"];
        if (DateType == null || DateType == "")
        {
            DateType = "PostDate";
        }
        ProviderId = Request.Form["ProviderId"];
        PracticeLocationId = Request.Form["PracticeLocationId"];
        PayerId = Request.Form["PayerId"];
        PatientId = Request.Form["PatientId"];
        

        ProcedureCode = Request.Form["ProcedureCode"];
        DataSet dsReportData = objPatientReportsDB.GetContractManagementDetail(PracticeId, Rows, PageNumber, SortBy, DateType, ProviderId, PracticeLocationId, PayerId, ProcedureCode, PatientId, _DateFrom, _DateTo);

        rptContractManagementDetail.DataSource = dsReportData.Tables[0];
        rptContractManagementDetail.DataBind();
        ltrTotalRows.Text = dsReportData.Tables[1].Rows[0]["TotalRows"].ToString();


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
        string[] DateFrom = _DateFrom.Split(new Char[] { '-' });
        string[] DateTo = _DateTo.Split(new Char[] { '-' });


        TimeSpan.Text = DateFrom[1] + "/" + DateFrom[2] + "/" + DateFrom[0] + "-" + DateTo[1] + "/" + DateTo[2] + "/" + DateTo[0];

        hdnDateFrom.Value = _DateFrom;
        hdnDateTo.Value = _DateTo;
        hdnPatId.Value = PatientId;
        hdnDateType.Value = DateType;
        hdnProviderId.Value = ProviderId;
        hdnPracticeLocationId.Value = PracticeLocationId;
        hdnProcedureCode.Value = ProcedureCode;
        hdnPayerId.Value = PayerId;
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
}