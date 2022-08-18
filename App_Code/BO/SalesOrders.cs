using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SalesOrders
/// </summary>
public class SalesOrders
{
	public SalesOrders()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    
    #region " Private Members "
    
    private long _SalesOrdersId;
    private Nullable<long> _PatientId;
    private Nullable<int> _PracticeLocationsId;
    private string _PaymentSource = string.Empty;
    private Nullable<DateTime> _OrderDate;
    private Nullable<DateTime> _DOS;
    private Nullable<int> _PriceListId;
    private long _PracticeId;
    private Nullable<int> _DeliverFromLocation;
    private Nullable<DateTime> _RequiredDeliveryDate;
    private string _DeliverTo = string.Empty;
    private string _DeliveryAddress = string.Empty;
    private string _ContactPhoneNumber = string.Empty;
    private string _CustomerReference = string.Empty;
    private string _Comments = string.Empty;
    private Nullable<long> _ShippingCompany;
    private Nullable<decimal> _TotalPrice;
    private Nullable<decimal> _DueAmount;
    private Nullable<decimal> _AmountPaid;
    private Nullable<decimal> _TotalDiscount;
    private string _DeliveryLocationType = string.Empty;
    private Nullable<long> _DeliveryLocationId;
    private Nullable<long> _ServiceProviderId;
    private Nullable<DateTime> _DeliveryDate;
    private Nullable<long> _CreatedById;
    private Nullable<DateTime> _CreatedDate;
    private Nullable<long> _ModifiedById;
    private Nullable<DateTime> _ModifiedDate;
    private bool _Deleted = false;
    
    #endregion
    
    #region " Properties "
    
    public long SalesOrdersId
    {
        get { return _SalesOrdersId; }
        set { _SalesOrdersId = value; }
    }
    
    public Nullable<long> PatientId
    {
        get { return _PatientId; }
        set { _PatientId = value; }
    }
    
    public Nullable<int> PracticeLocationsId
    {
        get { return _PracticeLocationsId; }
        set { _PracticeLocationsId = value; }
    }
    
    public string PaymentSource
    {
        get { return _PaymentSource; }
        set { _PaymentSource = value; }
    }
    
    public Nullable<DateTime> OrderDate
    {
        get { return _OrderDate; }
        set { _OrderDate = value; }
    }
    
    public Nullable<DateTime> DOS
    {
        get { return _DOS; }
        set { _DOS = value; }
    }

    public Nullable<int> PriceListId
    {
        get { return _PriceListId; }
        set { _PriceListId = value; }
    }

    public long PracticeId
    {
        get { return _PracticeId; }
        set { _PracticeId = value; }
    }

    public Nullable<int> DeliverFromLocation
    {
        get { return _DeliverFromLocation; }
        set { _DeliverFromLocation = value; }
    }

    public Nullable<DateTime> RequiredDeliveryDate
    {
        get { return _RequiredDeliveryDate; }
        set { _RequiredDeliveryDate = value; }
    }

    public string DeliverTo
    {
        get { return _DeliverTo; }
        set { _DeliverTo = value; }
    }

    public string DeliveryAddress
    {
        get { return _DeliveryAddress; }
        set { _DeliveryAddress = value; }
    }

    public string ContactPhoneNumber
    {
        get { return _ContactPhoneNumber; }
        set { _ContactPhoneNumber = value; }
    }

    public string CustomerReference
    {
        get { return _CustomerReference; }
        set { _CustomerReference = value; }
    }
    
    public string Comments
    {
        get { return _Comments; }
        set { _Comments = value; }
    }
    
    public Nullable<long> ShippingCompany
    {
        get { return _ShippingCompany; }
        set { _ShippingCompany = value; }
    }
    
    public Nullable<decimal> TotalPrice
    {
        get { return _TotalPrice; }
        set { _TotalPrice = value; }
    }
    
    public Nullable<decimal> DueAmount
    {
        get { return _DueAmount; }
        set { _DueAmount = value; }
    }
    
    public Nullable<decimal> AmountPaid
    {
        get { return _AmountPaid; }
        set { _AmountPaid = value; }
    }
    
    public Nullable<decimal> TotalDiscount
    {
        get { return _TotalDiscount; }
        set { _TotalDiscount = value; }
    }
    
    public string DeliveryLocationType
    {
        get { return _DeliveryLocationType; }
        set { _DeliveryLocationType = value; }
    }
    
    public Nullable<long> DeliveryLocationId
    {
        get { return _DeliveryLocationId; }
        set { _DeliveryLocationId = value; }
    }
    
    public Nullable<long> ServiceProviderId
    {
        get { return _ServiceProviderId; }
        set { _ServiceProviderId = value; }
    }

    public Nullable<DateTime> DeliveryDate
    {
        get { return _DeliveryDate; }
        set { _DeliveryDate = value; }
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