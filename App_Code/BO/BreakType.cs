using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BreakType
/// </summary>
public class BreakType
{
	public BreakType()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    #region " Private Members "

    long _BreakTypeId;
    string _Name;

    #endregion

    #region " Properties "

    public long BreakTypeId
    {
        get { return _BreakTypeId; }
        set { _BreakTypeId = value; }
    }

    public string Name
    {
        get { return _Name; }
        set { _Name = value; }
    }

    #endregion
}