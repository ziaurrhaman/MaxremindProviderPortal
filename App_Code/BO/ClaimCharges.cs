using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ClaimCharges
/// </summary>
public class ClaimCharges
{
    public ClaimCharges()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    
    #region " Private Members "
    
    long _ClaimChargesId;
    long _ClaimId;
    string _CPTCode = string.Empty;
    DateTime _ServiceDate;
    double _ServiceUnits = double.MinValue;
    decimal _TotalCharges;
    int _SequenceNumber;
    string _Modifier1 = string.Empty;
    string _Modifier2 = string.Empty;
    string _Modifier3 = string.Empty;
    string _Modifier4 = string.Empty;
    int _DXPointer1;
    int _DXPointer2;
    int _DXPointer3;
    int _DXPointer4;
    int _DXPointer5;
    int _DXPointer6;
    int _DXPointer7;
    int _DXPointer8;
    bool _IncludeInSubmission = false;
    string _BillingStatus = string.Empty;
    string _Drug = string.Empty;
    string _UnitCode = string.Empty;
    
    private bool _IsSuperBill = false;
    
    private decimal? _AllowedAmount;
    private decimal? _PaidAmount;
    private decimal? _PriInsPaidAmount;
    private decimal? _SecInsPaidAmount;
    private decimal? _OTHInsPaidAmount;
    private decimal? _PatPaidAmount;
    private decimal? _AdjustedAmount;
    private decimal? _WriteOffAmount;
    private decimal? _BalanceDue;
    
    private DateTime _CreatedDate;
    private long _CreatedById;
    private DateTime _ModifiedDate;
    private long _ModifiedById;
    private bool _Deleted = false;
    
    #endregion
    
    #region " Properties "
    
    public long ClaimChargesId
    {
        get { return _ClaimChargesId; }
        set { _ClaimChargesId = value; }
    }

    public long ClaimId
    {
        get { return _ClaimId; }
        set { _ClaimId = value; }
    }

    public string CPTCode
    {
        get { return _CPTCode; }
        set { _CPTCode = value; }
    }

    public DateTime ServiceDate
    {
        get { return _ServiceDate; }
        set { _ServiceDate = value; }
    }

    public double ServiceUnits
    {
        get { return _ServiceUnits; }
        set { _ServiceUnits = value; }
    }

    public decimal TotalCharges
    {
        get { return _TotalCharges; }
        set { _TotalCharges = value; }
    }

    public int SequenceNumber
    {
        get { return _SequenceNumber; }
        set { _SequenceNumber = value; }
    }

    public string Modifier1
    {
        get { return _Modifier1; }
        set { _Modifier1 = value; }
    }

    public string Modifier2
    {
        get { return _Modifier2; }
        set { _Modifier2 = value; }
    }

    public string Modifier3
    {
        get { return _Modifier3; }
        set { _Modifier3 = value; }
    }

    public string Modifier4
    {
        get { return _Modifier4; }
        set { _Modifier4 = value; }
    }

    public int DXPointer1
    {
        get { return _DXPointer1; }
        set { _DXPointer1 = value; }
    }

    public int DXPointer2
    {
        get { return _DXPointer2; }
        set { _DXPointer2 = value; }
    }

    public int DXPointer3
    {
        get { return _DXPointer3; }
        set { _DXPointer3 = value; }
    }

    public int DXPointer4
    {
        get { return _DXPointer4; }
        set { _DXPointer4 = value; }
    }

    public int DXPointer5
    {
        get { return _DXPointer5; }
        set { _DXPointer5 = value; }
    }

    public int DXPointer6
    {
        get { return _DXPointer6; }
        set { _DXPointer6 = value; }
    }

    public int DXPointer7
    {
        get { return _DXPointer7; }
        set { _DXPointer7 = value; }
    }

    public int DXPointer8
    {
        get { return _DXPointer8; }
        set { _DXPointer8 = value; }
    }

    public bool IncludeInSubmission
    {
        get { return _IncludeInSubmission; }
        set { _IncludeInSubmission = value; }
    }
    
    public string BillingStatus
    {
        get { return _BillingStatus; }
        set { _BillingStatus = value; }
    }
    
    public string Drug
    {
        get { return _Drug; }
        set { _Drug = value; }
    }
    
    public string UnitCode
    {
        get { return _UnitCode; }
        set { _UnitCode = value; }
    }
    
    public bool IsSuperBill
    {
        get { return _IsSuperBill; }
        set { _IsSuperBill = value; }
    }
    
    public decimal? AllowedAmount
    {
        get { return _AllowedAmount; }
        set { _AllowedAmount = value; }
    }
    
    public decimal? PaidAmount
    {
        get { return _PaidAmount; }
        set { _PaidAmount = value; }
    }
    
    public decimal? PriInsPaidAmount
    {
        get { return _PriInsPaidAmount; }
        set { _PriInsPaidAmount = value; }
    }
    
    public decimal? SecInsPaidAmount
    {
        get { return _SecInsPaidAmount; }
        set { _SecInsPaidAmount = value; }
    }
    
    public decimal? OTHInsPaidAmount
    {
        get { return _OTHInsPaidAmount; }
        set { _OTHInsPaidAmount = value; }
    }
    
    public decimal? PatPaidAmount
    {
        get { return _PatPaidAmount; }
        set { _PatPaidAmount = value; }
    }
    
    public decimal? AdjustedAmount
    {
        get { return _AdjustedAmount; }
        set { _AdjustedAmount = value; }
    }
    
    public decimal? WriteOffAmount
    {
        get { return _WriteOffAmount; }
        set { _WriteOffAmount = value; }
    }
    
    public decimal? BalanceDue
    {
        get { return _BalanceDue; }
        set { _BalanceDue = value; }
    }
    
    public DateTime CreatedDate
    {
        get { return _CreatedDate; }
        set { _CreatedDate = value; }
    }
    
    public long CreatedById
    {
        get { return _CreatedById; }
        set { _CreatedById = value; }
    }
    
    public DateTime ModifiedDate
    {
        get { return _ModifiedDate; }
        set { _ModifiedDate = value; }
    }
    
    public long ModifiedById
    {
        get { return _ModifiedById; }
        set { _ModifiedById = value; }
    }
    
    public bool Deleted
    {
        get { return _Deleted; }
        set { _Deleted = value; }
    }
    
    #endregion

}