using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
/// <summary>
/// Summary description for ClaimAdjustmentsDB
/// </summary>
public class ClaimAdjustmentsDB
{
	public ClaimAdjustmentsDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public Int64 Add(ClaimAdjustments objClaimAdjustments)
    {

        DBManager objDBManager = new DBManager();


        try
        {
            objDBManager.AddParameter("ClaimAdjustmentsId", objClaimAdjustments.ClaimAdjustmentsId, SqlDbType.BigInt, 8, ParameterDirection.Output);
            objDBManager.AddParameter("ClaimPaymentId", objClaimAdjustments.ClaimAdjustmentsId, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("ClaimNumber",objClaimAdjustments.ClaimNumber,SqlDbType.BigInt, 8);
            objDBManager.AddParameter("AdjustmentGroupCode",objClaimAdjustments.AdjustmentGroupCode,SqlDbType.VarChar, 2);
            objDBManager.AddParameter("AdjustmentReasonCode",objClaimAdjustments.AdjustmentReasonCode,SqlDbType.VarChar, 5);
            objDBManager.AddParameter("AdjustmentAmount",objClaimAdjustments.AdjustmentAmount,SqlDbType.Money, 8);
            objDBManager.AddParameter("Quantity",objClaimAdjustments.Quantity,SqlDbType.Float, 8);
            objDBManager.AddParameter("CreatedById",objClaimAdjustments.CreatedById,SqlDbType.BigInt, 8);
            objDBManager.AddParameter("CreatedDate",objClaimAdjustments.CreatedDate,SqlDbType.DateTime, 8);
            objDBManager.AddParameter("Deleted",objClaimAdjustments.Deleted,SqlDbType.Bit, 1);

            objDBManager.ExecuteNonQuery("ClaimAdjustments_Add");

            objClaimAdjustments.ClaimAdjustmentsId = (Int64) objDBManager.Parameters[0].Value;

        }
        catch (Exception ex)
        {

            throw ex;

        }

        return objClaimAdjustments.ClaimAdjustmentsId;

    }

    public DataTable ClaimAdjustments_GetByClaimNumber(Int64 ClaimNumber)
    {
        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("@ClaimNumber", ClaimNumber);
        return objDBManager.ExecuteDataTable("ClaimAdjustments_GetByClaimNumber");
    }

    public DataTable ClaimAdjustments_GetByClaimPaymentId(Int64 ClaimPaymentId)
    {
        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("@ClaimPaymentId", ClaimPaymentId);
        return objDBManager.ExecuteDataTable("ClaimAdjustments_GetByClaimPaymentId");
    }

}