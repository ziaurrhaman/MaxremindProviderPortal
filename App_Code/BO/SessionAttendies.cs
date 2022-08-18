using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SessionAttendies
/// </summary>
public class SessionAttendies
{
	public SessionAttendies()
	{
		//
		// TODO: Add constructor logic here
		//
	}



    #region " Private Members "

    Int64 _SessionAttendiesId;
    Int64 _TeleHealthSessionsId;
    Int64 _PatientId;
    bool _IsInvited = false;
    DateTime? _JoinTime;
    DateTime? _LeaveTime;
    string _ClientIP = string.Empty;
    Int64? _CreatedById;
    DateTime? _CreatedDate;
    Int64? _ModifiedById;
    DateTime? _ModifiedDate;

    bool _Deleted = false;
    #endregion

    #region " Properties "

    public Int64 SessionAttendiesId
    {
        get { return _SessionAttendiesId; }
        set { _SessionAttendiesId = value; }
    }

    public Int64 TeleHealthSessionsId
    {
        get { return _TeleHealthSessionsId; }
        set { _TeleHealthSessionsId = value; }
    }

    public Int64 PatientId
    {
        get { return _PatientId; }
        set { _PatientId = value; }
    }

    public bool IsInvited
    {
        get { return _IsInvited; }
        set { _IsInvited = value; }
    }

    public DateTime? JoinTime
    {
        get { return _JoinTime; }
        set { _JoinTime = value; }
    }

    public DateTime? LeaveTime
    {
        get { return _LeaveTime; }
        set { _LeaveTime = value; }
    }

    public string ClientIP
    {
        get { return _ClientIP; }
        set { _ClientIP = value; }
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