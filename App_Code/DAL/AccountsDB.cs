using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
/// <summary>
/// Summary description for AccountsDB
/// </summary>
public class AccountsDB
{
	public AccountsDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public Int64  Add(Account objAccount)
    {

        DBManager objDBManager = new DBManager();


        try
        {
            objDBManager.AddParameter("AccountId", objAccount.AccountId, SqlDbType.Int, 4, ParameterDirection.Output);

            objDBManager.AddParameter("Name",objAccount.Name, SqlDbType.VarChar, 50);
            objDBManager.AddParameter("Code",objAccount.Code, SqlDbType.NChar, 10);
            objDBManager.AddParameter("GroupId",objAccount.GroupId, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("Status",objAccount.Status, SqlDbType.VarChar, 15);
            objDBManager.AddParameter("CreatedById",objAccount.CreatedById, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("CreatedDate",objAccount.CreatedDate, SqlDbType.DateTime, 8);
            objDBManager.AddParameter("Deleted",objAccount.Deleted, SqlDbType.Bit, 1);

            objDBManager.ExecuteNonQuery("Account_Add");

            objAccount.AccountId = Convert.ToInt64(objDBManager.Parameters[0].Value);

        }
        catch (Exception ex)
        {

            throw ex;

        }

        return objAccount.AccountId;

    }

    public int Update(Account objAccount)
    {

        DBManager objDBManager = new DBManager();
        int ReturnValue = 0;

        try
        {

            objDBManager.AddParameter("AccountId", objAccount.AccountId, SqlDbType.Int, 4);

            objDBManager.AddParameter("Name",objAccount.Name, SqlDbType.VarChar, 50);
            objDBManager.AddParameter("Code",objAccount.Code, SqlDbType.NChar, 10);
            objDBManager.AddParameter("GroupId",objAccount.GroupId, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("Status",objAccount.Status, SqlDbType.VarChar, 15);
            objDBManager.AddParameter("ModifiedByid",objAccount.ModifiedByid, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("ModifiedDate",objAccount.ModifiedDate, SqlDbType.DateTime, 8);
            objDBManager.AddParameter("Deleted",objAccount.Deleted, SqlDbType.Bit, 1);

            ReturnValue = objDBManager.ExecuteNonQuery("Account_Update");


        }
        catch (Exception ex)
        {
            throw ex;

        }

        return ReturnValue;

    }

}