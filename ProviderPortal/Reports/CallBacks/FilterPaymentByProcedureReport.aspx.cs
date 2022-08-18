using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProviderPortal_Reports_CallBacks_FilterPaymentByProcedureReport : System.Web.UI.Page   
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
        _DateFrom = Request.Form["DateFrom"];
        _DateTo = Request.Form["DateTo"];
        DataSet dsReportData = objPatientReportsDB.GetPaymentByProcedure(PracticeId, Rows, PageNumber, SortBy, _DateFrom, _DateTo);

        rptPaymentByProcedure.DataSource = dsReportData.Tables[0];
        rptPaymentByProcedure.DataBind();
        ltrTotalRows.Text = dsReportData.Tables[1].Rows[0]["TotalRows"].ToString();
    }
    protected void rptPaymentByProcedure_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView drv = (DataRowView)e.Item.DataItem;
            string AvgPaymentByPrimary = drv["AvgPaymentByPrimary"].ToString();
            Label lblAvgPaymentByPrimary = (Label)e.Item.FindControl("lblAvgPaymentByPrimary");
            if (AvgPaymentByPrimary != "")
            {
                lblAvgPaymentByPrimary.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(AvgPaymentByPrimary));
            }
            string AvgPaymentBySecondary = drv["AvgPaymentBySecondary"].ToString();
            Label lblAvgPaymentBySecondary = (Label)e.Item.FindControl("lblAvgPaymentBySecondary");
            if (AvgPaymentBySecondary != "")
            {
                lblAvgPaymentBySecondary.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(AvgPaymentBySecondary));
            }
            string AvgPaymentByPatient = drv["AvgPaymentByPatient"].ToString();
            Label lblAvgPaymentByPatient = (Label)e.Item.FindControl("lblAvgPaymentByPatient");
            if (AvgPaymentByPatient != "")
            {
                lblAvgPaymentByPatient.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(AvgPaymentByPatient));
            }
            string AvgTotalPayment = drv["AvgTotalPayment"].ToString();
            Label lblAvgTotalPayment = (Label)e.Item.FindControl("lblAvgTotalPayment");
            if (AvgTotalPayment != "")
            {
                lblAvgTotalPayment.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(AvgTotalPayment));
            }
        }
    }
}