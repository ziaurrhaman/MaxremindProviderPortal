using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UserRoles
/// </summary>
public class UserRoles
{
	public UserRoles()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    #region " Private Members "

    private Int64 _UserRoleId;
    private Int64 _UserId;
    private Int64 _RoleId;
    private DateTime _CreatedDate;
    private int _CreatedById;
    private DateTime _ModifiedDate;
    private int _ModifiedById;
    private bool _Deleted = false;
    #endregion
    #region " Properties "

    public Int64 UserRoleId
    {
        get { return _UserRoleId; }
        set { _UserRoleId = value; }
    }

    public Int64 UserId
    {
        get { return _UserId; }
        set { _UserId = value; }
    }

    public Int64 RoleId
    {
        get { return _RoleId; }
        set { _RoleId = value; }
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