using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PatientProblem
/// </summary>
public class PatientProblems
{
	public PatientProblems()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    #region " Private Members "

    Int64 _ProblemId;
    DateTime? _ProblemDate;
    string _Assesment = string.Empty;
    string _DiagCode = string.Empty;
    bool _PrimaryDiagnosis;
    string _Severity;
    string _Comments = string.Empty;
    string _Status = string.Empty;
    DateTime? _ResolvedDate;
    string _ResolvedBy = string.Empty;
    Int64 _PatientId;
    Int64? _ChartId;
    string _Chronicity = string.Empty;
    Int64 _PracticeId;
    Int64 _CreatedById;
    DateTime _CreatedDate;
    Int64 _ModifiedById;
    DateTime _ModifiedDate;

    bool _Deleted = false;
    #endregion

   

    public Int64 ProblemId
    {
        get { return _ProblemId; }
        set { _ProblemId = value; }
    }

    public DateTime? ProblemDate
    {
        get { return _ProblemDate; }
        set { _ProblemDate = value; }
    }
    public string Assesment
    {
        get { return _Assesment; }
        set { _Assesment = value; }
    }

    public string DiagCode
    {
        get { return _DiagCode; }
        set { _DiagCode = value; }
    }

    public bool PrimaryDiagnosis
    {
        get { return _PrimaryDiagnosis; }
        set { _PrimaryDiagnosis = value; }
    }

    public string Severity
    {
        get { return _Severity; }
        set { _Severity = value; }
    }

    public string Comments
    {
        get { return _Comments; }
        set { _Comments = value; }
    }

    public string Status
    {
        get { return _Status; }
        set { _Status = value; }
    }

    public DateTime? ResolvedDate
    {
        get { return _ResolvedDate; }
        set { _ResolvedDate = value; }
    }

    public string ResolvedBy
    {
        get { return _ResolvedBy; }
        set { _ResolvedBy = value; }
    }

    public Int64 PatientId
    {
        get { return _PatientId; }
        set { _PatientId = value; }
    }

    public Int64? ChartId
    {
        get { return _ChartId; }
        set { _ChartId = value; }
    }
    public string Chronicity
    {
        get { return _Chronicity; }
        set { _Chronicity = value; }
    }

    public Int64 PracticeId
    {
        get { return _PracticeId; }
        set { _PracticeId = value; }
    }

    public Int64 CreatedById
    {
        get { return _CreatedById; }
        set { _CreatedById = value; }
    }

    public DateTime CreatedDate
    {
        get { return _CreatedDate; }
        set { _CreatedDate = value; }
    }

    public Int64 ModifiedById
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
}