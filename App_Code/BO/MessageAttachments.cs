using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MessageAttachments
/// </summary>
public class MessageAttachments
{
	public MessageAttachments()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    
    #region " Private Members "
    
    private long _MessageAttachmentsId;
    private long _MessagesId;
    private string _FileName;
    private string _FilePath;
    private DateTime _CreatedDate;
    private int _CreatedById;
    private Nullable<DateTime> _ModifiedDate;
    private Nullable<int> _ModifiedById;
    private bool _Deleted;
    
    #endregion
    
    #region " Properties "

    public long MessageAttachmentsId
    {
        get { return _MessageAttachmentsId; }
        set { _MessageAttachmentsId = value; }
    }

    public long MessagesId
    {
        get { return _MessagesId; }
        set { _MessagesId = value; }
    }

    public string FileName
    {
        get { return _FileName; }
        set { _FileName = value; }
    }

    public string FilePath
    {
        get { return _FilePath; }
        set { _FilePath = value; }
    }

    public DateTime CreatedDate
    {
        get { return _CreatedDate; }
        set { _CreatedDate = value; }
    }

    public int CreatedById
    {
        get { return _CreatedById; }
        set { _CreatedById = value; }
    }

    public Nullable<DateTime> ModifiedDate
    {
        get { return _ModifiedDate; }
        set { _ModifiedDate = value; }
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