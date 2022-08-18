using System;

/// <summary>
/// Summary description for LoincCodes
/// </summary>
public class LoincCodes
{
	public LoincCodes()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    #region " Private Members "

    private int _ResultId;
    private string _Code = string.Empty;
    private string _Name = string.Empty;

    string _Component = string.Empty;
    #endregion

    #region " Properties "

    public int ResultId
    {
        get { return _ResultId; }
        set { _ResultId = value; }
    }

    public string Code
    {
        get { return _Code; }
        set { _Code = value; }
    }

    public string Name
    {
        get { return _Name; }
        set { _Name = value; }
    }

    public string Component
    {
        get { return _Component; }
        set { _Component = value; }
    }

    #endregion
}