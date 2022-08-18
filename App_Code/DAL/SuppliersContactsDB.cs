using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for SuppliersContactsDB
/// </summary>
public class SuppliersContactsDB
{
	public SuppliersContactsDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    
    public long Add(SuppliersContacts objSuppliersContacts, SqlTransaction objSqlTransaction = null)
    {
        DBManager objDBManager = new DBManager(objSqlTransaction);
        try
        {
            objDBManager.AddParameter("SuppliersContactsId", objSuppliersContacts.SuppliersContactsId, SqlDbType.Int, 4, ParameterDirection.Output);
            
            objDBManager.AddParameter("SuppliersId", objSuppliersContacts.SuppliersId);
            objDBManager.AddParameter("PracticeId", objSuppliersContacts.PracticeId);
            objDBManager.AddParameter("FirstName", objSuppliersContacts.FirstName);
            objDBManager.AddParameter("LastName", objSuppliersContacts.LastName);
            objDBManager.AddParameter("Reference", objSuppliersContacts.Reference);
            objDBManager.AddParameter("ContactActiveFor", objSuppliersContacts.ContactActiveFor);
            objDBManager.AddParameter("ContactPhone", objSuppliersContacts.ContactPhone);
            objDBManager.AddParameter("ContactSecondaryPhone", objSuppliersContacts.ContactSecondaryPhone);
            objDBManager.AddParameter("FaxNumber", objSuppliersContacts.FaxNumber);
            objDBManager.AddParameter("Email", objSuppliersContacts.Email);
            objDBManager.AddParameter("Address", objSuppliersContacts.Address);
            objDBManager.AddParameter("DocumentLanguage", objSuppliersContacts.DocumentLanguage);
            objDBManager.AddParameter("ContactNotes", objSuppliersContacts.ContactNotes);
            objDBManager.AddParameter("CreatedById", objSuppliersContacts.CreatedById);
            objDBManager.AddParameter("CreatedDate", objSuppliersContacts.CreatedDate);
            
            objDBManager.ExecuteNonQuery("SuppliersContacts_Add");
            objSuppliersContacts.SuppliersContactsId = long.Parse(objDBManager.Parameters[0].Value.ToString());
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return objSuppliersContacts.SuppliersContactsId;
    }
    
    public int Update(SuppliersContacts objSuppliersContacts, SqlTransaction objSqlTransaction = null)
    {
        DBManager objDBManager = new DBManager(objSqlTransaction);
        int ReturnValue = 0;
        try
        {
            objDBManager.AddParameter("SuppliersContactsId", objSuppliersContacts.SuppliersContactsId, SqlDbType.Int, 4);
            
            objDBManager.AddParameter("SuppliersId", objSuppliersContacts.SuppliersId);
            objDBManager.AddParameter("PracticeId", objSuppliersContacts.PracticeId);
            objDBManager.AddParameter("FirstName", objSuppliersContacts.FirstName);
            objDBManager.AddParameter("LastName", objSuppliersContacts.LastName);
            objDBManager.AddParameter("Reference", objSuppliersContacts.Reference);
            objDBManager.AddParameter("ContactActiveFor", objSuppliersContacts.ContactActiveFor);
            objDBManager.AddParameter("ContactPhone", objSuppliersContacts.ContactPhone);
            objDBManager.AddParameter("ContactSecondaryPhone", objSuppliersContacts.ContactSecondaryPhone);
            objDBManager.AddParameter("FaxNumber", objSuppliersContacts.FaxNumber);
            objDBManager.AddParameter("Email", objSuppliersContacts.Email);
            objDBManager.AddParameter("Address", objSuppliersContacts.Address);
            objDBManager.AddParameter("DocumentLanguage", objSuppliersContacts.DocumentLanguage);
            objDBManager.AddParameter("ContactNotes", objSuppliersContacts.ContactNotes);
            objDBManager.AddParameter("ModifiedById", objSuppliersContacts.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objSuppliersContacts.ModifiedDate);
            
            ReturnValue = objDBManager.ExecuteNonQuery("SuppliersContacts_Update");
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ReturnValue;
    }
    
    public int Delete(SuppliersContacts objSuppliersContacts, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);
            objDBManager.AddParameter("SuppliersContactsId", objSuppliersContacts.SuppliersContactsId);
            objDBManager.AddParameter("ModifiedById", objSuppliersContacts.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objSuppliersContacts.ModifiedDate);
            
            return objDBManager.ExecuteNonQuery("SuppliersContacts_Delete");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    
    public DataTable GetByID(long SuppliersContactsId, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);
            objDBManager.AddParameter("SuppliersContactsId", SuppliersContactsId);
            
            return objDBManager.ExecuteDataTable("SuppliersContacts_GetByID");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    
    public DataSet GetAllFilterByPracticeId(long PracticeId, int Rows, int PageNumber, string SortBy, long SuppliersId, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);
            objDBManager.AddParameter("PracticeId", PracticeId);
            objDBManager.AddParameter("Rows", Rows);
            objDBManager.AddParameter("PageNumber", PageNumber);
            objDBManager.AddParameter("SortBy", SortBy);
            
            objDBManager.AddParameter("SuppliersId", SuppliersId);
            
            return objDBManager.ExecuteDataSet("SuppliersContacts_GetAllFilter");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    
    public DataTable GetAllByPracticeId(long PracticeId, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);
            objDBManager.AddParameter("PracticeId", PracticeId);
            
            return objDBManager.ExecuteDataTable("SuppliersContacts_GetAll");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}