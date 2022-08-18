using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
/// <summary>
/// Summary description for AccountingSubGroupDB
/// </summary>
public class AccountingSubGroupDB
{
	public AccountingSubGroupDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public Int64 Add(AccountingSubGroupMaster objAccountingSubGroupMaster)
    {

        DBManager objDBManager = new DBManager();


        try
        {
            objDBManager.AddParameter("AccountingSubGroupMasterId", objAccountingSubGroupMaster.AccountingSubGroupMasterId, SqlDbType.BigInt, 8, ParameterDirection.Output);

            objDBManager.AddParameter("AccountingGroupMasterId",objAccountingSubGroupMaster.AccountingGroupMasterId,SqlDbType.BigInt, 8);
            objDBManager.AddParameter("CodeFrom",objAccountingSubGroupMaster.CodeFrom,SqlDbType.Int, 4);
            objDBManager.AddParameter("CodeTo",objAccountingSubGroupMaster.CodeTo,SqlDbType.Int, 4);
            objDBManager.AddParameter("SubGroupName",objAccountingSubGroupMaster.SubGroupName,SqlDbType.VarChar, 50);
            objDBManager.AddParameter("Status",objAccountingSubGroupMaster.Status,SqlDbType.VarChar, 15);
            objDBManager.AddParameter("Description",objAccountingSubGroupMaster.Description,SqlDbType.VarChar, 250);
            objDBManager.AddParameter("CreatedById",objAccountingSubGroupMaster.CreatedById,SqlDbType.BigInt, 8);
            objDBManager.AddParameter("CreatedDate",objAccountingSubGroupMaster.CreatedDate,SqlDbType.DateTime, 8);
            objDBManager.AddParameter("Deleted",objAccountingSubGroupMaster.Deleted,SqlDbType.Bit, 1);

            objDBManager.ExecuteNonQuery("AccountingSubGroupMaster_Add");

            objAccountingSubGroupMaster.AccountingSubGroupMasterId = Convert.ToInt64(objDBManager.Parameters[0].Value);

        }
        catch (Exception ex)
        {

            throw ex;

        }

        return objAccountingSubGroupMaster.AccountingSubGroupMasterId;

    }

    public int Update(AccountingSubGroupMaster objAccountingSubGroupMaster)
    {

        DBManager objDBManager = new DBManager();
        int ReturnValue = 0;

        try
        {

            objDBManager.AddParameter("AccountingSubGroupMasterId", objAccountingSubGroupMaster.AccountingSubGroupMasterId, SqlDbType.Int, 4);

            objDBManager.AddParameter("AccountingGroupMasterId",objAccountingSubGroupMaster.AccountingGroupMasterId,SqlDbType.BigInt, 8);
            objDBManager.AddParameter("CodeFrom",objAccountingSubGroupMaster.CodeFrom,SqlDbType.Int, 4);
            objDBManager.AddParameter("CodeTo",objAccountingSubGroupMaster.CodeTo,SqlDbType.Int, 4);
            objDBManager.AddParameter("SubGroupName",objAccountingSubGroupMaster.SubGroupName,SqlDbType.VarChar, 50);
            objDBManager.AddParameter("Status",objAccountingSubGroupMaster.Status,SqlDbType.VarChar, 15);
            objDBManager.AddParameter("Description",objAccountingSubGroupMaster.Description,SqlDbType.VarChar, 250);
            objDBManager.AddParameter("ModifiedById",objAccountingSubGroupMaster.ModifiedById,SqlDbType.BigInt, 8);
            objDBManager.AddParameter("ModifiedDate",objAccountingSubGroupMaster.ModifiedDate,SqlDbType.DateTime, 8);
            objDBManager.AddParameter("Deleted",objAccountingSubGroupMaster.Deleted,SqlDbType.Bit, 1);

            ReturnValue = objDBManager.ExecuteNonQuery("AccountingSubGroupMaster_Update");


        }
        catch (Exception ex)
        {
            throw ex;

        }

        return ReturnValue;

    }
}