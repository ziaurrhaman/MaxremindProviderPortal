using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for NDCDB
/// </summary>
public class NDCDB
{
	public NDCDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable SearchDrug(string SearchValue)
    {
        try
        {
            DBManager objDBManager = new DBManager();

            objDBManager.AddParameter("SearchValue", SearchValue);

            return objDBManager.ExecuteDataTable("NDC_SearchDrug");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}