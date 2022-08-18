using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProviderPortal_Reports_CallBacks_FilterARAgingSummaryReport : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();
        long PracticeId = Profile.PracticeId;
        string AgingDate = Request.Form["AgingDate"];
        string AgingType = Request.Form["AgingType"];
        string PracticeLocationId = Request.Form["PracticeLocationId"];
        string ProviderId = Request.Form["ProviderId"];
        string PayerId = Request.Form["PayerId"];
        DataSet dsReportData = objPatientReportsDB.GetARAgingSummary(PracticeId, AgingType, AgingDate, PracticeLocationId, ProviderId, PayerId);

        rptARAgingSummary.DataSource = dsReportData.Tables[0];
        rptARAgingSummary.DataBind();
    }
    protected void rptARAgingSummary_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView drv = (DataRowView)e.Item.DataItem;

            string Payer = drv["Payer"].ToString();
            Label lblPayer = (Label)e.Item.FindControl("lblPayer");
            Label lblPecentage = (Label)e.Item.FindControl("lblPecentage");
            Label lblUnbilled = (Label)e.Item.FindControl("lblUnbilled");
            Label lblCurrent = (Label)e.Item.FindControl("lblCurrent");
            Label lbl3160 = (Label)e.Item.FindControl("lbl3160");
            Label lbl6190 = (Label)e.Item.FindControl("lbl6190");
            Label lbl91120 = (Label)e.Item.FindControl("lbl91120");
            Label lbl120 = (Label)e.Item.FindControl("lbl120");
            Label lblTotalBal = (Label)e.Item.FindControl("lblTotalBal");
            if (!string.IsNullOrEmpty(drv["Payer"].ToString()))
            {
                lblPayer.Text = Payer;
                lblUnbilled.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(drv["Unbilled"].ToString()));
                lblCurrent.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(drv["Current"].ToString()));
                lbl3160.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(drv["31-60"].ToString()));
                lbl6190.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(drv["61-90"].ToString()));
                lbl91120.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(drv["91-120"].ToString()));
                lbl120.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(drv["120+"].ToString()));
                lblTotalBal.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(drv["TotalBal"].ToString()));
            }
            else if (string.IsNullOrEmpty(drv["Payer"].ToString()) && drv["TotalBal"].ToString() == "100.0000")
            {
                lblPecentage.Style.Add("font-weight", "bold");
                lblPecentage.Text = "Pecentage";
                lblUnbilled.Text = drv["Unbilled"].ToString() + "%";
                lblCurrent.Text = drv["Current"].ToString() + "%";
                lbl3160.Text = drv["31-60"].ToString() + "%";
                lbl6190.Text = drv["61-90"].ToString() + "%";
                lbl91120.Text = drv["91-120"].ToString() + "%";
                lbl120.Text = drv["120+"].ToString() + "%";
                lblTotalBal.Text = drv["TotalBal"].ToString() + "%";
            }
            else
            {
                lblPayer.Style.Add("font-weight", "bold");
                lblPayer.Text = "Garand Total";
                lblUnbilled.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(drv["Unbilled"].ToString()));
                lblCurrent.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(drv["Current"].ToString()));
                lbl3160.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(drv["31-60"].ToString()));
                lbl6190.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(drv["61-90"].ToString()));
                lbl91120.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(drv["91-120"].ToString()));
                lbl120.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(drv["120+"].ToString()));
                lblTotalBal.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(drv["TotalBal"].ToString()));
            }

        }
    }
}