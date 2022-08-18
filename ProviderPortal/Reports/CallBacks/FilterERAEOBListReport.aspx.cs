using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProviderPortal_Reports_CallBacks_FilterERAEOBListReport : System.Web.UI.Page 
{
    string _DateFrom = "";
    string _DateTo = ""; 
    string _TimeSpan = "";
    protected void Page_Load(object sender, EventArgs e)
    {

        ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();
        long PracticeId = Profile.PracticeId;
        int Rows = int.Parse(Request.Form["Rows"]);
        int PageNumber = int.Parse(Request.Form["PageNumber"]);
        string SortBy = Request.Form["SortBy"];
        string Insurance = Request.Form["Insurance"];
        string PaymentType = Request.Form["PaymentType"];
        string PaymentMethod = Request.Form["PaymentMethod"];
        string DateType = Request.Form["DateType"];
        _DateFrom = Request.Form["DateFrom"];
        _DateTo = Request.Form["DateTo"];
        DataSet dsReportData = objPatientReportsDB.GetBySearchCriteria(PracticeId, Rows, PageNumber, SortBy, Insurance, PaymentType, PaymentMethod, _DateFrom, _DateTo);

        rptERAEOBList.DataSource = dsReportData.Tables[0];
        rptERAEOBList.DataBind();
        ltrTotalRows.Text = dsReportData.Tables[1].Rows[0]["TotalRows"].ToString();
    }
    protected void rptERAEOBList_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView drv = (DataRowView)e.Item.DataItem;
            Label lblPaymentAmount = (Label)e.Item.FindControl("lblPaymentAmount");
            Label lblPaymentPosted = (Label)e.Item.FindControl("lblPaymentPosted");
            Label lblUnapplied = (Label)e.Item.FindControl("lblUnapplied");

            if (!string.IsNullOrEmpty(drv["PaymentAmount"].ToString()))
                lblPaymentAmount.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(drv["PaymentAmount"].ToString()));
            if (!string.IsNullOrEmpty(drv["PaymentPosted"].ToString()))
                lblPaymentPosted.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(drv["PaymentPosted"].ToString()));
            if (!string.IsNullOrEmpty(drv["Unapplied"].ToString()))
                lblUnapplied.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(drv["Unapplied"].ToString()));
        }
    }
}