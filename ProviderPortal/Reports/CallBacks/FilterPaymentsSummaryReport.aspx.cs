using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProviderPortal_Reports_CallBacks_FilterPaymentsSummaryReport : System.Web.UI.Page
{
    string _DateFrom = "";
    string _DateTo = "";
    string _TimeSpan = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();
        long PracticeId = Profile.PracticeId;;
        _DateFrom = Request.Form["DateFrom"];
        _DateTo = Request.Form["DateTo"];
        DataSet dsReportData = objPatientReportsDB.GetPaymentsSummary(PracticeId,"", _DateFrom, _DateTo,"","","");

        rptPaymentsSummary.DataSource = dsReportData.Tables[0];
        rptPaymentsSummary.DataBind();
        ltrTotalRows.Text = dsReportData.Tables[1].Rows[0]["TotalRows"].ToString();
    }
    protected void rptPaymentsSummary_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView drv = (DataRowView)e.Item.DataItem;
            string Amount = drv["Amount"].ToString();
            Label lblAmount = (Label)e.Item.FindControl("lblAmount");
            if (Amount != "")
            {
                lblAmount.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(Amount));
            }
            string Unapplied = drv["Unapplied"].ToString();
            Label lblUnapplied = (Label)e.Item.FindControl("lblUnapplied");
            if (Unapplied != "")
            {
                lblUnapplied.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(Unapplied));
            }
        }
    }
}