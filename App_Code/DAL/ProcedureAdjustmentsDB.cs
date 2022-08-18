using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for ProcedureAdjustmentsDB
/// </summary>
public class ProcedureAdjustmentsDB
{
	public ProcedureAdjustmentsDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public long Add(ProcedureAdjustments objProcedureAdjustments, SqlTransaction objSqlTransaction = null)
    {
        DBManager objDBManager = new DBManager(objSqlTransaction);
        try
        {
            objDBManager.AddParameter("ProcedureAdjustmentId", objProcedureAdjustments.ProcedureAdjustmentId, SqlDbType.Int, 4, ParameterDirection.Output);
            
            objDBManager.AddParameter("ClaimId", objProcedureAdjustments.ClaimId);
            
            objDBManager.AddParameter("ProcedurePaymentsId", objProcedureAdjustments.ProcedurePaymentsId);
            objDBManager.AddParameter("GroupCode", objProcedureAdjustments.GroupCode);
            objDBManager.AddParameter("ReasonCode", objProcedureAdjustments.ReasonCode);
            objDBManager.AddParameter("AdjustedUnits", objProcedureAdjustments.AdjustedUnits);
            objDBManager.AddParameter("AdjustedAmount", objProcedureAdjustments.AdjustedAmount);
            objDBManager.AddParameter("RemarkCode1", objProcedureAdjustments.RemarkCode1);
            objDBManager.AddParameter("RemarkCode2", objProcedureAdjustments.RemarkCode2);
            objDBManager.AddParameter("RemarkCode3", objProcedureAdjustments.RemarkCode3);
            objDBManager.AddParameter("RemarkCode4", objProcedureAdjustments.RemarkCode4);
            objDBManager.AddParameter("RemarkCode5", objProcedureAdjustments.RemarkCode5);

            objDBManager.AddParameter("PaymentSource", objProcedureAdjustments.PaymentSource);
            objDBManager.AddParameter("ChargedProcedure", objProcedureAdjustments.ChargedProcedure);

            objDBManager.AddParameter("CreatedById", objProcedureAdjustments.CreatedById);
            objDBManager.AddParameter("CreatedDate", objProcedureAdjustments.CreatedDate);

            objDBManager.ExecuteNonQuery("ProcedureAdjustments_Add");
            objProcedureAdjustments.ProcedureAdjustmentId = long.Parse(objDBManager.Parameters[0].Value.ToString());
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return objProcedureAdjustments.ProcedureAdjustmentId;
    }

    public int UpdateFromPaymentHistory(ProcedureAdjustments objProcedureAdjustments, SqlTransaction objSqlTransaction = null)
    {
        DBManager objDBManager = new DBManager(objSqlTransaction);
        int ReturnValue = 0;
        try
        {
            objDBManager.AddParameter("ProcedureAdjustmentId", objProcedureAdjustments.ProcedureAdjustmentId, SqlDbType.Int, 4);
            
            objDBManager.AddParameter("GroupCode", objProcedureAdjustments.GroupCode);
            objDBManager.AddParameter("ReasonCode", objProcedureAdjustments.ReasonCode);
            objDBManager.AddParameter("AdjustedAmount", objProcedureAdjustments.AdjustedAmount);

            objDBManager.AddParameter("ClaimId", objProcedureAdjustments.ClaimId);
            objDBManager.AddParameter("PaymentSource", objProcedureAdjustments.PaymentSource);
            objDBManager.AddParameter("ChargedProcedure", objProcedureAdjustments.ChargedProcedure);
            
            objDBManager.AddParameter("ModifiedById", objProcedureAdjustments.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objProcedureAdjustments.ModifiedDate);

            ReturnValue = objDBManager.ExecuteNonQuery("ProcedureAdjustments_UpdateFromPaymentHistory");
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ReturnValue;
    }

    public int Delete(ProcedureAdjustments objProcedureAdjustments, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);
            
            objDBManager.AddParameter("ProcedureAdjustmentId", objProcedureAdjustments.ProcedureAdjustmentId);
            objDBManager.AddParameter("ModifiedById", objProcedureAdjustments.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objProcedureAdjustments.ModifiedDate);
            
            return objDBManager.ExecuteNonQuery("ProcedureAdjustments_Delete");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int DeleteMultiple(string strProcedureAdjustmentId, ProcedureAdjustments objProcedureAdjustments, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);

            objDBManager.AddParameter("strProcedureAdjustmentId", strProcedureAdjustmentId);
            objDBManager.AddParameter("ModifiedById", objProcedureAdjustments.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objProcedureAdjustments.ModifiedDate);

            return objDBManager.ExecuteNonQuery("ProcedureAdjustments_DeleteMultiple");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable GetAllByProcedurePayment(long ProcedurePaymentsId)
    {
        DBManager objDBManager = new DBManager();

        objDBManager.AddParameter("ProcedurePaymentsId", ProcedurePaymentsId);

        return objDBManager.ExecuteDataTable("ProcedureAdjustments_GetAllByProcedurePayment");
    }
}