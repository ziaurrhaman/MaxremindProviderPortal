using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for ProviderTaskSettingsDB
/// </summary>
public class ProviderTaskSettingsDB
{
	public ProviderTaskSettingsDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public long Add(ProviderTaskSettings objProviderTaskSettings, SqlTransaction objSqlTransaction = null)
    {

        DBManager objDBManager = new DBManager(objSqlTransaction);


        try
        {
            objDBManager.AddParameter("ProviderTaskSettingsId", objProviderTaskSettings.ProviderTaskSettingsId, SqlDbType.BigInt, 4, ParameterDirection.Output);
            objDBManager.AddParameter("TaskTypeId", objProviderTaskSettings.TaskTypeId, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("ServiceProviderId", objProviderTaskSettings.ServiceProviderId, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("ProviderSkillLevel", objProviderTaskSettings.ProviderSkillLevel, SqlDbType.VarChar, 20);
            objDBManager.AddParameter("CreatedById", objProviderTaskSettings.CreatedById, SqlDbType.Int, 4);
            objDBManager.AddParameter("CreatedDate", objProviderTaskSettings.CreatedDate, SqlDbType.DateTime, 8);
            objDBManager.AddParameter("ModifiedById", objProviderTaskSettings.ModifiedById, SqlDbType.Int, 4);
            objDBManager.AddParameter("ModifiedDate", objProviderTaskSettings.ModifiedDate, SqlDbType.DateTime, 8);
            objDBManager.AddParameter("Deleted", objProviderTaskSettings.Deleted, SqlDbType.Bit, 1);

            objDBManager.ExecuteNonQuery("ProviderTaskSettings_Add");

            objProviderTaskSettings.ProviderTaskSettingsId = long.Parse(objDBManager.Parameters[0].Value.ToString());

        }
        catch (Exception ex)
        {

            throw ex;

        }

        return objProviderTaskSettings.ProviderTaskSettingsId;

    }

    public int Update(ProviderTaskSettings objProviderTaskSettings, SqlTransaction objSqlTransaction = null)
    {

        DBManager objDBManager = new DBManager(objSqlTransaction);
        int ReturnValue = 0;

        try
        {

            objDBManager.AddParameter("ID", objProviderTaskSettings.ProviderTaskSettingsId, SqlDbType.Int, 4);

            objDBManager.AddParameter("TaskId", objProviderTaskSettings.TaskId, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("ServiceProviderId", objProviderTaskSettings.ServiceProviderId, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("ProviderSkillLevel", objProviderTaskSettings.ProviderSkillLevel, SqlDbType.VarChar, 20);
            objDBManager.AddParameter("CreatedById", objProviderTaskSettings.CreatedById, SqlDbType.Int, 4);
            objDBManager.AddParameter("CreatedDate", objProviderTaskSettings.CreatedDate, SqlDbType.DateTime, 8);
            objDBManager.AddParameter("ModifiedById", objProviderTaskSettings.ModifiedById, SqlDbType.Int, 4);
            objDBManager.AddParameter("ModifiedDate", objProviderTaskSettings.ModifiedDate, SqlDbType.DateTime, 8);
            objDBManager.AddParameter("Deleted", objProviderTaskSettings.Deleted, SqlDbType.Bit, 1);

            ReturnValue = objDBManager.ExecuteNonQuery("ProviderTaskSettings_Update");


        }
        catch (Exception ex)
        {
            throw ex;

        }

        return ReturnValue;

    }

    public DataSet GetSettingsByTaskTypeId(long TaskTypeId)
    {
        DBManager objDBManager = new DBManager();

        objDBManager.AddParameter("@TaskTypeId", TaskTypeId);
        return objDBManager.ExecuteDataSet("ProviderTaskSetting_GetSettingsByTaskTypeId");
    }

    public int DeleteByTaskType(long TaskTypeId)
    {

        DBManager objDBManager = new DBManager();

        objDBManager.AddParameter("@TaskTypeId", TaskTypeId);
        return objDBManager.ExecuteNonQuery("ProviderTaskSettings_DeleteByTaskType");

    }

    public DataSet GetServiceProviderByPracticeId(long PracticeId)
    {
        DBManager objDBManager = new DBManager();

        objDBManager.AddParameter("@PracticeId", PracticeId);
        return objDBManager.ExecuteDataSet("ProviderTaskSetting_GetByTaskType");
    }
}