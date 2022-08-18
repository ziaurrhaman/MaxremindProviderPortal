using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
/// <summary>
/// Summary description for PatientFamilyHistoryDB
/// </summary>
public class PatientFamilyHistoryDB
{
	public PatientFamilyHistoryDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public Int64 Add(PatientFamilyHistory objPatientFamilyHistory)
    {

        DBManager objDBManager = new DBManager();


        try
        {
            objDBManager.AddParameter("FamilyHistoryId", objPatientFamilyHistory.FamilyHistoryId, SqlDbType.BigInt, 8, ParameterDirection.Output);
            objDBManager.AddParameter("FirstName", objPatientFamilyHistory.FirstName);
            objDBManager.AddParameter("LastName", objPatientFamilyHistory.LastName);
            objDBManager.AddParameter("ContactNo", objPatientFamilyHistory.ContactNo);
            objDBManager.AddParameter("Relation",objPatientFamilyHistory.Relation, SqlDbType.VarChar, 15);
            objDBManager.AddParameter("Comments",objPatientFamilyHistory.Comments, SqlDbType.VarChar, 250);
            objDBManager.AddParameter("IcdCode",objPatientFamilyHistory.IcdCode, SqlDbType.VarChar, 15);
            objDBManager.AddParameter("PatientId", objPatientFamilyHistory.PatientId, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("ChartId", objPatientFamilyHistory.ChartId, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("PracticeId", objPatientFamilyHistory.PracticeId, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("Resolved", objPatientFamilyHistory.Resolved);
            objDBManager.AddParameter("CreatedById", objPatientFamilyHistory.CreatedById, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("CreatedDate", objPatientFamilyHistory.CreatedDate, SqlDbType.DateTime, 8);
            objDBManager.AddParameter("Deleted", objPatientFamilyHistory.Deleted, SqlDbType.Bit, 1);
            objDBManager.ExecuteNonQuery("PatientFamilyHistory_Add");

            objPatientFamilyHistory.FamilyHistoryId = Convert.ToInt64(objDBManager.Parameters[0].Value);

        }
        catch (Exception ex)
        {

            throw ex;

        }

        return objPatientFamilyHistory.FamilyHistoryId;

    }

    public Int64 Update(PatientFamilyHistory objPatientFamilyHistory)
    {

        DBManager objDBManager = new DBManager();
        int ReturnValue = 0;

        try
        {

            objDBManager.AddParameter("FamilyHistoryId", objPatientFamilyHistory.FamilyHistoryId, SqlDbType.Int, 8);
            objDBManager.AddParameter("FirstName", objPatientFamilyHistory.FirstName);
            objDBManager.AddParameter("LastName", objPatientFamilyHistory.LastName);
            objDBManager.AddParameter("ContactNo", objPatientFamilyHistory.ContactNo);
            objDBManager.AddParameter("Relation",objPatientFamilyHistory.Relation, SqlDbType.VarChar, 15);
            objDBManager.AddParameter("Comments",objPatientFamilyHistory.Comments, SqlDbType.VarChar, 250);
            objDBManager.AddParameter("IcdCode",objPatientFamilyHistory.IcdCode, SqlDbType.VarChar, 15);
            objDBManager.AddParameter("PatientId", objPatientFamilyHistory.PatientId, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("ChartId", objPatientFamilyHistory.ChartId, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("PracticeId", objPatientFamilyHistory.PracticeId, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("Resolved", objPatientFamilyHistory.Resolved);
            objDBManager.AddParameter("ModifiedById",objPatientFamilyHistory.ModifiedById, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("ModifiedDate",objPatientFamilyHistory.ModifiedDate, SqlDbType.DateTime, 8);
            objDBManager.AddParameter("Deleted",objPatientFamilyHistory.Deleted, SqlDbType.Bit, 1);

            ReturnValue = objDBManager.ExecuteNonQuery("PatientFamilyHistory_Update");


        }
        catch (Exception ex)
        {
            throw ex;

        }

        return ReturnValue;

    }

    public DataTable PatientFamilyHistory_GetByChartId(Int64 PatientId, Int64 ChartId)
    {
        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("PatientId", PatientId );
        if (ChartId != 0)
            objDBManager.AddParameter("ChartId", ChartId);
        return objDBManager.ExecuteDataTable("PatientFamilyHistory_GetByChartId");

    }
    public void PatientFamilyHistory_DeleteById(Int64 FamilyHistoryId)
    {
        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("@FamilyHistoryId", FamilyHistoryId);
        objDBManager.ExecuteNonQuery("PatientFamilyHistory_DeleteById");
    }


}