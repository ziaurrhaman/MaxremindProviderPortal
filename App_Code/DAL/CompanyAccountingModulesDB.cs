using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
/// <summary>
/// Summary description for CompanyAccountingModulesDB
/// </summary>
public class CompanyAccountingModulesDB
{
	public CompanyAccountingModulesDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public Int64 Add(CompanyAccountingModules objCompanyAccountingModules)
    {

        DBManager objDBManager = new DBManager();


        try
        {
            objDBManager.AddParameter("CompanyAccountingModulesId", objCompanyAccountingModules.CompanyAccountingModulesId, SqlDbType.BigInt, 8, ParameterDirection.Output);

            objDBManager.AddParameter("CompanyModulesId",objCompanyAccountingModules.CompanyModulesId);
            objDBManager.AddParameter("Sales",objCompanyAccountingModules.Sales);
            objDBManager.AddParameter("Purchase",objCompanyAccountingModules.Purchase);
            objDBManager.AddParameter("ItemsAndInventory",objCompanyAccountingModules.ItemsAndInventory);
            objDBManager.AddParameter("Manufacturing",objCompanyAccountingModules.Manufacturing);
            objDBManager.AddParameter("Dimensions",objCompanyAccountingModules.Dimensions);
            objDBManager.AddParameter("BankingAndGeneralLedger",objCompanyAccountingModules.BankingAndGeneralLedger);
            objDBManager.AddParameter("Setup", objCompanyAccountingModules.Setup);
            objDBManager.AddParameter("CreatedById",objCompanyAccountingModules.CreatedById);
            objDBManager.AddParameter("CreatedDate",objCompanyAccountingModules.CreatedDate);
            objDBManager.AddParameter("Deleted",objCompanyAccountingModules.Deleted);

            objDBManager.ExecuteNonQuery("CompanyAccountingModules_Add");

            objCompanyAccountingModules.CompanyAccountingModulesId = Convert.ToInt64(objDBManager.Parameters[0].Value);

        }
        catch (Exception ex)
        {

            throw ex;

        }

        return objCompanyAccountingModules.CompanyAccountingModulesId;

    }

    public int Update(CompanyAccountingModules objCompanyAccountingModules)
    {

        DBManager objDBManager = new DBManager();
        int ReturnValue = 0;

        try
        {

            objDBManager.AddParameter("CompanyAccountingModulesId", objCompanyAccountingModules.CompanyAccountingModulesId, SqlDbType.BigInt, 8);

            objDBManager.AddParameter("CompanyModulesId",objCompanyAccountingModules.CompanyModulesId,SqlDbType.BigInt, 8);
            objDBManager.AddParameter("Sales",objCompanyAccountingModules.Sales);
            objDBManager.AddParameter("Purchase",objCompanyAccountingModules.Purchase);
            objDBManager.AddParameter("ItemsAndInventory",objCompanyAccountingModules.ItemsAndInventory);
            objDBManager.AddParameter("Manufacturing",objCompanyAccountingModules.Manufacturing);
            objDBManager.AddParameter("Dimensions",objCompanyAccountingModules.Dimensions);
            objDBManager.AddParameter("BankingAndGeneralLedger",objCompanyAccountingModules.BankingAndGeneralLedger);
            objDBManager.AddParameter("Setup", objCompanyAccountingModules.Setup);
            objDBManager.AddParameter("ModifiedById",objCompanyAccountingModules.ModifiedById);
            objDBManager.AddParameter("ModifiedDate",objCompanyAccountingModules.ModifiedDate);
            objDBManager.AddParameter("Deleted",objCompanyAccountingModules.Deleted);

            ReturnValue = objDBManager.ExecuteNonQuery("CompanyAccountingModules_Update");


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
        return objDBManager.ExecuteDataTable("CompanyAccountingModules_GetByCompanyModulesId");
    }
}