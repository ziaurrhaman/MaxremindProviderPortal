
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class PatientInvoices
{
    public PatientInvoices()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    #region Private Members

    long _PatientInvoiceId;
    long? _InvoiceFileId;
    long _PatientId;
    long _PracticeId;
    Decimal? _TotalCharges;
    Decimal? _AdjustedAmount;
    Decimal? _WriteOff;
    Decimal? _TotalPaidAmount;
    Decimal? _InsPaidAmount;
    Decimal? _PatPaidAmount;
    Decimal? _TotalBalance;
    Decimal? _AmountDue;
    DateTime? _StatementDate;
    DateTime? _DueDate;
    DateTime? _LastPrintingDate;
    string _SubmissionMethod = string.Empty;
    DateTime? _SubmissionDate;
    string _InvoiceContents = string.Empty;

    long _CreatedById;
    DateTime _CreatedDate;
    long _ModifiedById;
    DateTime _ModifiedDate;
    bool _Deleted;

    #endregion

    #region Properties

    public long PatientInvoiceId
    {
        get { return _PatientInvoiceId; }
        set { _PatientInvoiceId = value; }
    }

    public long? InvoiceFileId
    {
        get { return _InvoiceFileId; }
        set { _InvoiceFileId = value; }
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

    public Decimal? TotalCharges
    {
        get { return _TotalCharges; }
        set { _TotalCharges = value; }
    }

    public Decimal? AdjustedAmount
    {
        get { return _AdjustedAmount; }
        set { _AdjustedAmount = value; }
    }

    public Decimal? WriteOff
    {
        get { return _WriteOff; }
        set { _WriteOff = value; }
    }

    public Decimal? TotalPaidAmount
    {
        get { return _TotalPaidAmount; }
        set { _TotalPaidAmount = value; }
    }

    public Decimal? InsPaidAmount
    {
        get { return _InsPaidAmount; }
        set { _InsPaidAmount = value; }
    }

    public Decimal? PatPaidAmount
    {
        get { return _PatPaidAmount; }
        set { _PatPaidAmount = value; }
    }

    public Decimal? TotalBalance
    {
        get { return _TotalBalance; }
        set { _TotalBalance = value; }
    }

    public Decimal? AmountDue
    {
        get { return _AmountDue; }
        set { _AmountDue = value; }
    }

    public DateTime? StatementDate
    {
        get { return _StatementDate; }
        set { _StatementDate = value; }
    }

    public DateTime? DueDate
    {
        get { return _DueDate; }
        set { _DueDate = value; }
    }

    public DateTime? LastPrintingDate
    {
        get { return _LastPrintingDate; }
        set { _LastPrintingDate = value; }
    }

    public string SubmissionMethod
    {
        get { return _SubmissionMethod; }
        set { _SubmissionMethod = value; }
    }

    public DateTime? SubmissionDate
    {
        get { return _SubmissionDate; }
        set { _SubmissionDate = value; }
    }

    public string InvoiceContents
    {
        get { return _InvoiceContents; }
        set { _InvoiceContents = value; }
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