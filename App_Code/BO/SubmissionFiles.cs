using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SubmissionFiles
/// </summary>
public class SubmissionFiles
{
	public SubmissionFiles()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    #region " Private Members "

    private Int64 _SubmissionFileId;
    private Int64 _PracticeId;
    private string _FileName = string.Empty;
    private string _FileStatus = string.Empty;
    private string _SubmissionResults = string.Empty;

    private string _EDI999FileName = string.Empty;
    private string _EDI277FileName = string.Empty;
    private string _EDI835FileName = string.Empty;
    private string _EDI999ISA13 = string.Empty;
    private string _ISA13 = string.Empty;
    private string _GS06 = string.Empty;
    private string _RejectionDetails = string.Empty;

    private DateTime _CreatedDate;
    private long _CreatedById;
    private DateTime? _ModifiedDate;
    private int? _ModifiedById;
    private bool _Deleted = false;
    #endregion

    #region " Properties "

    public Int64 SubmissionFileId
    {
        get { return _SubmissionFileId; }
        set { _SubmissionFileId = value; }
    }
    public Int64 PracticeId
    {
        get { return _PracticeId; }
        set { _PracticeId = value; }
    }
    public string FileName
    {
        get { return _FileName; }
        set { _FileName = value; }
    }

    public string FileStatus
    {
        get { return _FileStatus; }
        set { _FileStatus = value; }
    }

    public string SubmissionResults
    {
        get { return _SubmissionResults; }
        set { _SubmissionResults = value; }
    }

    public string EDI999FileName
    {
        get { return _EDI999FileName; }
        set { _EDI999FileName = value; }
    }
    public string EDI277FileName
    {
        get { return _EDI277FileName; }
        set { _EDI277FileName = value; }
    }
    public string EDI835FileName
    {
        get { return _EDI835FileName; }
        set { _EDI835FileName = value; }
    }
    public string EDI999ISA13
    {
        get { return _EDI999ISA13; }
        set { _EDI999ISA13 = value; }
    }
    public string ISA13
    {
        get { return _ISA13; }
        set { _ISA13 = value; }
    }
    public string GS06
    {
        get { return _GS06; }
        set { _GS06 = value; }
    }
    public string RejectionDetails
    {
        get { return _RejectionDetails; }
        set { _RejectionDetails = value; }
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

    public DateTime? ModifiedDate
    {
        get { return _ModifiedDate; }
        set { _ModifiedDate = value; }
    }

    public int? ModifiedById
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