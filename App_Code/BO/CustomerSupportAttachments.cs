using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CustomerSupportAttachments
/// </summary>
public class CustomerSupportAttachments
{
	public CustomerSupportAttachments()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    #region Private Members

    long _CSAttachmentsId;
    long? _CSTicketsId;
    string _AttachmentPath = string.Empty;
    string _FileName = string.Empty;

    long _CreatedById;
    DateTime _CreatedDate;
    long _ModifiedById;
    DateTime _ModifiedDate;
    bool _Deleted;
    long? _PracticeId;

    #endregion

    #region Properties

    public long CSAttachmentsId
    {
        get { return _CSAttachmentsId; }
        set { _CSAttachmentsId = value; }
    }

    public long? CSTicketsId
    {
        get { return _CSTicketsId; }
        set { _CSTicketsId = value; }
    }

    public string AttachmentPath
    {
        get { return _AttachmentPath; }
        set { _AttachmentPath = value; }
    }

    public string FileName
    {
        get { return _FileName; }
        set { _FileName = value; }
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

    public long? PracticeId
    {
        get { return _PracticeId; }
        set { _PracticeId = value; }
    }

    #endregion
}