using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for CashRegisterDB
/// </summary>
public class CashRegisterDB
{
	public CashRegisterDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public long Add(CashRegister objCashRegister)
    {

        DBManager objDBManager = new DBManager();


        try
        {
            objDBManager.AddParameter("CashRegisterId", objCashRegister.CashRegisterId, SqlDbType.Int, 4, ParameterDirection.Output);

            objDBManager.AddParameter("PatientId", objCashRegister.PatientId, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("PracticeId", objCashRegister.PracticeId, SqlDbType.Int, 4);
            objDBManager.AddParameter("AppointmentId", objCashRegister.AppointmentId, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("CoPayDue", objCashRegister.CoPayDue, SqlDbType.Money, 8);
            objDBManager.AddParameter("CoPayment", objCashRegister.CoPayment, SqlDbType.Money, 8);
            objDBManager.AddParameter("OtherCharges", objCashRegister.OtherCharges, SqlDbType.Money, 8);
            objDBManager.AddParameter("VisitCharges", objCashRegister.VisitCharges, SqlDbType.Money, 8);
            objDBManager.AddParameter("PreviousBalance", objCashRegister.PreviousBalance, SqlDbType.Money, 8);
            objDBManager.AddParameter("PreviousBalancePayment", objCashRegister.PreviousBalancePayment, SqlDbType.Money, 8);
            objDBManager.AddParameter("VisitPayment", objCashRegister.VisitPayment, SqlDbType.Money, 8);
            objDBManager.AddParameter("OtherPayment", objCashRegister.OtherPayment, SqlDbType.Money, 8);
            objDBManager.AddParameter("PreviousBalancePaymentMethod", objCashRegister.PreviousBalancePaymentMethod, SqlDbType.VarChar, 50);
            objDBManager.AddParameter("CoPaymentMethod", objCashRegister.CoPaymentMethod, SqlDbType.VarChar, 50);
            objDBManager.AddParameter("VisitPaymentMethod", objCashRegister.VisitPaymentMethod, SqlDbType.VarChar, 50);
            objDBManager.AddParameter("OtherPaymentMethod", objCashRegister.OtherPaymentMethod, SqlDbType.VarChar, 50);
            objDBManager.AddParameter("PreviousBalanceRefNumber", objCashRegister.PreviousBalanceRefNumber, SqlDbType.VarChar, 50);
            objDBManager.AddParameter("CoPaymentRefNumber", objCashRegister.CoPaymentRefNumber, SqlDbType.VarChar, 50);
            objDBManager.AddParameter("VisitRefNumber", objCashRegister.VisitRefNumber, SqlDbType.VarChar, 50);
            objDBManager.AddParameter("OtherRefNumber", objCashRegister.OtherRefNumber, SqlDbType.VarChar, 50);
            objDBManager.AddParameter("PreviousBalanceNotes", objCashRegister.PreviousBalanceNotes, SqlDbType.VarChar, 500);
            objDBManager.AddParameter("CoPaymentNotes", objCashRegister.CoPaymentNotes, SqlDbType.VarChar, 500);
            objDBManager.AddParameter("VisitNotes", objCashRegister.VisitNotes, SqlDbType.VarChar, 500);
            objDBManager.AddParameter("OtherNotes", objCashRegister.OtherNotes, SqlDbType.VarChar, 500);
            objDBManager.AddParameter("WriteOffAmount", objCashRegister.WriteOffAmount, SqlDbType.Money, 8);
            objDBManager.AddParameter("AdvancePayment", objCashRegister.AdvancePayment, SqlDbType.Money, 8);
            objDBManager.AddParameter("TotalCharges", objCashRegister.TotalCharges, SqlDbType.Money, 8);
            objDBManager.AddParameter("TotalPayments", objCashRegister.TotalPayments, SqlDbType.Money, 8);
            objDBManager.AddParameter("CreatedById", objCashRegister.CreatedById, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("CreatedDate", objCashRegister.CreatedDate, SqlDbType.DateTime, 8);
            objDBManager.AddParameter("Deleted", objCashRegister.Deleted);
            objDBManager.ExecuteNonQuery("CashRegister_Add");

            objCashRegister.CashRegisterId = long.Parse(objDBManager.Parameters[0].Value.ToString());

        }
        catch (Exception ex)
        {

            throw ex;

        }

        return objCashRegister.CashRegisterId;

    }
    public int Update(CashRegister objCashRegister, SqlTransaction objSqlTransaction = null)
    {

        DBManager objDBManager = new DBManager(objSqlTransaction);
        int ReturnValue = 0;

        try
        {

            objDBManager.AddParameter("CashRegisterId", objCashRegister.CashRegisterId, SqlDbType.Int, 4);

            objDBManager.AddParameter("PatientId", objCashRegister.PatientId, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("PracticeId", objCashRegister.PracticeId, SqlDbType.Int, 4);
            objDBManager.AddParameter("AppointmentId", objCashRegister.AppointmentId, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("CoPayDue", objCashRegister.CoPayDue, SqlDbType.Money, 8);
            objDBManager.AddParameter("CoPayment", objCashRegister.CoPayment, SqlDbType.Money, 8);
            objDBManager.AddParameter("CoPaymentMethod", objCashRegister.CoPaymentMethod, SqlDbType.VarChar, 50);
            objDBManager.AddParameter("CoPaymentRefNumber", objCashRegister.CoPaymentRefNumber, SqlDbType.VarChar, 50);
            objDBManager.AddParameter("CoPaymentNotes", objCashRegister.CoPaymentNotes, SqlDbType.VarChar, 500);
            objDBManager.AddParameter("PreviousBalance", objCashRegister.PreviousBalance, SqlDbType.Money, 8);
            objDBManager.AddParameter("PreviousBalancePayment", objCashRegister.PreviousBalancePayment, SqlDbType.Money, 8);
            objDBManager.AddParameter("PreviousBalancePaymentMethod", objCashRegister.PreviousBalancePaymentMethod, SqlDbType.VarChar, 50);
            objDBManager.AddParameter("PreviousBalanceRefNumber", objCashRegister.PreviousBalanceRefNumber, SqlDbType.VarChar, 50);
            objDBManager.AddParameter("PreviousBalanceNotes", objCashRegister.PreviousBalanceNotes, SqlDbType.VarChar, 500);
            objDBManager.AddParameter("VisitCharges", objCashRegister.VisitCharges, SqlDbType.Money, 8);
            objDBManager.AddParameter("VisitPayment", objCashRegister.VisitPayment, SqlDbType.Money, 8);
            objDBManager.AddParameter("VisitPaymentMethod", objCashRegister.VisitPaymentMethod, SqlDbType.VarChar, 50);
            objDBManager.AddParameter("VisitRefNumber", objCashRegister.VisitRefNumber, SqlDbType.VarChar, 50);
            objDBManager.AddParameter("VisitNotes", objCashRegister.VisitNotes, SqlDbType.VarChar, 500);
            objDBManager.AddParameter("OtherCharges", objCashRegister.OtherCharges, SqlDbType.Money, 8);
            objDBManager.AddParameter("OtherPayment", objCashRegister.OtherPayment, SqlDbType.Money, 8);
            objDBManager.AddParameter("OtherPaymentMethod", objCashRegister.OtherPaymentMethod, SqlDbType.VarChar, 50);
            objDBManager.AddParameter("OtherRefNumber", objCashRegister.OtherRefNumber, SqlDbType.VarChar, 50);
            objDBManager.AddParameter("OtherNotes", objCashRegister.OtherNotes, SqlDbType.VarChar, 500);
            objDBManager.AddParameter("WriteOffAmount", objCashRegister.WriteOffAmount, SqlDbType.Money, 8);
            objDBManager.AddParameter("AdvancePayment", objCashRegister.AdvancePayment, SqlDbType.Money, 8);
            objDBManager.AddParameter("TotalCharges", objCashRegister.TotalCharges, SqlDbType.Money, 8);
            objDBManager.AddParameter("TotalPayments", objCashRegister.TotalPayments, SqlDbType.Money, 8);
            objDBManager.AddParameter("ModifiedById", objCashRegister.ModifiedById, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("ModifiedDate", objCashRegister.ModifiedDate, SqlDbType.DateTime, 8);
            ReturnValue = objDBManager.ExecuteNonQuery("CashRegister_Update");


        }
        catch (Exception ex)
        {
            throw ex;

        }

        return ReturnValue;

    }

    public DataTable GetPracticeCheckInRoom(long PracticeId, long PracticeLocationsId)
    {
        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("PracticeId", PracticeId);
        objDBManager.AddParameter("PracticeLocationId", PracticeLocationsId);
        return objDBManager.ExecuteDataTable("CheckInRooms_GetByPracticeId");
    }

    public DataTable GetPatientInformation(long AppointmentId)
    {
        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("AppointmentId", AppointmentId);
        return objDBManager.ExecuteDataTable("CashRegister_GetPatientInformation");
    }


    public DataTable GetPaymentInformation(long CashRegisterId)
    {
        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("CashRegisterId", CashRegisterId);
        return objDBManager.ExecuteDataTable("CashRegister_GetPaymentDetail");
    }
    public DataSet GetByAppointmentID(int CashRegisterId, long PatientId, long AppointmentId)
    {
        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("PatientId", PatientId);
        if (CashRegisterId != 0)
        {
            objDBManager.AddParameter("CashRegisterId", CashRegisterId);
        }
        if (AppointmentId != 0)
        {
            objDBManager.AddParameter("AppointmentId", AppointmentId);
        }
        return objDBManager.ExecuteDataSet("CashRegister_GetByAppointmentID");
    }
    
}