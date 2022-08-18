using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ERAAttachFile
/// </summary>
public class ERAAttachFile
{
    public ERAAttachFile()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region " Private Members "

    long _ERAAttachfileId;
    long _UploadFileId;
    long _ERAMasterId;
    long _PracticeId;
    private DateTime _CreatedDate;
    private long _CreatedById;
    private DateTime _ModifiedDate;
    private long _ModifiedById;
    private bool _Deleted = false;
    #endregion
    #region " Properties "

    public long ERAAttachfileId
    {
        get { return _ERAAttachfileId; }
        set { _ERAAttachfileId = value; }
    }

    public long UploadFileId
    {
        get { return _UploadFileId; }
        set { _UploadFileId = value; }
    }
    public long ERAMasterId
    {
        get { return _ERAMasterId; }
        set { _ERAMasterId = value; }
    }
    public long PracticeId
    {
        get { return _PracticeId; }
        set { _PracticeId = value; }
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

    public DateTime ModifiedDate
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