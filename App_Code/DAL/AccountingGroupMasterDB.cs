using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
/// <summary>
/// Summary description for AccountingGroupMasterDB
/// </summary>
public class AccountingGroupMasterDB
{
	public AccountingGroupMasterDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public Int64 Add(AccountingGroupMaster objAccountingGroupMaster)
    {

        DBManager objDBManager = new DBManager();


        try
        {
            objDBManager.AddParameter("AccountingGroupMasterId", objAccountingGroupMaster.AccountingGroupMasterId, SqlDbType.BigInt, 8, ParameterDirection.Output);

            objDBManager.AddParameter("CodeFrom",objAccountingGroupMaster.CodeFrom,  SqlDbType.Int, 4);
            objDBManager.AddParameter("CodeTo",objAccountingGroupMaster.CodeTo,  SqlDbType.Int, 4);
            objDBManager.AddParameter("GroupName",objAccountingGroupMaster.GroupName,  SqlDbType.VarChar, 50);
            objDBManager.AddParameter("Status",objAccountingGroupMaster.Status,  SqlDbType.VarChar, 15);
            objDBManager.AddParameter("Description",objAccountingGroupMaster.Description,  SqlDbType.VarChar, 250);
            objDBManager.AddParameter("CreatedById",objAccountingGroupMaster.CreatedById,  SqlDbType.BigInt, 8);
            objDBManager.AddParameter("CreatedDate",objAccountingGroupMaster.CreatedDate,  SqlDbType.DateTime, 8);
            objDBManager.AddParameter("Deleted",objAccountingGroupMaster.Deleted,  SqlDbType.Bit, 1);

            objDBManager.ExecuteNonQuery("AccountingGroupMaster_Add");

            objAccountingGroupMaster.AccountingGroupMasterId = Convert.ToInt64(objDBManager.Parameters[0].Value);

        }
        catch (Exception ex)
        {

            throw ex;

        }

        return objAccountingGroupMaster.AccountingGroupMasterId;

    }

    public int Update(AccountingGroupMaster objAccountingGroupMaster)
    {

        DBManager objDBManager = new DBManager();
        int ReturnValue = 0;

        try
        {

            objDBManager.AddParameter("AccountingGroupMasterId", objAccountingGroupMaster.AccountingGroupMasterId, SqlDbType.BigInt, 8);

            objDBManager.AddParameter("CodeFrom",objAccountingGroupMaster.CodeFrom,  SqlDbType.Int, 4);
            objDBManager.AddParameter("CodeTo",objAccountingGroupMaster.CodeTo,  SqlDbType.Int, 4);
            objDBManager.AddParameter("GroupName",objAccountingGroupMaster.GroupName,  SqlDbType.VarChar, 50);
            objDBManager.AddParameter("Status",objAccountingGroupMaster.Status,  SqlDbType.VarChar, 15);
            objDBManager.AddParameter("Description",objAccountingGroupMaster.Description,  SqlDbType.VarChar, 250);
            objDBManager.AddParameter("ModifiedById",objAccountingGroupMaster.ModifiedById,  SqlDbType.BigInt, 8);
            objDBManager.AddParameter("ModifiedDate",objAccountingGroupMaster.ModifiedDate,  SqlDbType.DateTime, 8);
            objDBManager.AddParameter("Deleted",objAccountingGroupMaster.Deleted,  SqlDbType.Bit, 1);

            ReturnValue = objDBManager.ExecuteNonQuery("AccountingGroupMaster_Update");


        }
        catch (Exception ex)
        {
            throw ex;

        }

        return ReturnValue;

    }

  

    public DataSet AccountingGroupMaster_GetAll()
    {
        DBManager objDbmanager = new DBManager();
        return objDbmanager.ExecuteDataSet("AccountingGroupMaster_GetAll");
    }

}