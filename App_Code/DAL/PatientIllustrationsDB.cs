using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for PatientIllustrationsDB
/// </summary>
public class PatientIllustrationsDB
{
	public PatientIllustrationsDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public long Add(PatientIllustrations objPatientIllustrations, SqlTransaction objSqlTransaction = null)
    {
        DBManager objDBManager = new DBManager(objSqlTransaction);
        try
        {
            objDBManager.AddParameter("PatientIllustrationId", objPatientIllustrations.PatientIllustrationId, SqlDbType.Int, 4, ParameterDirection.Output);
            objDBManager.AddParameter("PatientId", objPatientIllustrations.PatientId);
            objDBManager.AddParameter("ChartId", objPatientIllustrations.ChartId);
            objDBManager.AddParameter("Illustration", objPatientIllustrations.Illustration);
            objDBManager.AddParameter("Descrption", objPatientIllustrations.Descrption);
            objDBManager.AddParameter("IllustrationImg", objPatientIllustrations.IllustrationImg);
            objDBManager.AddParameter("CreatedById", objPatientIllustrations.CreatedById);
            objDBManager.AddParameter("CreatedDate", objPatientIllustrations.CreatedDate);
            objDBManager.ExecuteNonQuery("PatientIllustrations_Add");
            objPatientIllustrations.PatientIllustrationId = long.Parse(objDBManager.Parameters[0].Value.ToString());
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return objPatientIllustrations.PatientIllustrationId;
    }

    public int Update(PatientIllustrations objPatientIllustrations, SqlTransaction objSqlTransaction = null)
    {
        DBManager objDBManager = new DBManager(objSqlTransaction);
        int ReturnValue = 0;
        try
        {
            objDBManager.AddParameter("PatientIllustrationId", objPatientIllustrations.PatientIllustrationId, SqlDbType.Int, 4);
            objDBManager.AddParameter("PatientId", objPatientIllustrations.PatientId);
            objDBManager.AddParameter("ChartId", objPatientIllustrations.ChartId);
            objDBManager.AddParameter("Illustration", objPatientIllustrations.Illustration);
            objDBManager.AddParameter("Descrption", objPatientIllustrations.Descrption);
            objDBManager.AddParameter("IllustrationImg", objPatientIllustrations.IllustrationImg);
            objDBManager.AddParameter("ModifiedById", objPatientIllustrations.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objPatientIllustrations.ModifiedDate);
            ReturnValue = objDBManager.ExecuteNonQuery("PatientIllustrations_Update");
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ReturnValue;
    }

    public int Delete(long PatientIllustrationId, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);
            objDBManager.AddParameter("PatientIllustrationId", PatientIllustrationId);
            return objDBManager.ExecuteNonQuery("PatientIllustrations_Delete");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetByID(long PatientIllustrationId, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);
            objDBManager.AddParameter("PatientIllustrationId", PatientIllustrationId);
            return objDBManager.ExecuteDataTable("PatientIllustrations_GetByID");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetAllByPatientId(long PatientId, long ChartId, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);
            objDBManager.AddParameter("PatientId", PatientId);
            if(ChartId != 0)
                objDBManager.AddParameter("ChartId", ChartId);
            return objDBManager.ExecuteDataTable("PatientIllustrations_GetAllByPatientId");
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
}