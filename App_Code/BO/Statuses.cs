using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Statuses
/// </summary>
public class Statuses
{
	public Statuses()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    #region " Private Members "

    int _StatusId;
    string _StatusName = string.Empty;
    string _StatusBackColor = string.Empty;
    private bool _Deleted = false;
    #endregion

    #region " Properties "

    public int StatusId
    {
        get { return _StatusId; }
        set { _StatusId = value; }
    }

    public string StatusName
    {
        get { return _StatusName; }
        set { _StatusName = value; }
    }

    public string StatusBackColor
    {
        get { return _StatusBackColor; }
        set { _StatusBackColor = value; }
    }

    public bool Deleted
    {
        get { return _Deleted; }
        set { _Deleted = value; }
    }

    #endregion

}