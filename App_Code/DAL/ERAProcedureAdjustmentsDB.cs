using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
/// <summary>
/// Summary description for ProcedureAdjustmentsDB
/// </summary>
public class ERAProcedureAdjustmentsDB
{
	public ERAProcedureAdjustmentsDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public Int64 Add(ERAProcedureAdjustments objProcedureAdjustments)
    {

        DBManager objDBManager = new DBManager();


        try
        {
            objDBManager.AddParameter("ERAProcedureAdjustmentsId", objProcedureAdjustments.ERAProcedureAdjustmentsId, SqlDbType.BigInt, 8, ParameterDirection.Output);

            objDBManager.AddParameter("ERAProcedurePaymentsId",objProcedureAdjustments.ERAProcedurePaymentsId,SqlDbType.BigInt, 8);
            objDBManager.AddParameter("AdjustmentGroupCode",objProcedureAdjustments.AdjustmentGroupCode,SqlDbType.VarChar, 2);
            objDBManager.AddParameter("AdjustmentReasonCode",objProcedureAdjustments.AdjustmentReasonCode,SqlDbType.VarChar, 5);
            objDBManager.AddParameter("AdjustmentAmount",objProcedureAdjustments.AdjustmentAmount,SqlDbType.Money, 8);
            objDBManager.AddParameter("AdjustedUnits",objProcedureAdjustments.AdjustedUnits,SqlDbType.Float, 8);
            objDBManager.AddParameter("AdjustmentReasonCode1",objProcedureAdjustments.AdjustmentReasonCode1,SqlDbType.VarChar, 5);
            objDBManager.AddParameter("AdjustmentAmount1",objProcedureAdjustments.AdjustmentAmount1,SqlDbType.Money, 8);
            objDBManager.AddParameter("AdjustedUnits1",objProcedureAdjustments.AdjustedUnits1,SqlDbType.Float, 8);
            objDBManager.AddParameter("AdjustmentReasonCode2",objProcedureAdjustments.AdjustmentReasonCode2,SqlDbType.VarChar, 5);
            objDBManager.AddParameter("AdjustmentAmount2",objProcedureAdjustments.AdjustmentAmount2,SqlDbType.Money, 8);
            objDBManager.AddParameter("AdjustmentUnits2",objProcedureAdjustments.AdjustmentUnits2,SqlDbType.Float, 8);
            objDBManager.AddParameter("AdjustmentReasonCode3",objProcedureAdjustments.AdjustmentReasonCode3,SqlDbType.VarChar, 5);
            objDBManager.AddParameter("AdjustmentAmount3",objProcedureAdjustments.AdjustmentAmount3,SqlDbType.Money, 8);
            objDBManager.AddParameter("AdjustmentUnits3",objProcedureAdjustments.AdjustmentUnits3,SqlDbType.Float, 8);
            objDBManager.AddParameter("AdjustmentReasonCode4",objProcedureAdjustments.AdjustmentReasonCode4,SqlDbType.VarChar, 5);
            objDBManager.AddParameter("AdjustmentAmount4",objProcedureAdjustments.AdjustmentAmount4,SqlDbType.Money, 8);
            objDBManager.AddParameter("AdjustmentUnits4",objProcedureAdjustments.AdjustmentUnits4,SqlDbType.Float, 8);
            objDBManager.AddParameter("AdjustmentReasonCode5",objProcedureAdjustments.AdjustmentReasonCode5,SqlDbType.VarChar, 5);
            objDBManager.AddParameter("AdjustmentAmount5",objProcedureAdjustments.AdjustmentAmount5,SqlDbType.Money, 8);
            objDBManager.AddParameter("AdjustmentUnits5",objProcedureAdjustments.AdjustmentUnits5,SqlDbType.Float, 8);
            objDBManager.AddParameter("CreatedById",objProcedureAdjustments.CreatedById,SqlDbType.BigInt, 8);
            objDBManager.AddParameter("CreatedDate",objProcedureAdjustments.CreatedDate,SqlDbType.DateTime, 8);
            
            objDBManager.AddParameter("Deleted",objProcedureAdjustments.Deleted,SqlDbType.Bit, 1);

            objDBManager.ExecuteNonQuery("ERAProcedureAdjustments_Add");

            objProcedureAdjustments.ERAProcedureAdjustmentsId = Convert.ToInt64(objDBManager.Parameters[0].Value);

        }
        catch (Exception ex)
        {

            throw ex;

        }

        return objProcedureAdjustments.ERAProcedureAdjustmentsId;

    }

    public DataTable ProcedureAdjustments_GetByProcedurePaymentId(Int64 ERAProcedurePaymentsId)
    {
        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("@ERAProcedurePaymentId", ERAProcedurePaymentsId);
        return objDBManager.ExecuteDataTable("ERAProcedureAdjustments_GetByProcedurePaymentId");
    }

    public decimal ERAProcedureAdjustment_GetTotalByProcedurePaymentsId(Int64 ERAProcedurePaymentsId)
    {
        DBManager objDbManager = new DBManager();
        objDbManager.AddParameter("ERAProcedurePaymentsId", ERAProcedurePaymentsId);
        return Convert.ToDecimal(objDbManager.ExecuteScalar("ERAProcedureAdjustment_GetTotalByProcedurePaymentsId"));
    }
}