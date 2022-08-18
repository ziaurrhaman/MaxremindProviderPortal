using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for PurchaseOrderItemsDB
/// </summary>
public class PurchaseOrderItemsDB
{
	public PurchaseOrderItemsDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    
    public long Add(PurchaseOrderItems objPurchaseOrderItems, SqlTransaction objSqlTransaction = null)
    {
        DBManager objDBManager = new DBManager(objSqlTransaction);
        try
        {
            objDBManager.AddParameter("PurchaseOrderItemsId", objPurchaseOrderItems.PurchaseOrderItemsId, SqlDbType.Int, 4, ParameterDirection.Output);
            
            objDBManager.AddParameter("PurchaseOrdersId", objPurchaseOrderItems.PurchaseOrdersId);
            objDBManager.AddParameter("ItemId", objPurchaseOrderItems.ItemId);
            objDBManager.AddParameter("QuantityOrderd", objPurchaseOrderItems.QuantityOrderd);
            objDBManager.AddParameter("QuantityReceived", objPurchaseOrderItems.QuantityReceived);
            objDBManager.AddParameter("QuantityInvoiced", objPurchaseOrderItems.QuantityInvoiced);
            objDBManager.AddParameter("RequiredDeliveryDate", objPurchaseOrderItems.RequiredDeliveryDate);
            objDBManager.AddParameter("PriceBeforeTax", objPurchaseOrderItems.PriceBeforeTax);
            objDBManager.AddParameter("TotalPrice", objPurchaseOrderItems.TotalPrice);
            objDBManager.AddParameter("SubTotal", objPurchaseOrderItems.SubTotal);
            objDBManager.AddParameter("DueAmount", objPurchaseOrderItems.DueAmount);
            objDBManager.AddParameter("CreatedById", objPurchaseOrderItems.CreatedById);
            objDBManager.AddParameter("CreatedDate", objPurchaseOrderItems.CreatedDate);
            
            objDBManager.ExecuteNonQuery("PurchaseOrderItems_Add");
            objPurchaseOrderItems.PurchaseOrderItemsId = long.Parse(objDBManager.Parameters[0].Value.ToString());
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return objPurchaseOrderItems.PurchaseOrderItemsId;
    }
    
    public int Update(PurchaseOrderItems objPurchaseOrderItems, SqlTransaction objSqlTransaction = null)
    {
        DBManager objDBManager = new DBManager(objSqlTransaction);
        int ReturnValue = 0;
        try
        {
            objDBManager.AddParameter("PurchaseOrderItemsId", objPurchaseOrderItems.PurchaseOrderItemsId, SqlDbType.Int, 4);
            
            objDBManager.AddParameter("PurchaseOrdersId", objPurchaseOrderItems.PurchaseOrdersId);
            objDBManager.AddParameter("ItemId", objPurchaseOrderItems.ItemId);
            objDBManager.AddParameter("QuantityOrderd", objPurchaseOrderItems.QuantityOrderd);
            objDBManager.AddParameter("QuantityReceived", objPurchaseOrderItems.QuantityReceived);
            objDBManager.AddParameter("QuantityInvoiced", objPurchaseOrderItems.QuantityInvoiced);
            objDBManager.AddParameter("RequiredDeliveryDate", objPurchaseOrderItems.RequiredDeliveryDate);
            objDBManager.AddParameter("PriceBeforeTax", objPurchaseOrderItems.PriceBeforeTax);
            objDBManager.AddParameter("TotalPrice", objPurchaseOrderItems.TotalPrice);
            objDBManager.AddParameter("SubTotal", objPurchaseOrderItems.SubTotal);
            objDBManager.AddParameter("DueAmount", objPurchaseOrderItems.DueAmount);
            objDBManager.AddParameter("ModifiedById", objPurchaseOrderItems.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objPurchaseOrderItems.ModifiedDate);
            
            ReturnValue = objDBManager.ExecuteNonQuery("PurchaseOrderItems_Update");
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ReturnValue;
    }
    
    public int Delete(PurchaseOrderItems objPurchaseOrderItems, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);
            objDBManager.AddParameter("PurchaseOrderItemsId", objPurchaseOrderItems.PurchaseOrderItemsId);
            objDBManager.AddParameter("ModifiedById", objPurchaseOrderItems.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objPurchaseOrderItems.ModifiedDate);
            
            return objDBManager.ExecuteNonQuery("PurchaseOrderItems_Delete");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int DeleteByPurchaseOrdersId(PurchaseOrderItems objPurchaseOrderItems, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);
            objDBManager.AddParameter("PurchaseOrdersId", objPurchaseOrderItems.PurchaseOrdersId);
            objDBManager.AddParameter("ModifiedById", objPurchaseOrderItems.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objPurchaseOrderItems.ModifiedDate);

            return objDBManager.ExecuteNonQuery("PurchaseOrderItems_DeleteByPurchaseOrdersId");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    
    public DataTable GetAllByPurchaseOrdersId(long PurchaseOrdersId, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);
            objDBManager.AddParameter("PurchaseOrdersId", PurchaseOrdersId);
            
            return objDBManager.ExecuteDataTable("PurchaseOrderItems_GetAllByPurchaseOrdersId");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}