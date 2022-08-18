using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for CheckInRoomDB
/// </summary>
public class CheckInRoomDB
{
	public CheckInRoomDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    
    public int Add(CheckInRooms objCheckInRooms)
    {
        DBManager objDBManager = new DBManager();
        try
        {
            objDBManager.AddParameter("RoomId", objCheckInRooms.RoomId, SqlDbType.Int, 4, ParameterDirection.Output);
            objDBManager.AddParameter("RoomNo", objCheckInRooms.RoomNo);
            objDBManager.AddParameter("Name", objCheckInRooms.Name);
            objDBManager.AddParameter("RoomTypeId", objCheckInRooms.RoomTypeId);
            objDBManager.AddParameter("PracticeId", objCheckInRooms.PracticeId);
            objDBManager.AddParameter("PracticeLocationsId", objCheckInRooms.PracticeLocationsId);
            objDBManager.AddParameter("CreatedById", objCheckInRooms.CreatedById);
            objDBManager.AddParameter("CreatedDate", objCheckInRooms.CreatedDate);
            objDBManager.ExecuteNonQuery("CheckInRooms_Add");
            objCheckInRooms.RoomId = int.Parse(objDBManager.Parameters[0].Value.ToString());
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return objCheckInRooms.RoomId;
    }
    
    public void Update(CheckInRooms objCheckInRooms)
    {
        DBManager objDBManager = new DBManager();
        try
        {
            objDBManager.AddParameter("RoomId", objCheckInRooms.RoomId);
            objDBManager.AddParameter("RoomNo", objCheckInRooms.RoomNo);
            objDBManager.AddParameter("Name", objCheckInRooms.Name);
            objDBManager.AddParameter("RoomTypeId", objCheckInRooms.RoomTypeId);
            objDBManager.AddParameter("PracticeId", objCheckInRooms.PracticeId);
            objDBManager.AddParameter("PracticeLocationsId", objCheckInRooms.PracticeLocationsId);
            objDBManager.AddParameter("ModifiedById", objCheckInRooms.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objCheckInRooms.ModifiedDate);
            objDBManager.ExecuteNonQuery("CheckInRooms_Update");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    
    public DataSet GetAllFilter(string Name, string RoomNo, int RoomTypeId, long PracticeId, long PracticeLocationsId, int Rows, int PageNumber, string SortBy, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);
            
            if (PracticeId != 0)
            {
                objDBManager.AddParameter("PracticeId", PracticeId);
            }
            
            if (PracticeLocationsId != 0)
            {
                objDBManager.AddParameter("PracticeLocationsId", PracticeLocationsId);
            }
            
            objDBManager.AddParameter("Rows", Rows);
            objDBManager.AddParameter("PageNumber", PageNumber);
            objDBManager.AddParameter("SortBy", SortBy);
            
            if (!string.IsNullOrEmpty(Name))
            {
                objDBManager.AddParameter("Name", Name);
            }
            
            if (!string.IsNullOrEmpty(RoomNo))
            {
                objDBManager.AddParameter("RoomNo", RoomNo);
            }

            if (RoomTypeId != 0)
            {
                objDBManager.AddParameter("RoomTypeId", RoomTypeId);
            }

            return objDBManager.ExecuteDataSet("CheckInRooms_GetAllFilter");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable RoomType_GetAll(long PracticeId, long PracticeLocationsId)
    {
        try
        {
            DBManager objDBManager = new DBManager();

            objDBManager.AddParameter("PracticeId", PracticeId);

            if (PracticeLocationsId != 0)
            {
                objDBManager.AddParameter("PracticeLocationsId", PracticeLocationsId);
            }

            return objDBManager.ExecuteDataTable("RoomType_GetAll");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    
    public DataTable CheckRoomNoExist(CheckInRooms objCheckInRooms)
    {
        try
        {
            DBManager objDBManager = new DBManager();
            
            objDBManager.AddParameter("PracticeId", objCheckInRooms.PracticeId);
            objDBManager.AddParameter("PracticeLocationsId", objCheckInRooms.PracticeLocationsId);
            
            objDBManager.AddParameter("RoomId", objCheckInRooms.RoomId);
            objDBManager.AddParameter("RoomNo", objCheckInRooms.RoomNo);
            
            return objDBManager.ExecuteDataTable("CheckInRooms_CheckRoomNoExist");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    
    public int Delete(CheckInRooms objCheckInRooms)
    {
        try
        {
            DBManager objDBManager = new DBManager();
            objDBManager.AddParameter("RoomId", objCheckInRooms.RoomId);
            objDBManager.AddParameter("ModifiedById", objCheckInRooms.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objCheckInRooms.ModifiedDate);
            return objDBManager.ExecuteNonQuery("CheckInRooms_DeleteRoom");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    
    public DataTable GetRoomsByPracticeLocations(long PracticeLocationsId)
    {
        try
        {
            DBManager objDBManager = new DBManager();

            objDBManager.AddParameter("PracticeLocationsId", PracticeLocationsId);

            return objDBManager.ExecuteDataTable("CheckInRooms_GetRoomsByPracticeLocations");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet GetRoomsWaitingTime(int rows, int pageno, long PracticeId)
    {
        try
        {
            DBManager objDBManager = new DBManager();

            objDBManager.AddParameter("Rows", rows);
            objDBManager.AddParameter("PageNumber", pageno);
            objDBManager.AddParameter("PracticeId", PracticeId);

            return objDBManager.ExecuteDataSet("RoomWaitingTimeSummary");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


}