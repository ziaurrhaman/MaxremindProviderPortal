using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for ItemPurchasePriceDB
/// </summary>
public class ItemPurchasePriceDB
{
	public ItemPurchasePriceDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public long Add(ItemPurchasePrice objItemPurchasePrice, SqlTransaction objSqlTransaction = null)
    {
        DBManager objDBManager = new DBManager(objSqlTransaction);
        try
        {
            objDBManager.AddParameter("ItemPurchasePriceId", objItemPurchasePrice.ItemPurchasePriceId, SqlDbType.Int, 4, ParameterDirection.Output);
            
            objDBManager.AddParameter("PracticeId", objItemPurchasePrice.PracticeId);
            objDBManager.AddParameter("ItemsId", objItemPurchasePrice.ItemsId);
            objDBManager.AddParameter("SuppliersId", objItemPurchasePrice.SuppliersId);
            objDBManager.AddParameter("PurchasePrice", objItemPurchasePrice.PurchasePrice);
            objDBManager.AddParameter("CurrencyId", objItemPurchasePrice.CurrencyId);
            objDBManager.AddParameter("SuppliersUnitOfMeasure", objItemPurchasePrice.SuppliersUnitOfMeasure);
            objDBManager.AddParameter("ConversionFactor", objItemPurchasePrice.ConversionFactor);
            objDBManager.AddParameter("SupplierCode", objItemPurchasePrice.SupplierCode);
            objDBManager.AddParameter("CreatedById", objItemPurchasePrice.CreatedById);
            objDBManager.AddParameter("CreatedDate", objItemPurchasePrice.CreatedDate);
            
            objDBManager.ExecuteNonQuery("ItemPurchasePrice_Add");
            objItemPurchasePrice.ItemPurchasePriceId = long.Parse(objDBManager.Parameters[0].Value.ToString());
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return objItemPurchasePrice.ItemPurchasePriceId;
    }
    
    public int Update(ItemPurchasePrice objItemPurchasePrice, SqlTransaction objSqlTransaction = null)
    {
        DBManager objDBManager = new DBManager(objSqlTransaction);
        int ReturnValue = 0;
        try
        {
            
            objDBManager.AddParameter("ItemPurchasePriceId", objItemPurchasePrice.ItemPurchasePriceId, SqlDbType.Int, 4);
            
            objDBManager.AddParameter("PracticeId", objItemPurchasePrice.PracticeId);
            objDBManager.AddParameter("ItemsId", objItemPurchasePrice.ItemsId);
            objDBManager.AddParameter("SuppliersId", objItemPurchasePrice.SuppliersId);
            objDBManager.AddParameter("PurchasePrice", objItemPurchasePrice.PurchasePrice);
            objDBManager.AddParameter("CurrencyId", objItemPurchasePrice.CurrencyId);
            objDBManager.AddParameter("SuppliersUnitOfMeasure", objItemPurchasePrice.SuppliersUnitOfMeasure);
            objDBManager.AddParameter("ConversionFactor", objItemPurchasePrice.ConversionFactor);
            objDBManager.AddParameter("SupplierCode", objItemPurchasePrice.SupplierCode);
            objDBManager.AddParameter("ModifiedById", objItemPurchasePrice.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objItemPurchasePrice.ModifiedDate);
            
            ReturnValue = objDBManager.ExecuteNonQuery("ItemPurchasePrice_Update");
        }
        catch (Exception ex)
        {
            throw ex;
        }
        
        return ReturnValue;
    }
    
    public int Delete(ItemPurchasePrice objItemPurchasePrice, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);
            objDBManager.AddParameter("ItemPurchasePriceId", objItemPurchasePrice.ItemPurchasePriceId);
            objDBManager.AddParameter("ModifiedById", objItemPurchasePrice.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objItemPurchasePrice.ModifiedDate);
            
            return objDBManager.ExecuteNonQuery("ItemPurchasePrice_Delete");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    
    public DataTable GetByID(int ItemPurchasePriceId, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);
            objDBManager.AddParameter("ItemPurchasePriceId", ItemPurchasePriceId);
            
            return objDBManager.ExecuteDataTable("ItemPurchasePrice_GetByID");
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
            
            return objDBManager.ExecuteDataSet("ItemPurchasePrice_GetAllFilter");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    
}