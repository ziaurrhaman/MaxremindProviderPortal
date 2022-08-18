using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for HAMA
/// </summary>
public class HAMA
{
	public HAMA()
	{
		//
		// TODO: Add constructor logic here
		//
	}


    #region " Private Members "

    long _HAMAId;
    int _PracticeId;
    long _ChartId;
    long _PatientId;
    int _AnxiousMood;
    int _Tension;
    int _Fears;
    int _Insomnia;
    int _Intellectual;
    int _DepressedMood;
    int _SomaticMuscular;
    int _SomaticSensory;
    int _CardiovascularSymptoms;
    int _RespiratorySymptoms;
    int _GastrointestinalSymptoms;
    int _GenitourinarySymptoms;
    int _AutonomicSymptoms;
    int _BehaviorAtInterview;
    DateTime _CreatedDate;
    int _CreatedById;
    DateTime _ModifiedDate;
    int _ModifiedById;

    bool _Deleted = false;
    #endregion

    #region " Properties "

    public long HAMAId
    {
        get { return _HAMAId; }
        set { _HAMAId = value; }
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

    public int AnxiousMood
    {
        get { return _AnxiousMood; }
        set { _AnxiousMood = value; }
    }

    public int Tension
    {
        get { return _Tension; }
        set { _Tension = value; }
    }

    public int Fears
    {
        get { return _Fears; }
        set { _Fears = value; }
    }

    public int Insomnia
    {
        get { return _Insomnia; }
        set { _Insomnia = value; }
    }

    public int Intellectual
    {
        get { return _Intellectual; }
        set { _Intellectual = value; }
    }

    public int DepressedMood
    {
        get { return _DepressedMood; }
        set { _DepressedMood = value; }
    }

    public int SomaticMuscular
    {
        get { return _SomaticMuscular; }
        set { _SomaticMuscular = value; }
    }

    public int SomaticSensory
    {
        get { return _SomaticSensory; }
        set { _SomaticSensory = value; }
    }

    public int CardiovascularSymptoms
    {
        get { return _CardiovascularSymptoms; }
        set { _CardiovascularSymptoms = value; }
    }

    public int RespiratorySymptoms
    {
        get { return _RespiratorySymptoms; }
        set { _RespiratorySymptoms = value; }
    }

    public int GastrointestinalSymptoms
    {
        get { return _GastrointestinalSymptoms; }
        set { _GastrointestinalSymptoms = value; }
    }

    public int GenitourinarySymptoms
    {
        get { return _GenitourinarySymptoms; }
        set { _GenitourinarySymptoms = value; }
    }

    public int AutonomicSymptoms
    {
        get { return _AutonomicSymptoms; }
        set { _AutonomicSymptoms = value; }
    }

    public int BehaviorAtInterview
    {
        get { return _BehaviorAtInterview; }
        set { _BehaviorAtInterview = value; }
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