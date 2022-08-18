using System;
using System.Data;

/// <summary>
/// Summary description for PatientHPIDb
/// </summary>
public class PatientHPIDb
{
	public PatientHPIDb()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public Int64 Add(PatientHPI objPatientHPI)
    {

        DBManager objDBManager = new DBManager();
        try
        {
            objDBManager.AddParameter("HPIId", objPatientHPI.HPIId, SqlDbType.BigInt, 8, ParameterDirection.Output);
            objDBManager.AddParameter("PatientId", objPatientHPI.PatientId, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("ChartId", objPatientHPI.ChartId, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("PracticeId", objPatientHPI.PracticeId, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("Location", objPatientHPI.Location);
            objDBManager.AddParameter("Severity", objPatientHPI.Severity);
            objDBManager.AddParameter("Timing", objPatientHPI.Timing);
            objDBManager.AddParameter("ModifyingFactors", objPatientHPI.ModifyingFactors);
            objDBManager.AddParameter("Quality", objPatientHPI.Quality);
            objDBManager.AddParameter("Duration", objPatientHPI.Duration);
            objDBManager.AddParameter("Context", objPatientHPI.Context);
            objDBManager.AddParameter("AssociatedSymptoms", objPatientHPI.AssociatedSymptoms);
            objDBManager.AddParameter("CreatedById", objPatientHPI.CreatedById);
            objDBManager.AddParameter("CreatedDate", objPatientHPI.CreatedDate);            
            objDBManager.AddParameter("Deleted", objPatientHPI.Deleted);
            objDBManager.ExecuteNonQuery("Chart_AddPatientHPI");
            objPatientHPI.HPIId = (Int64)objDBManager.Parameters[0].Value;

        }
        catch (Exception ex)
        {

            throw ex;

        }

        return objPatientHPI.HPIId;

    }

    public int Update(PatientHPI objPatientHPI)
    {

        DBManager objDBManager = new DBManager();
        int ReturnValue = 0;

        try
        {

            objDBManager.AddParameter("HPIId", objPatientHPI.HPIId);                        
            objDBManager.AddParameter("Location", objPatientHPI.Location);
            objDBManager.AddParameter("Severity", objPatientHPI.Severity);
            objDBManager.AddParameter("Timing", objPatientHPI.Timing);
            objDBManager.AddParameter("ModifyingFactors", objPatientHPI.ModifyingFactors);
            objDBManager.AddParameter("Quality", objPatientHPI.Quality);
            objDBManager.AddParameter("Duration", objPatientHPI.Duration);
            objDBManager.AddParameter("Context", objPatientHPI.Context);
            objDBManager.AddParameter("AssociatedSymptoms", objPatientHPI.AssociatedSymptoms);            
            objDBManager.AddParameter("ModifiedById", objPatientHPI.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objPatientHPI.ModifiedDate);
            ReturnValue = objDBManager.ExecuteNonQuery("Chart_UpdatePatientHPI");


        }
        catch (Exception ex)
        {
            throw ex;

        }

        return ReturnValue;

    }
}