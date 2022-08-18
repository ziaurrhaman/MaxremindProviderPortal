using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Reasons
/// </summary>
public class Reasons
{
    public Reasons()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    #region " Private Members "

    int _ReasonId;
    long _PracticeId;
    string _Description = string.Empty;
    string _BackColor = string.Empty;
    long _CreatedById;
    DateTime _CreatedDate;
    private Nullable<long> _ModifiedById;
    private DateTime _ModifiedDate;

    bool _Deleted = false;
    #endregion

    #region " Properties "

    public int ReasonId
    {
        get { return _ReasonId; }
        set { _ReasonId = value; }
    }

    public long PracticeId
    {
        get { return _PracticeId; }
        set { _PracticeId = value; }
    }

    public string Description
    {
        get { return _Description; }
        set { _Description = value; }
    }
    public string BackColor
    {
        get { return _BackColor; }
        set { _BackColor = value; }
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

    public Nullable<long> ModifiedById
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