using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for AIMSDB
/// </summary>
public class AIMSDB
{
	public AIMSDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    
    public long Add(AIMS objAIMS, SqlTransaction objSqlTransaction = null)
    {
        DBManager objDBManager = new DBManager(objSqlTransaction);
        try
        {
            objDBManager.AddParameter("AIMSId", objAIMS.AIMSId, SqlDbType.Int, 4, ParameterDirection.Output);

            objDBManager.AddParameter("PracticeId", objAIMS.PracticeId);
            objDBManager.AddParameter("ChartId", objAIMS.ChartId);
            objDBManager.AddParameter("PatientId", objAIMS.PatientId);

            objDBManager.AddParameter("MusclesOfFacialExpression", objAIMS.MusclesOfFacialExpression);
            objDBManager.AddParameter("LipsAndPerioralArea", objAIMS.LipsAndPerioralArea);
            objDBManager.AddParameter("Jaw", objAIMS.Jaw);
            objDBManager.AddParameter("Tongue", objAIMS.Tongue);
            objDBManager.AddParameter("Upper", objAIMS.Upper);
            objDBManager.AddParameter("Lower", objAIMS.Lower);
            objDBManager.AddParameter("NeckShouldersHips", objAIMS.NeckShouldersHips);
            objDBManager.AddParameter("SeverityOfAbnormalMovementsOverall", objAIMS.SeverityOfAbnormalMovementsOverall);
            objDBManager.AddParameter("IncapacitationDueToAbnormalMovements", objAIMS.IncapacitationDueToAbnormalMovements);
            objDBManager.AddParameter("PatientsAwarenessOfAbnormalMovements", objAIMS.PatientsAwarenessOfAbnormalMovements);
            objDBManager.AddParameter("CurrentProblemsWithTeethAndOrDentures", objAIMS.CurrentProblemsWithTeethAndOrDentures);
            objDBManager.AddParameter("AreDenturesUsuallyWorn", objAIMS.AreDenturesUsuallyWorn);
            objDBManager.AddParameter("Edentia", objAIMS.Edentia);
            objDBManager.AddParameter("DoMovementsDisappearInSleep", objAIMS.DoMovementsDisappearInSleep);

            objDBManager.AddParameter("CreatedDate", objAIMS.CreatedDate);
            objDBManager.AddParameter("CreatedById", objAIMS.CreatedById);

            objDBManager.ExecuteNonQuery("AIMS_Add");

            objAIMS.AIMSId = long.Parse(objDBManager.Parameters[0].Value.ToString());
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return objAIMS.AIMSId;
    }
    
    public int Update(AIMS objAIMS, SqlTransaction objSqlTransaction = null)
    {
        DBManager objDBManager = new DBManager(objSqlTransaction);
        int ReturnValue = 0;
        try
        {
            objDBManager.AddParameter("AIMSId", objAIMS.AIMSId);

            objDBManager.AddParameter("PracticeId", objAIMS.PracticeId);
            objDBManager.AddParameter("ChartId", objAIMS.ChartId);
            objDBManager.AddParameter("PatientId", objAIMS.PatientId);

            objDBManager.AddParameter("MusclesOfFacialExpression", objAIMS.MusclesOfFacialExpression);
            objDBManager.AddParameter("LipsAndPerioralArea", objAIMS.LipsAndPerioralArea);
            objDBManager.AddParameter("Jaw", objAIMS.Jaw);
            objDBManager.AddParameter("Tongue", objAIMS.Tongue);
            objDBManager.AddParameter("Upper", objAIMS.Upper);
            objDBManager.AddParameter("Lower", objAIMS.Lower);
            objDBManager.AddParameter("NeckShouldersHips", objAIMS.NeckShouldersHips);
            objDBManager.AddParameter("SeverityOfAbnormalMovementsOverall", objAIMS.SeverityOfAbnormalMovementsOverall);
            objDBManager.AddParameter("IncapacitationDueToAbnormalMovements", objAIMS.IncapacitationDueToAbnormalMovements);
            objDBManager.AddParameter("PatientsAwarenessOfAbnormalMovements", objAIMS.PatientsAwarenessOfAbnormalMovements);
            objDBManager.AddParameter("CurrentProblemsWithTeethAndOrDentures", objAIMS.CurrentProblemsWithTeethAndOrDentures);
            objDBManager.AddParameter("AreDenturesUsuallyWorn", objAIMS.AreDenturesUsuallyWorn);
            objDBManager.AddParameter("Edentia", objAIMS.Edentia);
            objDBManager.AddParameter("DoMovementsDisappearInSleep", objAIMS.DoMovementsDisappearInSleep);

            objDBManager.AddParameter("ModifiedDate", objAIMS.ModifiedDate);
            objDBManager.AddParameter("ModifiedById", objAIMS.ModifiedById);

            ReturnValue = objDBManager.ExecuteNonQuery("AIMS_Update");
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ReturnValue;
    }
    
    public DataTable GetAIMS(int PracticeId, long ChartId, long PatientId)
    {
        DBManager objDBManager = new DBManager();

        objDBManager.AddParameter("PracticeId", PracticeId);
        objDBManager.AddParameter("ChartId", ChartId);
        objDBManager.AddParameter("PatientId", PatientId);
        
        return objDBManager.ExecuteDataTable("AIMS_GetAIMS");
    }
}