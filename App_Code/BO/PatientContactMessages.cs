using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PatientContactMessages
/// </summary>
public class PatientContactMessages
{
	public PatientContactMessages()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    #region " Private Members "

    Int64 _PatientContactMessagesId;
    Int32 _PracticeId;
    Int64 _PatientId;
    string _PatientEmail = string.Empty;
    string _Priority = string.Empty;
    string _Subject = string.Empty;
    string _Message = string.Empty;
    bool _IsRead = false;
    string _MessageReply = string.Empty;
    int _CreatedById;
    DateTime _CreatedDate;
    int _ModifiedById;
    DateTime _ModifiedDate;

    bool _Deleted = false;
    #endregion

    #region " Properties "

    public Int64 PatientContactMessagesId
    {
        get { return _PatientContactMessagesId; }
        set { _PatientContactMessagesId = value; }
    }
    public Int32 PracticeId
    {
        get { return _PracticeId; }
        set { _PracticeId = value; }
    }
    public Int64 PatientId
    {
        get { return _PatientId; }
        set { _PatientId = value; }
    }

    public string PatientEmail
    {
        get { return _PatientEmail; }
        set { _PatientEmail = value; }
    }

    public string Priority
    {
        get { return _Priority; }
        set { _Priority = value; }
    }

    public string Subject
    {
        get { return _Subject; }
        set { _Subject = value; }
    }

    public string Message
    {
        get { return _Message; }
        set { _Message = value; }
    }

    public bool IsRead
    {
        get { return _IsRead; }
        set { _IsRead = value; }
    }

    public string MessageReply
    {
        get { return _MessageReply; }
        set { _MessageReply = value; }
    }

    public int CreatedById
    {
        get { return _CreatedById; }
        set { _CreatedById = value; }
    }

    public DateTime CreatedDate
    {
        get { return _CreatedDate; }
        set { _CreatedDate = value; }
    }

    public int ModifiedById
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