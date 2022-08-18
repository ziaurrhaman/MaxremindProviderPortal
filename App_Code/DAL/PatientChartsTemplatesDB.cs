using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for PatientChartsTemplatesDB
/// </summary>
public class PatientChartsTemplatesDB
{
	public PatientChartsTemplatesDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public long Add(PatientChartsTemplates objPatientChartsTemplates, SqlTransaction objSqlTransaction = null)
    {
        DBManager objDBManager = new DBManager(objSqlTransaction);
        try
        {
            objDBManager.AddParameter("ChartTemplateId", objPatientChartsTemplates.ChartTemplateId, SqlDbType.Int, 4, ParameterDirection.Output);
            objDBManager.AddParameter("TemplateType", objPatientChartsTemplates.TemplateType);
            objDBManager.AddParameter("TemplateName", objPatientChartsTemplates.TemplateName);
            objDBManager.AddParameter("TemplateText", objPatientChartsTemplates.TemplateText);
            objDBManager.AddParameter("Shared", objPatientChartsTemplates.Shared);
            objDBManager.AddParameter("ServiceProviderId", objPatientChartsTemplates.ServiceProviderId);
            objDBManager.AddParameter("PracticeId", objPatientChartsTemplates.PracticeId);
            objDBManager.AddParameter("CreatedById", objPatientChartsTemplates.CreatedById);
            objDBManager.AddParameter("CreatedDate", objPatientChartsTemplates.CreatedDate);
            objDBManager.ExecuteNonQuery("PatientChartsTemplates_Add");
            objPatientChartsTemplates.ChartTemplateId = int.Parse (objDBManager.Parameters[0].Value.ToString());
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return objPatientChartsTemplates.ChartTemplateId;
    }

    public int Update(PatientChartsTemplates objPatientChartsTemplates, SqlTransaction objSqlTransaction = null)
    {
        DBManager objDBManager = new DBManager(objSqlTransaction);
        int ReturnValue = 0;
        try
        {
            objDBManager.AddParameter("ChartTemplateId", objPatientChartsTemplates.ChartTemplateId, SqlDbType.Int, 4);
            objDBManager.AddParameter("TemplateType", objPatientChartsTemplates.TemplateType);
            objDBManager.AddParameter("TemplateName", objPatientChartsTemplates.TemplateName);
            objDBManager.AddParameter("TemplateText", objPatientChartsTemplates.TemplateText);
            objDBManager.AddParameter("Shared", objPatientChartsTemplates.Shared);
            objDBManager.AddParameter("ServiceProviderId", objPatientChartsTemplates.ServiceProviderId);
            objDBManager.AddParameter("PracticeId", objPatientChartsTemplates.PracticeId);
            objDBManager.AddParameter("ModifiedById", objPatientChartsTemplates.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objPatientChartsTemplates.ModifiedDate);
            ReturnValue = objDBManager.ExecuteNonQuery("PatientChartsTemplates_Update");
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ReturnValue;
    }

    public int Delete(int ChartTemplateId, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);
            objDBManager.AddParameter("ChartTemplateId", ChartTemplateId, SqlDbType.Int, 4);
            return objDBManager.ExecuteNonQuery("PatientChartsTemplates_Delete");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataSet GetBySerachFilter(string Type, string TemplateName, string TemplateText, long PracticeId, long ServiceProviderId, int Rows, int PageNumber, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);
            objDBManager.AddParameter("Rows", Rows);
            objDBManager.AddParameter("PageNumber", PageNumber);
            objDBManager.AddParameter("@PracticeId", PracticeId);
            if (ServiceProviderId != 0)
            {
                objDBManager.AddParameter("@ServiceProviderId", ServiceProviderId);
            }
            if (!string.IsNullOrEmpty(Type))
            {
                objDBManager.AddParameter("@Type", Type);
            }
            if (!string.IsNullOrEmpty(TemplateName))
            {
                objDBManager.AddParameter("@TemplateName", TemplateName);
            }
            if (!string.IsNullOrEmpty(TemplateText))
            {
                objDBManager.AddParameter("@TemplateText", TemplateText);
            }
            return objDBManager.ExecuteDataSet("PatientChartsTemplates_GetBySerachFilter");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataSet GetByProviderAndShared(long ServiceProviderId, long PracticeId, string TemplateType, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);
            objDBManager.AddParameter("ServiceProviderId", ServiceProviderId);
            objDBManager.AddParameter("PracticeId", PracticeId);
            objDBManager.AddParameter("TemplateType", TemplateType);
            return objDBManager.ExecuteDataSet("PatientChartsTemplates_GetByProviderAndShared");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}