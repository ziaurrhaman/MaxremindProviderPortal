using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PurchaseOrders
/// </summary>
public class PurchaseOrders
{
	public PurchaseOrders()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    
    #region " Private Members "
    
    long _PurchaseOrdersId;
    long _PracticeId;
    long _SuppliersId;
    Nullable<int> _PracticeLocationsId;
    Nullable<long> _PurchaseReference;
    Nullable<DateTime> _OrderDate;
    string _SupplierReference = string.Empty;
    Nullable<int> _ReceiverLocationId;
    string _PurchaseDeliverTo = string.Empty;
    string _Memo = string.Empty;
    private Nullable<decimal> _TotalPrice;
    long _CreatedById;
    DateTime _CreatedDate;
    long _ModifiedById;
    DateTime _ModifiedDate;
    bool _Deleted = false;
    
    #endregion
    
    #region " Properties "
    
    public long PurchaseOrdersId
    {
        get { return _PurchaseOrdersId; }
        set { _PurchaseOrdersId = value; }
    }
    
    public long PracticeId
    {
        get { return _PracticeId; }
        set { _PracticeId = value; }
    }
    
    public long SuppliersId
    {
        get { return _SuppliersId; }
        set { _SuppliersId = value; }
    }
    
    public Nullable<int> PracticeLocationsId
    {
        get { return _PracticeLocationsId; }
        set { _PracticeLocationsId = value; }
    }
    
    public Nullable<long> PurchaseReference
    {
        get { return _PurchaseReference; }
        set { _PurchaseReference = value; }
    }
    
    public Nullable<DateTime> OrderDate
    {
        get { return _OrderDate; }
        set { _OrderDate = value; }
    }
    
    public string SupplierReference
    {
        get { return _SupplierReference; }
        set { _SupplierReference = value; }
    }
    
    public Nullable<int> ReceiverLocationId
    {
        get { return _ReceiverLocationId; }
        set { _ReceiverLocationId = value; }
    }
    
    public string PurchaseDeliverTo
    {
        get { return _PurchaseDeliverTo; }
        set { _PurchaseDeliverTo = value; }
    }

    public string Memo
    {
        get { return _Memo; }
        set { _Memo = value; }
    }

    public Nullable<decimal> TotalPrice
    {
        get { return _TotalPrice; }
        set { _TotalPrice = value; }
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