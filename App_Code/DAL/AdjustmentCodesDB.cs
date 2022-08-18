using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for AdjustmentCodesDB
/// </summary>
public class AdjustmentCodesDB
{
	public AdjustmentCodesDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable GetAllFilter(string SearchKey)
    {
        DBManager objDbManager = new DBManager();

        objDbManager.AddParameter("SearchKey", SearchKey);

        return objDbManager.ExecuteDataTable("AdjustmentCodes_GetAllFilter");
    }


    public DataTable GetAdjustmentCode(long PracticeId)
    {
        DBManager objDbManager = new DBManager();
        objDbManager.AddParameter("PracticeId", PracticeId);
        return objDbManager.ExecuteDataTable("AdjustmentCodesMapping_GetAdjustmentCode");
    }

    public DataTable GetAllAdjustmentCode(long PracticeId)
    {
        DBManager objDbManager = new DBManager();
        objDbManager.AddParameter("PracticeId", PracticeId);
        return objDbManager.ExecuteDataTable("AllAdjustmentCodesMapping_GetAdjustmentCode");
    }
}