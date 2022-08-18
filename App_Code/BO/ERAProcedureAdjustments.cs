using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ProcedureAdjustments
/// </summary>
public class ERAProcedureAdjustments
{
	public ERAProcedureAdjustments()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    #region " Private Members "

Int64 _ERAProcedureAdjustmentsId;
Int64 _ERAProcedurePaymentsId;
string _AdjustmentGroupCode;
string _AdjustmentReasonCode;
decimal _AdjustmentAmount;
double _AdjustedUnits;
string _AdjustmentReasonCode1;
decimal _AdjustmentAmount1;
double _AdjustedUnits1;
string _AdjustmentReasonCode2;
decimal _AdjustmentAmount2;
double _AdjustmentUnits2;
string _AdjustmentReasonCode3;
decimal _AdjustmentAmount3;
double _AdjustmentUnits3;
string _AdjustmentReasonCode4;
decimal _AdjustmentAmount4;
double _AdjustmentUnits4;
string _AdjustmentReasonCode5;
decimal _AdjustmentAmount5;
double _AdjustmentUnits5;
Int64 _CreatedById;
DateTime _CreatedDate;
Int64 _ModifiedById;
DateTime _ModifiedDate;

bool _Deleted = false;
#endregion

#region " Properties "

public Int64 ERAProcedureAdjustmentsId {
	get { return _ERAProcedureAdjustmentsId; }
	set { _ERAProcedureAdjustmentsId = value; }
}

public Int64 ERAProcedurePaymentsId {
	get { return _ERAProcedurePaymentsId; }
	set { _ERAProcedurePaymentsId = value; }
}

public string AdjustmentGroupCode {
	get { return _AdjustmentGroupCode; }
	set { _AdjustmentGroupCode = value; }
}

public string AdjustmentReasonCode {
	get { return _AdjustmentReasonCode; }
	set { _AdjustmentReasonCode = value; }
}

public decimal AdjustmentAmount {
	get { return _AdjustmentAmount; }
	set { _AdjustmentAmount = value; }
}

public double AdjustedUnits {
	get { return _AdjustedUnits; }
	set { _AdjustedUnits = value; }
}

public string AdjustmentReasonCode1 {
	get { return _AdjustmentReasonCode1; }
	set { _AdjustmentReasonCode1 = value; }
}

public decimal AdjustmentAmount1 {
	get { return _AdjustmentAmount1; }
	set { _AdjustmentAmount1 = value; }
}

public double AdjustedUnits1 {
	get { return _AdjustedUnits1; }
	set { _AdjustedUnits1 = value; }
}

public string AdjustmentReasonCode2 {
	get { return _AdjustmentReasonCode2; }
	set { _AdjustmentReasonCode2 = value; }
}

public decimal AdjustmentAmount2 {
	get { return _AdjustmentAmount2; }
	set { _AdjustmentAmount2 = value; }
}

public double AdjustmentUnits2 {
	get { return _AdjustmentUnits2; }
	set { _AdjustmentUnits2 = value; }
}

public string AdjustmentReasonCode3 {
	get { return _AdjustmentReasonCode3; }
	set { _AdjustmentReasonCode3 = value; }
}

public decimal AdjustmentAmount3 {
	get { return _AdjustmentAmount3; }
	set { _AdjustmentAmount3 = value; }
}

public double AdjustmentUnits3 {
	get { return _AdjustmentUnits3; }
	set { _AdjustmentUnits3 = value; }
}

public string AdjustmentReasonCode4 {
	get { return _AdjustmentReasonCode4; }
	set { _AdjustmentReasonCode4 = value; }
}

public decimal AdjustmentAmount4 {
	get { return _AdjustmentAmount4; }
	set { _AdjustmentAmount4 = value; }
}

public double AdjustmentUnits4 {
	get { return _AdjustmentUnits4; }
	set { _AdjustmentUnits4 = value; }
}

public string AdjustmentReasonCode5 {
	get { return _AdjustmentReasonCode5; }
	set { _AdjustmentReasonCode5 = value; }
}

public decimal AdjustmentAmount5 {
	get { return _AdjustmentAmount5; }
	set { _AdjustmentAmount5 = value; }
}

public double AdjustmentUnits5 {
	get { return _AdjustmentUnits5; }
	set { _AdjustmentUnits5 = value; }
}

public Int64 CreatedById {
	get { return _CreatedById; }
	set { _CreatedById = value; }
}

public DateTime CreatedDate {
	get { return _CreatedDate; }
	set { _CreatedDate = value; }
}

public Int64 ModifiedById {
	get { return _ModifiedById; }
	set { _ModifiedById = value; }
}

public DateTime ModifiedDate {
	get { return _ModifiedDate; }
	set { _ModifiedDate = value; }
}

public bool Deleted {
	get { return _Deleted; }
	set { _Deleted = value; }
}

#endregion
}