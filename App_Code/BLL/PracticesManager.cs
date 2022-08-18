using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
/// <summary>
/// Summary description for AgenciesManager
/// </summary>
public class PracticesManager
{
    public PracticesManager()
	{
		//
		// TODO: Add constructor logic here
		//
	}


    public long Add(Practices objPractices)
    {

        PracticesDB objPracticesDb = new PracticesDB();

        return objPracticesDb.Add(objPractices);

    }

    public int Update(Practices objPractices)
    {

        PracticesDB objPracticesDb = new PracticesDB();

        return objPracticesDb.Update(objPractices);

    }

    //public DataTable GetPracticeDetails(Int64 PracticeId)
    //{
    //    PracticesDB objPracticesDb = new PracticesDB();
    //    return objPracticesDb.GetPracticeDetails(PracticeId);
    //}
    
}