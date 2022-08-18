
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

public class FileDocumentAttachmentsDB
{
    public long Add(FileDocumentAttachments objFileDocumentAttachments, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);

            objDBManager.AddParameter("FileDocumentAttachmentsId", objFileDocumentAttachments.FileDocumentAttachmentsId, SqlDbType.BigInt, 8, ParameterDirection.Output);

            objDBManager.AddParameter("DocumentId", objFileDocumentAttachments.DocumentId);
            objDBManager.AddParameter("DocumentPath", objFileDocumentAttachments.DocumentPath);
            objDBManager.AddParameter("OriginalFileName", objFileDocumentAttachments.OriginalFileName);
            objDBManager.AddParameter("CreatedById", objFileDocumentAttachments.CreatedById);
            objDBManager.AddParameter("CreatedDate", objFileDocumentAttachments.CreatedDate);
            objDBManager.AddParameter("Deleted", objFileDocumentAttachments.Deleted);
            objDBManager.ExecuteNonQuery("FileDocumentAttachments_Add");

            return long.Parse(objDBManager.Parameters[0].Value.ToString());
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int Update(FileDocumentAttachments objFileDocumentAttachments, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager();

            objDBManager.AddParameter("FileDocumentAttachmentsId", objFileDocumentAttachments.FileDocumentAttachmentsId, SqlDbType.BigInt, 8);

            objDBManager.AddParameter("DocumentId", objFileDocumentAttachments.DocumentId);
            objDBManager.AddParameter("DocumentPath", objFileDocumentAttachments.DocumentPath);
            objDBManager.AddParameter("OriginalFileName", objFileDocumentAttachments.OriginalFileName);
            objDBManager.AddParameter("ModifiedById", objFileDocumentAttachments.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objFileDocumentAttachments.ModifiedDate);

            return objDBManager.ExecuteNonQuery("FileDocumentAttachments_Update");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int Delete(FileDocumentAttachments objFileDocumentAttachments, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);

            objDBManager.AddParameter("FileDocumentAttachmentsId", objFileDocumentAttachments.FileDocumentAttachmentsId);

            objDBManager.AddParameter("ModifiedById", objFileDocumentAttachments.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objFileDocumentAttachments.ModifiedDate);

            return objDBManager.ExecuteNonQuery("FileDocumentAttachments_Delete");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable GetByID(long FileDocumentAttachmentsId, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);

            objDBManager.AddParameter("FileDocumentAttachmentsId", FileDocumentAttachmentsId);

            return objDBManager.ExecuteDataTable("FileDocumentAttachments_GetByID");
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

            return objDBManager.ExecuteDataSet("FileDocumentAttachments_GetAllFilter");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}