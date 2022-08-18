using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Account
/// </summary>
public class Account
{
	public Account()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    #region " Private Members "

    Int64 _AccountId;
    string _Name = string.Empty;
    string _Code = string.Empty;
    Int64 _GroupId;
    string _Status = string.Empty;
    Int64 _CreatedById;
    DateTime _CreatedDate;
    Int64 _ModifiedByid;
    DateTime _ModifiedDate;

    bool _Deleted = false;
    #endregion

    #region " Properties "

    public Int64 AccountId
    {
        get { return _AccountId; }
        set { _AccountId = value; }
    }

    public string Name
    {
        get { return _Name; }
        set { _Name = value; }
    }

    public string Code
    {
        get { return _Code; }
        set { _Code = value; }
    }

    public Int64 GroupId
    {
        get { return _GroupId; }
        set { _GroupId = value; }
    }

    public string Status
    {
        get { return _Status; }
        set { _Status = value; }
    }

    public Int64 CreatedById
    {
        get { return _CreatedById; }
        set { _CreatedById = value; }
    }

    public DateTime CreatedDate
    {
        get { return _CreatedDate; }
        set { _CreatedDate = value; }
    }

    public Int64 ModifiedByid
    {
        get { return _ModifiedByid; }
        set { _ModifiedByid = value; }
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