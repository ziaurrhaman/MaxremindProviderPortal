using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using DentalEMRForDashBoard;
using System.Data.SqlClient;
using System.Data;
using System.Web.Script.Serialization;
/// <summary>
/// Summary description for DashboardDataService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class DashboardDataService : System.Web.Services.WebService
{

    public DashboardDataService()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld()
    {
        return "Hello World";
    }

    [WebMethod]
    public DashboardStats GetDashBoardDetails()
    {
        AppointmentsDB objAppointmentsDB = new AppointmentsDB();
        ProfileCommon objProfileCommon = (ProfileCommon)HttpContext.Current.Profile;
        long PracticeId = objProfileCommon.PracticeId;

        List<AppointmentsByLocations> AppointmentsByLocation = new List<AppointmentsByLocations>();
        DataTable dt = objAppointmentsDB.GetAppointmentsByLocations(PracticeId);
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            AppointmentsByLocations obj = new AppointmentsByLocations();
            obj.LocationID = int.Parse(dt.Rows[i]["PracticeLocationsId"].ToString());
            obj.LocationName = dt.Rows[i]["Name"].ToString();
            obj.LocationAppointments = int.Parse(dt.Rows[i]["LocationAppointments"].ToString());
            AppointmentsByLocation.Add(obj);
        }

        List<AppointmentsByReasonForVisit> AppointmentsByReason = new List<AppointmentsByReasonForVisit>();
        DataTable dt1 = objAppointmentsDB.GetDashboardsAppointmentsByReasons(PracticeId);
        for (int i = 0; i < dt1.Rows.Count; i++)
        {
            AppointmentsByReasonForVisit obj = new AppointmentsByReasonForVisit();
            obj.ReasonForVisitID = int.Parse(dt1.Rows[i]["ReasonId"].ToString());
            obj.ReasonForvisitName = dt1.Rows[i]["Description"].ToString();
            obj.ReasonForvisitAppointments = int.Parse(dt1.Rows[i]["LocationAppointmentsByReasons"].ToString());
            AppointmentsByReason.Add(obj);
        }

        List<StatusesLocations> Statuses = new List<StatusesLocations>();
        List<AppointmentsByStatus> AppointmentByStatus = new List<AppointmentsByStatus>();
        DataSet ds = objAppointmentsDB.GetDashBoardAppointmentsStatusbyLocations(PracticeId);
        DataTable dtStatuses = ds.Tables[1];
        DataTable dtAppointmentsByStatus = ds.Tables[0];
        for (int i = 0; i < dtStatuses.Rows.Count; i++)
        {
            StatusesLocations objStatuses = new StatusesLocations();
            objStatuses.StatusName = dtStatuses.Rows[i]["StatusName"].ToString();
            objStatuses.StatusBackColor = dtStatuses.Rows[i]["StatusBackColor"].ToString();

            Statuses.Add(objStatuses);
        }
        for (int i = 0; i < dtAppointmentsByStatus.Rows.Count; i++)
        {
            AppointmentsByStatus objAppointmentsByStatus = new AppointmentsByStatus();
            objAppointmentsByStatus.LocationName = dtAppointmentsByStatus.Rows[i]["Name"].ToString();
            objAppointmentsByStatus.Pending = int.Parse(dtAppointmentsByStatus.Rows[i]["Pending"].ToString());
            objAppointmentsByStatus.Confirmed = int.Parse(dtAppointmentsByStatus.Rows[i]["Confirmed"].ToString());
            objAppointmentsByStatus.Cancelled = int.Parse(dtAppointmentsByStatus.Rows[i]["Cancelled"].ToString());
            objAppointmentsByStatus.CheckedIn = int.Parse(dtAppointmentsByStatus.Rows[i]["CheckedIn"].ToString());
            objAppointmentsByStatus.Completed = int.Parse(dtAppointmentsByStatus.Rows[i]["Completed"].ToString());
            objAppointmentsByStatus.NoShow = int.Parse(dtAppointmentsByStatus.Rows[i]["NoShow"].ToString());

            AppointmentByStatus.Add(objAppointmentsByStatus);
        }

        ClaimsSubmittedDB objClaimSubmittedDB = new ClaimsSubmittedDB();
        List<ClaimSubmissionStatus> claimssubmissionstatus = new List<ClaimSubmissionStatus>();
        DataTable dt2 = objClaimSubmittedDB.ClaimsSubmissionStatus(PracticeId);
        for (int i = 0; i < dt2.Rows.Count; i++)
        {
            ClaimSubmissionStatus obj = new ClaimSubmissionStatus();
            obj.totalclaims = int.Parse(dt2.Rows[i]["TotalClaims"].ToString());
            obj.submissionstatus = dt2.Rows[i]["SubmissionStatus"].ToString();
            //obj.submissionstatuscolor = dt2.Rows[i]["StatusBackColor"].ToString();
            claimssubmissionstatus.Add(obj);
        }

        List<ClaimStatusAgingReoprt> claimstatusagingreport = new List<ClaimStatusAgingReoprt>();
        DataTable dtDashBoardClaimStatusAgingReport = objClaimSubmittedDB.ClaimStatusAgingReport(PracticeId);

        for (int i = 0; i < dtDashBoardClaimStatusAgingReport.Rows.Count; i++)
        {
            ClaimStatusAgingReoprt obj = new ClaimStatusAgingReoprt();
            obj.Incomplete = int.Parse(dtDashBoardClaimStatusAgingReport.Rows[i][1].ToString());
            obj.readyforreview = int.Parse(dtDashBoardClaimStatusAgingReport.Rows[i][2].ToString());
            obj.readyforSubmission = int.Parse(dtDashBoardClaimStatusAgingReport.Rows[i][3].ToString());
            obj.billed = int.Parse(dtDashBoardClaimStatusAgingReport.Rows[i][4].ToString());
            obj.rejcted = int.Parse(dtDashBoardClaimStatusAgingReport.Rows[i][5].ToString());
            obj.rebill = int.Parse(dtDashBoardClaimStatusAgingReport.Rows[i][6].ToString());
            obj.PaidUp = int.Parse(dtDashBoardClaimStatusAgingReport.Rows[i][7].ToString());
            obj.submissionstatus = dtDashBoardClaimStatusAgingReport.Rows[i][0].ToString();
            claimstatusagingreport.Add(obj);
        }

        DashboardStats DS = new DashboardStats();
        DS.AppointmentsByLocations = AppointmentsByLocation;
        DS.AppointmentsByReasonForVisit = AppointmentsByReason;
        DS.Statuses = Statuses;
        DS.AppointmentsByStatus = AppointmentByStatus;
        DS.claimssubmission = claimssubmissionstatus;
        DS.claimssubmissionagingreport = claimstatusagingreport;

        return DS;
    }

    [WebMethod]
    public string GetVitalReportDataGraph(long PatientId, string DateFrom, string DateTo)
    {
        PatientVitalsDb objPatientVitalsDb = new PatientVitalsDb();

        DataTable dtVitals = objPatientVitalsDb.GetDataForGraph(PatientId, DateFrom, DateTo);

        List<ReportVital> listReportVital = new List<ReportVital>();

        for (int i = 0; i < dtVitals.Rows.Count; i++)
        {
            ReportVital objReportVital = new ReportVital();
            objReportVital.Date = dtVitals.Rows[i]["VisitDate"].ToString();
            objReportVital.HeartRate = dtVitals.Rows[i]["HeartRate"].ToString();
            objReportVital.Temperature = dtVitals.Rows[i]["Temperature"].ToString();
            objReportVital.BP1Systolic = dtVitals.Rows[i]["BP1Systolic"].ToString();
            objReportVital.BP1Diastolic = dtVitals.Rows[i]["BP1Diastolic"].ToString();
            objReportVital.RespirationRate = dtVitals.Rows[i]["RespirationRate"].ToString();
            objReportVital.Weight = dtVitals.Rows[i]["Weight"].ToString();
            listReportVital.Add(objReportVital);
        }

        JavaScriptSerializer objJavaScriptSerializer = new JavaScriptSerializer();
        string reportVitalData = objJavaScriptSerializer.Serialize(listReportVital);
        return reportVitalData;
    }
}
