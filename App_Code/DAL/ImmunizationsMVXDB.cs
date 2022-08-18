using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
/// <summary>
/// Summary description for ImmunizationsMVXDB
/// </summary>
public class ImmunizationsMVXDB
{
	public ImmunizationsMVXDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable ImmunizationsMVX_GetByImmunizationId(Int64 ImmunizationId)
    {
        DBManager objDbManager = new DBManager();
        objDbManager.AddParameter("@ImmunizationId", ImmunizationId);
        return objDbManager.ExecuteDataTable("ImmunizationsMVX_GetByImmunizationId");

    }
}