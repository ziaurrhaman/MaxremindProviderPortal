using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ClaimsSubmitted
/// </summary>
public class ClaimsSubmitted
{
	public ClaimsSubmitted()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    #region " Private Members "

	private Int64 _ClaimsSubmissionId;
    private Int64 _PatientAccount;
    private Int64 _PracticeId;
    private Int64 _LocationId;   
    private Int64 _ClaimNo;
    private Int64 _InsuranceId;
    private string _PriSecOthType = string.Empty;
    private Int64 _SubmissionFileId;
    private DateTime _SubmissionDate;
    private DateTime _ClaimWorkDate;
    private Int64 _BatchId;
    private string _SubmissionResults = string.Empty;
    private string _ErrorCode = string.Empty;
    private DateTime _CreatedDate;
    private long _CreatedById;
    private DateTime? _ModifiedDate;
    private long? _ModifiedById;
    private bool _Deleted = false;
    #endregion

    #region " Properties "

    public Int64 ClaimsSubmissionId
    {
        get { return _ClaimsSubmissionId; }
        set { _ClaimsSubmissionId = value; }
    }

    public Int64 PatientAccount
    {
        get { return _PatientAccount; }
        set { _PatientAccount = value; }
    }

    public Int64 PracticeId
    {
        get { return _PracticeId; }
        set { _PracticeId = value; }
    }

    public Int64 LocationId
    {
        get { return _LocationId; }
        set { _LocationId = value; }
    }

   
    public Int64 ClaimNo
    {
        get { return _ClaimNo; }
        set { _ClaimNo = value; }
    }

    public Int64 InsuranceId
    {
        get { return _InsuranceId; }
        set { _InsuranceId = value; }
    }

    public string PriSecOthType
    {
        get { return _PriSecOthType; }
        set { _PriSecOthType = value; }
    }

    public Int64 SubmissionFileId
    {
        get { return _SubmissionFileId; }
        set { _SubmissionFileId = value; }
    }

    public DateTime SubmissionDate
    {
        get { return _SubmissionDate; }
        set { _SubmissionDate = value; }
    }

    public DateTime ClaimWorkDate
    {
        get { return _ClaimWorkDate; }
        set { _ClaimWorkDate = value; }
    }

    public Int64 BatchId
    {
        get { return _BatchId; }
        set { _BatchId = value; }
    }

    public string SubmissionResults
    {
        get { return _SubmissionResults; }
        set { _SubmissionResults = value; }
    }

    public string ErrorCode
    {
        get { return _ErrorCode; }
        set { _ErrorCode = value; }
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

    public long? ModifiedById
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