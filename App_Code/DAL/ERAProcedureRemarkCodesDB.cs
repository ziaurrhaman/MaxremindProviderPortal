using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
/// <summary>
/// Summary description for ProcedureRemarkCodesDB
/// </summary>
public class ERAProcedureRemarkCodesDB
{
	public ERAProcedureRemarkCodesDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public Int64 Add(ERAProcedureRemarkCodes objProcedureRemarkCodes)
    {

        DBManager objDBManager = new DBManager();


        try
        {
            objDBManager.AddParameter("ERAProcedureRemarkCodeId", objProcedureRemarkCodes.ERAProcedureRemarkCodeId, SqlDbType.BigInt, 8, ParameterDirection.Output);

            objDBManager.AddParameter("ERAProcedurePaymentsId",objProcedureRemarkCodes.ERAProcedurePaymentsId,SqlDbType.BigInt, 8);
            objDBManager.AddParameter("ERAProcedureAdjustmentsId",objProcedureRemarkCodes.ERAProcedureAdjustmentsId,SqlDbType.BigInt, 8);
            objDBManager.AddParameter("RemarkCodeQualifier",objProcedureRemarkCodes.RemarkCodeQualifier,SqlDbType.VarChar, 2);
            objDBManager.AddParameter("RemarkCode",objProcedureRemarkCodes.RemarkCode,SqlDbType.VarChar, 30);
            objDBManager.AddParameter("CreatedById",objProcedureRemarkCodes.CreatedById,SqlDbType.BigInt, 8);
            objDBManager.AddParameter("CreatedDate",objProcedureRemarkCodes.CreatedDate,SqlDbType.DateTime, 8);
            objDBManager.AddParameter("Deleted",objProcedureRemarkCodes.Deleted,SqlDbType.Bit, 1);

            objDBManager.ExecuteNonQuery("ERAProcedureRemarkCodes_Add");

            objProcedureRemarkCodes.ERAProcedureRemarkCodeId = Convert.ToInt64(objDBManager.Parameters[0].Value);

        }
        catch (Exception ex)
        {

            throw ex;

        }

        return objProcedureRemarkCodes.ERAProcedureRemarkCodeId;

    }

    public DataTable ProcedureRemarkCodes_GetByProcedurePaymentId(Int64 ERAProcedurePaymentId)
    {
        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("@ERAProcedurePaymentId", ERAProcedurePaymentId);
        return objDBManager.ExecuteDataTable("ERAProcedureRemarkCodes_GetByProcedurePaymentId");
    }

    public DataTable ProcedureRemarkCodes_GetByProcedureAdjustmentId(Int64 ERAProcedureAdjustmentsId)
    {
        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("@ERAProcedureAdjustmentId", ERAProcedureAdjustmentsId);
        return objDBManager.ExecuteDataTable("ERAProcedureRemarkCodes_GetByProcedureAdjustmentId");
    }
}