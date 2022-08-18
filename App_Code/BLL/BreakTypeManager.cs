using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for BreakTypeManager
/// </summary>
public class BreakTypeManager
{
	public BreakTypeManager()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable GetAllAsDataTable()
    {
        BreakTypeDB objBreakTypeDB = new BreakTypeDB();
        return objBreakTypeDB.GetAllAsDataTable();
    }
}