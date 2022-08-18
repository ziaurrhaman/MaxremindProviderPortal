using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class ProviderPortal_ReportsNew_CallBacks_ReportPostClaimSummary : System.Web.UI.Page
{

    string Mainprovidername = "";
   
    protected void Page_Load(object sender, EventArgs e)
    {
        int countLabel = 0;
        string nextClaimStatus = ""; string _DateTo = ""; string _DateFrom = "";
        string _TimeSpan = "";
        string ClaimStatus = "";

        ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();
        long PracticeId = Profile.PracticeId;
        string DateType = Request.Form["Datetype"];
        _DateFrom = Request.Form["DateFrom"];
        _DateTo = Request.Form["DateTo"];
        string PracticeLocationId = Request.Form["PracticeLocationId"];
        string POSCode = Request.Form["POSCode"];
        string CPTCode = Request.Form["CPTCode"];
        string Payer ="";

        string ReportType = Request.Form["ReportTypes"];

        if (DateType == "" || DateType == null)
        {
            DateType = "PostDate";
        }
        string Search_FileId = Request.Form["SearchFileId"];
        string SearchFileId = "";
        string phsicians = "";
        if (!string.IsNullOrEmpty(Request.Form["ProviderIds"]))
        {
            phsicians = Request.Form["ProviderIds"];
        }

       
        ClaimStatus = Request.Form["ClaimStatus"];

        if (_DateFrom != "" && _DateTo != "")
        {
            DateTime curDate = DateTime.Now;
            _DateFrom = new DateTime(curDate.Year, curDate.Month, 1).ToShortDateString();
            //DateTime endDate1 = startDate.AddMonths(1).AddDays(-1);
            _DateTo = (curDate).ToShortDateString();
            //TimeSpan.Text = _DateFrom + " - " + _DateTo;
        }
        else
        {
            //TimeSpan.Text = "All Records";
        }

        hdnClaimStatus.Value = ClaimStatus;
        hdnPracticeLocationId.Value = Request.Form["PracticeLocationId"];
        DataSet ds = new DataSet();
        bool? IsImportedDataOnly = null;
        if (!string.IsNullOrEmpty(Session["IsImported"] as string))
        {

            if (Session["IsImported"].ToString() == "2") { IsImportedDataOnly = true; }
            else if (Session["IsImported"].ToString() == "1") { IsImportedDataOnly = false; }
            else { IsImportedDataOnly = null; }
        }
        DataSet dsReportData = objPatientReportsDB.GetPostClaim(PracticeId, 10, 0, DateType, _DateFrom, _DateTo, PracticeLocationId, POSCode, ClaimStatus, SearchFileId, CPTCode, Payer, "PROLevel", IsImportedDataOnly, phsicians);

   
        hdnDateType.Value = DateType;
        hdnPracticeLocationId.Value = PracticeLocationId;
        hdnPlaceOfService.Value = POSCode;
        hdnproviders.Value = phsicians;
        hdnpayer.Value = Payer;
        hdnClaimStatus.Value = ClaimStatus;
        hdnReportTypeLevel.Value = "PROLevel";
        hdnPOSCode.Value = CPTCode;
        hdnFileSearchId.Value = SearchFileId;
        hdnStartDate.Value = _DateFrom;
        hdnEndDate.Value = _DateTo;
        hdnTotalRows.Value = "NoRows";
        rptpostlciam.DataSource = dsReportData.Tables[0];
        rptpostlciam.DataBind();

        LoadPracticeStaffOnNPI();
        InsurancesFromInsurance();
        LoadClaimStatus();
        GetMultipleFiles();
        LoadPlaceOfService();
    }




    protected void rptpostlciam_ItemDataBound(object sender, RepeaterItemEventArgs e)
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
    public void LoadPracticeStaffOnNPI()
    {
        ServiceProviderDB serviceProviderDB = new ServiceProviderDB();
        DataTable dtPayerName = serviceProviderDB.GetPracticeStaffonNPINum(Profile.PracticeId);
        //ddlPracticeStaffOnNpiNum.DataSource = dtPayerName;
        //ddlPracticeStaffOnNpiNum.DataTextField = "Providers";
        //ddlPracticeStaffOnNpiNum.DataValueField = "StaffNPI";
        //ddlPracticeStaffOnNpiNum.DataBind();
        //ddlPracticeStaffOnNpiNum.Items.Insert(0, new ListItem("All", ""));
        ProvidersCustomize.DataSource = dtPayerName;
        ProvidersCustomize.DataTextField = "Providers";
        ProvidersCustomize.DataValueField = "StaffNPI";
        ProvidersCustomize.DataBind();
        ProvidersCustomize.Items.Insert(0, new ListItem("All", ""));
    }
    private void InsurancesFromInsurance()
    {
        InsuranceDB objInsuranceDB = new InsuranceDB();
        using (DataTable dtInsuranceDb = objInsuranceDB.Insurance_GetBySearchCriteria(Profile.PracticeId, "", "", "", "", 100, 0, "").Tables[0])
        {
            rptInsurances.DataSource = dtInsuranceDb;
            rptInsurances.DataBind();
        }

    }
    public void LoadPlaceOfService()
    {
        PlaceOfServicesDB objPlaceOfServicesDB = new PlaceOfServicesDB();
        DataTable dtPOS = objPlaceOfServicesDB.GetAllByPractice(Profile.PracticeId);
        rptPlaceOfService.DataSource = dtPOS;
        rptPlaceOfService.DataBind();
    }

    public void LoadClaimStatus()
    {
        SubmissionStatusCodesDB objSubmissionStatusCodesDB = new SubmissionStatusCodesDB();
        DataTable dtSubmissionStatusCodes = objSubmissionStatusCodesDB.GetSubmissionStatusCodes();

        rptCalimStatus.DataSource = dtSubmissionStatusCodes;
        rptCalimStatus.DataBind();
    }
    protected void GetMultipleFiles()
    {
        UploadFilesDB uploadFileDB = new UploadFilesDB();
        int PracticeId = Convert.ToInt32(Profile.PracticeId);
        DataTable ClaimFilesDetails = uploadFileDB.GetFilesOfClaim(PracticeId, null);
        RptFile.DataSource = ClaimFilesDetails;
        RptFile.DataBind();
    }
}