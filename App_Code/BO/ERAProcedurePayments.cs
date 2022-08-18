using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ProcedurePayments
/// </summary>
public class ERAProcedurePayments
{
	public ERAProcedurePayments()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    #region " Private Members "

    Int64 _ERAProcedurePaymentsId;
    Int64 _ERAClaimPaymentsId;
    string _ProcedureQualifier;
    string _ProcedureCode;
    string _ProcedureModifier1;
    string _ProcedureModifier2;
    string _ProcedureModifier3;
    string _ProcedureModifier4;
    decimal _ChargedAmount;
    decimal _PaidAmount;
    string _RevenueCode;
    double _PaidUnits;
    string _SubmittedProcedureQualifier;
    string _SubmittedProcedure;
    string _SubmittedModifier1;
    string _SubmittedModifier2;
    string _SubmittedModifier3;
    string _SubmittedModifier4;
    string _OriginalUnits;
    DateTime? _ServiceStartDate;
    DateTime? _ServiceEndDate;
    string _LineItemControlNumber;
    string _ReferenceIdQualifier;
    string _ReferenceId;
    decimal _ServiceAllowedAmount;
    Int64 _CreatedById;
    DateTime _CreatedDate;
    Int64 _ModifiedById;
    DateTime _ModifiedDate;

    bool _Deleted = false;
    #endregion

    #region " Properties "

    public Int64 ERAProcedurePaymentsId
    {
        get { return _ERAProcedurePaymentsId; }
        set { _ERAProcedurePaymentsId = value; }
    }

    public Int64 ERAClaimPaymentsId
    {
        get { return _ERAClaimPaymentsId; }
        set { _ERAClaimPaymentsId = value; }
    }

    public string ProcedureQualifier
    {
        get { return _ProcedureQualifier; }
        set { _ProcedureQualifier = value; }
    }

    public string ProcedureCode
    {
        get { return _ProcedureCode; }
        set { _ProcedureCode = value; }
    }

    public string ProcedureModifier1
    {
        get { return _ProcedureModifier1; }
        set { _ProcedureModifier1 = value; }
    }

    public string ProcedureModifier2
    {
        get { return _ProcedureModifier2; }
        set { _ProcedureModifier2 = value; }
    }

    public string ProcedureModifier3
    {
        get { return _ProcedureModifier3; }
        set { _ProcedureModifier3 = value; }
    }

    public string ProcedureModifier4
    {
        get { return _ProcedureModifier4; }
        set { _ProcedureModifier4 = value; }
    }

    public decimal ChargedAmount
    {
        get { return _ChargedAmount; }
        set { _ChargedAmount = value; }
    }

    public decimal PaidAmount
    {
        get { return _PaidAmount; }
        set { _PaidAmount = value; }
    }

    public string RevenueCode
    {
        get { return _RevenueCode; }
        set { _RevenueCode = value; }
    }

    public double PaidUnits
    {
        get { return _PaidUnits; }
        set { _PaidUnits = value; }
    }

    public string SubmittedProcedureQualifier
    {
        get { return _SubmittedProcedureQualifier; }
        set { _SubmittedProcedureQualifier = value; }
    }

    public string SubmittedProcedure
    {
        get { return _SubmittedProcedure; }
        set { _SubmittedProcedure = value; }
    }

    public string SubmittedModifier1
    {
        get { return _SubmittedModifier1; }
        set { _SubmittedModifier1 = value; }
    }

    public string SubmittedModifier2
    {
        get { return _SubmittedModifier2; }
        set { _SubmittedModifier2 = value; }
    }

    public string SubmittedModifier3
    {
        get { return _SubmittedModifier3; }
        set { _SubmittedModifier3 = value; }
    }

    public string SubmittedModifier4
    {
        get { return _SubmittedModifier4; }
        set { _SubmittedModifier4 = value; }
    }

    public string OriginalUnits
    {
        get { return _OriginalUnits; }
        set { _OriginalUnits = value; }
    }

    public DateTime? ServiceStartDate
    {
        get { return _ServiceStartDate; }
        set { _ServiceStartDate = value; }
    }

    public DateTime? ServiceEndDate
    {
        get { return _ServiceEndDate; }
        set { _ServiceEndDate = value; }
    }

    public string LineItemControlNumber
    {
        get { return _LineItemControlNumber; }
        set { _LineItemControlNumber = value; }
    }

    public string ReferenceIdQualifier
    {
        get { return _ReferenceIdQualifier; }
        set { _ReferenceIdQualifier = value; }
    }

    public string ReferenceId
    {
        get { return _ReferenceId; }
        set { _ReferenceId = value; }
    }

    public decimal ServiceAllowedAmount
    {
        get { return _ServiceAllowedAmount; }
        set { _ServiceAllowedAmount = value; }
    }

    public Int64 CreatedById
    {
        get { return _CreatedById; }
        set { _CreatedById = value; }
    }

    public DateTime CreatedDate
    {
        get { return _CreatedDate; }
        set { _CreatedDate = value; }
    }

    public Int64 ModifiedById
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