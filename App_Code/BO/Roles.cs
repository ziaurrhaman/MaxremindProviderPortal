using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Roles
/// </summary>
public class Roles
{
	public Roles()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    #region " Private Members "

    private Int64 _RoleId;
    private string _RoleName = string.Empty;
    private int _DefaultScreenId;
    private Int64 _PracticeId;
    private DateTime _CreatedDate;
    private int _CreatedById;
    private DateTime _ModifiedDate;
    private int _ModifiedById;
    private bool _Deleted = false;
    #endregion

    #region " Properties "

    public Int64 RoleId
    {
        get { return _RoleId; }
        set { _RoleId = value; }
    }

    public string RoleName
    {
        get { return _RoleName; }
        set { _RoleName = value; }
    }

    public int DefaultScreenId
    {
        get { return _DefaultScreenId; }
        set { _DefaultScreenId = value; }
    }

    public Int64 PracticeId
    {
        get { return _PracticeId; }
        set { _PracticeId = value; }
    }

    public DateTime CreatedDate
    {
        get { return _CreatedDate; }
        set { _CreatedDate = value; }
    }

    public int CreatedById
    {
        get { return _CreatedById; }
        set { _CreatedById = value; }
    }

    public DateTime ModifiedDate
    {
        get { return _ModifiedDate; }
        set { _ModifiedDate = value; }
    }

    public int ModifiedById
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