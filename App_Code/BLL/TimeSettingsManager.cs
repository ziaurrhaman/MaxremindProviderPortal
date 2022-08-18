using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for TimeSettingsManager
/// </summary>
public class TimeSettingsManager
{
	public TimeSettingsManager()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public long Add(TimeSettings objTimeSettings, SqlTransaction objSqlTransaction = null)
    {

        TimeSettingsDB objTimeSettingsDB = new TimeSettingsDB();
        return objTimeSettingsDB.Add(objTimeSettings, objSqlTransaction);

    }

    public int Update(TimeSettings objTimeSettings, SqlTransaction objSqlTransaction = null)
    {

        TimeSettingsDB objTimeSettingsDB = new TimeSettingsDB();
        return objTimeSettingsDB.Update(objTimeSettings, objSqlTransaction);

    }

    public DataSet GetProviderTimings(int ServiceProviderId, string NameOfDay)
    {
        TimeSettingsDB objTimeSettingsDB = new TimeSettingsDB();
        return objTimeSettingsDB.GetProviderTimings(ServiceProviderId, NameOfDay);
    }

    public DataSet GetProviderDetailTimings(int ServiceProviderId)
    {
        TimeSettingsDB objTimeSettingsDB = new TimeSettingsDB();
        return objTimeSettingsDB.GetProviderDetailTimings(ServiceProviderId);
    }

    public DataTable GetNamesOfDayByResource(int ResourceId)
    {
        TimeSettingsDB objTimeSettingsDB = new TimeSettingsDB();
        return objTimeSettingsDB.GetNamesOfDayByResource(ResourceId);
    }

    public int Delete(string ResourceType, int ResourceId, string NameOfDay)
    {
        TimeSettingsDB objTimeSettingsDB = new TimeSettingsDB();
        return objTimeSettingsDB.Delete(ResourceType, ResourceId, NameOfDay);
    }



}