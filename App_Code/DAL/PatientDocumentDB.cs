using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
/// <summary>
/// Summary description for PatientDocumentDB
/// </summary>
public class PatientDocumentDB
{
    public PatientDocumentDB()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public long Add(PatientDocuments objPatientDocuments)
    {

        DBManager objDBManager = new DBManager();


        try
        {
            objDBManager.AddParameter("DocumentId", objPatientDocuments.DocumentId, SqlDbType.BigInt, 8, ParameterDirection.Output);

            objDBManager.AddParameter("PatientId", objPatientDocuments.PatientId, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("CategoryId", objPatientDocuments.CategoryId, SqlDbType.Int, 4);
            objDBManager.AddParameter("Status", objPatientDocuments.Status, SqlDbType.VarChar, 50);
            objDBManager.AddParameter("DocumentDate", objPatientDocuments.DocumentDate, SqlDbType.DateTime, 8);
            objDBManager.AddParameter("IsConfedential", objPatientDocuments.IsConfedential, SqlDbType.Bit, 1);
            objDBManager.AddParameter("DocumentName", objPatientDocuments.DocumentName, SqlDbType.VarChar, 250);
            objDBManager.AddParameter("DocumentPath", objPatientDocuments.DocumentPath, SqlDbType.VarChar, 250);
            objDBManager.AddParameter("AssignedTo", objPatientDocuments.AssignedTo, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("Signed", objPatientDocuments.Signed, SqlDbType.Bit, 1);
            objDBManager.AddParameter("SignedById", objPatientDocuments.SignedById, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("SignDate", objPatientDocuments.SignDate, SqlDbType.DateTime, 8);
            objDBManager.AddParameter("Comments", objPatientDocuments.Comments, SqlDbType.VarChar, 1000);
            objDBManager.AddParameter("CreatedById", objPatientDocuments.CreatedById, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("CreatedDate", objPatientDocuments.CreatedDate, SqlDbType.DateTime, 8);
            objDBManager.AddParameter("Deleted", objPatientDocuments.Deleted, SqlDbType.Bit, 1);

            objDBManager.ExecuteNonQuery("PatientDocuments_Add");

            objPatientDocuments.DocumentId = Convert.ToInt64(objDBManager.Parameters[0].Value);

        }
        catch (Exception ex)
        {

            throw ex;

        }

        return objPatientDocuments.DocumentId;

    }

    public int Update(PatientDocuments objPatientDocuments)
    {

        DBManager objDBManager = new DBManager();
        int ReturnValue = 0;

        try
        {
            objDBManager.AddParameter("DocumentId", objPatientDocuments.DocumentId, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("PatientId", objPatientDocuments.PatientId, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("CategoryId", objPatientDocuments.CategoryId, SqlDbType.Int, 4);
            objDBManager.AddParameter("Status", objPatientDocuments.Status, SqlDbType.VarChar, 50);
            objDBManager.AddParameter("DocumentDate", objPatientDocuments.DocumentDate, SqlDbType.DateTime, 8);
            objDBManager.AddParameter("IsConfedential", objPatientDocuments.IsConfedential, SqlDbType.Bit, 1);
            objDBManager.AddParameter("DocumentName", objPatientDocuments.DocumentName, SqlDbType.VarChar, 250);
            objDBManager.AddParameter("DocumentPath", objPatientDocuments.DocumentPath, SqlDbType.VarChar, 250);
            objDBManager.AddParameter("AssignedTo", objPatientDocuments.AssignedTo, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("Signed", objPatientDocuments.Signed, SqlDbType.Bit, 1);
            objDBManager.AddParameter("SignedById", objPatientDocuments.SignedById, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("SignDate", objPatientDocuments.SignDate, SqlDbType.DateTime, 8);
            objDBManager.AddParameter("Comments", objPatientDocuments.Comments, SqlDbType.VarChar, 1000);

            objDBManager.AddParameter("ModifiedById", objPatientDocuments.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objPatientDocuments.ModifiedDate);
            objDBManager.AddParameter("Deleted", objPatientDocuments.Deleted, SqlDbType.Bit, 1);

            ReturnValue = objDBManager.ExecuteNonQuery("PatientDocuments_Update");
        }
        catch (Exception ex)
        {
            throw ex;

        }
        return ReturnValue;

    }

    public void Delete(PatientDocuments objPatientDocuments)
    {
        DBManager objDBManager = new DBManager();

        objDBManager.AddParameter("DocumentId", objPatientDocuments.DocumentId);

        objDBManager.AddParameter("ModifiedById", objPatientDocuments.ModifiedById);
        objDBManager.AddParameter("ModifiedDate", DateTime.Now);

        objDBManager.ExecuteNonQuery("PatientDocuments_Delete");
    }

    public DataSet GetByID(long DocumentId)
    {
        DBManager objDbManager = new DBManager();

        objDbManager.AddParameter("DocumentId", DocumentId);

        return objDbManager.ExecuteDataSet("PatientDocument_GetByID");
    }

    public DataTable PatientDocument_GetAll(long PatientId)
    {
        DBManager objDbManager = new DBManager();

        objDbManager.AddParameter("PatientId", PatientId);

        return objDbManager.ExecuteDataTable("PatientDocument_GetAll");
    }
    
    public DataSet FilterPatientDocuments(long PatientId, string Name, string Date, string Category, int Rows, int PageNumber, string SortBy, string PatientName, string ProviderName)
    {
        DBManager objDBManager = new DBManager();
        
        objDBManager.AddParameter("Rows", Rows);
        objDBManager.AddParameter("PageNumber", PageNumber);
        objDBManager.AddParameter("SortBy", SortBy);
        
        if (PatientId != 0)
        {
            objDBManager.AddParameter("PatientId", PatientId);
        }
        
        if (!string.IsNullOrEmpty(Name))
        {
            objDBManager.AddParameter("Name", Name);
        }
        
        if (!string.IsNullOrEmpty(Date))
        {
            objDBManager.AddParameter("Date", Convert.ToDateTime(Date));
        }
        
        if (!string.IsNullOrEmpty(Category))
        {
            objDBManager.AddParameter("Category", Category);
        }
        
        if (!string.IsNullOrEmpty(ProviderName))
        {
            objDBManager.AddParameter("ServiceProvider", ProviderName);
        }
        
        if (!string.IsNullOrEmpty(PatientName))
        {
            objDBManager.AddParameter("PatientName", PatientName);
        }
        
        return objDBManager.ExecuteDataSet("Patient_GetPatientDocumentsBySearchCriteria");
    }

    public void AssignDocumentToPatient(PatientDocuments objPatientDocuments)
    {
        DBManager objDBManager = new DBManager();
        try
        {
            objDBManager.AddParameter("DocumentId", objPatientDocuments.DocumentId);
            objDBManager.AddParameter("PatientId", objPatientDocuments.PatientId);

            objDBManager.AddParameter("ModifiedById", objPatientDocuments.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objPatientDocuments.ModifiedDate);

            objDBManager.ExecuteNonQuery("PatientDocuments_AssignDocumentToPatient");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}