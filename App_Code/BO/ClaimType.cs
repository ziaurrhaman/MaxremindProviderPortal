using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ClaimType
/// </summary>
public class ClaimType
{
    public ClaimType()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    #region " Private Members "
    private int _ClaimTypeId;
    private string _ClaimType = string.Empty;
    private DateTime _CreatedDate;
    private long _CreatedById;
    private System.Nullable<DateTime> _ModifiedDate;
    private System.Nullable<int> _ModifiedById;
    private bool _Deleted = false;
    #endregion

    #region " Properties "

    public int ClaimTypeId
    {
        get { return _ClaimTypeId; }
        set { _ClaimTypeId = value; }
    }

    public string ClaimsType
    {
        get { return _ClaimType; }
        set { _ClaimType = value; }
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