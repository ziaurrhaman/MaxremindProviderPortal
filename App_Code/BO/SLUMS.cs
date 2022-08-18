using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SLUMS
/// </summary>
public class SLUMS
{
	public SLUMS()
	{
		//
		// TODO: Add constructor logic here
		//
	}


    #region " Private Members "

    Int64 _SLUMSId;
    int _PracticeId;
    Int64 _ChartId;
    Int64 _PatientId;
    int? _DayOfTheWeek;
    int? _WhatIsTheYear;
    int? _WhatIsState;
    int? _HowMuchSpend;
    int? _HowMuchLeft;
    int? _AnimalNames;
    int? _FiveObjects;
    string _SeriesOfNumber;
    int? _MarkerOkay;
    int? _TimeCorrect;
    int? _XInTheTriangle;
    int? _LargestFigure;
    int? _FemaleName;
    int? _WorkSheDo;
    int? _SheGoBackToWork;
    int? _StateSheLiveIn;

    DateTime _CreatedDate;
    int _CreatedById;
    DateTime _ModifiedDate;
    int _ModifiedById;
    bool _Deleted = false;

    #endregion

    #region " Properties "

    public Int64 SLUMSId
    {
        get { return _SLUMSId; }
        set { _SLUMSId = value; }
    }

    public int PracticeId
    {
        get { return _PracticeId; }
        set { _PracticeId = value; }
    }

    public Int64 ChartId
    {
        get { return _ChartId; }
        set { _ChartId = value; }
    }

    public Int64 PatientId
    {
        get { return _PatientId; }
        set { _PatientId = value; }
    }

    public int? DayOfTheWeek
    {
        get { return _DayOfTheWeek; }
        set { _DayOfTheWeek = value; }
    }

    public int? WhatIsTheYear
    {
        get { return _WhatIsTheYear; }
        set { _WhatIsTheYear = value; }
    }

    public int? WhatIsState
    {
        get { return _WhatIsState; }
        set { _WhatIsState = value; }
    }

    public int? HowMuchSpend
    {
        get { return _HowMuchSpend; }
        set { _HowMuchSpend = value; }
    }

    public int? HowMuchLeft
    {
        get { return _HowMuchLeft; }
        set { _HowMuchLeft = value; }
    }

    public int? AnimalNames
    {
        get { return _AnimalNames; }
        set { _AnimalNames = value; }
    }

    public int? FiveObjects
    {
        get { return _FiveObjects; }
        set { _FiveObjects = value; }
    }

    public string SeriesOfNumber
    {
        get { return _SeriesOfNumber; }
        set { _SeriesOfNumber = value; }
    }

    public int? MarkerOkay
    {
        get { return _MarkerOkay; }
        set { _MarkerOkay = value; }
    }

    public int? TimeCorrect
    {
        get { return _TimeCorrect; }
        set { _TimeCorrect = value; }
    }

    public int? XInTheTriangle
    {
        get { return _XInTheTriangle; }
        set { _XInTheTriangle = value; }
    }

    public int? LargestFigure
    {
        get { return _LargestFigure; }
        set { _LargestFigure = value; }
    }

    public int? FemaleName
    {
        get { return _FemaleName; }
        set { _FemaleName = value; }
    }

    public int? WorkSheDo
    {
        get { return _WorkSheDo; }
        set { _WorkSheDo = value; }
    }

    public int? SheGoBackToWork
    {
        get { return _SheGoBackToWork; }
        set { _SheGoBackToWork = value; }
    }

    public int? StateSheLiveIn
    {
        get { return _StateSheLiveIn; }
        set { _StateSheLiveIn = value; }
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