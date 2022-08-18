using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for TimeSettingsDB
/// </summary>
public class TimeSettingsDB
{
    public TimeSettingsDB()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    
    public long Add(TimeSettings objTimeSettings, SqlTransaction objSqlTransaction = null)
    {
        DBManager objDBManager = new DBManager(objSqlTransaction);
        
        try
        {
            objDBManager.AddParameter("TimeSettingsId", objTimeSettings.TimeSettingsId, SqlDbType.Int, 4, ParameterDirection.Output);
            objDBManager.AddParameter("NameOfDay", objTimeSettings.NameOfDay);
            objDBManager.AddParameter("DayNumber", objTimeSettings.DayNumber);
            objDBManager.AddParameter("ResourceId", objTimeSettings.ResourceId);
            
            if (!string.IsNullOrEmpty(objTimeSettings.TimeFrom.ToString()))
            {
                objDBManager.AddParameter("TimeFrom", objTimeSettings.TimeFrom);
            }
            
            if (!string.IsNullOrEmpty(objTimeSettings.TimeTo.ToString()))
            {
                objDBManager.AddParameter("TimeTo", objTimeSettings.TimeTo);
            }
            
            if (!string.IsNullOrEmpty(objTimeSettings.BreakStart.ToString()))
            {
                objDBManager.AddParameter("BreakStart", objTimeSettings.BreakStart);
            }
            
            if (!string.IsNullOrEmpty(objTimeSettings.BreakEnd.ToString()))
            {
                objDBManager.AddParameter("BreakEnd", objTimeSettings.BreakEnd);
            }
            
            objDBManager.AddParameter("ResourceType", objTimeSettings.ResourceType);
            objDBManager.AddParameter("BreakTypeId", objTimeSettings.BreakTypeId);
            objDBManager.AddParameter("SettingType", objTimeSettings.SettingType);
            objDBManager.AddParameter("TimingStartDate", objTimeSettings.TimingStartDate);
            objDBManager.AddParameter("TimingExpireDate", objTimeSettings.TimingExpireDate);
            
            objDBManager.AddParameter("CreatedById", objTimeSettings.CreatedById);
            objDBManager.AddParameter("CreatedDate", objTimeSettings.CreatedDate);
            
            objDBManager.ExecuteNonQuery("TimeSettings_Add");
            
            objTimeSettings.TimeSettingsId = long.Parse(objDBManager.Parameters[0].Value.ToString());
        }
        catch (Exception ex)
        {
            throw ex;
        }
        
        return objTimeSettings.TimeSettingsId;
    }
    
    public int Update(TimeSettings objTimeSettings, SqlTransaction objSqlTransaction = null)
    {
        DBManager objDBManager = new DBManager(objSqlTransaction);
        int ReturnValue = 0;
        
        try
        {
            objDBManager.AddParameter("TimeSettingsId", objTimeSettings.TimeSettingsId, SqlDbType.Int, 4);
            
            objDBManager.AddParameter("NameOfDay", objTimeSettings.NameOfDay);
            objDBManager.AddParameter("DayNumber", objTimeSettings.DayNumber);
            objDBManager.AddParameter("ResourceId", objTimeSettings.ResourceId);
            objDBManager.AddParameter("TimeFrom", objTimeSettings.TimeFrom);
            objDBManager.AddParameter("TimeTo", objTimeSettings.TimeTo);
            objDBManager.AddParameter("ResourceType", objTimeSettings.ResourceType);
            objDBManager.AddParameter("BreakTypeId", objTimeSettings.BreakTypeId);
            objDBManager.AddParameter("SettingType", objTimeSettings.SettingType);
            objDBManager.AddParameter("TimingStartDate", objTimeSettings.TimingStartDate);
            objDBManager.AddParameter("TimingExpireDate", objTimeSettings.TimingExpireDate);
            
            objDBManager.AddParameter("ModifiedById", objTimeSettings.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objTimeSettings.ModifiedDate);
            
            ReturnValue = objDBManager.ExecuteNonQuery("TimeSettings_Update");
        }
        catch (Exception ex)
        {
            throw ex;
        }
        
        return ReturnValue;
    }
    
    public int UpdateProviderTimeSetting(TimeSettings objTimeSettings, SqlTransaction objSqlTransaction = null)
    {
        DBManager objDBManager = new DBManager(objSqlTransaction);
        int ReturnValue = 0;
        
        try
        {
            objDBManager.AddParameter("TimeSettingsId", objTimeSettings.TimeSettingsId);
            objDBManager.AddParameter("BreakTypeId", objTimeSettings.BreakTypeId);

            if (!string.IsNullOrEmpty(objTimeSettings.TimeFrom.ToString()))
            {
                objDBManager.AddParameter("TimeFrom", objTimeSettings.TimeFrom);
            }

            if (!string.IsNullOrEmpty(objTimeSettings.TimeTo.ToString()))
            {
                objDBManager.AddParameter("TimeTo", objTimeSettings.TimeTo);
            }

            if (!string.IsNullOrEmpty(objTimeSettings.BreakStart.ToString()))
            {
                objDBManager.AddParameter("BreakStart", objTimeSettings.BreakStart);
            }

            if (!string.IsNullOrEmpty(objTimeSettings.BreakEnd.ToString()))
            {
                objDBManager.AddParameter("BreakEnd", objTimeSettings.BreakEnd);
            }

            objDBManager.AddParameter("TimingStartDate", objTimeSettings.TimingStartDate);
            objDBManager.AddParameter("TimingExpireDate", objTimeSettings.TimingExpireDate);

            objDBManager.AddParameter("ModifiedById", objTimeSettings.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objTimeSettings.ModifiedDate);

            ReturnValue = objDBManager.ExecuteNonQuery("TimeSettings_UpdateProviderTimeSetting");
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return ReturnValue;
    }

    public DataSet GetProviderTimings(int ServiceProviderId, string NameOfDay)
    {
        DBManager objDBManager = new DBManager();

        objDBManager.AddParameter("ServiceProviderId", ServiceProviderId);
        objDBManager.AddParameter("NameOfDay", NameOfDay);

        return objDBManager.ExecuteDataSet("TimeSettings_GetProviderTimings");
    }

    public DataSet GetProviderDetailTimings(int ServiceProviderId)
    {
        DBManager objDBManager = new DBManager();

        objDBManager.AddParameter("ServiceProviderId", ServiceProviderId);

        return objDBManager.ExecuteDataSet("TimeSettings_GetProviderDetailTimings");
    }

    public DataSet GetTimingsByResourceId(long ResourceId)
    {
        DBManager objDBManager = new DBManager();

        objDBManager.AddParameter("ResourceId", ResourceId);

        return objDBManager.ExecuteDataSet("TimeSettings_GetTimingsByResourceId");
    }

    public DataTable GetNamesOfDayByResource(int ResourceId)
    {
        DBManager objDBManager = new DBManager();

        objDBManager.AddParameter("ResourceId", ResourceId);

        return objDBManager.ExecuteDataTable("TimeSettings_GetDaysByResource");
    }

    public int Delete(string ResourceType, int ResourceId, string NameOfDay)
    {
        DBManager objDBManager = new DBManager();

        objDBManager.AddParameter("ResourceType", ResourceType);
        objDBManager.AddParameter("ResourceId", ResourceId);
        objDBManager.AddParameter("NameOfDay", NameOfDay);

        return objDBManager.ExecuteNonQuery("TimeSettings_Delete");
    }

    public DataTable GetProvidersAllTimings(long providerId)
    {
        DBManager objDBManager = new DBManager();

        objDBManager.AddParameter("ProviderId", providerId);

        return objDBManager.ExecuteDataTable("GetProvidersAllTimings");
    }

    public DataTable GetBreakHours(int DayNumber, string ResourceType, int ResourceId, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);

            objDBManager.AddParameter("DayNumber", DayNumber);
            objDBManager.AddParameter("ResourceType", ResourceType);

            if (ResourceId != 0)
            {
                objDBManager.AddParameter("ResourceId", ResourceId);
            }

            return objDBManager.ExecuteDataTable("TimeSettings_GetBreakHours");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable GetTimingsByProvider(int DayNumber, string ResourceType, int ResourceId, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);

            objDBManager.AddParameter("DayNumber", DayNumber);
            objDBManager.AddParameter("ResourceType", ResourceType);
            objDBManager.AddParameter("ResourceId", ResourceId);

            return objDBManager.ExecuteDataTable("TimeSettings_GetTimingsByProvider");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable GetTimingsByProviders(int DayNumber, string ResourceType, string ResourceIds, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);

            objDBManager.AddParameter("DayNumber", DayNumber);
            objDBManager.AddParameter("ResourceType", ResourceType);
            objDBManager.AddParameter("ResourceIds", ResourceIds);

            return objDBManager.ExecuteDataTable("TimeSettings_GetTimingsByProviders");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}