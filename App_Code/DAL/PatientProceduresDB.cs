using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PatientProceduresDB
/// </summary>
public class PatientProceduresDB
{
	public PatientProceduresDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public long Add(PatientProcedures objPatientProcedures)
    {

        DBManager objDBManager = new DBManager();


        try
        {
            objDBManager.AddParameter("ProcedureId", objPatientProcedures.ProcedureId, SqlDbType.Int, 4, ParameterDirection.Output);

            objDBManager.AddParameter("PatientId", objPatientProcedures.PatientId, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("ChartId", objPatientProcedures.ChartId, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("CPTCode", objPatientProcedures.CPTCode, SqlDbType.VarChar, 15);
            objDBManager.AddParameter("Drug", objPatientProcedures.Drug, SqlDbType.VarChar, 20);
            objDBManager.AddParameter("UnitCode", objPatientProcedures.UnitCode, SqlDbType.VarChar, 50);
            objDBManager.AddParameter("ServiceUnits", objPatientProcedures.ServiceUnits, SqlDbType.Int, 4);
            objDBManager.AddParameter("Modifier1", objPatientProcedures.Modifier1, SqlDbType.VarChar, 5);
            objDBManager.AddParameter("Modifier2", objPatientProcedures.Modifier2, SqlDbType.VarChar, 5);
            objDBManager.AddParameter("Modifier3", objPatientProcedures.Modifier3, SqlDbType.VarChar, 5);
            objDBManager.AddParameter("Modifier4", objPatientProcedures.Modifier4, SqlDbType.VarChar, 5);
            objDBManager.AddParameter("SequenceNumber", objPatientProcedures.SequenceNumber, SqlDbType.Int, 4);
            objDBManager.AddParameter("CreatedDate", objPatientProcedures.CreatedDate, SqlDbType.DateTime, 8);
            objDBManager.AddParameter("CreatedById", objPatientProcedures.CreatedById, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("Deleted", objPatientProcedures.Deleted, SqlDbType.Bit, 1);

            objDBManager.ExecuteNonQuery("PatientProcedures_Add");

            objPatientProcedures.ProcedureId = int.Parse(objDBManager.Parameters[0].Value.ToString());

        }
        catch (Exception ex)
        {

            throw ex;

        }

        return objPatientProcedures.ProcedureId;

    }

    public int Update(PatientProcedures objPatientProcedures)
    {

        DBManager objDBManager = new DBManager();
        int ReturnValue = 0;

        try
        {

            objDBManager.AddParameter("ProcedureId", objPatientProcedures.ProcedureId, SqlDbType.Int, 4);

            objDBManager.AddParameter("PatientId", objPatientProcedures.PatientId, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("ChartId", objPatientProcedures.ChartId, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("CPTCode", objPatientProcedures.CPTCode, SqlDbType.VarChar, 15);
            objDBManager.AddParameter("Drug", objPatientProcedures.Drug, SqlDbType.VarChar, 20);
            objDBManager.AddParameter("UnitCode", objPatientProcedures.UnitCode, SqlDbType.VarChar, 50);
            objDBManager.AddParameter("ServiceUnits", objPatientProcedures.ServiceUnits, SqlDbType.Int, 4);
            objDBManager.AddParameter("Modifier1", objPatientProcedures.Modifier1, SqlDbType.VarChar, 5);
            objDBManager.AddParameter("Modifier2", objPatientProcedures.Modifier2, SqlDbType.VarChar, 5);
            objDBManager.AddParameter("Modifier3", objPatientProcedures.Modifier3, SqlDbType.VarChar, 5);
            objDBManager.AddParameter("Modifier4", objPatientProcedures.Modifier4, SqlDbType.VarChar, 5);
            objDBManager.AddParameter("SequenceNumber", objPatientProcedures.SequenceNumber, SqlDbType.Int, 4);
            objDBManager.AddParameter("ModifiedDate", objPatientProcedures.ModifiedDate, SqlDbType.DateTime, 8);
            objDBManager.AddParameter("ModifiedById", objPatientProcedures.ModifiedById, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("Deleted", objPatientProcedures.Deleted, SqlDbType.Bit, 1);

            ReturnValue = objDBManager.ExecuteNonQuery("PatientProcedures_Update");


        }
        catch (Exception ex)
        {
            throw ex;

        }

        return ReturnValue;

    }

    public void Delete(int ProcedureId)
    {
        try
        {
            DBManager objDBManager = new DBManager();
            objDBManager.AddParameter("ProcedureId", ProcedureId, SqlDbType.Int, 4);
            objDBManager.ExecuteNonQuery("PatientProcedures_Delete");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    public DataTable GetByPatientChartId(long PatientChartId)
    {
        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("ChartId", PatientChartId, SqlDbType.Int, 4);
        return objDBManager.ExecuteDataTable("PatientProcedures_GetByChartId");
    }

}