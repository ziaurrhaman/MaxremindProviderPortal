using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CompanyAccountingSubGroups
/// </summary>
public class CompanyAccountingSubGroups
{
	public CompanyAccountingSubGroups()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    #region " Private Members "

    Int64 _CompanyAccountingSubGroupsId;
    Int64 _CompanyAccountingGroupsId;
    string _Name = string.Empty;
    int _CodeFrom ;
    int _CodeTo ;
    string _Status = string.Empty;
    string _Description = string.Empty;
    Int64 _PracticeId;
    Int64 _CreatedById;
    DateTime _CreatedDate;
    Int64 _ModifiedById;
    DateTime _ModifiedDate;

    bool _Deleted = false;
    #endregion

    #region " Properties "

    public Int64 CompanyAccountingSubGroupsId
    {
        get { return _CompanyAccountingSubGroupsId; }
        set { _CompanyAccountingSubGroupsId = value; }
    }

    public Int64 CompanyAccountingGroupsId
    {
        get { return _CompanyAccountingGroupsId; }
        set { _CompanyAccountingGroupsId = value; }
    }

    public string Name
    {
        get { return _Name; }
        set { _Name = value; }
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

    public Int64 PracticeId
    {
        get { return _PracticeId; }
        set { _PracticeId = value; }
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