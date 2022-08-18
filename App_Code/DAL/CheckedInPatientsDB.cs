using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for CheckedInPatientsDB
/// </summary>
public class CheckedInPatientsDB
{
	public CheckedInPatientsDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    
    public long Add(CheckedInPatients objCheckedInPatients, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);
            
            objDBManager.AddParameter("CheckedInPatientsId", objCheckedInPatients.CheckedInPatientsId, SqlDbType.BigInt, 8, ParameterDirection.Output);
            
            objDBManager.AddParameter("PracticeId", objCheckedInPatients.PracticeId);
            objDBManager.AddParameter("PracticeLocationsId", objCheckedInPatients.PracticeLocationsId);
            
            objDBManager.AddParameter("AppointmentsId", objCheckedInPatients.AppointmentsId);
            objDBManager.AddParameter("PatientId", objCheckedInPatients.PatientId);
            objDBManager.AddParameter("AppointmentDate", objCheckedInPatients.AppointmentDate);
            objDBManager.AddParameter("ArrivalTime", objCheckedInPatients.ArrivalTime);
            objDBManager.AddParameter("RoomId", objCheckedInPatients.RoomId);
            objDBManager.AddParameter("CheckInTime", objCheckedInPatients.CheckInTime);
            
            objDBManager.AddParameter("CreatedById", objCheckedInPatients.CreatedById);
            objDBManager.AddParameter("CreatedDate", objCheckedInPatients.CreatedDate);
            
            objDBManager.ExecuteNonQuery("CheckedInPatients_Add");
            
            return long.Parse(objDBManager.Parameters[0].Value.ToString());
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    
    public int Update(CheckedInPatients objCheckedInPatients, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager();
            
            objDBManager.AddParameter("CheckedInPatientsId", objCheckedInPatients.CheckedInPatientsId, SqlDbType.BigInt, 8);

            objDBManager.AddParameter("PracticeId", objCheckedInPatients.PracticeId);
            objDBManager.AddParameter("PracticeLocationsId", objCheckedInPatients.PracticeLocationsId);

            objDBManager.AddParameter("AppointmentsId", objCheckedInPatients.AppointmentsId);
            objDBManager.AddParameter("PatientId", objCheckedInPatients.PatientId);
            objDBManager.AddParameter("AppointmentDate", objCheckedInPatients.AppointmentDate);
            objDBManager.AddParameter("ArrivalTime", objCheckedInPatients.ArrivalTime);
            objDBManager.AddParameter("RoomId", objCheckedInPatients.RoomId);
            objDBManager.AddParameter("TimeInRoom", objCheckedInPatients.TimeInRoom);
            objDBManager.AddParameter("CheckInTime", objCheckedInPatients.CheckInTime);
            objDBManager.AddParameter("TimeInOffice", objCheckedInPatients.TimeInOffice);
            
            objDBManager.AddParameter("ModifiedById", objCheckedInPatients.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objCheckedInPatients.ModifiedDate);
            
            return objDBManager.ExecuteNonQuery("CheckedInPatients_Update");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    
    public int Delete(CheckedInPatients objCheckedInPatients, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);
            
            objDBManager.AddParameter("CheckedInPatientsId", objCheckedInPatients.CheckedInPatientsId);
            
            objDBManager.AddParameter("ModifiedById", objCheckedInPatients.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objCheckedInPatients.ModifiedDate);
            
            return objDBManager.ExecuteNonQuery("CheckedInPatients_Delete");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    
    public int UpdateHistory(CheckedInPatients objCheckedInPatients, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);
            
            objDBManager.AddParameter("CheckedInPatientsId", objCheckedInPatients.CheckedInPatientsId);
            
            objDBManager.AddParameter("TimeInRoom", objCheckedInPatients.TimeInRoom);
            
            objDBManager.AddParameter("ModifiedById", objCheckedInPatients.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objCheckedInPatients.ModifiedDate);
            
            return objDBManager.ExecuteNonQuery("CheckedInPatients_UpdateHistory");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int DeleteByAppointment(CheckedInPatients objCheckedInPatients, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);
            
            objDBManager.AddParameter("AppointmentsId", objCheckedInPatients.AppointmentsId);
            
            objDBManager.AddParameter("ModifiedById", objCheckedInPatients.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objCheckedInPatients.ModifiedDate);
            
            return objDBManager.ExecuteNonQuery("CheckedInPatients_DeleteByAppointment");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    
    public DataTable GetByID(long CheckedInPatientsId, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);
            
            objDBManager.AddParameter("CheckedInPatientsId", CheckedInPatientsId);
            
            return objDBManager.ExecuteDataTable("CheckedInPatients_GetByID");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable GetByAppointmentsID(long AppointmentsId, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);

            objDBManager.AddParameter("AppointmentsId", AppointmentsId);

            return objDBManager.ExecuteDataTable("CheckedInPatients_GetByAppointmentsID");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet GetAllByDate(long PracticeId, long PracticeLocationsId, DateTime AppointmentDate, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);

            objDBManager.AddParameter("PracticeId", PracticeId);

            if (PracticeLocationsId != 0)
            {
                objDBManager.AddParameter("PracticeLocationsId", PracticeLocationsId);
            }
            
            objDBManager.AddParameter("AppointmentDate", AppointmentDate);
            
            DataSet dsCheckedInPatientsInfo = objDBManager.ExecuteDataSet("CheckedInPatients_GetAllByDate");

            //dsCheckedInPatientsInfo.Relations.Add("RelationLocationRooms", dsCheckedInPatientsInfo.Tables[0].Columns["PracticeLocationsId"], dsCheckedInPatientsInfo.Tables[1].Columns["PracticeLocationsId"]);
            
            return dsCheckedInPatientsInfo;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    
    public DataSet GetAllFilter(int Rows, int PageNumber, string SortBy)
    {
        try
        {
            DBManager objDBManager = new DBManager();

            objDBManager.AddParameter("Rows", Rows);
            objDBManager.AddParameter("PageNumber", PageNumber);

            if (!string.IsNullOrEmpty(SortBy))
            {
                objDBManager.AddParameter("SortBy", SortBy);
            }

            return objDBManager.ExecuteDataSet("CheckedInPatients_GetAllFilter");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet GetInfoForCheckInForm(long PatientId, long PracticeLocationsId)
    {
        try
        {
            DBManager objDBManager = new DBManager();

            objDBManager.AddParameter("PatientId", PatientId);
            objDBManager.AddParameter("PracticeLocationsId", PracticeLocationsId);

            return objDBManager.ExecuteDataSet("CheckedInPatients_GetInfoForCheckInForm");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}