using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for PHQ9DB
/// </summary>
public class PHQ9DB
{
	public PHQ9DB()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    
    public long Add(PHQ9 objPHQ9, SqlTransaction objSqlTransaction = null)
    {
        DBManager objDBManager = new DBManager(objSqlTransaction);
        try
        {
            objDBManager.AddParameter("PHQ9Id", objPHQ9.PHQ9Id, SqlDbType.Int, 4, ParameterDirection.Output);

            objDBManager.AddParameter("PracticeId", objPHQ9.PracticeId);
            objDBManager.AddParameter("ChartId", objPHQ9.ChartId);
            objDBManager.AddParameter("PatientId", objPHQ9.PatientId);
            objDBManager.AddParameter("LittleInterest", objPHQ9.LittleInterest);
            objDBManager.AddParameter("FeelingDown", objPHQ9.FeelingDown);
            objDBManager.AddParameter("TroubleFalling", objPHQ9.TroubleFalling);
            objDBManager.AddParameter("FeelingTired", objPHQ9.FeelingTired);
            objDBManager.AddParameter("PoorAppetite", objPHQ9.PoorAppetite);
            objDBManager.AddParameter("FeelingBad", objPHQ9.FeelingBad);
            objDBManager.AddParameter("TroubleConcentrating", objPHQ9.TroubleConcentrating);
            objDBManager.AddParameter("MovingOrSpeaking", objPHQ9.MovingOrSpeaking);
            objDBManager.AddParameter("Thoughts", objPHQ9.Thoughts);
            
            objDBManager.AddParameter("CreatedDate", objPHQ9.CreatedDate);
            objDBManager.AddParameter("CreatedById", objPHQ9.CreatedById);

            objDBManager.ExecuteNonQuery("PHQ9_Add");

            objPHQ9.PHQ9Id = long.Parse(objDBManager.Parameters[0].Value.ToString());
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return objPHQ9.PHQ9Id;
    }
    
    public int Update(PHQ9 objPHQ9, SqlTransaction objSqlTransaction = null)
    {
        DBManager objDBManager = new DBManager(objSqlTransaction);
        int ReturnValue = 0;
        try
        {
            objDBManager.AddParameter("PHQ9Id", objPHQ9.PHQ9Id, SqlDbType.Int, 4);

            objDBManager.AddParameter("PracticeId", objPHQ9.PracticeId);
            objDBManager.AddParameter("ChartId", objPHQ9.ChartId);
            objDBManager.AddParameter("PatientId", objPHQ9.PatientId);
            objDBManager.AddParameter("LittleInterest", objPHQ9.LittleInterest);
            objDBManager.AddParameter("FeelingDown", objPHQ9.FeelingDown);
            objDBManager.AddParameter("TroubleFalling", objPHQ9.TroubleFalling);
            objDBManager.AddParameter("FeelingTired", objPHQ9.FeelingTired);
            objDBManager.AddParameter("PoorAppetite", objPHQ9.PoorAppetite);
            objDBManager.AddParameter("FeelingBad", objPHQ9.FeelingBad);
            objDBManager.AddParameter("TroubleConcentrating", objPHQ9.TroubleConcentrating);
            objDBManager.AddParameter("MovingOrSpeaking", objPHQ9.MovingOrSpeaking);
            objDBManager.AddParameter("Thoughts", objPHQ9.Thoughts);
            
            objDBManager.AddParameter("ModifiedDate", objPHQ9.ModifiedDate);
            objDBManager.AddParameter("ModifiedById", objPHQ9.ModifiedById);

            ReturnValue = objDBManager.ExecuteNonQuery("PHQ9_Update");
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ReturnValue;
    }

    public DataTable GetPHQ9(int PracticeId, long ChartId, long PatientId)
    {
        DBManager objDBManager = new DBManager();

        objDBManager.AddParameter("PracticeId", PracticeId);
        objDBManager.AddParameter("ChartId", ChartId);
        objDBManager.AddParameter("PatientId", PatientId);

        return objDBManager.ExecuteDataTable("PHQ9_GetPHQ9");
    }
}