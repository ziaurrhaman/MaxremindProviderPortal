using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ProcedurePayments
/// </summary>
public class ProcedurePayments
{
	public ProcedurePayments()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    
    #region " Private Members "
    
    private long _ProcedurePaymentsId;
    private long _ClaimId;
    private string _ClaimNumber;
    private long _ClaimChargesId;
    private string _CheckNumber = string.Empty;
    private DateTime? _CheckDate;
    private string _PaymentSource = string.Empty;
    private string _PaymentMethod = string.Empty;
    private string _LineItemNumber = string.Empty;
    private string _RevenueCode = string.Empty;
    private string _ChargedProcedure = string.Empty;
    private string _PaidProcedure = string.Empty;
    private string _ICN = string.Empty;
    private decimal _AllowedAmount;
    private decimal _PaidAmount;
    private double _PaidUnits = double.MinValue;
    private decimal _AdjustedAmount;
    private long _PayerId;
    
    private long? _ERAMasterId;
    
    public List<ProcedureAdjustments> listProcedureAdjustments { get; set; }
    
    private long _CreatedById;
    private DateTime _CreatedDate;
    private long _ModifiedById;
    private DateTime _ModifiedDate;
    private bool _Deleted = false;
    
    #endregion
    
    #region " Properties "

    public long ProcedurePaymentsId
    {
        get { return _ProcedurePaymentsId; }
        set { _ProcedurePaymentsId = value; }
    }

    public long ClaimId
    {
        get { return _ClaimId; }
        set { _ClaimId = value; }
    }

    public string ClaimNumber
    {
        get { return _ClaimNumber; }
        set { _ClaimNumber = value; }
    }

    public long ClaimChargesId
    {
        get { return _ClaimChargesId; }
        set { _ClaimChargesId = value; }
    }

    public string CheckNumber
    {
        get { return _CheckNumber; }
        set { _CheckNumber = value; }
    }

    public string ICN
    {
        get { return _ICN; }
        set { _ICN = value; }
    }

    public DateTime? CheckDate
    {
        get { return _CheckDate; }
        set { _CheckDate = value; }
    }

    public string PaymentSource
    {
        get { return _PaymentSource; }
        set { _PaymentSource = value; }
    }

    public string PaymentMethod
    {
        get { return _PaymentMethod; }
        set { _PaymentMethod = value; }
    }

    public string LineItemNumber
    {
        get { return _LineItemNumber; }
        set { _LineItemNumber = value; }
    }

    public string RevenueCode
    {
        get { return _RevenueCode; }
        set { _RevenueCode = value; }
    }

    public string ChargedProcedure
    {
        get { return _ChargedProcedure; }
        set { _ChargedProcedure = value; }
    }

    public string PaidProcedure
    {
        get { return _PaidProcedure; }
        set { _PaidProcedure = value; }
    }

    public decimal AllowedAmount
    {
        get { return _AllowedAmount; }
        set { _AllowedAmount = value; }
    }

    public decimal PaidAmount
    {
        get { return _PaidAmount; }
        set { _PaidAmount = value; }
    }

    public double PaidUnits
    {
        get { return _PaidUnits; }
        set { _PaidUnits = value; }
    }

    public decimal AdjustedAmount
    {
        get { return _AdjustedAmount; }
        set { _AdjustedAmount = value; }
    }
    
    public long PayerId
    {
        get { return _PayerId; }
        set { _PayerId = value; }
    }
    
    public long? ERAMasterId
    {
        get { return _ERAMasterId; }
        set { _ERAMasterId = value; }
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