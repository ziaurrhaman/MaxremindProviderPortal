using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SubmissionStatusCodes
/// </summary>
public class SubmissionStatusCodes
{
    public SubmissionStatusCodes()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region " Private Members "
    private int _SubmissionStatusId;
    private string _SubmissionStatus = string.Empty;
    private DateTime _CreatedDate;
    private long _CreatedById;
    private System.Nullable<DateTime> _ModifiedDate;
    private System.Nullable<int> _ModifiedById;
    private bool _Deleted = false;
    #endregion

    #region " Properties "

    public int SubmissionStatusId
    {
        get { return _SubmissionStatusId; }
        set { _SubmissionStatusId = value; }
    }

    public string SubmissionStatus
    {
        get { return _SubmissionStatus; }
        set { _SubmissionStatus = value; }
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

    public System.Nullable<DateTime> ModifiedDate
    {
        get { return _ModifiedDate; }
        set { _ModifiedDate = value; }
    }

    public System.Nullable<int> ModifiedById
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