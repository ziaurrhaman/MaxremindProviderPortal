
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class EDIProcessedFiles
{
    public EDIProcessedFiles()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    #region Private Members

    long _EDIFilesId;
    long? _PracticeId;
    long? _LocationId;
    string _FileName = string.Empty;
    string _SubmitterId = string.Empty;
    string _ReceiverId = string.Empty;
    string _FileId = string.Empty;
    DateTime? _FileCreationDate;
    TimeSpan? _FileCreationTime;
    string _TransactionVersion = string.Empty;
    string _TransactionCode = string.Empty;
    string _TransactionType = string.Empty;
    DateTime? _FileProcessDate;

    long _CreatedById;
    DateTime _CreatedDate;
    long _ModifiedById;
    DateTime _ModifiedDate;
    bool _Deleted;

    #endregion

    #region Properties

    public long EDIFilesId
    {
        get { return _EDIFilesId; }
        set { _EDIFilesId = value; }
    }

    public long? PracticeId
    {
        get { return _PracticeId; }
        set { _PracticeId = value; }
    }

    public long? LocationId
    {
        get { return _LocationId; }
        set { _LocationId = value; }
    }

    public string FileName
    {
        get { return _FileName; }
        set { _FileName = value; }
    }

    public string SubmitterId
    {
        get { return _SubmitterId; }
        set { _SubmitterId = value; }
    }

    public string ReceiverId
    {
        get { return _ReceiverId; }
        set { _ReceiverId = value; }
    }

    public string FileId
    {
        get { return _FileId; }
        set { _FileId = value; }
    }

    public DateTime? FileCreationDate
    {
        get { return _FileCreationDate; }
        set { _FileCreationDate = value; }
    }

    public TimeSpan? FileCreationTime
    {
        get { return _FileCreationTime; }
        set { _FileCreationTime = value; }
    }

    public string TransactionVersion
    {
        get { return _TransactionVersion; }
        set { _TransactionVersion = value; }
    }

    public string TransactionCode
    {
        get { return _TransactionCode; }
        set { _TransactionCode = value; }
    }

    public string TransactionType
    {
        get { return _TransactionType; }
        set { _TransactionType = value; }
    }

    public DateTime? FileProcessDate
    {
        get { return _FileProcessDate; }
        set { _FileProcessDate = value; }
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

    #endregion
}