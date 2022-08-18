using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for OrganDetailsValues
/// </summary>
public class OrganDetailsValues
{
	public OrganDetailsValues()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    #region " Private Members "

    private long _OrganValueId ;
    private long _OrgansDetailsId;
    private string _Value = string.Empty;
    private long _CreatedById;
    private DateTime _CreatedDate;
    private long _ModifiedById;
    private DateTime _ModifiedDate;
    bool _Deleted = false;

    #endregion

    #region " Properties "

    public long OrganValueId
    {
        get { return _OrganValueId; }
        set { _OrganValueId = value; }
    }

    public long OrgansDetailsId
    {
        get { return _OrgansDetailsId; }
        set { _OrgansDetailsId = value; }
    }

    public string Value
    {
        get { return _Value; }
        set { _Value = value; }
    }

    public long CreatedById
    {
        get { return _CreatedById; }
        set { _CreatedById = value; }
    }

    public DateTime CreatedDate
    {
        get { return _CreatedDate; }
        set { _CreatedDate = value; }
    }

    public long ModifiedById
    {
        get { return _ModifiedById; }
        set { _ModifiedById = value; }
    }

    public DateTime ModifiedDate
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