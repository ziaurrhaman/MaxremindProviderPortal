using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Immunizations
/// </summary>
public class Immunizations
{
	public Immunizations()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    #region " Private Members "

	long _ImmunizationId;
	string _ImmunizationName = string.Empty;
	string _CvxCode = string.Empty;
	string _LongName = string.Empty;
	bool _Deleted = false;
	Nullable<DateTime> _CreatedDate;
	long _CreatedById;
	Nullable<DateTime> _ModifiedDate;
	Nullable<long> _ModifiedById;
	long _PracticeId;

    #endregion

    #region " Properties "

    public long ImmunizationId
    {
        get { return _ImmunizationId; }
        set { _ImmunizationId = value; }
    }

    public string ImmunizationName
    {
        get { return _ImmunizationName; }
        set { _ImmunizationName = value; }
    }

    public string CvxCode
    {
        get { return _CvxCode; }
        set { _CvxCode = value; }
    }

    public string LongName
    {
        get { return _LongName; }
        set { _LongName = value; }
    }

    public bool Deleted
    {
        get { return _Deleted; }
        set { _Deleted = value; }
    }

    public Nullable<DateTime> CreatedDate
    {
        get { return _CreatedDate; }
        set { _CreatedDate = value; }
    }

    public long CreatedById
    {
        get { return _CreatedById; }
        set { _CreatedById = value; }
    }

    public Nullable<DateTime> ModifiedDate
    {
        get { return _ModifiedDate; }
        set { _ModifiedDate = value; }
    }

    public Nullable<long> ModifiedById
    {
        get { return _ModifiedById; }
        set { _ModifiedById = value; }
    }

    public long PracticeId
    {
        get { return _PracticeId; }
        set { _PracticeId = value; }
    }

    #endregion
}