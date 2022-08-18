using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for FaceEncounterDB
/// </summary>
public class FaceEncounterDB
{
	public FaceEncounterDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    
    public long Add(FaceEncounter objFaceEncounter, SqlTransaction objSqlTransaction = null)
    {
        
        DBManager objDBManager = new DBManager(objSqlTransaction);
        
        
        try
        {
            objDBManager.AddParameter("FaceEncounterId", objFaceEncounter.FaceEncounterId, SqlDbType.BigInt, 8, ParameterDirection.Output);
            
            objDBManager.AddParameter("PatientId", objFaceEncounter.PatientId, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("PracticeId", objFaceEncounter.PracticeId, SqlDbType.Int, 4);
            objDBManager.AddParameter("ServiceProviderId", objFaceEncounter.ServiceProviderId, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("ReferringPhysicianId", objFaceEncounter.ReferringPhysicianId, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("EncounterDate", objFaceEncounter.EncounterDate, SqlDbType.DateTime, 25);
            objDBManager.AddParameter("ReasonForEncounter", objFaceEncounter.ReasonForEncounter, SqlDbType.VarChar, 500);
            objDBManager.AddParameter("EvidenceToStatus", objFaceEncounter.EvidenceToStatus, SqlDbType.VarChar, 500);
            objDBManager.AddParameter("SkilledNursing", objFaceEncounter.SkilledNursing, SqlDbType.Bit, 1);
            objDBManager.AddParameter("PhysicalTherapy", objFaceEncounter.PhysicalTherapy, SqlDbType.Bit, 1);
            objDBManager.AddParameter("OccupationalTherapy", objFaceEncounter.OccupationalTherapy, SqlDbType.Bit, 1);
            objDBManager.AddParameter("SpeechTherapy", objFaceEncounter.SpeechTherapy, SqlDbType.Bit, 1);
            objDBManager.AddParameter("SocialWorker", objFaceEncounter.SocialWorker, SqlDbType.Bit, 1);
            objDBManager.AddParameter("HHAide", objFaceEncounter.HHAide, SqlDbType.Bit, 1);
            objDBManager.AddParameter("SignatureDate", objFaceEncounter.SignatureDate, SqlDbType.DateTime, 25);
            objDBManager.AddParameter("CreatedById", objFaceEncounter.CreatedById, SqlDbType.Int, 4);
            objDBManager.AddParameter("CreatedDate", objFaceEncounter.CreatedDate, SqlDbType.DateTime, 25);
            objDBManager.AddParameter("ModifiedById", objFaceEncounter.ModifiedById, SqlDbType.Int, 4);
            objDBManager.AddParameter("ModifiedDate", objFaceEncounter.ModifiedDate, SqlDbType.DateTime, 25);
            objDBManager.AddParameter("Deleted", objFaceEncounter.Deleted, SqlDbType.Bit, 1);
            
            objDBManager.ExecuteNonQuery("FaceEncounter_Add");
            
            objFaceEncounter.FaceEncounterId = long.Parse(objDBManager.Parameters[0].Value.ToString());
            
        }
        catch (Exception ex)
        {
            
            throw ex;
            
        }
        
        return objFaceEncounter.FaceEncounterId;
        
    }
    
    public int Update(FaceEncounter objFaceEncounter, SqlTransaction objSqlTransaction = null)
    {

        DBManager objDBManager = new DBManager(objSqlTransaction);

        try
        {

            objDBManager.AddParameter("FaceEncounterId", objFaceEncounter.FaceEncounterId, SqlDbType.BigInt, 8, ParameterDirection.Output);

            objDBManager.AddParameter("PatientId", objFaceEncounter.PatientId, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("PracticeId", objFaceEncounter.PracticeId, SqlDbType.Int, 4);
            objDBManager.AddParameter("ServiceProviderId", objFaceEncounter.ServiceProviderId, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("ReferringPhysicianId", objFaceEncounter.ReferringPhysicianId, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("EncounterDate", objFaceEncounter.EncounterDate, SqlDbType.DateTime, 25);
            objDBManager.AddParameter("ReasonForEncounter", objFaceEncounter.ReasonForEncounter, SqlDbType.VarChar, 500);
            objDBManager.AddParameter("EvidenceToStatus", objFaceEncounter.EvidenceToStatus, SqlDbType.VarChar, 500);
            objDBManager.AddParameter("SkilledNursing", objFaceEncounter.SkilledNursing, SqlDbType.Bit, 1);
            objDBManager.AddParameter("PhysicalTherapy", objFaceEncounter.PhysicalTherapy, SqlDbType.Bit, 1);
            objDBManager.AddParameter("OccupationalTherapy", objFaceEncounter.OccupationalTherapy, SqlDbType.Bit, 1);
            objDBManager.AddParameter("SpeechTherapy", objFaceEncounter.SpeechTherapy, SqlDbType.Bit, 1);
            objDBManager.AddParameter("SocialWorker", objFaceEncounter.SocialWorker, SqlDbType.Bit, 1);
            objDBManager.AddParameter("HHAide", objFaceEncounter.HHAide, SqlDbType.Bit, 1);
            objDBManager.AddParameter("SignatureDate", objFaceEncounter.SignatureDate, SqlDbType.DateTime, 25);
            objDBManager.AddParameter("CreatedById", objFaceEncounter.CreatedById, SqlDbType.Int, 4);
            objDBManager.AddParameter("CreatedDate", objFaceEncounter.CreatedDate, SqlDbType.DateTime, 25);
            objDBManager.AddParameter("ModifiedById", objFaceEncounter.ModifiedById, SqlDbType.Int, 4);
            objDBManager.AddParameter("ModifiedDate", objFaceEncounter.ModifiedDate, SqlDbType.DateTime, 25);
            objDBManager.AddParameter("Deleted", objFaceEncounter.Deleted, SqlDbType.Bit, 1);

            return objDBManager.ExecuteNonQuery("FaceEncounter_Update");


        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

}