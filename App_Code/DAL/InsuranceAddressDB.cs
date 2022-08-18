using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
/// <summary>
/// Summary description for InsuranceAddressDB
/// </summary>
public class InsuranceAddressDB
{
	public InsuranceAddressDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public long Add(InsuranceAddress objInsuranceAddress)
    {

        DBManager objDBManager = new DBManager();


        try
        {
            objDBManager.AddParameter("InsuranceAddressId", objInsuranceAddress.InsuranceAddressId, SqlDbType.BigInt, 8, ParameterDirection.Output);
            objDBManager.AddParameter("InsuranceId", objInsuranceAddress.InsuranceId, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("Department",objInsuranceAddress.Department, SqlDbType.VarChar, 30);
            objDBManager.AddParameter("Address",objInsuranceAddress.Address, SqlDbType.VarChar, 100);
            objDBManager.AddParameter("City",objInsuranceAddress.City, SqlDbType.VarChar, 30);
            objDBManager.AddParameter("State",objInsuranceAddress.State, SqlDbType.VarChar, 2);
            objDBManager.AddParameter("Zip",objInsuranceAddress.Zip, SqlDbType.VarChar, 16);
            objDBManager.AddParameter("ContactPerson",objInsuranceAddress.ContactPerson, SqlDbType.VarChar, 30);
            objDBManager.AddParameter("Email",objInsuranceAddress.Email, SqlDbType.VarChar, 50);
            objDBManager.AddParameter("Fax",objInsuranceAddress.Fax, SqlDbType.VarChar, 30);
            objDBManager.AddParameter("Phone1",objInsuranceAddress.Phone1, SqlDbType.VarChar, 25);
            objDBManager.AddParameter("Phone2",objInsuranceAddress.Phone2, SqlDbType.VarChar, 25);
            objDBManager.AddParameter("Phone3",objInsuranceAddress.Phone3, SqlDbType.VarChar, 25);
            objDBManager.AddParameter("CraetedById",objInsuranceAddress.CraetedById, SqlDbType.Int, 4);
            objDBManager.AddParameter("CreatedDate",objInsuranceAddress.CreatedDate, SqlDbType.DateTime, 8);
            objDBManager.AddParameter("InAcative",objInsuranceAddress.InAcative, SqlDbType.Bit, 1);
            objDBManager.AddParameter("Deleted",objInsuranceAddress.Deleted, SqlDbType.Bit, 1);

            objDBManager.ExecuteNonQuery("InsuranceAddress_Add");

            objInsuranceAddress.InsuranceAddressId = (long) objDBManager.Parameters[0].Value;

        }
        catch (Exception ex)
        {

            throw ex;

        }

        return objInsuranceAddress.InsuranceAddressId;

    }

    public int Update(InsuranceAddress objInsuranceAddress)
    {

        DBManager objDBManager = new DBManager();
        int ReturnValue = 0;

        try
        {

            objDBManager.AddParameter("InsuranceAddressId", objInsuranceAddress.InsuranceAddressId, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("InsuranceId", objInsuranceAddress.InsuranceId, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("Department",objInsuranceAddress.Department, SqlDbType.VarChar, 30);
            objDBManager.AddParameter("Address",objInsuranceAddress.Address, SqlDbType.VarChar, 100);
            objDBManager.AddParameter("City",objInsuranceAddress.City, SqlDbType.VarChar, 30);
            objDBManager.AddParameter("State",objInsuranceAddress.State, SqlDbType.VarChar, 2);
            objDBManager.AddParameter("Zip",objInsuranceAddress.Zip, SqlDbType.VarChar, 16);
            objDBManager.AddParameter("ContactPerson",objInsuranceAddress.ContactPerson, SqlDbType.VarChar, 30);
            objDBManager.AddParameter("Email",objInsuranceAddress.Email, SqlDbType.VarChar, 50);
            objDBManager.AddParameter("Fax",objInsuranceAddress.Fax, SqlDbType.VarChar, 30);
            objDBManager.AddParameter("Phone1",objInsuranceAddress.Phone1, SqlDbType.VarChar, 25);
            objDBManager.AddParameter("Phone2",objInsuranceAddress.Phone2, SqlDbType.VarChar, 25);
            objDBManager.AddParameter("Phone3",objInsuranceAddress.Phone3, SqlDbType.VarChar, 25);
            objDBManager.AddParameter("ModifiedById",objInsuranceAddress.ModifiedById, SqlDbType.Int, 4);
            objDBManager.AddParameter("ModifiedDate",objInsuranceAddress.ModifiedDate, SqlDbType.DateTime, 8);
            objDBManager.AddParameter("InAcative",objInsuranceAddress.InAcative, SqlDbType.Bit, 1);
            objDBManager.AddParameter("Deleted",objInsuranceAddress.Deleted, SqlDbType.Bit, 1);

            ReturnValue = objDBManager.ExecuteNonQuery("InsuranceAddress_Update");


        }
        catch (Exception ex)
        {
            throw ex;

        }

        return ReturnValue;

    }
}