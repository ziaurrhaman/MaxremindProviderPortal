using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class EMR_ReportsNew_CallBacks_ERAEOBListReport : System.Web.UI.Page
{
    string _DateFrom = "";
    string _DateTo = "";
    string _TimeSpan = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadReport();
    }
    private void LoadReport()
    {
        ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();
        long PracticeId = Profile.PracticeId;
        string Insurance = Request.Form["InsuranceName"];
        string PaymentType = Request.Form["PaymentType"];
        string PaymentMethod = Request.Form["PaymentMethod"];
        _DateFrom = Request.Form["DateFrom"];
        _DateTo = Request.Form["DateTo"];
        if (_DateFrom != "" && _DateTo != "")
        {

            TimeSpan.Text = _DateFrom + "-" + _DateTo;
        }
        else
        {
            TimeSpan.Text = "All Records";
        }
        hdnInsurance.Value = Request.Form["InsuranceName"];
        hdnPaymentType.Value = Request.Form["PaymentType"];
        hdnPaymentMethod.Value = Request.Form["PaymentMethod"];
        hdnDateFrom.Value = Request.Form["DateFrom"];
        hdnDateTo.Value = Request.Form["DateTo"];
        DataSet dsReportData = objPatientReportsDB.GetBySearchCriteria(PracticeId, 10, 0, "PaymentType ASC", Insurance, PaymentType, PaymentMethod, _DateFrom, _DateTo);

        rptERAEOBList.DataSource = dsReportData.Tables[0];
        rptERAEOBList.DataBind();
        hdnTotalRows.Value = dsReportData.Tables[1].Rows[0]["TotalRows"].ToString();

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