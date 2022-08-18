using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProviderPortal_Reports_CallBacks_FilterChargesSummaryReport : System.Web.UI.Page
{
    string _TimeSpan = ""; string DateType; string ProviderId;
    string PracticeLocationId; string PayerId;
    string PatientId; string ProcedureCode;
    protected void Page_Load(object sender, EventArgs e)
    {
        int Rows = int.Parse(Request.Form["Rows"]);
        int PageNumber = int.Parse(Request.Form["PageNumber"]);
        string SortBy = Request.Form["SortBy"];
        string DateForm=Request.Form["DateFrom"];
        string DateTo = Request.Form["DateTo"];
        long PracticeId = Profile.PracticeId;
        DateType = Request.QueryString["DateType"];
        ProviderId = Request.QueryString["ProviderId"];
        PracticeLocationId = Request.QueryString["PracticeLocationId"];
        PayerId = Request.QueryString["PayerId"];
        PatientId = Request.Form["PatientId"];
       
        ProcedureCode = Request.QueryString["ProcedureCode"];
        ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();

        DataSet dsReportData = objPatientReportsDB.ChargesSummary(PracticeId, Rows, PageNumber, SortBy, DateType, ProviderId, PracticeLocationId, PayerId, ProcedureCode, PatientId, DateForm, DateTo);

        rptChargesSummary.DataSource = dsReportData.Tables[0];
        rptChargesSummary.DataBind();

        ltrTotalRows.Text = dsReportData.Tables[1].Rows[0]["TotalRows"].ToString();
    }
    protected void rptChargesSummary_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView drv = (DataRowView)e.Item.DataItem;
            string total = drv["Total"].ToString();
            Label lblSubTotal = (Label)e.Item.FindControl("lblSubTotal");
            if (total != "")
            {
                lblSubTotal.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(total));
            }
        }
    }
}