using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for AccountingSubGroupMaster
/// </summary>
public class AccountingSubGroupMaster
{
	public AccountingSubGroupMaster()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    #region " Private Members "

    Int64 _AccountingSubGroupMasterId;
    Int64 _AccountingGroupMasterId;
    int _CodeFrom;
    int _CodeTo;
    string _SubGroupName = string.Empty;
    string _Status = string.Empty;
    string _Description = string.Empty;
    Int64 _CreatedById;
    DateTime _CreatedDate;
    Int64 _ModifiedById;
    DateTime _ModifiedDate;

    bool _Deleted = false;
    #endregion

    #region " Properties "

    public Int64 AccountingSubGroupMasterId
    {
        get { return _AccountingSubGroupMasterId; }
        set { _AccountingSubGroupMasterId = value; }
    }

    public Int64 AccountingGroupMasterId
    {
        get { return _AccountingGroupMasterId; }
        set { _AccountingGroupMasterId = value; }
    }

    public int CodeFrom
    {
        get { return _CodeFrom; }
        set { _CodeFrom = value; }
    }

    public int CodeTo
    {
        get { return _CodeTo; }
        set { _CodeTo = value; }
    }

    public string SubGroupName
    {
        get { return _SubGroupName; }
        set { _SubGroupName = value; }
    }

    public string Status
    {
        get { return _Status; }
        set { _Status = value; }
    }

    public string Description
    {
        get { return _Description; }
        set { _Description = value; }
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

    public Int64 ModifiedById
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