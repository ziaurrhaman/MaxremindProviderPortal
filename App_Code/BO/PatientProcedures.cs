using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PatientProcedures
/// </summary>
public class PatientProcedures
{
	public PatientProcedures()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    #region " Private Members "

    Int64 _ProcedureId;
    Int64 _PatientId;
    Int64 _ChartId;
    string _CPTCode = string.Empty;
    string _Drug = string.Empty;
    string _UnitCode = string.Empty;
    int? _ServiceUnits;
    string _Modifier1 = string.Empty;
    string _Modifier2 = string.Empty;
    string _Modifier3 = string.Empty;
    string _Modifier4 = string.Empty;
    int _SequenceNumber;
    DateTime? _CreatedDate;
    Int64? _CreatedById;
    DateTime? _ModifiedDate;
    Int64? _ModifiedById;

    bool _Deleted = false;
    #endregion

    #region " Properties "

    public Int64 ProcedureId
    {
        get { return _ProcedureId; }
        set { _ProcedureId = value; }
    }

    public Int64 PatientId
    {
        get { return _PatientId; }
        set { _PatientId = value; }
    }

    public Int64 ChartId
    {
        get { return _ChartId; }
        set { _ChartId = value; }
    }

    public string CPTCode
    {
        get { return _CPTCode; }
        set { _CPTCode = value; }
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

    public int? ServiceUnits
    {
        get { return _ServiceUnits; }
        set { _ServiceUnits = value; }
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

    public int SequenceNumber
    {
        get { return _SequenceNumber; }
        set { _SequenceNumber = value; }
    }

    public DateTime? CreatedDate
    {
        get { return _CreatedDate; }
        set { _CreatedDate = value; }
    }

    public Int64? CreatedById
    {
        get { return _CreatedById; }
        set { _CreatedById = value; }
    }

    public DateTime? ModifiedDate
    {
        get { return _ModifiedDate; }
        set { _ModifiedDate = value; }
    }

    public Int64? ModifiedById
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