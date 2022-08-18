using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Items
/// </summary>
public class Items
{
	public Items()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    
    #region " Private Members "
    
    private long _ItemsId;
    private long _PracticeId;
    private string _ItemCode = string.Empty;
    private string _Name = string.Empty;
    private string _Description = string.Empty;
    private Nullable<long> _ItemCategoryId;
    private Nullable<long> _TaxTypeId;
    private string _ItemType = string.Empty;
    private string _UnitsOfMeasures = string.Empty;
    private bool _EditableDescription = false;
    private bool _ExcludeFromSale = false;
    private Nullable<long> _DimentionId;
    private Nullable<long> _SalesAccountId;
    private Nullable<long> _InventoryAccountId;
    private Nullable<long> _COGSAccountId;
    private Nullable<long> _InventoryAdjustmentsAccountId;
    private string _ImagePath = string.Empty;
    
    private Nullable<double> _InStock = double.MinValue;
    private Nullable<double> _Demand = double.MinValue;
    private Nullable<double> _PurchasePending = double.MinValue;

    private Nullable<double> _StandardCost = double.MinValue;
    
    private string _Status = string.Empty;
    private Nullable<long> _CreatedById;
    private Nullable<DateTime> _CreatedDate;
    private Nullable<long> _ModifiedById;
    private Nullable<DateTime> _ModifiedDate;
    bool _Deleted = false;
    
    private string _TaxRate = string.Empty;
    private string _PurchasePrice = string.Empty;
    
    #endregion
    
    #region " Properties "
    
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
    
    public string ItemCode
    {
        get { return _ItemCode; }
        set { _ItemCode = value; }
    }

    public string Name
    {
        get { return _Name; }
        set { _Name = value; }
    }

    public string Description
    {
        get { return _Description; }
        set { _Description = value; }
    }

    public Nullable<long> ItemCategoryId
    {
        get { return _ItemCategoryId; }
        set { _ItemCategoryId = value; }
    }

    public Nullable<long> TaxTypeId
    {
        get { return _TaxTypeId; }
        set { _TaxTypeId = value; }
    }

    public string ItemType
    {
        get { return _ItemType; }
        set { _ItemType = value; }
    }

    public string UnitsOfMeasures
    {
        get { return _UnitsOfMeasures; }
        set { _UnitsOfMeasures = value; }
    }

    public bool EditableDescription
    {
        get { return _EditableDescription; }
        set { _EditableDescription = value; }
    }

    public bool ExcludeFromSale
    {
        get { return _ExcludeFromSale; }
        set { _ExcludeFromSale = value; }
    }
    
    public Nullable<long> DimentionId
    {
        get { return _DimentionId; }
        set { _DimentionId = value; }
    }
    
    public Nullable<long> SalesAccountId
    {
        get { return _SalesAccountId; }
        set { _SalesAccountId = value; }
    }
    
    public Nullable<long> InventoryAccountId
    {
        get { return _InventoryAccountId; }
        set { _InventoryAccountId = value; }
    }
    
    public Nullable<long> COGSAccountId
    {
        get { return _COGSAccountId; }
        set { _COGSAccountId = value; }
    }
    
    public Nullable<long> InventoryAdjustmentsAccountId
    {
        get { return _InventoryAdjustmentsAccountId; }
        set { _InventoryAdjustmentsAccountId = value; }
    }
    
    public string ImagePath
    {
        get { return _ImagePath; }
        set { _ImagePath = value; }
    }
    
    public Nullable<double> InStock
    {
        get { return _InStock; }
        set { _InStock = value; }
    }
    
    public Nullable<double> Demand
    {
        get { return _Demand; }
        set { _Demand = value; }
    }
    
    public Nullable<double> PurchasePending
    {
        get { return _PurchasePending; }
        set { _PurchasePending = value; }
    }

    public Nullable<double> StandardCost
    {
        get { return _StandardCost; }
        set { _StandardCost = value; }
    }
    
    public string Status
    {
        get { return _Status; }
        set { _Status = value; }
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
    
    
    public string TaxRate
    {
        get { return _TaxRate; }
        set { _TaxRate = value; }
    }
    
    public string PurchasePrice
    {
        get { return _PurchasePrice; }
        set { _PurchasePrice = value; }
    }
    
    #endregion
}