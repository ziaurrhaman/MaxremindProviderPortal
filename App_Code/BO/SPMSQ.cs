using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SPMSQ
/// </summary>
public class SPMSQ
{
	public SPMSQ()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    #region " Private Members "

    long _SPMSQId;
    int _PracticeId;
    long _ChartId;
    long _PatientId;

    string _DateToday = string.Empty;
    string _DayOfTheWeek = string.Empty;
    string _NameOfThisPlace = string.Empty;
    string _TelephoneNumber = string.Empty;
    string _StreetAddress = string.Empty;
    string _HowOldAreYou = string.Empty;
    string _WhenWereYouBorn = string.Empty;
    string _PresidentOfUSA = string.Empty;
    string _PresidentJustBefore = string.Empty;
    string _MothersMaidenName = string.Empty;
    string _Subtract3From20 = string.Empty;

    DateTime _CreatedDate;
    int _CreatedById;
    DateTime _ModifiedDate;
    int _ModifiedById;
    bool _Deleted = false;

    #endregion

    #region " Properties "

    public long SPMSQId
    {
        get { return _SPMSQId; }
        set { _SPMSQId = value; }
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

    public string DateToday
    {
        get { return _DateToday; }
        set { _DateToday = value; }
    }

    public string DayOfTheWeek
    {
        get { return _DayOfTheWeek; }
        set { _DayOfTheWeek = value; }
    }

    public string NameOfThisPlace
    {
        get { return _NameOfThisPlace; }
        set { _NameOfThisPlace = value; }
    }

    public string TelephoneNumber
    {
        get { return _TelephoneNumber; }
        set { _TelephoneNumber = value; }
    }

    public string StreetAddress
    {
        get { return _StreetAddress; }
        set { _StreetAddress = value; }
    }

    public string HowOldAreYou
    {
        get { return _HowOldAreYou; }
        set { _HowOldAreYou = value; }
    }

    public string WhenWereYouBorn
    {
        get { return _WhenWereYouBorn; }
        set { _WhenWereYouBorn = value; }
    }

    public string PresidentOfUSA
    {
        get { return _PresidentOfUSA; }
        set { _PresidentOfUSA = value; }
    }

    public string PresidentJustBefore
    {
        get { return _PresidentJustBefore; }
        set { _PresidentJustBefore = value; }
    }

    public string MothersMaidenName
    {
        get { return _MothersMaidenName; }
        set { _MothersMaidenName = value; }
    }

    public string Subtract3From20
    {
        get { return _Subtract3From20; }
        set { _Subtract3From20 = value; }
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