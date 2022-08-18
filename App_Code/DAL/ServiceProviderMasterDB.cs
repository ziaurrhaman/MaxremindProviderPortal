using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
/// <summary>
/// Summary description for ServiceProviderMasterDB
/// </summary>
public class ServiceProviderMasterDB
{
	public ServiceProviderMasterDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    #region "Auto-Generated Methods"
    public DataTable GetAllServiceProvidersMaster()
    {
        try
        {
            DBManager objDBManager = new DBManager();
            return objDBManager.ExecuteDataTable("GetAllServiceProvidersMaster");
        }
        catch (Exception ex)
        {
            throw ex;

        }
    }
    public int Add(ServiceProviderMaster objServiceProviderMaster, SqlTransaction objSqlTransaction = null)
    {
        DBManager objDBManager = new DBManager(objSqlTransaction);
        try
        {
            objDBManager.AddParameter("ServiceProviderTypeId", objServiceProviderMaster.ServiceProviderTypeId);
            objDBManager.AddParameter("ProviderType", objServiceProviderMaster.ProviderType);
            objDBManager.AddParameter("CreatedById", objServiceProviderMaster.CreatedById);
            objDBManager.AddParameter("CreatedByDate", objServiceProviderMaster.CreatedByDate);
            objDBManager.AddParameter("ModifiedById", objServiceProviderMaster.ModifiedById);
            objDBManager.AddParameter("ModifiedByDate", objServiceProviderMaster.ModifiedByDate);

            objDBManager.ExecuteNonQuery("");

            objServiceProviderMaster.ServiceProviderTypeId = int.Parse(objDBManager.Parameters[0].Value.ToString());

        }
        catch (Exception ex)
        {
            throw ex;
        }

        return objServiceProviderMaster.ServiceProviderTypeId;
    }

    public int Update(ServiceProviderMaster objServiceProviderMaster, SqlTransaction objSqlTransaction = null)
    {
        DBManager objDBManager = new DBManager(objSqlTransaction);
        int ReturnValue = 0;

        try
        {

            objDBManager.AddParameter("ServiceProviderTypeId", objServiceProviderMaster.ServiceProviderTypeId);
            objDBManager.AddParameter("ProviderType", objServiceProviderMaster.ProviderType);
            objDBManager.AddParameter("CreatedById", objServiceProviderMaster.CreatedById);
            objDBManager.AddParameter("CreatedByDate", objServiceProviderMaster.CreatedByDate);
            objDBManager.AddParameter("ModifiedById", objServiceProviderMaster.ModifiedById);
            objDBManager.AddParameter("ModifiedByDate", objServiceProviderMaster.ModifiedByDate);

            ReturnValue = objDBManager.ExecuteNonQuery("");
        }
        catch (Exception ex)
        {
            throw ex;

        }

        return ReturnValue;

    }   
    
    #endregion   
}