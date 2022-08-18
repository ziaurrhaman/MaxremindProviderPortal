using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for BPRSDB
/// </summary>
public class BPRSDB
{
	public BPRSDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public long Add(BPRS objBPRS, SqlTransaction objSqlTransaction = null)
    {
        DBManager objDBManager = new DBManager(objSqlTransaction);
        try
        {
            objDBManager.AddParameter("BPRSId", objBPRS.BPRSId, SqlDbType.Int, 4, ParameterDirection.Output);

            objDBManager.AddParameter("PracticeId", objBPRS.PracticeId);
            objDBManager.AddParameter("ChartId", objBPRS.ChartId);
            objDBManager.AddParameter("PatientId", objBPRS.PatientId);

            objDBManager.AddParameter("SomaticConcern", objBPRS.SomaticConcern);
            objDBManager.AddParameter("Anxiety", objBPRS.Anxiety);
            objDBManager.AddParameter("EmotionalWithdrawal", objBPRS.EmotionalWithdrawal);
            objDBManager.AddParameter("ConceptualDisorganization", objBPRS.ConceptualDisorganization);
            objDBManager.AddParameter("GuiltFeelings", objBPRS.GuiltFeelings);
            objDBManager.AddParameter("Tension", objBPRS.Tension);
            objDBManager.AddParameter("MannerismsAndPosturing", objBPRS.MannerismsAndPosturing);
            objDBManager.AddParameter("Grandiosity", objBPRS.Grandiosity);
            objDBManager.AddParameter("DepressiveMood", objBPRS.DepressiveMood);
            objDBManager.AddParameter("Hostility", objBPRS.Hostility);
            objDBManager.AddParameter("Suspiciousness", objBPRS.Suspiciousness);
            objDBManager.AddParameter("HallucinatoryBehavior", objBPRS.HallucinatoryBehavior);
            objDBManager.AddParameter("MotorRetardation", objBPRS.MotorRetardation);
            objDBManager.AddParameter("Uncooperativeness", objBPRS.Uncooperativeness);
            objDBManager.AddParameter("UnusualThoughtContent", objBPRS.UnusualThoughtContent);
            objDBManager.AddParameter("BluntedAffect", objBPRS.BluntedAffect);
            objDBManager.AddParameter("Excitement", objBPRS.Excitement);
            objDBManager.AddParameter("Disorientation", objBPRS.Disorientation);

            objDBManager.AddParameter("CreatedDate", objBPRS.CreatedDate);
            objDBManager.AddParameter("CreatedById", objBPRS.CreatedById);

            objDBManager.ExecuteNonQuery("BPRS_Add");

            objBPRS.BPRSId = long.Parse(objDBManager.Parameters[0].Value.ToString());
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return objBPRS.BPRSId;
    }

    public int Update(BPRS objBPRS, SqlTransaction objSqlTransaction = null)
    {
        DBManager objDBManager = new DBManager(objSqlTransaction);
        int ReturnValue = 0;
        try
        {
            objDBManager.AddParameter("BPRSId", objBPRS.BPRSId);

            objDBManager.AddParameter("PracticeId", objBPRS.PracticeId);
            objDBManager.AddParameter("ChartId", objBPRS.ChartId);
            objDBManager.AddParameter("PatientId", objBPRS.PatientId);

            objDBManager.AddParameter("SomaticConcern", objBPRS.SomaticConcern);
            objDBManager.AddParameter("Anxiety", objBPRS.Anxiety);
            objDBManager.AddParameter("EmotionalWithdrawal", objBPRS.EmotionalWithdrawal);
            objDBManager.AddParameter("ConceptualDisorganization", objBPRS.ConceptualDisorganization);
            objDBManager.AddParameter("GuiltFeelings", objBPRS.GuiltFeelings);
            objDBManager.AddParameter("Tension", objBPRS.Tension);
            objDBManager.AddParameter("MannerismsAndPosturing", objBPRS.MannerismsAndPosturing);
            objDBManager.AddParameter("Grandiosity", objBPRS.Grandiosity);
            objDBManager.AddParameter("DepressiveMood", objBPRS.DepressiveMood);
            objDBManager.AddParameter("Hostility", objBPRS.Hostility);
            objDBManager.AddParameter("Suspiciousness", objBPRS.Suspiciousness);
            objDBManager.AddParameter("HallucinatoryBehavior", objBPRS.HallucinatoryBehavior);
            objDBManager.AddParameter("MotorRetardation", objBPRS.MotorRetardation);
            objDBManager.AddParameter("Uncooperativeness", objBPRS.Uncooperativeness);
            objDBManager.AddParameter("UnusualThoughtContent", objBPRS.UnusualThoughtContent);
            objDBManager.AddParameter("BluntedAffect", objBPRS.BluntedAffect);
            objDBManager.AddParameter("Excitement", objBPRS.Excitement);
            objDBManager.AddParameter("Disorientation", objBPRS.Disorientation);

            objDBManager.AddParameter("ModifiedDate", objBPRS.ModifiedDate);
            objDBManager.AddParameter("ModifiedById", objBPRS.ModifiedById);

            ReturnValue = objDBManager.ExecuteNonQuery("BPRS_Update");
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ReturnValue;
    }

    public DataTable GetBPRS(int PracticeId, long ChartId, long PatientId)
    {
        DBManager objDBManager = new DBManager();

        objDBManager.AddParameter("PracticeId", PracticeId);
        objDBManager.AddParameter("ChartId", ChartId);
        objDBManager.AddParameter("PatientId", PatientId);

        return objDBManager.ExecuteDataTable("BPRS_GetBPRS");
    }
}