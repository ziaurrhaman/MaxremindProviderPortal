using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;


public class FrontDeskDB
{
	public FrontDeskDB()
	{
		
	}
    public DataTable GetCountPatientClaim(long PracticeId)
    {
        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("PracticeId", PracticeId);

        return objDBManager.ExecuteDataTable("GetCountPatientClaim");
    }
}