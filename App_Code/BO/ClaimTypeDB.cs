using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for ClaimTypeDB
/// </summary>
public class ClaimTypeDB
{
	public ClaimTypeDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataTable GetClaimsType()
    {
        try
        {
            DBManager objDBManager = new DBManager();
            return objDBManager.ExecuteDataTable("GetClaimsType");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}