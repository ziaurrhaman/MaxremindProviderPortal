using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for ProviderAppointmentTypesDB
/// </summary>
public class ProviderAppointmentTypesDB
{
	public ProviderAppointmentTypesDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public int Add(ProviderAppointmentTypes objProviderAppointmentTypes, SqlTransaction objSqlTransaction = null)
    {
        DBManager objDBManager = new DBManager(objSqlTransaction);
        try
        {
            objDBManager.AddParameter("ProviderAppointmentTypeId", objProviderAppointmentTypes.ProviderAppointmentTypeId, SqlDbType.Int, 4, ParameterDirection.Output);
            objDBManager.AddParameter("ServiceProviderId",objProviderAppointmentTypes.ServiceProviderId);
            objDBManager.AddParameter("AppointmentTypeId",objProviderAppointmentTypes.AppointmentTypeId);
            objDBManager.AddParameter("CreatedById",objProviderAppointmentTypes.CreatedById);
            objDBManager.AddParameter("CreatedDate",objProviderAppointmentTypes.CreatedDate);
            objDBManager.ExecuteNonQuery("ProviderAppointmentTypes_Add");
            objProviderAppointmentTypes.ProviderAppointmentTypeId = int.Parse(objDBManager.Parameters[0].Value.ToString());
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return objProviderAppointmentTypes.ProviderAppointmentTypeId;
    }

    public int Update(ProviderAppointmentTypes objProviderAppointmentTypes, SqlTransaction objSqlTransaction = null)
    {
        DBManager objDBManager = new DBManager(objSqlTransaction);
        int ReturnValue = 0;
        try
        {
            objDBManager.AddParameter("ProviderAppointmentTypeId", objProviderAppointmentTypes.ProviderAppointmentTypeId, SqlDbType.Int, 4);
            objDBManager.AddParameter("ServiceProviderId",objProviderAppointmentTypes.ServiceProviderId);
            objDBManager.AddParameter("AppointmentTypeId",objProviderAppointmentTypes.AppointmentTypeId);
            objDBManager.AddParameter("ModifiedById",objProviderAppointmentTypes.ModifiedById);
            objDBManager.AddParameter("ModifiedDate",objProviderAppointmentTypes.ModifiedDate);
            ReturnValue = objDBManager.ExecuteNonQuery("ProviderAppointmentTypes_Update");
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ReturnValue;
    }

    public int Delete(int ProviderAppointmentTypeId, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);
            objDBManager.AddParameter("ProviderAppointmentTypeId", ProviderAppointmentTypeId);
            return objDBManager.ExecuteNonQuery("ProviderAppointmentTypes_Delete");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public int DeleteByProviderId(int ServiceProviderId, long ModifiedById, DateTime ModifiedDate, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);
            objDBManager.AddParameter("ServiceProviderId", ServiceProviderId);
            objDBManager.AddParameter("ModifiedById", ModifiedById);
            objDBManager.AddParameter("ModifiedDate", ModifiedDate);
            return objDBManager.ExecuteNonQuery("ProviderAppointmentTypes_DeleteByProviderId");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetByProviderID(int ServiceProviderId, SqlTransaction objSqlTransaction = null)
    {
        DBManager objDBManager = new DBManager(objSqlTransaction);
        objDBManager.AddParameter("ServiceProviderId", ServiceProviderId);
        return objDBManager.ExecuteDataTable("ProviderAppointmentTypes_GetByProviderID");
    }

    public int UpdateProviderTypeDefaultTime(ProviderAppointmentTypes objProviderAppointmentTypes, SqlTransaction objSqlTransaction = null)
    {
        DBManager objDBManager = new DBManager(objSqlTransaction);
        int ReturnValue = 0;
        try
        {
            objDBManager.AddParameter("ServiceProviderId", objProviderAppointmentTypes.ServiceProviderId);
            objDBManager.AddParameter("AppointmentTypeId", objProviderAppointmentTypes.AppointmentTypeId);
            objDBManager.AddParameter("DefaultTime", objProviderAppointmentTypes.DefaultTime);
            objDBManager.AddParameter("ModifiedById", objProviderAppointmentTypes.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objProviderAppointmentTypes.ModifiedDate);
            ReturnValue = objDBManager.ExecuteNonQuery("ProviderAppointmentTypes_UpdateProviderTypeDefaultTime");
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ReturnValue;
    }
}