using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ProviderAdjustments
/// </summary>
public class ProviderAdjustments
{
	public ProviderAdjustments()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    #region " Private Members "

    Int64 _ProviderAdjustmentsId;
    Int64 _ERAId;
    string _ReferenceId;
    DateTime? _ProviderFiscalDate;
    string _ProviderAdjustmentReasonCode;
    string _ReferenceIdentification;
    decimal _ProviderAdjustmentAmount;
    string _ProviderAdjustmentReasonCode1;
    string _ReferenceIdentification1;
    decimal _ReferenceAdjustmentAmount1;
    string _ProviderAdjustmentReasonCode2;
    string _ReferenceIdentification2;
    decimal _ProviderAdjustmentAmount2;
    string _ProviderAdjustmentReasonCode3;
    string _ReferenceIdentification3;
    decimal _ProviderAdjustmentAmount3;
    Int64 _CreatedById;
    DateTime _CreatedDate;
    Int64 _ModifiedById;
    DateTime _ModifiedDate;

    bool _Deleted = false;
    #endregion

    #region " Properties "

    public Int64 ProviderAdjustmentsId
    {
        get { return _ProviderAdjustmentsId; }
        set { _ProviderAdjustmentsId = value; }
    }

    public Int64 ERAId
    {
        get { return _ERAId; }
        set { _ERAId = value; }
    }

    public string ReferenceId
    {
        get { return _ReferenceId; }
        set { _ReferenceId = value; }
    }

    public DateTime? ProviderFiscalDate
    {
        get { return _ProviderFiscalDate; }
        set { _ProviderFiscalDate = value; }
    }

    public string ProviderAdjustmentReasonCode
    {
        get { return _ProviderAdjustmentReasonCode; }
        set { _ProviderAdjustmentReasonCode = value; }
    }

    public string ReferenceIdentification
    {
        get { return _ReferenceIdentification; }
        set { _ReferenceIdentification = value; }
    }

    public decimal ProviderAdjustmentAmount
    {
        get { return _ProviderAdjustmentAmount; }
        set { _ProviderAdjustmentAmount = value; }
    }

    public string ProviderAdjustmentReasonCode1
    {
        get { return _ProviderAdjustmentReasonCode1; }
        set { _ProviderAdjustmentReasonCode1 = value; }
    }

    public string ReferenceIdentification1
    {
        get { return _ReferenceIdentification1; }
        set { _ReferenceIdentification1 = value; }
    }

    public decimal ReferenceAdjustmentAmount1
    {
        get { return _ReferenceAdjustmentAmount1; }
        set { _ReferenceAdjustmentAmount1 = value; }
    }

    public string ProviderAdjustmentReasonCode2
    {
        get { return _ProviderAdjustmentReasonCode2; }
        set { _ProviderAdjustmentReasonCode2 = value; }
    }

    public string ReferenceIdentification2
    {
        get { return _ReferenceIdentification2; }
        set { _ReferenceIdentification2 = value; }
    }

    public decimal ProviderAdjustmentAmount2
    {
        get { return _ProviderAdjustmentAmount2; }
        set { _ProviderAdjustmentAmount2 = value; }
    }

    public string ProviderAdjustmentReasonCode3
    {
        get { return _ProviderAdjustmentReasonCode3; }
        set { _ProviderAdjustmentReasonCode3 = value; }
    }

    public string ReferenceIdentification3
    {
        get { return _ReferenceIdentification3; }
        set { _ReferenceIdentification3 = value; }
    }

    public decimal ProviderAdjustmentAmount3
    {
        get { return _ProviderAdjustmentAmount3; }
        set { _ProviderAdjustmentAmount3 = value; }
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