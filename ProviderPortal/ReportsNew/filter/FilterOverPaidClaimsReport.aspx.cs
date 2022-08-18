using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class ProviderPortal_ReportsNew_filter_FilterOverPaidClaims : System.Web.UI.Page
{
    string DateFrom = "";
    string DateTo = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        ReportsDB objOverClaimDB = new ReportsDB();
        long PracticeId = Profile.PracticeId;
        int Rows = int.Parse(Request.Form["Rows"]);
        int PageNumber = int.Parse(Request.Form["PageNumber"]);
        DateFrom = Request.Form["StartDate"];
        DateTo = Request.Form["EndDate"];
        string Payers = Request.Form["Payers"];
        string InsuranceType = Request.Form["InsuranceType"];
        string ClaimStatus = Request.Form["ClaimStatus"];
        string LocationId = Request.Form["LocationId"];
        string ProviderId = Request.Form["ProviderId"];
        string SortBy = Request.Form["SortBy"];
        string DateType = Request.Form["DateType"];

        DataSet dsReportData = objOverClaimDB.GetOverPaidClaims(PracticeId, Rows, PageNumber, SortBy, DateFrom, DateTo, DateType, Payers, ClaimStatus, InsuranceType, LocationId, ProviderId);
        rptReportData.DataSource = dsReportData.Tables[0];
        rptReportData.DataBind();
        ltrTotalRows.Text = dsReportData.Tables[1].Rows[0]["TotalRows"].ToString();
        hdnDateFrom.Value = DateFrom;
        hdnDateTo.Value = DateTo;
        hdnDateType.Value = DateType;
        hdnInsuranceType.Value = InsuranceType;
        hdnClaimStatus.Value = ClaimStatus;
        hdnPayers.Value = Payers;
        hdnProviderId.Value = ProviderId;
        hdnLocationId.Value = LocationId;
        string[] _DateFrom = DateFrom.Split(new Char[] { '-' });
        string[] _DateTo = DateTo.Split(new Char[] { '-' });
        TimeSpan.Text = _DateFrom[1] + "/" + _DateFrom[2] + "/" + _DateFrom[0] + "-" + _DateTo[1] + "/" + _DateTo[2] + "/" + _DateTo[0];

    }
}