using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for AIMS
/// </summary>
public class AIMS
{
	public AIMS()
	{
		//
		// TODO: Add constructor logic here
		//
	}


    #region " Private Members "

    long _AIMSId;
    int _PracticeId;
    long _ChartId;
    long _PatientId;
    int _MusclesOfFacialExpression;
    int _LipsAndPerioralArea;
    int _Jaw;
    int _Tongue;
    int _Upper;
    int _Lower;
    int _NeckShouldersHips;
    int _SeverityOfAbnormalMovementsOverall;
    int _IncapacitationDueToAbnormalMovements;
    int _PatientsAwarenessOfAbnormalMovements;
    int _CurrentProblemsWithTeethAndOrDentures;
    int _AreDenturesUsuallyWorn;
    int _Edentia;
    int _DoMovementsDisappearInSleep;
    DateTime _CreatedDate;
    int _CreatedById;
    DateTime _ModifiedDate;
    int _ModifiedById;
    bool _Deleted = false;

    #endregion

    #region " Properties "

    public long AIMSId
    {
        get { return _AIMSId; }
        set { _AIMSId = value; }
    }

    public int PracticeId
    {
        get { return _PracticeId; }
        set { _PracticeId = value; }
    }

    public long ChartId
    {
        get { return _ChartId; }
        set { _ChartId = value; }
    }

    public long PatientId
    {
        get { return _PatientId; }
        set { _PatientId = value; }
    }

    public int MusclesOfFacialExpression
    {
        get { return _MusclesOfFacialExpression; }
        set { _MusclesOfFacialExpression = value; }
    }

    public int LipsAndPerioralArea
    {
        get { return _LipsAndPerioralArea; }
        set { _LipsAndPerioralArea = value; }
    }

    public int Jaw
    {
        get { return _Jaw; }
        set { _Jaw = value; }
    }

    public int Tongue
    {
        get { return _Tongue; }
        set { _Tongue = value; }
    }

    public int Upper
    {
        get { return _Upper; }
        set { _Upper = value; }
    }

    public int Lower
    {
        get { return _Lower; }
        set { _Lower = value; }
    }

    public int NeckShouldersHips
    {
        get { return _NeckShouldersHips; }
        set { _NeckShouldersHips = value; }
    }

    public int SeverityOfAbnormalMovementsOverall
    {
        get { return _SeverityOfAbnormalMovementsOverall; }
        set { _SeverityOfAbnormalMovementsOverall = value; }
    }

    public int IncapacitationDueToAbnormalMovements
    {
        get { return _IncapacitationDueToAbnormalMovements; }
        set { _IncapacitationDueToAbnormalMovements = value; }
    }

    public int PatientsAwarenessOfAbnormalMovements
    {
        get { return _PatientsAwarenessOfAbnormalMovements; }
        set { _PatientsAwarenessOfAbnormalMovements = value; }
    }

    public int CurrentProblemsWithTeethAndOrDentures
    {
        get { return _CurrentProblemsWithTeethAndOrDentures; }
        set { _CurrentProblemsWithTeethAndOrDentures = value; }
    }

    public int AreDenturesUsuallyWorn
    {
        get { return _AreDenturesUsuallyWorn; }
        set { _AreDenturesUsuallyWorn = value; }
    }

    public int Edentia
    {
        get { return _Edentia; }
        set { _Edentia = value; }
    }

    public int DoMovementsDisappearInSleep
    {
        get { return _DoMovementsDisappearInSleep; }
        set { _DoMovementsDisappearInSleep = value; }
    }

    public DateTime CreatedDate
    {
        get { return _CreatedDate; }
        set { _CreatedDate = value; }
    }

    public int CreatedById
    {
        get { return _CreatedById; }
        set { _CreatedById = value; }
    }

    public DateTime ModifiedDate
    {
        get { return _ModifiedDate; }
        set { _ModifiedDate = value; }
    }

    public int ModifiedById
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