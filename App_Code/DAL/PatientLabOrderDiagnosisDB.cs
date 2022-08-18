using System;
using System.Data;

/// <summary>
/// Summary description for PatientLabOrderDiagnosisDB
/// </summary>
public class PatientLabOrderDiagnosisDB
{
	public PatientLabOrderDiagnosisDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public Int64 Add(PatientLabOrderDiagnosis objPatientLabOrderDiagnosis)
    {
        DBManager objDBManager = new DBManager();
        try
        {
            objDBManager.AddParameter("PatientDiagnosisId", objPatientLabOrderDiagnosis.PatientDiagnosisId, SqlDbType.BigInt, 8, ParameterDirection.Output);
            objDBManager.AddParameter("PatientOrderId", objPatientLabOrderDiagnosis.PatientOrderId);
            objDBManager.AddParameter("PatientId", objPatientLabOrderDiagnosis.PatientId);
            objDBManager.AddParameter("DxCode", objPatientLabOrderDiagnosis.DxCode);
            objDBManager.AddParameter("DxDescription", objPatientLabOrderDiagnosis.DxDescription);            
            objDBManager.AddParameter("ModifiedById", objPatientLabOrderDiagnosis.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objPatientLabOrderDiagnosis.ModifiedDate);
            objDBManager.AddParameter("Deleted", objPatientLabOrderDiagnosis.Deleted);
            objDBManager.ExecuteNonQuery("Lab_AddPatientLabOrderDiagnosis");
            objPatientLabOrderDiagnosis.PatientDiagnosisId = Convert.ToInt64(objDBManager.Parameters[0].Value.ToString());
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return objPatientLabOrderDiagnosis.PatientDiagnosisId;
    }

    public void Update(PatientLabOrderDiagnosis objPatientLabOrderDiagnosis)
    {
        DBManager objDBManager = new DBManager();        
        try
        {
            objDBManager.AddParameter("PatientDiagnosisId", objPatientLabOrderDiagnosis.PatientDiagnosisId);
            objDBManager.AddParameter("PatientOrderId", objPatientLabOrderDiagnosis.PatientOrderId);            
            objDBManager.AddParameter("DxCode", objPatientLabOrderDiagnosis.DxCode);
            objDBManager.AddParameter("DxDescription", objPatientLabOrderDiagnosis.DxDescription);            
            objDBManager.AddParameter("ModifiedById", objPatientLabOrderDiagnosis.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objPatientLabOrderDiagnosis.ModifiedDate);
            objDBManager.ExecuteNonQuery("Lab_UpdatePatientLabOrderDiagnosis");

        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    public void DeletePatientDiagnosis(Int64 patientDiagnosisId, Int32 modifiedById)
    {
        var objDbManager = new DBManager();
        objDbManager.AddParameter("PatientDiagnosisId", patientDiagnosisId);
        objDbManager.AddParameter("ModifiedById", modifiedById);
        objDbManager.AddParameter("ModifiedDate", DateTime.Now);
        objDbManager.ExecuteNonQuery("Lab_DeletePatientLabOrderDiag");
    }
}