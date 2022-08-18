using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for GDS
/// </summary>
public class GDS
{
	public GDS()
	{
		//
		// TODO: Add constructor logic here
		//
	}


    #region " Private Members "

    long _GDSId;
    int _PracticeId;
    long _ChartId;
    long _PatientId;
    int _SatisfiedWithYourLife;
    int _DroppedActivitiesAndInterests;
    int _YourLifeIsEmpty;
    int _GetBored;
    int _InGoodSpirits;
    int _SomethingBadIsGoingToHappen;
    int _HappyMostOfTheTime;
    int _FeelHelpless;
    int _PreferToStayAtHome;
    int _ProblemsWithMemory;
    int _WonderfulToBeAliveNow;
    int _PrettyWorthless;
    int _FullOfEnergy;
    int _SituationIsHopeless;
    int _MostPeopleAreBetter;
    DateTime _CreatedDate;
    int _CreatedById;
    DateTime _ModifiedDate;
    int _ModifiedById;

    bool _Deleted = false;
    #endregion

    #region " Properties "

    public long GDSId
    {
        get { return _GDSId; }
        set { _GDSId = value; }
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

    public int SatisfiedWithYourLife
    {
        get { return _SatisfiedWithYourLife; }
        set { _SatisfiedWithYourLife = value; }
    }

    public int DroppedActivitiesAndInterests
    {
        get { return _DroppedActivitiesAndInterests; }
        set { _DroppedActivitiesAndInterests = value; }
    }

    public int YourLifeIsEmpty
    {
        get { return _YourLifeIsEmpty; }
        set { _YourLifeIsEmpty = value; }
    }

    public int GetBored
    {
        get { return _GetBored; }
        set { _GetBored = value; }
    }

    public int InGoodSpirits
    {
        get { return _InGoodSpirits; }
        set { _InGoodSpirits = value; }
    }

    public int SomethingBadIsGoingToHappen
    {
        get { return _SomethingBadIsGoingToHappen; }
        set { _SomethingBadIsGoingToHappen = value; }
    }

    public int HappyMostOfTheTime
    {
        get { return _HappyMostOfTheTime; }
        set { _HappyMostOfTheTime = value; }
    }

    public int FeelHelpless
    {
        get { return _FeelHelpless; }
        set { _FeelHelpless = value; }
    }

    public int PreferToStayAtHome
    {
        get { return _PreferToStayAtHome; }
        set { _PreferToStayAtHome = value; }
    }

    public int ProblemsWithMemory
    {
        get { return _ProblemsWithMemory; }
        set { _ProblemsWithMemory = value; }
    }

    public int WonderfulToBeAliveNow
    {
        get { return _WonderfulToBeAliveNow; }
        set { _WonderfulToBeAliveNow = value; }
    }

    public int PrettyWorthless
    {
        get { return _PrettyWorthless; }
        set { _PrettyWorthless = value; }
    }

    public int FullOfEnergy
    {
        get { return _FullOfEnergy; }
        set { _FullOfEnergy = value; }
    }

    public int SituationIsHopeless
    {
        get { return _SituationIsHopeless; }
        set { _SituationIsHopeless = value; }
    }

    public int MostPeopleAreBetter
    {
        get { return _MostPeopleAreBetter; }
        set { _MostPeopleAreBetter = value; }
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