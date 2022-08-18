using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for RoleModuleRights
/// </summary>
public class RoleModuleRights
{
	public RoleModuleRights()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    #region " Private Members "

    private long _RoleModuleRightsId;

    private long _RoleId;
    private int _ModuleRightId;
    private string _Status = string.Empty;

    private long _CreatedById;
    private DateTime _CreatedDate;
    private long _ModifiedById;
    private DateTime _ModifiedDate;
    
    private bool _Deleted = false;
    #endregion

    #region " Properties "

    public long RoleModuleRightsId
    {
        get { return _RoleModuleRightsId; }
        set { _RoleModuleRightsId = value; }
    }
    public long RoleId
    {
        get { return _RoleId; }
        set { _RoleId = value; }
    }
    public int ModuleRightId
    {
        get { return _ModuleRightId; }
        set { _ModuleRightId = value; }
    }
    public string Status
    {
        get { return _Status; }
        set { _Status = value; }
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