using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
/// <summary>
/// Summary description for Ethnicity
/// </summary>
public class EthnicityDB
{
	public EthnicityDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataTable GetAllEthnicity()
    {
        DBManager objDBManager = new DBManager();
        return objDBManager.ExecuteDataTable("GetAllEthnicity");
    }
    public DataTable GetAllEthnicity(string EthnicityIds)
    {
        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("@EthnicityIds", EthnicityIds);
        return objDBManager.ExecuteDataTable("GetPatientAllEthnicity");
    }
}