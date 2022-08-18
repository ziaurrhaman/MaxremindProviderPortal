using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProviderPortal_Reports_CallBacks_FilterContractManagementDetailReport : System.Web.UI.Page
{ 
     string _DateFrom = "";
    string _DateTo = "";
    string _TimeSpan = ""; string DateType; string ProviderId;
    string PracticeLocationId; string PayerId;
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
        PayerId = Request.Form["PayerId"];
        PatientId = Request.Form["PatientId"];
       
        ProcedureCode = Request.Form["ProcedureCode"];
        DataSet dsReportData = objPatientReportsDB.GetContractManagementDetail(PracticeId, Rows, PageNumber, "PatientName asc", DateType, ProviderId, PracticeLocationId, PayerId, ProcedureCode, PatientId, _DateFrom, _DateTo);

        rptContractManagementDetail.DataSource = dsReportData.Tables[0];
        rptContractManagementDetail.DataBind();
        ltrTotalRows.Text = dsReportData.Tables[1].Rows[0]["TotalRows"].ToString();
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