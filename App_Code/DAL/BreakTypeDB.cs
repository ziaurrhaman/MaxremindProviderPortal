using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for BreakTypeDB
/// </summary>
public class BreakTypeDB
{
	public BreakTypeDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable GetAllAsDataTable()
    {
        try
        {
            DBManager objDBManager = new DBManager();
            return objDBManager.ExecuteDataTable("BreakType_GetAllType");
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
}