using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProviderPortal_Reports_CallBacks_FilterChargesDetailReport : System.Web.UI.Page
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
        DateType = Request.QueryString["DateType"];
        ProviderId = Request.QueryString["ProviderId"];
        PracticeLocationId = Request.QueryString["PracticeLocationId"];
        PayerId = Request.QueryString["PayerId"];
        PatientId = Request.Form["PatientId"];
        ProcedureCode = Request.QueryString["ProcedureCode"];
        DataSet dsReportData = objPatientReportsDB.ChargesDetail(PracticeId, Rows, PageNumber, SortBy, DateType, ProviderId, PracticeLocationId, PayerId, ProcedureCode, PatientId, _DateFrom, _DateTo);

        rptChargesDetail.DataSource = dsReportData.Tables[0];
        rptChargesDetail.DataBind();
        ltrTotalRows.Text = dsReportData.Tables[1].Rows[0]["TotalRows"].ToString();
    }
    protected void rptChargesDetail_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView drv = (DataRowView)e.Item.DataItem;
            string ServiceUnits = drv["ServiceUnits"].ToString();
            Label lblServiceUnits = (Label)e.Item.FindControl("lblServiceUnits");
            if (ServiceUnits != "")
            {
                lblServiceUnits.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(ServiceUnits));
            }
            string TotalCharges = drv["TotalCharges"].ToString();
            Label lblTotalCharges = (Label)e.Item.FindControl("lblTotalCharges");
            if (TotalCharges != "")
            {
                lblTotalCharges.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(TotalCharges));
            }
        }
    }
}