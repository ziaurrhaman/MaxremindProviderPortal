using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PurchaseOrderItems
/// </summary>
public class PurchaseOrderItems
{
	public PurchaseOrderItems()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    
    #region " Private Members "
    
    long _PurchaseOrderItemsId;
    long _PurchaseOrdersId;
    long _ItemId;
    double _QuantityOrderd = double.MinValue;
    double _QuantityReceived = double.MinValue;
    double _QuantityInvoiced = double.MinValue;
    Nullable<DateTime> _RequiredDeliveryDate;
    decimal _PriceBeforeTax = decimal.MinValue;
    decimal _TotalPrice = decimal.MinValue;
    decimal _SubTotal = decimal.MinValue;
    decimal _DueAmount = decimal.MinValue;
    long _CreatedById;
    DateTime _CreatedDate;
    long _ModifiedById;
    DateTime _ModifiedDate;
    bool _Deleted = false;
    
    #endregion
    
    #region " Properties "
    
    public long PurchaseOrderItemsId
    {
        get { return _PurchaseOrderItemsId; }
        set { _PurchaseOrderItemsId = value; }
    }
    
    public long PurchaseOrdersId
    {
        get { return _PurchaseOrdersId; }
        set { _PurchaseOrdersId = value; }
    }
    
    public long ItemId
    {
        get { return _ItemId; }
        set { _ItemId = value; }
    }
    
    public double QuantityOrderd
    {
        get { return _QuantityOrderd; }
        set { _QuantityOrderd = value; }
    }
    
    public double QuantityReceived
    {
        get { return _QuantityReceived; }
        set { _QuantityReceived = value; }
    }
    
    public double QuantityInvoiced
    {
        get { return _QuantityInvoiced; }
        set { _QuantityInvoiced = value; }
    }

    public Nullable<DateTime> RequiredDeliveryDate
    {
        get { return _RequiredDeliveryDate; }
        set { _RequiredDeliveryDate = value; }
    }

    public decimal PriceBeforeTax
    {
        get { return _PriceBeforeTax; }
        set { _PriceBeforeTax = value; }
    }
    
    public decimal TotalPrice
    {
        get { return _TotalPrice; }
        set { _TotalPrice = value; }
    }
    
    public decimal SubTotal
    {
        get { return _SubTotal; }
        set { _SubTotal = value; }
    }
    
    public decimal DueAmount
    {
        get { return _DueAmount; }
        set { _DueAmount = value; }
    }
    
    public long CreatedById
    {
        get { return _CreatedById; }
        set { _CreatedById = value; }
    }
    
    public DateTime CreatedDate
    {
        get { return _CreatedDate; }
        set { _CreatedDate = value; }
    }
    
    public long ModifiedById
    {
        get { return _ModifiedById; }
        set { _ModifiedById = value; }
    }
    
    public DateTime ModifiedDate
    {
        get { return _ModifiedDate; }
        set { _ModifiedDate = value; }
    }
    
    public bool Deleted
    {
        get { return _Deleted; }
        set { _Deleted = value; }
    }
    
    #endregion
}