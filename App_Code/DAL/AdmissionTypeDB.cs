using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for AdmissionTypeDB
/// </summary>
public class AdmissionTypeDB
{
	public AdmissionTypeDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable GetAdmissionTypes()
    {
        DBManager ObjDBManager = new DBManager();
        return ObjDBManager.ExecuteDataTable("AdmissionType_GetAll");
    }
}