using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
/// <summary>
/// Summary description for BalanceSheet
/// </summary>
public class BalanceSheetDB
{

    public DataSet GetByPatient(long PatientId)
    {
        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("PatientId", PatientId);
        return objDBManager.ExecuteDataSet("BalanceSheet_GetByPatient");
    }
    public DataTable GetCashRregisterDetails(string DOS,long patientId)
    {
        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("DOS", DOS);
        objDBManager.AddParameter("PatientId", patientId);
        return objDBManager.ExecuteDataTable("CashRregister_GetDetails");
    }
    public DataTable UpdateClaimPaidAmount(Claim objclaim)
    {
        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("ClaimId", objclaim.ClaimId);
        objDBManager.AddParameter("PaidAmount", objclaim.PatientPaidAmmount);
        objDBManager.AddParameter("ModifiedBy", objclaim.ModifiedById);
        objDBManager.AddParameter("ModifiedDate", objclaim.ModifiedDate);
        return objDBManager.ExecuteDataTable("Claim_UpdateClaimPaidAmount");
    }
    public DataTable GetClaimByDOS(string DOS)
    {
        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("DOS", DOS);
        return objDBManager.ExecuteDataTable("Claim_GetByDOS");
    }
    public int PHRPaymentUpdate(CashRegister objCashRegister, SqlTransaction objSqlTransaction = null)
    {

        DBManager objDBManager = new DBManager(objSqlTransaction);
        int ReturnValue = 0;

        try
        {

            objDBManager.AddParameter("CashRegisterId", objCashRegister.CashRegisterId, SqlDbType.Int, 4);

            objDBManager.AddParameter("PatientId", objCashRegister.PatientId, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("CoPayment", objCashRegister.CoPayment, SqlDbType.Money, 8);
            objDBManager.AddParameter("CoPaymentMethod", objCashRegister.CoPaymentMethod, SqlDbType.VarChar, 50);
            objDBManager.AddParameter("PreviousBalancePayment", objCashRegister.PreviousBalancePayment, SqlDbType.Money, 8);
            objDBManager.AddParameter("PreviousBalancePaymentMethod", objCashRegister.PreviousBalancePaymentMethod, SqlDbType.VarChar, 50);
            objDBManager.AddParameter("VisitPayment", objCashRegister.VisitPayment, SqlDbType.Money, 8);
            objDBManager.AddParameter("VisitPaymentMethod", objCashRegister.VisitPaymentMethod, SqlDbType.VarChar, 50);
            objDBManager.AddParameter("OtherPayment", objCashRegister.OtherPayment, SqlDbType.Money, 8);
            objDBManager.AddParameter("OtherPaymentMethod", objCashRegister.OtherPaymentMethod, SqlDbType.VarChar, 50);
            objDBManager.AddParameter("TotalPayments", objCashRegister.TotalPayments, SqlDbType.Money, 8);
            objDBManager.AddParameter("ModifiedById", objCashRegister.ModifiedById, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("ModifiedDate", objCashRegister.ModifiedDate, SqlDbType.DateTime, 8);
            ReturnValue = objDBManager.ExecuteNonQuery("CashRegister_PHRPaymentUpdate");


        }
        catch (Exception ex)
        {
            throw ex;

        }

        return ReturnValue;

    }
}