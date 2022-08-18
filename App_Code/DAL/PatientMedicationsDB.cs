using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for PatientMedicationsDB
/// </summary>
public class PatientMedicationsDB
{
    public PatientMedicationsDB()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public long Add(PatientMedications objPatientMedications, SqlTransaction objSqlTransaction = null)
    {
        DBManager objDBManager = new DBManager(objSqlTransaction);
        try
        {
            objDBManager.AddParameter("PatientMedicationId", objPatientMedications.PatientMedicationId, SqlDbType.Int, 4, ParameterDirection.Output);
            objDBManager.AddParameter("PracticeId", objPatientMedications.PracticeId);
            objDBManager.AddParameter("PatientId", objPatientMedications.PatientId);
            objDBManager.AddParameter("ChartId", objPatientMedications.ChartId);
            objDBManager.AddParameter("MEDID", objPatientMedications.MEDID);
            objDBManager.AddParameter("MedicationName", objPatientMedications.MedicationName);
            objDBManager.AddParameter("Sig", objPatientMedications.Sig);
            objDBManager.AddParameter("PrescribedBy", objPatientMedications.PrescribedBy);
            objDBManager.AddParameter("Reason", objPatientMedications.Reason);
            objDBManager.AddParameter("DateStarted", objPatientMedications.DateStarted);
            objDBManager.AddParameter("DateEnd", objPatientMedications.DateEnd);
            objDBManager.AddParameter("IsTakingNow", objPatientMedications.IsTakingNow);
            objDBManager.AddParameter("Comments", objPatientMedications.Comments);
            objDBManager.AddParameter("MedReconciliationComplete", objPatientMedications.MedReconciliationComplete);
            objDBManager.AddParameter("CreatedById", objPatientMedications.CreatedById);
            objDBManager.AddParameter("CreatedDate", objPatientMedications.CreatedDate);
            objDBManager.ExecuteNonQuery("PatientMedications_Add");
            objPatientMedications.PatientMedicationId = long.Parse(objDBManager.Parameters[0].Value.ToString());
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return objPatientMedications.PatientMedicationId;
    }

    public int Update(PatientMedications objPatientMedications, SqlTransaction objSqlTransaction = null)
    {
        DBManager objDBManager = new DBManager(objSqlTransaction);
        int ReturnValue = 0;
        try
        {
            objDBManager.AddParameter("PatientMedicationId", objPatientMedications.PatientMedicationId, SqlDbType.Int, 4);
            objDBManager.AddParameter("PracticeId", objPatientMedications.PracticeId);
            objDBManager.AddParameter("PatientId", objPatientMedications.PatientId);
            objDBManager.AddParameter("ChartId", objPatientMedications.ChartId);
            objDBManager.AddParameter("MEDID", objPatientMedications.MEDID);
            objDBManager.AddParameter("MedicationName", objPatientMedications.MedicationName);
            objDBManager.AddParameter("Sig", objPatientMedications.Sig);
            objDBManager.AddParameter("PrescribedBy", objPatientMedications.PrescribedBy);
            objDBManager.AddParameter("Reason", objPatientMedications.Reason);
            objDBManager.AddParameter("DateStarted", objPatientMedications.DateStarted);
            objDBManager.AddParameter("DateEnd", objPatientMedications.DateEnd);
            objDBManager.AddParameter("IsTakingNow", objPatientMedications.IsTakingNow);
            objDBManager.AddParameter("Comments", objPatientMedications.Comments);
            objDBManager.AddParameter("MedReconciliationComplete", objPatientMedications.MedReconciliationComplete);
            objDBManager.AddParameter("ModifiedById", objPatientMedications.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objPatientMedications.ModifiedDate);
            objDBManager.AddParameter("Deleted", objPatientMedications.Deleted);
            ReturnValue = objDBManager.ExecuteNonQuery("PatientMedications_Update");
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ReturnValue;
    }
    public int Delete(long PatientMedicationId, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);
            objDBManager.AddParameter("PatientMedicationId", PatientMedicationId, SqlDbType.Int, 4);
            return objDBManager.ExecuteNonQuery("PatientMedications_Delete");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet GetPatientMedicationAndAllergies(Int64 patientId)
    {
        DBManager objDbManager = new DBManager();
        objDbManager.AddParameter("PatientId", patientId);
        return objDbManager.ExecuteDataSet("PatientMedication_GetPatientMedicationAndAllergies");
    }

    public DataTable GetAllByPatientId(Int64 patientId, Int64 practiceId, Int64 ChartId)
    {
        DBManager objDbManager = new DBManager();
        objDbManager.AddParameter("@PatientId", patientId);
        objDbManager.AddParameter("@PracticeId", practiceId);
        if (ChartId != 0)
        {
            objDbManager.AddParameter("@ChartId", ChartId);
        }
        return objDbManager.ExecuteDataTable("PatientMedications_GetAllByPatientId");
    }

    public DataTable GetAllActiveByPatientId(Int64 patientId, Int64 practiceId, Int64 ChartId)
    {
        DBManager objDbManager = new DBManager();
        objDbManager.AddParameter("@PatientId", patientId);
        objDbManager.AddParameter("@PracticeId", practiceId);
        if (ChartId != 0)
        {
            objDbManager.AddParameter("@ChartId", ChartId);
        }
        return objDbManager.ExecuteDataTable("PatientMedications_GetAllActiveByPatientId");
    }
    public DataTable CheckExistingMedication(Int64 patientId, Int64 medid)
    {
        DBManager objDbManager = new DBManager();
        objDbManager.AddParameter("@PatientId", patientId);
        objDbManager.AddParameter("MEDID", medid);
        return objDbManager.ExecuteDataTable("PatientMedication_CheckExistingMedication");
    }
    public DataTable GetPatientMedicatoinsDate(long PatientId)
    {
        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("PatientId", PatientId);
        return objDBManager.ExecuteDataTable("PatientMedication_GetPatientMedicatoinsDate");
    }
    
}