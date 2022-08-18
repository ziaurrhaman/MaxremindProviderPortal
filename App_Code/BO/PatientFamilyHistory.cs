using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PatientFamilyHistory
/// </summary>
public class PatientFamilyHistory
{
	public PatientFamilyHistory()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    #region " Private Members "

    Int64 _FamilyHistoryId;
    string _FirstName = string.Empty;
    string _LastName = string.Empty;
    string _ContactNo = string.Empty;
    string _Relation = string.Empty;
    string _Comments = string.Empty;
    string _IcdCode = string.Empty;
    private Int64 _PatientId;
    private Int64 _ChartId;
    private Int64 _PracticeId;
    private bool _Resolved;
    Int64 _CreatedById;
    DateTime _CreatedDate;
    Int64 _ModifiedById;
    DateTime _ModifiedDate;

    bool _Deleted = false;
    #endregion

    #region " Properties "

    public Int64 FamilyHistoryId
    {
        get { return _FamilyHistoryId; }
        set { _FamilyHistoryId = value; }
    }
    public string FirstName
    {
        get { return _FirstName; }
        set { _FirstName = value; }
    }
    public string LastName
    {
        get { return _LastName; }
        set { _LastName = value; }
    }
    public string ContactNo
    {
        get { return _ContactNo; }
        set { _ContactNo = value; }
    }

    public string Relation
    {
        get { return _Relation; }
        set { _Relation = value; }
    }

    public string Comments
    {
        get { return _Comments; }
        set { _Comments = value; }
    }

    public string IcdCode
    {
        get { return _IcdCode; }
        set { _IcdCode = value; }
    }

    public Int64 PatientId
    {
        get { return _PatientId; }
        set { _PatientId = value; }
    }

    public Int64 ChartId
    {
        get { return _ChartId; }
        set { _ChartId = value; }
    }

    public Int64 PracticeId
    {
        get { return _PracticeId; }
        set { _PracticeId = value; }
    }

    public bool Resolved
    {
        get { return _Resolved; }
        set { _Resolved = value; }
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