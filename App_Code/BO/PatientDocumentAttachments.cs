
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class PatientDocumentAttachments
{
    public PatientDocumentAttachments()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    #region Private Members

    long _PatientDocumentAttachmentsId;
    long? _DocumentId;
    string _DocumentPath = string.Empty;
    string _OriginalFileName = string.Empty;

    private long _CreatedById;
    private DateTime _CreatedDate;
    private long _ModifiedById;
    private DateTime _ModifiedDate;
    bool _Deleted = false;

    #endregion

    #region Properties

    public long PatientDocumentAttachmentsId
    {
        get { return _PatientDocumentAttachmentsId; }
        set { _PatientDocumentAttachmentsId = value; }
    }

    public long? DocumentId
    {
        get { return _DocumentId; }
        set { _DocumentId = value; }
    }
    
    public string DocumentPath
    {
        get { return _DocumentPath; }
        set { _DocumentPath = value; }
    }

    public string OriginalFileName
    {
        get { return _OriginalFileName; }
        set { _OriginalFileName = value; }
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