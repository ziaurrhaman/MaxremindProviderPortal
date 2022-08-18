using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for AppointmentTypesDB
/// </summary>
public class AppointmentTypesDB
{
	public AppointmentTypesDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public int Add(AppointmentTypes objAppointmentTypes, SqlTransaction objSqlTransaction = null)
    {
        DBManager objDBManager = new DBManager(objSqlTransaction);
        try
        {
            objDBManager.AddParameter("AppointmentTypeId", objAppointmentTypes.AppointmentTypeId, SqlDbType.Int, 4, ParameterDirection.Output);
            objDBManager.AddParameter("PracticeId", objAppointmentTypes.PracticeId);
            objDBManager.AddParameter("AppointmentType", objAppointmentTypes.AppointmentType );
            objDBManager.AddParameter("DefaultTime", objAppointmentTypes.DefaultTime );
            objDBManager.AddParameter("CreatedById", objAppointmentTypes.CreatedById );
            objDBManager.AddParameter("CreatedDate", objAppointmentTypes.CreatedDate );
            objDBManager.ExecuteNonQuery("AppointmentTypes_Add");
            objAppointmentTypes.AppointmentTypeId = int.Parse(objDBManager.Parameters[0].Value.ToString());
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return objAppointmentTypes.AppointmentTypeId;
    }

    public int Update(AppointmentTypes objAppointmentTypes, SqlTransaction objSqlTransaction = null)
    {
        DBManager objDBManager = new DBManager(objSqlTransaction);
        int ReturnValue = 0;
        try
        {
            objDBManager.AddParameter("AppointmentTypeId", objAppointmentTypes.AppointmentTypeId, SqlDbType.Int, 4);
            objDBManager.AddParameter("PracticeId", objAppointmentTypes.PracticeId);
            objDBManager.AddParameter("AppointmentType", objAppointmentTypes.AppointmentType );
            objDBManager.AddParameter("DefaultTime", objAppointmentTypes.DefaultTime );
            objDBManager.AddParameter("ModifiedById", objAppointmentTypes.ModifiedById );
            objDBManager.AddParameter("ModifiedDate", objAppointmentTypes.ModifiedDate );
            ReturnValue = objDBManager.ExecuteNonQuery("AppointmentTypes_Update");
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ReturnValue;
    }

    public int Delete(int AppointmentTypeId, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);
            objDBManager.AddParameter("AppointmentTypeId", AppointmentTypeId, SqlDbType.Int, 4);
            return objDBManager.ExecuteNonQuery("AppointmentTypes_Delete");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataSet GetBySerachFilter(string AppointmentType, string DefaultTime, long PracticeId, int Rows, int PageNumber, string SortBy, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);
            objDBManager.AddParameter("Rows", Rows);
            objDBManager.AddParameter("PageNumber", PageNumber);
            objDBManager.AddParameter("SortBy", SortBy);
            objDBManager.AddParameter("@PracticeId", PracticeId);
            if (!string.IsNullOrEmpty(AppointmentType))
            {
                objDBManager.AddParameter("@AppointmentType", AppointmentType);
            }
            if (!string.IsNullOrEmpty(DefaultTime))
            {
                objDBManager.AddParameter("@DefaultTime", DefaultTime);
            }
            return objDBManager.ExecuteDataSet("AppointmentTypes_GetBySerachFilter");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable GetAllTypes(long PracticeId, int ServiceProviderId, SqlTransaction objSqlTransaction = null)
    {
        DBManager objDBManager = new DBManager(objSqlTransaction);
        objDBManager.AddParameter("PracticeId", PracticeId);
        if (ServiceProviderId != 0)
        {
            objDBManager.AddParameter("ServiceProviderId", ServiceProviderId);
        }
        return objDBManager.ExecuteDataTable("AppointmentTypes_GetAllTypes");
    }
    public DataTable GetAll(long PracticeId, SqlTransaction objSqlTransaction = null)
    {
        DBManager objDBManager = new DBManager(objSqlTransaction);
        objDBManager.AddParameter("PracticeId", PracticeId);
        return objDBManager.ExecuteDataTable("AppointmentTypes_GetAll");
    }

    public DataTable GetTypesByProviderID(long PracticeId, int ServiceProviderId, SqlTransaction objSqlTransaction = null)
    {
        DBManager objDBManager = new DBManager(objSqlTransaction);
        objDBManager.AddParameter("PracticeId", PracticeId);
        objDBManager.AddParameter("ServiceProviderId", ServiceProviderId);
        return objDBManager.ExecuteDataTable("AppointmentTypes_GetTypesByProviderID");
    }
}