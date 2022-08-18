using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for ItemTaxTypesDB
/// </summary>
public class ItemTaxTypesDB
{
	public ItemTaxTypesDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    
    public long Add(ItemTaxTypes objItemTaxTypes, SqlTransaction objSqlTransaction = null)
    {
        DBManager objDBManager = new DBManager(objSqlTransaction);
        try
        {
            objDBManager.AddParameter("ItemTaxTypesId", objItemTaxTypes.ItemTaxTypesId, SqlDbType.Int, 4, ParameterDirection.Output);
            
            objDBManager.AddParameter("PracticeId", objItemTaxTypes.PracticeId);
            objDBManager.AddParameter("Name", objItemTaxTypes.Name);
            objDBManager.AddParameter("Rate", objItemTaxTypes.Rate);
            objDBManager.AddParameter("IsFullyTaxExempt", objItemTaxTypes.IsFullyTaxExempt);
            objDBManager.AddParameter("Status", objItemTaxTypes.Status);
            objDBManager.AddParameter("CreatedById", objItemTaxTypes.CreatedById);
            objDBManager.AddParameter("CreatedDate", objItemTaxTypes.CreatedDate);
            
            objDBManager.ExecuteNonQuery("ItemTaxTypes_Add");
            objItemTaxTypes.ItemTaxTypesId = long.Parse(objDBManager.Parameters[0].Value.ToString());
        }
        catch (Exception ex)
        {
            throw ex;
        }
        
        return objItemTaxTypes.ItemTaxTypesId;
    }
    
    public int Update(ItemTaxTypes objItemTaxTypes, SqlTransaction objSqlTransaction = null)
    {
        
        DBManager objDBManager = new DBManager(objSqlTransaction);
        int ReturnValue = 0;
        try
        {
            objDBManager.AddParameter("ItemTaxTypesId", objItemTaxTypes.ItemTaxTypesId, SqlDbType.Int, 4);
            
            objDBManager.AddParameter("PracticeId", objItemTaxTypes.PracticeId);
            objDBManager.AddParameter("Name", objItemTaxTypes.Name);
            objDBManager.AddParameter("Rate", objItemTaxTypes.Rate);
            objDBManager.AddParameter("IsFullyTaxExempt", objItemTaxTypes.IsFullyTaxExempt);
            objDBManager.AddParameter("Status", objItemTaxTypes.Status);
            objDBManager.AddParameter("ModifiedById", objItemTaxTypes.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objItemTaxTypes.ModifiedDate);
            
            ReturnValue = objDBManager.ExecuteNonQuery("ItemTaxTypes_Update");
        }
        catch (Exception ex)
        {
            throw ex;
        }
        
        return ReturnValue;
    }
    
    public int Delete(ItemTaxTypes objItemTaxTypes, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);
            objDBManager.AddParameter("ItemTaxTypesId", objItemTaxTypes.ItemTaxTypesId);
            objDBManager.AddParameter("ModifiedById", objItemTaxTypes.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objItemTaxTypes.ModifiedDate);
            
            return objDBManager.ExecuteNonQuery("ItemTaxTypes_Delete");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    
    public DataTable GetByID(int ItemTaxTypesId, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);
            objDBManager.AddParameter("ItemTaxTypesId", ItemTaxTypesId, SqlDbType.Int, 4);
            
            return objDBManager.ExecuteDataTable("ItemTaxTypes_GetByID");
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
            
            return objDBManager.ExecuteDataSet("ItemTaxTypes_GetAllFilter");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet GetAllByPracticeId(long PracticeId, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);
            objDBManager.AddParameter("PracticeId", PracticeId);

            return objDBManager.ExecuteDataSet("ItemTaxTypes_GetAll");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    
}