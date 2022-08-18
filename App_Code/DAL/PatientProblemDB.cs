using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
/// <summary>
/// Summary description for PatientProblemDB
/// </summary>
public class PatientProblemDB
{
	public PatientProblemDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public Int64 Add(PatientProblems objPatientProblems)
    {

        DBManager objDBManager = new DBManager();


        try
        {
            objDBManager.AddParameter("ProblemId", objPatientProblems.ProblemId, SqlDbType.BigInt, 8, ParameterDirection.Output);

            objDBManager.AddParameter("ProblemDate",objPatientProblems.ProblemDate);
            objDBManager.AddParameter("Assesment", objPatientProblems.Assesment);
            objDBManager.AddParameter("DiagCode",objPatientProblems.DiagCode, SqlDbType.VarChar, 10);
            objDBManager.AddParameter("PrimaryDiagnosis", objPatientProblems.PrimaryDiagnosis);
            objDBManager.AddParameter("Severity", objPatientProblems.Severity);
            objDBManager.AddParameter("Comments",objPatientProblems.Comments, SqlDbType.VarChar, 500);
            objDBManager.AddParameter("Status",objPatientProblems.Status, SqlDbType.VarChar, 25);
            objDBManager.AddParameter("ResolvedDate",objPatientProblems.ResolvedDate, SqlDbType.DateTime, 8);
            objDBManager.AddParameter("ResolvedBy",objPatientProblems.ResolvedBy, SqlDbType.VarChar, 100);
            objDBManager.AddParameter("PatientId",objPatientProblems.PatientId, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("ChartId",objPatientProblems.ChartId, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("PracticeId",objPatientProblems.PracticeId, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("Chronicity", objPatientProblems.Chronicity);
            objDBManager.AddParameter("CreatedById",objPatientProblems.CreatedById, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("CreatedDate",objPatientProblems.CreatedDate, SqlDbType.DateTime, 8);
            objDBManager.AddParameter("Deleted",objPatientProblems.Deleted, SqlDbType.Bit, 1);

            objDBManager.ExecuteNonQuery("PatientProblems_Add");

            objPatientProblems.ProblemId = Convert.ToInt64(objDBManager.Parameters[0].Value);

        }
        catch (Exception ex)
        {

            throw ex;

        }

        return objPatientProblems.ProblemId;

    }

    public int Update(PatientProblems objPatientProblems)
    {

        DBManager objDBManager = new DBManager();
        int ReturnValue = 0;

        try
        {

            objDBManager.AddParameter("ProblemId", objPatientProblems.ProblemId, SqlDbType.BigInt, 8);

            objDBManager.AddParameter("ProblemDate",objPatientProblems.ProblemDate, SqlDbType.DateTime, 8);
            objDBManager.AddParameter("Assesment", objPatientProblems.Assesment);
            objDBManager.AddParameter("DiagCode",objPatientProblems.DiagCode, SqlDbType.VarChar, 10);
            objDBManager.AddParameter("PrimaryDiagnosis", objPatientProblems.PrimaryDiagnosis);
            objDBManager.AddParameter("Severity", objPatientProblems.Severity);
            objDBManager.AddParameter("Comments",objPatientProblems.Comments, SqlDbType.VarChar, 500);
            objDBManager.AddParameter("Status",objPatientProblems.Status, SqlDbType.VarChar, 25);
            objDBManager.AddParameter("ResolvedDate",objPatientProblems.ResolvedDate, SqlDbType.DateTime, 8);
            objDBManager.AddParameter("ResolvedBy",objPatientProblems.ResolvedBy, SqlDbType.VarChar, 100);
            objDBManager.AddParameter("PatientId",objPatientProblems.PatientId, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("ChartId",objPatientProblems.ChartId, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("PracticeId",objPatientProblems.PracticeId, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("Chronicity", objPatientProblems.Chronicity);
            objDBManager.AddParameter("ModifiedById",objPatientProblems.ModifiedById, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("ModifiedDate",objPatientProblems.ModifiedDate, SqlDbType.DateTime, 8);
            objDBManager.AddParameter("Deleted",objPatientProblems.Deleted, SqlDbType.Bit, 1);

            ReturnValue = objDBManager.ExecuteNonQuery("PatientProblems_Update");


        }
        catch (Exception ex)
        {
            throw ex;

        }

        return ReturnValue;

    }

    public DataTable PatientProblems_GetByChartAndPatientId(long PatientId, long? ChartId)
    {
        DBManager objDbManager = new DBManager();
        objDbManager.AddParameter("PatientId", PatientId);
        objDbManager.AddParameter("ChartId", ChartId);
        return objDbManager.ExecuteDataTable("PatientProblems_GetByChartAndPatientId");
    }

    public DataTable GetByPatientId(Int64 PatientId, string status, string diagCode, string shortDescription, string Chronicity, string ProblemDate, string ResolvedDate, long ChartId)
    {
        DBManager objDbManager = new DBManager();
        objDbManager.AddParameter("PatientId", PatientId);
        if (!string.IsNullOrEmpty(status))
        {
            objDbManager.AddParameter("Status", status);
        }
        if (!string.IsNullOrEmpty(diagCode))
        {
            objDbManager.AddParameter("DiagCode", diagCode);
        }
        if (!string.IsNullOrEmpty(shortDescription))
        {
            objDbManager.AddParameter("ShorterDescription", shortDescription);
        }
        if (!string.IsNullOrEmpty(Chronicity))
        {
            objDbManager.AddParameter("Chronicity", Chronicity);
        }
        if (!string.IsNullOrEmpty(ProblemDate))
        {
            objDbManager.AddParameter("ProblemDate", ProblemDate);
        }
        if (!string.IsNullOrEmpty(ResolvedDate))
        {
            objDbManager.AddParameter("ResolvedDate", ResolvedDate);
        }
        if (ChartId != 0)
        {
            objDbManager.AddParameter("@ChartId", ChartId);
        }
        
        return objDbManager.ExecuteDataTable("PatientProblems_GetByPatientId");
    }

    public void PatientProblem_DeleteByProblemId(Int64 ProblemId)
    {
        DBManager objDbManager = new DBManager();
        objDbManager.AddParameter("@ProblemId", ProblemId);
        objDbManager.ExecuteNonQuery("PatientProblem_DeleteByProblemId");
    }
}