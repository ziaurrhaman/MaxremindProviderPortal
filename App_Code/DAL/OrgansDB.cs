using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
/// <summary>
/// Summary description for Orgasns
/// </summary>
public class OrgansDB
{
	public OrgansDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    
    public long Add(Organs objOrgans, SqlTransaction objSqlTransaction = null)
    {
        DBManager objDBManager = new DBManager(objSqlTransaction);
        try
        {
            objDBManager.AddParameter("OrganId", objOrgans.OrganId, SqlDbType.Int, 4, ParameterDirection.Output);
            
            objDBManager.AddParameter("OrganCode", objOrgans.OrganCode);
            objDBManager.AddParameter("OrganName", objOrgans.OrganName);
            objDBManager.AddParameter("CreatedById", objOrgans.CreatedById);
            objDBManager.AddParameter("CreatedDate", objOrgans.CreatedDate);
            objDBManager.AddParameter("Position", objOrgans.Position);
            objDBManager.AddParameter("PracticeId", objOrgans.PracticeId);
            
            objDBManager.ExecuteNonQuery("Organs_Add");
            objOrgans.OrganId = long.Parse(objDBManager.Parameters[0].Value.ToString());
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return objOrgans.OrganId;
    }
    
    public int Update(Organs objOrgans, SqlTransaction objSqlTransaction = null)
    {
        DBManager objDBManager = new DBManager(objSqlTransaction);
        int ReturnValue = 0;
        try
        {
            objDBManager.AddParameter("OrganId", objOrgans.OrganId, SqlDbType.Int, 4);
            
            objDBManager.AddParameter("OrganCode", objOrgans.OrganCode);
            objDBManager.AddParameter("OrganName", objOrgans.OrganName);
            objDBManager.AddParameter("ModifiedById", objOrgans.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objOrgans.ModifiedDate);
            objDBManager.AddParameter("Position", objOrgans.Position);
            objDBManager.AddParameter("PracticeId", objOrgans.PracticeId);
            
            ReturnValue = objDBManager.ExecuteNonQuery("Organs_Update");
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ReturnValue;
    }
    
    public int Delete(Organs objOrgans, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);
            objDBManager.AddParameter("OrganId", objOrgans.OrganId);
            objDBManager.AddParameter("OrganCode", objOrgans.OrganCode);
            objDBManager.AddParameter("ModifiedById", objOrgans.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objOrgans.ModifiedDate);
            return objDBManager.ExecuteNonQuery("Organs_Delete");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    
    public DataTable GetOrgans(Int64 practiceId)
    {
        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("PracticeId", practiceId);
        return objDBManager.ExecuteDataTable("Chart_GetOrgans");
    }
    
    public DataTable GetByOrganTemplates(long OrganTemplatesId)
    {
        DBManager objDBManager = new DBManager();
        
        objDBManager.AddParameter("OrganTemplatesId", OrganTemplatesId);
        
        return objDBManager.ExecuteDataTable("Organs_GetByOrganTemplates");
    }
    
    public DataTable CheckIfOrganCodeExists(string OrganCode, long PracticeId, SqlTransaction objSqlTransaction = null)
    {
        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("OrganCode", OrganCode);
        objDBManager.AddParameter("PracticeId", PracticeId);
        return objDBManager.ExecuteDataTable("Organs_CheckIfOrganCodeExists");
    }
    
}