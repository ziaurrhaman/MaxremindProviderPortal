using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for ServiceProviderSalaryDB
/// </summary>
public class ServiceProviderSalaryDB
{
	public ServiceProviderSalaryDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public long Add(ServiceProviderSalary objServiceProviderSalary, SqlTransaction objSqlTransaction = null)
    {
        DBManager objDBManager = new DBManager(objSqlTransaction);

        try
        {
            objDBManager.AddParameter("ServiceProviderSalaryId", objServiceProviderSalary.ServiceProviderSalaryId, SqlDbType.BigInt, 8, ParameterDirection.Output);

            objDBManager.AddParameter("ServiceProviderId", objServiceProviderSalary.ServiceProviderId);
            objDBManager.AddParameter("Salary", objServiceProviderSalary.Salary);
            objDBManager.AddParameter("SalaryType", objServiceProviderSalary.SalaryType);
            objDBManager.AddParameter("Commission", objServiceProviderSalary.Commission);
            objDBManager.AddParameter("CommissionType", objServiceProviderSalary.CommissionType);
            objDBManager.AddParameter("CreatedById", objServiceProviderSalary.CreatedById);
            objDBManager.AddParameter("CreatedDate", objServiceProviderSalary.CreatedDate);

            objDBManager.ExecuteNonQuery("ServiceProviderSalary_Add");

            objServiceProviderSalary.ServiceProviderSalaryId = long.Parse(objDBManager.Parameters[0].Value.ToString());
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return objServiceProviderSalary.ServiceProviderSalaryId;
    }

    public int Update(ServiceProviderSalary objServiceProviderSalary, SqlTransaction objSqlTransaction = null)
    {

        DBManager objDBManager = new DBManager(objSqlTransaction);
        int ReturnValue = 0;

        try
        {
            objDBManager.AddParameter("ServiceProviderSalaryId", objServiceProviderSalary.ServiceProviderSalaryId);
            objDBManager.AddParameter("Salary", objServiceProviderSalary.Salary);
            objDBManager.AddParameter("SalaryType", objServiceProviderSalary.SalaryType);
            objDBManager.AddParameter("Commission", objServiceProviderSalary.Commission);
            objDBManager.AddParameter("CommissionType", objServiceProviderSalary.CommissionType);
            objDBManager.AddParameter("ModifiedById", objServiceProviderSalary.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objServiceProviderSalary.ModifiedDate);
            ReturnValue = objDBManager.ExecuteNonQuery("ServiceProviderSalary_Update");

        }
        catch (Exception ex)
        {
            throw ex;
        }

        return ReturnValue;
    }

    public DataTable GetByServiceProviderId(long ServiceProviderId, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);
            objDBManager.AddParameter("ServiceProviderId", ServiceProviderId);

            return objDBManager.ExecuteDataTable("ServiceProviderSalary_GetByServiceProviderId");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}