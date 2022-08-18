using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for PracticeDocumentsDB
/// </summary>
public class PracticeDocumentsDB
{
	public PracticeDocumentsDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public long Add(PracticeDocuments objPracticeDocuments, SqlTransaction objSqlTransaction = null)
    {
        DBManager objDBManager = new DBManager(objSqlTransaction);
        try
        {
            objDBManager.AddParameter("PracticeDocumentsId", objPracticeDocuments.PracticeDocumentsId, SqlDbType.Int, 4, ParameterDirection.Output);

            objDBManager.AddParameter("PracticeId", objPracticeDocuments.PracticeId);
            objDBManager.AddParameter("PracticeDocumentsCatagoriesId", objPracticeDocuments.PracticeDocumentsCatagoriesId);
            objDBManager.AddParameter("DocumentDate", objPracticeDocuments.DocumentDate);
            objDBManager.AddParameter("DocumentType", objPracticeDocuments.DocumentType);
            objDBManager.AddParameter("DocumentName", objPracticeDocuments.DocumentName);
            objDBManager.AddParameter("DocumentUploadedName", objPracticeDocuments.DocumentUploadedName);
            objDBManager.AddParameter("CreatedById", objPracticeDocuments.CreatedById);
            objDBManager.AddParameter("CreatedDate", objPracticeDocuments.CreatedDate);

            objDBManager.ExecuteNonQuery("PracticeDocuments_Add");
            objPracticeDocuments.PracticeDocumentsId = long.Parse(objDBManager.Parameters[0].Value.ToString());
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return objPracticeDocuments.PracticeDocumentsId;
    }

    public int Update(PracticeDocuments objPracticeDocuments, SqlTransaction objSqlTransaction = null)
    {
        DBManager objDBManager = new DBManager(objSqlTransaction);
        int ReturnValue = 0;
        try
        {
            objDBManager.AddParameter("PracticeDocumentsId", objPracticeDocuments.PracticeDocumentsId, SqlDbType.Int, 4);

            objDBManager.AddParameter("PracticeId", objPracticeDocuments.PracticeId);
            objDBManager.AddParameter("PracticeDocumentsCatagoriesId", objPracticeDocuments.PracticeDocumentsCatagoriesId);
            objDBManager.AddParameter("DocumentDate", objPracticeDocuments.DocumentDate);
            objDBManager.AddParameter("DocumentType", objPracticeDocuments.DocumentType);
            objDBManager.AddParameter("DocumentName", objPracticeDocuments.DocumentName);
            objDBManager.AddParameter("DocumentUploadedName", objPracticeDocuments.DocumentUploadedName);
            objDBManager.AddParameter("ModifiedById", objPracticeDocuments.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objPracticeDocuments.ModifiedDate);

            ReturnValue = objDBManager.ExecuteNonQuery("PracticeDocuments_Update");
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ReturnValue;
    }

    public int Delete(PracticeDocuments objPracticeDocuments, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);

            objDBManager.AddParameter("PracticeDocumentsId", objPracticeDocuments.PracticeDocumentsId);
            objDBManager.AddParameter("ModifiedById", objPracticeDocuments.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objPracticeDocuments.ModifiedDate);

            return objDBManager.ExecuteNonQuery("PracticeDocuments_Delete");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int DeleteByPracticeDocumentsCatagories(PracticeDocuments objPracticeDocuments, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);

            objDBManager.AddParameter("PracticeDocumentsCatagoriesId", objPracticeDocuments.PracticeDocumentsCatagoriesId);
            objDBManager.AddParameter("ModifiedById", objPracticeDocuments.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objPracticeDocuments.ModifiedDate);

            return objDBManager.ExecuteNonQuery("PracticeDocuments_DeleteByPracticeDocumentsCatagories");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable GetAllByPracticeDocumentsCatagories(long PracticeDocumentsCatagoriesId, long PracticeId, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);

            objDBManager.AddParameter("PracticeDocumentsCatagoriesId", PracticeDocumentsCatagoriesId);
            objDBManager.AddParameter("PracticeId", PracticeId);

            return objDBManager.ExecuteDataTable("PracticeDocuments_GetAllByPracticeDocumentsCatagories");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable GetByID(long PracticeDocumentsId, long PracticeId, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);

            objDBManager.AddParameter("PracticeDocumentsId", PracticeDocumentsId);
            objDBManager.AddParameter("PracticeId", PracticeId);

            return objDBManager.ExecuteDataTable("PracticeDocuments_GetByID");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}