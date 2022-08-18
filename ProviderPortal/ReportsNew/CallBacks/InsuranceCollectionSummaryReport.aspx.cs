using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.HtmlControls;

public partial class EMR_ReportsNew_CallBacks_InsuranceCollectionSummaryReport : System.Web.UI.Page
{
    int countLabel = 0;
    string nextClaimStatus = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadReport();
    }
    private void LoadReport()
    {
        ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();
        long PracticeId = Profile.PracticeId;
        string AgingDate = Request.Form["AgingDate"];
        string AgingType = Request.Form["AgingType"];
        string PracticeLocationId = Request.Form["PracticeLocationId"];
        string ProviderId = Request.Form["ProviderId"];
        string PayerId = Request.Form["PayerId"];
        string ClaimStatus = Request.Form["ClaimStatus"];
        hdnAgingDate.Value = Request.Form["AgingDate"];
        hdnAgingType.Value = Request.Form["AgingType"];
        hdnPracticeLocationId.Value = Request.Form["PracticeLocationId"];
        hdnPayerId.Value = Request.Form["PayerId"];
        hdnClaimStatus.Value = Request.Form["ClaimStatus"];
        hdnProviderId.Value = Request.Form["ProviderId"];
        DataSet dsReportData = objPatientReportsDB.GetInsuranceCollectionSummary(PracticeId, 10, 0, "ClaimStatus ASC", AgingType, AgingDate, PracticeLocationId, ProviderId, PayerId, ClaimStatus);

        rptInsuranceCollectionSummary.DataSource = dsReportData.Tables[0];
        rptInsuranceCollectionSummary.DataBind();
        hdnTotalRows.Value = dsReportData.Tables[1].Rows[0]["TotalRows"].ToString();


    }
    protected void rptInsuranceCollectionSummary_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView drv = (DataRowView)e.Item.DataItem;
            int rptIndex = e.Item.ItemIndex;
            //******For 0 Index******/
            HtmlTableRow trClaimStatus = (HtmlTableRow)e.Item.FindControl("trClaimStatus");
            HtmlTableCell thClaimStatus = (HtmlTableCell)e.Item.FindControl("thClaimStatus");
            Label lblClaimStatus = (Label)e.Item.FindControl("lblClaimStatus");
            Label lblPeriod = (Label)e.Item.FindControl("lblPeriod");
            Label lblTotalPeriod = (Label)e.Item.FindControl("lblTotalPeriod");
            /******for other than 0 index***********/
            HtmlTableRow trLastClaimStatus = (HtmlTableRow)e.Item.FindControl("trLastClaimStatus");
            HtmlTableCell thLastClaimStatus = (HtmlTableCell)e.Item.FindControl("thLastClaimStatus");
            Label lblLastClaimStatus = (Label)e.Item.FindControl("lblLastClaimStatus");
            Label lblEncounters = (Label)e.Item.FindControl("lblEncounters");
            Label lblProcedures = (Label)e.Item.FindControl("lblProcedures");
            Label lblValue = (Label)e.Item.FindControl("lblValue");
            Label lblARBalance = (Label)e.Item.FindControl("lblARBalance");
            Label lblPercentageOfAR = (Label)e.Item.FindControl("lblPercentageOfAR");
            Label lblAge = (Label)e.Item.FindControl("lblAge");
            Label lblGranTotalPeriod = (Label)e.Item.FindControl("lblGranTotalPeriod");
            if (string.IsNullOrEmpty(drv["Period"].ToString()))
                countLabel++;
            if (!string.IsNullOrEmpty(drv["ClaimStatus"].ToString()))
            {
                if (string.IsNullOrEmpty(drv["Period"].ToString()) || rptIndex == 0)
                {
                    string ClaimStatus = "";
                    if (!string.IsNullOrEmpty(drv["ClaimStatus"].ToString()))
                        ClaimStatus = drv["ClaimStatus"].ToString();
                    if (rptIndex == 0)
                    {
                        /*lblClaimStatus.Style.Add("float", "left");
                        trClaimStatus.Style.Remove("display");
                        trClaimStatus.Style.Add("border-top", "1px solid #ccc");
                        lblClaimStatus.Text = ClaimStatus;*/
                    }
                    else if (string.IsNullOrEmpty(drv["Period"].ToString()))
                    {
                        lblTotalPeriod.Style.Add("font-weight", "bold");
                        lblTotalPeriod.Text = "Total " + ClaimStatus;
                        /* lblLastClaimStatus.Style.Add("float", "left");
                         trLastClaimStatus.Style.Remove("display");
                         trLastClaimStatus.Style.Add("border-top", "1px solid #ccc");
                         lblLastClaimStatus.Text = ClaimStatus;*/
                    }

                }
            }
            else
            {
                lblGranTotalPeriod.Style.Add("font-weight", "bold");
                lblGranTotalPeriod.Text = "Grand Total";
            }
            if (!string.IsNullOrEmpty(drv["ClaimStatus"].ToString()))
                lblClaimStatus.Text = drv["ClaimStatus"].ToString();

            if (!string.IsNullOrEmpty(drv["Period"].ToString()))
                lblPeriod.Text = drv["Period"].ToString();

            if (!string.IsNullOrEmpty(drv["Encounters"].ToString()))
                lblEncounters.Text = drv["Encounters"].ToString();

            if (!string.IsNullOrEmpty(drv["Procedures"].ToString()))
                lblProcedures.Text = drv["Procedures"].ToString();

            if (!string.IsNullOrEmpty(drv["Value"].ToString()))
                lblValue.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(drv["Value"].ToString()));

            if (!string.IsNullOrEmpty(drv["ARBalance"].ToString()))
                lblARBalance.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(drv["ARBalance"].ToString()));

            if (!string.IsNullOrEmpty(drv["%ofAR"].ToString()))
                lblPercentageOfAR.Text = drv["%ofAR"].ToString() + "%";

            if (!string.IsNullOrEmpty(drv["Age"].ToString()))
                lblAge.Text = drv["Age"].ToString();
        }
    }
}