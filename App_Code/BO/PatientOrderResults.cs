using System;


/// <summary>
/// Summary description for PatientOrderResults
/// </summary>
public class PatientOrderResults
{
	public PatientOrderResults()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    #region " Private Members "

    private Int64 _PatientOrderResultId;
    private Int64 _PatientOrderId;
    private Int64 _PatientId;
    private string _TestName = string.Empty;
    private Int64 _GroupId;
    private Int64 _PatientOrderTestId;
    private string _RangeValueRecomended = string.Empty;
    private string _RangeValueModerate = string.Empty;
    private string _RangeValueHigh = string.Empty;    
    private string _Comments = string.Empty;
    private bool _Abnormal = false;
    private string _AbnormalRangeCode = string.Empty;
    private string _ResultStatusCode = string.Empty;
    private string _ResultId = string.Empty;    
    private string _ResultUnit;
    private string _ResultValue = string.Empty;
    private DateTime _ObservationDate;
    private string _AssignTo = string.Empty;
    private bool _Review = false;
    private Int64? _ReviewedBy;
    private DateTime? _ReviewedDate;    
    private long _CreatedById;
    private DateTime _CreatedDate;
    private long _ModifiedById;
    private DateTime _ModifiedDate;
    private bool _Deleted = false;

    #endregion

    #region " Properties "

    public Int64 PatientOrderResultId
    {
        get { return _PatientOrderResultId; }
        set { _PatientOrderResultId = value; }
    }

    public Int64 PatientOrderId
    {
        get { return _PatientOrderId; }
        set { _PatientOrderId = value; }
    }

    public Int64 PatientId
    {
        get { return _PatientId; }
        set { _PatientId = value; }
    }

    public string TestName
    {
        get { return _TestName; }
        set { _TestName = value; }
    }

    public Int64 GroupId
    {
        get { return _GroupId; }
        set { _GroupId = value; }
    }

    public Int64 PatientOrderTestId
    {
        get { return _PatientOrderTestId; }
        set { _PatientOrderTestId = value; }
    }

    public string RangeValueRecomended
    {
        get { return _RangeValueRecomended; }
        set { _RangeValueRecomended = value; }
    }

    public string RangeValueModerate
    {
        get { return _RangeValueModerate; }
        set { _RangeValueModerate = value; }
    }

    public string RangeValueHigh
    {
        get { return _RangeValueHigh; }
        set { _RangeValueHigh = value; }
    }

    

    public string Comments
    {
        get { return _Comments; }
        set { _Comments = value; }
    }

    public bool Abnormal
    {
        get { return _Abnormal; }
        set { _Abnormal = value; }
    }

    public string AbnormalRangeCode
    {
        get { return _AbnormalRangeCode; }
        set { _AbnormalRangeCode = value; }
    }

    public string ResultStatusCode
    {
        get { return _ResultStatusCode; }
        set { _ResultStatusCode = value; }
    }

    public string ResultId
    {
        get { return _ResultId; }
        set { _ResultId = value; }
    }

    public string ResultUnit
    {
        get { return _ResultUnit; }
        set { _ResultUnit = value; }
    }

    public string ResultValue
    {
        get { return _ResultValue; }
        set { _ResultValue = value; }
    }

    public DateTime ObservationDate
    {
        get { return _ObservationDate; }
        set { _ObservationDate = value; }
    }

    public string AssignTo
    {
        get { return _AssignTo; }
        set { _AssignTo = value; }
    }

    public bool Review
    {
        get { return _Review; }
        set { _Review = value; }
    }

    public Int64? ReviewedBy
    {
        get { return _ReviewedBy; }
        set { _ReviewedBy = value; }
    }

    public DateTime? ReviewedDate
    {
        get { return _ReviewedDate; }
        set { _ReviewedDate = value; }
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