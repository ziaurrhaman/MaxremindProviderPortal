using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class ProviderPortal_Reports_CallBacks_FilterDailyPayments : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.Form["action"];
        
        if (action == "Filter")
        {
            LoadReport();
        }
    }
    
    private void LoadReport()
    {
        string PaymentDate = Request.Form["PaymentDate"];
        int Rows = int.Parse(Request.Form["Rows"]);
        int PageNumber = int.Parse(Request.Form["PageNumber"]);
        //string SortBy = Request.Form["SortBy"];
        string SortBy = "PaymentDate DESC";
        ERAMasterDB objERAMasterDB = new ERAMasterDB();

        DataSet dsReportData = objERAMasterDB.Report_DailyPayments(long.Parse(Profile.PracticeId.ToString()), Rows, PageNumber, SortBy, PaymentDate);
        
        rptReportData.DataSource = dsReportData.Tables[0];
        rptReportData.DataBind();
        
        ltrTotalRows.Text = dsReportData.Tables[1].Rows[0]["TotalRows"].ToString();
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