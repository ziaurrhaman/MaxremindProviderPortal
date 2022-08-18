using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
/// <summary>
/// Summary description for ClaimAdjustmentReasonCodesDB
/// </summary>
public class ClaimAdjustmentReasonCodesDB
{
	public ClaimAdjustmentReasonCodesDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable ClaimAdjustmentReasonCode_GetBySearchCriteria(string Code, string Description)
    {
        DBManager objDbManager = new DBManager();
        if (!string.IsNullOrEmpty(Code))
        {
            objDbManager.AddParameter("Code",Code);
        }
        if (!string.IsNullOrEmpty(Description))
        {
            objDbManager.AddParameter("Description", Description);
        }
        return objDbManager.ExecuteDataTable("ClaimAdjustmentReasonCode_GetBySearchCriteria");
    }
}