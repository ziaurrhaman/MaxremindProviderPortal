using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for ZipCodesDB
/// </summary>
public class ZipCodesDB
{ 
	public ZipCodesDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable GetCityStateByZipCode(string zipcode)
    {
        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("ZipCode", zipcode);
        return objDBManager.ExecuteDataTable("ZipCodes_GetCityState");
    }

    public DataTable GetZipCityState(string zip, string city)
    {

        DBManager ObjDBManager = new DBManager();
        if (!string.IsNullOrEmpty(zip))
        {

            ObjDBManager.AddParameter("ZipCode", zip);
        }

        if (!string.IsNullOrEmpty(city))
        {
            ObjDBManager.AddParameter("City", city);
        }

        return ObjDBManager.ExecuteDataTable("GetZipCityState");


    }

    public DataTable ShowZipCityCodes(string zipcode)
    {
        DBManager ObjDBManager = new DBManager();
     ObjDBManager.AddParameter("ZipCode", zipcode);
    return ObjDBManager.ExecuteDataTable("ZipCityState");
    }

}