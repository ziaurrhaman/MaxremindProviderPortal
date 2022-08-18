using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ClaimAdjustments
/// </summary>
public class ClaimAdjustments
{
	public ClaimAdjustments()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    #region " Private Members "

    Int64 _ClaimAdjustmentsId;
    Int64 _ClaimPaymentId;
    string _ClaimNumber;
    string _AdjustmentGroupCode;
    string _AdjustmentReasonCode;
    decimal _AdjustmentAmount;
    double _Quantity;
    Int64 _CreatedById;
    DateTime _CreatedDate;
    Int64 _ModifiedById;
    DateTime _ModifiedDate;

    bool _Deleted = false;
    #endregion

    #region " Properties "

    public Int64 ClaimAdjustmentsId
    {
        get { return _ClaimAdjustmentsId; }
        set { _ClaimAdjustmentsId = value; }
    }

    public Int64 ClaimPaymentId   
    {
        get { return _ClaimPaymentId; }
        set { _ClaimPaymentId = value; }
    }

    public string ClaimNumber
    {
        get { return _ClaimNumber; }
        set { _ClaimNumber = value; }
    }

    public string AdjustmentGroupCode
    {
        get { return _AdjustmentGroupCode; }
        set { _AdjustmentGroupCode = value; }
    }

    public string AdjustmentReasonCode
    {
        get { return _AdjustmentReasonCode; }
        set { _AdjustmentReasonCode = value; }
    }

    public decimal AdjustmentAmount
    {
        get { return _AdjustmentAmount; }
        set { _AdjustmentAmount = value; }
    }

    public double Quantity
    {
        get { return _Quantity; }
        set { _Quantity = value; }
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