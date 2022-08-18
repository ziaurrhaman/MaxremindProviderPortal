using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for ROSValuesDB
/// </summary>
public class ROSCategoryItemsDB
{
    public ROSCategoryItemsDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    
    public int Add(ROSCategoryItems objROSCategoryItems, SqlTransaction objSqlTransaction = null)
    {
        DBManager objDBManager = new DBManager(objSqlTransaction);
        try
        {
            objDBManager.AddParameter("ROSCategoryItemId", objROSCategoryItems.ROSCategoryItemId, SqlDbType.Int, 4, ParameterDirection.Output);
            
            objDBManager.AddParameter("ROSCategoryId", objROSCategoryItems.ROSCategoryId);
            objDBManager.AddParameter("ItemName", objROSCategoryItems.ItemName);
            objDBManager.AddParameter("CreatedById", objROSCategoryItems.CreatedById);
            objDBManager.AddParameter("CreatedDate", objROSCategoryItems.CreatedDate);
            objDBManager.AddParameter("Position", objROSCategoryItems.Position);
            
            objDBManager.ExecuteNonQuery("ROSCategoryItems_Add");
            objROSCategoryItems.ROSCategoryItemId = int.Parse(objDBManager.Parameters[0].Value.ToString());
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return objROSCategoryItems.ROSCategoryItemId;
    }

    public int Update(ROSCategoryItems objROSCategoryItems, SqlTransaction objSqlTransaction = null)
    {
        DBManager objDBManager = new DBManager(objSqlTransaction);
        int ReturnValue = 0;
        try
        {
            objDBManager.AddParameter("ROSCategoryItemId", objROSCategoryItems.ROSCategoryItemId);
            
            objDBManager.AddParameter("ROSCategoryId", objROSCategoryItems.ROSCategoryId);
            objDBManager.AddParameter("ItemName", objROSCategoryItems.ItemName);
            objDBManager.AddParameter("ModifiedById", objROSCategoryItems.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objROSCategoryItems.ModifiedDate);
            objDBManager.AddParameter("Position", objROSCategoryItems.Position);
            
            ReturnValue = objDBManager.ExecuteNonQuery("ROSCategoryItems_Update");
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ReturnValue;
    }
    
    public int Delete(ROSCategoryItems objROSCategoryItems, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);
            objDBManager.AddParameter("ROSCategoryItemId", objROSCategoryItems.ROSCategoryItemId);
            objDBManager.AddParameter("ModifiedById", objROSCategoryItems.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objROSCategoryItems.ModifiedDate);
            
            return objDBManager.ExecuteNonQuery("ROSCategoryItems_Delete");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int DeleteByROSCategories(ROSCategoryItems objROSCategoryItems, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);
            objDBManager.AddParameter("ROSCategoryId", objROSCategoryItems.ROSCategoryId);
            objDBManager.AddParameter("ModifiedById", objROSCategoryItems.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objROSCategoryItems.ModifiedDate);
            
            return objDBManager.ExecuteNonQuery("ROSCategoryItems_DeleteByROSCategories");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable GetRosItems(int rosCategoryId)
    {
        DBManager objDBManager = new DBManager();        
        objDBManager.AddParameter("RosCategoryId", rosCategoryId);
        return objDBManager.ExecuteDataTable("Chart_GetRosItems");
    }

    //Please Waqas Bhai
    public DataTable GetByROSCategoryId(int ROSCategoryId)
    {
        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("ROSCategoryId", ROSCategoryId);
        return objDBManager.ExecuteDataTable("ROSCategoryItems_GetByROSCategoryId");
    }
  
}