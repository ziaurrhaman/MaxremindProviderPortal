
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

public class ProcedureRemarkCodesDB
{
    public long Add(ProcedureRemarkCodes objProcedureRemarkCodes, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);

            objDBManager.AddParameter("ProcedureRemarkCodesId", objProcedureRemarkCodes.ProcedureRemarkCodesId, SqlDbType.BigInt, 8, ParameterDirection.Output);

            objDBManager.AddParameter("ProcedurePaymentsId", objProcedureRemarkCodes.ProcedurePaymentsId);
            objDBManager.AddParameter("ClaimId", objProcedureRemarkCodes.ClaimId);
            objDBManager.AddParameter("RemarkCodeQualifier", objProcedureRemarkCodes.RemarkCodeQualifier);
            objDBManager.AddParameter("RemarkCode", objProcedureRemarkCodes.RemarkCode);
            objDBManager.AddParameter("CreatedById", objProcedureRemarkCodes.CreatedById);
            objDBManager.AddParameter("CreatedDate", objProcedureRemarkCodes.CreatedDate);

            objDBManager.ExecuteNonQuery("ProcedureRemarkCodes_Add");

            return long.Parse(objDBManager.Parameters[0].Value.ToString());
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int Update(ProcedureRemarkCodes objProcedureRemarkCodes, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager();

            objDBManager.AddParameter("ProcedureRemarkCodesId", objProcedureRemarkCodes.ProcedureRemarkCodesId, SqlDbType.BigInt, 8);

            objDBManager.AddParameter("ProcedurePaymentsId", objProcedureRemarkCodes.ProcedurePaymentsId);
            objDBManager.AddParameter("ClaimId", objProcedureRemarkCodes.ClaimId);
            objDBManager.AddParameter("RemarkCodeQualifier", objProcedureRemarkCodes.RemarkCodeQualifier);
            objDBManager.AddParameter("RemarkCode", objProcedureRemarkCodes.RemarkCode);
            objDBManager.AddParameter("ModifiedById", objProcedureRemarkCodes.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objProcedureRemarkCodes.ModifiedDate);

            return objDBManager.ExecuteNonQuery("ProcedureRemarkCodes_Update");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int Delete(ProcedureRemarkCodes objProcedureRemarkCodes, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);

            objDBManager.AddParameter("ProcedureRemarkCodesId", objProcedureRemarkCodes.ProcedureRemarkCodesId);

            objDBManager.AddParameter("ModifiedById", objProcedureRemarkCodes.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objProcedureRemarkCodes.ModifiedDate);

            return objDBManager.ExecuteNonQuery("ProcedureRemarkCodes_Delete");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable GetByID(long ProcedureRemarkCodesId, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);

            objDBManager.AddParameter("ProcedureRemarkCodesId", ProcedureRemarkCodesId);

            return objDBManager.ExecuteDataTable("ProcedureRemarkCodes_GetByID");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet GetAllFilter(int Rows, int PageNumber, string SortBy)
    {
        try
        {
            DBManager objDBManager = new DBManager();

            objDBManager.AddParameter("Rows", Rows);
            objDBManager.AddParameter("PageNumber", PageNumber);

            if (!string.IsNullOrEmpty(SortBy))
            {
                objDBManager.AddParameter("SortBy", SortBy);
            }

            return objDBManager.ExecuteDataSet("ProcedureRemarkCodes_GetAllFilter");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}