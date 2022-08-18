using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for CPTCodesDB
/// </summary>
public class CPT1CodesDB
{
	public CPT1CodesDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable CPT1Codes_AutoComplete(string Code, string Description)
    {
        DBManager ObjDBManager = new DBManager();
        if (!string.IsNullOrEmpty(Code))
        {
            ObjDBManager.AddParameter("CPTCode", Code, SqlDbType.NVarChar, 32);
        }

        if (!string.IsNullOrEmpty(Description))
        {
            ObjDBManager.AddParameter("CPTDescription", Description, SqlDbType.NVarChar, 255);
        }

        DataTable dtCodes = ObjDBManager.ExecuteDataTable("CPT1Codes_AutoComplete");
        return dtCodes;
    }

    public DataTable FilterCPTs(string Code, string Description, long PracticeId, string PriInsurance, bool FeeSchedule, string CPTCodeFromPdf = null, string Modifier = null)
    {
        DBManager ObjDBManager = new DBManager();
        if (!string.IsNullOrEmpty(Code))
        {
            ObjDBManager.AddParameter("CPTCode", Code);
        }
        if (!string.IsNullOrEmpty(Description))
        {
            ObjDBManager.AddParameter("CPTDescription", Description);
        }
        if (FeeSchedule)
        {
            ObjDBManager.AddParameter("PracticeId", PracticeId);
        }
        ObjDBManager.AddParameter("Payer", PriInsurance);
        if (!string.IsNullOrEmpty(CPTCodeFromPdf))
        {
            ObjDBManager.AddParameter("CPTCodeFromPdf", CPTCodeFromPdf);
        }
        if (!string.IsNullOrEmpty(Modifier))
        {
            if (Modifier == "TC" || Modifier == "26" || Modifier == "53")
                ObjDBManager.AddParameter("Modifier", Modifier);
        }


        return ObjDBManager.ExecuteDataTable("FilterCPTs");
    }

    public DataTable ServiceCharges(string Code, string Dos)
    {
        DBManager ObjDBManager = new DBManager();
        if (!string.IsNullOrEmpty(Code))
        {
            ObjDBManager.AddParameter("CPTCode", Code);
        }
        if (!string.IsNullOrEmpty(Dos))
        {
            ObjDBManager.AddParameter("Dos", Dos);
        }
        return ObjDBManager.ExecuteDataTable("ServiceCharges");
    }
}