using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SessionRequests
/// </summary>
public class SessionRequests
{
	public SessionRequests()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    #region " Private Members "

    Int64 _SessionRequestId;
    string _SessionId = string.Empty;
    string _UserId = string.Empty;
    Int64 _PatientId;
    string _FirstName = string.Empty;
    string _LastName = string.Empty;
    string _Gender = string.Empty;
    DateTime _DOB;
    string _MaritalStatus = string.Empty;
    string _ImagePath = string.Empty;

    bool _Accepted = false;
    bool _Rejected = false;

    DateTime? _CreatedDate;
    Int64? _CreatedById;

    bool _Deleted = false;
    #endregion

    #region " Properties "

    public Int64 SessionRequestId
    {
        get { return _SessionRequestId; }
        set { _SessionRequestId = value; }
    }

    public string SessionId
    {
        get { return _SessionId; }
        set { _SessionId = value; }
    }

    public string UserId
    {
        get { return _UserId; }
        set { _UserId = value; }
    }

    public Int64 PatientId
    {
        get { return _PatientId; }
        set { _PatientId = value; }
    }

    public string FirstName
    {
        get { return _FirstName; }
        set { _FirstName = value; }
    }

    public string LastName
    {
        get { return _LastName; }
        set { _LastName = value; }
    }

    public string Gender
    {
        get { return _Gender; }
        set { _Gender = value; }
    }

    public DateTime DOB
    {
        get { return _DOB; }
        set { _DOB = value; }
    }

    public string MaritalStatus
    {
        get { return _MaritalStatus; }
        set { _MaritalStatus = value; }
    }

    public string ImagePath
    {
        get { return _ImagePath; }
        set { _ImagePath = value; }
    }
    public bool Accepted
    {
        get { return _Accepted; }
        set { _Accepted = value; }
    }
    public bool Rejected
    {
        get { return _Rejected; }
        set { _Rejected = value; }
    }

    public DateTime? CreatedDate
    {
        get { return _CreatedDate; }
        set { _CreatedDate = value; }
    }

    public Int64? CreatedById
    {
        get { return _CreatedById; }
        set { _CreatedById = value; }
    }

    public bool Deleted
    {
        get { return _Deleted; }
        set { _Deleted = value; }
    }

    #endregion
}