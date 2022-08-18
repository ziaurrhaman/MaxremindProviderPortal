using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for StatesManager
/// </summary>
public class StatesManager
{
	public StatesManager()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable GetAllAsDataTable(SqlTransaction objDBTransaction = null)
    {
        StatesDB objStatesDB = new StatesDB();
        return objStatesDB.GetAllAsDataTable(objDBTransaction);
    }
} 