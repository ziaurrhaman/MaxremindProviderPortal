    using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CashRegister
/// </summary>
public class CashRegister
{
	public CashRegister()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    #region " Private Members "

    long _CashRegisterId;
    long _PatientId;
    long _PracticeId;
    long _AppointmentId;
    Nullable<decimal> _CoPayDue;
    Nullable<decimal> _CoPayment;
    Nullable<decimal> _OtherCharges;
    Nullable<decimal> _VisitCharges;
    Nullable<decimal> _PreviousBalance;
    Nullable<decimal> _PreviousBalancePayment;
    Nullable<decimal> _VisitPayment;
    Nullable<decimal> _OtherPayment;
    string _PreviousBalancePaymentMethod = string.Empty;
    string _CoPaymentMethod = string.Empty;
    string _VisitPaymentMethod = string.Empty;
    string _OtherPaymentMethod = string.Empty;
    string _PreviousBalanceRefNumber = string.Empty;
    string _CoPaymentRefNumber = string.Empty;
    string _VisitRefNumber = string.Empty;
    string _OtherRefNumber = string.Empty;
    string _PreviousBalanceNotes = string.Empty;
    string _CoPaymentNotes = string.Empty;
    string _VisitNotes = string.Empty;
    string _OtherNotes = string.Empty;
    Nullable<decimal> _WriteOffAmount;
    Nullable<decimal> _AdvancePayment;
    Nullable<decimal> _TotalCharges;
    Nullable<decimal> _TotalPayments;
    long _CreatedById;
    DateTime _CreatedDate;
    long _ModifiedById;
    DateTime _ModifiedDate;

    bool _Deleted = false;
    #endregion

    #region " Properties "

    public long CashRegisterId
    {
        get { return _CashRegisterId; }
        set { _CashRegisterId = value; }
    }

    public long PatientId
    {
        get { return _PatientId; }
        set { _PatientId = value; }
    }

    public long PracticeId
    {
        get { return _PracticeId; }
        set { _PracticeId = value; }
    }

    public long AppointmentId
    {
        get { return _AppointmentId; }
        set { _AppointmentId = value; }
    }

    public Nullable<decimal> CoPayDue
    {
        get { return _CoPayDue; }
        set { _CoPayDue = value; }
    }

    public Nullable<decimal> CoPayment
    {
        get { return _CoPayment; }
        set { _CoPayment = value; }
    }

    public Nullable<decimal> OtherCharges
    {
        get { return _OtherCharges; }
        set { _OtherCharges = value; }
    }

    public Nullable<decimal> VisitCharges
    {
        get { return _VisitCharges; }
        set { _VisitCharges = value; }
    }

    public Nullable<decimal> PreviousBalance
    {
        get { return _PreviousBalance; }
        set { _PreviousBalance = value; }
    }

    public Nullable<decimal> PreviousBalancePayment
    {
        get { return _PreviousBalancePayment; }
        set { _PreviousBalancePayment = value; }
    }

    public Nullable<decimal> VisitPayment
    {
        get { return _VisitPayment; }
        set { _VisitPayment = value; }
    }

    public Nullable<decimal> OtherPayment
    {
        get { return _OtherPayment; }
        set { _OtherPayment = value; }
    }

    public string PreviousBalancePaymentMethod
    {
        get { return _PreviousBalancePaymentMethod; }
        set { _PreviousBalancePaymentMethod = value; }
    }

    public string CoPaymentMethod
    {
        get { return _CoPaymentMethod; }
        set { _CoPaymentMethod = value; }
    }

    public string VisitPaymentMethod
    {
        get { return _VisitPaymentMethod; }
        set { _VisitPaymentMethod = value; }
    }

    public string OtherPaymentMethod
    {
        get { return _OtherPaymentMethod; }
        set { _OtherPaymentMethod = value; }
    }

    public string PreviousBalanceRefNumber
    {
        get { return _PreviousBalanceRefNumber; }
        set { _PreviousBalanceRefNumber = value; }
    }

    public string CoPaymentRefNumber
    {
        get { return _CoPaymentRefNumber; }
        set { _CoPaymentRefNumber = value; }
    }

    public string VisitRefNumber
    {
        get { return _VisitRefNumber; }
        set { _VisitRefNumber = value; }
    }

    public string OtherRefNumber
    {
        get { return _OtherRefNumber; }
        set { _OtherRefNumber = value; }
    }

    public string PreviousBalanceNotes
    {
        get { return _PreviousBalanceNotes; }
        set { _PreviousBalanceNotes = value; }
    }

    public string CoPaymentNotes
    {
        get { return _CoPaymentNotes; }
        set { _CoPaymentNotes = value; }
    }

    public string VisitNotes
    {
        get { return _VisitNotes; }
        set { _VisitNotes = value; }
    }

    public string OtherNotes
    {
        get { return _OtherNotes; }
        set { _OtherNotes = value; }
    }

    public Nullable<decimal> WriteOffAmount
    {
        get { return _WriteOffAmount; }
        set { _WriteOffAmount = value; }
    }

    public Nullable<decimal> AdvancePayment
    {
        get { return _AdvancePayment; }
        set { _AdvancePayment = value; }
    }

    public Nullable<decimal> TotalCharges
    {
        get { return _TotalCharges; }
        set { _TotalCharges = value; }
    }

    public Nullable<decimal> TotalPayments
    {
        get { return _TotalPayments; }
        set { _TotalPayments = value; }
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