using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
/// <summary>
/// Summary description for Languages
/// </summary>
public class LanguagesDB
{
	public LanguagesDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataTable GetAllLanguages()
    {
        DBManager ObjDBManager = new DBManager();
        return ObjDBManager.ExecuteDataTable("GetAllLanguages");
    }
}