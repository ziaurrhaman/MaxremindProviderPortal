
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class PatientInvoiceFiles
{
    public PatientInvoiceFiles()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    #region Private Members

    long _InvoiceFileId;
    string _FileName = string.Empty;
    long? _PracticeId;
    string _FileContents = string.Empty;
    DateTime? _PrintingDate;
    DateTime? _MailingDate;
    string _MailedBy = string.Empty;
    long? _PrintedById;

    long _CreatedById;
    DateTime _CreatedDate;
    long _ModifiedById;
    DateTime _ModifiedDate;
    bool _Deleted;

    #endregion

    #region Properties

    public long InvoiceFileId
    {
        get { return _InvoiceFileId; }
        set { _InvoiceFileId = value; }
    }

    public string FileName
    {
        get { return _FileName; }
        set { _FileName = value; }
    }

    public long? PracticeId
    {
        get { return _PracticeId; }
        set { _PracticeId = value; }
    }

    public string FileContents
    {
        get { return _FileContents; }
        set { _FileContents = value; }
    }

    public DateTime? PrintingDate
    {
        get { return _PrintingDate; }
        set { _PrintingDate = value; }
    }

    public DateTime? MailingDate
    {
        get { return _MailingDate; }
        set { _MailingDate = value; }
    }

    public string MailedBy
    {
        get { return _MailedBy; }
        set { _MailedBy = value; }
    }

    public long? PrintedById
    {
        get { return _PrintedById; }
        set { _PrintedById = value; }
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