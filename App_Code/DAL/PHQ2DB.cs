using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for PHQ2DB
/// </summary>
public class PHQ2DB
{
	public PHQ2DB()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public long Add(PHQ2 objPHQ2, SqlTransaction objSqlTransaction = null)
    {
        DBManager objDBManager = new DBManager(objSqlTransaction);
        try
        {
            objDBManager.AddParameter("PHQ2Id", objPHQ2.PHQ2Id, SqlDbType.Int, 4, ParameterDirection.Output);

            objDBManager.AddParameter("PracticeId", objPHQ2.PracticeId);
            objDBManager.AddParameter("ChartId", objPHQ2.ChartId);
            objDBManager.AddParameter("PatientId", objPHQ2.PatientId);
            objDBManager.AddParameter("LittleInterest", objPHQ2.LittleInterest);
            objDBManager.AddParameter("FeelingDown", objPHQ2.FeelingDown);

            objDBManager.AddParameter("CreatedDate", objPHQ2.CreatedDate);
            objDBManager.AddParameter("CreatedById", objPHQ2.CreatedById);

            objDBManager.ExecuteNonQuery("PHQ2_Add");

            objPHQ2.PHQ2Id = long.Parse(objDBManager.Parameters[0].Value.ToString());
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return objPHQ2.PHQ2Id;
    }

    public int Update(PHQ2 objPHQ2, SqlTransaction objSqlTransaction = null)
    {
        DBManager objDBManager = new DBManager(objSqlTransaction);
        int ReturnValue = 0;
        try
        {
            objDBManager.AddParameter("PHQ2Id", objPHQ2.PHQ2Id);

            objDBManager.AddParameter("PracticeId", objPHQ2.PracticeId);
            objDBManager.AddParameter("ChartId", objPHQ2.ChartId);
            objDBManager.AddParameter("PatientId", objPHQ2.PatientId);
            objDBManager.AddParameter("LittleInterest", objPHQ2.LittleInterest);
            objDBManager.AddParameter("FeelingDown", objPHQ2.FeelingDown);
            
            objDBManager.AddParameter("ModifiedDate", objPHQ2.ModifiedDate);
            objDBManager.AddParameter("ModifiedById", objPHQ2.ModifiedById);

            ReturnValue = objDBManager.ExecuteNonQuery("PHQ2_Update");
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ReturnValue;
    }

    public DataTable GetPHQ2(int PracticeId, long ChartId, long PatientId)
    {
        DBManager objDBManager = new DBManager();

        objDBManager.AddParameter("PracticeId", PracticeId);
        objDBManager.AddParameter("ChartId", ChartId);
        objDBManager.AddParameter("PatientId", PatientId);

        return objDBManager.ExecuteDataTable("PHQ2_GetPHQ2");
    }
}