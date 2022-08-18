
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

public class PatientInvoiceFilesDB
{
    public long Add(PatientInvoiceFiles objPatientInvoiceFiles, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);

            objDBManager.AddParameter("InvoiceFileId", objPatientInvoiceFiles.InvoiceFileId, SqlDbType.BigInt, 8, ParameterDirection.Output);

            objDBManager.AddParameter("FileName", objPatientInvoiceFiles.FileName);
            objDBManager.AddParameter("PracticeId", objPatientInvoiceFiles.PracticeId);
            objDBManager.AddParameter("FileContents", objPatientInvoiceFiles.FileContents);
            objDBManager.AddParameter("PrintingDate", objPatientInvoiceFiles.PrintingDate);
            objDBManager.AddParameter("MailingDate", objPatientInvoiceFiles.MailingDate);
            objDBManager.AddParameter("MailedBy", objPatientInvoiceFiles.MailedBy);
            objDBManager.AddParameter("PrintedById", objPatientInvoiceFiles.PrintedById);
            objDBManager.AddParameter("CreatedById", objPatientInvoiceFiles.CreatedById);
            objDBManager.AddParameter("CreatedDate", objPatientInvoiceFiles.CreatedDate);

            objDBManager.ExecuteNonQuery("PatientInvoiceFiles_Add");

            return long.Parse(objDBManager.Parameters[0].Value.ToString());
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int Update(PatientInvoiceFiles objPatientInvoiceFiles, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager();

            objDBManager.AddParameter("InvoiceFileId", objPatientInvoiceFiles.InvoiceFileId, SqlDbType.BigInt, 8);

            objDBManager.AddParameter("FileName", objPatientInvoiceFiles.FileName);
            objDBManager.AddParameter("PracticeId", objPatientInvoiceFiles.PracticeId);
            objDBManager.AddParameter("FileContents", objPatientInvoiceFiles.FileContents);
            objDBManager.AddParameter("PrintingDate", objPatientInvoiceFiles.PrintingDate);
            objDBManager.AddParameter("MailingDate", objPatientInvoiceFiles.MailingDate);
            objDBManager.AddParameter("MailedBy", objPatientInvoiceFiles.MailedBy);
            objDBManager.AddParameter("PrintedById", objPatientInvoiceFiles.PrintedById);
            objDBManager.AddParameter("ModifiedById", objPatientInvoiceFiles.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objPatientInvoiceFiles.ModifiedDate);

            return objDBManager.ExecuteNonQuery("PatientInvoiceFiles_Update");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int Delete(PatientInvoiceFiles objPatientInvoiceFiles, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);

            objDBManager.AddParameter("InvoiceFileId", objPatientInvoiceFiles.InvoiceFileId);

            objDBManager.AddParameter("ModifiedById", objPatientInvoiceFiles.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objPatientInvoiceFiles.ModifiedDate);

            return objDBManager.ExecuteNonQuery("PatientInvoiceFiles_Delete");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable GetByID(long InvoiceFileId, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);

            objDBManager.AddParameter("InvoiceFileId", InvoiceFileId);

            return objDBManager.ExecuteDataTable("PatientInvoiceFiles_GetByID");
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

            return objDBManager.ExecuteDataSet("PatientInvoiceFiles_GetAllFilter");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}