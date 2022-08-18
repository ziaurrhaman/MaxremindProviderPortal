using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProviderPortal_Reports_CallBacks_FilterPatientCollectionSummaryReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();
        long PracticeId = Profile.PracticeId;
        string AgingType = Request.Form["AgingType"];
        string AgingDate = Request.Form["AgingDate"];
        string PracticeLocationId = Request.Form["PracticeLocationId"];
        string ProviderId = Request.Form["ProviderId"];
        string PatientId = Request.Form["PatientId"];
        DataSet dsReportData = objPatientReportsDB.GetPatientCollectionSummary(PracticeId, AgingType, AgingDate, PracticeLocationId, ProviderId,PatientId);

        rptPatientCollectionSummary.DataSource = dsReportData.Tables[0];
        rptPatientCollectionSummary.DataBind();
    }
    protected void rptPatientCollectionSummary_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView drv = (DataRowView)e.Item.DataItem;
            Label lblCollectionCategory = (Label)e.Item.FindControl("lblCollectionCategory");
            Label lblUnbilled = (Label)e.Item.FindControl("lblUnbilled");
            Label lblCurrent = (Label)e.Item.FindControl("lblCurrent");
            Label lbl3160 = (Label)e.Item.FindControl("lbl3160");
            Label lbl6190 = (Label)e.Item.FindControl("lbl6190");
            Label lbl91120 = (Label)e.Item.FindControl("lbl91120");
            Label lbl120 = (Label)e.Item.FindControl("lbl120");
            Label lblTotalBal = (Label)e.Item.FindControl("lblTotalBal");
            if (string.IsNullOrEmpty(drv["CollectionCategory"].ToString()))
            {
                if (!string.IsNullOrEmpty(drv["NoOfPatients"].ToString()))
                {
                    lblCollectionCategory.Style.Add("font-weight", "bold");
                    lblCollectionCategory.Text = "Grand Total";
                }
                else
                {
                    lblCollectionCategory.Style.Add("font-weight", "bold");
                    lblCollectionCategory.Text = "Grand Total(%)";
                }
            }
            else
            {
                lblCollectionCategory.Style.Add("font-weight", "bold");
                lblCollectionCategory.Text = drv["CollectionCategory"].ToString();
            }

            if (!string.IsNullOrEmpty(drv["Unbilled"].ToString()) && !string.IsNullOrEmpty(drv["NoOfPatients"].ToString()))
                lblUnbilled.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(drv["Unbilled"].ToString()));
            if (string.IsNullOrEmpty(drv["NoOfPatients"].ToString()) && !string.IsNullOrEmpty(drv["Unbilled"].ToString()))
                lblUnbilled.Text = drv["Unbilled"].ToString() + "%";

            if (!string.IsNullOrEmpty(drv["Current"].ToString()) && !string.IsNullOrEmpty(drv["NoOfPatients"].ToString()))
                lblCurrent.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(drv["Current"].ToString()));
            if (string.IsNullOrEmpty(drv["NoOfPatients"].ToString()) && !string.IsNullOrEmpty(drv["Current"].ToString()))
                lblCurrent.Text = drv["Current"].ToString() + "%";

            if (!string.IsNullOrEmpty(drv["31-60"].ToString()) && !string.IsNullOrEmpty(drv["NoOfPatients"].ToString()))
                lbl3160.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(drv["31-60"].ToString()));
            if (string.IsNullOrEmpty(drv["NoOfPatients"].ToString()) && !string.IsNullOrEmpty(drv["31-60"].ToString()))
                lbl3160.Text = drv["31-60"].ToString() + "%";

            if (!string.IsNullOrEmpty(drv["61-90"].ToString()) && !string.IsNullOrEmpty(drv["NoOfPatients"].ToString()))
                lbl6190.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(drv["61-90"].ToString()));
            if (string.IsNullOrEmpty(drv["NoOfPatients"].ToString()) && !string.IsNullOrEmpty(drv["61-90"].ToString()))
                lbl6190.Text = drv["61-90"].ToString() + "%";

            if (!string.IsNullOrEmpty(drv["91-120"].ToString()) && !string.IsNullOrEmpty(drv["NoOfPatients"].ToString()))
                lbl91120.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(drv["91-120"].ToString()));
            if (string.IsNullOrEmpty(drv["NoOfPatients"].ToString()) && !string.IsNullOrEmpty(drv["91-120"].ToString()))
                lbl91120.Text = drv["91-120"].ToString() + "%";

            if (!string.IsNullOrEmpty(drv["120+"].ToString()) && !string.IsNullOrEmpty(drv["NoOfPatients"].ToString()))
                lbl120.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(drv["120+"].ToString()));
            if (string.IsNullOrEmpty(drv["NoOfPatients"].ToString()) && !string.IsNullOrEmpty(drv["120+"].ToString()))
                lbl120.Text = drv["120+"].ToString() + "%";

            if (!string.IsNullOrEmpty(drv["TotalBal"].ToString()) && !string.IsNullOrEmpty(drv["NoOfPatients"].ToString()))
                lblTotalBal.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(drv["TotalBal"].ToString()));
            if (string.IsNullOrEmpty(drv["NoOfPatients"].ToString()) && !string.IsNullOrEmpty(drv["TotalBal"].ToString()))
                lblTotalBal.Text = drv["TotalBal"].ToString() + "%";
        }
    }
}