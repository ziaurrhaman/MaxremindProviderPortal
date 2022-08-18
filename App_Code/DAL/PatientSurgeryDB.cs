using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
/// <summary>
/// Summary description for PatientSurgeryDB
/// </summary>
public class PatientSurgeryDB
{
	public PatientSurgeryDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public Int64 Add(PatientSurgeries objPatientSurgeries)
    {

        DBManager objDBManager = new DBManager();


        try
        {
            objDBManager.AddParameter("SurgeryId", objPatientSurgeries, SqlDbType.BigInt, 8, ParameterDirection.Output);

            objDBManager.AddParameter("PatientId",objPatientSurgeries.PatientId, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("ChartId",objPatientSurgeries.ChartId, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("PracticeId",objPatientSurgeries.PracticeId, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("SurgeryDate",objPatientSurgeries.SurgeryDate, SqlDbType.DateTime, 8);
            objDBManager.AddParameter("ProcedureCode",objPatientSurgeries.ProcedureCode, SqlDbType.VarChar, 10);
            objDBManager.AddParameter("Comments",objPatientSurgeries.Comments, SqlDbType.VarChar, 250);
            objDBManager.AddParameter("Deleted",objPatientSurgeries.Deleted, SqlDbType.Bit, 1);
            objDBManager.AddParameter("CreatedById",objPatientSurgeries.CreatedById, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("CreatedDate",objPatientSurgeries.CreatedDate, SqlDbType.DateTime, 8);
            objDBManager.ExecuteNonQuery("PatientSurgeries_Add");

            objPatientSurgeries.SurgeryId = Convert.ToInt64(objDBManager.Parameters[0].Value);
            
        }
        catch (Exception ex)
        {

            throw ex;

        }

        return objPatientSurgeries.SurgeryId;

    }

    public int Update(PatientSurgeries objPatientSurgeries)
    {

        DBManager objDBManager = new DBManager();
        int ReturnValue = 0;

        try
        {

            objDBManager.AddParameter("SurgeryId", objPatientSurgeries.SurgeryId, SqlDbType.BigInt, 8);

            objDBManager.AddParameter("PatientId",objPatientSurgeries.PatientId, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("ChartId",objPatientSurgeries.ChartId, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("PracticeId",objPatientSurgeries.PracticeId, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("SurgeryDate",objPatientSurgeries.SurgeryDate, SqlDbType.DateTime, 8);
            objDBManager.AddParameter("ProcedureCode",objPatientSurgeries.ProcedureCode, SqlDbType.VarChar, 10);
            objDBManager.AddParameter("Comments",objPatientSurgeries.Comments, SqlDbType.VarChar, 250);
            objDBManager.AddParameter("Deleted",objPatientSurgeries.Deleted, SqlDbType.Bit, 1);
            objDBManager.AddParameter("ModifiedById",objPatientSurgeries.ModifiedById, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("ModifiedDate",objPatientSurgeries.ModifiedDate, SqlDbType.DateTime, 8);

            ReturnValue = objDBManager.ExecuteNonQuery("PatientSurgeries_Update");


        }
        catch (Exception ex)
        {
            throw ex;

        }

        return ReturnValue;

    }

    public DataTable PatientSurgeries_GetByChartId(Int64 PatientId, Int64 ChartId)
    {
        DBManager objDbManager = new DBManager();
        objDbManager.AddParameter("ChartId", ChartId);
        objDbManager.AddParameter("PatientId", PatientId);
        return objDbManager.ExecuteDataTable("PatientSurgeries_GetByChartId");
    }

    public void PatientSurgeries_DeleteBySurgeryId(Int64 SurgeryId)
    {
        DBManager objDbManager = new DBManager();
        objDbManager.AddParameter("SurgeryId", SurgeryId);
        objDbManager.ExecuteNonQuery("PatientSurgeries_DeleteBySurgeryId");
    }
}