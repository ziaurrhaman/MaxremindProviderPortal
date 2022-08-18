using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for ICD9CodesDB
/// </summary>
public class ICD9CodesDB
{
	public ICD9CodesDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable ICD9Codes_AutoComplete(string Code, string ShorterDescription)
    {
        DBManager ObjDBManager = new DBManager();
        if (!string.IsNullOrEmpty(Code))
        {
            ObjDBManager.AddParameter("Code", Code, SqlDbType.NVarChar, 32);
        }

        if (!string.IsNullOrEmpty(ShorterDescription))
        {
            ObjDBManager.AddParameter("ShorterDescription", ShorterDescription, SqlDbType.NVarChar, 255);
        }

        DataTable ddtCodes = ObjDBManager.ExecuteDataTable("ICD9Codes_AutoComplete");
        return ddtCodes;
    }
}