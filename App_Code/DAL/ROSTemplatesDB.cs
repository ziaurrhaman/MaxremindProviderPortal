using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for ROSTemplatesDB
/// </summary>
public class ROSTemplatesDB
{
	public ROSTemplatesDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    
    public int Add(ROSTemplates objROSTemplates, SqlTransaction objSqlTransaction = null)
    {
        DBManager objDBManager = new DBManager(objSqlTransaction);
        try
        {
            objDBManager.AddParameter("ROSTemplatesId", objROSTemplates.ROSTemplatesId, SqlDbType.Int, 4, ParameterDirection.Output);

            objDBManager.AddParameter("TemplateName", objROSTemplates.TemplateName);
            objDBManager.AddParameter("TemplateType", objROSTemplates.TemplateType);
            objDBManager.AddParameter("ServiceProviderId", objROSTemplates.ServiceProviderId);
            objDBManager.AddParameter("PracticeId", objROSTemplates.PracticeId);
            objDBManager.AddParameter("PracticeLocationsId", objROSTemplates.PracticeLocationsId);
            objDBManager.AddParameter("IsActive", objROSTemplates.IsActive);
            objDBManager.AddParameter("CreatedById", objROSTemplates.CreatedById);
            objDBManager.AddParameter("CreatedDate", objROSTemplates.CreatedDate);
            
            objDBManager.ExecuteNonQuery("ROSTemplates_Add");
            objROSTemplates.ROSTemplatesId = int.Parse(objDBManager.Parameters[0].Value.ToString());
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return objROSTemplates.ROSTemplatesId;
    }
    
    public int Update(ROSTemplates objROSTemplates, SqlTransaction objSqlTransaction = null)
    {
        DBManager objDBManager = new DBManager(objSqlTransaction);
        int ReturnValue = 0;
        try
        {
            objDBManager.AddParameter("ROSTemplatesId", objROSTemplates.ROSTemplatesId);

            objDBManager.AddParameter("TemplateName", objROSTemplates.TemplateName);
            objDBManager.AddParameter("TemplateType", objROSTemplates.TemplateType);
            objDBManager.AddParameter("ServiceProviderId", objROSTemplates.ServiceProviderId);
            objDBManager.AddParameter("PracticeId", objROSTemplates.PracticeId);
            objDBManager.AddParameter("PracticeLocationsId", objROSTemplates.PracticeLocationsId);
            objDBManager.AddParameter("IsActive", objROSTemplates.IsActive);
            objDBManager.AddParameter("ModifiedById", objROSTemplates.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objROSTemplates.ModifiedDate);

            ReturnValue = objDBManager.ExecuteNonQuery("ROSTemplates_Update");
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ReturnValue;
    }
    
    public int Delete(ROSTemplates objROSTemplates, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);
            objDBManager.AddParameter("ROSTemplatesId", objROSTemplates.ROSTemplatesId);
            objDBManager.AddParameter("ModifiedById", objROSTemplates.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objROSTemplates.ModifiedDate);
            return objDBManager.ExecuteNonQuery("ROSTemplates_Delete");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable GetByPractice(long PracticeId)
    {
        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("PracticeId", PracticeId);
        
        return objDBManager.ExecuteDataTable("ROSTemplates_GetByPractice");
    }
}