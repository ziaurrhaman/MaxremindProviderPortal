using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary> 
/// Summary description for ReportsDB
/// </summary>
public class ReportsDB
{
	public ReportsDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataSet FilterClaimSubmissionStatusSummary(string ClaimId, string PatientName, string DateOfService, string BillDate, string InsuranceId, string SubmissionStatusId, long PracticeId, string PracticeLocationsId, int Rows, int PageNumber)
    {
        DBManager objDBManager = new DBManager();

        objDBManager.AddParameter("@PracticeId", PracticeId);
        objDBManager.AddParameter("@Rows", Rows);
        objDBManager.AddParameter("@PageNumber", PageNumber);





        if (!string.IsNullOrEmpty(ClaimId))
        {
            objDBManager.AddParameter("ClaimId", ClaimId);
        }

        if (!string.IsNullOrEmpty(PatientName))
        {
            objDBManager.AddParameter("PatientName", PatientName);
        }

        DateTime DateOfServices;
        if (DateTime.TryParse(DateOfService, out DateOfServices))
        {
            objDBManager.AddParameter("DateOfService", DateOfServices);
        }

        DateTime BillDates;
        if (DateTime.TryParse(BillDate, out BillDates))
        {
            objDBManager.AddParameter("BillDate", BillDates);
        }

        if (!string.IsNullOrEmpty(InsuranceId))
        {
            objDBManager.AddParameter("InsuranceId", long.Parse(InsuranceId));
        }

        if (!string.IsNullOrEmpty(SubmissionStatusId))
        {
            objDBManager.AddParameter("SubmissionStatusId", SubmissionStatusId);
        }
        if (!string.IsNullOrEmpty(PracticeLocationsId))
        {
            objDBManager.AddParameter("PracticeLocationsId", int.Parse(PracticeLocationsId));
        }

        return objDBManager.ExecuteDataSet("Reports_Claim_GetAdmissionStatusSummary");
    }
    public DataSet GetAppointmentBySearchCriteria(int PracticeLocationsId, string PracticeStaffId, long PatientId, string PatientName, string AppointmentDate, string StartTime, string EndTime, string StatusId, int Rows, int PageNumber, SqlTransaction objSqlTransaction = null)
    {

        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);

            if (PracticeLocationsId != 0)
                objDBManager.AddParameter("@PracticeLocationsId", PracticeLocationsId);


            if (!string.IsNullOrEmpty(PracticeStaffId))
            {
                if (PracticeStaffId != "0")
                    objDBManager.AddParameter("PracticeStaffId", long.Parse(PracticeStaffId));
            }

            objDBManager.AddParameter("@Rows", Rows);
            objDBManager.AddParameter("@PageNumber", PageNumber);
           
            if (PatientId != 0)
                objDBManager.AddParameter("@PatientId", PatientId);

            if (!string.IsNullOrEmpty(PatientName))
                objDBManager.AddParameter("@PatientName", PatientName);

            if (!string.IsNullOrEmpty(AppointmentDate))
                objDBManager.AddParameter("@AppointmentDate", Convert.ToDateTime(AppointmentDate));

            if (!string.IsNullOrEmpty(StartTime))
                objDBManager.AddParameter("@StartTime", StartTime);

            if (!string.IsNullOrEmpty(EndTime))
                objDBManager.AddParameter("@EndTime", EndTime);

            if (!string.IsNullOrEmpty(StatusId))
                objDBManager.AddParameter("@StatusId", StatusId);

            return objDBManager.ExecuteDataSet("Reports_Appointments_GetAppointmentBySearchCriteria");
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
/////Rizwan kharal 7March2018
    public DataSet GetCompanyIndicatorReport(long PracticeId,  string DosStartDate, string DosEndDate, string PostStartDate, string PostEndDate)
    {
        DBManager objDBManager = new DBManager();

        objDBManager.AddParameter("PracticeId", PracticeId);
        if (!string.IsNullOrEmpty(DosStartDate))
            objDBManager.AddParameter("DATEOFSERIVCEFROM", DosStartDate);

        if (!string.IsNullOrEmpty(DosEndDate))
            objDBManager.AddParameter("DATEOFSERIVCETO", DosEndDate);


        if (!string.IsNullOrEmpty(PostStartDate))
            objDBManager.AddParameter("@PostDateFrom", PostStartDate);

        if (!string.IsNullOrEmpty(PostEndDate))
            objDBManager.AddParameter("@PostDateTo", PostEndDate);

        return objDBManager.ExecuteDataSet("Report_GetCompanyIndicators");
    }

    public DataSet GetClaimsCreatedByUser(long PracticeId, string CreatedById, int Rows, int PageNumber, string DateType, string StartDate, string EndDate, string PracticeLocationId, string ProviderId, string InsuranceType, string PriInsurance, string SecInsurance, string ClaimStatus)
    {
        DBManager objDBManager = new DBManager();

        objDBManager.AddParameter("PracticeId", PracticeId);
        if (CreatedById !="")
        {
            objDBManager.AddParameter("@CreatedById", CreatedById);

        }
        
        objDBManager.AddParameter("@Rows", Rows);
        objDBManager.AddParameter("@PageNumber", PageNumber);

        if (!string.IsNullOrEmpty(DateType))
            objDBManager.AddParameter("@DateType", DateType);

        if (!string.IsNullOrEmpty(StartDate))
            objDBManager.AddParameter("@StartDate", StartDate);

        if (!string.IsNullOrEmpty(EndDate))
            objDBManager.AddParameter("@EndDate", EndDate);
        //
        if (!string.IsNullOrEmpty(PracticeLocationId))
            objDBManager.AddParameter("@PracticeLocationId", PracticeLocationId);

        if (!string.IsNullOrEmpty(ProviderId))
            objDBManager.AddParameter("@ProviderId", ProviderId);

        if (!string.IsNullOrEmpty(InsuranceType))
            objDBManager.AddParameter("InsuranceType", InsuranceType);

        if (!string.IsNullOrEmpty(PriInsurance))
            objDBManager.AddParameter("@PriInsurance", PriInsurance);

        if (!string.IsNullOrEmpty(SecInsurance))
            objDBManager.AddParameter("@SecInsurance", SecInsurance);

        if (!string.IsNullOrEmpty(ClaimStatus))
            objDBManager.AddParameter("@ClaimStatus", ClaimStatus);

        return objDBManager.ExecuteDataSet("GetSpecificUserCreatedClaims");
    }
    //Added by faiza bilal 2-4-2022 to get Patient Balance Report
    
    public DataSet GetPatientBalanceSummary(long UserId, long PracticeId, int Rows, int PageNumber, string DateType, string FromDate, string ToDate, string ProviderIds=null, string PracticeLocationId=null)
    {
        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("UserId", UserId);
        objDBManager.AddParameter("PracticeId", PracticeId);
        objDBManager.AddParameter("@Rows", Rows);
        objDBManager.AddParameter("@PageNumber", PageNumber);
        if (!string.IsNullOrEmpty(PracticeLocationId))
            objDBManager.AddParameter("PracticeLocationId", PracticeLocationId);

        if (!string.IsNullOrEmpty(FromDate))
            objDBManager.AddParameter("FromDate", FromDate);

        if (!string.IsNullOrEmpty(ToDate))
            objDBManager.AddParameter("ToDate", ToDate);

        if (!string.IsNullOrEmpty(ProviderIds))
            objDBManager.AddParameter("StaffNPI", ProviderIds);
        objDBManager.AddParameter("DateType", DateType);

        return objDBManager.ExecuteDataSet("GetPatientBalanceReportSummary");

    }
    public DataTable GetPatientBalanceDetail(long UserId, long PracticeId, int Patientid, string DateType, string FromDate, string ToDate, string ProviderIds = null, string PracticeLocationId = null)
    {
        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("UserId", UserId);
        objDBManager.AddParameter("PracticeId", PracticeId);
        if (Patientid != 0)
            objDBManager.AddParameter("Patientid", Patientid);
        if (!string.IsNullOrEmpty(PracticeLocationId))
            objDBManager.AddParameter("PracticeLocationId", PracticeLocationId);

        if (!string.IsNullOrEmpty(FromDate))
            objDBManager.AddParameter("FromDate", FromDate);

        if (!string.IsNullOrEmpty(ToDate))
            objDBManager.AddParameter("ToDate", ToDate);

        if (!string.IsNullOrEmpty(ProviderIds))
            objDBManager.AddParameter("StaffNPI", ProviderIds);
        objDBManager.AddParameter("DateType", DateType);
        return objDBManager.ExecuteDataTable("GetPatientBalanceReport");

    }
    //End Added by faiza bilal 2-4-2022 to get Patient Balance Report
    public DataSet GetClaimsDetails(long PracticeId, int Rows, int PageNumber, string SortBy, string DateType, string StartDate, string EndDate, string PracticeLocationId, string StaffNPI, string Insurance,
        string ClaimId, bool? IsImportedDataOnly, string level = null, string type = null, string CPTcode = null, string BillAs = null, string ClaimStatus = null)
    {
        DBManager objDBManager = new DBManager();

        objDBManager.AddParameter("PracticeId", PracticeId);

        if (!string.IsNullOrEmpty(DateType))
            objDBManager.AddParameter("@DateType", DateType);

        if (!string.IsNullOrEmpty(StartDate))
            objDBManager.AddParameter("@StartDate", StartDate);
        if (!string.IsNullOrEmpty(CPTcode))
            objDBManager.AddParameter("@CPTcode", CPTcode);
        if (!string.IsNullOrEmpty(BillAs))
            objDBManager.AddParameter("@billas", BillAs);
        if (!string.IsNullOrEmpty(ClaimStatus))
            objDBManager.AddParameter("@claimstatus", ClaimStatus);
        if (!string.IsNullOrEmpty(EndDate))
            objDBManager.AddParameter("@EndDate", EndDate);
        objDBManager.AddParameter("@PracticeLocationId", PracticeLocationId);
        objDBManager.AddParameter("@StaffNPI", StaffNPI);

        if (!string.IsNullOrEmpty(Insurance))
            objDBManager.AddParameter("@ClaimpayerId", Insurance);
        if (ClaimId != "")
            objDBManager.AddParameter("@ClaimId", ClaimId);
        if (level != null)
            objDBManager.AddParameter("@Level", level);
        if (!string.IsNullOrEmpty(type))
            objDBManager.AddParameter("@Type", type);
        if (IsImportedDataOnly != null)
        {
            objDBManager.AddParameter("@IsImportedDataOnly", IsImportedDataOnly);
        }

        return objDBManager.ExecuteDataSet("GetClaimsDetail_ProviderPortal");
    }
    public DataSet GetClaimsDetail_ProviderPortalChargedClaims(long PracticeId, int Rows, int PageNumber, string SortBy, string DateType, string StartDate, string EndDate,
        string PracticeLocationId, string StaffNPI, string Insurance, string ClaimId, bool? IsImportedDataOnly, string level = null, string type = null, string CPTcode = null, string BillAs = null, string ClaimStatus = null,string Payerid=null)
    {
        DBManager objDBManager = new DBManager();

        objDBManager.AddParameter("PracticeId", PracticeId);
        objDBManager.AddParameter("@Rows",Rows);
        objDBManager.AddParameter("@PageNumber",PageNumber);

        if (!string.IsNullOrEmpty(DateType))
            objDBManager.AddParameter("@DateType", DateType);

        if (!string.IsNullOrEmpty(StartDate))
            objDBManager.AddParameter("@StartDate", StartDate);

        if (!string.IsNullOrEmpty(EndDate))
            objDBManager.AddParameter("@EndDate", EndDate);
        if (!string.IsNullOrEmpty(CPTcode))
            objDBManager.AddParameter("@CPTcode", CPTcode);
        if (!string.IsNullOrEmpty(BillAs))
            objDBManager.AddParameter("@billas", BillAs);
        objDBManager.AddParameter("@PracticeLocationId", PracticeLocationId);

        //if (!string.IsNullOrEmpty(ProviderId))
            objDBManager.AddParameter("@StaffNPI", StaffNPI);

        if (!string.IsNullOrEmpty(Insurance))
            objDBManager.AddParameter("@Insurance", Insurance);
        if (ClaimId != "")
            objDBManager.AddParameter("@ClaimId", ClaimId);
         if (level != null)
            objDBManager.AddParameter("@Level", level);
         if (!string.IsNullOrEmpty(type))  
             objDBManager.AddParameter("@Type", type);
         if (IsImportedDataOnly != null)
         {
             objDBManager.AddParameter("@IsImportedDataOnly", IsImportedDataOnly);
         }
        if (Payerid != null)
        {
            objDBManager.AddParameter("@ClaimpayerId", Payerid);
        }
        if (!string.IsNullOrEmpty(ClaimStatus))
            objDBManager.AddParameter("@claimstatus", ClaimStatus);
        return objDBManager.ExecuteDataSet("GetClaimsDetail_ProviderPortalChargedClaims");
    }
    public DataSet GetClaimsDetail_ProviderPortalPaidClaims(long PracticeId, int Rows, int PageNumber, string SortBy, string DateType, string StartDate, string EndDate,
        string PracticeLocationId, string StaffNPI, string Insurance, string ClaimId, bool? IsImportedDataOnly, string level = null, string type = null, string CPTcode = null, string BillAs = null, string ClaimStatus = null,string Payerid=null)
    {
        DBManager objDBManager = new DBManager();

        objDBManager.AddParameter("PracticeId", PracticeId);
        objDBManager.AddParameter("@Rows", Rows);
        objDBManager.AddParameter("@PageNumber", PageNumber);

        if (!string.IsNullOrEmpty(DateType))
            objDBManager.AddParameter("@DateType", DateType);

        if (!string.IsNullOrEmpty(StartDate))
            objDBManager.AddParameter("@StartDate", StartDate);

        if (!string.IsNullOrEmpty(EndDate))
            objDBManager.AddParameter("@EndDate", EndDate);
        if (!string.IsNullOrEmpty(CPTcode))
            objDBManager.AddParameter("@CPTcode", CPTcode);
        if (!string.IsNullOrEmpty(BillAs))
            objDBManager.AddParameter("@billas", BillAs);
        objDBManager.AddParameter("@PracticeLocationId", PracticeLocationId);
        objDBManager.AddParameter("@StaffNPI", StaffNPI);

        if (!string.IsNullOrEmpty(Insurance))
            objDBManager.AddParameter("@Insurance", Insurance);
        if (ClaimId != "")
            objDBManager.AddParameter("@ClaimId", ClaimId);
        if (level != null)
            objDBManager.AddParameter("@Level", level);
        if (!string.IsNullOrEmpty(type))
            objDBManager.AddParameter("@Type", type);
        if (IsImportedDataOnly != null)
        {
            objDBManager.AddParameter("@IsImportedDataOnly", IsImportedDataOnly);
        }
        if (Payerid != null)
        {
            objDBManager.AddParameter("@ClaimpayerId", Payerid);
        }
        if (!string.IsNullOrEmpty(ClaimStatus))
            objDBManager.AddParameter("@claimstatus", ClaimStatus);
        return objDBManager.ExecuteDataSet("GetClaimsDetail_ProviderPortalPaidClaims");
    }
    public DataSet GetClaimsDetail_ProviderPortalUnPaidClaims(long PracticeId, int Rows, int PageNumber, string SortBy, string DateType, string StartDate, string EndDate,
        string PracticeLocationId, string StaffNPI, string Insurance, string ClaimId, bool? IsImportedDataOnly, string level = null, string type = null, string CPTcode = null, string BillAs = null, string ClaimStatus = null,string Payerid=null)
    {
        DBManager objDBManager = new DBManager();

        objDBManager.AddParameter("PracticeId", PracticeId);
        objDBManager.AddParameter("@Rows", Rows);
        objDBManager.AddParameter("@PageNumber", PageNumber);

        if (!string.IsNullOrEmpty(DateType))
            objDBManager.AddParameter("@DateType", DateType);

        if (!string.IsNullOrEmpty(StartDate))
            objDBManager.AddParameter("@StartDate", StartDate);

        if (!string.IsNullOrEmpty(EndDate))
            objDBManager.AddParameter("@EndDate", EndDate);
        if (!string.IsNullOrEmpty(CPTcode))
            objDBManager.AddParameter("@CPTcode", CPTcode);
        if (!string.IsNullOrEmpty(BillAs))
            objDBManager.AddParameter("@billas", BillAs);
        objDBManager.AddParameter("@PracticeLocationId", PracticeLocationId);
        objDBManager.AddParameter("@StaffNPI", StaffNPI);

        if (!string.IsNullOrEmpty(Insurance))
            objDBManager.AddParameter("@Insurance", Insurance);
        if (ClaimId != "")
            objDBManager.AddParameter("@ClaimId", ClaimId);
        if (level != null)
            objDBManager.AddParameter("@Level", level);
        if (!string.IsNullOrEmpty(type))
            objDBManager.AddParameter("@Type", type);
        if (IsImportedDataOnly != null)
        {
            objDBManager.AddParameter("@IsImportedDataOnly", IsImportedDataOnly);
        }
        if (Payerid != null)
        {
            objDBManager.AddParameter("@ClaimpayerId", Payerid);
        }
        if (!string.IsNullOrEmpty(ClaimStatus))
            objDBManager.AddParameter("@claimstatus", ClaimStatus);
        return objDBManager.ExecuteDataSet("GetClaimsDetail_ProviderPortalUnPaidClaims");
    }
    public DataSet GetClaimsDetail_ProviderPortalAdjClaims(long PracticeId, int Rows, int PageNumber, string SortBy, string DateType, string StartDate, string EndDate,
        string PracticeLocationId, string StaffNPI, string Insurance, string ClaimId, bool? IsImportedDataOnly, string level = null, string type = null, string CPTcode = null, string BillAs = null, string ClaimStatus = null, string Payerid = null)
    {
        DBManager objDBManager = new DBManager();

        objDBManager.AddParameter("PracticeId", PracticeId);
        objDBManager.AddParameter("@Rows", Rows);
        objDBManager.AddParameter("@PageNumber", PageNumber);

        if (!string.IsNullOrEmpty(DateType))
            objDBManager.AddParameter("@DateType", DateType);

        if (!string.IsNullOrEmpty(StartDate))
            objDBManager.AddParameter("@StartDate", StartDate);

        if (!string.IsNullOrEmpty(EndDate))
            objDBManager.AddParameter("@EndDate", EndDate);
        if (!string.IsNullOrEmpty(CPTcode))
            objDBManager.AddParameter("@CPTcode", CPTcode);
        if (!string.IsNullOrEmpty(BillAs))
            objDBManager.AddParameter("@billas", BillAs);
        objDBManager.AddParameter("@PracticeLocationId", PracticeLocationId);
        objDBManager.AddParameter("@StaffNPI", StaffNPI);

        if (!string.IsNullOrEmpty(Insurance))
            objDBManager.AddParameter("@Insurance", Insurance);
        if (ClaimId != "")
            objDBManager.AddParameter("@ClaimId", ClaimId);
        if (level != null)
            objDBManager.AddParameter("@Level", level);
        if (!string.IsNullOrEmpty(type))
            objDBManager.AddParameter("@Type", type);
        if (IsImportedDataOnly != null)
        {
            objDBManager.AddParameter("@IsImportedDataOnly", IsImportedDataOnly);
        }
        if (Payerid != null)
        {
            objDBManager.AddParameter("@ClaimpayerId", Payerid);
        }
        if (!string.IsNullOrEmpty(ClaimStatus))
            objDBManager.AddParameter("@claimstatus", ClaimStatus);
        return objDBManager.ExecuteDataSet("GetClaimsDetail_ProviderPortalAdjClaims");
    }
    public DataSet GetClaimsDetail_ProviderPortalChargedCPT(long PracticeId, int Rows, int PageNumber, string SortBy, string DateType, string StartDate, string EndDate, string PracticeLocationId, string StaffNPI,
        string Insurance, string ClaimId, bool? IsImportedDataOnly, string level = null, string type = null, string CPTcode = null, string BillAs = null, string ClaimStatus = null,string Payerid=null)
    {
        DBManager objDBManager = new DBManager();

        objDBManager.AddParameter("PracticeId", PracticeId);
        objDBManager.AddParameter("@Rows", Rows);
        objDBManager.AddParameter("@PageNumber", PageNumber);

        if (!string.IsNullOrEmpty(DateType))
            objDBManager.AddParameter("@DateType", DateType);

        if (!string.IsNullOrEmpty(StartDate))
            objDBManager.AddParameter("@StartDate", StartDate);

        if (!string.IsNullOrEmpty(EndDate))
            objDBManager.AddParameter("@EndDate", EndDate);

        if (!string.IsNullOrEmpty(CPTcode))
            objDBManager.AddParameter("@CPTcode", CPTcode);
        if (!string.IsNullOrEmpty(BillAs))
            objDBManager.AddParameter("@billas", BillAs);

        objDBManager.AddParameter("@PracticeLocationId", PracticeLocationId);
        objDBManager.AddParameter("@StaffNPI", StaffNPI);

        if (!string.IsNullOrEmpty(Insurance))
            objDBManager.AddParameter("@Insurance", Insurance);
        if (ClaimId != "")
            objDBManager.AddParameter("@ClaimId", ClaimId);
        if (level != null)
            objDBManager.AddParameter("@Level", level);
        if (!string.IsNullOrEmpty(type))
            objDBManager.AddParameter("@Type", type);
        if (IsImportedDataOnly != null)
        {
            objDBManager.AddParameter("@IsImportedDataOnly", IsImportedDataOnly);
        }
        if (Payerid != null)
        {
            objDBManager.AddParameter("@ClaimpayerId", Payerid);
        }
        if (!string.IsNullOrEmpty(ClaimStatus))
            objDBManager.AddParameter("@claimstatus", ClaimStatus);
        return objDBManager.ExecuteDataSet("GetClaimsDetail_ProviderPortalChargedCPT");
    }
    public DataSet GetClaimsDetail_ProviderPortalPaidCPT(long PracticeId, int Rows, int PageNumber, string SortBy, string DateType,
        string StartDate, string EndDate, string PracticeLocationId, string StaffNPI, string Insurance, string ClaimId, bool? IsImportedDataOnly,
        string level = null, string type = null, string CPTcode = null, string BillAs = null, string ClaimStatus = null,string Payerid=null)
    {
        DBManager objDBManager = new DBManager();

        objDBManager.AddParameter("PracticeId", PracticeId);
        objDBManager.AddParameter("@Rows", Rows);
        objDBManager.AddParameter("@PageNumber", PageNumber);

        if (!string.IsNullOrEmpty(DateType))
            objDBManager.AddParameter("@DateType", DateType);

        if (!string.IsNullOrEmpty(StartDate))
            objDBManager.AddParameter("@StartDate", StartDate);
        if (!string.IsNullOrEmpty(BillAs))
            objDBManager.AddParameter("@billas", BillAs);
        if (!string.IsNullOrEmpty(EndDate))
            objDBManager.AddParameter("@EndDate", EndDate);
        if (!string.IsNullOrEmpty(CPTcode))
            objDBManager.AddParameter("@CPTcode", CPTcode);
        objDBManager.AddParameter("@PracticeLocationId", PracticeLocationId);

        //if (!string.IsNullOrEmpty(ProviderId))
        objDBManager.AddParameter("@StaffNPI", StaffNPI);

        if (!string.IsNullOrEmpty(Insurance))
            objDBManager.AddParameter("@Insurance", Insurance);
        if (ClaimId != "")
            objDBManager.AddParameter("@ClaimId", ClaimId);
        if (level != null)
            objDBManager.AddParameter("@Level", level);
        if (!string.IsNullOrEmpty(type))
            objDBManager.AddParameter("@Type", type);
        if (IsImportedDataOnly != null)
        {
            objDBManager.AddParameter("@IsImportedDataOnly", IsImportedDataOnly);
        }
        if (Payerid != null)
        {
            objDBManager.AddParameter("@ClaimpayerId", Payerid);
        }
        if (!string.IsNullOrEmpty(ClaimStatus))
            objDBManager.AddParameter("@claimstatus", ClaimStatus);
        return objDBManager.ExecuteDataSet("GetClaimsDetail_ProviderPortalPaidCPT");
    }
    public DataSet GetClaimsDetail_ProviderPortalUnPaidCPT(long PracticeId, int Rows, int PageNumber, string SortBy, string DateType, string StartDate, string EndDate,
        string PracticeLocationId, string StaffNPI, string Payerid,string ClaimId, bool? IsImportedDataOnly, string level = null, string type = null, string CPTcode = null, string BillAs = null, string ClaimStatus = null)
    {
        DBManager objDBManager = new DBManager();

        objDBManager.AddParameter("PracticeId", PracticeId);
        objDBManager.AddParameter("@Rows", Rows);
        objDBManager.AddParameter("@PageNumber", PageNumber);

        if (!string.IsNullOrEmpty(DateType))
            objDBManager.AddParameter("@DateType", DateType);

        if (!string.IsNullOrEmpty(StartDate))
            objDBManager.AddParameter("@StartDate", StartDate);

        if (!string.IsNullOrEmpty(EndDate))
            objDBManager.AddParameter("@EndDate", EndDate);
        if (!string.IsNullOrEmpty(CPTcode))
            objDBManager.AddParameter("@CPTcode", CPTcode);
        objDBManager.AddParameter("@PracticeLocationId", PracticeLocationId);

        if (!string.IsNullOrEmpty(BillAs))
            objDBManager.AddParameter("@billas", BillAs);
        objDBManager.AddParameter("@StaffNPI", StaffNPI);

        //if (!string.IsNullOrEmpty(Insurance))
        //    objDBManager.AddParameter("@Insurance", Insurance);
        if (ClaimId != "")
            objDBManager.AddParameter("@ClaimId", ClaimId);
        if (level != null)
            objDBManager.AddParameter("@Level", level);
        if (!string.IsNullOrEmpty(type))
            objDBManager.AddParameter("@Type", type);
        if (IsImportedDataOnly != null)
        {
            objDBManager.AddParameter("@IsImportedDataOnly", IsImportedDataOnly);
        }
        if (Payerid != null || Payerid != "")
        {
            objDBManager.AddParameter("@ClaimpayerId", Payerid);
        }
        if (!string.IsNullOrEmpty(ClaimStatus))
            objDBManager.AddParameter("@claimstatus", ClaimStatus);
        return objDBManager.ExecuteDataSet("GetClaimsDetail_ProviderPortalUnPaidCPT");
    }

    public DataSet GetClaimsDetail_ProviderPortalAdjCPT(long PracticeId, int Rows, int PageNumber, string SortBy, string DateType, string StartDate, string EndDate,
        string PracticeLocationId, string StaffNPI, string Insurance, string ClaimId, bool? IsImportedDataOnly, string level = null, string type = null, string CPTcode = null, string BillAs = null, string ClaimStatus = null, string Payerid = null)
    {
        DBManager objDBManager = new DBManager();

        objDBManager.AddParameter("PracticeId", PracticeId);
        objDBManager.AddParameter("@Rows", Rows);
        objDBManager.AddParameter("@PageNumber", PageNumber);

        if (!string.IsNullOrEmpty(DateType))
            objDBManager.AddParameter("@DateType", DateType);

        if (!string.IsNullOrEmpty(StartDate))
            objDBManager.AddParameter("@StartDate", StartDate);

        if (!string.IsNullOrEmpty(EndDate))
            objDBManager.AddParameter("@EndDate", EndDate);
        if (!string.IsNullOrEmpty(CPTcode))
            objDBManager.AddParameter("@CPTcode", CPTcode);
        objDBManager.AddParameter("@PracticeLocationId", PracticeLocationId);

        if (!string.IsNullOrEmpty(BillAs))
            objDBManager.AddParameter("@billas", BillAs);
        objDBManager.AddParameter("@StaffNPI", StaffNPI);

        if (!string.IsNullOrEmpty(Insurance))
            objDBManager.AddParameter("@Insurance", Insurance);
        if (ClaimId != "")
            objDBManager.AddParameter("@ClaimId", ClaimId);
        if (level != null)
            objDBManager.AddParameter("@Level", level);
        if (!string.IsNullOrEmpty(type))
            objDBManager.AddParameter("@Type", type);
        if (IsImportedDataOnly != null)
        {
            objDBManager.AddParameter("@IsImportedDataOnly", IsImportedDataOnly);
        }
        if (Payerid != null)
        {
            objDBManager.AddParameter("@ClaimpayerId", Payerid);
        }
        if (!string.IsNullOrEmpty(ClaimStatus))
            objDBManager.AddParameter("@claimstatus", ClaimStatus);
        return objDBManager.ExecuteDataSet("GetClaimsDetail_ProviderPortalAdjProc");
    }
    public DataTable GetSearchedReports(string Search)
    {
        DBManager objDBManager = new DBManager();

        objDBManager.AddParameter("Search", Search);
        return objDBManager.ExecuteDataTable("Get_SearchedReports");
    }
    public DataSet GetLocationWiseCollection(long PracticeId)
    {
        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("PracticeId", PracticeId);
        return objDBManager.ExecuteDataSet("GetLocationCollectionReport");

    }
    public DataSet LocationWiseDataSummary(long PracticeId, int Rows, int PageNumber, string StartDate, string EndDate, string DateType, string Practicesatffid = null, string practicelocationid = null, string CheckAssociated = null, string InsuranceID = null)
    {
        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("PracticeId", PracticeId);
        objDBManager.AddParameter("@Rows", Rows);
        objDBManager.AddParameter("@PageNumber", PageNumber);
        if (!string.IsNullOrEmpty(StartDate))
            objDBManager.AddParameter("@StartDate", StartDate);
        if (!string.IsNullOrEmpty(EndDate))
            objDBManager.AddParameter("@EndDate", EndDate);
        if (!string.IsNullOrEmpty(InsuranceID))
            objDBManager.AddParameter("@InsuranceID", InsuranceID);
        if (!string.IsNullOrEmpty(Practicesatffid))
            objDBManager.AddParameter("@Staffnpi", Practicesatffid);
        if (!string.IsNullOrEmpty(practicelocationid))
            objDBManager.AddParameter("@practicelocationid", practicelocationid);
        if (!string.IsNullOrEmpty(DateType))
            objDBManager.AddParameter("@DateType", DateType);

        if (!string.IsNullOrEmpty(CheckAssociated))
            objDBManager.AddParameter("@CheckAssociated", CheckAssociated);

        return objDBManager.ExecuteDataSet("LocationWiseCollectionReportSummary");
    }
    public DataTable GetLocationNamePracticestaffDropDown(long PracticeId,string StaffNPI)
    {
        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("PracticeId", PracticeId);
        if (StaffNPI == "")  
        {
            objDBManager.AddParameter("StaffNPI", DBNull.Value);
        }
        else
        {
            objDBManager.AddParameter("StaffNPI", StaffNPI);
        }
        return objDBManager.ExecuteDataTable("GetLocationNamePracticestaffDropDown");


    }
    public DataTable GetPracticeStaffLocationNameDropDown(long PracticeId, string PracticeLocationId)
    {
        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("PracticeId", PracticeId);
        if (PracticeLocationId == "")
        {
            objDBManager.AddParameter("PracticeLocationId", DBNull.Value);
        }
        else
        {
            objDBManager.AddParameter("PracticeLocationId", PracticeLocationId);
        }
        return objDBManager.ExecuteDataTable("GetPracticeStaffLocationNameDropDown");


    }
    public DataTable GetLocationsByDefault(long PracticeId)
    {
        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("PracticeId", PracticeId);
        return objDBManager.ExecuteDataTable("GetPracticeLocationDropDown");



    }
    public DataTable GetProvidersByDefault(long PracticeId)
    {
        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("PracticeId", PracticeId);
        return objDBManager.ExecuteDataTable("GetPracticeStaffNameDropDown");



    }

    //Added by Daniyal_Baig 10Dec2018
    public DataSet GetDeductableReport(long PracticeId, string CreatedById, int Rows, int PageNumber, string DateType, string StartDate, string EndDate, string PracticeLocationId, string ProviderId, string InsuranceType, string PriInsurance, string SecInsurance, string PriClaimStatus, string SecClaimStatus, string ReasonCodeValues)
    {
        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("PracticeId", PracticeId);
        objDBManager.AddParameter("@Rows", Rows);
        objDBManager.AddParameter("@PageNumber", PageNumber);
        if (!string.IsNullOrEmpty(DateType))
            objDBManager.AddParameter("@DateType", DateType);

        if (!string.IsNullOrEmpty(StartDate))
            objDBManager.AddParameter("@StartDate", StartDate);

        if (!string.IsNullOrEmpty(EndDate))
            objDBManager.AddParameter("@EndDate", EndDate);
        //
        if (!string.IsNullOrEmpty(PracticeLocationId))
            objDBManager.AddParameter("@PracticeLocationId", PracticeLocationId);

        if (!string.IsNullOrEmpty(ProviderId))
            objDBManager.AddParameter("@ProviderId", ProviderId);

        if (!string.IsNullOrEmpty(InsuranceType))
            objDBManager.AddParameter("@InsuranceType ", InsuranceType);

        if (!string.IsNullOrEmpty(PriInsurance))
            objDBManager.AddParameter("@PriInsurance", PriInsurance);

        if (!string.IsNullOrEmpty(SecInsurance))
            objDBManager.AddParameter("@SecInsurance", SecInsurance);

        if (!string.IsNullOrEmpty(PriClaimStatus))
            objDBManager.AddParameter("@PriClaimStatus", PriClaimStatus);

        if (!string.IsNullOrEmpty(SecClaimStatus))
            objDBManager.AddParameter("@SecClaimStatus", SecClaimStatus);
        if (!string.IsNullOrEmpty(ReasonCodeValues))
        {
            objDBManager.AddParameter("@ReasonCode", ReasonCodeValues);
        }

        return objDBManager.ExecuteDataSet("GetDeductableReport");
    }
    //End
    //*** Added by Daniyal_Baig 12March2019 ***//
    public DataSet GetProcedurePaymentsReport(long PracticeId, string ReportType, string DateType, string StartDate, string EndDate, string CPTCode, string InsuranceType, string InsuranceId)
    {
        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("PracticeId", PracticeId);
        //objDBManager.AddParameter("@Rows", Rows);
        //objDBManager.AddParameter("@PageNumber", PageNumber);
        if (!string.IsNullOrEmpty(ReportType))
            objDBManager.AddParameter("ReportType", ReportType);

        if (!string.IsNullOrEmpty(DateType))
            objDBManager.AddParameter("DateType", DateType);

        if (!string.IsNullOrEmpty(StartDate))
            objDBManager.AddParameter("@DateTo", StartDate);

        if (!string.IsNullOrEmpty(EndDate))
            objDBManager.AddParameter("@DateFrom", EndDate);

        if (!string.IsNullOrEmpty(CPTCode))
            objDBManager.AddParameter("CPTCode", CPTCode);

        if (!string.IsNullOrEmpty(InsuranceType))
            objDBManager.AddParameter("PaymentSource", InsuranceType);

        if (!string.IsNullOrEmpty(InsuranceId))
            objDBManager.AddParameter("InsuranceId", InsuranceId);

        return objDBManager.ExecuteDataSet("GetCPTwisePaymentDetail");
    }

    //End
    //public DataTable GetProvidersByDefault(long PracticeId)
    //{
    //    DBManager objDBManager = new DBManager();
    //    objDBManager.AddParameter("PracticeId", PracticeId);
    //    return objDBManager.ExecuteDataTable("GetPracticeStaffNameDropDown ");



    //}
    /////added by irfan
    //public DataSet GetPracticeStaffLocationNameDropDown(long PracticeId, string PracticeLocationId)
    //{
    //    DBManager objDBManager = new DBManager();
    //    objDBManager.AddParameter("PracticeId", PracticeId);
    //    objDBManager.AddParameter("Practicelocationid", PracticeLocationId);

    //    return objDBManager.ExecuteDataSet("GetPracticeStaffLocationNameDropDown");
    //}
    //public DataSet GetLocationNamePracticestaffDropDown(long PracticeId, string StaffNpi)
    //{
    //    DBManager objDBManager = new DBManager();
    //    objDBManager.AddParameter("PracticeId", PracticeId);
    //    objDBManager.AddParameter("StaffNpi", StaffNpi);

    //    return objDBManager.ExecuteDataSet("GetLocationNamePracticestaffDropDown");
    //}

    public DataSet CPTWiseCollection(long PracticeId, int Rows, int PageNumber, string DateType, string StartDate, string EndDate, string PracticeLocationId, string staffnpi, string CheckAssociated = null, string InsuranceID = null, string CPTCode = null)
    {
        DBManager objDbManager = new DBManager();
        objDbManager.AddParameter("PracticeId", PracticeId);
        objDbManager.AddParameter("Rows", Rows);
        objDbManager.AddParameter("PageNumber", PageNumber);
        if (!string.IsNullOrEmpty(InsuranceID))
            objDbManager.AddParameter("InsuranceID", InsuranceID);
        if (!string.IsNullOrEmpty(CPTCode))
            objDbManager.AddParameter("CPTCode", CPTCode);
        if (!string.IsNullOrEmpty(DateType))
            objDbManager.AddParameter("DateType", DateType);
        if (!string.IsNullOrEmpty(StartDate))
            objDbManager.AddParameter("StartDate", StartDate);
        if (!string.IsNullOrEmpty(EndDate))
            objDbManager.AddParameter("EndDate", EndDate);

        if (PracticeLocationId == "")
        {
            objDbManager.AddParameter("practicelocationid", DBNull.Value);
        }
        else
        {
            objDbManager.AddParameter("practicelocationid", PracticeLocationId);

        }
        if (staffnpi == "")
        {
            objDbManager.AddParameter("staffnpi", DBNull.Value);
        }
        else
        {
            objDbManager.AddParameter("staffnpi", staffnpi);

        }
        objDbManager.AddParameter("CheckAssociated", CheckAssociated);
        return objDbManager.ExecuteDataSet("ProcedureWiseCollectionReportSummary");
    }
    public DataSet FilterPatientss(long PatientId, string FirstName, string LastName, string DOB, string Phone, string Gender, string Address, string PriInsurance, string PatientCondition, long PracticeId, int Rows, int PageNumber, string SortBy, bool IsPTL = false, string PTLReasons = "", bool IsRPM = false,
        string SSN = "", string PolicyNumber = "", DateTime? DateFrom = null, DateTime? DateTo = null, string InsuranceID = "", string City = "", string Zip = "", string State = "")
    {
        DBManager objDBManager = new DBManager();

        objDBManager.AddParameter("@PracticeId", PracticeId);
        objDBManager.AddParameter("@Rows", Rows);
        objDBManager.AddParameter("@PageNumber", PageNumber);
        objDBManager.AddParameter("@SortBy", SortBy);

        if (PatientId != 0)
        {
            objDBManager.AddParameter("@PatientId", PatientId);
        }
        if (!string.IsNullOrEmpty(PriInsurance))
        {
            objDBManager.AddParameter("@PriInsurance", PriInsurance);
        }
        if (!string.IsNullOrEmpty(FirstName))
        {
            objDBManager.AddParameter("@FirstName", FirstName);
        }

        if (!string.IsNullOrEmpty(LastName))
        {
            objDBManager.AddParameter("@LastName", LastName);
        }

        if (!string.IsNullOrEmpty(DOB))
        {
            objDBManager.AddParameter("@DateOfBirth", Convert.ToDateTime(DOB));
        }

        if (!string.IsNullOrEmpty(Gender))
        {
            objDBManager.AddParameter("@Gender", Gender);
        }

        if (!string.IsNullOrEmpty(Phone))
        {
            objDBManager.AddParameter("@Phone", Phone);
        }

        if (!string.IsNullOrEmpty(Address))
        {
            objDBManager.AddParameter("@Address", Address);
        }

        if (!string.IsNullOrEmpty(PatientCondition))
        {
            objDBManager.AddParameter("@PatientCondition", PatientCondition);
        }

        if (IsPTL)
        {
            objDBManager.AddParameter("IsPTL", IsPTL);
        }
        if (IsRPM)
        {
            objDBManager.AddParameter("IsRPM", IsRPM);
        }
        if (!string.IsNullOrEmpty(PTLReasons))
        {
            objDBManager.AddParameter("PTLReasons", PTLReasons);
        }
        ///Start  Modified By Irfan Mahmood 15-Oct-2021///
        if (!string.IsNullOrEmpty(SSN))
        {
            objDBManager.AddParameter("@SSN", SSN);
        }
        if (!string.IsNullOrEmpty(PolicyNumber))
        {
            objDBManager.AddParameter("@PolicyNo", PolicyNumber);
        }
        if (!string.IsNullOrEmpty(InsuranceID))
        {
            objDBManager.AddParameter("@InsuranceId", InsuranceID);
        }
        ///Start  Modified By Irfan Mahmood 25-Oct-2021///
        if (!string.IsNullOrEmpty(City))
        {
            objDBManager.AddParameter("@City", City);
        }
        if (!string.IsNullOrEmpty(Zip))
        {
            objDBManager.AddParameter("@ZIP", Zip);
        }
        if (!string.IsNullOrEmpty(State))
        {
            objDBManager.AddParameter("@State", State);
        }

        objDBManager.AddParameter("@DateFrom", DateFrom);
        objDBManager.AddParameter("@DateTo", DateTo);

        ///End  Modified By Irfan Mahmood 25-Oct-2021///
        return objDBManager.ExecuteDataSet("Patient_GetPatientBySearchCriteria");
    }
    public DataSet CountPTL(long PracticeId)
    {
        DBManager objDBManager = new DBManager();

        objDBManager.AddParameter("@PracticeId", PracticeId);

        return objDBManager.ExecuteDataSet("PTL_TotalCounts");
    }
    public DataSet GetOverPaidClaims(long PracticeId, int Rows, int PageNumber, string SortBy, string DateFrom, string DateTo, string DateType,
        string Payer, string ClaimStatus, string BilledAs, string LocationId="", string ProviderId="")
    {
        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("PracticeId", PracticeId);
        objDBManager.AddParameter("Rows", Rows);
        objDBManager.AddParameter("PageNumber", PageNumber);

        if (!string.IsNullOrEmpty(SortBy))
        {
            objDBManager.AddParameter("SortBy", SortBy);
        }

        if (!string.IsNullOrEmpty(DateFrom))
        {
            objDBManager.AddParameter("DateFrom", DateFrom);
        }
        if (!string.IsNullOrEmpty(DateTo))
        {
            objDBManager.AddParameter("DateTo", DateTo);
        }
        if (!string.IsNullOrEmpty(DateType))
        {
            objDBManager.AddParameter("@DateType", DateType);
        }
        if (!string.IsNullOrEmpty(Payer))
        {
            objDBManager.AddParameter("Payers", Payer);
        }
        if (!string.IsNullOrEmpty(ClaimStatus))
        {
            objDBManager.AddParameter("ClaimStatus", ClaimStatus);
        }
        if (!string.IsNullOrEmpty(BilledAs))
        {
            objDBManager.AddParameter("BilledAs", BilledAs);
        }
        if (!string.IsNullOrEmpty(LocationId))
        {
            objDBManager.AddParameter("@LocationId", LocationId);
        }
        if (!string.IsNullOrEmpty(ProviderId))
        {
            objDBManager.AddParameter("@ProviderId", ProviderId);
        }
        return objDBManager.ExecuteDataSet("GetOverPaidClaimsReport");
    }
    public DataSet GetAllByPatient(long PatientId, string ClaimId, long PracticeID, string BatchId = null)
    {

        DBManager objDbManager = new DBManager();

        if (PatientId != 0)
        {
            objDbManager.AddParameter("PatientId", PatientId);
        }
        if (PracticeID != 0)
        {
            objDbManager.AddParameter("practiceID", PracticeID);
        }
        if (!string.IsNullOrEmpty(ClaimId))
        {
            objDbManager.AddParameter("ClaimId", ClaimId);
        }

        if (!string.IsNullOrEmpty(BatchId))
        {
            objDbManager.AddParameter("@BatchClaimId", BatchId);
        }

        return objDbManager.ExecuteDataSet("Claims_GetAllByPatient");
    }
}

