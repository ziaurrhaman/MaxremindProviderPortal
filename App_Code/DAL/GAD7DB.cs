using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for GAD7DB
/// </summary>
public class GAD7DB
{
	public GAD7DB()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    
    public long Add(GAD7 objGAD7, SqlTransaction objSqlTransaction = null)
    {
        DBManager objDBManager = new DBManager(objSqlTransaction);
        try
        {
            objDBManager.AddParameter("GAD7Id", objGAD7.GAD7Id, SqlDbType.Int, 4, ParameterDirection.Output);

            objDBManager.AddParameter("PracticeId", objGAD7.PracticeId);
            objDBManager.AddParameter("ChartId", objGAD7.ChartId);
            objDBManager.AddParameter("PatientId", objGAD7.PatientId);
            objDBManager.AddParameter("FeelingNervous", objGAD7.FeelingNervous);
            objDBManager.AddParameter("NotBeing", objGAD7.NotBeing);
            objDBManager.AddParameter("WorryingTooMuch", objGAD7.WorryingTooMuch);
            objDBManager.AddParameter("TroubleRelaxing", objGAD7.TroubleRelaxing);
            objDBManager.AddParameter("BeingSoRestless", objGAD7.BeingSoRestless);
            objDBManager.AddParameter("BecomingEasilyAnnoyed", objGAD7.BecomingEasilyAnnoyed);
            objDBManager.AddParameter("FeelingAfraid", objGAD7.FeelingAfraid);
            
            objDBManager.AddParameter("CreatedDate", objGAD7.CreatedDate);
            objDBManager.AddParameter("CreatedById", objGAD7.CreatedById);
            
            objDBManager.ExecuteNonQuery("GAD7_Add");

            objGAD7.GAD7Id = long.Parse(objDBManager.Parameters[0].Value.ToString());
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return objGAD7.GAD7Id;
    }
    
    public int Update(GAD7 objGAD7, SqlTransaction objSqlTransaction = null)
    {
        DBManager objDBManager = new DBManager(objSqlTransaction);
        int ReturnValue = 0;
        try
        {
            objDBManager.AddParameter("GAD7Id", objGAD7.GAD7Id);

            objDBManager.AddParameter("PracticeId", objGAD7.PracticeId);
            objDBManager.AddParameter("ChartId", objGAD7.ChartId);
            objDBManager.AddParameter("PatientId", objGAD7.PatientId);
            objDBManager.AddParameter("FeelingNervous", objGAD7.FeelingNervous);
            objDBManager.AddParameter("NotBeing", objGAD7.NotBeing);
            objDBManager.AddParameter("WorryingTooMuch", objGAD7.WorryingTooMuch);
            objDBManager.AddParameter("TroubleRelaxing", objGAD7.TroubleRelaxing);
            objDBManager.AddParameter("BeingSoRestless", objGAD7.BeingSoRestless);
            objDBManager.AddParameter("BecomingEasilyAnnoyed", objGAD7.BecomingEasilyAnnoyed);
            objDBManager.AddParameter("FeelingAfraid", objGAD7.FeelingAfraid);

            objDBManager.AddParameter("ModifiedDate", objGAD7.ModifiedDate);
            objDBManager.AddParameter("ModifiedById", objGAD7.ModifiedById);

            ReturnValue = objDBManager.ExecuteNonQuery("GAD7_Update");
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ReturnValue;
    }

    public DataTable GetGAD7(int PracticeId, long ChartId, long PatientId)
    {
        DBManager objDBManager = new DBManager();

        objDBManager.AddParameter("PracticeId", PracticeId);
        objDBManager.AddParameter("ChartId", ChartId);
        objDBManager.AddParameter("PatientId", PatientId);

        return objDBManager.ExecuteDataTable("GAD7_GetGAD7");
    }
}