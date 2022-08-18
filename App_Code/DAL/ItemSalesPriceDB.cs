using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for ItemSalesPriceDB
/// </summary>
public class ItemSalesPriceDB
{
	public ItemSalesPriceDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public long Add(ItemSalesPrice objItemSalesPrice, SqlTransaction objSqlTransaction = null)
    {
        
        DBManager objDBManager = new DBManager(objSqlTransaction);
        try
        {
            objDBManager.AddParameter("ItemSalesPriceId", objItemSalesPrice.ItemSalesPriceId, SqlDbType.Int, 4, ParameterDirection.Output);
            
            objDBManager.AddParameter("ItemsId", objItemSalesPrice.ItemsId);
            objDBManager.AddParameter("PracticeId", objItemSalesPrice.PracticeId);
            objDBManager.AddParameter("CurrencyId", objItemSalesPrice.CurrencyId);
            objDBManager.AddParameter("SalesTypeId", objItemSalesPrice.SalesTypeId);
            objDBManager.AddParameter("ItemPrice", objItemSalesPrice.ItemPrice);
            objDBManager.AddParameter("CreatedById", objItemSalesPrice.CreatedById);
            objDBManager.AddParameter("CreatedDate", objItemSalesPrice.CreatedDate);
            
            objDBManager.ExecuteNonQuery("ItemSalesPrice_Add");
            objItemSalesPrice.ItemSalesPriceId = long.Parse(objDBManager.Parameters[0].Value.ToString());
        }
        catch (Exception ex)
        {
            throw ex;
        }
        
        return objItemSalesPrice.ItemSalesPriceId;
    }
    
    public int Update(ItemSalesPrice objItemSalesPrice, SqlTransaction objSqlTransaction = null)
    {
        DBManager objDBManager = new DBManager(objSqlTransaction);
        int ReturnValue = 0;
        
        try
        {
            objDBManager.AddParameter("ItemSalesPriceId", objItemSalesPrice.ItemSalesPriceId, SqlDbType.Int, 4);
            
            objDBManager.AddParameter("ItemsId", objItemSalesPrice.ItemsId);
            objDBManager.AddParameter("PracticeId", objItemSalesPrice.PracticeId);
            objDBManager.AddParameter("CurrencyId", objItemSalesPrice.CurrencyId);
            objDBManager.AddParameter("SalesTypeId", objItemSalesPrice.SalesTypeId);
            objDBManager.AddParameter("ItemPrice", objItemSalesPrice.ItemPrice);
            objDBManager.AddParameter("ModifiedById", objItemSalesPrice.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objItemSalesPrice.ModifiedDate);
            
            ReturnValue = objDBManager.ExecuteNonQuery("ItemSalesPrice_Update");
        }
        catch (Exception ex)
        {
            throw ex;
        }
        
        return ReturnValue;
    }
    
    public int Delete(ItemSalesPrice objItemSalesPrice, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);
            objDBManager.AddParameter("ItemSalesPriceId", objItemSalesPrice.ItemSalesPriceId);
            objDBManager.AddParameter("ModifiedById", objItemSalesPrice.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objItemSalesPrice.ModifiedDate);
            
            return objDBManager.ExecuteNonQuery("ItemSalesPrice_Delete");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    
    public DataTable GetByID(int ItemSalesPriceId, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);
            objDBManager.AddParameter("ItemSalesPriceId", ItemSalesPriceId);
            
            return objDBManager.ExecuteDataTable("ItemSalesPrice_GetByID");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    
    public DataSet GetAllFilterByPracticeId(long PracticeId, int Rows, int PageNumber, string SortBy, long ItemsId, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);
            objDBManager.AddParameter("PracticeId", PracticeId);
            objDBManager.AddParameter("Rows", Rows);
            objDBManager.AddParameter("PageNumber", PageNumber);
            objDBManager.AddParameter("SortBy", SortBy);
            
            objDBManager.AddParameter("ItemsId", ItemsId);
            
            return objDBManager.ExecuteDataSet("ItemSalesPrice_GetAllFilter");
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

            return objDBManager.ExecuteDataTable("ItemSalesPrice_GetAll");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

}