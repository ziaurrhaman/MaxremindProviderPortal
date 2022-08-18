using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CPT1Codes
/// </summary>
public class CPT1Codes
{
	public CPT1Codes()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    #region " Private Members "

    int _CPTID;
    string _CPTcode = string.Empty;
    string _CPTdescription = string.Empty;
    bool _CPTcommon = false;
    string _AverageFee = string.Empty;
    double _RVU = double.MinValue;

    bool _personalcode = false;
    #endregion

    #region " Properties "

    public int CPTID
    {
        get { return _CPTID; }
        set { _CPTID = value; }
    }

    public string CPTcode
    {
        get { return _CPTcode; }
        set { _CPTcode = value; }
    }

    public string CPTdescription
    {
        get { return _CPTdescription; }
        set { _CPTdescription = value; }
    }

    public bool CPTcommon
    {
        get { return _CPTcommon; }
        set { _CPTcommon = value; }
    }

    public string AverageFee
    {
        get { return _AverageFee; }
        set { _AverageFee = value; }
    }

    public double RVU
    {
        get { return _RVU; }
        set { _RVU = value; }
    }

    public bool personalcode
    {
        get { return _personalcode; }
        set { _personalcode = value; }
    }

    #endregion
}