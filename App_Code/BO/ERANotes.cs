using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ERANotes
/// </summary>
/// 

//// Created By Rizwan kharal 24April2018
public class ERANotes
{
    public ERANotes()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    #region " Private Members "

    private long _ERANotesId;
    private string _Comments;
    private long _ERAMasterId;
    private long _PracticeId;
    private DateTime _CreatedOn;
    private long _CreatedById;
    private Nullable<DateTime> _ModifiedOn;
    private Nullable<int> _ModifiedById;
    private bool _Deleted = false;

    #endregion

    #region " Properties "

    public long ERANotesId
    {
        get { return _ERANotesId; }
        set { _ERANotesId = value; }
    }

    public string Comments
    {
        get { return _Comments; }
        set { _Comments = value; }
    }

    public long PracticeId
    {
        get { return _PracticeId; }
        set { _PracticeId = value; }
    }

    public long ERAMasterId
    {
        get { return _ERAMasterId; }
        set { _ERAMasterId = value; }
    }

    public DateTime CreatedOn
    {
        get { return _CreatedOn; }
        set { _CreatedOn = value; }
    }

    public long CreatedById
    {
        get { return _CreatedById; }
        set { _CreatedById = value; }
    }

    public Nullable<DateTime> ModifiedOn
    {
        get { return _ModifiedOn; }
        set { _ModifiedOn = value; }
    }

    public Nullable<int> ModifiedById
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