using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BPRS
/// </summary>
public class BPRS
{
	public BPRS()
	{
		//
		// TODO: Add constructor logic here
		//
	}


    #region " Private Members "

    long _BPRSId;
    int _PracticeId;
    long _ChartId;
    long _PatientId;
    int _SomaticConcern;
    int _Anxiety;
    int _EmotionalWithdrawal;
    int _ConceptualDisorganization;
    int _GuiltFeelings;
    int _Tension;
    int _MannerismsAndPosturing;
    int _Grandiosity;
    int _DepressiveMood;
    int _Hostility;
    int _Suspiciousness;
    int _HallucinatoryBehavior;
    int _MotorRetardation;
    int _Uncooperativeness;
    int _UnusualThoughtContent;
    int _BluntedAffect;
    int _Excitement;
    int _Disorientation;
    DateTime _CreatedDate;
    int _CreatedById;
    DateTime _ModifiedDate;
    int _ModifiedById;

    bool _Deleted = false;
    #endregion

    #region " Properties "

    public long BPRSId
    {
        get { return _BPRSId; }
        set { _BPRSId = value; }
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

    public int SomaticConcern
    {
        get { return _SomaticConcern; }
        set { _SomaticConcern = value; }
    }

    public int Anxiety
    {
        get { return _Anxiety; }
        set { _Anxiety = value; }
    }

    public int EmotionalWithdrawal
    {
        get { return _EmotionalWithdrawal; }
        set { _EmotionalWithdrawal = value; }
    }

    public int ConceptualDisorganization
    {
        get { return _ConceptualDisorganization; }
        set { _ConceptualDisorganization = value; }
    }

    public int GuiltFeelings
    {
        get { return _GuiltFeelings; }
        set { _GuiltFeelings = value; }
    }

    public int Tension
    {
        get { return _Tension; }
        set { _Tension = value; }
    }

    public int MannerismsAndPosturing
    {
        get { return _MannerismsAndPosturing; }
        set { _MannerismsAndPosturing = value; }
    }

    public int Grandiosity
    {
        get { return _Grandiosity; }
        set { _Grandiosity = value; }
    }

    public int DepressiveMood
    {
        get { return _DepressiveMood; }
        set { _DepressiveMood = value; }
    }

    public int Hostility
    {
        get { return _Hostility; }
        set { _Hostility = value; }
    }

    public int Suspiciousness
    {
        get { return _Suspiciousness; }
        set { _Suspiciousness = value; }
    }

    public int HallucinatoryBehavior
    {
        get { return _HallucinatoryBehavior; }
        set { _HallucinatoryBehavior = value; }
    }

    public int MotorRetardation
    {
        get { return _MotorRetardation; }
        set { _MotorRetardation = value; }
    }

    public int Uncooperativeness
    {
        get { return _Uncooperativeness; }
        set { _Uncooperativeness = value; }
    }

    public int UnusualThoughtContent
    {
        get { return _UnusualThoughtContent; }
        set { _UnusualThoughtContent = value; }
    }

    public int BluntedAffect
    {
        get { return _BluntedAffect; }
        set { _BluntedAffect = value; }
    }

    public int Excitement
    {
        get { return _Excitement; }
        set { _Excitement = value; }
    }

    public int Disorientation
    {
        get { return _Disorientation; }
        set { _Disorientation = value; }
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