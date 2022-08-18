using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for AgenciesDB
/// </summary>
public class PracticesDB
{
    DBManager DBManagerInstance = new DBManager();
    public PracticesDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    
    public long Add(Practices objPractices)
    {

        DBManager objDBManager = new DBManager();


        try
        {
            objDBManager.AddParameter("PracticeId", objPractices.PracticeId, SqlDbType.BigInt, 8, ParameterDirection.Output);

            objDBManager.AddParameter("PracticeName", objPractices.PracticeName);
            objDBManager.AddParameter("UPIN", objPractices.UPIN);
            objDBManager.AddParameter("PracticeType", objPractices.PracticeType);
            objDBManager.AddParameter("Address", objPractices.Address);
            objDBManager.AddParameter("City", objPractices.City);
            objDBManager.AddParameter("State", objPractices.State);
            objDBManager.AddParameter("Zip", objPractices.Zip);
            objDBManager.AddParameter("PracticeExt", objPractices.PracticeExt);
            objDBManager.AddParameter("NPI", objPractices.NPI);
            objDBManager.AddParameter("PhoneNumber1", objPractices.PhoneNumber1);
            objDBManager.AddParameter("PhoneNumber2", objPractices.PhoneNumber2);
            objDBManager.AddParameter("PhoneNumber3", objPractices.PhoneNumber3);
            objDBManager.AddParameter("EmailAddress1", objPractices.EmailAddress1);
            objDBManager.AddParameter("EmailAddress2", objPractices.EmailAddress2);
            objDBManager.AddParameter("FaxNumber", objPractices.FaxNumber);
            objDBManager.AddParameter("DEANumber", objPractices.DEANumber);
            objDBManager.AddParameter("StateRXId", objPractices.StateRXId);
            objDBManager.AddParameter("TaxID", objPractices.TaxID);
            objDBManager.AddParameter("TaxonomyCode", objPractices.TaxonomyCode);
            objDBManager.AddParameter("ContractType", objPractices.ContractType);
            objDBManager.AddParameter("FeeSchedule", objPractices.FeeSchedule);
            objDBManager.AddParameter("MedicaidNumber", objPractices.MedicaidNumber);
            objDBManager.AddParameter("MedicareNumber", objPractices.MedicareNumber);
            objDBManager.AddParameter("StateLicense", objPractices.StateLicense);
            objDBManager.AddParameter("ContactPersonName", objPractices.ContactPersonName);
            objDBManager.AddParameter("ContactPersonPhone", objPractices.ContactPersonPhone);
            objDBManager.AddParameter("CreatedById", objPractices.CreatedById);
            objDBManager.AddParameter("CreatedDate", objPractices.CreatedDate);

            objDBManager.ExecuteNonQuery("Practices_Add");

            objPractices.PracticeId = Convert.ToInt64(objDBManager.Parameters[0].Value);

        }
        catch (Exception ex)
        {

            throw ex;

        }

        return objPractices.PracticeId;

    }
    
    public int Update(Practices objPractices)
    {
        DBManager objDBManager = new DBManager();
        int ReturnValue = 0;

        try
        {
            objDBManager.AddParameter("PracticeId", objPractices.PracticeId, SqlDbType.BigInt, 8);

            objDBManager.AddParameter("PracticeName", objPractices.PracticeName);
            objDBManager.AddParameter("UPIN", objPractices.UPIN);
            objDBManager.AddParameter("PracticeType", objPractices.PracticeType);
            objDBManager.AddParameter("Address", objPractices.Address);
            objDBManager.AddParameter("City", objPractices.City);
            objDBManager.AddParameter("State", objPractices.State);
            objDBManager.AddParameter("Zip", objPractices.Zip);
            objDBManager.AddParameter("PracticeExt", objPractices.PracticeExt);
            objDBManager.AddParameter("NPI", objPractices.NPI);
            objDBManager.AddParameter("PhoneNumber1", objPractices.PhoneNumber1);
            objDBManager.AddParameter("PhoneNumber2", objPractices.PhoneNumber2);
            objDBManager.AddParameter("PhoneNumber3", objPractices.PhoneNumber3);
            objDBManager.AddParameter("EmailAddress1", objPractices.EmailAddress1);
            objDBManager.AddParameter("EmailAddress2", objPractices.EmailAddress2);
            objDBManager.AddParameter("FaxNumber", objPractices.FaxNumber);
            objDBManager.AddParameter("DEANumber", objPractices.DEANumber);
            objDBManager.AddParameter("StateRXId", objPractices.StateRXId);
            objDBManager.AddParameter("TaxID", objPractices.TaxID);
            objDBManager.AddParameter("TaxonomyCode", objPractices.TaxonomyCode);
            objDBManager.AddParameter("ContractType", objPractices.ContractType);
            objDBManager.AddParameter("FeeSchedule", objPractices.FeeSchedule);
            objDBManager.AddParameter("MedicaidNumber", objPractices.MedicaidNumber);
            objDBManager.AddParameter("MedicareNumber", objPractices.MedicareNumber);
            objDBManager.AddParameter("StateLicense", objPractices.StateLicense);
            objDBManager.AddParameter("ContactPersonName", objPractices.ContactPersonName);
            objDBManager.AddParameter("ContactPersonPhone", objPractices.ContactPersonPhone);
            objDBManager.AddParameter("ModifiedById", objPractices.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objPractices.ModifiedDate);

            ReturnValue = objDBManager.ExecuteNonQuery("Practices_Update");
        }
        catch (Exception ex)
        {
            throw ex;

        }

        return ReturnValue;

    }
    
    public int Delete(Practices objPractices, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);
            objDBManager.AddParameter("PracticeId", objPractices.PracticeId);
            objDBManager.AddParameter("ModifiedById", objPractices.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objPractices.ModifiedDate);

            return objDBManager.ExecuteNonQuery("Practice_Delete");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    
    public DataSet GetAllFilter(int Rows, int PageNumber, string SortBy, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);
            objDBManager.AddParameter("Rows", Rows);
            objDBManager.AddParameter("PageNumber", PageNumber);
            objDBManager.AddParameter("SortBy", SortBy);

            return objDBManager.ExecuteDataSet("Practice_GetAllFilter");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    
    public DataTable GetPracticeDetails(long practiceId)
    {
        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("PracticeId", practiceId);
        return objDBManager.ExecuteDataTable("GetPracticeDetails");
    }

    public string GetPracticeAddress(long PracticeId)
    {
        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("@UserID", PracticeId);

        return objDBManager.ExecuteScalar("GetPracticeAddressInformation");
    }

    //Added By Syed Sajid Ali Date:10-09-2019
    public DataTable Practices_GetByPracticeId(long PracticeId)
    {
        DBManager objDbManager = new DBManager();
        objDbManager.AddParameter("@PracticeId", PracticeId);
        return objDbManager.ExecuteDataTable("Practices_GetByPracticeId");
    }

    public DataTable GetAllreadyExistPracticeUser(long PracticeId, string UserName)
    {
        DBManager objDbManager = new DBManager();

        objDbManager.AddParameter("@PracticeId", PracticeId);
        objDbManager.AddParameter("@UserName", UserName);
        return objDbManager.ExecuteDataTable("GetExistPracticeUser");

    }
    //End by Syed Sajid Ali

}