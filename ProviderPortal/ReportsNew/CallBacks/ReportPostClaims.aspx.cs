using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class EMR_ReportsNew_CallBacks_ReportPostClaims : System.Web.UI.Page
{
    int countLabel = 0;
    string nextClaimStatus = ""; string _DateTo = ""; string _DateFrom = "";
    string _TimeSpan = "";
    string ClaimStatus = "";
    string Mainprovidername = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.Form["Action"];
        if (action == "Filter")
        {
            string _DateTo = ""; string _DateFrom = "";
            string ClaimStatus = "";

            ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();
            long PracticeId = Profile.PracticeId;
            string DateType = Request.Form["Datetype"];
            _DateFrom = Request.Form["BillDateFrom"];
            _DateTo = Request.Form["BillDateTo"];
            string PracticeLocationId = Request.Form["PracticeLocationId"];
            string POSCode = Request.Form["POSCode"];
            string CPTCode = Request.Form["CPTCode"];
            string Payer = Request.Form["Payer"];
            string ReportType = Request.Form["ReportType"];
            string Search_FileId = Request.Form["SearchFileId"];
            string SearchFileId = "";
            string phsicians = "";
            if (!string.IsNullOrEmpty(Request.Form["ProviderIds"]))
            {
                phsicians = Request.Form["ProviderIds"];
            }
            ClaimStatus = Request.Form["ClaimStatus"];
            DataSet ds = new DataSet();
            bool? IsImportedDataOnly = null;
            if (!string.IsNullOrEmpty(Session["IsImported"] as string))
            {

                if (Session["IsImported"].ToString() == "2") { IsImportedDataOnly = true; }
                else if (Session["IsImported"].ToString() == "1") { IsImportedDataOnly = false; }
                else { IsImportedDataOnly = null; }
            }
            if(ReportType == "" || ReportType == null)
            {
                ReportType = "PROLevel";
            }
            DataSet dsReportData = objPatientReportsDB.GetPostClaim(PracticeId, 10, 0, DateType, _DateFrom, _DateTo, PracticeLocationId, POSCode, ClaimStatus, Search_FileId, CPTCode, Payer, ReportType, IsImportedDataOnly, phsicians);

            hdnClaimStatus.Value = ClaimStatus;
            hdnPracticeLocationId.Value = Request.Form["PracticeLocationId"];
            hdnDateType.Value = DateType;
            hdnPracticeLocationId.Value = PracticeLocationId;
            hdnPlaceOfService.Value = POSCode;
            hdnproviders.Value = phsicians;
            hdnpayer.Value = Payer;
            hdnClaimStatus.Value = ClaimStatus;
            hdnReportTypeLevel.Value = ReportType;
            hdnPOSCode.Value = CPTCode;
            hdnFileSearchId.Value = Search_FileId;
            hdnStartDate.Value = _DateFrom;
            hdnEndDate.Value = _DateTo;
            rptFilterPostlciam.DataSource = dsReportData.Tables[0];
            rptFilterPostlciam.DataBind();
        }
        else
        {
            LoadReport();
        }

    }
    private void LoadReport()
    {
        ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();
        long PracticeId = Profile.PracticeId;
        string DateType = Request.Form["DateType"];
        _DateFrom = Request.Form["StartDate"];
        _DateTo = Request.Form["EndDate"];
        string PracticeLocationId = Request.Form["PracticeLocationId"];
        string POSCode = Request.Form["PlaceOfService"];
        string CPTCode = Request.Form["POSCode"];
        string Payer = Request.Form["payer"];

        string ReportType = Request.Form["ReportType"];


        string Search_FileId = Request.Form["FileSearchId"];
        string SearchFileId = Search_FileId;
        string phsicians = "";
        if (!string.IsNullOrEmpty(Request.Form["providers"]))
        {
            phsicians = Request.Form["providers"];
        }


        ClaimStatus = Request.Form["ClaimStatus"];
        string name = Request.Form["name"];

        DataSet ds = new DataSet();


        bool? IsImportedDataOnly = null;
        if (!string.IsNullOrEmpty(Session["IsImported"] as string))
        {

            if (Session["IsImported"].ToString() == "2") { IsImportedDataOnly = true; }
            else if (Session["IsImported"].ToString() == "1") { IsImportedDataOnly = false; }
            else { IsImportedDataOnly = null; }
        }


        DataSet dsReportData = objPatientReportsDB.GetPostClaim(PracticeId, 10, 0, DateType, _DateFrom, _DateTo, PracticeLocationId, POSCode, ClaimStatus, SearchFileId, CPTCode, Payer, ReportType, IsImportedDataOnly, phsicians, name);
        rptpostlciam.DataSource = dsReportData.Tables[1];
        rptpostlciam.DataBind();
        ltrTotalRows.Value = dsReportData.Tables[2].Rows[0]["TotalRows"].ToString();

    }
    protected void rptpostlciam_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView drv = (DataRowView)e.Item.DataItem;
            string ProcedureCode = drv["ProcedureCode"].ToString();
            Label lblProcedureCode = (Label)e.Item.FindControl("lblProcedureCode");
            if (ProcedureCode == "")
            {
                lblProcedureCode.Style.Add("display", "none");
            }
            else
            {
                lblProcedureCode.Style.Add("display", "block");
            }
        }
    }
    protected void rptpostlciam_ItemDataBoundFilter(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView drv = (DataRowView)e.Item.DataItem;
            string ProviderName = drv["Provider"].ToString();
            string ProcedureCode = drv["ProcedureCode"].ToString();
            string Frequency = drv["Frequency"].ToString();
            string Charges = drv["Charges"].ToString();
            string Payments = drv["Payments"].ToString();
            string AR = drv["AR"].ToString();

            Label LBLProviderName = (Label)e.Item.FindControl("LBLProviderName");
            Label lblFrequency = (Label)e.Item.FindControl("lblFrequency");
            Label lblCharges = (Label)e.Item.FindControl("lblCharges");
            Label lblPayments = (Label)e.Item.FindControl("lblPayments");
            Label lblAR = (Label)e.Item.FindControl("lblAR");

            HtmlTableRow Providertr = (HtmlTableRow)e.Item.FindControl("ProviderNameTr");
            HtmlTableRow ProviderSummaryTr = (HtmlTableRow)e.Item.FindControl("ProviderSummaryTr");
            HtmlTableRow DataRowTr = (HtmlTableRow)e.Item.FindControl("DataRowTr");
            HtmlTableRow ColumnsTr = (HtmlTableRow)e.Item.FindControl("ColumnsTr");

            if (Mainprovidername != ProviderName)
            {
                Providertr.Style.Remove("display");
                Mainprovidername = ProviderName;
                LBLProviderName.Text = ProviderName;
                DataRowTr.Style.Remove("display");
                ColumnsTr.Style.Remove("display");
            }
            else
            {
                Providertr.Style.Add("display", "none");

                if (ProcedureCode == "")
                {
                    Providertr.Style.Add("display", "none");
                    DataRowTr.Style.Add("display", "none");
                    ColumnsTr.Style.Add("display", "none");
                    ProviderSummaryTr.Style.Remove("display");
                    lblFrequency.Text = Frequency;
                    lblCharges.Text = Charges;
                    lblPayments.Text = Payments;
                    lblAR.Text = AR;

                }
                else
                {
                    ProviderSummaryTr.Style.Add("display", "none");
                    DataRowTr.Style.Remove("display");
                    //ColumnsTr.Style.Remove("display");
                }


            }

        }
    }
}