using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DashboardStats
/// </summary>
namespace DentalEMRForDashBoard 
{
    public class DashboardStats
    {
        public List<AppointmentsByLocations> AppointmentsByLocations { get; set; }
        public List<AppointmentsByReasonForVisit> AppointmentsByReasonForVisit { get; set; }
        public List<AppointmentsByStatus> AppointmentsByStatus { get; set; }
        public List<StatusesLocations> Statuses { get; set; }
        public List<ClaimSubmissionStatus> claimssubmission { get; set; }
        public List<ClaimStatusAgingReoprt> claimssubmissionagingreport { get; set; }
       // public List<ClaimStatusAgingReoprtPeriod> ClaimStatusAgingReoprtPeriodperiod { get; set; }
    }
    public class AppointmentsByLocations
    {
        public int LocationID { get; set; }
        public string LocationName { get; set; }
        public int LocationAppointments { get; set; }
    }
    public class AppointmentsByReasonForVisit
    {
        public int ReasonForVisitID { get; set; }
        public string ReasonForvisitName { get; set; }
        public int ReasonForvisitAppointments { get; set; }
    }
    public class AppointmentsByStatus
    {
        public string LocationName { get; set; }
        public int Pending { get; set; }
        public int Confirmed { get; set; }
        public int Cancelled { get; set; }
        public int CheckedIn { get; set; }
        public int Completed { get; set; }
        public int NoShow { get; set; }
    }
    public class StatusesLocations
    {
        public string StatusName { get; set; }
        public string StatusBackColor { get; set; }
    }
    public class ClaimSubmissionStatus
    {
        public string submissionstatus{ get; set;}
        public string submissionstatuscolor { get; set; }
        public int totalclaims { get; set; }
    }
    public class ClaimStatusAgingReoprt
    {
        public int Incomplete { get; set; }
        public int readyforreview { get; set; }
        public int readyforSubmission { get; set; }
        public int rebill { get; set; }
        public int billed { get; set; }
        public int rejcted { get; set; }
        public int PaidUp { get; set; }
        public string submissionstatus { get; set; }
       
    }
    //public class ClaimStatusAgingReoprtPeriod
    //{
    //    public int period { get; set; }
    //}
}