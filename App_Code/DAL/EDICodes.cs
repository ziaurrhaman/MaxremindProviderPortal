using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for EDICodes
/// </summary>
public class EDICodes
{
	public EDICodes()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable GetEDICodes()
    {
        DBManager objDBManager = new DBManager();

        return objDBManager.ExecuteDataTable("EDICODES_GETALL");
    }
}