using System;

/// <summary>
/// Summary description for PatientVitals
/// </summary>
public class PatientVitals
{
	public PatientVitals()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    #region " Private Members "

    private Int64 _VitalId;
    private Int64 _PatientId;
    private Int64? _ChartId;
    private Int64 _PracticeId;
    private string _Height = string.Empty;
    private string _Weight = string.Empty;
    private string _Temperature = string.Empty;
    private string _Source = string.Empty;
    string _SupplementalO2 = string.Empty;
    string _SupplementalO2Unit = string.Empty;
    private string _HeadCircumference = string.Empty;
    private int? _NoOfLiters;
    private string _RespirationRate = string.Empty;
    private string _PulseRate = string.Empty;
    private string _OxygenSaturation = string.Empty;
    private string _HeartRate = string.Empty;
    private string _Rhythm = string.Empty;
    private string _Volume = string.Empty;
    private string _Character = string.Empty;
    private string _BP1Systolic = string.Empty;
    private string _BP1Diastolic = string.Empty;
    private string _BP1MonitoringPos = string.Empty;
    private string _BP2Systolic = string.Empty;
    private string _BP2Diastolic = string.Empty;
    private string _BP2MonitoringPos = string.Empty;
    private string _Delay = string.Empty;
    private DateTime? _LMP;
    private DateTime? _EDD;
    private string _PregnancyText = string.Empty;
    private Int64 _CreatedById;
    private DateTime _CreatedDate;
    private Int64? _ModifiedById;
    private DateTime? _ModifiedDate;
    private Int64 _Deleted;
    private string _AgeInMonths = string.Empty;
    private string _VisitDate = string.Empty;
    private string _LesionsSize = string.Empty;
    private DateTime? _TakenTime;
    private int? _PainScale;
    private string _PatientCondition = string.Empty;

    
    #endregion

    #region " Properties "

    public Int64 VitalId
    {
        get { return _VitalId; }
        set { _VitalId = value; }
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

    public Int64 PracticeId
    {
        get { return _PracticeId; }
        set { _PracticeId = value; }
    }

    public string Height
    {
        get { return _Height; }
        set { _Height = value; }
    }

    public string Weight
    {
        get { return _Weight; }
        set { _Weight = value; }
    }

    public string Temperature
    {
        get { return _Temperature; }
        set { _Temperature = value; }
    }

    public string Source
    {
        get { return _Source; }
        set { _Source = value; }
    }
    public string SupplementalO2
    {
        get { return _SupplementalO2; }
        set { _SupplementalO2 = value; }
    }

    public string SupplementalO2Unit
    {
        get { return _SupplementalO2Unit; }
        set { _SupplementalO2Unit = value; }
    }
    public string HeadCircumference
    {
        get { return _HeadCircumference; }
        set { _HeadCircumference = value; }
    }

    public int? NoOfLiters
    {
        get { return _NoOfLiters; }
        set { _NoOfLiters = value; }
    }

    public string RespirationRate
    {
        get { return _RespirationRate; }
        set { _RespirationRate = value; }
    }

    public string PulseRate
    {
        get { return _PulseRate; }
        set { _PulseRate = value; }
    }

    public string OxygenSaturation
    {
        get { return _OxygenSaturation; }
        set { _OxygenSaturation = value; }
    }

    public string HeartRate
    {
        get { return _HeartRate; }
        set { _HeartRate = value; }
    }

    public string Rhythm
    {
        get { return _Rhythm; }
        set { _Rhythm = value; }
    }

    public string Volume
    {
        get { return _Volume; }
        set { _Volume = value; }
    }

    public string Character
    {
        get { return _Character; }
        set { _Character = value; }
    }

    public string BP1Systolic
    {
        get { return _BP1Systolic; }
        set { _BP1Systolic = value; }
    }

    public string BP1Diastolic
    {
        get { return _BP1Diastolic; }
        set { _BP1Diastolic = value; }
    }

    public string BP1MonitoringPos
    {
        get { return _BP1MonitoringPos; }
        set { _BP1MonitoringPos = value; }
    }

    public string BP2Systolic
    {
        get { return _BP2Systolic; }
        set { _BP2Systolic = value; }
    }

    public string BP2Diastolic
    {
        get { return _BP2Diastolic; }
        set { _BP2Diastolic = value; }
    }

    public string BP2MonitoringPos
    {
        get { return _BP2MonitoringPos; }
        set { _BP2MonitoringPos = value; }
    }

    public string Delay
    {
        get { return _Delay; }
        set { _Delay = value; }
    }

    public DateTime? LMP
    {
        get { return _LMP; }
        set { _LMP = value; }
    }
    public DateTime? EDD
    {
        get { return _EDD; }
        set { _EDD = value; }
    }
    public string PregnancyText
    {
        get { return _PregnancyText; }
        set { _PregnancyText = value; }
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

    public string AgeInMonths
    {
        get { return _AgeInMonths; }
        set { _AgeInMonths = value; }
    }

    public string VisitDate
    {
        get { return _VisitDate; }
        set { _VisitDate = value; }
    }
    public string LesionsSize
    {
        get { return _LesionsSize; }
        set { _LesionsSize = value; }
    }
    public DateTime? TakenTime
    {
        get { return _TakenTime; }
        set { _TakenTime = value; }
    }
    public int? PainScale
    {
        get { return _PainScale; }
        set { _PainScale = value; }
    }
    public string PatientCondition
    {
        get { return _PatientCondition; }
        set { _PatientCondition = value; }
    }
    #endregion
}