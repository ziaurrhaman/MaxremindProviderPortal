
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

public class PatientDocumentAttachmentsDB
{
    public long Add(PatientDocumentAttachments objPatientDocumentAttachments, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);

            objDBManager.AddParameter("PatientDocumentAttachmentsId", objPatientDocumentAttachments.PatientDocumentAttachmentsId, SqlDbType.BigInt, 8, ParameterDirection.Output);


            objDBManager.AddParameter("DocumentId", objPatientDocumentAttachments.DocumentId);
            objDBManager.AddParameter("DocumentPath", objPatientDocumentAttachments.DocumentPath);
            objDBManager.AddParameter("OriginalFileName", objPatientDocumentAttachments.OriginalFileName);

            objDBManager.AddParameter("CreatedById", objPatientDocumentAttachments.CreatedById);
            objDBManager.AddParameter("CreatedDate", objPatientDocumentAttachments.CreatedDate);
            objDBManager.AddParameter("Deleted", objPatientDocumentAttachments.Deleted);

            objDBManager.ExecuteNonQuery("PatientDocumentAttachments_Add");

            return long.Parse(objDBManager.Parameters[0].Value.ToString());
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int Update(PatientDocumentAttachments objPatientDocumentAttachments, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager();
            
            objDBManager.AddParameter("PatientDocumentAttachmentsId", objPatientDocumentAttachments.PatientDocumentAttachmentsId, SqlDbType.BigInt, 8);
            
            objDBManager.AddParameter("DocumentId", objPatientDocumentAttachments.DocumentId);
            objDBManager.AddParameter("DocumentPath", objPatientDocumentAttachments.DocumentPath);
            objDBManager.AddParameter("OriginalFileName", objPatientDocumentAttachments.OriginalFileName);
            
            objDBManager.AddParameter("ModifiedById", objPatientDocumentAttachments.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objPatientDocumentAttachments.ModifiedDate);
            objDBManager.AddParameter("Deleted", objPatientDocumentAttachments.Deleted);
            
            return objDBManager.ExecuteNonQuery("PatientDocumentAttachments_Update");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable GetByID(long PatientDocumentAttachmentsId, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);

            objDBManager.AddParameter("PatientDocumentAttachmentsId", PatientDocumentAttachmentsId);

            return objDBManager.ExecuteDataTable("PatientDocumentAttachments_GetByID");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable GetByDocumentId(long DocumentId, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);

            objDBManager.AddParameter("DocumentId", DocumentId);

            return objDBManager.ExecuteDataTable("PatientDocumentAttachments_GetByDocumentId");
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
            
            return objDBManager.ExecuteDataSet("PatientDocumentAttachments_GetAllFilter");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}