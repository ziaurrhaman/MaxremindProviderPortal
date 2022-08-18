using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PracticeDocumentsCatagories
/// </summary>
public class PracticeDocumentsCatagories
{
	public PracticeDocumentsCatagories()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    #region " Private Members "

    long _PracticeDocumentsCatagoriesId;
    long _PracticeId;
    string _DocumentsCategoryName = string.Empty;
    long _CreatedById;
    DateTime _CreatedDate;
    long _ModifiedById;
    DateTime _ModifiedDate;
    bool _Deleted = false;

    #endregion

    #region " Properties "

    public long PracticeDocumentsCatagoriesId
    {
        get { return _PracticeDocumentsCatagoriesId; }
        set { _PracticeDocumentsCatagoriesId = value; }
    }

    public long PracticeId
    {
        get { return _PracticeId; }
        set { _PracticeId = value; }
    }

    public string DocumentsCategoryName
    {
        get { return _DocumentsCategoryName; }
        set { _DocumentsCategoryName = value; }
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