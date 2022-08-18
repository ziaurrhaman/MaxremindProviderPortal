using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
/// <summary>
/// Summary description for CompanyDB
/// </summary>
public class CompanyDB
{
	public CompanyDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public Int64 Add(Company objCompany)
    {

        DBManager objDBManager = new DBManager();


        try
        {
            objDBManager.AddParameter("CompanyId", objCompany.CompanyId, SqlDbType.BigInt, 8, ParameterDirection.Output);

            objDBManager.AddParameter("CompanyName", objCompany.CompanyName, SqlDbType.VarChar, 150);
            objDBManager.AddParameter("Address", objCompany.Address, SqlDbType.VarChar, 100);
            objDBManager.AddParameter("City", objCompany.City, SqlDbType.VarChar, 50);
            objDBManager.AddParameter("State", objCompany.State, SqlDbType.Char, 2);
            objDBManager.AddParameter("Zip", objCompany.Zip, SqlDbType.VarChar, 10);
            objDBManager.AddParameter("NPI", objCompany.NPI, SqlDbType.Int, 4);
            objDBManager.AddParameter("PhoneNumber1", objCompany.PhoneNumber1, SqlDbType.VarChar, 15);
            objDBManager.AddParameter("PhoneNumber2", objCompany.PhoneNumber2, SqlDbType.VarChar, 15);
            objDBManager.AddParameter("PhoneNumber3", objCompany.PhoneNumber3, SqlDbType.VarChar, 15);
            objDBManager.AddParameter("EmailAddress1", objCompany.EmailAddress1, SqlDbType.VarChar, 150);
            objDBManager.AddParameter("EmailAddress2", objCompany.EmailAddress2, SqlDbType.VarChar, 150);
            objDBManager.AddParameter("FaxNumber", objCompany.FaxNumber, SqlDbType.VarChar, 15);
            objDBManager.AddParameter("DEANumber", objCompany.DEANumber, SqlDbType.VarChar, 20);
            objDBManager.AddParameter("StateRXId", objCompany.StateRXId, SqlDbType.VarChar, 20);
            objDBManager.AddParameter("TaxID", objCompany.TaxID, SqlDbType.Int, 4);
            objDBManager.AddParameter("FeeSchedule", objCompany.FeeSchedule, SqlDbType.VarChar, 15);
            objDBManager.AddParameter("MedicaidNumber", objCompany.MedicaidNumber, SqlDbType.VarChar, 15);
            objDBManager.AddParameter("MedicareNumber", objCompany.MedicareNumber, SqlDbType.VarChar, 15);
            objDBManager.AddParameter("StateLicense", objCompany.StateLicense, SqlDbType.VarChar, 20);
            objDBManager.AddParameter("ContactPersonName", objCompany.ContactPersonName, SqlDbType.VarChar, 150);
            objDBManager.AddParameter("CreatedById", objCompany.CreatedById, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("CreatedDate", objCompany.CreatedDate, SqlDbType.DateTime, 8);
            objDBManager.AddParameter("Deleted", objCompany.Deleted, SqlDbType.Bit, 1);

            objDBManager.ExecuteNonQuery("Company_Add");

            objCompany.CompanyId = Convert.ToInt64(objDBManager.Parameters[0].Value);

        }
        catch (Exception ex)
        {

            throw ex;

        }

        return objCompany.CompanyId;

    }

    public int Update(Company objCompany)
    {

        DBManager objDBManager = new DBManager();
        int ReturnValue = 0;

        try
        {

            objDBManager.AddParameter("CompanyId", objCompany.CompanyId, SqlDbType.BigInt, 8);

            objDBManager.AddParameter("CompanyName", objCompany.CompanyName, SqlDbType.VarChar, 150);
            objDBManager.AddParameter("Address", objCompany.Address, SqlDbType.VarChar, 100);
            objDBManager.AddParameter("City", objCompany.City, SqlDbType.VarChar, 50);
            objDBManager.AddParameter("State", objCompany.State, SqlDbType.Char, 2);
            objDBManager.AddParameter("Zip", objCompany.Zip, SqlDbType.VarChar, 10);
            objDBManager.AddParameter("NPI", objCompany.NPI, SqlDbType.Int, 4);
            objDBManager.AddParameter("PhoneNumber1", objCompany.PhoneNumber1, SqlDbType.VarChar, 15);
            objDBManager.AddParameter("PhoneNumber2", objCompany.PhoneNumber2, SqlDbType.VarChar, 15);
            objDBManager.AddParameter("PhoneNumber3", objCompany.PhoneNumber3, SqlDbType.VarChar, 15);
            objDBManager.AddParameter("EmailAddress1", objCompany.EmailAddress1, SqlDbType.VarChar, 150);
            objDBManager.AddParameter("EmailAddress2", objCompany.EmailAddress2, SqlDbType.VarChar, 150);
            objDBManager.AddParameter("FaxNumber", objCompany.FaxNumber, SqlDbType.VarChar, 15);
            objDBManager.AddParameter("DEANumber", objCompany.DEANumber, SqlDbType.VarChar, 20);
            objDBManager.AddParameter("StateRXId", objCompany.StateRXId, SqlDbType.VarChar, 20);
            objDBManager.AddParameter("TaxID", objCompany.TaxID, SqlDbType.Int, 4);
            objDBManager.AddParameter("FeeSchedule", objCompany.FeeSchedule, SqlDbType.VarChar, 15);
            objDBManager.AddParameter("MedicaidNumber", objCompany.MedicaidNumber, SqlDbType.VarChar, 15);
            objDBManager.AddParameter("MedicareNumber", objCompany.MedicareNumber, SqlDbType.VarChar, 15);
            objDBManager.AddParameter("StateLicense", objCompany.StateLicense, SqlDbType.VarChar, 20);
            objDBManager.AddParameter("ContactPersonName", objCompany.ContactPersonName, SqlDbType.VarChar, 150);
            objDBManager.AddParameter("ModifiedById", objCompany.ModifiedById, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("ModifiedDate", objCompany.ModifiedDate, SqlDbType.DateTime, 8);
            objDBManager.AddParameter("Deleted", objCompany.Deleted, SqlDbType.Bit, 1);

            ReturnValue = objDBManager.ExecuteNonQuery("Company_Update");


        }
        catch (Exception ex)
        {
            throw ex;

        }

        return ReturnValue;

    }

 

}