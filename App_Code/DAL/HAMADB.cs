using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for HAMADB
/// </summary>
public class HAMADB
{
	public HAMADB()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    
    public long Add(HAMA objHAMA, SqlTransaction objSqlTransaction = null)
    {
        DBManager objDBManager = new DBManager(objSqlTransaction);
        try
        {
            objDBManager.AddParameter("HAMAId", objHAMA.HAMAId, SqlDbType.Int, 4, ParameterDirection.Output);

            objDBManager.AddParameter("PracticeId", objHAMA.PracticeId);
            objDBManager.AddParameter("ChartId", objHAMA.ChartId);
            objDBManager.AddParameter("PatientId", objHAMA.PatientId);
            
            objDBManager.AddParameter("AnxiousMood", objHAMA.AnxiousMood);
            objDBManager.AddParameter("Tension", objHAMA.Tension);
            objDBManager.AddParameter("Fears", objHAMA.Fears);
            objDBManager.AddParameter("Insomnia", objHAMA.Insomnia);
            objDBManager.AddParameter("Intellectual", objHAMA.Intellectual);
            objDBManager.AddParameter("DepressedMood", objHAMA.DepressedMood);
            objDBManager.AddParameter("SomaticMuscular", objHAMA.SomaticMuscular);
            objDBManager.AddParameter("SomaticSensory", objHAMA.SomaticSensory);
            objDBManager.AddParameter("CardiovascularSymptoms", objHAMA.CardiovascularSymptoms);
            objDBManager.AddParameter("RespiratorySymptoms", objHAMA.RespiratorySymptoms);
            objDBManager.AddParameter("GastrointestinalSymptoms", objHAMA.GastrointestinalSymptoms);
            objDBManager.AddParameter("GenitourinarySymptoms", objHAMA.GenitourinarySymptoms);
            objDBManager.AddParameter("AutonomicSymptoms", objHAMA.AutonomicSymptoms);
            objDBManager.AddParameter("BehaviorAtInterview", objHAMA.BehaviorAtInterview);
            
            objDBManager.AddParameter("CreatedDate", objHAMA.CreatedDate);
            objDBManager.AddParameter("CreatedById", objHAMA.CreatedById);

            objDBManager.ExecuteNonQuery("HAMA_Add");
            
            objHAMA.HAMAId = long.Parse(objDBManager.Parameters[0].Value.ToString());
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return objHAMA.HAMAId;
    }
    
    public int Update(HAMA objHAMA, SqlTransaction objSqlTransaction = null)
    {
        DBManager objDBManager = new DBManager(objSqlTransaction);
        int ReturnValue = 0;
        try
        {
            objDBManager.AddParameter("HAMAId", objHAMA.HAMAId);

            objDBManager.AddParameter("PracticeId", objHAMA.PracticeId);
            objDBManager.AddParameter("ChartId", objHAMA.ChartId);
            objDBManager.AddParameter("PatientId", objHAMA.PatientId);
            
            objDBManager.AddParameter("AnxiousMood", objHAMA.AnxiousMood);
            objDBManager.AddParameter("Tension", objHAMA.Tension);
            objDBManager.AddParameter("Fears", objHAMA.Fears);
            objDBManager.AddParameter("Insomnia", objHAMA.Insomnia);
            objDBManager.AddParameter("Intellectual", objHAMA.Intellectual);
            objDBManager.AddParameter("DepressedMood", objHAMA.DepressedMood);
            objDBManager.AddParameter("SomaticMuscular", objHAMA.SomaticMuscular);
            objDBManager.AddParameter("SomaticSensory", objHAMA.SomaticSensory);
            objDBManager.AddParameter("CardiovascularSymptoms", objHAMA.CardiovascularSymptoms);
            objDBManager.AddParameter("RespiratorySymptoms", objHAMA.RespiratorySymptoms);
            objDBManager.AddParameter("GastrointestinalSymptoms", objHAMA.GastrointestinalSymptoms);
            objDBManager.AddParameter("GenitourinarySymptoms", objHAMA.GenitourinarySymptoms);
            objDBManager.AddParameter("AutonomicSymptoms", objHAMA.AutonomicSymptoms);
            objDBManager.AddParameter("BehaviorAtInterview", objHAMA.BehaviorAtInterview);
            
            objDBManager.AddParameter("ModifiedDate", objHAMA.ModifiedDate);
            objDBManager.AddParameter("ModifiedById", objHAMA.ModifiedById);
            
            ReturnValue = objDBManager.ExecuteNonQuery("HAMA_Update");
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ReturnValue;
    }

    public DataTable GetHAMA(int PracticeId, long ChartId, long PatientId)
    {
        DBManager objDBManager = new DBManager();

        objDBManager.AddParameter("PracticeId", PracticeId);
        objDBManager.AddParameter("ChartId", ChartId);
        objDBManager.AddParameter("PatientId", PatientId);
        
        return objDBManager.ExecuteDataTable("HAMA_GetHAMA");
    }
}