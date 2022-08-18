using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for FaxQueues
/// </summary>
public class FaxQueues
{
    public FaxQueues()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    #region " Private Members "

    Int64 _FaxQueueId;
    long _PracticeId;
    Int64 _PatientId;
    int _SenderId;
    string _Receiver = string.Empty;
    string _FaxNumber = string.Empty;
    string _DocumentName = string.Empty;
    string _FaxContents = string.Empty;
    Int64? _CreatedById;
    DateTime? _CreatedDate;
    Int64? _ModifiedById;
    DateTime? _ModifiedDate;

    bool _Deleted = false;
    #endregion

    #region " Properties "

    public Int64 FaxQueueId
    {
        get { return _FaxQueueId; }
        set { _FaxQueueId = value; }
    }

    public long PracticeId
    {
        get { return _PracticeId; }
        set { _PracticeId = value; }
    }

    public Int64 PatientId
    {
        get { return _PatientId; }
        set { _PatientId = value; }
    }

    public int SenderId
    {
        get { return _SenderId; }
        set { _SenderId = value; }
    }

    public string Receiver
    {
        get { return _Receiver; }
        set { _Receiver = value; }
    }

    public string FaxNumber
    {
        get { return _FaxNumber; }
        set { _FaxNumber = value; }
    }

    public string DocumentName
    {
        get { return _DocumentName; }
        set { _DocumentName = value; }
    }

    public string FaxContents
    {
        get { return _FaxContents; }
        set { _FaxContents = value; }
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