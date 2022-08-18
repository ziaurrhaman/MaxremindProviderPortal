using System;
using System.Data;


/// <summary>
/// Summary description for MeasuringUnitsDB
/// </summary>
public class MeasuringUnitsDB
{
    public MeasuringUnitsDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataTable GetUnits()
    {
        DBManager ObjDBManager = new DBManager();       
        return ObjDBManager.ExecuteDataTable("MeasuringUnits_GetUnits");
    }
}