
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class FileDocumentAttachments
{
    public FileDocumentAttachments()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    #region Private Members

    long _FileDocumentAttachmentsId;
    long? _DocumentId;
    string _DocumentPath = string.Empty;
    string _OriginalFileName = string.Empty;

    long _CreatedById;
    DateTime? _CreatedDate;
    long _ModifiedById;
    DateTime _ModifiedDate;
    bool _Deleted;

    #endregion

    #region Properties

    public long FileDocumentAttachmentsId
    {
        get { return _FileDocumentAttachmentsId; }
        set { _FileDocumentAttachmentsId = value; }
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

    public DateTime? CreatedDate
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