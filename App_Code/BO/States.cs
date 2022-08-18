using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for States
/// </summary>
public class States
{
    public States()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region " Private Members "

    int _StateId;
    string _StateName;
    string _StateCode;

    #endregion

    #region " Properties "

    public int StateId
    {
        get { return _StateId; }
        set { _StateId = value; }
    }

    public string StateName
    {
        get { return _StateName; }
        set { _StateName = value; }
    }

    public string StateCode
    {
        get { return _StateCode; }
        set { _StateCode = value; }
    }

    #endregion
}