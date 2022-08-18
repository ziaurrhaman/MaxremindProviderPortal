
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class UploadFiles
{
    public UploadFiles()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    #region Private Members

    long _UploadFilesId;
    long? _PracticeId;
    DateTime? _UploadDate;
    string _FileName = string.Empty;
    string _TagName = string.Empty;
    int? _SubmissionMethodId;
    DateTime? _SubmissionDate;
    int? _FileTypeId;
    int? _FileStatusId;
    int? _FileFormatId;
    string _Notes = string.Empty;
    string _FileLocation = string.Empty;
    int? _Patients;
    int? _Claims;
    Decimal? _Charges;

    long _CreatedById;
    DateTime _CreatedDate;
    long _ModifiedById;
    DateTime _ModifiedDate;
    bool _Deleted;

    #endregion

    #region Properties

    public long UploadFilesId
    {
        get { return _UploadFilesId; }
        set { _UploadFilesId = value; }
    }

    public long? PracticeId
    {
        get { return _PracticeId; }
        set { _PracticeId = value; }
    }

    public DateTime? UploadDate
    {
        get { return _UploadDate; }
        set { _UploadDate = value; }
    }

    public string FileName
    {
        get { return _FileName; }
        set { _FileName = value; }
    }

    public string TagName
    {
        get { return _TagName; }
        set { _TagName = value; }
    }

    public int? SubmissionMethodId
    {
        get { return _SubmissionMethodId; }
        set { _SubmissionMethodId = value; }
    }

    public DateTime? SubmissionDate
    {
        get { return _SubmissionDate; }
        set { _SubmissionDate = value; }
    }

    public int? FileTypeId
    {
        get { return _FileTypeId; }
        set { _FileTypeId = value; }
    }

    public int? FileStatusId
    {
        get { return _FileStatusId; }
        set { _FileStatusId = value; }
    }

    public int? FileFormatId
    {
        get { return _FileFormatId; }
        set { _FileFormatId = value; }
    }

    public string Notes
    {
        get { return _Notes; }
        set { _Notes = value; }
    }

    public string FileLocation
    {
        get { return _FileLocation; }
        set { _FileLocation = value; }
    }

    public int? Patients
    {
        get { return _Patients; }
        set { _Patients = value; }
    }

    public int? Claims
    {
        get { return _Claims; }
        set { _Claims = value; }
    }

    public Decimal? Charges
    {
        get { return _Charges; }
        set { _Charges = value; }
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