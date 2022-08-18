using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.HtmlControls;

public partial class EMR_ReportsNew_filter_FilterUnpaidInsuranceClaimsReport : System.Web.UI.Page
{
    int Balance = 0;
    //Edited By Faiza Bilal 6-14-2022 to change layout of grid
    int PatientCheck = 0;
    //End Edited By Faiza Bilal 6-14-2022 to change layout of grid
    protected void Page_Load(object sender, EventArgs e)
    {
        ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();
        long PracticeId = Profile.PracticeId;
        string PayerId = Request.Form["PayerId"];
        string ProviderId = Request.Form["ProviderId"];
        string PracticeLocationId = Request.Form["PracticeLocationId"];
        if (!string.IsNullOrEmpty(Request.Form["Balance"]))
            Balance = int.Parse(Request.Form["Balance"]);
        string DateOfService = Request.Form["DateOfService"];
        string BillDateFrom = Request.Form["BillDateFrom"];
        string BillDateTo = Request.Form["BillDateTo"];
        string DateType = "BillDate";
        //int Rows = int.Parse(Request.Form["Rows"]);
        int PageNumber = int.Parse(Request.Form["PageNumber"]);

        string SortBy = Request.Form["SortBy"];
        DataSet dsReportData = objPatientReportsDB.GetUnpaidInsuranceClaims(PracticeId, 10000000, PageNumber, "", PayerId, ProviderId, PracticeLocationId, Balance, DateOfService, BillDateFrom, BillDateTo, DateType);

       rptReportData.DataSource = dsReportData.Tables[0];
        rptReportData.DataBind();
        ltrTotalRows.Text = dsReportData.Tables[1].Rows[0]["TotalRows"].ToString();
        hdnPayerId.Value = Request.Form["PayerId"];
        hdnProviderId.Value = Request.Form["ProviderId"];
        hdnPracticeLocationId.Value = Request.Form["PracticeLocationId"];
        hdnBalance.Value = Request.Form["Balance"];
        hdnDateOfService.Value = Request.Form["DateOfService"];
        hdnBillDateFrom.Value = Request.Form["BillDateFrom"];
        hdnBillDateTo.Value = Request.Form["BillDateTo"];
        string[] DateFrom = BillDateFrom.Split(new Char[] { '-' });
        string[] DateTo = BillDateTo.Split(new Char[] { '-' });
        TimeSpan.Text = DateFrom[1] + "/" + DateFrom[2] + "/" + DateFrom[0] + "-" + DateTo[1] + "/" + DateTo[2] + "/" + DateTo[0];

    }
    protected void rptReportData_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView drv = (DataRowView)e.Item.DataItem;
            //Edited By Faiza Bilal 6-14-2022 to change layout of grid
            string Patient = drv["Patient"].ToString();
            //End Edited By Faiza Bilal 6-14-2022 to change layout of grid
            Label lblProcedures = (Label)e.Item.FindControl("lblProcedures");
            Label lblCharges = (Label)e.Item.FindControl("lblCharges");
            Label lblAdjust = (Label)e.Item.FindControl("lblAdjust");
            Label lblReceipts = (Label)e.Item.FindControl("lblBalance");
            Label lblBalance = (Label)e.Item.FindControl("lblBalance");
            //Edited By Faiza Bilal 6-14-2022 to change layout of grid
            Label LblPatient = (Label)e.Item.FindControl("LblPatient");
            HtmlTableCell trmain = (HtmlTableCell)e.Item.FindControl("trpatient");
            if (PatientCheck == 0)
            {
                
                LblPatient.Text = Patient;
                
            }
            else
            {
                LblPatient.Text = "";
            }
            PatientCheck++;
            //End Edited By Faiza Bilal 6-14-2022 to change layout of grid
            if (!string.IsNullOrEmpty(drv["Patient"].ToString()) && string.IsNullOrEmpty(drv["Encounter"].ToString()))
            {
                //Edited By Faiza Bilal 6-14-2022 to change layout of grid
                PatientCheck = 0;
                trmain.Attributes.Add("style", "border-top-style:hidden;background-color:white");
                //End Edited By Faiza Bilal 6-14-2022 to change layout of grid
                lblProcedures.Style.Add("font-weight", "bold");
                lblProcedures.Style.Add("float", "left");
                lblProcedures.Text = "Total : ";
            }
            else if (string.IsNullOrEmpty(drv["Patient"].ToString()) && string.IsNullOrEmpty(drv["Encounter"].ToString()))
            {
                lblProcedures.Style.Add("font-weight", "bold");
                lblProcedures.Style.Add("float", "left");
                lblProcedures.Text = "Grand Total : ";
            }
            else
            {
                lblProcedures.Text = drv["Procedures"].ToString();
            }
            if (!string.IsNullOrEmpty(drv["Charges"].ToString()))
                lblCharges.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(drv["Charges"].ToString()));

            //if (!string.IsNullOrEmpty(drv["Adjust"].ToString()))
            //    lblAdjust.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(drv["Adjust"].ToString()));

            //if (!string.IsNullOrEmpty(drv["Receipts"].ToString()))
            //    lblReceipts.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(drv["Receipts"].ToString()));

            //if (!string.IsNullOrEmpty(drv["Balance"].ToString()))
            //    lblBalance.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(drv["Balance"].ToString()));
        }
    }
}
