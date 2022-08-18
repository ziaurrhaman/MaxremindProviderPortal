using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for ItemCategoriesDB
/// </summary>
public class ItemCategoriesDB
{
	public ItemCategoriesDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public long Add(ItemCategories objItemCategories, SqlTransaction objSqlTransaction = null)
    {

        DBManager objDBManager = new DBManager(objSqlTransaction);
        try
        {
            objDBManager.AddParameter("ItemCategoriesId", objItemCategories.ItemCategoriesId, SqlDbType.Int, 4, ParameterDirection.Output);

            objDBManager.AddParameter("PracticeId", objItemCategories.PracticeId);
            objDBManager.AddParameter("Name", objItemCategories.Name);
            objDBManager.AddParameter("ItemTaxTypesId", objItemCategories.ItemTaxTypesId);
            objDBManager.AddParameter("ItemType", objItemCategories.ItemType);
            objDBManager.AddParameter("UnitsOfMeasures", objItemCategories.UnitsOfMeasures);
            objDBManager.AddParameter("ExcludeFromSale", objItemCategories.ExcludeFromSale);
            objDBManager.AddParameter("DimentionId", objItemCategories.DimentionId);
            objDBManager.AddParameter("SalesAccountId", objItemCategories.SalesAccountId);
            objDBManager.AddParameter("InventoryAccountId", objItemCategories.InventoryAccountId);
            objDBManager.AddParameter("COGSAccountId", objItemCategories.COGSAccountId);
            objDBManager.AddParameter("InventoryAdjustmentsAccountId", objItemCategories.InventoryAdjustmentsAccountId);
            objDBManager.AddParameter("ItemAssemblyCostsAccountId", objItemCategories.ItemAssemblyCostsAccountId);
            objDBManager.AddParameter("Status", objItemCategories.Status);
            objDBManager.AddParameter("CreatedById", objItemCategories.CreatedById);
            objDBManager.AddParameter("CreatedDate", objItemCategories.CreatedDate);
            
            objDBManager.ExecuteNonQuery("ItemCategories_Add");

            objItemCategories.ItemCategoriesId = long.Parse(objDBManager.Parameters[0].Value.ToString());

        }
        catch (Exception ex)
        {

            throw ex;

        }

        return objItemCategories.ItemCategoriesId;

    }

    public int Update(ItemCategories objItemCategories, SqlTransaction objSqlTransaction = null)
    {

        DBManager objDBManager = new DBManager(objSqlTransaction);
        int ReturnValue = 0;

        try
        {

            objDBManager.AddParameter("ItemCategoriesId", objItemCategories.ItemCategoriesId, SqlDbType.Int, 4);

            objDBManager.AddParameter("PracticeId", objItemCategories.PracticeId);
            objDBManager.AddParameter("Name", objItemCategories.Name);
            objDBManager.AddParameter("ItemTaxTypesId", objItemCategories.ItemTaxTypesId);
            objDBManager.AddParameter("ItemType", objItemCategories.ItemType);
            objDBManager.AddParameter("UnitsOfMeasures", objItemCategories.UnitsOfMeasures);
            objDBManager.AddParameter("ExcludeFromSale", objItemCategories.ExcludeFromSale);
            objDBManager.AddParameter("DimentionId", objItemCategories.DimentionId);
            objDBManager.AddParameter("SalesAccountId", objItemCategories.SalesAccountId);
            objDBManager.AddParameter("InventoryAccountId", objItemCategories.InventoryAccountId);
            objDBManager.AddParameter("COGSAccountId", objItemCategories.COGSAccountId);
            objDBManager.AddParameter("InventoryAdjustmentsAccountId", objItemCategories.InventoryAdjustmentsAccountId);
            objDBManager.AddParameter("ItemAssemblyCostsAccountId", objItemCategories.ItemAssemblyCostsAccountId);
            objDBManager.AddParameter("Status", objItemCategories.Status);
            objDBManager.AddParameter("ModifiedById", objItemCategories.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objItemCategories.ModifiedDate);

            ReturnValue = objDBManager.ExecuteNonQuery("ItemCategories_Update");
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return ReturnValue;
    }

    public int Delete(ItemCategories objItemCategories, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);
            objDBManager.AddParameter("ItemCategoriesId", objItemCategories.ItemCategoriesId);
            objDBManager.AddParameter("ModifiedById", objItemCategories.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objItemCategories.ModifiedDate);

            return objDBManager.ExecuteNonQuery("ItemCategories_Delete");
        }
        catch (Exception ex)
        {
            throw ex;

        }

    }

    public DataTable GetByID(int ItemCategoriesId, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);
            objDBManager.AddParameter("ItemCategoriesId", ItemCategoriesId);

            return objDBManager.ExecuteDataTable("ItemCategories_GetByID");
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
            
            return objDBManager.ExecuteDataSet("ItemCategories_GetAllFilter");
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

            return objDBManager.ExecuteDataSet("ItemCategories_GetAll");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    
}