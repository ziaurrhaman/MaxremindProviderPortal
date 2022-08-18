using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for InsuranceCategoryDB
/// </summary>
public class InsuranceCategoryDB
{
	public InsuranceCategoryDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataTable InsuranceCategory_GetAll()
    {
        DBManager objDBManager = new DBManager();
        return objDBManager.ExecuteDataTable("InsuranceCategory_GetAll");
    }
}