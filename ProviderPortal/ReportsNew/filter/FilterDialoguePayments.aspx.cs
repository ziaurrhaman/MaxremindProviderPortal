using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.HtmlControls;
public partial class EMR_ReportsNew_filter_FilterDialogue : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Request.Form["Action"])) 
        {
            if (Request.Form["Action"] == "GetFilterPatient") { GetPatientList(); }
            return;
        }

        MultiUserName();

        string ReportType = Request.Form["ReportTypeName"];
        if (ReportType == "PaymentByProcedureReport")
        {
            divPaymentByProcedure.Style.Remove("display");
            divTimeSpan.Style.Remove("display");

        }  //
        if (ReportType == "PaymentsDetailReport")
        {
            divPaymentsDetail.Style.Remove("display");
            divTimeSpan.Style.Remove("display");

        }
        if (ReportType == "PaymentsSummaryAndDetail")
        {

            divPaymentsSummary.Style.Remove("display");
            //LoadPayersFromERAMasterTable();
            divPostType.Style.Remove("display");
           
            //LoadPatientFromERA();
            ddlPostType.Items.FindByValue("CheckDate").Enabled = true;
            ddlPostType.Items.FindByValue("DOS").Enabled = false;
            InsurancesFromERA();
          //  divPayerDropDownSearch.Style.Remove("display");
            divPracticeStaffOnNpiNum.Style.Remove("display");
            LoadPracticeStaffOnNPI();
           //divPaymentsSummary.Style.Remove("display");
            divTimeSpan.Style.Remove("display");
            
        }
        if (ReportType == "UnpostedPaymentsDetailandSummary")
        {

            divUnpostedPaymentsDetailandSummary.Style.Remove("display");

            divPostType.Style.Remove("display");
            ddlPostType.Items.FindByValue("CheckDate").Enabled = true;
            ddlPostType.Items.FindByValue("DOS").Enabled = false;
            divCheckNumberSearch.Style.Remove("display");
            divPayerType2.Style.Remove("display");
            divTimeSpan.Style.Remove("display");


        }
        if (ReportType == "ProcedurePaymentsSummaryAndDetail")
        {
            divProcedurePaymentsSummary.Style.Remove("display");
            divReportBilledAs.Style.Remove("display");
            InsurancesFromInsurance();
            divPayerDropDownSearch.Style.Remove("display");
            divCPT.Style.Remove("display");
            divCPT.Style.Add("width", "100%");
        }
        if (ReportType == "ContractManagementSummaryReport")
        {
            divContractManagementSummary.Style.Remove("display");
            divPostType.Style.Remove("display");
            divReportServiceProvider.Style.Remove("display");
            LoadProvider();
            divPracticeLocationId.Style.Remove("display");
            LoadPracticeLocation();
            divBillDates.Style.Remove("display");
            hrHideForEmployee.Style.Add("display", "none");
            divReportProcedure.Style.Remove("display");
            divReportPatientName.Style.Remove("display");
            LoadPatient();
            divInsuranceDetailDialog.Style.Remove("display");
            LoadPatientInsurance();
        }





        if (ReportType == "ContractManagementDetailReport")
        {
            divContractManagementDetail.Style.Remove("display");
            //divTimeSpan.Style.Remove("display");
            //hrPatientDetailDialog.Style.Add("display", "none");
            divPostType.Style.Remove("display");
            divReportServiceProvider.Style.Remove("display");
            LoadProvider();
            divPracticeLocationId.Style.Remove("display");
            LoadPracticeLocation();
            divReportPayerScenario.Style.Remove("display");
           // LoadPayersFromClaim();
            divBillDates.Style.Remove("display");

            //hrEndPatientDetail.Style.Add("display", "none");
            hrHideForEmployee.Style.Add("display", "none");
            //spnDOB.Style.Remove("display");
            divReportProcedure.Style.Remove("display");
            //divReportProcedure.Style.Add("border-bottom", "1px solid #ccc !important");
            //divReportProcedure.Style.Add("height", "35px");
            //divReportProcedure.Style.Add("margin-top", "4%");
            divReportPatientName.Style.Remove("display");
            LoadPatient();
            //ddlPatientList.Style.Add("width", "81% !important");
            //ddlPatientList.Style.Add("margin-left", "41px !important");
        }
        if (ReportType == "MissedCopaysReport")
        {
            divMissedCopays.Style.Remove("display");
            divTimeSpan.Style.Remove("display");

        }
        if (ReportType == "PaymentApplicationReport")
        {
            divPaymentApplication.Style.Remove("display");
            //hrEndPatientDetail.Style.Add("display", "none");

            divPayersName.Style.Remove("display");
            divCheckNumber.Style.Remove("display");
            divPostDate.Style.Remove("display");
            LoadPayerName();
        }
        if (ReportType == "PaymentApplicationSummaryReport")
        {
            divPaymentApplicationSummary.Style.Remove("display");
            divTimeSpan.Style.Remove("display");

        }
        if (ReportType == "UnappliedAnalysisReport")
        {
            divUnappliedAnalysis.Style.Remove("display");
            divTimeSpan.Style.Remove("display");

        }
        if (ReportType == "PayerAnalysis")    
        {
            divPayerMixSummary.Style.Remove("display");
            InsurancesFromInsurance();
            divPayerDropDownSearch.Style.Remove("display");
            divPayerDropDownSearch.Style.Add("width", "100%");
        }
        if (ReportType == "ARAgingSummaryReport")
        {
            divARAgingSummary.Style.Remove("display");
            divAgingBy.Style.Remove("display");
           // divAgingDate.Style.Remove("display");
            divPracticeLocationId.Style.Remove("display");
            LoadPracticeLocation();
            //divPracticeStaffOnNpiNum.Style.Remove("display");
            //LoadPracticeStaffOnNPI();

            divReportServiceProvider.Style.Remove("display");
            LoadProvider();

            divPayerDropDownSearch.Style.Remove("display");
            InsurancesFromInsurance();
            hrHideForEmployee.Style.Add("display", "none");
             divAsof.Style.Remove("display");
        }
        if (ReportType == "InsuranceCollectionDetailReport")
        {
            divInsuranceCollectionDetail.Style.Remove("display");
            divAgingType.Style.Remove("display");
            divAgingDate.Style.Remove("display");
            divPracticeLocationId.Style.Remove("display");
            LoadPracticeLocation();
            divReportServiceProvider.Style.Remove("display");
            LoadProvider();
            divReportPayerScenario.Style.Remove("display");
          //  LoadPayersFromClaim();
            hrHideForEmployee.Style.Add("display", "none");
            divReportClaimStatus.Style.Remove("display");
            LoadClaimStatus();
        }
        if (ReportType == "InsuranceCollectionSummaryReport")
        {
            divInsuranceCollectionSummary.Style.Remove("display");
            divAgingType.Style.Remove("display");
            divAgingDate.Style.Remove("display");
            divPracticeLocationId.Style.Remove("display");
            LoadPracticeLocation();
            divReportServiceProvider.Style.Remove("display");
            LoadProvider();
            divReportPayerScenario.Style.Remove("display");
        //    LoadPayersFromClaim();
            hrHideForEmployee.Style.Add("display", "none");
            divReportClaimStatus.Style.Remove("display");
            LoadClaimStatus();
        }
        if (ReportType == "PatientCollectionSummary")
        {
            divPatientCollectionSummary.Style.Remove("display");
            divAgingType.Style.Remove("display");
            divAgingDate.Style.Remove("display");
            divPracticeLocationId.Style.Remove("display");
            LoadPracticeLocation();
            divReportServiceProvider.Style.Remove("display");
            LoadProvider();
            //divReportPatientName.Style.Remove("display");
            LoadPatient();
            //hrHideForEmployee.Style.Add("display", "none");
        }
        if (ReportType == "PatientCollectionDetail")
        {
            divPatientCollectionDetail.Style.Remove("display");
            divAgingType.Style.Remove("display");
            divAgingDate.Style.Remove("display");
            divPracticeLocationId.Style.Remove("display");
            LoadPracticeLocation();
            divReportServiceProvider.Style.Remove("display");
            LoadProvider();
            //divReportPatientName.Style.Remove("display");
            LoadPatient();
            //hrHideForEmployee.Style.Add("display", "none");
        }
        if (ReportType == "UnpaidInsuranceClaimsReport")
        {
            txtBillDateFrom.Enabled = true;
            txtBillDateTo.Enabled = true;
            divUnpaidInsuranceCliams.Style.Remove("display");

            divDateOfService.Style.Remove("display");
            divPracticeLocationId.Style.Remove("display");
            LoadPracticeLocation();
            divReportServiceProvider.Style.Remove("display");
            divReportUnpaidinsurances.Style.Remove("display");
            LoadProvider();

            GetUnpaidInsurancsedata();

            divBillDates.Style.Remove("display");
            hrHideForEmployee.Style.Add("display", "none");
        }

        if (ReportType == "DenialsDetailReport")
        {
            divDenialsDetail.Style.Remove("display");
            divPostType.Style.Remove("display");
            divPracticeLocationId.Style.Remove("display");
            LoadPracticeLocation();
            divReportServiceProvider.Style.Remove("display");
            LoadProvider();
            divReportDenailPayerName.Style.Remove("display");
           // LoadDenailPayerName();
            divReportAdjustmentCode.Style.Remove("display");
            LoadAdjustmentCode();
            divTimeSpan.Style.Remove("display");
            hrHideForEmployee.Style.Add("display", "none");
            //  LoadPatient();
        }
        if (ReportType == "DenialsSummaryReport")
        {
            divDenialsSummary.Style.Remove("display");
            divPostType.Style.Remove("display");
            divPracticeLocationId.Style.Remove("display");
            LoadPracticeLocation();
            divReportServiceProvider.Style.Remove("display");
            LoadProvider();
            divReportDenailPayerName.Style.Remove("display");
           // LoadDenailPayerName();
            divReportAdjustmentCode.Style.Remove("display");
            LoadAdjustmentCode();
            divTimeSpan.Style.Remove("display");
            hrHideForEmployee.Style.Add("display", "none");
            // LoadPatient();
        }
        if (ReportType == "ERAEOBListReport")
        {
            //ddlInsuranceList.Style.Remove("width");
            //ddlInsuranceList.Style.Add("width", "80.5%");
            divERAEOBList.Style.Remove("display");
            divInsuranceDetailDialog.Style.Remove("display");
            LoadPatientInsurance();
            divReportPaymentType.Style.Remove("display");
            divPaymentMethod.Style.Remove("display");
            divTimeSpan.Style.Remove("display");
            hrHideForEmployee.Style.Add("display", "none");
        }
        if (ReportType == "PatientTransactionsDetail")
        {
            divPatientTransactionsDetail.Style.Remove("display");
            divPatientTransactionsDetail.Style.Remove("width");

            LoadPatient();
            divTimeSpan.Style.Remove("display");
            divPatFilter.Style.Remove("display");

        }


        if (ReportType == "EncounterDetailReport")
        {
            divEncounterDetail.Style.Remove("display");
            divPostType.Style.Remove("display");
            divSubmissionStatus.Style.Remove("display");
            SubmissionStatusCodesInformation();
            divPracticeLocationId.Style.Remove("display");
            LoadPracticeLocation();
            divReportServiceProvider.Style.Remove("display");
            LoadProvider();
            divReportPayerScenario.Style.Remove("display");
            //LoadPayersFromClaim();
            divBillDates.Style.Remove("display");

        }
        if (ReportType == "EncounterSummaryReport")
        {
            divEncounterDetail.Style.Remove("display");
            divPostType.Style.Remove("display");
            divSubmissionStatus.Style.Remove("display");
            SubmissionStatusCodesInformation();
            divPracticeLocationId.Style.Remove("display");
            LoadPracticeLocation();
            divReportServiceProvider.Style.Remove("display");
            LoadProvider();
            divReportPayerScenario.Style.Remove("display");
          //  LoadPayersFromClaim();
            divBillDates.Style.Remove("display");

        }

        //  Appointment Detail
        //Added By rizwan  22 May 2018

        if (ReportType == "AppointmentsDetailReport")
        {
            divAppointmentDetail.Style.Remove("display");

            divReportServiceProvider.Style.Remove("display");
            LoadProvider();
            divPracticeLocationId.Style.Remove("display");
            LoadPracticeLocation();

            divReportPatientName.Style.Remove("display");
           // LoadAppoitmentPatient();
            divAppointmentStatus.Style.Remove("display");
            AppointmentStatus();

            divAppointmentReasons.Style.Remove("display");
            AppointmentReasons();
            divTimeSpan.Style.Remove("display");

        }

        if (ReportType == "ReportPostClaimSummary")
        {
            divPostClaim.Style.Remove("display");
            // divClaimPostDate.Style.Remove("display");
            divPostType.Style.Remove("display");
            ddlPostType.Items.FindByValue("SubmissionDate").Enabled = true;
            LoadPracticeLocation();
            divPracticeLocationId.Style.Remove("display");
            divPlaceOfServiceReport.Style.Remove("display");
            LoadPlaceOfService();

            // hrEndPatientDetail.Style.Add("display", "none");
            hrHideForEmployee.Style.Add("display", "none");
            divCPT.Style.Remove("display");
            //txtClaimPostDate.Text = DateTime.Now.ToString("MM/dd/yyy");
            divBillDates.Style.Remove("display");
            divReportPayerScenario1.Style.Remove("display");
            divReportClaimStatus.Style.Remove("display");
            divReportReportType.Style.Remove("display");
            LoadClaimStatus();
            divFileSearch.Style.Remove("display");
            //divReportServiceProvider.Style.Remove("display");
            //LoadProvider();
            divPracticeStaffOnNpiNum.Style.Remove("display");
            LoadPracticeStaffOnNPI();

            GetMultipleFiles();
        }

        //
        if (ReportType == "ReportMonthlyReconciliation")
        {
            divMonthlyReconciliation.Style.Remove("display");
            divMonthlyReconciliationLocation.Style.Remove("display");
          //  divPracticeLocationId.Style.Remove("display");
            MonthlyReconciliationLocation();
            divMonthlyReconciliationtYear.Style.Remove("display");
            divMonthlyReconciliationtMonth.Style.Remove("display");
            divMRRProvider.Style.Remove("display");
            divProviderType.Style.Remove("display");

        }

        //Added by rizwan kharal 26April2018
        //Rejected Denaid Claims Report
        if (ReportType == "RejectedDeniedSummaryAndDetail")
        {
            divRejectedDenaidClaims.Style.Remove("display");
            InsurancesFromInsurance();
            divPayerDropDownSearch.Style.Remove("display");
          //  divReportPayerScenario.Style.Remove("display");
           // LoadPayersFromClaim();

            divReportBilledAs.Style.Remove("display");
            divAging.Style.Remove("display");
            
        }

        //Added by rizwan kharal 26April2018   TPDAS ThirtyPlusDaysAfterSubmission

        //Added by rizwan kharal 27April2018
        //ThirtyPlusDaysAfterSubmission Report
        if (ReportType == "ThirtyPlusDaysAfterSubmission")
        {
            divThirtyPlusDaysAfterSubmission.Style.Remove("display");
            divPostType.Style.Remove("display");
            ddlPostType.Items.FindByValue("SubmissionDate").Enabled = true;
            //ddlPostType.Items[3].Attributes.Add("Enabled", "Enabled");
            divBillDates.Style.Remove("display");
            divInsuranceDetailDialog.Style.Remove("display");
            LoadPatientInsurance();

        }

        if (ReportType == "PatientPayments")
        {
            divPatientPayments.Style.Remove("display");

            divPostType.Style.Remove("display");
            ddlPostType.Items.FindByValue("PaymentDate").Enabled = true;
            ddlPostType.Items.FindByValue("DOS").Enabled = false;

            divBillDates.Style.Remove("display");
        }

        if (ReportType == "UserAuditReport")
        {
            divInsuranceType.Style.Remove("display");
            divUserSearch.Style.Remove("display");
            divPracticeLocationId.Style.Remove("display");
            divReportServiceProvider.Style.Remove("display");
            divReportDenailPayerName.Style.Remove("display");
            //rbReportTimeSpanFromTheBeginning.Style.Add("display", "none");
            divPostType.Style.Remove("display");
            ddlPostType.Items.FindByValue("BillDate").Enabled = true;
            rbReportToday.Style.Remove("display");
            rbReportToday.Checked = true;
            divClaimsCreatedByUser.Style.Remove("display");
            divTimeSpan.Style.Remove("display");
           // LoadDenailPayerName();
            LoadProvider();
            LoadPracticeLocation();
            divReportClaimStatus.Style.Remove("display");
            LoadClaimStatus();
        }
        if (ReportType == "DeductableReport")
        {
            divDeductableReport.Style.Remove("display");
            divInsuranceType.Style.Remove("display");
            //divUserSearch.Style.Remove("display");
            //divPracticeLocationId.Style.Remove("display");
            //divReportServiceProvider.Style.Remove("display");
            divReportDenailPayerName.Style.Remove("display");           
            divPostType.Style.Remove("display");
            ddlPostType.Items.FindByValue("BillDate").Enabled = true;
            rbReportToday.Style.Remove("display");
            rbReportToday.Checked = true;
            //divClaimsCreatedByUser.Style.Remove("display");
            divTimeSpan.Style.Remove("display");
            divPatient.Style.Remove("display");
            //LoadDenailPayerName();
            LoadProvider();
            LoadPracticeLocation();
            divReportClaimStatus.Style.Remove("display");
            LoadClaimStatus();
        }
        if (ReportType == "ReadyForSubmissionClaimsDetail")
        {

            RFSCDetails.Style.Remove("display");
        }
        if (ReportType == "UserClaimSummaryReport")
        {
            divUserClaimSummary.Style.Remove("display");
            divUserSearch.Style.Remove("display");
            divPostType.Style.Remove("display");
            divTimeSpan.Style.Remove("display");
            Div_MultiUserName.Style.Add("top", "95px !important");
            //rbReportTimeSpanFromTheBeginning.Style.Add("display", "none");
            rbReportToday.Style.Remove("display");
            rbReportToday.Checked = true;
        }
       
        if (ReportType == "ClaimSummaryAndDetail")
        {

            divClaimDetails.Style.Remove("display");
            divPracticeLocationId.Style.Remove("display");
            divReportServiceProvider.Style.Remove("display");
           // divPayersName.Style.Remove("display");
           // LoadPayerNameFromERAMaster();
        //    rbReportTimeSpanFromTheBeginning.Style.Add("display", "none");
            divPostType.Style.Remove("display");
          //  rbReportTimeSpanFromTheBeginning.Style.Remove("display");
            //rbReportTimeSpanFromTheBeginning.Checked = true;
            divClaimId.Style.Remove("display");
            divTimeSpan.Style.Remove("display");
            //LoadDenailPayerName();
            LoadProvider();
            LoadPracticeLocation();           
        }

        if (ReportType == "ProcedurePaymentsReport")
        {
            divProcedurePayment_rb.Style.Remove("display");
            divProcedurePaymentsReportName.Style.Remove("display");           
            divPostType.Style.Remove("display");
            divInsuranceType.Style.Remove("display");           
            divCPTReport.Style.Remove("display");
            divTimeSpan.Style.Remove("display");
            divReportDenailPayerName.Style.Remove("display");
           // LoadDenailPayerName();
            LoadProvider();
        }
    }

    #region ddl databind methods
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


    public void LoadClaimStatusForRejectedDeniedClaim() 
    {
        SubmissionStatusCodesDB objSubmissionStatusCodesDB = new SubmissionStatusCodesDB();
        DataTable dtSubmissionStatusCodes = objSubmissionStatusCodesDB.GetSubmissionStatusCodes();

        DataTable dt = dtSubmissionStatusCodes.Clone(); 
        for (int i = 0; i < dtSubmissionStatusCodes.Rows.Count; i++)
        {
            DataRow row = dtSubmissionStatusCodes.Rows[i];

            string columnvalue=row["SubmissionStatusId"].ToString();

            if(columnvalue=="104" || columnvalue=="108" || columnvalue=="115")
            {
                dt.ImportRow(row);
            }
            
        }

        


        rptCalimStatus.DataSource = dt;
        rptCalimStatus.DataBind();
     
    }
    public void LoadProvider()
    {
        ServiceProviderDB serviceProviderDB = new ServiceProviderDB();
        string PracticeLocationId = Request.Form["PracticeLocationId"];
        string PracticeId = Profile.PracticeId.ToString();
        DataTable dtPayerName = serviceProviderDB.GetServiceProviderByPracticeLocationsId(PracticeLocationId, PracticeId);
        rptProviders.DataSource = dtPayerName;
        rptProviders.DataBind();
    }

    public void LoadPracticeStaffOnNPI()
    {
        ServiceProviderDB serviceProviderDB = new ServiceProviderDB();
         DataTable dtPayerName = serviceProviderDB.GetPracticeStaffonNPINum(Profile.PracticeId);
         ddlPracticeStaffOnNpiNum.DataSource = dtPayerName;
         ddlPracticeStaffOnNpiNum.DataTextField = "Providers";
         ddlPracticeStaffOnNpiNum.DataValueField = "StaffNPI";
         ddlPracticeStaffOnNpiNum.DataBind();
         ddlPracticeStaffOnNpiNum.Items.Insert(0, new ListItem("All", ""));
    }

    public void LoadProviderddl()
    {
        ServiceProviderDB serviceProviderDB = new ServiceProviderDB();
        string PracticeLocationId = Request.Form["PracticeLocationId"];
        string PracticeId = Profile.PracticeId.ToString();
        DataTable dtPayerName = serviceProviderDB.GetServiceProviderByPracticeLocationsId(PracticeLocationId, PracticeId);
        ddlProviders.DataSource = dtPayerName;
        ddlProviders.DataTextField = "Providers";
        ddlProviders.DataValueField = "Providers";
        ddlProviders.DataBind();
        ddlProviders.Items.Insert(0, new ListItem("All", "0"));

        ddlMonthlyReconciliationProvider.DataSource = dtPayerName;
        ddlMonthlyReconciliationProvider.DataTextField = "Providers";
        ddlMonthlyReconciliationProvider.DataValueField = "Providers";
        ddlMonthlyReconciliationProvider.DataBind();
        ddlMonthlyReconciliationProvider.Items.Insert(0, new ListItem("All", "0"));

    }
    public void LoadPayerName()
    {
        InsuranceDB insuranceDB = new InsuranceDB();
        long PracticeId = Profile.PracticeId;
        DataTable dtPatient = insuranceDB.GetAllPayersDetail(PracticeId, "", "", "PayerName");
        ddlPayerName.DataSource = dtPatient;
        ddlPayerName.DataBind();
        ddlPayerName.DataTextField = "PayerName";
        ddlPayerName.DataValueField = "PayerName";
        ddlPayerName.DataBind();
        ddlPayerName.Items.Insert(0, new ListItem("All", "0"));
    }

    public void LoadPracticeLocation()
    {
        PracticeLocationsDB practiceLocationsDB = new PracticeLocationsDB();
        long PracticeId = Profile.PracticeId;
        DataTable dtPracticeLocation = practiceLocationsDB.GetPracticeLocationsByPractice(PracticeId);
        rptLocation.DataSource = dtPracticeLocation;
        rptLocation.DataBind();
        /* DDLPracticeLocationId.DataTextField = "Name";
         DDLPracticeLocationId.DataValueField = "PracticeLocationsId";
         DDLPracticeLocationId.DataBind();
         DDLPracticeLocationId.Items.Insert(0, new ListItem("All Locations", "0"));*/
    }
    public void MonthlyReconciliationLocation()
    {
        PracticeLocationsDB practiceLocationsDB = new PracticeLocationsDB();
        long PracticeId = Profile.PracticeId;
        DataTable dtPracticeLocation = practiceLocationsDB.GetPracticeLocationsByPractice(PracticeId);
        ddlMonthlyReconciliationLocation.DataSource = dtPracticeLocation;
        //rptLocation.DataBind();
        ddlMonthlyReconciliationLocation.DataTextField = "Name";
        ddlMonthlyReconciliationLocation.DataValueField = "PracticeLocationsId";
        ddlMonthlyReconciliationLocation.DataBind();
        ddlMonthlyReconciliationLocation.Items.Insert(0, new ListItem("Please Select Location", "0"));
    }
    //public void LoadPayersFromClaim()
    //{
    //    InsuranceDB insuranceDB = new InsuranceDB();
    //    long PracticeId = Profile.PracticeId;
    //    DataTable dtPatient = insuranceDB.GetPayersByPracticeId(PracticeId);
    //    //rptPayerScenario.DataSource = dtPatient;
    //    //rptPayerScenario.DataBind();
       
    //}

    private void LoadPatientInsurance()
    {
        InsuranceDB insuranceDB = new InsuranceDB();
        long PracticeId = Profile.PracticeId;
        DataTable dtPatient = insuranceDB.GetAllInsurancesHavingClaims(PracticeId,"");
        ddlInsuranceList.DataSource = dtPatient;
        ddlInsuranceList.DataBind();
        ddlInsuranceList.DataTextField = "InsuranceName";
        ddlInsuranceList.DataValueField = "InsuranceId";
        ddlInsuranceList.DataBind();
        ddlInsuranceList.Items.Insert(0, new ListItem("All", "0"));
    }
    public void LoadPatient()
    {
        PatientDB patientDB = new PatientDB();
        long PracticeId = Profile.PracticeId;
        DataTable dtPatient = patientDB.GetAllPatients(PracticeId);
       
        ddlPatientList.DataSource = dtPatient;
        ddlPatientList.DataTextField = "PatientName";
        ddlPatientList.DataValueField = "PatientId";
        ddlPatientList.DataBind();
    }

    //public void LoadPatient()
    //{
    //    PatientDB patientDB = new PatientDB();
    //    long PracticeId = Profile.PracticeId;
    //    DataTable dtPatient = patientDB.GetAllPatients(PracticeId);
    //    rptPatientName.DataSource = dtPatient;

    //    rptPatientName.DataBind();

    //    ddlPatientList.DataSource = dtPatient;
    //    ddlPatientList.DataTextField = "PatientName";
    //    ddlPatientList.DataValueField = "PatientId";
    //    ddlPatientList.DataBind();
    //}
  
    public void LoadAdjustmentCode()
    {
        AdjustmentCodesDB adjustmentCodeDB = new AdjustmentCodesDB();
        DataTable dtAdjustmentCode = adjustmentCodeDB.GetAdjustmentCode(Profile.PracticeId);
        rptAdjustmentCode.DataSource = dtAdjustmentCode;
        rptAdjustmentCode.DataBind();

    }

    public void SubmissionStatusCodesInformation()
    {

        PatientDB db = new PatientDB();
        DataTable dt = db.SubmissionStatusCodes();
        ddlSubmissionStatus.DataSource = dt;
        ddlSubmissionStatus.DataTextField = "submissionStatus";
        ddlSubmissionStatus.DataValueField = "SubmissionStatusId";
        ddlSubmissionStatus.DataBind();
        ddlSubmissionStatus.Items.Insert(0, new ListItem("Select Submission Status", ""));
    }
    public void GetUnpaidInsurancsedata()
    {
        InsuranceDB db = new InsuranceDB();
        DataTable dt = new DataTable();


        dt = db.GetUnpaidInsurancedata(Profile.PracticeId);
        rptunpaidinsurances.DataSource = dt;
        rptunpaidinsurances.DataBind();
    }


    //Added By rizwan  27 Feb 2018
    public void AppointmentStatus()
    {
        AppointmentsDB DB = new AppointmentsDB();
        DataTable dt = new DataTable();
        dt = DB.GetAppointmentsStatus();
        ddlAppointmentStatus.DataSource = dt;
        ddlAppointmentStatus.DataTextField = "StatusName";
        ddlAppointmentStatus.DataValueField = "StatusId";
        ddlAppointmentStatus.DataBind();
        ddlAppointmentStatus.Items.Insert(0, new ListItem("All", "")); //AppointmentReasons
    }
    //Added By rizwan  27 Feb 2018
    public void AppointmentReasons()
    {
        AppointmentsDB DB = new AppointmentsDB();
        DataTable dt = new DataTable();
        dt = DB.GetAppointmentReasons(Convert.ToInt32(Profile.PracticeId));
        ddlAppointmentReasons.DataSource = dt;
        ddlAppointmentReasons.DataTextField = "Description";
        ddlAppointmentReasons.DataValueField = "ReasonId";
        ddlAppointmentReasons.DataBind();
        ddlAppointmentReasons.Items.Insert(0, new ListItem("All", "")); //
    }
    /*protected void ddlCheckNumber_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadPostDate();
    }
    protected void ddlPayerName_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadCheckNumber();
    }*/
    protected void ddlMonthlyReconciliationLocation_SelectedIndexChanged(object sender, EventArgs e)
    {
        string a = ddlMonthlyReconciliationLocation.SelectedIndex.ToString();
    }

    protected void MultiUserName()
    {
        UploadFilesDB uploadFilesDB = new UploadFilesDB();
        rptMultiUserName.DataSource = uploadFilesDB.PracticeUsersearch("", Profile.PracticeId);
        rptMultiUserName.DataBind();
    }

    protected void GetMultipleFiles()
    {
        UploadFilesDB uploadFileDB = new UploadFilesDB();
        int PracticeId = Convert.ToInt32(Profile.PracticeId);
        DataTable ClaimFilesDetails = uploadFileDB.GetFilesOfClaim(PracticeId,null);
        RptFile.DataSource = ClaimFilesDetails;
        RptFile.DataBind();
    }

    #endregion


    public void GetPatientList() 
    {
        string patientname =Request.Form["patient"];
        PatientDB patientDb = new PatientDB();

        rptPatientlist.DataSource = patientDb.GetByPatientName(patientname, Profile.PracticeId);
        rptPatientlist.DataBind();
    }

    public void LoadPayerNameFromERAMaster()
    {
        InsuranceDB insuranceDB = new InsuranceDB();
        long PracticeId = Profile.PracticeId;
        DataTable dtPatient = insuranceDB.GetAllPayersFromERAMaster(PracticeId);
        ddlPayerName.DataSource = dtPatient;
        ddlPayerName.DataBind();
        ddlPayerName.DataTextField = "PayerName";
        ddlPayerName.DataValueField = "PayerName";
        ddlPayerName.DataBind();
        ddlPayerName.Items.Insert(0, new ListItem("All", ""));
    }

    private void InsurancesFromERA()
    {
        InsuranceDB objInsuranceDB = new InsuranceDB();
        using (DataTable dtInsuranceDb=objInsuranceDB.GetPayersFromERAMasterByPracticeId(Profile.PracticeId, "", ""))
        {
            rptInsurances.DataSource = dtInsuranceDb;
            rptInsurances.DataBind();
        }

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

  
    

   
}
