using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProviderPortal_Reports_CallBacks_FilterContractManagementSummaryReport : System.Web.UI.Page 
{
    string _DateFrom = "";
    string _DateTo = "";
    string _TimeSpan = ""; string DateType; string ProviderId;
    string PracticeLocationId;
    string PatientId; string ProcedureCode;
    protected void Page_Load(object sender, EventArgs e)
    {
        ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();
        long PracticeId = Profile.PracticeId;
        int Rows = int.Parse(Request.Form["Rows"]);
        int PageNumber = int.Parse(Request.Form["PageNumber"]);
        string SortBy = Request.Form["SortBy"];
        _DateFrom = Request.Form["DateFrom"];
        _DateTo = Request.Form["DateTo"];
        DateType = Request.Form["DateType"];

        ProviderId = Request.Form["ProviderId"];
        PracticeLocationId = Request.Form["PracticeLocationId"];
        
        PatientId = Request.Form["PatientId"];

        ProcedureCode = Request.Form["ProcedureCode"];
        long InsuranceId = long.Parse(Request.Form["InsuranceId"]);
        DataSet dsReportData = objPatientReportsDB.GetContractManagementSummary(PracticeId, Rows, PageNumber, "Procedure asc", DateType, ProviderId, PracticeLocationId, ProcedureCode, PatientId, _DateFrom, _DateTo, InsuranceId);

        rptContractManagementSummary.DataSource = dsReportData.Tables[0];
        rptContractManagementSummary.DataBind();
        ltrTotalRows.Text = dsReportData.Tables[1].Rows[0]["TotalRows"].ToString();
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
}