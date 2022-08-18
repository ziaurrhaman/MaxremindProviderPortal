using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for PatientImmunizationDB
/// </summary>
public class PatientImmunizationDB
{
	public PatientImmunizationDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public long Add(PatientImmunization objPatientImmunization, SqlTransaction objSqlTransaction = null)
    {

        DBManager objDBManager = new DBManager(objSqlTransaction);

        try
        {
            objDBManager.AddParameter("PatientImmunizationId", objPatientImmunization.PatientImmunizationId, SqlDbType.Int, 4, ParameterDirection.Output);

            objDBManager.AddParameter("ImmunizationDate", objPatientImmunization.ImmunizationDate);
            objDBManager.AddParameter("ImmunizationName", objPatientImmunization.ImmunizationName);
            objDBManager.AddParameter("Manufacturer", objPatientImmunization.Manufacturer);
            objDBManager.AddParameter("LotNumber", objPatientImmunization.LotNumber);
            objDBManager.AddParameter("NotPerformed", objPatientImmunization.NotPerformed);
            objDBManager.AddParameter("NotPerformedReason", objPatientImmunization.NotPerformedReason);
            objDBManager.AddParameter("CvxCode", objPatientImmunization.CvxCode);
            objDBManager.AddParameter("ImmunizationDose", objPatientImmunization.ImmunizationDose);
            objDBManager.AddParameter("ImmunizationUnits", objPatientImmunization.ImmunizationUnits);
            objDBManager.AddParameter("ImmunizationTime", objPatientImmunization.ImmunizationTime);
            objDBManager.AddParameter("ExpirationDate", objPatientImmunization.ExpirationDate);
            objDBManager.AddParameter("Site", objPatientImmunization.Site);
            objDBManager.AddParameter("Routs", objPatientImmunization.Routs);
            objDBManager.AddParameter("IsCompleted", objPatientImmunization.IsCompleted);
            objDBManager.AddParameter("AdversReaction", objPatientImmunization.AdversReaction);
            objDBManager.AddParameter("Comments", objPatientImmunization.Comments);
            objDBManager.AddParameter("PatientId", objPatientImmunization.PatientId);
            objDBManager.AddParameter("ImmunizationId", objPatientImmunization.ImmunizationId);
            objDBManager.AddParameter("ChartId", objPatientImmunization.ChartId);
            objDBManager.AddParameter("CreatedById", objPatientImmunization.CreatedById);
            objDBManager.AddParameter("CreatedDate", objPatientImmunization.CreatedDate);

            objDBManager.ExecuteNonQuery("PatientImmunization_Add");

            objPatientImmunization.PatientImmunizationId = long.Parse(objDBManager.Parameters[0].Value.ToString());

        }
        catch (Exception ex)
        {
            throw ex;
        }

        return objPatientImmunization.PatientImmunizationId;
    }
    
    public int Update(PatientImmunization objPatientImmunization, SqlTransaction objSqlTransaction = null)
    {
        
        DBManager objDBManager = new DBManager(objSqlTransaction);
        int ReturnValue = 0;
        
        try
        {
            objDBManager.AddParameter("PatientImmunizationId", objPatientImmunization.PatientImmunizationId);
            
            objDBManager.AddParameter("ImmunizationDate", objPatientImmunization.ImmunizationDate);
            objDBManager.AddParameter("ImmunizationName", objPatientImmunization.ImmunizationName);
            objDBManager.AddParameter("Manufacturer", objPatientImmunization.Manufacturer);
            objDBManager.AddParameter("LotNumber", objPatientImmunization.LotNumber);
            objDBManager.AddParameter("NotPerformed", objPatientImmunization.NotPerformed);
            objDBManager.AddParameter("NotPerformedReason", objPatientImmunization.NotPerformedReason);
            objDBManager.AddParameter("CvxCode", objPatientImmunization.CvxCode);
            objDBManager.AddParameter("ImmunizationDose", objPatientImmunization.ImmunizationDose);
            objDBManager.AddParameter("ImmunizationUnits", objPatientImmunization.ImmunizationUnits);
            objDBManager.AddParameter("ImmunizationTime", objPatientImmunization.ImmunizationTime);
            objDBManager.AddParameter("ExpirationDate", objPatientImmunization.ExpirationDate);
            objDBManager.AddParameter("Site", objPatientImmunization.Site);
            objDBManager.AddParameter("Routs", objPatientImmunization.Routs);
            objDBManager.AddParameter("IsCompleted", objPatientImmunization.IsCompleted);
            objDBManager.AddParameter("AdversReaction", objPatientImmunization.AdversReaction);
            objDBManager.AddParameter("Comments", objPatientImmunization.Comments);
            objDBManager.AddParameter("PatientId", objPatientImmunization.PatientId);
            objDBManager.AddParameter("ImmunizationId", objPatientImmunization.ImmunizationId);
            objDBManager.AddParameter("ChartId", objPatientImmunization.ChartId);
            objDBManager.AddParameter("ModifiedById", objPatientImmunization.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objPatientImmunization.ModifiedDate);
            objDBManager.AddParameter("Deleted", objPatientImmunization.Deleted);
            ReturnValue = objDBManager.ExecuteNonQuery("PatientImmunization_Update");
        }
        catch (Exception ex)
        {
            throw ex;
        }
        
        return ReturnValue;
    }
    
    public int Delete(PatientImmunization objPatientImmunization, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);
            objDBManager.AddParameter("PatientImmunizationId", objPatientImmunization.PatientImmunizationId);
            objDBManager.AddParameter("ModifiedById", objPatientImmunization.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objPatientImmunization.ModifiedDate);

            return objDBManager.ExecuteNonQuery("PatientImmunization_Delete");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable GetByID(int PatientImmunizationId, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);
            objDBManager.AddParameter("PatientImmunizationId", PatientImmunizationId);

            return objDBManager.ExecuteDataTable("PatientImmunization_GetByID");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet GetAllAsDataTable(long PatientId, int Rows, int PageNumber, string SortBy, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);
            objDBManager.AddParameter("@PatientId", PatientId);
            objDBManager.AddParameter("@Rows", Rows);
            objDBManager.AddParameter("@PageNumber", PageNumber);
            if (!string.IsNullOrEmpty(SortBy))
                objDBManager.AddParameter("@SortBy", SortBy);

            return objDBManager.ExecuteDataSet("PatientImmunization_GetAll");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable PatientImmunization_GetByPatientChartId(Int64 ChartId, Int64 Patientid)
    {
        DBManager objDBManager = new DBManager();
        if (ChartId != 0)
        {
            objDBManager.AddParameter("ChartId", ChartId);
        }
        objDBManager.AddParameter("PatientId", Patientid);
        return objDBManager.ExecuteDataTable("PatientImmunization_GetByPatientChartId");
    }

    public void PatientImmunization_DeleteById(Int64 PatientImmunizationId)
    {
        DBManager objDbManager = new DBManager();
        objDbManager.AddParameter("PatientImmunizationId", PatientImmunizationId);
        objDbManager.ExecuteNonQuery("PatientImmunization_DeleteById");
    }
}