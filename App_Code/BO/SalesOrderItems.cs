using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SalesOrderItems
/// </summary>
public class SalesOrderItems
{
	public SalesOrderItems()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    
    #region " Private Members "
    
    private long _SalesOrderItemsId;
    private Nullable<long> _SalesOrdersId;
    private Nullable<long> _ItemId;
    private Nullable<decimal> _QuantityOrderd;
    private Nullable<decimal> _QuantityDelivered;
    private Nullable<decimal> _QuantityInvoiced;
    private Nullable<decimal> _PriceBeforeTax;
    private Nullable<decimal> _TaxAmount;
    private Nullable<int> _TaxTypeId;
    private Nullable<decimal> _TotalPrice;
    private Nullable<double> _Discount;
    private Nullable<decimal> _DueAmount;
    private Nullable<decimal> _PaidAmount;
    private Nullable<long> _CreatedById;
    private Nullable<DateTime> _CreatedDate;
    private Nullable<long> _ModifiedById;
    private Nullable<DateTime> _ModifiedDate;
    private bool _Deleted = false;
    
    #endregion
    
    #region " Properties "
    
    public long SalesOrderItemsId
    {
        get { return _SalesOrderItemsId; }
        set { _SalesOrderItemsId = value; }
    }
    
    public Nullable<long> SalesOrdersId
    {
        get { return _SalesOrdersId; }
        set { _SalesOrdersId = value; }
    }
    
    public Nullable<long> ItemId
    {
        get { return _ItemId; }
        set { _ItemId = value; }
    }
    
    public Nullable<decimal> QuantityOrderd
    {
        get { return _QuantityOrderd; }
        set { _QuantityOrderd = value; }
    }
    
    public Nullable<decimal> QuantityDelivered
    {
        get { return _QuantityDelivered; }
        set { _QuantityDelivered = value; }
    }
    
    public Nullable<decimal> QuantityInvoiced
    {
        get { return _QuantityInvoiced; }
        set { _QuantityInvoiced = value; }
    }
    
    public Nullable<decimal> PriceBeforeTax
    {
        get { return _PriceBeforeTax; }
        set { _PriceBeforeTax = value; }
    }

    public Nullable<decimal> TaxAmount
    {
        get { return _TaxAmount; }
        set { _TaxAmount = value; }
    }

    public Nullable<int> TaxTypeId
    {
        get { return _TaxTypeId; }
        set { _TaxTypeId = value; }
    }

    public Nullable<decimal> TotalPrice
    {
        get { return _TotalPrice; }
        set { _TotalPrice = value; }
    }

    public Nullable<double> Discount
    {
        get { return _Discount; }
        set { _Discount = value; }
    }

    public Nullable<decimal> DueAmount
    {
        get { return _DueAmount; }
        set { _DueAmount = value; }
    }

    public Nullable<decimal> PaidAmount
    {
        get { return _PaidAmount; }
        set { _PaidAmount = value; }
    }

    public Nullable<long> CreatedById
    {
        get { return _CreatedById; }
        set { _CreatedById = value; }
    }

    public Nullable<DateTime> CreatedDate
    {
        get { return _CreatedDate; }
        set { _CreatedDate = value; }
    }

    public Nullable<long> ModifiedById
    {
        get { return _ModifiedById; }
        set { _ModifiedById = value; }
    }

    public Nullable<DateTime> ModifiedDate
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