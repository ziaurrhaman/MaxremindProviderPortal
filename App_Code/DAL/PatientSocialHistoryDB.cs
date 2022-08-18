using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
/// <summary>
/// Summary description for PatientSocialHistoryDB
/// </summary>
public class PatientSocialHistoryDB
{
	public PatientSocialHistoryDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public Int64 Add(PatientSocialHistory objPatientSocialHistory)
    {

        DBManager objDBManager = new DBManager();


        try
        {
            objDBManager.AddParameter("SocialHistoryId", objPatientSocialHistory.SocialHistoryId, SqlDbType.BigInt, 8, ParameterDirection.Output);

            objDBManager.AddParameter("ChartId", objPatientSocialHistory.ChartId, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("PatientId", objPatientSocialHistory.PatientId, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("MaritalStatus", objPatientSocialHistory.MaritalStatus, SqlDbType.VarChar, 10);
            objDBManager.AddParameter("Children", objPatientSocialHistory.Children, SqlDbType.VarChar, 25);
            objDBManager.AddParameter("Education", objPatientSocialHistory.Education, SqlDbType.VarChar, 50);
            objDBManager.AddParameter("Occupation", objPatientSocialHistory.Occupation, SqlDbType.VarChar, 50);
            objDBManager.AddParameter("SexualOrientation", objPatientSocialHistory.SexualOrientation, SqlDbType.VarChar, 25);
            objDBManager.AddParameter("Exercise", objPatientSocialHistory.Exercise, SqlDbType.VarChar, 25);
            objDBManager.AddParameter("DrugUse", objPatientSocialHistory.DrugUse, SqlDbType.VarChar, 25);
            objDBManager.AddParameter("SeatBelt", objPatientSocialHistory.SeatBelt, SqlDbType.VarChar, 15);
            objDBManager.AddParameter("Exposure", objPatientSocialHistory.Exposure, SqlDbType.VarChar, 15);
            objDBManager.AddParameter("CafeineUse", objPatientSocialHistory.CafeineUse, SqlDbType.Bit, 1);
            objDBManager.AddParameter("CafeineDay", objPatientSocialHistory.CafeineDay, SqlDbType.VarChar, 25);
            objDBManager.AddParameter("AlcoholUse", objPatientSocialHistory.AlcoholUse, SqlDbType.Bit, 1);
            objDBManager.AddParameter("AlcoholDay", objPatientSocialHistory.AlcoholDay, SqlDbType.VarChar, 25);
            objDBManager.AddParameter("AgeAtMenarche", objPatientSocialHistory.AgeAtMenarche, SqlDbType.VarChar, 3);
            objDBManager.AddParameter("LMP", objPatientSocialHistory.LMP, SqlDbType.DateTime, 3);
            objDBManager.AddParameter("Cycle", objPatientSocialHistory.Cycle, SqlDbType.VarChar, 25);
            objDBManager.AddParameter("Flow", objPatientSocialHistory.Flow, SqlDbType.VarChar, 35);
            objDBManager.AddParameter("Gravida", objPatientSocialHistory.Gravida, SqlDbType.VarChar, 2);
            objDBManager.AddParameter("Pregnant", objPatientSocialHistory.Pregnant, SqlDbType.Bit, 1);
            objDBManager.AddParameter("Edd", objPatientSocialHistory.Edd, SqlDbType.DateTime, 3);
            objDBManager.AddParameter("Dysmenomhea", objPatientSocialHistory.Dysmenomhea, SqlDbType.Bit, 1);
            objDBManager.AddParameter("Para", objPatientSocialHistory.Para, SqlDbType.VarChar, 2);
            objDBManager.AddParameter("PracticeId", objPatientSocialHistory.PracticeId, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("CreatedById", objPatientSocialHistory.CreatedById, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("CreatedDate", objPatientSocialHistory.CreatedDate, SqlDbType.DateTime, 8);
            objDBManager.AddParameter("Deleted", objPatientSocialHistory.Deleted, SqlDbType.Bit, 1);

            objDBManager.ExecuteNonQuery("PatientSocialHistory_Add");

            objPatientSocialHistory.SocialHistoryId = Convert.ToInt64 (objDBManager.Parameters[0].Value);

        }
        catch (Exception ex)
        {

            throw ex;

        }

        return objPatientSocialHistory.SocialHistoryId;

    }

    public int Update(PatientSocialHistory objPatientSocialHistory)
    {

        DBManager objDBManager = new DBManager();
        int ReturnValue = 0;

        try
        {

            objDBManager.AddParameter("SocialHistoryId", objPatientSocialHistory.SocialHistoryId, SqlDbType.Int, 8);

            objDBManager.AddParameter("ChartId",objPatientSocialHistory.ChartId, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("PatientId",objPatientSocialHistory.PatientId, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("MaritalStatus",objPatientSocialHistory.MaritalStatus, SqlDbType.VarChar, 10);
            objDBManager.AddParameter("Children",objPatientSocialHistory.Children, SqlDbType.VarChar, 25);
            objDBManager.AddParameter("Education",objPatientSocialHistory.Education, SqlDbType.VarChar, 50);
            objDBManager.AddParameter("Occupation",objPatientSocialHistory.Occupation, SqlDbType.VarChar, 50);
            objDBManager.AddParameter("SexualOrientation",objPatientSocialHistory.SexualOrientation, SqlDbType.VarChar, 25);
            objDBManager.AddParameter("Exercise",objPatientSocialHistory.Exercise, SqlDbType.VarChar, 25);
            objDBManager.AddParameter("DrugUse",objPatientSocialHistory.DrugUse, SqlDbType.VarChar, 25);
            objDBManager.AddParameter("SeatBelt",objPatientSocialHistory.SeatBelt, SqlDbType.VarChar, 15);
            objDBManager.AddParameter("Exposure",objPatientSocialHistory.Exposure, SqlDbType.VarChar, 15);
            objDBManager.AddParameter("CafeineUse",objPatientSocialHistory.CafeineUse, SqlDbType.Bit, 1);
            objDBManager.AddParameter("CafeineDay",objPatientSocialHistory.CafeineDay, SqlDbType.VarChar, 25);
            objDBManager.AddParameter("AlcoholUse",objPatientSocialHistory.AlcoholUse, SqlDbType.Bit, 1);
            objDBManager.AddParameter("AlcoholDay",objPatientSocialHistory.AlcoholDay, SqlDbType.VarChar, 25);
            objDBManager.AddParameter("AgeAtMenarche",objPatientSocialHistory.AgeAtMenarche, SqlDbType.VarChar, 3);
            objDBManager.AddParameter("LMP",objPatientSocialHistory.LMP, SqlDbType.DateTime, 3);
            objDBManager.AddParameter("Cycle",objPatientSocialHistory.Cycle, SqlDbType.VarChar, 25);
            objDBManager.AddParameter("Flow",objPatientSocialHistory.Flow, SqlDbType.VarChar, 35);
            objDBManager.AddParameter("Gravida",objPatientSocialHistory.Gravida, SqlDbType.VarChar, 2);
            objDBManager.AddParameter("Pregnant",objPatientSocialHistory.Pregnant, SqlDbType.Bit, 1);
            objDBManager.AddParameter("Edd",objPatientSocialHistory.Edd, SqlDbType.DateTime, 3);
            objDBManager.AddParameter("Dysmenomhea",objPatientSocialHistory.Dysmenomhea, SqlDbType.Bit, 1);
            objDBManager.AddParameter("Para",objPatientSocialHistory.Para, SqlDbType.VarChar, 2);
            objDBManager.AddParameter("PracticeId",objPatientSocialHistory.PracticeId, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("ModifiedById",objPatientSocialHistory.ModifiedById, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("ModifiedDate",objPatientSocialHistory.ModifiedDate, SqlDbType.DateTime, 8);
            objDBManager.AddParameter("Deleted",objPatientSocialHistory.Deleted, SqlDbType.Bit, 1);

            ReturnValue = objDBManager.ExecuteNonQuery("PatientSocialHistory_Update");


        }
        catch (Exception ex)
        {
            throw ex;

        }

        return ReturnValue;

    }



    public DataTable PatientSocialHistory_GetByChartId(Int64 ChartId, Int64 PatientId)
    {
        DBManager objDbManager = new DBManager();
        if (ChartId != 0)
        {
            objDbManager.AddParameter("ChartId", ChartId);
        }
        objDbManager.AddParameter("PatientId", PatientId);
        return objDbManager.ExecuteDataTable("PatientSocialHistory_GetByChartId");
    }
}