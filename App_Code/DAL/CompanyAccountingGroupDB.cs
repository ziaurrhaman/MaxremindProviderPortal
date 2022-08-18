using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
/// <summary>
/// Summary description for CompanyAccountingGroupDB
/// </summary>
public class CompanyAccountingGroupDB
{
	public CompanyAccountingGroupDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public Int64 Add(CompanyAccountingGroups objCompanyAccountingGroups)
    {

        DBManager objDBManager = new DBManager();


        try
        {
            objDBManager.AddParameter("CompanyAccountingGroupsId", objCompanyAccountingGroups.CompanyAccountingGroupsId, SqlDbType.Int, 4, ParameterDirection.Output);

            objDBManager.AddParameter("CodeFrom",objCompanyAccountingGroups.CodeFrom,SqlDbType.BigInt, 8);
            objDBManager.AddParameter("CodeTo",objCompanyAccountingGroups.CodeTo,SqlDbType.Int, 4);
            objDBManager.AddParameter("Name",objCompanyAccountingGroups.Name,SqlDbType.VarChar, 50);
            objDBManager.AddParameter("Status",objCompanyAccountingGroups.Status,SqlDbType.VarChar, 15);
            objDBManager.AddParameter("Description",objCompanyAccountingGroups.Description,SqlDbType.VarChar, 250);
            objDBManager.AddParameter("PracticeId",objCompanyAccountingGroups.PracticeId,SqlDbType.BigInt, 8);
            objDBManager.AddParameter("CreatedById",objCompanyAccountingGroups.CreatedById,SqlDbType.BigInt, 8);
            objDBManager.AddParameter("CreatedDate",objCompanyAccountingGroups.CreatedDate,SqlDbType.DateTime, 8);
            objDBManager.AddParameter("Deleted",objCompanyAccountingGroups.Deleted,SqlDbType.Bit, 1);

            objDBManager.ExecuteNonQuery("CompanyAccountingGroups_Add");

            objCompanyAccountingGroups.CompanyAccountingGroupsId = Convert.ToInt64(objDBManager.Parameters[0].Value);

        }
        catch (Exception ex)
        {

            throw ex;

        }

        return objCompanyAccountingGroups.CompanyAccountingGroupsId;

    }

    public int Update(CompanyAccountingGroups objCompanyAccountingGroups)
    {

        DBManager objDBManager = new DBManager();
        int ReturnValue = 0;

        try
        {

            objDBManager.AddParameter("CompanyAccountingGroupsId", objCompanyAccountingGroups.CompanyAccountingGroupsId, SqlDbType.Int, 4);

            objDBManager.AddParameter("CodeFrom",objCompanyAccountingGroups.CodeFrom,SqlDbType.BigInt, 8);
            objDBManager.AddParameter("CodeTo",objCompanyAccountingGroups.CodeTo,SqlDbType.Int, 4);
            objDBManager.AddParameter("Name",objCompanyAccountingGroups.Name,SqlDbType.VarChar, 50);
            objDBManager.AddParameter("Status",objCompanyAccountingGroups.Status,SqlDbType.VarChar, 15);
            objDBManager.AddParameter("Description",objCompanyAccountingGroups.Description,SqlDbType.VarChar, 250);
            objDBManager.AddParameter("PracticeId",objCompanyAccountingGroups.PracticeId,SqlDbType.BigInt, 8);
            objDBManager.AddParameter("ModifiedById",objCompanyAccountingGroups.ModifiedById,SqlDbType.BigInt, 8);
            objDBManager.AddParameter("ModifiedDate",objCompanyAccountingGroups.ModifiedDate,SqlDbType.DateTime, 8);
            objDBManager.AddParameter("Deleted",objCompanyAccountingGroups.Deleted,SqlDbType.Bit, 1);

            ReturnValue = objDBManager.ExecuteNonQuery("CompanyAccountingGroups_Update");


        }
        catch (Exception ex)
        {
            throw ex;

        }

        return ReturnValue;

    }
}