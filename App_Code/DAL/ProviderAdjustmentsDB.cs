using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
/// <summary>
/// Summary description for ProviderAdjustmentsDB
/// </summary>
public class ProviderAdjustmentsDB
{
	public ProviderAdjustmentsDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public Int64 Add(ProviderAdjustments objProviderAdjustments)
    {

        DBManager objDBManager = new DBManager();


        try
        {
            objDBManager.AddParameter("ProviderAdjustmentsId", objProviderAdjustments.ProviderAdjustmentsId, SqlDbType.BigInt, 8, ParameterDirection.Output);

            objDBManager.AddParameter("ERAId",objProviderAdjustments.ERAId,SqlDbType.BigInt, 8);
            objDBManager.AddParameter("ReferenceId",objProviderAdjustments.ReferenceId,SqlDbType.VarChar, 50);
            objDBManager.AddParameter("ProviderFiscalDate",objProviderAdjustments.ProviderFiscalDate,SqlDbType.DateTime, 8);
            objDBManager.AddParameter("ProviderAdjustmentReasonCode",objProviderAdjustments.ProviderAdjustmentReasonCode,SqlDbType.VarChar, 2);
            objDBManager.AddParameter("ReferenceIdentification",objProviderAdjustments.ReferenceIdentification,SqlDbType.VarChar, 50);
            objDBManager.AddParameter("ProviderAdjustmentAmount",objProviderAdjustments.ProviderAdjustmentAmount,SqlDbType.Money, 8);
            objDBManager.AddParameter("ProviderAdjustmentReasonCode1",objProviderAdjustments.ProviderAdjustmentReasonCode1,SqlDbType.VarChar, 2);
            objDBManager.AddParameter("ReferenceIdentification1",objProviderAdjustments.ReferenceIdentification1,SqlDbType.VarChar, 50);
            objDBManager.AddParameter("ReferenceAdjustmentAmount1",objProviderAdjustments.ReferenceAdjustmentAmount1,SqlDbType.Money, 8);
            objDBManager.AddParameter("ProviderAdjustmentReasonCode2",objProviderAdjustments.ProviderAdjustmentReasonCode2,SqlDbType.VarChar, 2);
            objDBManager.AddParameter("ReferenceIdentification2",objProviderAdjustments.ReferenceIdentification2,SqlDbType.VarChar, 50);
            objDBManager.AddParameter("ProviderAdjustmentAmount2",objProviderAdjustments.ProviderAdjustmentAmount2,SqlDbType.Money, 8);
            objDBManager.AddParameter("ProviderAdjustmentReasonCode3",objProviderAdjustments.ProviderAdjustmentReasonCode3,SqlDbType.VarChar, 2);
            objDBManager.AddParameter("ReferenceIdentification3",objProviderAdjustments.ReferenceIdentification3,SqlDbType.VarChar, 50);
            objDBManager.AddParameter("ProviderAdjustmentAmount3",objProviderAdjustments.ProviderAdjustmentAmount3,SqlDbType.Money, 8);
            objDBManager.AddParameter("CreatedById",objProviderAdjustments.CreatedById,SqlDbType.BigInt, 8);
            objDBManager.AddParameter("CreatedDate",objProviderAdjustments.CreatedDate,SqlDbType.DateTime, 8);
            objDBManager.AddParameter("Deleted",objProviderAdjustments.Deleted,SqlDbType.Bit, 1);

            objDBManager.ExecuteNonQuery("ProviderAdjustments_Add");

            objProviderAdjustments.ProviderAdjustmentsId = Convert.ToInt64(objDBManager.Parameters[0].Value);

        }
        catch (Exception ex)
        {

            throw ex;

        }

        return objProviderAdjustments.ProviderAdjustmentsId;

    }

    public DataTable ProviderAdjustments_GetByERAMasterId(Int64 ERAMasterId)
    {
        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("@ERAMasterId", ERAMasterId);
        return objDBManager.ExecuteDataTable("ProviderAdjustments_GetByERAMasterId");
    }
}