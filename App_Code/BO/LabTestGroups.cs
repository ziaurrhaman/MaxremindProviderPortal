using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for LabTestGroups
/// </summary>
public class LabTestGroups
{
	public LabTestGroups()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    #region " Private Members "

    Int64 _LabTestGroupId;
    string _Name = string.Empty;
    Int64 _PracticeId;
    private Nullable<Int64> _CreatedById;
    private Nullable<DateTime> _CreatedDate;
    private Nullable<Int64> _ModifiedById;
    private Nullable<DateTime> _ModifiedDate;

    bool _Deleted = false;
    #endregion

    #region " Properties "

    public Int64 LabTestGroupId
    {
        get { return _LabTestGroupId; }
        set { _LabTestGroupId = value; }
    }

    public string Name
    {
        get { return _Name; }
        set { _Name = value; }
    }

    public Int64 PracticeId
    {
        get { return _PracticeId; }
        set { _PracticeId = value; }
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