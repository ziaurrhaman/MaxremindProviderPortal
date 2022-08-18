
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class ClaimNotes
{
    public ClaimNotes()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    #region Private Members

    long _ClaimNotesId;
    long? _PracticeId;
    long? _ClaimId;
    long? _PatientId;
    string _Notes = string.Empty;
    long? _ClaimNoteCategoriesId;

    long _CreatedById;
    DateTime _CreatedDate;
    long _ModifiedById;
    DateTime _ModifiedDate;
    bool _Deleted;

    #endregion

    #region Properties

    public long ClaimNotesId
    {
        get { return _ClaimNotesId; }
        set { _ClaimNotesId = value; }
    }

    public long? PracticeId
    {
        get { return _PracticeId; }
        set { _PracticeId = value; }
    }

    public long? ClaimId
    {
        get { return _ClaimId; }
        set { _ClaimId = value; }
    }

    public long? PatientId
    {
        get { return _PatientId; }
        set { _PatientId = value; }
    }

    public string Notes
    {
        get { return _Notes; }
        set { _Notes = value; }
    }

    public long? ClaimNoteCategoriesId
    {
        get { return _ClaimNoteCategoriesId; }
        set { _ClaimNoteCategoriesId = value; }
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