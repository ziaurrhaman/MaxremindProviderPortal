using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Messages
/// </summary>
public class Messages
{
	public Messages()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    
    #region " Private Members "

    private long _MessagesId;
    private string _MessageCode;
    private string _Subject;
    private string _Body;
    private string _MessageFromUserId;
    private string _Priority;
    private bool _IsDraft;
    private bool _ShowInSent;
    private DateTime _CreatedDate;
    private int _CreatedById;
    private Nullable<DateTime> _ModifiedDate;
    private Nullable<int> _ModifiedById;
    private bool _Deleted;

    #endregion
    
    #region " Properties "

    public long MessagesId
    {
        get { return _MessagesId; }
        set { _MessagesId = value; }
    }

    public string MessageCode
    {
        get { return _MessageCode; }
        set { _MessageCode = value; }
    }

    public string Subject
    {
        get { return _Subject; }
        set { _Subject = value; }
    }

    public string Body
    {
        get { return _Body; }
        set { _Body = value; }
    }

    public string MessageFromUserId
    {
        get { return _MessageFromUserId; }
        set { _MessageFromUserId = value; }
    }

    public string Priority
    {
        get { return _Priority; }
        set { _Priority = value; }
    }

    public bool IsDraft
    {
        get { return _IsDraft; }
        set { _IsDraft = value; }
    }
    public bool ShowInSent
    {
        get { return _ShowInSent; }
        set { _ShowInSent = value; }
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