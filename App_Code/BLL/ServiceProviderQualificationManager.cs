using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

/// <summary>
/// Summary description for ServiceProviderQualificationManager
/// </summary>
public class ServiceProviderQualificationManager
{
	public ServiceProviderQualificationManager()
	{
		//
		// TODO: Add constructor logic here
		//
	}


    public long Add(ServiceProviderQualification objServiceProviderQualification, SqlTransaction objSqlTransaction = null)
    {

        ServiceProviderQualificationDB objServiceProviderQualificationDB = new ServiceProviderQualificationDB();

        return objServiceProviderQualificationDB.Add(objServiceProviderQualification);

    }

    public void Update(ServiceProviderQualification objServiceProviderQualification, SqlTransaction objSqlTransaction = null)
    {

        ServiceProviderQualificationDB objServiceProviderQualificationDB = new ServiceProviderQualificationDB();
        objServiceProviderQualificationDB.Update(objServiceProviderQualification);

    }
}