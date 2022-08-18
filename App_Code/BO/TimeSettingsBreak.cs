using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for TimeSettingsBreak
/// </summary>
public class TimeSettingsBreak
{
	
    public TimeSettingsBreak()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    
    #region " Private Members "
    
    private long _BreakTypeId;
    private string _Name;
    private string _TimeFrom;
    private string _TimeTo;

    #endregion

    #region " Properties "

    public Int64 BreakTypeId
    {
        get { return _BreakTypeId; }
        set { _BreakTypeId = value; }
    }

    public string Name
    {
        get { return _Name; }
        set { _Name = value; }
    }

    public string TimeFrom
    {
        get { return _TimeFrom; }
        set { _TimeFrom = value; }
    }

    public string TimeTo
    {
        get { return _TimeTo; }
        set { _TimeTo = value; }
    }

    #endregion

}