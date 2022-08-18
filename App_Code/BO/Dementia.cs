using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Dementia
/// </summary>
public class Dementia
{
	public Dementia()
	{
		//
		// TODO: Add constructor logic here
		//
	}


    #region " Private Members "

    long _DementiaId;
    int _PracticeId;
    long _ChartId;
    long _PatientId;
    string _Anxiety = string.Empty;
    string _Sadness = string.Empty;
    string _LackOfReaction = string.Empty;
    string _Irritability = string.Empty;
    string _Agitation = string.Empty;
    string _Retardation = string.Empty;
    string _MultiplePhysicalComplaints = string.Empty;
    string _LossOfInterest = string.Empty;
    string _AppetiteLoss = string.Empty;
    string _WeightLoss = string.Empty;
    string _LackOfEnergy = string.Empty;
    string _DiurnalVariationOfMood = string.Empty;
    string _DifficultyFallingAsleep = string.Empty;
    string _MultipleAwakeningsDuringSleep = string.Empty;
    string _EarlyMorningAwakening = string.Empty;
    string _Suicidal = string.Empty;
    string _PoorSelfEsteem = string.Empty;
    string _Pessimism = string.Empty;
    string _MoodCongruentDelusions = string.Empty;
    DateTime _CreatedDate;
    int _CreatedById;
    DateTime _ModifiedDate;
    int _ModifiedById;

    bool _Deleted = false;
    #endregion

    #region " Properties "

    public long DementiaId
    {
        get { return _DementiaId; }
        set { _DementiaId = value; }
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

    public string Anxiety
    {
        get { return _Anxiety; }
        set { _Anxiety = value; }
    }

    public string Sadness
    {
        get { return _Sadness; }
        set { _Sadness = value; }
    }

    public string LackOfReaction
    {
        get { return _LackOfReaction; }
        set { _LackOfReaction = value; }
    }

    public string Irritability
    {
        get { return _Irritability; }
        set { _Irritability = value; }
    }

    public string Agitation
    {
        get { return _Agitation; }
        set { _Agitation = value; }
    }

    public string Retardation
    {
        get { return _Retardation; }
        set { _Retardation = value; }
    }

    public string MultiplePhysicalComplaints
    {
        get { return _MultiplePhysicalComplaints; }
        set { _MultiplePhysicalComplaints = value; }
    }

    public string LossOfInterest
    {
        get { return _LossOfInterest; }
        set { _LossOfInterest = value; }
    }

    public string AppetiteLoss
    {
        get { return _AppetiteLoss; }
        set { _AppetiteLoss = value; }
    }

    public string WeightLoss
    {
        get { return _WeightLoss; }
        set { _WeightLoss = value; }
    }

    public string LackOfEnergy
    {
        get { return _LackOfEnergy; }
        set { _LackOfEnergy = value; }
    }

    public string DiurnalVariationOfMood
    {
        get { return _DiurnalVariationOfMood; }
        set { _DiurnalVariationOfMood = value; }
    }

    public string DifficultyFallingAsleep
    {
        get { return _DifficultyFallingAsleep; }
        set { _DifficultyFallingAsleep = value; }
    }

    public string MultipleAwakeningsDuringSleep
    {
        get { return _MultipleAwakeningsDuringSleep; }
        set { _MultipleAwakeningsDuringSleep = value; }
    }

    public string EarlyMorningAwakening
    {
        get { return _EarlyMorningAwakening; }
        set { _EarlyMorningAwakening = value; }
    }

    public string Suicidal
    {
        get { return _Suicidal; }
        set { _Suicidal = value; }
    }

    public string PoorSelfEsteem
    {
        get { return _PoorSelfEsteem; }
        set { _PoorSelfEsteem = value; }
    }

    public string Pessimism
    {
        get { return _Pessimism; }
        set { _Pessimism = value; }
    }

    public string MoodCongruentDelusions
    {
        get { return _MoodCongruentDelusions; }
        set { _MoodCongruentDelusions = value; }
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