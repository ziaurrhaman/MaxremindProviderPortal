
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class ClaimNoteCategories
{
    public ClaimNoteCategories()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    #region Private Members

    long _ClaimNoteCategoriesId;
    long? _PracticeId;
    string _CategoryName = string.Empty;

    long _CreatedById;
    DateTime _CreatedDate;
    long _ModifiedById;
    DateTime _ModifiedDate;
    bool _Deleted;

    #endregion

    #region Properties

    public long ClaimNoteCategoriesId
    {
        get { return _ClaimNoteCategoriesId; }
        set { _ClaimNoteCategoriesId = value; }
    }

    public long? PracticeId
    {
        get { return _PracticeId; }
        set { _PracticeId = value; }
    }

    public string CategoryName
    {
        get { return _CategoryName; }
        set { _CategoryName = value; }
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