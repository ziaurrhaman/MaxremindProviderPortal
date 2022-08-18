using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
/// <summary>
/// Summary description for RaceDB
/// </summary>
public class RaceDB
{
	public RaceDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataTable GetAllRace()
    {
        DBManager objDBManager = new DBManager();
        return objDBManager.ExecuteDataTable("GetAllRace");
    }
    public DataTable GetPatientAllRace(string RaceIds)
    {
        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("@RaceIds", RaceIds);
        return objDBManager.ExecuteDataTable("GetPatientAllRace");
    }
}