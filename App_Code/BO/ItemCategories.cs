using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ItemCategories
/// </summary>
public class ItemCategories
{
	public ItemCategories()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    #region " Private Members "
    
    private long _ItemCategoriesId;
    private long _PracticeId;
    private string _Name = string.Empty;
    private Nullable<long> _ItemTaxTypesId;
    private string _ItemType = string.Empty;
    private string _UnitsOfMeasures = string.Empty;
    private bool _ExcludeFromSale = false;
    private Nullable<long> _DimentionId;
    private Nullable<long> _SalesAccountId;
    private Nullable<long> _InventoryAccountId;
    private Nullable<long> _COGSAccountId;
    private Nullable<long> _InventoryAdjustmentsAccountId;
    private Nullable<long> _ItemAssemblyCostsAccountId;
    private string _Status = string.Empty;
    private long _CreatedById;
    private DateTime _CreatedDate;
    private long _ModifiedById;
    private DateTime _ModifiedDate;
    private bool _Deleted = false;
    
    #endregion

    #region " Properties "

    public long ItemCategoriesId
    {
        get { return _ItemCategoriesId; }
        set { _ItemCategoriesId = value; }
    }

    public long PracticeId
    {
        get { return _PracticeId; }
        set { _PracticeId = value; }
    }

    public string Name
    {
        get { return _Name; }
        set { _Name = value; }
    }

    public Nullable<long> ItemTaxTypesId
    {
        get { return _ItemTaxTypesId; }
        set { _ItemTaxTypesId = value; }
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

    public Nullable<long> ItemAssemblyCostsAccountId
    {
        get { return _ItemAssemblyCostsAccountId; }
        set { _ItemAssemblyCostsAccountId = value; }
    }

    public string Status
    {
        get { return _Status; }
        set { _Status = value; }
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