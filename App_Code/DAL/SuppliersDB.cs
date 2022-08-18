using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for SuppliersDB
/// </summary>
public class SuppliersDB
{
	public SuppliersDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public long Add(Suppliers objSuppliers, SqlTransaction objSqlTransaction = null)
    {
        
        DBManager objDBManager = new DBManager(objSqlTransaction);
        try
        {
            objDBManager.AddParameter("SuppliersId", objSuppliers.SuppliersId, SqlDbType.Int, 4, ParameterDirection.Output);
            
            objDBManager.AddParameter("PracticeId", objSuppliers.PracticeId);
            objDBManager.AddParameter("SupplierName", objSuppliers.SupplierName);
            objDBManager.AddParameter("GSTNo", objSuppliers.GSTNo);
            objDBManager.AddParameter("Website", objSuppliers.Website);
            objDBManager.AddParameter("CurrencyId", objSuppliers.CurrencyId);
            objDBManager.AddParameter("OurCustomerNo", objSuppliers.OurCustomerNo);
            objDBManager.AddParameter("BankAccount", objSuppliers.BankAccount);
            objDBManager.AddParameter("BankName", objSuppliers.BankName);
            objDBManager.AddParameter("CreditLimit", objSuppliers.CreditLimit);
            objDBManager.AddParameter("PaymentTerms", objSuppliers.PaymentTerms);
            objDBManager.AddParameter("PricesTaxIncluded", objSuppliers.PricesTaxIncluded);
            objDBManager.AddParameter("PhoneNumber", objSuppliers.PhoneNumber);
            objDBManager.AddParameter("SecondaryPhone", objSuppliers.SecondaryPhone);
            objDBManager.AddParameter("MailingAddress", objSuppliers.MailingAddress);
            objDBManager.AddParameter("PhysicalAddress", objSuppliers.PhysicalAddress);
            objDBManager.AddParameter("City", objSuppliers.City);
            objDBManager.AddParameter("StateCode", objSuppliers.StateCode);
            objDBManager.AddParameter("Zip", objSuppliers.Zip);
            objDBManager.AddParameter("Notes", objSuppliers.Notes);
            objDBManager.AddParameter("Status", objSuppliers.Status);
            objDBManager.AddParameter("CreatedById", objSuppliers.CreatedById);
            objDBManager.AddParameter("CreatedDate", objSuppliers.CreatedDate);
            
            objDBManager.ExecuteNonQuery("Suppliers_Add");
            
            objSuppliers.SuppliersId = long.Parse(objDBManager.Parameters[0].Value.ToString());
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return objSuppliers.SuppliersId;
    }

    public int Update(Suppliers objSuppliers, SqlTransaction objSqlTransaction = null)
    {
        DBManager objDBManager = new DBManager(objSqlTransaction);
        int ReturnValue = 0;
        try
        {
            objDBManager.AddParameter("SuppliersId", objSuppliers.SuppliersId, SqlDbType.Int, 4);

            objDBManager.AddParameter("PracticeId", objSuppliers.PracticeId);
            objDBManager.AddParameter("SupplierName", objSuppliers.SupplierName);
            objDBManager.AddParameter("GSTNo", objSuppliers.GSTNo);
            objDBManager.AddParameter("Website", objSuppliers.Website);
            objDBManager.AddParameter("CurrencyId", objSuppliers.CurrencyId);
            objDBManager.AddParameter("OurCustomerNo", objSuppliers.OurCustomerNo);
            objDBManager.AddParameter("BankAccount", objSuppliers.BankAccount);
            objDBManager.AddParameter("BankName", objSuppliers.BankName);
            objDBManager.AddParameter("CreditLimit", objSuppliers.CreditLimit);
            objDBManager.AddParameter("PaymentTerms", objSuppliers.PaymentTerms);
            objDBManager.AddParameter("PricesTaxIncluded", objSuppliers.PricesTaxIncluded);
            objDBManager.AddParameter("PhoneNumber", objSuppliers.PhoneNumber);
            objDBManager.AddParameter("SecondaryPhone", objSuppliers.SecondaryPhone);
            objDBManager.AddParameter("MailingAddress", objSuppliers.MailingAddress);
            objDBManager.AddParameter("PhysicalAddress", objSuppliers.PhysicalAddress);
            objDBManager.AddParameter("City", objSuppliers.City);
            objDBManager.AddParameter("StateCode", objSuppliers.StateCode);
            objDBManager.AddParameter("Zip", objSuppliers.Zip);
            objDBManager.AddParameter("Notes", objSuppliers.Notes);
            objDBManager.AddParameter("Status", objSuppliers.Status);
            objDBManager.AddParameter("ModifiedById", objSuppliers.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objSuppliers.ModifiedDate);
            
            ReturnValue = objDBManager.ExecuteNonQuery("Suppliers_Update");
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ReturnValue;
    }
    
    public int Delete(Suppliers objSuppliers, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);
            objDBManager.AddParameter("SuppliersId", objSuppliers.SuppliersId);
            objDBManager.AddParameter("ModifiedById", objSuppliers.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objSuppliers.ModifiedDate);
            
            return objDBManager.ExecuteNonQuery("Suppliers_Delete");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    
    public DataTable GetByID(long SuppliersId, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);
            objDBManager.AddParameter("SuppliersId", SuppliersId);
            
            return objDBManager.ExecuteDataTable("Suppliers_GetByID");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    
    public DataSet GetAllFilterByPracticeId(long PracticeId, int Rows, int PageNumber, string SortBy, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);
            objDBManager.AddParameter("PracticeId", PracticeId);
            objDBManager.AddParameter("Rows", Rows);
            objDBManager.AddParameter("PageNumber", PageNumber);
            objDBManager.AddParameter("SortBy", SortBy);
            
            return objDBManager.ExecuteDataSet("Suppliers_GetAllFilter");
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
            
            return objDBManager.ExecuteDataTable("Suppliers_GetAll");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    
    public DataTable GetCurrencyIdByID(long SuppliersId, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);
            objDBManager.AddParameter("SuppliersId", SuppliersId);

            return objDBManager.ExecuteDataTable("Suppliers_GetCurrencyIdByID");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}