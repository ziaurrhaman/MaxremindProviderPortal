using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UserRights
/// </summary>
public class UserRights
{
	public UserRights()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    #region " Private Members "

    private long _UserRightsId;
    
    private long _UserId;
    private int _ModuleRightId;
    private bool _IsIncluded;
    private string _Status = string.Empty;

    private long _CreatedById;
    private DateTime _CreatedDate;
    private long _ModifiedById;
    private DateTime _ModifiedDate;
    private bool _Deleted = false;
    
    #endregion
    #region " Properties "

    public long UserRightsId
    {
        get { return _UserRightsId; }
        set { _UserRightsId = value; }
    }

    public long UserId
    {
        get { return _UserId; }
        set { _UserId = value; }
    }

    public int ModuleRightId
    {
        get { return _ModuleRightId; }
        set { _ModuleRightId = value; }
    }
    public bool IsIncluded
    {
        get { return _IsIncluded; }
        set { _IsIncluded = value; }
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