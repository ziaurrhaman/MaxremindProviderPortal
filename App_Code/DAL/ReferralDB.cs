using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
/// <summary>
/// Summary description for ReferralDB
/// </summary>
public class ReferralDB
{
	public ReferralDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public long Add(Referral objReferral)
    {

        DBManager objDBManager = new DBManager();


        try
        {
            objDBManager.AddParameter("ReferralId", objReferral.ReferralId, SqlDbType.Int, 4, ParameterDirection.Output);

            objDBManager.AddParameter("FirstName", objReferral.FirstName,  SqlDbType.VarChar, 25);
            objDBManager.AddParameter("MiddleName", objReferral.MiddleName,  SqlDbType.VarChar, 25);
            objDBManager.AddParameter("LastName", objReferral.LastName,  SqlDbType.VarChar, 25);
            objDBManager.AddParameter("Phone", objReferral.Phone,  SqlDbType.VarChar, 25);
            objDBManager.AddParameter("Cell", objReferral.Cell,  SqlDbType.VarChar, 25);
            objDBManager.AddParameter("Email", objReferral.Email,  SqlDbType.VarChar, 50);
            objDBManager.AddParameter("City", objReferral.City,  SqlDbType.VarChar, 25);
            objDBManager.AddParameter("State", objReferral.State,  SqlDbType.VarChar, 2);
            objDBManager.AddParameter("Zip", objReferral.Zip,  SqlDbType.VarChar, 16);
            objDBManager.AddParameter("TaxId", objReferral.TaxId,  SqlDbType.VarChar, 16);
            objDBManager.AddParameter("NPI", objReferral.NPI,  SqlDbType.VarChar, 25);
            objDBManager.AddParameter("ReferralType", objReferral.ReferralType,  SqlDbType.Bit, 1);
            objDBManager.AddParameter("CreatedById", objReferral.CreatedById,  SqlDbType.Int, 4);
            objDBManager.AddParameter("CreatedDate", objReferral.CreatedDate,  SqlDbType.DateTime, 8);
            objDBManager.AddParameter("ModifiedId", objReferral.ModifiedId,  SqlDbType.Int, 4);
            objDBManager.AddParameter("ModifiedDate", objReferral.ModifiedDate,  SqlDbType.DateTime, 8);
            objDBManager.AddParameter("InActive", objReferral.InActive,  SqlDbType.Bit, 1);
            objDBManager.AddParameter("Deleted", objReferral.Deleted,  SqlDbType.Bit, 1);

            objDBManager.ExecuteNonQuery("Referral_Add");

            objReferral.ReferralId =  (long) objDBManager.Parameters[0].Value;

        }
        catch (Exception ex)
        {

            throw ex;

        }

        return objReferral.ReferralId;

    }

    public int Update(Referral objReferral)
    {

        DBManager objDBManager = new DBManager();
        int ReturnValue = 0;

        try
        {

            objDBManager.AddParameter("ReferralId", objReferral.ReferralId, SqlDbType.Int, 4);

            objDBManager.AddParameter("FirstName", objReferral.FirstName,  SqlDbType.VarChar, 25);
            objDBManager.AddParameter("MiddleName", objReferral.MiddleName,  SqlDbType.VarChar, 25);
            objDBManager.AddParameter("LastName", objReferral.LastName,  SqlDbType.VarChar, 25);
            objDBManager.AddParameter("Phone", objReferral.Phone,  SqlDbType.VarChar, 25);
            objDBManager.AddParameter("Cell", objReferral.Cell,  SqlDbType.VarChar, 25);
            objDBManager.AddParameter("Email", objReferral.Email,  SqlDbType.VarChar, 50);
            objDBManager.AddParameter("City", objReferral.City,  SqlDbType.VarChar, 25);
            objDBManager.AddParameter("State", objReferral.State,  SqlDbType.VarChar, 2);
            objDBManager.AddParameter("Zip", objReferral.Zip,  SqlDbType.VarChar, 16);
            objDBManager.AddParameter("TaxId", objReferral.TaxId,  SqlDbType.VarChar, 16);
            objDBManager.AddParameter("NPI", objReferral.NPI,  SqlDbType.VarChar, 25);
            objDBManager.AddParameter("ReferralType", objReferral.ReferralType,  SqlDbType.Bit, 1);
            objDBManager.AddParameter("CreatedById", objReferral.CreatedById,  SqlDbType.Int, 4);
            objDBManager.AddParameter("CreatedDate", objReferral.CreatedDate,  SqlDbType.DateTime, 8);
            objDBManager.AddParameter("ModifiedId", objReferral.ModifiedId,  SqlDbType.Int, 4);
            objDBManager.AddParameter("ModifiedDate", objReferral.ModifiedDate,  SqlDbType.DateTime, 8);
            objDBManager.AddParameter("InActive", objReferral.InActive,  SqlDbType.Bit, 1);
            objDBManager.AddParameter("Deleted", objReferral.Deleted,  SqlDbType.Bit, 1);

            ReturnValue = objDBManager.ExecuteNonQuery("Referral_Update");


        }
        catch (Exception ex)
        {
            throw ex;

        }

        return ReturnValue;

    }

    public DataTable GetAllExternalReferral()
    {
        DBManager ObjDBManager = new DBManager();
        return ObjDBManager.ExecuteDataTable("Referral_GetAllExternal");
    }

    public DataTable GetAllInternalReferral()
    {
        DBManager ObjDBManager = new DBManager();
        return ObjDBManager.ExecuteDataTable("Referral_GetAllInternal"); 

    }
}