
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class PTLReasons
{
    public PTLReasons()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    #region Private Members

    long _PTLReasonsId;
    long? _PracticeId;
    long? _PracticeLocationsId;
    string _PTLType = string.Empty;
    string _Reason = string.Empty;

    long _CreatedById;
    DateTime _CreatedDate;
    long _ModifiedById;
    DateTime _ModifiedDate;
    bool _Deleted;

    #endregion

    #region Properties

    public long PTLReasonsId
    {
        get { return _PTLReasonsId; }
        set { _PTLReasonsId = value; }
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

    public string PTLType
    {
        get { return _PTLType; }
        set { _PTLType = value; }
    }

    public string Reason
    {
        get { return _Reason; }
        set { _Reason = value; }
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