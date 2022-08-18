using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class EMR_ReportsNew_CallBacks_DailyPayments : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ERAMasterDB objERAMasterDB = new ERAMasterDB();

        DataSet dsReportData = objERAMasterDB.Report_DailyPayments(Profile.PracticeId, 10, 0,  "CheckIssueDate","");
            //, DateTime.Now.ToShortDateString(), "");

        rptReportData.DataSource = dsReportData.Tables[0];
        rptReportData.DataBind();

        hdnTotalRows.Value = dsReportData.Tables[1].Rows[0]["TotalRows"].ToString();
        hdnDate.Value = DateTime.Now.ToShortDateString();
    }
    protected void rptReportData_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        DataRowView drv = (DataRowView)e.Item.DataItem;

        string PaymentType = drv["PaymentType"].ToString().Trim();

        if (PaymentType == "PAT")
        {
            PaymentType = "Patient";
        }
        else
        {
            PaymentType = "Insurance";
        }

        Label lblPaymentSource = (Label)e.Item.FindControl("lblPaymentSource");

        lblPaymentSource.Text = PaymentType;
    }
}