using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for ServiceProviderManager
/// </summary>
public class ServiceProviderManager
{
	public ServiceProviderManager()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public long Add(ServiceProvider objServiceProvider, SqlTransaction objSqlTransaction = null)
    {

        ServiceProviderDB objServiceProviderDB = new ServiceProviderDB();

        return objServiceProviderDB.Add(objServiceProvider, objSqlTransaction);

    }

    public int Update(ServiceProvider objServiceProvider, SqlTransaction objSqlTransaction = null)
    {

        ServiceProviderDB objServiceProviderDB = new ServiceProviderDB();
        return objServiceProviderDB.Update(objServiceProvider, objSqlTransaction);

    }

    public DataTable GetProvidersByPractice(long PracticeId)
    {
        ServiceProviderDB objServiceProviderDB = new ServiceProviderDB();

        return objServiceProviderDB.GetProvidersByPractice(PracticeId);
    }
}