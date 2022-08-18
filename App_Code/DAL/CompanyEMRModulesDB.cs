using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
/// <summary>
/// Summary description for CompanyEMRModulesDB
/// </summary>
public class CompanyEMRModulesDB
{
	public CompanyEMRModulesDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public Int64 Add(CompanyEMRModules objCompanyEMRModules)
    {

        DBManager objDBManager = new DBManager();


        try
        {
            objDBManager.AddParameter("CompanyEMRModulesId", objCompanyEMRModules.CompanyEMRModulesId, SqlDbType.BigInt, 8, ParameterDirection.Output);

            objDBManager.AddParameter("CompanyModulesId",objCompanyEMRModules.CompanyModulesId, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("Scheduler",objCompanyEMRModules.Scheduler, SqlDbType.VarChar, 25);
            objDBManager.AddParameter("PatientManager",objCompanyEMRModules.PatientManager, SqlDbType.VarChar, 25);
            objDBManager.AddParameter("BillingManager",objCompanyEMRModules.BillingManager, SqlDbType.VarChar, 25);
            objDBManager.AddParameter("Message",objCompanyEMRModules.Message, SqlDbType.VarChar, 25);
            objDBManager.AddParameter("Settings",objCompanyEMRModules.Settings, SqlDbType.VarChar, 25);
            objDBManager.AddParameter("TriageManager",objCompanyEMRModules.TriageManager, SqlDbType.VarChar, 25);
            objDBManager.AddParameter("CCM",objCompanyEMRModules.CCM, SqlDbType.VarChar, 25);
            objDBManager.AddParameter("LabManager", objCompanyEMRModules.LabManager);
            objDBManager.AddParameter("CreatedById",objCompanyEMRModules.CreatedById, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("CreatedDate",objCompanyEMRModules.CreatedDate, SqlDbType.DateTime, 8);
            objDBManager.AddParameter("Deleted",objCompanyEMRModules.Deleted, SqlDbType.Bit, 1);

            objDBManager.ExecuteNonQuery("CompanyEMRModules_Add");

            objCompanyEMRModules.CompanyEMRModulesId = Convert.ToInt64(objDBManager.Parameters[0].Value);

        }
        catch (Exception ex)
        {

            throw ex;

        }

        return objCompanyEMRModules.CompanyEMRModulesId;

    }

    public int Update(CompanyEMRModules objCompanyEMRModules)
    {

        DBManager objDBManager = new DBManager();
        int ReturnValue = 0;

        try
        {

            objDBManager.AddParameter("CompanyEMRModulesId", objCompanyEMRModules.CompanyEMRModulesId, SqlDbType.BigInt, 8);

            objDBManager.AddParameter("CompanyModulesId",objCompanyEMRModules.CompanyModulesId, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("Scheduler",objCompanyEMRModules.Scheduler, SqlDbType.VarChar, 25);
            objDBManager.AddParameter("PatientManager",objCompanyEMRModules.PatientManager, SqlDbType.VarChar, 25);
            objDBManager.AddParameter("BillingManager",objCompanyEMRModules.BillingManager, SqlDbType.VarChar, 25);
            objDBManager.AddParameter("Message",objCompanyEMRModules.Message, SqlDbType.VarChar, 25);
            objDBManager.AddParameter("Settings",objCompanyEMRModules.Settings, SqlDbType.VarChar, 25);
            objDBManager.AddParameter("TriageManager",objCompanyEMRModules.TriageManager, SqlDbType.VarChar, 25);
            objDBManager.AddParameter("CCM",objCompanyEMRModules.CCM, SqlDbType.VarChar, 25);
            objDBManager.AddParameter("LabManager", objCompanyEMRModules.LabManager);
            objDBManager.AddParameter("ModifiedById",objCompanyEMRModules.ModifiedById, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("ModifiedDate",objCompanyEMRModules.ModifiedDate, SqlDbType.DateTime, 8);
            objDBManager.AddParameter("Deleted",objCompanyEMRModules.Deleted, SqlDbType.Bit, 1);

            ReturnValue = objDBManager.ExecuteNonQuery("CompanyEMRModules_Update");


        }
        catch (Exception ex)
        {
            throw ex;

        }

        return ReturnValue;

    }


    public DataTable GetByCompanyModulesId(long CompanyModulesId)
    {
        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("CompanyModulesId", CompanyModulesId);
        return objDBManager.ExecuteDataTable("CompanyEMRModules_GetByCompanyModulesId");
    }
    
}