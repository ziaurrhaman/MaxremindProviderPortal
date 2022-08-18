using System;
using System.Data;

/// <summary>
/// Summary description for PatientLabOrderTestsDB
/// </summary>
public class PatientLabOrderTestsDB
{
	public PatientLabOrderTestsDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public Int64 Add(PatientLabOrderTests objPatientLabOrderTests)
    {
        DBManager objDBManager = new DBManager();
        try
        {
            objDBManager.AddParameter("PatientOrderTestId", objPatientLabOrderTests.PatientOrderTestId, SqlDbType.BigInt, 8, ParameterDirection.Output);
            objDBManager.AddParameter("PatientOrderId", objPatientLabOrderTests.PatientOrderId);
            objDBManager.AddParameter("PatientId", objPatientLabOrderTests.PatientId);            
            objDBManager.AddParameter("LabTestGroupId",objPatientLabOrderTests.LabTestGroupId);
            objDBManager.AddParameter("LabTestId", objPatientLabOrderTests.LabTestId);
            objDBManager.AddParameter("CptCode", objPatientLabOrderTests.CptCode);
            objDBManager.AddParameter("CptDescription", objPatientLabOrderTests.CptDescription);
            objDBManager.AddParameter("Instructions",objPatientLabOrderTests.Instructions);
            objDBManager.AddParameter("Units",objPatientLabOrderTests.Units);            
            objDBManager.AddParameter("ModifiedById",objPatientLabOrderTests.ModifiedById);
            objDBManager.AddParameter("ModifiedDate",objPatientLabOrderTests.ModifiedDate);
            objDBManager.AddParameter("Deleted",objPatientLabOrderTests.Deleted);
            objDBManager.ExecuteNonQuery("Lab_AddPatientLabOrderTests");
            objPatientLabOrderTests.PatientOrderTestId = Convert.ToInt64(objDBManager.Parameters[0].Value.ToString());

        }
        catch (Exception ex)
        {

            throw ex;

        }

        return objPatientLabOrderTests.PatientOrderTestId;

    }

    public void Update(PatientLabOrderTests objPatientLabOrderTests)
    {
        DBManager objDBManager = new DBManager();        
        try
        {

            objDBManager.AddParameter("PatientOrderTestId", objPatientLabOrderTests.PatientOrderTestId);
            objDBManager.AddParameter("PatientOrderId", objPatientLabOrderTests.PatientOrderId);                        
            objDBManager.AddParameter("LabTestGroupId",objPatientLabOrderTests.LabTestGroupId);
            objDBManager.AddParameter("LabTestId", objPatientLabOrderTests.LabTestId);
            objDBManager.AddParameter("CptCode", objPatientLabOrderTests.CptCode);
            objDBManager.AddParameter("CptDescription", objPatientLabOrderTests.CptDescription);
            objDBManager.AddParameter("Instructions",objPatientLabOrderTests.Instructions);
            objDBManager.AddParameter("Units",objPatientLabOrderTests.Units);            
            objDBManager.AddParameter("ModifiedById",objPatientLabOrderTests.ModifiedById);
            objDBManager.AddParameter("ModifiedDate",objPatientLabOrderTests.ModifiedDate);
            objDBManager.ExecuteNonQuery("Lab_UpdatePatientLabOrderTests");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetLabOrderTests(Int64 labOrderId)
    {
        var objDbManager = new DBManager();
        objDbManager.AddParameter("LabOrderId", labOrderId);
        return objDbManager.ExecuteDataTable("Lab_GetLabOrderTests");
    }
    public DataTable DeletePatientLabOrderTests(Int64 patientOrderId, string patientOrderTestId, long modifiedById)
    {
        var objDbManager = new DBManager();
        objDbManager.AddParameter("PatientOrderId", patientOrderId);
        objDbManager.AddParameter("PatientOrderTestId", patientOrderTestId);
        objDbManager.AddParameter("ModifiedById", modifiedById);
        objDbManager.AddParameter("ModifiedDate", DateTime.Now);
        return objDbManager.ExecuteDataTable("Lab_DeletePatientLabOrderTests");
    }
}