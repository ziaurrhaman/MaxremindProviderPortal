using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

/// <summary>
/// Summary description for OrganDetailsValuesDB
/// </summary>
public class OrganDetailsValuesDB
{
	public OrganDetailsValuesDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    
    public Int64 Add(OrganDetailsValues objOrganDetailsValues)
    {
        DBManager objDBManager = new DBManager();
        try
        {
            objDBManager.AddParameter("OrganValueId", objOrganDetailsValues.OrganValueId, SqlDbType.BigInt, 8, ParameterDirection.Output);
            objDBManager.AddParameter("OrgansDetailsId", objOrganDetailsValues.OrgansDetailsId);
            objDBManager.AddParameter("Value", objOrganDetailsValues.Value);
            objDBManager.AddParameter("CreatedById", objOrganDetailsValues.CreatedById);
            objDBManager.AddParameter("CreatedDate", objOrganDetailsValues.CreatedDate);            
            objDBManager.ExecuteNonQuery("OrganDetailsValues_Add");
            
            objOrganDetailsValues.OrganValueId = long.Parse(objDBManager.Parameters[0].Value.ToString());
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return objOrganDetailsValues.OrganValueId;
    }
    
    public void Update(OrganDetailsValues objOrganDetailsValues)
    {
        DBManager objDBManager = new DBManager();        
        try
        {
            objDBManager.AddParameter("OrganValueId", objOrganDetailsValues.OrganValueId);
            objDBManager.AddParameter("OrgansDetailsId", objOrganDetailsValues.OrgansDetailsId);
            objDBManager.AddParameter("Value", objOrganDetailsValues.Value);            
            objDBManager.AddParameter("ModifiedById", objOrganDetailsValues.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objOrganDetailsValues.ModifiedDate);
            objDBManager.ExecuteNonQuery("OrganDetailsValues_Update");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    
    public int Delete(OrganDetailsValues objOrganDetailsValues, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);
            objDBManager.AddParameter("OrganValueId", objOrganDetailsValues.OrganValueId);
            objDBManager.AddParameter("ModifiedById", objOrganDetailsValues.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objOrganDetailsValues.ModifiedDate);
            return objDBManager.ExecuteNonQuery("OrganDetailsValues_Delete");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    
    public DataTable GetByOrganDetails(long OrgansDetailsId)
    {
        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("OrgansDetailsId", OrgansDetailsId);
        return objDBManager.ExecuteDataTable("OrganDetailsValues_GetByOrganDetails");
    }
}