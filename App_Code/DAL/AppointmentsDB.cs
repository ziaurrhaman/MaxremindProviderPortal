using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for AppointmentsDB
/// </summary>
public class AppointmentsDB
{
    public AppointmentsDB()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public long Add(Appointments objAppointments, SqlTransaction objSqlTransaction = null)
    {
        DBManager objDBManager = new DBManager(objSqlTransaction);
        try
        {
            objDBManager.AddParameter("AppointmentsId", objAppointments.AppointmentsId, SqlDbType.Int, 4, ParameterDirection.Output);

            objDBManager.AddParameter("PracticeId", long.Parse(HttpContext.Current.Profile.GetPropertyValue("PracticeId").ToString()));
            objDBManager.AddParameter("PracticeLocationsId", objAppointments.PracticeLocationsId);
            objDBManager.AddParameter("ReasonId", objAppointments.ReasonId);
            objDBManager.AddParameter("PatientId", objAppointments.PatientId);
            objDBManager.AddParameter("ServiceProviderId", objAppointments.ServiceProviderId);
            objDBManager.AddParameter("ResourceId", objAppointments.ResourceId);
            objDBManager.AddParameter("Notes", objAppointments.Notes);
            objDBManager.AddParameter("AppointmentDate", objAppointments.AppointmentDate);
            objDBManager.AddParameter("StartTime", objAppointments.StartTime);
            objDBManager.AddParameter("EndTime", objAppointments.EndTime);
            objDBManager.AddParameter("StatusId", objAppointments.StatusId);
            
            objDBManager.AddParameter("BookingReferenceNo", objAppointments.BookingReferenceNo);
            
            objDBManager.AddParameter("IsRecurrence", objAppointments.IsRecurrence);
            objDBManager.AddParameter("RecurrenceDays", objAppointments.RecurrenceDays);
            objDBManager.AddParameter("RecurrenceFrequency", objAppointments.RecurrenceFrequency);
            objDBManager.AddParameter("RecurrenceUnit", objAppointments.RecurrenceUnit);
            
            objDBManager.AddParameter("CreatedById", objAppointments.CreatedById);
            objDBManager.AddParameter("CreatedDate", objAppointments.CreatedDate);
            
            objDBManager.ExecuteNonQuery("Appointments_Add");
            
            objAppointments.AppointmentsId = long.Parse(objDBManager.Parameters[0].Value.ToString());
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return objAppointments.AppointmentsId;
    }

    public long Reccurence(long AppointmentsId, long ParentAppointmentId, Appointments objAppointments, int Interval, SqlTransaction objSqlTransaction = null)
    {
        DBManager objDBManager = new DBManager(objSqlTransaction);
        try
        {
            objDBManager.AddParameter("AppointmentsId", AppointmentsId);
            objDBManager.AddParameter("ParentAppointmentId", ParentAppointmentId);
            objDBManager.AddParameter("AppointmentDate", objAppointments.AppointmentDate);
            objDBManager.AddParameter("Interval", Interval);
            objDBManager.AddParameter("RecurrenceDays", objAppointments.RecurrenceDays);
            
            objDBManager.ExecuteNonQuery("Appointment_Reccurence");
            
            objAppointments.AppointmentsId = long.Parse(objDBManager.Parameters[0].Value.ToString());
        }
        catch (Exception ex)
        {
            throw ex;
        }
        
        return objAppointments.AppointmentsId;
    }
    
    public int Update(Appointments objAppointments, SqlTransaction objSqlTransaction = null)
    {
        DBManager objDBManager = new DBManager(objSqlTransaction);
        int ReturnValue = 0;

        try
        {
            objDBManager.AddParameter("AppointmentsId", objAppointments.AppointmentsId, SqlDbType.Int, 4);

            objDBManager.AddParameter("PracticeLocationsId", objAppointments.PracticeLocationsId);
            objDBManager.AddParameter("IsRecurrence", objAppointments.IsRecurrence);
            objDBManager.AddParameter("ReasonId", objAppointments.ReasonId);
            objDBManager.AddParameter("PatientId", objAppointments.PatientId);
            objDBManager.AddParameter("ServiceProviderId", objAppointments.ServiceProviderId);
            objDBManager.AddParameter("ResourceId", objAppointments.ResourceId);
            objDBManager.AddParameter("Notes", objAppointments.Notes);
            objDBManager.AddParameter("AppointmentDate", objAppointments.AppointmentDate);
            objDBManager.AddParameter("StartTime", objAppointments.StartTime);
            objDBManager.AddParameter("EndTime", objAppointments.EndTime);
            objDBManager.AddParameter("StatusId", objAppointments.StatusId);

            objDBManager.AddParameter("BookingReferenceNo", objAppointments.BookingReferenceNo);

            objDBManager.AddParameter("ModifiedById", objAppointments.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objAppointments.ModifiedDate);

            ReturnValue = objDBManager.ExecuteNonQuery("Appointments_Update");
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return ReturnValue;
    }

    public int UpdateAppointmentTime(Appointments objAppointments, SqlTransaction objSqlTransaction = null)
    {

        DBManager objDBManager = new DBManager(objSqlTransaction);
        int ReturnValue = 0;
        try
        {
            objDBManager.AddParameter("AppointmentsId", objAppointments.AppointmentsId, SqlDbType.Int, 4);
            objDBManager.AddParameter("EndTime", objAppointments.EndTime);
            objDBManager.AddParameter("ModifiedById", objAppointments.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objAppointments.ModifiedDate);

            ReturnValue = objDBManager.ExecuteNonQuery("Appointments_UpdateTime");
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ReturnValue;
    }

    public int UpdateStatus(Appointments objAppointments, SqlTransaction objSqlTransaction = null)
    {

        DBManager objDBManager = new DBManager(objSqlTransaction);
        int ReturnValue = 0;

        try
        {
            objDBManager.AddParameter("AppointmentsId", objAppointments.AppointmentsId);
            objDBManager.AddParameter("ModifiedById", objAppointments.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objAppointments.ModifiedDate);
            objDBManager.AddParameter("StatusId", objAppointments.StatusId);

            ReturnValue = objDBManager.ExecuteNonQuery("Appointments_UpdateStatus");

        }
        catch (Exception ex)
        {
            throw ex;
        }

        return ReturnValue;
    }

    public int UpdateAppointmentStatus(long appointmentId, int statusId, long modifiedById)
    {

        DBManager objDBManager = new DBManager();
        int ReturnValue = 0;

        try
        {
            objDBManager.AddParameter("AppointmentsId", appointmentId);
            objDBManager.AddParameter("ModifiedById", modifiedById);
            objDBManager.AddParameter("ModifiedDate", DateTime.Now);
            objDBManager.AddParameter("StatusId", statusId);

            ReturnValue = objDBManager.ExecuteNonQuery("Appointments_UpdateAppointmentStatus");

        }
        catch (Exception ex)
        {
            throw ex;
        }

        return ReturnValue;

    }

    public int UpdateAppointmentStatus(Appointments objAppointments, SqlTransaction objSqlTransaction = null)
    {
        DBManager objDBManager = new DBManager(objSqlTransaction);
        int ReturnValue = 0;

        try
        {
            objDBManager.AddParameter("AppointmentsId", objAppointments.AppointmentsId);
            objDBManager.AddParameter("StatusId", objAppointments.StatusId);

            if (objAppointments.CheckInRoomId != 0)
            {
                objDBManager.AddParameter("CheckInRoomId", objAppointments.CheckInRoomId);
                objDBManager.AddParameter("CheckInTime", objAppointments.CheckInTime);
            }

            objDBManager.AddParameter("ModifiedById", objAppointments.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objAppointments.ModifiedDate);

            ReturnValue = objDBManager.ExecuteNonQuery("Appointments_UpdateStatusInfo");
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return ReturnValue;
    }

    public void UpdateServiceProvider(long ServiceProviderFrom, long ServiceProviderTo, string StatusIds, DateTime ModifiedDate, long @ModifiedById)
    {
        DBManager objDBManager = new DBManager();

        objDBManager.AddParameter("ServiceProviderFrom", ServiceProviderFrom);
        objDBManager.AddParameter("ServiceProviderTo", ServiceProviderTo);
        objDBManager.AddParameter("StatusIds", StatusIds);

        objDBManager.AddParameter("ModifiedDate", ModifiedDate);
        objDBManager.AddParameter("ModifiedById", ModifiedById);

        objDBManager.ExecuteNonQuery("Appointments_UpdateServiceProvider");
    }

    public void UpdateCheckInRoom(long AppointmentsId, int RoomId, DateTime Time)
    {
        DBManager objDBManager = new DBManager();

        objDBManager.AddParameter("AppointmentId", AppointmentsId);
        objDBManager.AddParameter("RoomId", RoomId);
        objDBManager.AddParameter("Time", Time);

        objDBManager.ExecuteNonQuery("Appointments_UpdateCheckInRoom");
    }

    public int Delete(Appointments objAppointments, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);

            objDBManager.AddParameter("AppointmentsId", objAppointments.AppointmentsId);
            objDBManager.AddParameter("DeleteReason", objAppointments.DeleteReason);

            objDBManager.AddParameter("ModifiedById", objAppointments.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objAppointments.ModifiedDate);

            return objDBManager.ExecuteNonQuery("Appointments_Delete");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable GetByID(int AppointmentsId, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);
            objDBManager.AddParameter("AppointmentsId", AppointmentsId, SqlDbType.Int, 4);
            return objDBManager.ExecuteDataTable("Appointments_GetByID");
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    public DataSet GetByPatientId(long PatientId, int Rows, int PageNumber, string SortBy, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);
            objDBManager.AddParameter("PatientId", PatientId);
            objDBManager.AddParameter("@Rows", Rows);
            objDBManager.AddParameter("@PageNumber", PageNumber);
            if (!string.IsNullOrEmpty(SortBy))
                objDBManager.AddParameter("@SortBy", SortBy);
            return objDBManager.ExecuteDataSet("Appointments_GetByPatientId");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable GetAll(DateTime AppointmentDate, int PracticeLocationsId, long PracticeStaffId, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);

            objDBManager.AddParameter("@AppointmentDate", AppointmentDate);

            if (PracticeLocationsId != 0)
            {
                objDBManager.AddParameter("@PracticeLocationsId", PracticeLocationsId);
            }

            if (PracticeStaffId != 0)
            {
                objDBManager.AddParameter("@PracticeStaffId", PracticeStaffId);
            }

            return objDBManager.ExecuteDataTable("Appointments_GetAll");
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    public DataTable GetAllByProviders(DateTime AppointmentDate, int PracticeLocationsId, string PracticeStaffIds, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);

            objDBManager.AddParameter("AppointmentDate", AppointmentDate);

            if (PracticeLocationsId != 0)
            {
                objDBManager.AddParameter("PracticeLocationsId", PracticeLocationsId);
            }

            if (!string.IsNullOrEmpty(PracticeStaffIds))
            {
                objDBManager.AddParameter("PracticeStaffIds", PracticeStaffIds);
            }

            return objDBManager.ExecuteDataTable("Appointments_GetAllByProviders");
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    public DataTable GetAppointmentInfo(long AppointmentsId)
    {
        DBManager objDBManager = new DBManager();

        objDBManager.AddParameter("AppointmentsId", AppointmentsId);

        return objDBManager.ExecuteDataTable("Appointments_GetAppointmentInfo");
    }

    public DataTable GetAppointmentByID(long AppointmentsId)
    {
        DBManager objDBManager = new DBManager();

        objDBManager.AddParameter("AppointmentsId", AppointmentsId);

        return objDBManager.ExecuteDataTable("Appointments_GetAppointmentByID");
    }

    public DataSet GetAppointmentBySearchCriteria(long PracticeLocationsId, long PracticeStaffId, long PatientId, string PatientName, string AppointmentDate, string StartTime, string EndTime, string PatientPhone, string StatusId, int Rows, int PageNumber, string SortBy, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);

            if (PracticeLocationsId != 0)
            {
                objDBManager.AddParameter("@PracticeLocationsId", PracticeLocationsId);
            }

            if (PracticeStaffId != 0)
            {
                objDBManager.AddParameter("PracticeStaffId", PracticeStaffId);
            }

            objDBManager.AddParameter("@Rows", Rows);
            objDBManager.AddParameter("@PageNumber", PageNumber);

            if (!string.IsNullOrEmpty(SortBy))
            {
                objDBManager.AddParameter("@SortBy", SortBy);
            }

            if (PatientId != 0)
            {
                objDBManager.AddParameter("@PatientId", PatientId);
            }

            if (!string.IsNullOrEmpty(PatientName))
            {
                objDBManager.AddParameter("@PatientName", PatientName);
            }

            if (!string.IsNullOrEmpty(AppointmentDate))
            {
                objDBManager.AddParameter("@AppointmentDate", Convert.ToDateTime(AppointmentDate));
            }

            if (!string.IsNullOrEmpty(StartTime))
            {
                objDBManager.AddParameter("@StartTime", StartTime);
            }

            if (!string.IsNullOrEmpty(EndTime))
            {
                objDBManager.AddParameter("@EndTime", EndTime);
            }

            if (!string.IsNullOrEmpty(PatientPhone))
            {
                objDBManager.AddParameter("@PatientPhone", PatientPhone);
            }

            if (!string.IsNullOrEmpty(StatusId))
            {
                objDBManager.AddParameter("@StatusId", StatusId);
            }

            return objDBManager.ExecuteDataSet("Appointments_GetAppointmentBySearchCriteria");
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    public string GetAppointmentStatusBackColor(long AppointmentsId)
    {
        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("AppointmentsId", AppointmentsId);
        return objDBManager.ExecuteScalar("Appointments_GetAppointmentStatusBackColor");
    }

    public string GetAppointmentReasonBackColor(long AppointmentsId)
    {
        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("AppointmentsId", AppointmentsId);
        return objDBManager.ExecuteScalar("Appointments_GetAppointmentReasonBackColor");
    }

    public DataTable GetAppointmentColors(long AppointmentsId)
    {
        DBManager objDBManager = new DBManager();

        objDBManager.AddParameter("AppointmentsId", AppointmentsId);

        return objDBManager.ExecuteDataTable("Appointments_GetAppointmentColors");
    }

    public DataTable PatientRecentAppointment(long PatientId)
    {
        DBManager objDBManager = new DBManager();
        
        objDBManager.AddParameter("PatientId", PatientId);

        return objDBManager.ExecuteDataTable("Appointments_PatientRecentAppointment");
    }

    public DataSet GetCheckedInPatients(DateTime AppointmentDate, long PracticeId)
    {
        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("@AppointmentDate", AppointmentDate);
        objDBManager.AddParameter("PracticeId", PracticeId);
        return objDBManager.ExecuteDataSet("Appointment_GetCheckedInPatients");
    }

    public DataSet GetCheckedInPatientsList(Appointments objAppointments)
    {
        DBManager objDBManager = new DBManager();

        objDBManager.AddParameter("AppointmentDate", objAppointments.AppointmentDate);
        objDBManager.AddParameter("PracticeId", objAppointments.PracticeId);

        if (objAppointments.PracticeLocationsId != 0)
        {
            objDBManager.AddParameter("PracticeLocationsId", objAppointments.PracticeLocationsId);
        }

        if (objAppointments.ServiceProviderId != 0)
        {
            objDBManager.AddParameter("ServiceProviderId", objAppointments.ServiceProviderId);
        }

        return objDBManager.ExecuteDataSet("Appointment_GetCheckedInPatientsList");
    }

    public DataTable GetAppointmentsByLocations(long PracticeId)
    {
        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("PracticeId", PracticeId);

        return objDBManager.ExecuteDataTable("DashboardsAppointmentsByLocations_GetAll");
    }

    public DataTable GetDashboardsAppointmentsByReasons(long PracticeId)
    {
        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("PracticeId", PracticeId);

        return objDBManager.ExecuteDataTable("DashboardsAppointmentsByReasons_GetAll");

    }

    public DataSet GetDashBoardAppointmentsStatusbyLocations(long PracticeId)
    {
        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("PracticeId", PracticeId);

        return objDBManager.ExecuteDataSet("DashBoardAppointmentsStatusbyLocations_GetAll");

    }

    public DataTable GetAppointmentDetail(long AppointmentsId)
    {
        DBManager objDBManager = new DBManager();

        objDBManager.AddParameter("AppointmentsId", AppointmentsId);

        return objDBManager.ExecuteDataTable("Appointments_GetAppointmentDetail");
    }

    public DataTable GetPatientAppointmentDate(long PatientId)
    {
        DBManager objDBManager = new DBManager();

        objDBManager.AddParameter("PatientId", PatientId);

        return objDBManager.ExecuteDataTable("Appointments_GetPatientAppointmentDate");
    }
    public DataTable GetAppointmentsStatus()
    {
        DBManager objDBManager = new DBManager();
        return objDBManager.ExecuteDataTable("GetAppointmentStatus");
    }
    public DataTable GetAppointmentReasons(int PracticeId)
    {
        DBManager objDBManager = new DBManager();

        objDBManager.AddParameter("PracticeId", PracticeId);

        return objDBManager.ExecuteDataTable("GetAppointmentReasons");
    }

  

    public DataSet AppointmentDetails(long PracticeId, int Rows, int PageNumber, string SortBy, string PatientId, string Provider, string ServiceLocationId, string status, string reasons, string DateFrom, string DateTo)
    {
        DBManager objDBManager = new DBManager();

        if (PracticeId != 0)
        {
            objDBManager.AddParameter("PracticeId", PracticeId);
        }


        objDBManager.AddParameter("Rows", Rows);
        objDBManager.AddParameter("PageNumber", PageNumber);

        if (!string.IsNullOrEmpty(SortBy))
        {
            objDBManager.AddParameter("SortBy", SortBy);
        }
        if (!string.IsNullOrEmpty(PatientId))
        {
            objDBManager.AddParameter("PatientId", PatientId);
        }

        if (!string.IsNullOrEmpty(Provider))
        {
            objDBManager.AddParameter("Provider", Provider);
        }
        if (!string.IsNullOrEmpty(ServiceLocationId))
        {
            objDBManager.AddParameter("PracticeLocationsId", ServiceLocationId);
        }
        if (!string.IsNullOrEmpty(status))
        {
            objDBManager.AddParameter("Status", status);
        }
        if (!string.IsNullOrEmpty(reasons))
        {
            objDBManager.AddParameter("Reasons", reasons);
        }
        if (DateFrom != "")
        {
            objDBManager.AddParameter("DateFrom", DateFrom);
        }
        if (DateTo != "")
        {
            objDBManager.AddParameter("DateTo", DateTo);
        }
        return objDBManager.ExecuteDataSet("Reports_AppointmentDetail");
    }
}