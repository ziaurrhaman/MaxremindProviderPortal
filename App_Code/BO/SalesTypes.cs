using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SalesTypes
/// </summary>
public class SalesTypes
{
	public SalesTypes()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    
    #region " Private Members "
    
    long _SalesTypeId;
    Nullable<long> _PracticeId;
    string _SalesTypeName = string.Empty;
    double _CalculationFactor = double.MinValue;
    bool _TaxIncluded = false;
    string _Status = string.Empty;
    Nullable<long> _CreatedById;
    Nullable<DateTime> _CreatedDate;
    Nullable<long> _ModifiedById;
    Nullable<DateTime> _ModifiedDate;
    
    bool _Deleted = false;
    #endregion

    #region " Properties "

    public long SalesTypeId
    {
        get { return _SalesTypeId; }
        set { _SalesTypeId = value; }
    }

    public Nullable<long> PracticeId
    {
        get { return _PracticeId; }
        set { _PracticeId = value; }
    }

    public string SalesTypeName
    {
        get { return _SalesTypeName; }
        set { _SalesTypeName = value; }
    }

    public double CalculationFactor
    {
        get { return _CalculationFactor; }
        set { _CalculationFactor = value; }
    }

    public bool TaxIncluded
    {
        get { return _TaxIncluded; }
        set { _TaxIncluded = value; }
    }

    public string Status
    {
        get { return _Status; }
        set { _Status = value; }
    }

    public Nullable<long> CreatedById
    {
        get { return _CreatedById; }
        set { _CreatedById = value; }
    }

    public Nullable<DateTime> CreatedDate
    {
        get { return _CreatedDate; }
        set { _CreatedDate = value; }
    }

    public Nullable<long> ModifiedById
    {
        get { return _ModifiedById; }
        set { _ModifiedById = value; }
    }

    public Nullable<DateTime> ModifiedDate
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