using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UserMessages
/// </summary>
public class UserMessages
{
	public UserMessages()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    
    #region " Private Members "
    
    private long _UserMessagesId;
    private string _MessageCode;
    private long _MessagesId;
    private long _ReceiverId;
    private string _ReceiverType;
    private string _MessageStatus;
    private DateTime _CreatedDate;
    private long _CreatedById;
    private Nullable<DateTime> _ModifiedDate;
    private long _ModifiedById;
    private bool _Deleted;

    #endregion
    
    #region " Properties "

    public long UserMessagesId
    {
        get { return _UserMessagesId; }
        set { _UserMessagesId = value; }
    }

    public string MessageCode
    {
        get { return _MessageCode; }
        set { _MessageCode = value; }
    }

    public long MessagesId
    {
        get { return _MessagesId; }
        set { _MessagesId = value; }
    }

    public long ReceiverId
    {
        get { return _ReceiverId; }
        set { _ReceiverId = value; }
    }

    public string ReceiverType
    {
        get { return _ReceiverType; }
        set { _ReceiverType = value; }
    }

    public string MessageStatus
    {
        get { return _MessageStatus; }
        set { _MessageStatus = value; }
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

    public Nullable<DateTime> ModifiedDate
    {
        get { return _ModifiedDate; }
        set { _ModifiedDate = value; }
    }

    public long ModifiedById
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