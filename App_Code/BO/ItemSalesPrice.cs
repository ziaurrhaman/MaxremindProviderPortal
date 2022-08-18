using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ItemSalesPrice
/// </summary>
public class ItemSalesPrice
{
	public ItemSalesPrice()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    #region " Private Members "
    
    long _ItemSalesPriceId;
    long _ItemsId;
    long _PracticeId;
    int _CurrencyId;
    long _SalesTypeId;
    decimal _ItemPrice;
    long _CreatedById;
    DateTime _CreatedDate;
    long _ModifiedById;
    DateTime _ModifiedDate;
    bool _Deleted = false;
    
    #endregion
    
    #region " Properties "
    
    public long ItemSalesPriceId
    {
        get { return _ItemSalesPriceId; }
        set { _ItemSalesPriceId = value; }
    }
    
    public long ItemsId
    {
        get { return _ItemsId; }
        set { _ItemsId = value; }
    }
    
    public long PracticeId
    {
        get { return _PracticeId; }
        set { _PracticeId = value; }
    }
    
    public int CurrencyId
    {
        get { return _CurrencyId; }
        set { _CurrencyId = value; }
    }
    
    public long SalesTypeId
    {
        get { return _SalesTypeId; }
        set { _SalesTypeId = value; }
    }
    
    public decimal ItemPrice
    {
        get { return _ItemPrice; }
        set { _ItemPrice = value; }
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