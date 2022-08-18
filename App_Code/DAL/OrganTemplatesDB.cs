using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for OrganTemplatesDB
/// </summary>
public class OrganTemplatesDB
{
	public OrganTemplatesDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    
    public long Add(OrganTemplates objOrganTemplates, SqlTransaction objSqlTransaction = null)
    {
        DBManager objDBManager = new DBManager(objSqlTransaction);
        try
        {
            objDBManager.AddParameter("OrganTemplatesId", objOrganTemplates.OrganTemplatesId, SqlDbType.BigInt, 4, ParameterDirection.Output);
            
            objDBManager.AddParameter("TemplateName", objOrganTemplates.TemplateName);
            objDBManager.AddParameter("TemplateType", objOrganTemplates.TemplateType);
            objDBManager.AddParameter("ServiceProviderId", objOrganTemplates.ServiceProviderId);
            objDBManager.AddParameter("PracticeId", objOrganTemplates.PracticeId);
            objDBManager.AddParameter("PracticeLocationsId", objOrganTemplates.PracticeLocationsId);
            objDBManager.AddParameter("IsActive", objOrganTemplates.IsActive);
            objDBManager.AddParameter("CreatedById", objOrganTemplates.CreatedById);
            objDBManager.AddParameter("CreatedDate", objOrganTemplates.CreatedDate);
            
            objDBManager.ExecuteNonQuery("OrganTemplates_Add");
            objOrganTemplates.OrganTemplatesId = long.Parse(objDBManager.Parameters[0].Value.ToString());
        }
        catch (Exception ex)
        {
            throw ex;
        }
        
        return objOrganTemplates.OrganTemplatesId;
    }
    
    public int Update(OrganTemplates objOrganTemplates, SqlTransaction objSqlTransaction = null)
    {
        DBManager objDBManager = new DBManager(objSqlTransaction);
        int ReturnValue = 0;
        try
        {
            objDBManager.AddParameter("OrganTemplatesId", objOrganTemplates.OrganTemplatesId);
            
            objDBManager.AddParameter("TemplateName", objOrganTemplates.TemplateName);
            objDBManager.AddParameter("TemplateType", objOrganTemplates.TemplateType);
            objDBManager.AddParameter("ServiceProviderId", objOrganTemplates.ServiceProviderId);
            objDBManager.AddParameter("PracticeId", objOrganTemplates.PracticeId);
            objDBManager.AddParameter("PracticeLocationsId", objOrganTemplates.PracticeLocationsId);
            objDBManager.AddParameter("IsActive", objOrganTemplates.IsActive);
            objDBManager.AddParameter("ModifiedById", objOrganTemplates.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objOrganTemplates.ModifiedDate);
            
            ReturnValue = objDBManager.ExecuteNonQuery("OrganTemplates_Update");
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ReturnValue;
    }
    
    public int Delete(OrganTemplates objOrganTemplates, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);
            
            objDBManager.AddParameter("OrganTemplatesId", objOrganTemplates.OrganTemplatesId);
            objDBManager.AddParameter("ModifiedById", objOrganTemplates.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objOrganTemplates.ModifiedDate);
            
            return objDBManager.ExecuteNonQuery("OrganTemplates_Delete");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    
    public DataTable GetByPractice(long PracticeId, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);
            
            objDBManager.AddParameter("PracticeId", PracticeId);
            
            return objDBManager.ExecuteDataTable("OrganTemplates_GetByPractice");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}