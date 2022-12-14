using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProviderPortal_Reports_CallBacks_PatientFilterDialog : System.Web.UI.Page  
{

    protected void Page_Load(object sender, EventArgs e)
    {
        string ReportType = Request.Form["ReportType"];
        if (ReportType == "PD")
        {
            divPatientSarch.Style.Remove("display");
            //divPatientDetailDialog.Style.Remove("display");

            //LoadPatient();
        }
        if (ReportType == "PCL")
        {
            divActuvity.Style.Remove("display");
            divReportServiceProvider.Style.Remove("display");
            LoadProvider();
            divReportDiagnosis.Style.Remove("display");
            divReportProcedure.Style.Remove("display");
            divGender.Style.Remove("display");
            divAgingDate.Style.Remove("display");
            divReportPayerScenario.Style.Remove("display");
            LoadPayersFromClaim();
            spnDOB.Style.Remove("display");
            txtDOB1.Style.Remove("display");
            txtDOB.Style.Add("display","none");
        }
        if (ReportType == "PS")
        {
            divPostType.Style.Remove("display");
            divReportServiceProvider.Style.Remove("display");
            LoadProvider();
            divPracticeLocationId.Style.Remove("display");
            LoadPracticeLocation();
            divReportPayerScenario.Style.Remove("display");
            LoadPayersFromClaim();
            divBillDates.Style.Remove("display");
           
    
          
            spnDOB.Style.Remove("display");
        }
        if (ReportType == "PBD")
        {
            divPatientSarch.Style.Remove("display");
            //divPatientDetailDialog.Style.Remove("display");
            //LoadPatient();
            divReportProcedure.Style.Remove("display");
            divDate.Style.Remove("display");
            divAgingDate.Style.Remove("display");
            spnAsOf.Style.Remove("display");
            
        }
        if (ReportType == "PBS")
        {
      
            divDate.Style.Remove("display");
            divAgingDate.Style.Remove("display");
            spnAsOf.Style.Remove("display");
            //ddlDate.Style.Remove("width");
            //ddlDate.Style.Add("width", "81%");
            divAssignedTo.Style.Remove("display");
        }
        if (ReportType == "PTS")
        {
            divTimeSpan.Style.Remove("display");
           
        }
        //jump   

        if (ReportType == "AD")
        {
            divPostType.Style.Remove("display");
            divReportServiceProvider.Style.Remove("display");
            LoadProvider();
            divPracticeLocationId.Style.Remove("display");
            LoadPracticeLocation();
            divReportPayerScenario.Style.Remove("display");
            LoadPayersFromClaim();
            divBillDates.Style.Remove("display");
     
         
            spnDOB.Style.Remove("display");
            divReportProcedure.Style.Remove("display");
            divPatientSarch.Style.Remove("display");
         //   divPatientSarch.Style.Remove("display");
            //LoadPatient();
           // LoadAllPatientsForAdjustments();
   
            divReportAdjustmentCode.Style.Remove("display");
            LoadAllAdjustmentCode();
        }
        if (ReportType == "AS")
        {
       
            divPostType.Style.Remove("display");
            divReportServiceProvider.Style.Remove("display");
            LoadProvider();
            divPracticeLocationId.Style.Remove("display");
            LoadPracticeLocation();
            divReportPayerScenario.Style.Remove("display");
            LoadPayersFromClaim();
            divBillDates.Style.Remove("display");
         
      
            spnDOB.Style.Remove("display");
            divReportProcedure.Style.Remove("display");


            divPatientSarch.Style.Remove("display");

           // divPatientDetailDialog.Style.Remove("display");
           //// LoadPatient();
           // LoadAllPatientsForAdjustments();
   
            divReportAdjustmentCode.Style.Remove("display");
            LoadAllAdjustmentCode();
        }
        if (ReportType == "CS")
        {
            divPostType.Style.Remove("display");
            divReportServiceProvider.Style.Remove("display");
            LoadProvider();
            divPracticeLocationId.Style.Remove("display");
            LoadPracticeLocation();
            divReportPayerScenario.Style.Remove("display");
            LoadPayersFromClaim();
            divBillDates.Style.Remove("display");
      
            spnDOB.Style.Remove("display");
            divReportProcedure.Style.Remove("display");
            divPatientSarch.Style.Remove("display");
            //divPatientDetailDialog.Style.Remove("display");
            //LoadPatient();
         
        }
        if (ReportType == "CD")
        {
            
            divPostType.Style.Remove("display");
            divReportServiceProvider.Style.Remove("display");
            LoadProvider();
            divPracticeLocationId.Style.Remove("display");
            LoadPracticeLocation();
            divReportPayerScenario.Style.Remove("display");
            LoadPayersFromClaim();
            divBillDates.Style.Remove("display");
          
   
            spnDOB.Style.Remove("display");
            divReportProcedure.Style.Remove("display");
           
            //divPatientDetailDialog.Style.Remove("display");
            //LoadPatient();
            divPatientSarch.Style.Remove("display");
       
        
        }

        if (ReportType == "IOC")
        {
            divPatientSarch.Style.Remove("display");
            //divPatientDetailDialog.Style.Remove("display");
            //LoadALlPatient();
            divPostType.Style.Remove("display");
            divDate.Style.Remove("display");
            divAgingDate.Style.Remove("display");
            spnAsOf.Style.Remove("display");
            divReportServiceProvider.Style.Remove("display");
            LoadProvider();
            divReportPayerScenario.Style.Remove("display");
            LoadPayersFromClaim();
           
        }
        if (ReportType == "SCS")
        {
            divReportPatientName.Style.Remove("display");
            LoadALlPatientForSettledCharges();
            divReportServiceProvider.Style.Remove("display");
            LoadProvider();
            divPracticeLocationId.Style.Remove("display");
            LoadPracticeLocation();
            divReportProcedure.Style.Remove("display");
            divTimeSpan.Style.Remove("display");

        }

    }
    private void LoadPatient()
    {

        ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();
        long PracticeId = Profile.PracticeId;
        DataTable dtPatient = objPatientReportsDB.GetAllPatients(PracticeId);
        ddlPatientList.DataSource = dtPatient;
        ddlPatientList.DataBind();
        ddlPatientList.DataTextField = "PatientName";
        ddlPatientList.DataValueField = "PatientId";
        ddlPatientList.DataBind();
    }

    private void LoadAllPatientsForAdjustments()
    {

        ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();
        long PracticeId = Profile.PracticeId;
        DataTable dtPatient = objPatientReportsDB.GetAllPatientsForAdjustments(PracticeId);
        ddlPatientList.DataSource = dtPatient;
        ddlPatientList.DataBind();
        ddlPatientList.DataTextField = "PatientName";
        ddlPatientList.DataValueField = "PatientId";
        ddlPatientList.DataBind();
    }
    

    private void LoadALlPatient()
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


    private void LoadALlPatientForSettledCharges()
    {

        PatientDB patientDB = new PatientDB();
        long PracticeId = Profile.PracticeId;
        DataTable dtPatient = patientDB.GetAllPatientswithPaidUpStatus(PracticeId);
        rptPatientName.DataSource = dtPatient;
        rptPatientName.DataBind();
}


    public void LoadProvider()
    {
        ServiceProviderDB serviceProviderDB = new ServiceProviderDB();
        string PracticeLocationId = Request.Form["PracticeLocationId"];
        string PracticeId = Profile.PracticeId.ToString();
        DataTable dtPayerName = serviceProviderDB.GetServiceProviderByPracticeLocationsId(PracticeLocationId,PracticeId);
        rptProviders.DataSource = dtPayerName;
        rptProviders.DataBind();
    }
    public void LoadPracticeLocation()
    {
        PracticeLocationsDB practiceLocationsDB = new PracticeLocationsDB();
        long PracticeId = Profile.PracticeId;
        DataTable dtPracticeLocation = practiceLocationsDB.GetPracticeLocationsByPractice(PracticeId);
        rptLocation.DataSource = dtPracticeLocation;
        rptLocation.DataBind();
    }
    public void LoadPayersFromClaim()
    {
        InsuranceDB insuranceDB = new InsuranceDB();
        long PracticeId = Profile.PracticeId;
        DataTable dtPatient = insuranceDB.GetPayersByPracticeId(PracticeId,"","");
        rptPayerScenario.DataSource = dtPatient;
        rptPayerScenario.DataBind();
    }

    public void LoadAdjustmentCode()
    {
        AdjustmentCodesDB adjustmentCodeDB = new AdjustmentCodesDB();
        DataTable dtAdjustmentCode = adjustmentCodeDB.GetAdjustmentCode(Profile.PracticeId);
        rptAdjustmentCode.DataSource = dtAdjustmentCode;
        rptAdjustmentCode.DataBind();

    }
    public void LoadAllAdjustmentCode()
    {
        AdjustmentCodesDB adjustmentCodeDB = new AdjustmentCodesDB();
        DataTable dtAdjustmentCode = adjustmentCodeDB.GetAllAdjustmentCode(Profile.PracticeId);
        rptAdjustmentCode.DataSource = dtAdjustmentCode;
        rptAdjustmentCode.DataBind();

    }
}