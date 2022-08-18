using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for AppointmentTypes
/// </summary>
public class AppointmentTypes
{
	public AppointmentTypes()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    #region " Private Members "

    int _AppointmentTypeId;
    long _PracticeId;
    string _AppointmentType = string.Empty;
    TimeSpan _DefaultTime;
    private Nullable<Int64> _CreatedById;
    private Nullable<DateTime> _CreatedDate;
    private Nullable<Int64> _ModifiedById;
    private Nullable<DateTime> _ModifiedDate;

    bool _Deleted = false;
    #endregion

    #region " Properties "

    public int AppointmentTypeId
    {
        get { return _AppointmentTypeId; }
        set { _AppointmentTypeId = value; }
    }
    public long PracticeId
    {
        get { return _PracticeId; }
        set { _PracticeId = value; }
    }
    public string AppointmentType
    {
        get { return _AppointmentType; }
        set { _AppointmentType = value; }
    }

    public TimeSpan DefaultTime
    {
        get { return _DefaultTime; }
        set { _DefaultTime = value; }
    }

    public Nullable<Int64> CreatedById
    {
        get { return _CreatedById; }
        set { _CreatedById = value; }
    }

    public Nullable<DateTime> CreatedDate
    {
        get { return _CreatedDate; }
        set { _CreatedDate = value; }
    }

    public Nullable<Int64> ModifiedById
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