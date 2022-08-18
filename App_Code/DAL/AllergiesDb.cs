using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for AllergiesDb
/// </summary>
public class AllergiesDb
{
	public AllergiesDb()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataTable SearchAllergy(string allergy)
    {
        DBManager objDbManager = new DBManager();
        objDbManager.AddParameter("Allergy", allergy);
        return objDbManager.ExecuteDataTable("Chart_SearchAllergy");
    }
}