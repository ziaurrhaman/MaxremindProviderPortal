using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for SPMSQDB
/// </summary>
public class SPMSQDB
{
	public SPMSQDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}


    public long Add(SPMSQ objSPMSQ, SqlTransaction objSqlTransaction = null)
    {
        DBManager objDBManager = new DBManager(objSqlTransaction);
        try
        {
            objDBManager.AddParameter("SPMSQId", objSPMSQ.SPMSQId, SqlDbType.Int, 4, ParameterDirection.Output);

            objDBManager.AddParameter("PracticeId", objSPMSQ.PracticeId);
            objDBManager.AddParameter("ChartId", objSPMSQ.ChartId);
            objDBManager.AddParameter("PatientId", objSPMSQ.PatientId);
            
            objDBManager.AddParameter("DateToday", objSPMSQ.DateToday);
            objDBManager.AddParameter("DayOfTheWeek", objSPMSQ.DayOfTheWeek);
            objDBManager.AddParameter("NameOfThisPlace", objSPMSQ.NameOfThisPlace);
            objDBManager.AddParameter("TelephoneNumber", objSPMSQ.TelephoneNumber);
            objDBManager.AddParameter("StreetAddress", objSPMSQ.StreetAddress);
            objDBManager.AddParameter("HowOldAreYou", objSPMSQ.HowOldAreYou);
            objDBManager.AddParameter("WhenWereYouBorn", objSPMSQ.WhenWereYouBorn);
            objDBManager.AddParameter("PresidentOfUSA", objSPMSQ.PresidentOfUSA);
            objDBManager.AddParameter("PresidentJustBefore", objSPMSQ.PresidentJustBefore);
            objDBManager.AddParameter("MothersMaidenName", objSPMSQ.MothersMaidenName);
            objDBManager.AddParameter("Subtract3From20", objSPMSQ.Subtract3From20);
            
            objDBManager.AddParameter("CreatedDate", objSPMSQ.CreatedDate);
            objDBManager.AddParameter("CreatedById", objSPMSQ.CreatedById);
            
            objDBManager.ExecuteNonQuery("SPMSQ_Add");
            
            objSPMSQ.SPMSQId = long.Parse(objDBManager.Parameters[0].Value.ToString());
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return objSPMSQ.SPMSQId;
    }

    public int Update(SPMSQ objSPMSQ, SqlTransaction objSqlTransaction = null)
    {
        DBManager objDBManager = new DBManager(objSqlTransaction);
        int ReturnValue = 0;
        try
        {
            objDBManager.AddParameter("SPMSQId", objSPMSQ.SPMSQId);

            objDBManager.AddParameter("PracticeId", objSPMSQ.PracticeId);
            objDBManager.AddParameter("ChartId", objSPMSQ.ChartId);
            objDBManager.AddParameter("PatientId", objSPMSQ.PatientId);
            
            objDBManager.AddParameter("DateToday", objSPMSQ.DateToday);
            objDBManager.AddParameter("DayOfTheWeek", objSPMSQ.DayOfTheWeek);
            objDBManager.AddParameter("NameOfThisPlace", objSPMSQ.NameOfThisPlace);
            objDBManager.AddParameter("TelephoneNumber", objSPMSQ.TelephoneNumber);
            objDBManager.AddParameter("StreetAddress", objSPMSQ.StreetAddress);
            objDBManager.AddParameter("HowOldAreYou", objSPMSQ.HowOldAreYou);
            objDBManager.AddParameter("WhenWereYouBorn", objSPMSQ.WhenWereYouBorn);
            objDBManager.AddParameter("PresidentOfUSA", objSPMSQ.PresidentOfUSA);
            objDBManager.AddParameter("PresidentJustBefore", objSPMSQ.PresidentJustBefore);
            objDBManager.AddParameter("MothersMaidenName", objSPMSQ.MothersMaidenName);
            objDBManager.AddParameter("Subtract3From20", objSPMSQ.Subtract3From20);
            
            objDBManager.AddParameter("ModifiedDate", objSPMSQ.ModifiedDate);
            objDBManager.AddParameter("ModifiedById", objSPMSQ.ModifiedById);

            ReturnValue = objDBManager.ExecuteNonQuery("SPMSQ_Update");
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ReturnValue;
    }

    public DataTable GetSPMSQ(int PracticeId, long ChartId, long PatientId)
    {
        DBManager objDBManager = new DBManager();

        objDBManager.AddParameter("PracticeId", PracticeId);
        objDBManager.AddParameter("ChartId", ChartId);
        objDBManager.AddParameter("PatientId", PatientId);

        return objDBManager.ExecuteDataTable("SPMSQ_GetSPMSQ");
    }
}