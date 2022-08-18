using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ProcedureAdjustments
/// </summary>
public class ProcedureAdjustments
{
	public ProcedureAdjustments()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    #region " Private Members "

    long _ProcedureAdjustmentId;
    long _ProcedurePaymentsId;
    long? _ClaimId;
    string _GroupCode = string.Empty;
    string _ReasonCode = string.Empty;
    double _AdjustedUnits = 0;
    decimal _AdjustedAmount = 0;
    string _RemarkCode1 = string.Empty;
    string _RemarkCode2 = string.Empty;
    string _RemarkCode3 = string.Empty;
    string _RemarkCode4 = string.Empty;
    string _RemarkCode5 = string.Empty;

    public string PaymentSource { get; set; }
    public string ChargedProcedure { get; set; }

    long _CreatedById;
    DateTime _CreatedDate;
    long _ModifiedById;
    DateTime _ModifiedDate;
    bool _Deleted = false;

    #endregion

    #region " Properties "

    public long ProcedureAdjustmentId
    {
        get { return _ProcedureAdjustmentId; }
        set { _ProcedureAdjustmentId = value; }
    }

    public long ProcedurePaymentsId
    {
        get { return _ProcedurePaymentsId; }
        set { _ProcedurePaymentsId = value; }
    }

    public long? ClaimId
    {
        get { return _ClaimId; }
        set { _ClaimId = value; }
    }

    public string GroupCode
    {
        get { return _GroupCode; }
        set { _GroupCode = value; }
    }

    public string ReasonCode
    {
        get { return _ReasonCode; }
        set { _ReasonCode = value; }
    }

    public double AdjustedUnits
    {
        get { return _AdjustedUnits; }
        set { _AdjustedUnits = value; }
    }

    public decimal AdjustedAmount
    {
        get { return _AdjustedAmount; }
        set { _AdjustedAmount = value; }
    }

    public string RemarkCode1
    {
        get { return _RemarkCode1; }
        set { _RemarkCode1 = value; }
    }

    public string RemarkCode2
    {
        get { return _RemarkCode2; }
        set { _RemarkCode2 = value; }
    }

    public string RemarkCode3
    {
        get { return _RemarkCode3; }
        set { _RemarkCode3 = value; }
    }

    public string RemarkCode4
    {
        get { return _RemarkCode4; }
        set { _RemarkCode4 = value; }
    }

    public string RemarkCode5
    {
        get { return _RemarkCode5; }
        set { _RemarkCode5 = value; }
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