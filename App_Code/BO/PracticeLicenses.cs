using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PracticeLicenses
/// </summary>
public class PracticeLicenses
{
	public PracticeLicenses()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    #region " Private Members "
    private Int64 _LicenseId;
    private long _PracticeId;
    private string _LicenseName = string.Empty;
    private DateTime _CreatedDate;
    private long _CreatedById;
    private DateTime _ModifiedDate;
    private long _ModifiedById;
    bool _Deleted = false;
    #endregion

    #region " Properties "

    public Int64 LicenseId
    {
        get { return _LicenseId; }
        set { _LicenseId = value; }
    }

    public long PracticeId
    {
        get { return _PracticeId; }
        set { _PracticeId = value; }
    }

    public string LicenseName
    {
        get { return _LicenseName; }
        set { _LicenseName = value; }
    }

    public DateTime CreatedDate
    {
        get { return _CreatedDate; }
        set { _CreatedDate = value; }
    }

    public long CreatedById
    {
        get { return _CreatedById; }
        set { _CreatedById = value; }
    }

    public DateTime ModifiedDate
    {
        get { return _ModifiedDate; }
        set { _ModifiedDate = value; }
    }

    public long ModifiedById
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