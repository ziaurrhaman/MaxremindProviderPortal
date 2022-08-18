using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web; 
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProviderPortal_Reports_CallBacks_FilterPaymentApplicationReport : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();
        long PracticeId = Profile.PracticeId;
        string PayerName = Request.Form["PayerName"];
        string CheckNumber = Request.Form["CheckNumber"];
        string PostDate = Request.Form["PostDate"];
        int Rows = int.Parse(Request.Form["Rows"]);
        int PageNumber = int.Parse(Request.Form["PageNumber"]);
        string SortBy = Request.Form["SortBy"];
        DataSet dsReportData = objPatientReportsDB.GetPaymentApplication(PracticeId, Rows, PageNumber, SortBy, PayerName, CheckNumber, PostDate);

        rptPaymentApplication.DataSource = dsReportData.Tables[0];
        rptPaymentApplication.DataBind();
        ltrTotalRows.Text = dsReportData.Tables[1].Rows[0]["TotalRows"].ToString();
    }
    protected void rptPaymentApplication_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {

        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView drv = (DataRowView)e.Item.DataItem;
            string Patientid = drv["Patientid"].ToString();
            string CheckNumber = drv["CheckNumber"].ToString();
            string ClaimId = drv["ClaimId"].ToString();
            string PostDate = drv["PostDate"].ToString();
            Label lblPostDate = (Label)e.Item.FindControl("lblPostDate");
            Label lblSubTotal = (Label)e.Item.FindControl("lblSubTotal");
            Label lblChkGrandTotal = (Label)e.Item.FindControl("lblChkGrandTotal");
            Label lblGrandTotal = (Label)e.Item.FindControl("lblGrandTotal");
            if (Patientid == "" && CheckNumber != "")
            {
                lblChkGrandTotal.Text = "Check Number's Grand Total :";
            }
            else if (Patientid != "" && ClaimId == "")
            {
                lblSubTotal.Text = "Sub Total :";
            }
            else if (CheckNumber == "")
            {
                lblGrandTotal.Text = "Grand Total :";
            }
            else
            {
                lblPostDate.Text = PostDate;
            }
        }
    }
}