using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for ProviderTaskSettingManager
/// </summary>
public class ProviderTaskSettingManager
{
	public ProviderTaskSettingManager()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public long Add(ProviderTaskSettings objProviderTaskSettings, SqlTransaction objSqlTransaction = null)
    {

        ProviderTaskSettingsDB objProviderTaskSettingsDB = new ProviderTaskSettingsDB();

        return objProviderTaskSettingsDB.Add(objProviderTaskSettings, objSqlTransaction);

    }

    public int Update(ProviderTaskSettings objProviderTaskSettings, SqlTransaction objSqlTransaction = null)
    {

        ProviderTaskSettingsDB objProviderTaskSettingsDB = new ProviderTaskSettingsDB();
        return objProviderTaskSettingsDB.Update(objProviderTaskSettings, objSqlTransaction);

    }

    public DataSet GetSettingsByTaskTypeId(long TaskTypeId)
    {
        ProviderTaskSettingsDB objProviderTaskSettingsDB = new ProviderTaskSettingsDB();
        return objProviderTaskSettingsDB.GetSettingsByTaskTypeId(TaskTypeId);
    }

    public int DeleteByTaskType(long TaskTypeId)
    {
        ProviderTaskSettingsDB objProviderTaskSettingsDB = new ProviderTaskSettingsDB();
        return objProviderTaskSettingsDB.DeleteByTaskType(TaskTypeId);
    }


    public DataSet GetServiceProviderByPracticeId(long PracticeId)
    {
        ProviderTaskSettingsDB objProviderTaskSettingsDB = new ProviderTaskSettingsDB();
        return objProviderTaskSettingsDB.GetServiceProviderByPracticeId(PracticeId);
    }
}