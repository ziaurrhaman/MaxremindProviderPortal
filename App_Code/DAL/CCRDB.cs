using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for CCR
/// </summary>
public class CCRDB
{
	public CCRDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    
    public DataSet GetData()
    {
        DBManager objDBManager = new DBManager();
        
        return objDBManager.ExecuteDataSet("CCR_GetData");
    }
}