using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for GAD7
/// </summary>
public class GAD7
{
	public GAD7()
	{
		//
		// TODO: Add constructor logic here
		//
	}


    #region " Private Members "

    Int64 _GAD7Id;
    int _PracticeId;
    Int64 _ChartId;
    Int64 _PatientId;
    int _FeelingNervous;
    int _NotBeing;
    int _WorryingTooMuch;
    int _TroubleRelaxing;
    int _BeingSoRestless;
    int _BecomingEasilyAnnoyed;
    int _FeelingAfraid;

    DateTime _CreatedDate;
    int _CreatedById;
    DateTime _ModifiedDate;
    int _ModifiedById;
    bool _Deleted = false;

    #endregion

    #region " Properties "

    public Int64 GAD7Id
    {
        get { return _GAD7Id; }
        set { _GAD7Id = value; }
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

    public int FeelingNervous
    {
        get { return _FeelingNervous; }
        set { _FeelingNervous = value; }
    }

    public int NotBeing
    {
        get { return _NotBeing; }
        set { _NotBeing = value; }
    }

    public int WorryingTooMuch
    {
        get { return _WorryingTooMuch; }
        set { _WorryingTooMuch = value; }
    }

    public int TroubleRelaxing
    {
        get { return _TroubleRelaxing; }
        set { _TroubleRelaxing = value; }
    }

    public int BeingSoRestless
    {
        get { return _BeingSoRestless; }
        set { _BeingSoRestless = value; }
    }

    public int BecomingEasilyAnnoyed
    {
        get { return _BecomingEasilyAnnoyed; }
        set { _BecomingEasilyAnnoyed = value; }
    }

    public int FeelingAfraid
    {
        get { return _FeelingAfraid; }
        set { _FeelingAfraid = value; }
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