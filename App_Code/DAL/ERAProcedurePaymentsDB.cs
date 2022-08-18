using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
/// <summary>
/// Summary description for ProcedurePaymentsDB
/// </summary>
public class ERAProcedurePaymentsDB
{
	public ERAProcedurePaymentsDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public Int64 Add(ERAProcedurePayments objProcedurePayments)
    {

        DBManager objDBManager = new DBManager();


        try
        {
            objDBManager.AddParameter("ERAProcedurePaymentsId", objProcedurePayments.ERAProcedurePaymentsId, SqlDbType.BigInt, 8, ParameterDirection.Output);

            objDBManager.AddParameter("ERAClaimPaymentsId",objProcedurePayments.ERAClaimPaymentsId,SqlDbType.BigInt, 8);
            objDBManager.AddParameter("ProcedureQualifier",objProcedurePayments.ProcedureQualifier,SqlDbType.VarChar, 2);
            objDBManager.AddParameter("ProcedureCode",objProcedurePayments.ProcedureCode,SqlDbType.VarChar, 15);
            objDBManager.AddParameter("ProcedureModifier1",objProcedurePayments.ProcedureModifier1,SqlDbType.VarChar, 2);
            objDBManager.AddParameter("ProcedureModifier2",objProcedurePayments.ProcedureModifier2,SqlDbType.VarChar, 2);
            objDBManager.AddParameter("ProcedureModifier3",objProcedurePayments.ProcedureModifier3,SqlDbType.VarChar, 2);
            objDBManager.AddParameter("ProcedureModifier4",objProcedurePayments.ProcedureModifier4,SqlDbType.VarChar, 2);
            objDBManager.AddParameter("ChargedAmount",objProcedurePayments.ChargedAmount,SqlDbType.Money, 8);
            objDBManager.AddParameter("PaidAmount",objProcedurePayments.PaidAmount,SqlDbType.Money, 8);
            objDBManager.AddParameter("RevenueCode",objProcedurePayments.RevenueCode,SqlDbType.VarChar, 25);
            objDBManager.AddParameter("PaidUnits",objProcedurePayments.PaidUnits,SqlDbType.Float, 8);
            objDBManager.AddParameter("SubmittedProcedureQualifier",objProcedurePayments.SubmittedProcedureQualifier,SqlDbType.VarChar, 2);
            objDBManager.AddParameter("SubmittedProcedure",objProcedurePayments.SubmittedProcedure,SqlDbType.VarChar, 15);
            objDBManager.AddParameter("SubmittedModifier1",objProcedurePayments.SubmittedModifier1,SqlDbType.VarChar, 2);
            objDBManager.AddParameter("SubmittedModifier2",objProcedurePayments.SubmittedModifier2,SqlDbType.VarChar, 2);
            objDBManager.AddParameter("SubmittedModifier3",objProcedurePayments.SubmittedModifier3,SqlDbType.VarChar, 3);
            objDBManager.AddParameter("SubmittedModifier4",objProcedurePayments.SubmittedModifier4,SqlDbType.VarChar, 50);
            objDBManager.AddParameter("OriginalUnits",objProcedurePayments.OriginalUnits,SqlDbType.VarChar, 15);
            objDBManager.AddParameter("ServiceStartDate",objProcedurePayments.ServiceStartDate,SqlDbType.DateTime, 3);
            objDBManager.AddParameter("ServiceEndDate",objProcedurePayments.ServiceEndDate,SqlDbType.DateTime, 3);
            objDBManager.AddParameter("LineItemControlNumber",objProcedurePayments.LineItemControlNumber,SqlDbType.VarChar, 50);
            objDBManager.AddParameter("ReferenceIdQualifier",objProcedurePayments.ReferenceIdQualifier,SqlDbType.VarChar, 3);
            objDBManager.AddParameter("ReferenceId",objProcedurePayments.ReferenceId,SqlDbType.VarChar, 50);
            objDBManager.AddParameter("ServiceAllowedAmount",objProcedurePayments.ServiceAllowedAmount,SqlDbType.Money, 8);
            objDBManager.AddParameter("CreatedById",objProcedurePayments.CreatedById,SqlDbType.BigInt, 8);
            objDBManager.AddParameter("CreatedDate",objProcedurePayments.CreatedDate,SqlDbType.DateTime, 8);
            objDBManager.AddParameter("Deleted",objProcedurePayments.Deleted,SqlDbType.Bit, 1);

            objDBManager.ExecuteNonQuery("ERAProcedurePayments_Add");

            objProcedurePayments.ERAProcedurePaymentsId = Convert.ToInt64(objDBManager.Parameters[0].Value);

        }
        catch (Exception ex)
        {

            throw ex;

        }

        return objProcedurePayments.ERAProcedurePaymentsId;

    }

    public DataTable ProcedurePayments_GetByClaimPaymentId(Int64 ERAClaimPaymentsId)
    {
        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("@ERAClaimPaymentsId", ERAClaimPaymentsId);
        return objDBManager.ExecuteDataTable("ERAProcedurePayments_GetByClaimPaymentId");
    }
}