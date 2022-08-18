using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for AdmissionSourceDB
/// </summary>
public class AdmissionSourceDB
{
	public AdmissionSourceDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable GetAdmissionSourceByType(string AdmissionType)
    {
        DBManager ObjDBManager = new DBManager();
        if (!string.IsNullOrEmpty(AdmissionType))
        {
            ObjDBManager.AddParameter("@AdmissionTypeId", AdmissionType);
        }
        return ObjDBManager.ExecuteDataTable("AdmissionSource_GetByAdmissionType");
    }
}