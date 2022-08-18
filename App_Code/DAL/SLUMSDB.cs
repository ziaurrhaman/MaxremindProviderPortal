using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for SLUMSDB
/// </summary>
public class SLUMSDB
{
	public SLUMSDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public long Add(SLUMS objSLUMS, SqlTransaction objSqlTransaction = null)
    {
        DBManager objDBManager = new DBManager(objSqlTransaction);
        try
        {
            objDBManager.AddParameter("SLUMSId", objSLUMS.SLUMSId, SqlDbType.Int, 4, ParameterDirection.Output);

            objDBManager.AddParameter("PracticeId", objSLUMS.PracticeId);
            objDBManager.AddParameter("ChartId", objSLUMS.ChartId);
            objDBManager.AddParameter("PatientId", objSLUMS.PatientId);
            objDBManager.AddParameter("DayOfTheWeek", objSLUMS.DayOfTheWeek);
            objDBManager.AddParameter("WhatIsTheYear", objSLUMS.WhatIsTheYear);
            objDBManager.AddParameter("WhatIsState", objSLUMS.WhatIsState);
            objDBManager.AddParameter("HowMuchSpend", objSLUMS.HowMuchSpend);
            objDBManager.AddParameter("HowMuchLeft", objSLUMS.HowMuchLeft);
            objDBManager.AddParameter("AnimalNames", objSLUMS.AnimalNames);
            objDBManager.AddParameter("FiveObjects", objSLUMS.FiveObjects);
            objDBManager.AddParameter("SeriesOfNumber", objSLUMS.SeriesOfNumber);
            objDBManager.AddParameter("MarkerOkay", objSLUMS.MarkerOkay);
            objDBManager.AddParameter("TimeCorrect", objSLUMS.TimeCorrect);
            objDBManager.AddParameter("XInTheTriangle", objSLUMS.XInTheTriangle);
            objDBManager.AddParameter("LargestFigure", objSLUMS.LargestFigure);
            objDBManager.AddParameter("FemaleName", objSLUMS.FemaleName);
            objDBManager.AddParameter("WorkSheDo", objSLUMS.WorkSheDo);
            objDBManager.AddParameter("SheGoBackToWork", objSLUMS.SheGoBackToWork);
            objDBManager.AddParameter("StateSheLiveIn", objSLUMS.StateSheLiveIn);

            objDBManager.AddParameter("CreatedDate", objSLUMS.CreatedDate);
            objDBManager.AddParameter("CreatedById", objSLUMS.CreatedById);

            objDBManager.ExecuteNonQuery("SLUMS_Add");

            objSLUMS.SLUMSId = long.Parse(objDBManager.Parameters[0].Value.ToString());
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return objSLUMS.SLUMSId;
    }

    public int Update(SLUMS objSLUMS, SqlTransaction objSqlTransaction = null)
    {
        DBManager objDBManager = new DBManager(objSqlTransaction);
        int ReturnValue = 0;
        try
        {
            objDBManager.AddParameter("SLUMSId", objSLUMS.SLUMSId);

            objDBManager.AddParameter("PracticeId", objSLUMS.PracticeId);
            objDBManager.AddParameter("ChartId", objSLUMS.ChartId);
            objDBManager.AddParameter("PatientId", objSLUMS.PatientId);
            objDBManager.AddParameter("DayOfTheWeek", objSLUMS.DayOfTheWeek);
            objDBManager.AddParameter("WhatIsTheYear", objSLUMS.WhatIsTheYear);
            objDBManager.AddParameter("WhatIsState", objSLUMS.WhatIsState);
            objDBManager.AddParameter("HowMuchSpend", objSLUMS.HowMuchSpend);
            objDBManager.AddParameter("HowMuchLeft", objSLUMS.HowMuchLeft);
            objDBManager.AddParameter("AnimalNames", objSLUMS.AnimalNames);
            objDBManager.AddParameter("FiveObjects", objSLUMS.FiveObjects);
            objDBManager.AddParameter("SeriesOfNumber", objSLUMS.SeriesOfNumber);
            objDBManager.AddParameter("MarkerOkay", objSLUMS.MarkerOkay);
            objDBManager.AddParameter("TimeCorrect", objSLUMS.TimeCorrect);
            objDBManager.AddParameter("XInTheTriangle", objSLUMS.XInTheTriangle);
            objDBManager.AddParameter("LargestFigure", objSLUMS.LargestFigure);
            objDBManager.AddParameter("FemaleName", objSLUMS.FemaleName);
            objDBManager.AddParameter("WorkSheDo", objSLUMS.WorkSheDo);
            objDBManager.AddParameter("SheGoBackToWork", objSLUMS.SheGoBackToWork);
            objDBManager.AddParameter("StateSheLiveIn", objSLUMS.StateSheLiveIn);
            
            objDBManager.AddParameter("ModifiedDate", objSLUMS.ModifiedDate);
            objDBManager.AddParameter("ModifiedById", objSLUMS.ModifiedById);

            ReturnValue = objDBManager.ExecuteNonQuery("SLUMS_Update");
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ReturnValue;
    }

    public DataTable GetSLUMS(int PracticeId, long ChartId, long PatientId)
    {
        DBManager objDBManager = new DBManager();

        objDBManager.AddParameter("PracticeId", PracticeId);
        objDBManager.AddParameter("ChartId", ChartId);
        objDBManager.AddParameter("PatientId", PatientId);

        return objDBManager.ExecuteDataTable("SLUMS_GetSLUMS");
    }
}