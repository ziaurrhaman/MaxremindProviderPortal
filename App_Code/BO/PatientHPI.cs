using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PatientHPI
/// </summary>
public class PatientHPI
{
	public PatientHPI()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    #region " Private Members "

    private Int64 _HPIId;
    private Int64 _PatientId;
    private Int64 _ChartId;
    private Int64 _PracticeId;
    private string _Location = string.Empty;
    private string _Severity = string.Empty;
    private string _Timing = string.Empty;
    private string _ModifyingFactors = string.Empty;
    private string _Quality = string.Empty;
    private string _Duration = string.Empty;
    private string _Context = string.Empty;
    private string _AssociatedSymptoms = string.Empty;
    private Int64 _CreatedById;
    private DateTime _CreatedDate;
    private Int64? _ModifiedById;
    private DateTime? _ModifiedDate;
    private Int64 _Deleted;
    #endregion

    #region " Properties "

    public Int64 HPIId
    {
        get { return _HPIId; }
        set { _HPIId = value; }
    }

    public Int64 PatientId
    {
        get { return _PatientId; }
        set { _PatientId = value; }
    }

    public Int64 ChartId
    {
        get { return _ChartId; }
        set { _ChartId = value; }
    }

    public Int64 PracticeId
    {
        get { return _PracticeId; }
        set { _PracticeId = value; }
    }

    public string Location
    {
        get { return _Location; }
        set { _Location = value; }
    }

    public string Severity
    {
        get { return _Severity; }
        set { _Severity = value; }
    }

    public string Timing
    {
        get { return _Timing; }
        set { _Timing = value; }
    }

    public string ModifyingFactors
    {
        get { return _ModifyingFactors; }
        set { _ModifyingFactors = value; }
    }

    public string Quality
    {
        get { return _Quality; }
        set { _Quality = value; }
    }

    public string Duration
    {
        get { return _Duration; }
        set { _Duration = value; }
    }

    public string Context
    {
        get { return _Context; }
        set { _Context = value; }
    }

    public string AssociatedSymptoms
    {
        get { return _AssociatedSymptoms; }
        set { _AssociatedSymptoms = value; }
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

    public Int64 Deleted
    {
        get { return _Deleted; }
        set { _Deleted = value; }
    }

    #endregion
}