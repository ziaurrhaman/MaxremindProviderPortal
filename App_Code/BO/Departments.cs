
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class Departments
{
    public Departments()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    #region Private Members

    long _DepartmentsId;
    long? _PracticeId;
    long? _PracticeLocationsId;
    string _DepartmentName = string.Empty;
    string _DepartmentAccoutingCode = string.Empty;

    long _CreatedById;
    DateTime _CreatedDate;
    long _ModifiedById;
    DateTime _ModifiedDate;
    bool _Deleted;

    #endregion

    #region Properties

    public long DepartmentsId
    {
        get { return _DepartmentsId; }
        set { _DepartmentsId = value; }
    }

    public long? PracticeId
    {
        get { return _PracticeId; }
        set { _PracticeId = value; }
    }

    public long? PracticeLocationsId
    {
        get { return _PracticeLocationsId; }
        set { _PracticeLocationsId = value; }
    }

    public string DepartmentName
    {
        get { return _DepartmentName; }
        set { _DepartmentName = value; }
    }

    public string DepartmentAccoutingCode
    {
        get { return _DepartmentAccoutingCode; }
        set { _DepartmentAccoutingCode = value; }
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