using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class EMR_ReportsNew_CallBacks_PayerMixSummaryReport : System.Web.UI.Page
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
        hdnDateFrom.Value = Request.QueryString["DateFrom"];
        hdnDateTo.Value = Request.QueryString["DateTo"];
        DataSet dsReportData = objPatientReportsDB.GetPayerMixSummary(PracticeId, 10, 0, "PayerName asc");

        rptPayerMixSummary.DataSource = dsReportData.Tables[0];
        rptPayerMixSummary.DataBind();
        hdnTotalRows.Value = dsReportData.Tables[1].Rows[0]["TotalRows"].ToString();


       

    }

    protected void rptPayerMixSummary_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView drv = (DataRowView)e.Item.DataItem;
            Label lblPatient = (Label)e.Item.FindControl("lblPatient");
            if (!string.IsNullOrEmpty(drv["Patient"].ToString()))
            {
                string Patient = drv["Patient"].ToString();
                lblPatient.Text = Patient;
            }
            else
            {
                lblPatient.Text = "0";
            }

            Label lblPtnt = (Label)e.Item.FindControl("lblPtnt");
            if (!string.IsNullOrEmpty(drv["Ptnt"].ToString()))
            {
                string Ptnt = drv["Ptnt"].ToString();
                lblPtnt.Text = Ptnt;
            }
            else
            {
                lblPtnt.Text = "-";
            }

            Label lblEncounter = (Label)e.Item.FindControl("lblEncounter");
            if (!string.IsNullOrEmpty(drv["Encounter"].ToString()))
            {
                string Encounter = drv["Encounter"].ToString();
                lblEncounter.Text = Encounter;
            }
            else
            {
                lblEncounter.Text = "0";
            }

            Label lblEncntrs = (Label)e.Item.FindControl("lblEncntrs");
            if (!string.IsNullOrEmpty(drv["Encntrs"].ToString()))
            {
                string Encntrs = drv["Encntrs"].ToString();
                lblEncntrs.Text = Encntrs;
            }
            else
            {
                lblEncntrs.Text = "-";
            }

            Label lblProcedure = (Label)e.Item.FindControl("lblProcedure");
            if (!string.IsNullOrEmpty(drv["Procedure"].ToString()))
            {
                string Procedure = drv["Procedure"].ToString();
                lblProcedure.Text = Procedure;
            }
            else
            {
                lblProcedure.Text = "0";
            }

            Label lblProc = (Label)e.Item.FindControl("lblProc");
            if (!string.IsNullOrEmpty(drv["Proc"].ToString()))
            {
                string Proc = drv["Proc"].ToString();
                lblProc.Text = Proc;
            }
            else
            {
                lblProc.Text = "-";
            }

            Label lblCharges = (Label)e.Item.FindControl("lblCharges");
            if (!string.IsNullOrEmpty(drv["Charges"].ToString()))
            {
                string Charges = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(drv["Charges"].ToString()));
                lblCharges.Text = Charges;
            }
            else
            {
                lblCharges.Text = "$0";
            }

            Label lblChrgs = (Label)e.Item.FindControl("lblChrgs");
            if (!string.IsNullOrEmpty(drv["Chrgs"].ToString()))
            {
                string Chrgs = drv["Chrgs"].ToString();
                lblChrgs.Text = Chrgs;
            }
            else
            {
                lblChrgs.Text = "-";
            }

            Label lblReceipt = (Label)e.Item.FindControl("lblReceipt");
            if (!string.IsNullOrEmpty(drv["Receipt"].ToString()))
            {
                string Receipt = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(drv["Receipt"].ToString()));
                lblReceipt.Text = Receipt;
            }
            else
            {
                lblReceipt.Text = "$0";
            }

            Label lblRcpts = (Label)e.Item.FindControl("lblRcpts");
            if (!string.IsNullOrEmpty(drv["Rcpts"].ToString()))
            {
                string Rcpts = drv["Rcpts"].ToString();
                lblRcpts.Text = Rcpts;
            }
            else
            {
                lblRcpts.Text = "-";
            }
        }
    }
}