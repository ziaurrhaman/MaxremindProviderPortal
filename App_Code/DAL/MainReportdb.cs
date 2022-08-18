using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MainReportdb
/// </summary>
public class MainReportdb
{
	public MainReportdb()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable getReportList() {

        DBManager objDbManager = new DBManager();
		//objDbManager.AddParameter("@category", Filter);
		return objDbManager.ExecuteDataTable("Reports_Menu_Portal");
    
    } 
}