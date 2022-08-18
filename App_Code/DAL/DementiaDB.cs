using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for DementiaDB
/// </summary>
public class DementiaDB
{
	public DementiaDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public long Add(Dementia objDementia, SqlTransaction objSqlTransaction = null)
    {
        DBManager objDBManager = new DBManager(objSqlTransaction);
        try
        {
            objDBManager.AddParameter("DementiaId", objDementia.DementiaId, SqlDbType.Int, 4, ParameterDirection.Output);

            objDBManager.AddParameter("PracticeId", objDementia.PracticeId);
            objDBManager.AddParameter("ChartId", objDementia.ChartId);
            objDBManager.AddParameter("PatientId", objDementia.PatientId);

            objDBManager.AddParameter("Anxiety", objDementia.Anxiety);
            objDBManager.AddParameter("Sadness", objDementia.Sadness);
            objDBManager.AddParameter("LackOfReaction", objDementia.LackOfReaction);
            objDBManager.AddParameter("Irritability", objDementia.Irritability);
            objDBManager.AddParameter("Agitation", objDementia.Agitation);
            objDBManager.AddParameter("Retardation", objDementia.Retardation);
            objDBManager.AddParameter("MultiplePhysicalComplaints", objDementia.MultiplePhysicalComplaints);
            objDBManager.AddParameter("LossOfInterest", objDementia.LossOfInterest);
            objDBManager.AddParameter("AppetiteLoss", objDementia.AppetiteLoss);
            objDBManager.AddParameter("WeightLoss", objDementia.WeightLoss);
            objDBManager.AddParameter("LackOfEnergy", objDementia.LackOfEnergy);
            objDBManager.AddParameter("DiurnalVariationOfMood", objDementia.DiurnalVariationOfMood);
            objDBManager.AddParameter("DifficultyFallingAsleep", objDementia.DifficultyFallingAsleep);
            objDBManager.AddParameter("MultipleAwakeningsDuringSleep", objDementia.MultipleAwakeningsDuringSleep);
            objDBManager.AddParameter("EarlyMorningAwakening", objDementia.EarlyMorningAwakening);
            objDBManager.AddParameter("Suicidal", objDementia.Suicidal);
            objDBManager.AddParameter("PoorSelfEsteem", objDementia.PoorSelfEsteem);
            objDBManager.AddParameter("Pessimism", objDementia.Pessimism);
            objDBManager.AddParameter("MoodCongruentDelusions", objDementia.MoodCongruentDelusions);

            objDBManager.AddParameter("CreatedDate", objDementia.CreatedDate);
            objDBManager.AddParameter("CreatedById", objDementia.CreatedById);

            objDBManager.ExecuteNonQuery("Dementia_Add");

            objDementia.DementiaId = long.Parse(objDBManager.Parameters[0].Value.ToString());
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return objDementia.DementiaId;
    }

    public int Update(Dementia objDementia, SqlTransaction objSqlTransaction = null)
    {
        DBManager objDBManager = new DBManager(objSqlTransaction);
        int ReturnValue = 0;
        try
        {
            objDBManager.AddParameter("DementiaId", objDementia.DementiaId);

            objDBManager.AddParameter("PracticeId", objDementia.PracticeId);
            objDBManager.AddParameter("ChartId", objDementia.ChartId);
            objDBManager.AddParameter("PatientId", objDementia.PatientId);

            objDBManager.AddParameter("Anxiety", objDementia.Anxiety);
            objDBManager.AddParameter("Sadness", objDementia.Sadness);
            objDBManager.AddParameter("LackOfReaction", objDementia.LackOfReaction);
            objDBManager.AddParameter("Irritability", objDementia.Irritability);
            objDBManager.AddParameter("Agitation", objDementia.Agitation);
            objDBManager.AddParameter("Retardation", objDementia.Retardation);
            objDBManager.AddParameter("MultiplePhysicalComplaints", objDementia.MultiplePhysicalComplaints);
            objDBManager.AddParameter("LossOfInterest", objDementia.LossOfInterest);
            objDBManager.AddParameter("AppetiteLoss", objDementia.AppetiteLoss);
            objDBManager.AddParameter("WeightLoss", objDementia.WeightLoss);
            objDBManager.AddParameter("LackOfEnergy", objDementia.LackOfEnergy);
            objDBManager.AddParameter("DiurnalVariationOfMood", objDementia.DiurnalVariationOfMood);
            objDBManager.AddParameter("DifficultyFallingAsleep", objDementia.DifficultyFallingAsleep);
            objDBManager.AddParameter("MultipleAwakeningsDuringSleep", objDementia.MultipleAwakeningsDuringSleep);
            objDBManager.AddParameter("EarlyMorningAwakening", objDementia.EarlyMorningAwakening);
            objDBManager.AddParameter("Suicidal", objDementia.Suicidal);
            objDBManager.AddParameter("PoorSelfEsteem", objDementia.PoorSelfEsteem);
            objDBManager.AddParameter("Pessimism", objDementia.Pessimism);
            objDBManager.AddParameter("MoodCongruentDelusions", objDementia.MoodCongruentDelusions);

            objDBManager.AddParameter("ModifiedDate", objDementia.ModifiedDate);
            objDBManager.AddParameter("ModifiedById", objDementia.ModifiedById);

            ReturnValue = objDBManager.ExecuteNonQuery("Dementia_Update");
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ReturnValue;
    }

    public DataTable GetDementia(int PracticeId, long ChartId, long PatientId)
    {
        DBManager objDBManager = new DBManager();

        objDBManager.AddParameter("ChartId", ChartId);
        objDBManager.AddParameter("PracticeId", PracticeId);
        objDBManager.AddParameter("PatientId", PatientId);

        return objDBManager.ExecuteDataTable("Dementia_GetDementia");
    }
}