using System;
using System.Data;

/// <summary>
/// Summary description for LabsDB
/// </summary>
public class LabsDB
{
	public LabsDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataTable FilterLabs(Int64 practiceId, string name)
    {
        DBManager ObjDBManager = new DBManager();
        ObjDBManager.AddParameter("Name", name);
        ObjDBManager.AddParameter("PracticeId", practiceId);        
        return ObjDBManager.ExecuteDataTable("Labs_FilterLabs");
    }
}