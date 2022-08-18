using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
/// <summary>
/// Summary description for CompanyAccountingSubGroupsDB
/// </summary>
public class CompanyAccountingSubGroupsDB
{
	public CompanyAccountingSubGroupsDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public Int64 Add(CompanyAccountingSubGroups objCompanyAccountingSubGroups)
    {

        DBManager objDBManager = new DBManager();


        try
        {
            objDBManager.AddParameter("CompanyAccountingSubGroupsId", objCompanyAccountingSubGroups.CompanyAccountingSubGroupsId, SqlDbType.BigInt, 8, ParameterDirection.Output);

            objDBManager.AddParameter("CompanyAccountingGroupsId", objCompanyAccountingSubGroups.CompanyAccountingGroupsId, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("Name", objCompanyAccountingSubGroups.Name, SqlDbType.VarChar, 50);
            objDBManager.AddParameter("CodeFrom", objCompanyAccountingSubGroups.CodeFrom, SqlDbType.Int, 4);
            objDBManager.AddParameter("CodeTo", objCompanyAccountingSubGroups.CodeTo, SqlDbType.Int, 4);
            objDBManager.AddParameter("Status", objCompanyAccountingSubGroups.Status, SqlDbType.VarChar, 15);
            objDBManager.AddParameter("Description", objCompanyAccountingSubGroups.Description, SqlDbType.VarChar, 250);
            objDBManager.AddParameter("PracticeId", objCompanyAccountingSubGroups.PracticeId, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("CreatedById", objCompanyAccountingSubGroups.CreatedById, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("CreatedDate", objCompanyAccountingSubGroups.CreatedDate, SqlDbType.DateTime, 8);
            objDBManager.AddParameter("Deleted", objCompanyAccountingSubGroups.Deleted, SqlDbType.Bit, 1);

            objDBManager.ExecuteNonQuery("CompanyAccountingSubGroups_Add");

            objCompanyAccountingSubGroups.CompanyAccountingSubGroupsId = Convert.ToInt64(objDBManager.Parameters[0].Value);

        }
        catch (Exception ex)
        {

            throw ex;

        }

        return objCompanyAccountingSubGroups.CompanyAccountingSubGroupsId;

    }

    public int Update(CompanyAccountingSubGroups objCompanyAccountingSubGroups)
    {

        DBManager objDBManager = new DBManager();
        int ReturnValue = 0;

        try
        {

            objDBManager.AddParameter("CompanyAccountingSubGroupsId", objCompanyAccountingSubGroups.CompanyAccountingSubGroupsId, SqlDbType.Int, 4);

            objDBManager.AddParameter("CompanyAccountingGroupsId", objCompanyAccountingSubGroups.CompanyAccountingGroupsId, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("Name", objCompanyAccountingSubGroups.Name, SqlDbType.VarChar, 50);
            objDBManager.AddParameter("CodeFrom", objCompanyAccountingSubGroups.CodeFrom, SqlDbType.Int, 4);
            objDBManager.AddParameter("CodeTo", objCompanyAccountingSubGroups.CodeTo, SqlDbType.Int, 4);
            objDBManager.AddParameter("Status", objCompanyAccountingSubGroups.Status, SqlDbType.VarChar, 15);
            objDBManager.AddParameter("Description", objCompanyAccountingSubGroups.Description, SqlDbType.VarChar, 250);
            objDBManager.AddParameter("PracticeId", objCompanyAccountingSubGroups.PracticeId, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("ModifiedById", objCompanyAccountingSubGroups.ModifiedById, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("ModifiedDate", objCompanyAccountingSubGroups.ModifiedDate, SqlDbType.DateTime, 8);
            objDBManager.AddParameter("Deleted", objCompanyAccountingSubGroups.Deleted, SqlDbType.Bit, 1);

            ReturnValue = objDBManager.ExecuteNonQuery("CompanyAccountingSubGroups_Update");


        }
        catch (Exception ex)
        {
            throw ex;

        }

        return ReturnValue;

    }
   

}