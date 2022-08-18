using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for LabTestGroupDetails
/// </summary>
public class LabTestGroupDetails
{
	public LabTestGroupDetails()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    #region " Private Members "

    Int64 _LabTestGroupDetailId;
    Int64 _LabTestGroupId;
    Int64 _PracticeId;
    string _HcpcsCode = string.Empty;
    Int64 _LabTestId;
    private Nullable<Int64> _CreatedById;
    private Nullable<DateTime> _CreatedDate;
    private Nullable<Int64> _ModifiedById;
    private Nullable<DateTime> _ModifiedDate;

    bool _Deleted = false;
    #endregion

    #region " Properties "

    public Int64 LabTestGroupDetailId
    {
        get { return _LabTestGroupDetailId; }
        set { _LabTestGroupDetailId = value; }
    }

    public Int64 LabTestGroupId
    {
        get { return _LabTestGroupId; }
        set { _LabTestGroupId = value; }
    }

    public Int64 PracticeId
    {
        get { return _PracticeId; }
        set { _PracticeId = value; }
    }

    public string HcpcsCode
    {
        get { return _HcpcsCode; }
        set { _HcpcsCode = value; }
    }

    public Int64 LabTestId
    {
        get { return _LabTestId; }
        set { _LabTestId = value; }
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