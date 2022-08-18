using System;


/// <summary>
/// Summary description for MeasuringUnits
/// </summary>
public class MeasuringUnits
{
	public MeasuringUnits()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    #region " Private Members "

    private int _UnitId ;
    private string _UnitOfMeasure = string.Empty;

    #endregion

    #region " Properties "

    public int UnitId
    {
        get { return _UnitId; }
        set { _UnitId = value; }
    }

    public string UnitOfMeasure
    {
        get { return _UnitOfMeasure; }
        set { _UnitOfMeasure = value; }
    }

    #endregion
}