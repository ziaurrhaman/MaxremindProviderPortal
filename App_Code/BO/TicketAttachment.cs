using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for TicketAttachment
/// </summary>
public class TicketAttachment
{
    public TicketAttachment()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    #region " Private Members "

    private long _TicketAttachmentsId;
    private string _PracticeId;
    private long _TicketId;
    private string _AttachmentPath;
    private string _FileName;
    private string _Notes;
    private DateTime _CreatedDate;
    private long _CreatedById;
    private Nullable<DateTime> _ModifiedDate;
    private Nullable<int> _ModifiedById;
    private bool _Deleted = false;

    #endregion

    #region " Properties "

    public long TicketAttachmentsId
    {
        get { return _TicketAttachmentsId; }
        set { _TicketAttachmentsId = value; }
    }
    public long TicketId
    {
        get { return _TicketId; }
        set { _TicketId = value; }
    }


    public string PracticeId
    {
        get { return _PracticeId; }
        set { _PracticeId = value; }
    }

    public string AttachmentPath
    {
        get { return _AttachmentPath; }
        set { _AttachmentPath = value; }
    }

    public string FileName
    {
        get { return _FileName; }
        set { _FileName = value; }
    }
    public string Notes
    {
        get { return _Notes; }
        set { _Notes = value; }
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