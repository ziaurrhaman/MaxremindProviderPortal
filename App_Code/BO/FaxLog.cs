using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for FaxLog
/// </summary>
public class FaxLog
{
	public FaxLog()
	{
		//
		// TODO: Add constructor logic here
		//
	}


    #region " Private Members "

    long _FaxLogId;
    string _Receiver = string.Empty;
    string _ReceiverNumber = string.Empty;
    string _DocumentName = string.Empty;
    string _AuthorizedBy = string.Empty;
    Int64? _CreatedById;
    DateTime? _CreatedDate;
    Int64? _ModifiedById;
    DateTime? _ModifiedDate;

    bool _Deleted = false;
    #endregion

    #region " Properties "

    public long FaxLogId
    {
        get { return _FaxLogId; }
        set { _FaxLogId = value; }
    }

    public string Receiver
    {
        get { return _Receiver; }
        set { _Receiver = value; }
    }

    public string ReceiverNumber
    {
        get { return _ReceiverNumber; }
        set { _ReceiverNumber = value; }
    }

    public string DocumentName
    {
        get { return _DocumentName; }
        set { _DocumentName = value; }
    }

    public string AuthorizedBy
    {
        get { return _AuthorizedBy; }
        set { _AuthorizedBy = value; }
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