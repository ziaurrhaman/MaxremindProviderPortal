using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProviderPortal_Reports_CallBacks_PaymentsFilterDialog : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string ReportType = Request.Form["ReportType"];
        if (ReportType == "PBP")
        {
            divTimeSpan.Style.Remove("display");
          
        } 
        if (ReportType == "PD")
        {
            divTimeSpan.Style.Remove("display");
           
        }
        if (ReportType == "PS")
        {
            divTimeSpan.Style.Remove("display");
       
        }
        if (ReportType == "PPS")
        {
            divTimeSpan.Style.Remove("display");
          
        }
        if (ReportType == "CMS")
        {
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





        if (ReportType == "CMD")
        {
            //divTimeSpan.Style.Remove("display");
            //hrPatientDetailDialog.Style.Add("display", "none");
             divPostType.Style.Remove("display");
            divReportServiceProvider.Style.Remove("display");
            LoadProvider();
            divPracticeLocationId.Style.Remove("display");
            LoadPracticeLocation();
            divReportPayerScenario.Style.Remove("display");
            LoadPayersFromClaim();
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
        if (ReportType == "MC")
        {
            divTimeSpan.Style.Remove("display");
         
        }
        if(ReportType=="PA")
        {
            //hrEndPatientDetail.Style.Add("display", "none");
           
            divPayersName.Style.Remove("display");
            divCheckNumber.Style.Remove("display");
            divPostDate.Style.Remove("display");
                LoadPayerName();
        }
        if (ReportType == "PAS")
        {
            divTimeSpan.Style.Remove("display");
          
        } 
        if (ReportType == "UA")
        {
            divTimeSpan.Style.Remove("display");
           
        }
        if (ReportType == "PMS")
        {
           // divPayerMixSummary.Style.Remove("display");
            divTimeSpan.Style.Remove("display");
          
        }
        if(ReportType=="ARAS")
        {
            divAgingType.Style.Remove("display");
            divAgingDate.Style.Remove("display");
            divPracticeLocationId.Style.Remove("display");
            LoadPracticeLocation();
            divReportServiceProvider.Style.Remove("display");
            LoadProvider();
            divReportPayerScenario.Style.Remove("display");
            LoadPayersFromClaim();
            hrHideForEmployee.Style.Add("display", "none");
        } 
        if (ReportType == "ICD")
        {
            divAgingType.Style.Remove("display");
            divAgingDate.Style.Remove("display");
            divPracticeLocationId.Style.Remove("display");
            LoadPracticeLocation();
            divReportServiceProvider.Style.Remove("display");
            LoadProvider();
            divReportPayerScenario.Style.Remove("display");
            LoadPayersFromClaim();
            hrHideForEmployee.Style.Add("display", "none");
            divReportClaimStatus.Style.Remove("display");
            LoadClaimStatus();
        } 
        if (ReportType == "ICS")
        {
            divAgingType.Style.Remove("display");
            divAgingDate.Style.Remove("display");
            divPracticeLocationId.Style.Remove("display");
            LoadPracticeLocation();
            divReportServiceProvider.Style.Remove("display");
            LoadProvider();
            divReportPayerScenario.Style.Remove("display");
            LoadPayersFromClaim();
            hrHideForEmployee.Style.Add("display", "none");
            divReportClaimStatus.Style.Remove("display");
            LoadClaimStatus();
        }
        if (ReportType == "PCS")
        {
            divAgingType.Style.Remove("display");
            divAgingDate.Style.Remove("display");
            divPracticeLocationId.Style.Remove("display");
            LoadPracticeLocation();
            divReportServiceProvider.Style.Remove("display");
            LoadProvider();
            LoadPatient();
            //hrHideForEmployee.Style.Add("display", "none");
        } 
        if (ReportType == "PCD")
        {
            divAgingType.Style.Remove("display");
            divAgingDate.Style.Remove("display");
            divPracticeLocationId.Style.Remove("display");
            LoadPracticeLocation();
            divReportServiceProvider.Style.Remove("display");
            LoadProvider();
            LoadPatient();
            //hrHideForEmployee.Style.Add("display", "none");
        }
        if (ReportType == "UNC")
        {
            txtBillDateFrom.Enabled = true;
            txtBillDateTo.Enabled = true;
      
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

        if (ReportType == "DD")
        {
            divPostType.Style.Remove("display");
            divPracticeLocationId.Style.Remove("display");
            LoadPracticeLocation();
            divReportServiceProvider.Style.Remove("display");
            LoadProvider();
            divReportDenailPayerName.Style.Remove("display");
            LoadDenailPayerName();
            divReportAdjustmentCode.Style.Remove("display");
            LoadAdjustmentCode();
            divTimeSpan.Style.Remove("display");
            hrHideForEmployee.Style.Add("display", "none");
          //  LoadPatient();
        }
        if (ReportType == "DS")
        {
            divPostType.Style.Remove("display");
            divPracticeLocationId.Style.Remove("display");
            LoadPracticeLocation();
            divReportServiceProvider.Style.Remove("display");
            LoadProvider();
            divReportDenailPayerName.Style.Remove("display");
            LoadDenailPayerName();
            divReportAdjustmentCode.Style.Remove("display");
            LoadAdjustmentCode();
            divTimeSpan.Style.Remove("display");
            hrHideForEmployee.Style.Add("display", "none");
           // LoadPatient();
        }
        if (ReportType == "ERAEOB")
        {
            //ddlInsuranceList.Style.Remove("width");
            //ddlInsuranceList.Style.Add("width", "80.5%");;
            divInsuranceDetailDialog.Style.Remove("display");
            LoadPatientInsurance();
            divReportPaymentType.Style.Remove("display");
            divPaymentMethod.Style.Remove("display");
            divTimeSpan.Style.Remove("display");
            hrHideForEmployee.Style.Add("display", "none");
        }
        if (ReportType == "PTD")
        {
         
            LoadPatient();
            divTimeSpan.Style.Remove("display");
            
        }


        if (ReportType == "PED")
        {
            divPostType.Style.Remove("display");
            divSubmissionStatus.Style.Remove("display");
            SubmissionStatusCodesInformation();
            divPracticeLocationId.Style.Remove("display");
            LoadPracticeLocation();
            divReportServiceProvider.Style.Remove("display");
            LoadProvider();
            divReportPayerScenario.Style.Remove("display");
            LoadPayersFromClaim();
            divBillDates.Style.Remove("display");
       
        }
        if (ReportType == "ES")
        {
            divPostType.Style.Remove("display");
            divSubmissionStatus.Style.Remove("display");
            SubmissionStatusCodesInformation();
            divPracticeLocationId.Style.Remove("display");
            LoadPracticeLocation();
            divReportServiceProvider.Style.Remove("display");
            LoadProvider();
            divReportPayerScenario.Style.Remove("display");
            LoadPayersFromClaim();
            divBillDates.Style.Remove("display");

        }

        //  Appointment Detail
        //Added By rizwan  27 Feb 2018
        if (ReportType == "AppD")
        {
            divReportServiceProvider.Style.Remove("display");
            LoadProvider();
            divPracticeLocationId.Style.Remove("display");
            LoadPracticeLocation();

            divReportPatientName.Style.Remove("display");
            LoadAppoitmentPatient();
            divAppointmentStatus.Style.Remove("display");
            AppointmentStatus();

            divAppointmentReasons.Style.Remove("display");
            AppointmentReasons();
            divTimeSpan.Style.Remove("display");

        }

        //

    }



    private void LoadAppoitmentPatient()
    {

        ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();
        long PracticeId = Profile.PracticeId;
        DataTable dtPatient = objPatientReportsDB.GetAllPatientsForAppointments(PracticeId);
        rptPatientName.DataSource = dtPatient;

        rptPatientName.DataBind();
       
    }
    public void LoadClaimStatus()
    {
        SubmissionStatusCodesDB objSubmissionStatusCodesDB = new SubmissionStatusCodesDB();
        DataTable dtSubmissionStatusCodes = objSubmissionStatusCodesDB.GetSubmissionStatusCodes();

        rptCalimStatus.DataSource = dtSubmissionStatusCodes;
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
    public void LoadPayersFromClaim()
    {
        InsuranceDB insuranceDB = new InsuranceDB();
        long PracticeId = Profile.PracticeId;
        DataTable dtPatient = insuranceDB.GetPayersByPracticeId(PracticeId,"","");
        rptPayerScenario.DataSource = dtPatient;
        rptPayerScenario.DataBind();
        /*ddlPayerScenarioId.DataTextField = "Payers";
        ddlPayerScenarioId.DataValueField = "InsuranceId";
        ddlPayerScenarioId.DataBind();
        ddlPayerScenarioId.Items.Insert(0, new ListItem("All Payer Scenario", "0"));*/
    }
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
        rptPatientName.DataSource = dtPatient;

        rptPatientName.DataBind();

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
    public void LoadDenailPayerName()
    {
        InsuranceDB DenailInsuranceDB = new InsuranceDB();
        long PracticeId = Profile.PracticeId;
        DataTable dtDenailPayerName = DenailInsuranceDB.GetDenialPayerName(PracticeId);

        rptDenailPayerName.DataSource = dtDenailPayerName;
        rptDenailPayerName.DataBind();
    }
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
        ddlSubmissionStatus.Items.Insert(0, new ListItem("Select Submission Status",""));
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
        ddlAppointmentStatus.DataValueField="StatusId";
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
    //protected void ddlCheckNumber_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    LoadPostDate();
    //}
    //protected void ddlPayerName_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    LoadCheckNumber();
    //}
}