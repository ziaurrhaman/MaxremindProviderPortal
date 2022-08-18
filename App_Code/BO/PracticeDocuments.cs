using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PracticeDocuments
/// </summary>
public class PracticeDocuments
{
	public PracticeDocuments()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    #region " Private Members "

    long _PracticeDocumentsId;
    long _PracticeId;
    long _PracticeDocumentsCatagoriesId;
    DateTime _DocumentDate;
    string _DocumentType = string.Empty;
    string _DocumentName = string.Empty;
    string _DocumentUploadedName = string.Empty;
    long _CreatedById;
    DateTime _CreatedDate;
    long _ModifiedById;
    DateTime _ModifiedDate;
    bool _Deleted = false;

    #endregion

    #region " Properties "

    public long PracticeDocumentsId
    {
        get { return _PracticeDocumentsId; }
        set { _PracticeDocumentsId = value; }
    }

    public long PracticeId
    {
        get { return _PracticeId; }
        set { _PracticeId = value; }
    }

    public long PracticeDocumentsCatagoriesId
    {
        get { return _PracticeDocumentsCatagoriesId; }
        set { _PracticeDocumentsCatagoriesId = value; }
    }

    public DateTime DocumentDate
    {
        get { return _DocumentDate; }
        set { _DocumentDate = value; }
    }

    public string DocumentType
    {
        get { return _DocumentType; }
        set { _DocumentType = value; }
    }

    public string DocumentName
    {
        get { return _DocumentName; }
        set { _DocumentName = value; }
    }

    public string DocumentUploadedName
    {
        get { return _DocumentUploadedName; }
        set { _DocumentUploadedName = value; }
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