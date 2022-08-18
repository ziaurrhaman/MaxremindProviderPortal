using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PHQ2
/// </summary>
public class PHQ2
{
	public PHQ2()
	{
		//
		// TODO: Add constructor logic here
		//
	}


    #region " Private Members "

    Int64 _PHQ2Id;
    int _PracticeId;
    Int64 _ChartId;
    Int64 _PatientId;
    int _LittleInterest;
    int _FeelingDown;

    DateTime _CreatedDate;
    int _CreatedById;
    DateTime _ModifiedDate;
    int _ModifiedById;
    bool _Deleted = false;

    #endregion

    #region " Properties "

    public Int64 PHQ2Id
    {
        get { return _PHQ2Id; }
        set { _PHQ2Id = value; }
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