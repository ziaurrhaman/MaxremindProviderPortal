using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PHQ9
/// </summary>
public class PHQ9
{
	public PHQ9()
	{
		//
		// TODO: Add constructor logic here
		//
	}


    #region " Private Members "

    Int64 _PHQ9Id;
    int _PracticeId;
    Int64 _ChartId;
    Int64 _PatientId;
    int _LittleInterest;
    int _FeelingDown;
    int _TroubleFalling;
    int _FeelingTired;
    int _PoorAppetite;
    int _FeelingBad;
    int _TroubleConcentrating;
    int _MovingOrSpeaking;
    int _Thoughts;

    DateTime _CreatedDate;
    int _CreatedById;
    DateTime _ModifiedDate;
    int _ModifiedById;
    bool _Deleted = false;

    #endregion

    #region " Properties "

    public Int64 PHQ9Id
    {
        get { return _PHQ9Id; }
        set { _PHQ9Id = value; }
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

    public int LittleInterest
    {
        get { return _LittleInterest; }
        set { _LittleInterest = value; }
    }

    public int FeelingDown
    {
        get { return _FeelingDown; }
        set { _FeelingDown = value; }
    }

    public int TroubleFalling
    {
        get { return _TroubleFalling; }
        set { _TroubleFalling = value; }
    }

    public int FeelingTired
    {
        get { return _FeelingTired; }
        set { _FeelingTired = value; }
    }

    public int PoorAppetite
    {
        get { return _PoorAppetite; }
        set { _PoorAppetite = value; }
    }

    public int FeelingBad
    {
        get { return _FeelingBad; }
        set { _FeelingBad = value; }
    }

    public int TroubleConcentrating
    {
        get { return _TroubleConcentrating; }
        set { _TroubleConcentrating = value; }
    }

    public int MovingOrSpeaking
    {
        get { return _MovingOrSpeaking; }
        set { _MovingOrSpeaking = value; }
    }

    public int Thoughts
    {
        get { return _Thoughts; }
        set { _Thoughts = value; }
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