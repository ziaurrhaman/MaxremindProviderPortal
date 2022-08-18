using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for ItemsDB
/// </summary>
public class ItemsDB
{
	public ItemsDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    
    public long Add(Items objItems, SqlTransaction objSqlTransaction = null)
    {
        DBManager objDBManager = new DBManager(objSqlTransaction);
        try
        {
            objDBManager.AddParameter("ItemsId", objItems.ItemsId, SqlDbType.Int, 4, ParameterDirection.Output);
            
            objDBManager.AddParameter("PracticeId", objItems.PracticeId);
            objDBManager.AddParameter("ItemCode", objItems.ItemCode);
            objDBManager.AddParameter("Name", objItems.Name);
            objDBManager.AddParameter("Description", objItems.Description);
            objDBManager.AddParameter("ItemCategoryId", objItems.ItemCategoryId);
            objDBManager.AddParameter("TaxTypeId", objItems.TaxTypeId);
            objDBManager.AddParameter("ItemType", objItems.ItemType);
            objDBManager.AddParameter("UnitsOfMeasures", objItems.UnitsOfMeasures);
            objDBManager.AddParameter("EditableDescription", objItems.EditableDescription);
            objDBManager.AddParameter("ExcludeFromSale", objItems.ExcludeFromSale);
            objDBManager.AddParameter("StandardCost", objItems.StandardCost);
            objDBManager.AddParameter("DimentionId", objItems.DimentionId);
            objDBManager.AddParameter("SalesAccountId", objItems.SalesAccountId);
            objDBManager.AddParameter("InventoryAccountId", objItems.InventoryAccountId);
            objDBManager.AddParameter("COGSAccountId", objItems.COGSAccountId);
            objDBManager.AddParameter("InventoryAdjustmentsAccountId", objItems.InventoryAdjustmentsAccountId);
            objDBManager.AddParameter("ImagePath", objItems.ImagePath);
            objDBManager.AddParameter("Status", objItems.Status);
            objDBManager.AddParameter("CreatedById", objItems.CreatedById);
            objDBManager.AddParameter("CreatedDate", objItems.CreatedDate);
            
            objDBManager.ExecuteNonQuery("Items_Add");
            
            objItems.ItemsId = long.Parse(objDBManager.Parameters[0].Value.ToString());
        }
        catch (Exception ex)
        {
            throw ex;
        }
        
        return objItems.ItemsId;
    }
    
    public int Update(Items objItems, SqlTransaction objSqlTransaction = null)
    {
        DBManager objDBManager = new DBManager(objSqlTransaction);
        int ReturnValue = 0;
        
        try
        {
            objDBManager.AddParameter("ItemsId", objItems.ItemsId, SqlDbType.Int, 4);
            
            objDBManager.AddParameter("PracticeId", objItems.PracticeId);
            objDBManager.AddParameter("ItemCode", objItems.ItemCode);
            objDBManager.AddParameter("Name", objItems.Name);
            objDBManager.AddParameter("Description", objItems.Description);
            objDBManager.AddParameter("ItemCategoryId", objItems.ItemCategoryId);
            objDBManager.AddParameter("TaxTypeId", objItems.TaxTypeId);
            objDBManager.AddParameter("ItemType", objItems.ItemType);
            objDBManager.AddParameter("UnitsOfMeasures", objItems.UnitsOfMeasures);
            objDBManager.AddParameter("EditableDescription", objItems.EditableDescription);
            objDBManager.AddParameter("ExcludeFromSale", objItems.ExcludeFromSale);
            objDBManager.AddParameter("StandardCost", objItems.StandardCost);
            objDBManager.AddParameter("DimentionId", objItems.DimentionId);
            objDBManager.AddParameter("SalesAccountId", objItems.SalesAccountId);
            objDBManager.AddParameter("InventoryAccountId", objItems.InventoryAccountId);
            objDBManager.AddParameter("COGSAccountId", objItems.COGSAccountId);
            objDBManager.AddParameter("InventoryAdjustmentsAccountId", objItems.InventoryAdjustmentsAccountId);
            objDBManager.AddParameter("ImagePath", objItems.ImagePath);
            objDBManager.AddParameter("Status", objItems.Status);
            objDBManager.AddParameter("ModifiedById", objItems.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objItems.ModifiedDate);
            
            ReturnValue = objDBManager.ExecuteNonQuery("Items_Update");
        }
        catch (Exception ex)
        {
            throw ex;
        }
        
        return ReturnValue;
    }
    
    public int Delete(Items objItems, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);
            objDBManager.AddParameter("ItemsId", objItems.ItemsId);
            objDBManager.AddParameter("ModifiedById", objItems.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objItems.ModifiedDate);
            return objDBManager.ExecuteNonQuery("Items_Delete");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    
    public DataTable GetByID(long ItemsId, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);
            objDBManager.AddParameter("ItemsId", ItemsId, SqlDbType.Int, 4);
            return objDBManager.ExecuteDataTable("Items_GetByID");
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
            
            return objDBManager.ExecuteDataSet("Items_GetAllFilter");
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
            return objDBManager.ExecuteDataTable("Items_GetAll");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable GetAllAutoCompleteByItemCode(long PracticeId, string ItemCode, long SalesTypeId, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);
            objDBManager.AddParameter("PracticeId", PracticeId);
            objDBManager.AddParameter("ItemCode", ItemCode);
            objDBManager.AddParameter("SalesTypeId", SalesTypeId);
            
            return objDBManager.ExecuteDataTable("Items_GetAllAutoCompleteByItemCode");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    
    public DataTable GetAllAutoCompleteByItemName(long PracticeId, string ItemName, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);
            objDBManager.AddParameter("PracticeId", PracticeId);
            objDBManager.AddParameter("ItemName", ItemName);
            
            return objDBManager.ExecuteDataTable("Items_GetAllAutoCompleteByItemName");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable GetPriceInfoById(long ItemsId, long SalesTypeId, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);
            objDBManager.AddParameter("ItemsId", ItemsId);
            objDBManager.AddParameter("SalesTypeId", SalesTypeId);

            return objDBManager.ExecuteDataTable("Items_GetPriceInfoById");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}