using System;
using System.Data;

/// <summary>
/// Summary description for PatientReasonOfVisitDb
/// </summary>
public class PatientReasonOfVisitDb
{
	public PatientReasonOfVisitDb()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public Int64 Add(PatientReasonOfVisit objPatientReasonOfVisit)
    {

        DBManager objDBManager = new DBManager();
        try
        {
            objDBManager.AddParameter("ReasonOfVisitId", objPatientReasonOfVisit.ReasonOfVisitId, SqlDbType.BigInt, 8, ParameterDirection.Output);
            objDBManager.AddParameter("ReasonOfVisit", objPatientReasonOfVisit.ReasonOfVisit);
            objDBManager.AddParameter("HPI", objPatientReasonOfVisit.HPI);
            objDBManager.AddParameter("ProvidedBy", objPatientReasonOfVisit.ProvidedBy);
            objDBManager.AddParameter("ReferringPhysicainId", objPatientReasonOfVisit.ReferringPhysicainId);
            objDBManager.AddParameter("PatientId", objPatientReasonOfVisit.PatientId);
            objDBManager.AddParameter("ChartId", objPatientReasonOfVisit.ChartId);
            objDBManager.AddParameter("PracticeId", objPatientReasonOfVisit.PracticeId);
            objDBManager.AddParameter("CreatedById", objPatientReasonOfVisit.CreatedById);
            objDBManager.AddParameter("CreatedDate", objPatientReasonOfVisit.CreatedDate);            
            objDBManager.AddParameter("Deleted", objPatientReasonOfVisit.Deleted);
            objDBManager.ExecuteNonQuery("Chart_AddPatientReasonOfVisit");
            objPatientReasonOfVisit.ReasonOfVisitId = (Int64)objDBManager.Parameters[0].Value;
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return objPatientReasonOfVisit.ReasonOfVisitId;

    }

    public void Update(PatientReasonOfVisit objPatientReasonOfVisit)
    {

        DBManager objDBManager = new DBManager();        
        try
        {
            objDBManager.AddParameter("ReasonOfVisitId", objPatientReasonOfVisit.ReasonOfVisitId);
            objDBManager.AddParameter("ReasonOfVisit", objPatientReasonOfVisit.ReasonOfVisit);
            objDBManager.AddParameter("HPI", objPatientReasonOfVisit.HPI);
            objDBManager.AddParameter("ProvidedBy", objPatientReasonOfVisit.ProvidedBy);
            objDBManager.AddParameter("ReferringPhysicainId", objPatientReasonOfVisit.ReferringPhysicainId);
            objDBManager.AddParameter("ChartId", objPatientReasonOfVisit.ChartId);
            objDBManager.AddParameter("ModifiedById", objPatientReasonOfVisit.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objPatientReasonOfVisit.ModifiedDate);
            objDBManager.ExecuteNonQuery("Chart_UpdatePatientReasonOfVisit");
        }
        catch (Exception ex)
        {
            throw ex;
        }     
    }
}