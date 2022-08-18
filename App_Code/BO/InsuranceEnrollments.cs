using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for InsuranceEnrollments
/// </summary>
public class InsuranceEnrollments
{
	public InsuranceEnrollments()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    #region Private Members

    long _InsuranceEnrollmentId;
    long? _PracticeId;
    long? _InsuranceId;
    int? _ClaimStatusId;
    int? _EligibilityStatusId;
    int? _ERAStatusId;

    long _CreatedById;
    DateTime _CreatedDate;
    long _ModifiedById;
    DateTime _ModifiedDate;
    bool _Deleted;
    string _Notes;
    #endregion

    #region Properties

    public long InsuranceEnrollmentId
    {
        get { return _InsuranceEnrollmentId; }
        set { _InsuranceEnrollmentId = value; }
    }

    public long? PracticeId
    {
        get { return _PracticeId; }
        set { _PracticeId = value; }
    }

    public long? InsuranceId
    {
        get { return _InsuranceId; }
        set { _InsuranceId = value; }
    }

    public int? ClaimStatusId
    {
        get { return _ClaimStatusId; }
        set { _ClaimStatusId = value; }
    }

    public int? EligibilityStatusId
    {
        get { return _EligibilityStatusId; }
        set { _EligibilityStatusId = value; }
    }

    public int? ERAStatusId
    {
        get { return _ERAStatusId; }
        set { _ERAStatusId = value; }
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
    public string Notes
    {
        get { return _Notes; }
        set { _Notes = value; }
    }
    #endregion
}