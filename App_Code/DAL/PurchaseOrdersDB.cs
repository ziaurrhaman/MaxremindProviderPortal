using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for PurchaseOrdersDB
/// </summary>
public class PurchaseOrdersDB
{
	public PurchaseOrdersDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    
    public long Add(PurchaseOrders objPurchaseOrders, SqlTransaction objSqlTransaction = null)
    {
        DBManager objDBManager = new DBManager(objSqlTransaction);
        try
        {
            objDBManager.AddParameter("PurchaseOrdersId", objPurchaseOrders.PurchaseOrdersId, SqlDbType.Int, 4, ParameterDirection.Output);
            
            objDBManager.AddParameter("SuppliersId", objPurchaseOrders.SuppliersId);
            objDBManager.AddParameter("PracticeId", objPurchaseOrders.PracticeId);
            objDBManager.AddParameter("PracticeLocationsId", objPurchaseOrders.PracticeLocationsId);
            objDBManager.AddParameter("PurchaseReference", objPurchaseOrders.PurchaseReference);
            objDBManager.AddParameter("OrderDate", objPurchaseOrders.OrderDate);
            objDBManager.AddParameter("SupplierReference", objPurchaseOrders.SupplierReference);
            objDBManager.AddParameter("ReceiverLocationId", objPurchaseOrders.ReceiverLocationId);
            objDBManager.AddParameter("PurchaseDeliverTo", objPurchaseOrders.PurchaseDeliverTo);
            objDBManager.AddParameter("Memo", objPurchaseOrders.Memo);
            objDBManager.AddParameter("TotalPrice", objPurchaseOrders.TotalPrice);
            objDBManager.AddParameter("CreatedById", objPurchaseOrders.CreatedById);
            objDBManager.AddParameter("CreatedDate", objPurchaseOrders.CreatedDate);
            
            objDBManager.ExecuteNonQuery("PurchaseOrders_Add");
            
            objPurchaseOrders.PurchaseOrdersId = long.Parse(objDBManager.Parameters[0].Value.ToString());
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return objPurchaseOrders.PurchaseOrdersId;
    }
    
    public int Update(PurchaseOrders objPurchaseOrders, SqlTransaction objSqlTransaction = null)
    {
        DBManager objDBManager = new DBManager(objSqlTransaction);
        int ReturnValue = 0;
        try
        {
            objDBManager.AddParameter("PurchaseOrdersId", objPurchaseOrders.PurchaseOrdersId, SqlDbType.Int, 4);

            objDBManager.AddParameter("SuppliersId", objPurchaseOrders.SuppliersId);
            objDBManager.AddParameter("PracticeId", objPurchaseOrders.PracticeId);
            objDBManager.AddParameter("PracticeLocationsId", objPurchaseOrders.PracticeLocationsId);
            objDBManager.AddParameter("PurchaseReference", objPurchaseOrders.PurchaseReference);
            objDBManager.AddParameter("OrderDate", objPurchaseOrders.OrderDate);
            objDBManager.AddParameter("SupplierReference", objPurchaseOrders.SupplierReference);
            objDBManager.AddParameter("ReceiverLocationId", objPurchaseOrders.ReceiverLocationId);
            objDBManager.AddParameter("PurchaseDeliverTo", objPurchaseOrders.PurchaseDeliverTo);
            objDBManager.AddParameter("Memo", objPurchaseOrders.Memo);
            objDBManager.AddParameter("TotalPrice", objPurchaseOrders.TotalPrice);
            objDBManager.AddParameter("ModifiedById", objPurchaseOrders.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objPurchaseOrders.ModifiedDate);

            ReturnValue = objDBManager.ExecuteNonQuery("PurchaseOrders_Update");
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ReturnValue;
    }
    
    public int Delete(PurchaseOrders objPurchaseOrders, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);
            objDBManager.AddParameter("PurchaseOrdersId", objPurchaseOrders.PurchaseOrdersId);
            objDBManager.AddParameter("ModifiedById", objPurchaseOrders.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objPurchaseOrders.ModifiedDate);
            
            return objDBManager.ExecuteNonQuery("PurchaseOrders_Delete");
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
            
            return objDBManager.ExecuteDataSet("PurchaseOrders_GetAllFilter");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    
    public DataTable GetByID(long PurchaseOrdersId, SqlTransaction objSqpTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqpTransaction);
            objDBManager.AddParameter("PurchaseOrdersId", PurchaseOrdersId);
            return objDBManager.ExecuteDataTable("PurchaseOrders_GetByID");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    
    public DataTable GetAllItemsAutoCompleteByItemCode(long PracticeId, string ItemCode, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);
            objDBManager.AddParameter("PracticeId", PracticeId);
            objDBManager.AddParameter("ItemCode", ItemCode);
            
            return objDBManager.ExecuteDataTable("Items_GetAllItemsAutoCompleteByItemCode");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    
    public DataTable GetAllItemsAutoCompleteByItemName(long PracticeId, string ItemName, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);
            objDBManager.AddParameter("PracticeId", PracticeId);
            objDBManager.AddParameter("ItemName", ItemName);
            
            return objDBManager.ExecuteDataTable("Items_GetAllItemsAutoCompleteByItemName");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}