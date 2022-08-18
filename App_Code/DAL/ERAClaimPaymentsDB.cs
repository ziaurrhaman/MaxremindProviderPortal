using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
/// <summary>
/// Summary description for ClaimPaymentsDB
/// </summary>
public class ERAClaimPaymentsDB
{
	public ERAClaimPaymentsDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public Int64 Add(ERAClaimPayment objClaimPayments)
    {

        DBManager objDBManager = new DBManager();


        try
        {
            objDBManager.AddParameter("ERAClaimPaymentsId", objClaimPayments.ERAClaimPaymentsId, SqlDbType.BigInt , 8, ParameterDirection.Output);

            objDBManager.AddParameter("ERAPaymentsId",objClaimPayments.ERAPaymentsId,SqlDbType.BigInt, 8);
            objDBManager.AddParameter("ClaimNumber",objClaimPayments.ClaimNumber,SqlDbType.VarChar, 35);
            objDBManager.AddParameter("ClaimStatusCode",objClaimPayments.ClaimStatusCode,SqlDbType.VarChar, 2);
            objDBManager.AddParameter("ClaimCharges",objClaimPayments.ClaimCharges,SqlDbType.Money, 8);
            objDBManager.AddParameter("ClaimPayments",objClaimPayments.ClaimPayments,SqlDbType.Money, 8);
            objDBManager.AddParameter("PatientResponsibility",objClaimPayments.PatientResponsibility,SqlDbType.Money, 8);
            objDBManager.AddParameter("InsurancePlanCode",objClaimPayments.InsurancePlanCode,SqlDbType.VarChar, 25);
            objDBManager.AddParameter("PayerClaimControlNumber",objClaimPayments.PayerClaimControlNumber,SqlDbType.VarChar, 50);
            objDBManager.AddParameter("PatientLastName",objClaimPayments.PatientLastName,SqlDbType.VarChar, 60);
            objDBManager.AddParameter("PatientFirstName",objClaimPayments.PatientFirstName,SqlDbType.VarChar, 35);
            objDBManager.AddParameter("PatientIdQualifier",objClaimPayments.PatientIdQualifier,SqlDbType.VarChar, 2);
            objDBManager.AddParameter("PatientIdNumber",objClaimPayments.PatientIdNumber,SqlDbType.VarChar, 80);
            objDBManager.AddParameter("InsuredLastName",objClaimPayments.InsuredLastName,SqlDbType.VarChar, 60);
            objDBManager.AddParameter("InsuredFirstName",objClaimPayments.InsuredFirstName,SqlDbType.VarChar, 35);
            objDBManager.AddParameter("InsuredIdQualifier",objClaimPayments.InsuredIdQualifier,SqlDbType.VarChar, 2);
            objDBManager.AddParameter("InsuredIdNumber",objClaimPayments.InsuredIdNumber,SqlDbType.VarChar, 80);
            objDBManager.AddParameter("CorrectedLastName",objClaimPayments.CorrectedLastName,SqlDbType.VarChar, 60);
            objDBManager.AddParameter("CorrectedFirstName",objClaimPayments.CorrectedFirstName,SqlDbType.VarChar, 35);
            objDBManager.AddParameter("CorrectedIdNumber",objClaimPayments.CorrectedIdNumber,SqlDbType.VarChar, 80);
            objDBManager.AddParameter("ServiceProviderLastName",objClaimPayments.ServiceProviderLastName,SqlDbType.VarChar, 60);
            objDBManager.AddParameter("ServiceProviderFirstName",objClaimPayments.ServiceProviderFirstName,SqlDbType.VarChar, 35);
            objDBManager.AddParameter("ServiceProviderIdQualifier",objClaimPayments.ServiceProviderIdQualifier,SqlDbType.VarChar, 2);
            objDBManager.AddParameter("ServiceProviderIdCode",objClaimPayments.ServiceProviderIdCode,SqlDbType.VarChar, 80);
            objDBManager.AddParameter("CrossOverPayerName",objClaimPayments.CrossOverPayerName,SqlDbType.VarChar, 60);
            objDBManager.AddParameter("CrossOverIdQualifier",objClaimPayments.CrossOverIdQualifier,SqlDbType.VarChar, 2);
            objDBManager.AddParameter("CrossOverIdCode",objClaimPayments.CrossOverIdCode,SqlDbType.VarChar, 80);
            objDBManager.AddParameter("CorrectedPayerName",objClaimPayments.CorrectedPayerName,SqlDbType.VarChar, 60);
            objDBManager.AddParameter("CorrectedIdQualifier",objClaimPayments.CorrectedIdQualifier,SqlDbType.VarChar, 2);
            objDBManager.AddParameter("CorrectedIdCode",objClaimPayments.CorrectedIdCode,SqlDbType.VarChar, 80);
            objDBManager.AddParameter("OtherSubscriberLastName",objClaimPayments.OtherSubscriberLastName,SqlDbType.VarChar, 60);
            objDBManager.AddParameter("OtherSubscriberFirstName",objClaimPayments.OtherSubscriberFirstName,SqlDbType.VarChar, 35);
            objDBManager.AddParameter("OtherSubscriberId",objClaimPayments.OtherSubscriberId,SqlDbType.VarChar, 80);
            objDBManager.AddParameter("OtherSubscriberIdQualifier",objClaimPayments.OtherSubscriberIdQualifier,SqlDbType.VarChar, 2);
            objDBManager.AddParameter("CoveredDaysVisitCount",objClaimPayments.CoveredDaysVisitCount,SqlDbType.Float, 8);
            objDBManager.AddParameter("PPSOperatingAmount",objClaimPayments.PPSOperatingAmount,SqlDbType.Money, 8);
            objDBManager.AddParameter("PsychiatricDays",objClaimPayments.PsychiatricDays,SqlDbType.Float, 8);
            objDBManager.AddParameter("StatementPeriodStart",objClaimPayments.StatementPeriodStart,SqlDbType.DateTime, 3);
            objDBManager.AddParameter("StatementPeriodEnd",objClaimPayments.StatementPeriodEnd,SqlDbType.DateTime, 3);
            objDBManager.AddParameter("CoverageExpirationDate",objClaimPayments.CoverageExpirationDate,SqlDbType.DateTime, 3);
            objDBManager.AddParameter("ClaimReceiverDate",objClaimPayments.ClaimReceiverDate,SqlDbType.DateTime, 3);
            objDBManager.AddParameter("Deleted",objClaimPayments.Deleted,SqlDbType.Bit, 1);

            objDBManager.ExecuteNonQuery("ERAClaimPayments_Add");

            
            objClaimPayments.ERAClaimPaymentsId = Convert.ToInt64(objDBManager.Parameters[0].Value);

        }
        catch (Exception ex)
        {

            throw ex;

        }

        return objClaimPayments.ERAClaimPaymentsId;

    }

    public DataTable ERAClaimPayments_GetByERAPaymentsId(Int64 ERAClaimPaymentsId)
    {
        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("@ERAPaymentsId", ERAClaimPaymentsId);
        return objDBManager.ExecuteDataTable("ERAClaimPayments_GetByERAPaymentsId");
    }

    public DataSet ERAClaimPayments_GetAllForViewClaims(Int64 ERAMasterId)
    {
        DBManager objDbManager = new DBManager();
        objDbManager.AddParameter("@ERAClaimPaymentsId", ERAMasterId);
        DataSet ds = objDbManager.ExecuteDataSet("ERAClaimPayments_GetAllForViewClaims");
        return ds;

    }

    public DataSet ERAMaster_GetCheckDetails(Int64 ERAMasterId)
    {
        DBManager objDbManager = new DBManager();
        objDbManager.AddParameter("ERAMasterId", ERAMasterId);
        return objDbManager.ExecuteDataSet("ERAMaster_GetCheckDetails");
    }

}           