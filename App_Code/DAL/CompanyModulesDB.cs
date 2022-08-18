using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
/// <summary>
/// Summary description for CompanyModulesDB
/// </summary>
public class CompanyModulesDB
{
	public CompanyModulesDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public Int64 Add(CompanyModules objCompanyModules)
    {

        DBManager objDBManager = new DBManager();


        try
        {
            objDBManager.AddParameter("CompanyModulesId", objCompanyModules.CompanyModulesId, SqlDbType.BigInt, 8, ParameterDirection.Output);

            objDBManager.AddParameter("EMR",objCompanyModules.EMR, SqlDbType.Bit, 1);
            objDBManager.AddParameter("Accounting",objCompanyModules.Accounting);
            objDBManager.AddParameter("PracticeId", objCompanyModules.PracticeId);
            objDBManager.AddParameter("CreatedById",objCompanyModules.CreatedById);
            objDBManager.AddParameter("CreatedDate",objCompanyModules.CreatedDate);
            objDBManager.AddParameter("Deleted",objCompanyModules.Deleted, SqlDbType.Bit, 1);

            objDBManager.ExecuteNonQuery("CompanyModules_Add");

            objCompanyModules.CompanyModulesId = Convert.ToInt64(objDBManager.Parameters[0].Value);

        }
        catch (Exception ex)
        {

            throw ex;

        }

        return objCompanyModules.CompanyModulesId;

    }

    public int Update(CompanyModules objCompanyModules)
    {

        DBManager objDBManager = new DBManager();
        int ReturnValue = 0;

        try
        {

            objDBManager.AddParameter("CompanyModulesId", objCompanyModules.CompanyModulesId, SqlDbType.BigInt, 8);

            objDBManager.AddParameter("EMR",objCompanyModules.EMR, SqlDbType.Bit, 1);
            objDBManager.AddParameter("Accounting",objCompanyModules.Accounting, SqlDbType.Bit, 1);
            objDBManager.AddParameter("PracticeId", objCompanyModules.PracticeId);
            objDBManager.AddParameter("ModifiedById",objCompanyModules.ModifiedById, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("ModifiedDate",objCompanyModules.ModifiedDate, SqlDbType.DateTime, 8);
            objDBManager.AddParameter("Deleted",objCompanyModules.Deleted, SqlDbType.Bit, 1);

            ReturnValue = objDBManager.ExecuteNonQuery("CompanyModules_Update");


        }
        catch (Exception ex)
        {
            throw ex;

        }

        return ReturnValue;

    }

    public DataTable GetByCompanyId(long PracticeId)
    {
        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("PracticeId", PracticeId);
        return objDBManager.ExecuteDataTable("CompanyModules_GetByCompanyId");
    }
}