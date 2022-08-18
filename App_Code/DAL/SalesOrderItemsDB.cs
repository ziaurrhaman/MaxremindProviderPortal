using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for SalesOrderItemsDB
/// </summary>
public class SalesOrderItemsDB
{
	public SalesOrderItemsDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    
    public long Add(SalesOrderItems objSalesOrderItems, SqlTransaction objSqlTransaction = null)
    {
        DBManager objDBManager = new DBManager(objSqlTransaction);
        try
        {
            objDBManager.AddParameter("SalesOrderItemsId", objSalesOrderItems.SalesOrderItemsId, SqlDbType.Int, 4, ParameterDirection.Output);
            
            objDBManager.AddParameter("SalesOrdersId", objSalesOrderItems.SalesOrdersId);
            objDBManager.AddParameter("ItemId", objSalesOrderItems.ItemId);
            objDBManager.AddParameter("QuantityOrderd", objSalesOrderItems.QuantityOrderd);
            objDBManager.AddParameter("QuantityDelivered", objSalesOrderItems.QuantityDelivered);
            objDBManager.AddParameter("QuantityInvoiced", objSalesOrderItems.QuantityInvoiced);
            objDBManager.AddParameter("PriceBeforeTax", objSalesOrderItems.PriceBeforeTax);
            objDBManager.AddParameter("TaxAmount", objSalesOrderItems.TaxAmount);
            objDBManager.AddParameter("TaxTypeId", objSalesOrderItems.TaxTypeId);
            objDBManager.AddParameter("TotalPrice", objSalesOrderItems.TotalPrice);
            objDBManager.AddParameter("DueAmount", objSalesOrderItems.DueAmount);
            objDBManager.AddParameter("Discount", objSalesOrderItems.Discount);
            
            objDBManager.AddParameter("CreatedById", objSalesOrderItems.CreatedById);
            objDBManager.AddParameter("CreatedDate", objSalesOrderItems.CreatedDate);
            
            objDBManager.ExecuteNonQuery("SalesOrderItems_Add");
            objSalesOrderItems.SalesOrderItemsId = long.Parse(objDBManager.Parameters[0].Value.ToString());
        }
        catch (Exception ex)
        {
            throw ex;
        }
        
        return objSalesOrderItems.SalesOrderItemsId;
    }
    
    public int Update(SalesOrderItems objSalesOrderItems, SqlTransaction objSqlTransaction = null)
    {
        DBManager objDBManager = new DBManager(objSqlTransaction);
        int ReturnValue = 0;
        
        try
        {
            objDBManager.AddParameter("SalesOrderItemsId", objSalesOrderItems.SalesOrderItemsId, SqlDbType.Int, 4);
            
            objDBManager.AddParameter("SalesOrdersId", objSalesOrderItems.SalesOrdersId);
            objDBManager.AddParameter("ItemId", objSalesOrderItems.ItemId);
            objDBManager.AddParameter("QuantityOrderd", objSalesOrderItems.QuantityOrderd);
            objDBManager.AddParameter("QuantityDelivered", objSalesOrderItems.QuantityDelivered);
            objDBManager.AddParameter("QuantityInvoiced", objSalesOrderItems.QuantityInvoiced);
            objDBManager.AddParameter("PriceBeforeTax", objSalesOrderItems.PriceBeforeTax);
            objDBManager.AddParameter("TaxAmount", objSalesOrderItems.TaxAmount);
            objDBManager.AddParameter("TaxTypeId", objSalesOrderItems.TaxTypeId);
            objDBManager.AddParameter("TotalPrice", objSalesOrderItems.TotalPrice);
            objDBManager.AddParameter("Discount", objSalesOrderItems.Discount);
            objDBManager.AddParameter("DueAmount", objSalesOrderItems.DueAmount);
            objDBManager.AddParameter("ModifiedById", objSalesOrderItems.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objSalesOrderItems.ModifiedDate);
            
            ReturnValue = objDBManager.ExecuteNonQuery("SalesOrderItems_Update");
        }
        catch (Exception ex)
        {
            throw ex;
        }
        
        return ReturnValue;
    }
    
    public int Delete(SalesOrderItems objSalesOrderItems, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);
            objDBManager.AddParameter("SalesOrderItemsId", objSalesOrderItems.SalesOrderItemsId);
            objDBManager.AddParameter("ModifiedById", objSalesOrderItems.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objSalesOrderItems.ModifiedDate);
            
            return objDBManager.ExecuteNonQuery("SalesOrderItems_Delete");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataSet SalesOrderItems_GetBySalesOrderId(Int64 SalesOrderId)
    {
        DBManager objDbManager = new DBManager();
        objDbManager.AddParameter("SalesOrderId", SalesOrderId);
        return objDbManager.ExecuteDataSet("SalesOrderItems_GetBySalesOrderId");
    }

    public void SalesOrderItems_MakeDelivery(long SalesOrderItemsId, decimal? PaidAmount, decimal? QuantityDelivered, Int64 ModifiedById)
    {
        DBManager objDbManager = new DBManager();
        objDbManager.AddParameter("@SalesOrderItemsId", SalesOrderItemsId);
        objDbManager.AddParameter("@PaidAmount", PaidAmount);
        objDbManager.AddParameter("@QuantityDelivered", QuantityDelivered);
        objDbManager.AddParameter("@ModifiedDate", DateTime.Now);
        objDbManager.AddParameter("@ModifiedById", ModifiedById);
        objDbManager.ExecuteNonQuery("SalesOrderItems_MakeDelivery");
    }
}