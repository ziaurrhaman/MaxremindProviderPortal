using System;
using System.Data;


/// <summary>
/// Summary description for LoincCodesDB
/// </summary>
public class LoincCodesDB
{
	public LoincCodesDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataTable FilterLoinc(string code, string name)
    {
        DBManager ObjDBManager = new DBManager();
        if (!string.IsNullOrEmpty(code))
        {
            ObjDBManager.AddParameter("Code", code);
        }
        if (!string.IsNullOrEmpty(name))
        {
            ObjDBManager.AddParameter("Name", name);
        }
        return ObjDBManager.ExecuteDataTable("Loinc_FilterLoinc");
    }
}