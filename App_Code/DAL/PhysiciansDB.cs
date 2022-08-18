using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PhysiciansDB
/// </summary>
public class PhysiciansDB
{
	public PhysiciansDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataTable SearchPracticePhysicians(Int64 practiceId,string pyhsicianName,string searchBy)
    {
        DBManager ObjDBManager = new DBManager();
        ObjDBManager.AddParameter("PracticeId", practiceId);
        ObjDBManager.AddParameter("PyhsicianName", pyhsicianName);
        ObjDBManager.AddParameter("SearchBy", searchBy);
        return ObjDBManager.ExecuteDataTable("SearchPracticePhysicians");
    }
}