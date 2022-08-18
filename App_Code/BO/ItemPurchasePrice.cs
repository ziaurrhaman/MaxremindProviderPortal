using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ItemPurchasePrice
/// </summary>
public class ItemPurchasePrice
{
	public ItemPurchasePrice()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    
    #region " Private Members "
    
    long _ItemPurchasePriceId;
    long _PracticeId;
    long _ItemsId;
    long _SuppliersId;
    decimal _PurchasePrice;
    int _CurrencyId;
    double _SuppliersUnitOfMeasure = double.MinValue;
    double _ConversionFactor = double.MinValue;
    string _SupplierCode = string.Empty;
    long _CreatedById;
    DateTime _CreatedDate;
    long _ModifiedById;
    DateTime _ModifiedDate;
    bool _Deleted = false;
    
    #endregion
    
    #region " Properties "
    
    public long ItemPurchasePriceId
    {
        get { return _ItemPurchasePriceId; }
        set { _ItemPurchasePriceId = value; }
    }

    public long PracticeId
    {
        get { return _PracticeId; }
        set { _PracticeId = value; }
    }
    
    public long ItemsId
    {
        get { return _ItemsId; }
        set { _ItemsId = value; }
    }
    
    public long SuppliersId
    {
        get { return _SuppliersId; }
        set { _SuppliersId = value; }
    }
    
    public decimal PurchasePrice
    {
        get { return _PurchasePrice; }
        set { _PurchasePrice = value; }
    }
    
    public int CurrencyId
    {
        get { return _CurrencyId; }
        set { _CurrencyId = value; }
    }

    public double SuppliersUnitOfMeasure
    {
        get { return _SuppliersUnitOfMeasure; }
        set { _SuppliersUnitOfMeasure = value; }
    }

    public double ConversionFactor
    {
        get { return _ConversionFactor; }
        set { _ConversionFactor = value; }
    }

    public string SupplierCode
    {
        get { return _SupplierCode; }
        set { _SupplierCode = value; }
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