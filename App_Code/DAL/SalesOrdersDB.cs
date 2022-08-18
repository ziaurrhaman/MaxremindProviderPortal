using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for SalesOrdersDB
/// </summary>
public class SalesOrdersDB
{
	public SalesOrdersDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    
    public long Add(SalesOrders objSalesOrders, SqlTransaction objSqpTransaction = null)
    {
        DBManager objDBManager = new DBManager(objSqpTransaction);
        try
        {
            objDBManager.AddParameter("SalesOrdersId", objSalesOrders.SalesOrdersId, SqlDbType.Int, 4, ParameterDirection.Output);
            
            objDBManager.AddParameter("PatientId", objSalesOrders.PatientId);
            objDBManager.AddParameter("PracticeId", objSalesOrders.PracticeId);
            objDBManager.AddParameter("PracticeLocationsId", objSalesOrders.PracticeLocationsId);
            
            objDBManager.AddParameter("OrderDate", objSalesOrders.OrderDate);
            objDBManager.AddParameter("DOS", objSalesOrders.DOS);
            
            objDBManager.AddParameter("PaymentSource", objSalesOrders.PaymentSource);
            objDBManager.AddParameter("PriceListId", objSalesOrders.PriceListId);
            
            objDBManager.AddParameter("TotalPrice", objSalesOrders.TotalPrice);
            objDBManager.AddParameter("DueAmount", objSalesOrders.DueAmount);
            
            objDBManager.AddParameter("DeliverFromLocation", objSalesOrders.DeliverFromLocation);
            objDBManager.AddParameter("RequiredDeliveryDate", objSalesOrders.RequiredDeliveryDate);
            objDBManager.AddParameter("DeliverTo", objSalesOrders.DeliverTo);
            objDBManager.AddParameter("DeliveryAddress", objSalesOrders.DeliveryAddress);
            
            objDBManager.AddParameter("DeliveryLocationType", objSalesOrders.DeliveryLocationType);
            objDBManager.AddParameter("DeliveryLocationId", objSalesOrders.DeliveryLocationId);
            
            objDBManager.AddParameter("ServiceProviderId", objSalesOrders.ServiceProviderId);
            
            objDBManager.AddParameter("ContactPhoneNumber", objSalesOrders.ContactPhoneNumber);
            objDBManager.AddParameter("CustomerReference", objSalesOrders.CustomerReference);
            objDBManager.AddParameter("ShippingCompany", objSalesOrders.ShippingCompany);
            
            objDBManager.AddParameter("Comments", objSalesOrders.Comments);

            objDBManager.AddParameter("DeliveryDate", objSalesOrders.DeliveryDate);
            
            objDBManager.AddParameter("CreatedById", objSalesOrders.CreatedById);
            objDBManager.AddParameter("CreatedDate", objSalesOrders.CreatedDate);
            
            objDBManager.ExecuteNonQuery("SalesOrders_Add");
            objSalesOrders.SalesOrdersId = long.Parse(objDBManager.Parameters[0].Value.ToString());
        }
        catch (Exception ex)
        {
            throw ex;
        }
        
        return objSalesOrders.SalesOrdersId;
    }
    
    public int Update(SalesOrders objSalesOrders, SqlTransaction objSqpTransaction = null)
    {
        DBManager objDBManager = new DBManager(objSqpTransaction);
        int ReturnValue = 0;
        
        try
        {
            objDBManager.AddParameter("SalesOrdersId", objSalesOrders.SalesOrdersId, SqlDbType.Int, 4);
            
            objDBManager.AddParameter("PatientId", objSalesOrders.PatientId);
            objDBManager.AddParameter("PracticeLocationsId", objSalesOrders.PracticeLocationsId);
            objDBManager.AddParameter("PaymentSource", objSalesOrders.PaymentSource);
            objDBManager.AddParameter("OrderDate", objSalesOrders.OrderDate);
            objDBManager.AddParameter("DOS", objSalesOrders.DOS);
            objDBManager.AddParameter("PriceListId", objSalesOrders.PriceListId);
            objDBManager.AddParameter("PracticeId", objSalesOrders.PracticeId);
            objDBManager.AddParameter("DeliverFromLocation", objSalesOrders.DeliverFromLocation);
            objDBManager.AddParameter("RequiredDeliveryDate", objSalesOrders.RequiredDeliveryDate);
            objDBManager.AddParameter("DeliverTo", objSalesOrders.DeliverTo);
            objDBManager.AddParameter("DeliveryAddress", objSalesOrders.DeliveryAddress);
            objDBManager.AddParameter("ContactPhoneNumber", objSalesOrders.ContactPhoneNumber);
            objDBManager.AddParameter("CustomerReference", objSalesOrders.CustomerReference);
            objDBManager.AddParameter("Comments", objSalesOrders.Comments);
            objDBManager.AddParameter("ShippingCompany", objSalesOrders.ShippingCompany);
            objDBManager.AddParameter("TotalPrice", objSalesOrders.TotalPrice);
            objDBManager.AddParameter("DueAmount", objSalesOrders.DueAmount);
            objDBManager.AddParameter("DeliveryLocationType", objSalesOrders.DeliveryLocationType);
            objDBManager.AddParameter("DeliveryLocationId", objSalesOrders.DeliveryLocationId);
            objDBManager.AddParameter("ServiceProviderId", objSalesOrders.ServiceProviderId);
            objDBManager.AddParameter("DeliveryDate", objSalesOrders.DeliveryDate);
            objDBManager.AddParameter("ModifiedById", objSalesOrders.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objSalesOrders.ModifiedDate);
            
            ReturnValue = objDBManager.ExecuteNonQuery("SalesOrders_Update");
        }
        catch (Exception ex)
        {
            throw ex;
        }
        
        return ReturnValue;
    }
    
    public int Delete(SalesOrders objSalesOrders, SqlTransaction objSqpTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqpTransaction);
            objDBManager.AddParameter("SalesOrdersId", objSalesOrders.SalesOrdersId);
            objDBManager.AddParameter("ModifiedById", objSalesOrders.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objSalesOrders.ModifiedDate);
            return objDBManager.ExecuteNonQuery("SalesOrders_Delete");
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
            
            return objDBManager.ExecuteDataSet("SalesOrders_GetAllFilter");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    
    public DataTable GetByID(int SalesOrdersId, SqlTransaction objSqpTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqpTransaction);
            objDBManager.AddParameter("SalesOrdersId", SalesOrdersId, SqlDbType.Int, 4);
            return objDBManager.ExecuteDataTable("SalesOrders_GetByID");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public void SalesOrders_UpdateAfterDelivery(Int64 SalesOrdersId, decimal? AmountPaid, string Comments)
    {
        DBManager objDbManager = new DBManager();
        objDbManager.AddParameter("@SalesOrdersId", SalesOrdersId);
        objDbManager.AddParameter("@AmountPaid", AmountPaid);
        objDbManager.AddParameter("@Comments", Comments);
        objDbManager.ExecuteNonQuery("SalesOrders_UpdateAfterDelivery");
    }
}