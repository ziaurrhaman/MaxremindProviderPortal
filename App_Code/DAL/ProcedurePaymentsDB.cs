using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
/// <summary>
/// Summary description for ProcedurePaymentsDB
/// </summary>
public class ProcedurePaymentsDB
{
	public ProcedurePaymentsDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public Int64 Add(ProcedurePayments objProcedurePayments, decimal AdjustedAmountForClaim = 0)
    {
        DBManager objDBManager = new DBManager();
        
        try
        {
            objDBManager.AddParameter("ProcedurePaymentsId", objProcedurePayments.ProcedurePaymentsId, SqlDbType.BigInt, 4, ParameterDirection.Output);

            objDBManager.AddParameter("ClaimId", objProcedurePayments.ClaimId, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("ClaimNumber", objProcedurePayments.ClaimNumber, SqlDbType.VarChar, 35);

            objDBManager.AddParameter("ClaimChargesId", objProcedurePayments.ClaimChargesId, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("CheckNumber", objProcedurePayments.CheckNumber, SqlDbType.VarChar, 50);
            objDBManager.AddParameter("CheckDate", objProcedurePayments.CheckDate, SqlDbType.DateTime, 3);
            objDBManager.AddParameter("PaymentSource", objProcedurePayments.PaymentSource, SqlDbType.VarChar, 3);
            objDBManager.AddParameter("PaymentMethod", objProcedurePayments.PaymentMethod, SqlDbType.VarChar, 15);

            objDBManager.AddParameter("LineItemNumber", objProcedurePayments.LineItemNumber, SqlDbType.VarChar, 25);
            objDBManager.AddParameter("RevenueCode", objProcedurePayments.RevenueCode, SqlDbType.VarChar, 15);
            objDBManager.AddParameter("ChargedProcedure", objProcedurePayments.ChargedProcedure, SqlDbType.VarChar, 15);
            objDBManager.AddParameter("PaidProcedure", objProcedurePayments.PaidProcedure, SqlDbType.VarChar, 15);
            objDBManager.AddParameter("AllowedAmount", objProcedurePayments.AllowedAmount, SqlDbType.Money, 8);
            objDBManager.AddParameter("PaidAmount", objProcedurePayments.PaidAmount, SqlDbType.Money, 8);
            objDBManager.AddParameter("PaidUnits", objProcedurePayments.PaidUnits, SqlDbType.Float, 8);
            objDBManager.AddParameter("AdjustedAmount", objProcedurePayments.AdjustedAmount, SqlDbType.Money, 8);
            objDBManager.AddParameter("PayerId", objProcedurePayments.PayerId, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("ICN", objProcedurePayments.ICN, SqlDbType.VarChar, 50);
            
            objDBManager.AddParameter("ERAMasterId", objProcedurePayments.ERAMasterId);

            objDBManager.AddParameter("CreatedById", objProcedurePayments.CreatedById, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("CreatedDate", objProcedurePayments.CreatedDate, SqlDbType.DateTime, 8);
            objDBManager.AddParameter("Deleted", objProcedurePayments.Deleted, SqlDbType.Bit, 1);

            if (AdjustedAmountForClaim != 0)
            {
                objDBManager.AddParameter("AdjustedAmountForClaim", AdjustedAmountForClaim);
            }
            
            objDBManager.ExecuteNonQuery("ProcedurePayments_Add");
            
            objProcedurePayments.ProcedurePaymentsId = Convert.ToInt64(objDBManager.Parameters[0].Value);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        
        return objProcedurePayments.ProcedurePaymentsId;
    }

    public int UpdateFromPaymentHistory(ProcedurePayments objProcedurePayments, SqlTransaction objSqlTransaction = null)
    {
        DBManager objDBManager = new DBManager();
        int ReturnValue = 0;
        
        try
        {
            objDBManager.AddParameter("ProcedurePaymentsId", objProcedurePayments.ProcedurePaymentsId);
            
            objDBManager.AddParameter("PaymentSource", objProcedurePayments.PaymentSource);
            
            objDBManager.AddParameter("AllowedAmount", objProcedurePayments.AllowedAmount);
            objDBManager.AddParameter("PaidAmount", objProcedurePayments.PaidAmount);
            
            objDBManager.AddParameter("ERAMasterId", objProcedurePayments.ERAMasterId);
            objDBManager.AddParameter("ClaimId", objProcedurePayments.ClaimId);
            objDBManager.AddParameter("ChargedProcedure", objProcedurePayments.ChargedProcedure);
            
            objDBManager.AddParameter("ModifiedById", objProcedurePayments.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objProcedurePayments.ModifiedDate);
            
            ReturnValue = objDBManager.ExecuteNonQuery("ProcedurePayments_UpdateFromPaymentHistory");
        }
        catch (Exception ex)
        {
            throw ex;
        }
        
        return ReturnValue;
    }
    
    public DataTable ProcedurePayments_GetInsertDataByClaimNumber(Int64 claimNumber)
    {
        DBManager objDbManager = new DBManager();
        objDbManager.AddParameter("ClaimNumber", claimNumber);
        return objDbManager.ExecuteDataTable("ProcedurePayments_GetInsertDataByClaimNumber");
    }

    public DataTable GetClaimChargesId(long ClaimId,long ClaimChargesId, string CPTCode, DateTime? DOS )
    {
        DBManager objDbManager = new DBManager();
        try
        {
            objDbManager.AddParameter("ClaimId", ClaimId);
            objDbManager.AddParameter("ClaimChargesId", ClaimChargesId);
            objDbManager.AddParameter("CPTCode", CPTCode);
            objDbManager.AddParameter("DOS", DOS);

            return objDbManager.ExecuteDataTable("GetClaimChargesId");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet GetPatientPayment(long PatientId)
    {
        DBManager objDbManager = new DBManager();
        try
        {
            objDbManager.AddParameter("PatientId",PatientId );
            return objDbManager.ExecuteDataSet("GetPatientPayment");
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }


}