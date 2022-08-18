using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for TeleHealthSessions
/// </summary>
public class TeleHealthSessions
{
	public TeleHealthSessions()
	{
		//
		// TODO: Add constructor logic here
		//
	}


    #region " Private Members "

    Int64 _TeleHealthSessionsId;
    Int64? _PracticeId;
    Int64 _PresenterId;
    string _SessionTitle = string.Empty;
    DateTime? _SechduleTime;
    DateTime? _StartTime;
    DateTime? _EndTime;
    string _SessionStatus = string.Empty;
    string _RoomID = string.Empty;
    bool _IsOpenSession = false;
    bool _IsRecorded = false;
    string _RecordingPath = string.Empty;
    bool _Isbillable = false;
    Int64? _CreatedById;
    DateTime? _CreatedDate;
    Int64? _ModifiedById;
    DateTime? _ModifiedDate;

    bool _Deleted = false;
    #endregion

    #region " Properties "

    public Int64 TeleHealthSessionsId
    {
        get { return _TeleHealthSessionsId; }
        set { _TeleHealthSessionsId = value; }
    }

    public Int64? PracticeId
    {
        get { return _PracticeId; }
        set { _PracticeId = value; }
    }

    public Int64 PresenterId
    {
        get { return _PresenterId; }
        set { _PresenterId = value; }
    }

    public string SessionTitle
    {
        get { return _SessionTitle; }
        set { _SessionTitle = value; }
    }

    public DateTime? SechduleTime
    {
        get { return _SechduleTime; }
        set { _SechduleTime = value; }
    }

    public DateTime? StartTime
    {
        get { return _StartTime; }
        set { _StartTime = value; }
    }

    public DateTime? EndTime
    {
        get { return _EndTime; }
        set { _EndTime = value; }
    }

    public string SessionStatus
    {
        get { return _SessionStatus; }
        set { _SessionStatus = value; }
    }

    public string RoomID
    {
        get { return _RoomID; }
        set { _RoomID = value; }
    }

    public bool IsOpenSession
    {
        get { return _IsOpenSession; }
        set { _IsOpenSession = value; }
    }

    public bool IsRecorded
    {
        get { return _IsRecorded; }
        set { _IsRecorded = value; }
    }

    public string RecordingPath
    {
        get { return _RecordingPath; }
        set { _RecordingPath = value; }
    }

    public bool Isbillable
    {
        get { return _Isbillable; }
        set { _Isbillable = value; }
    }

    public Int64? CreatedById
    {
        get { return _CreatedById; }
        set { _CreatedById = value; }
    }

    public DateTime? CreatedDate
    {
        get { return _CreatedDate; }
        set { _CreatedDate = value; }
    }

    public Int64? ModifiedById
    {
        get { return _ModifiedById; }
        set { _ModifiedById = value; }
    }

    public DateTime? ModifiedDate
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