
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

public class EDIProcessedFilesDB
{
    public long Add(EDIProcessedFiles objEDIProcessedFiles, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);

            objDBManager.AddParameter("EDIFilesId", objEDIProcessedFiles.EDIFilesId, SqlDbType.BigInt, 8, ParameterDirection.Output);

            objDBManager.AddParameter("PracticeId", objEDIProcessedFiles.PracticeId);
            objDBManager.AddParameter("LocationId", objEDIProcessedFiles.LocationId);
            objDBManager.AddParameter("FileName", objEDIProcessedFiles.FileName);
            objDBManager.AddParameter("SubmitterId", objEDIProcessedFiles.SubmitterId);
            objDBManager.AddParameter("ReceiverId", objEDIProcessedFiles.ReceiverId);
            objDBManager.AddParameter("FileId", objEDIProcessedFiles.FileId);
            objDBManager.AddParameter("FileCreationDate", objEDIProcessedFiles.FileCreationDate);
            objDBManager.AddParameter("FileCreationTime", objEDIProcessedFiles.FileCreationTime);
            objDBManager.AddParameter("TransactionVersion", objEDIProcessedFiles.TransactionVersion);
            objDBManager.AddParameter("TransactionCode", objEDIProcessedFiles.TransactionCode);
            objDBManager.AddParameter("TransactionType", objEDIProcessedFiles.TransactionType);
            objDBManager.AddParameter("FileProcessDate", objEDIProcessedFiles.FileProcessDate);
            objDBManager.AddParameter("CreatedById", objEDIProcessedFiles.CreatedById);
            objDBManager.AddParameter("CreatedDate", objEDIProcessedFiles.CreatedDate);

            objDBManager.ExecuteNonQuery("EDIProcessedFiles_Add");

            return long.Parse(objDBManager.Parameters[0].Value.ToString());
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int Update(EDIProcessedFiles objEDIProcessedFiles, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager();

            objDBManager.AddParameter("EDIFilesId", objEDIProcessedFiles.EDIFilesId, SqlDbType.BigInt, 8);

            objDBManager.AddParameter("PracticeId", objEDIProcessedFiles.PracticeId);
            objDBManager.AddParameter("LocationId", objEDIProcessedFiles.LocationId);
            objDBManager.AddParameter("FileName", objEDIProcessedFiles.FileName);
            objDBManager.AddParameter("SubmitterId", objEDIProcessedFiles.SubmitterId);
            objDBManager.AddParameter("ReceiverId", objEDIProcessedFiles.ReceiverId);
            objDBManager.AddParameter("FileId", objEDIProcessedFiles.FileId);
            objDBManager.AddParameter("FileCreationDate", objEDIProcessedFiles.FileCreationDate);
            objDBManager.AddParameter("FileCreationTime", objEDIProcessedFiles.FileCreationTime);
            objDBManager.AddParameter("TransactionVersion", objEDIProcessedFiles.TransactionVersion);
            objDBManager.AddParameter("TransactionCode", objEDIProcessedFiles.TransactionCode);
            objDBManager.AddParameter("TransactionType", objEDIProcessedFiles.TransactionType);
            objDBManager.AddParameter("FileProcessDate", objEDIProcessedFiles.FileProcessDate);
            objDBManager.AddParameter("ModifiedById", objEDIProcessedFiles.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objEDIProcessedFiles.ModifiedDate);

            return objDBManager.ExecuteNonQuery("EDIProcessedFiles_Update");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int Delete(EDIProcessedFiles objEDIProcessedFiles, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);

            objDBManager.AddParameter("EDIFilesId", objEDIProcessedFiles.EDIFilesId);

            objDBManager.AddParameter("ModifiedById", objEDIProcessedFiles.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objEDIProcessedFiles.ModifiedDate);

            return objDBManager.ExecuteNonQuery("EDIProcessedFiles_Delete");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable GetByID(long EDIFilesId, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);

            objDBManager.AddParameter("EDIFilesId", EDIFilesId);

            return objDBManager.ExecuteDataTable("EDIProcessedFiles_GetByID");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet GetAllFilter(long PracticeId,string LocationId, string fileName, string submitterId, string fileId, string transactionType, string processDate, 
  int Rows, int PageNumber, string SortBy)
    {
        try
        {
            DBManager objDBManager = new DBManager();

            objDBManager.AddParameter("PracticeId", PracticeId);

            if (!string.IsNullOrEmpty(LocationId))
            {
                objDBManager.AddParameter("LocationId", LocationId);
            }

            objDBManager.AddParameter("fileName", fileName);
            objDBManager.AddParameter("submitterId", submitterId);
            objDBManager.AddParameter("fileId", fileId);
            objDBManager.AddParameter("transactionType", transactionType);
            objDBManager.AddParameter("processDate", processDate);

            objDBManager.AddParameter("Rows", Rows);
            objDBManager.AddParameter("PageNumber", PageNumber);

            if (!string.IsNullOrEmpty(SortBy))
            {
                objDBManager.AddParameter("SortBy", SortBy);
            }

            return objDBManager.ExecuteDataSet("EDIProcessedFiles_GetAllFilter");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable FileAlreadyImported(long practiceId, string FileName, string submitterId, string receiverId, string fileId, string filecreationdate, string filecreationtime, string transactiontype)
    {
        try
        {
            DBManager objDBManager = new DBManager();

            objDBManager.AddParameter("PracticeId", practiceId);

            objDBManager.AddParameter("FileName", FileName);

            objDBManager.AddParameter("SubmitterId", submitterId);
            objDBManager.AddParameter("ReceiverId", receiverId);
            objDBManager.AddParameter("FileId", fileId);
            objDBManager.AddParameter("Filecreationdate", filecreationdate);
            objDBManager.AddParameter("Filecreationtime", filecreationtime);
            objDBManager.AddParameter("Transactiontype", transactiontype);

            return objDBManager.ExecuteDataTable("EDICheckFileImported");

        }
        catch(Exception ex)
        {
            throw ex;
        }

        
    }
}