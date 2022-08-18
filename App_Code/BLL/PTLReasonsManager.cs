using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for PTLReasonsManager
/// </summary>
public class PTLReasonsManager
{
	public PTLReasonsManager()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    
    public DataSet TotalCounts(long PracticeId)
    {
        PTLReasonsDB objPTLReasonsDB = new PTLReasonsDB();
        
        return objPTLReasonsDB.TotalCounts(PracticeId);
    }
}