using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for FinancialGuarantorDB
/// </summary>
public class FinancialGuarantorDB
{
	public FinancialGuarantorDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public int Add(FinancialGuarantor objFinancialGuarantor)
    {

        DBManager objDBManager = new DBManager();


        try
        {
            objDBManager.AddParameter("FinancialGuarantorId", objFinancialGuarantor.FinancialGuarantorId, SqlDbType.Int, 4, ParameterDirection.Output);
            objDBManager.AddParameter("PracticeId", objFinancialGuarantor.PracticeId);
            objDBManager.AddParameter("FirstName", objFinancialGuarantor.FirstName, SqlDbType.VarChar, 25);
            objDBManager.AddParameter("LastName", objFinancialGuarantor.LastName, SqlDbType.VarChar, 25);
            objDBManager.AddParameter("MiddleName", objFinancialGuarantor.MiddleName, SqlDbType.VarChar, 25);
            objDBManager.AddParameter("DateOfBirth", objFinancialGuarantor.DateOfBirth, SqlDbType.DateTime, 3);
            objDBManager.AddParameter("SSN", objFinancialGuarantor.SSN, SqlDbType.VarChar, 15);
            objDBManager.AddParameter("Gender", objFinancialGuarantor.Gender, SqlDbType.VarChar, 8);
            objDBManager.AddParameter("MaritalStatus", objFinancialGuarantor.MaritalStatus, SqlDbType.VarChar, 15);
            objDBManager.AddParameter("Address", objFinancialGuarantor.Address, SqlDbType.VarChar, 100);
            objDBManager.AddParameter("Zip", objFinancialGuarantor.Zip, SqlDbType.VarChar, 15);
            objDBManager.AddParameter("City", objFinancialGuarantor.City, SqlDbType.VarChar, 25);
            objDBManager.AddParameter("State", objFinancialGuarantor.State, SqlDbType.Char, 2);
            objDBManager.AddParameter("HomePhone", objFinancialGuarantor.HomePhone, SqlDbType.VarChar, 16);
            objDBManager.AddParameter("Cell", objFinancialGuarantor.Cell, SqlDbType.VarChar, 16);
            objDBManager.AddParameter("WorkPhone", objFinancialGuarantor.WorkPhone, SqlDbType.VarChar, 16);
            objDBManager.AddParameter("Ext", objFinancialGuarantor.Ext, SqlDbType.VarChar, 5);
            objDBManager.AddParameter("Email", objFinancialGuarantor.Email, SqlDbType.VarChar, 50);
            objDBManager.AddParameter("CreatedById", objFinancialGuarantor.CreatedById, SqlDbType.Int, 4);
            objDBManager.AddParameter("CreatedDate", objFinancialGuarantor.CreatedDate, SqlDbType.DateTime, 8);

            objDBManager.ExecuteNonQuery("FinancialGuarantor_Add");

            objFinancialGuarantor.FinancialGuarantorId = int.Parse(objDBManager.Parameters[0].Value.ToString());

        }
        catch (Exception ex)
        {

            throw ex;

        }

        return objFinancialGuarantor.FinancialGuarantorId;

    }

    public int Update(FinancialGuarantor objFinancialGuarantor)
    {

        DBManager objDBManager = new DBManager();
        int ReturnValue = 0;

        try
        {

            objDBManager.AddParameter("FinancialGuarantorId", objFinancialGuarantor.FinancialGuarantorId, SqlDbType.Int, 4);

            objDBManager.AddParameter("FirstName", objFinancialGuarantor.FirstName, SqlDbType.VarChar, 25);
            objDBManager.AddParameter("LastName", objFinancialGuarantor.LastName, SqlDbType.VarChar, 25);
            objDBManager.AddParameter("MiddleName", objFinancialGuarantor.MiddleName, SqlDbType.VarChar, 25);
            objDBManager.AddParameter("DateOfBirth", objFinancialGuarantor.DateOfBirth, SqlDbType.DateTime, 3);
            objDBManager.AddParameter("SSN", objFinancialGuarantor.SSN, SqlDbType.VarChar, 15);
            objDBManager.AddParameter("Gender", objFinancialGuarantor.Gender, SqlDbType.VarChar, 8);
            objDBManager.AddParameter("MaritalStatus", objFinancialGuarantor.MaritalStatus, SqlDbType.VarChar, 15);
            objDBManager.AddParameter("Address", objFinancialGuarantor.Address, SqlDbType.VarChar, 100);
            objDBManager.AddParameter("Zip", objFinancialGuarantor.Zip, SqlDbType.VarChar, 15);
            objDBManager.AddParameter("City", objFinancialGuarantor.City, SqlDbType.VarChar, 25);
            objDBManager.AddParameter("State", objFinancialGuarantor.State, SqlDbType.Char, 2);
            objDBManager.AddParameter("HomePhone", objFinancialGuarantor.HomePhone, SqlDbType.VarChar, 16);
            objDBManager.AddParameter("Cell", objFinancialGuarantor.Cell, SqlDbType.VarChar, 16);
            objDBManager.AddParameter("WorkPhone", objFinancialGuarantor.WorkPhone, SqlDbType.VarChar, 16);
            objDBManager.AddParameter("Ext", objFinancialGuarantor.Ext, SqlDbType.VarChar, 5);
            objDBManager.AddParameter("Email", objFinancialGuarantor.Email, SqlDbType.VarChar, 50);
            objDBManager.AddParameter("ModifiedById", objFinancialGuarantor.ModifiedById, SqlDbType.Int, 4);
            objDBManager.AddParameter("ModifiedDate", objFinancialGuarantor.ModifiedDate, SqlDbType.DateTime, 8);

            ReturnValue = objDBManager.ExecuteNonQuery("FinancialGuarantor_Update");


        }
        catch (Exception ex)
        {
            throw ex;

        }

        return ReturnValue;

    }

    public DataSet GetBySearchCriteria(string firstName, string lastName, string dateofBirth, string gender, string address, long PracticeId, int rows, int pageNumber)
    {
        DBManager objDBManager = new DBManager();
        if (!string.IsNullOrEmpty(firstName))
            objDBManager.AddParameter("FirstName", firstName);
        if (!string.IsNullOrEmpty(lastName))
            objDBManager.AddParameter("LastName", lastName);

        if (!string.IsNullOrEmpty(dateofBirth))
            objDBManager.AddParameter("DateOfBirth", dateofBirth);
        if (!string.IsNullOrEmpty(gender))
            objDBManager.AddParameter("Gender", gender);
        if (!string.IsNullOrEmpty(address))
            objDBManager.AddParameter("Address", address);

        objDBManager.AddParameter("PracticeId", PracticeId);
        objDBManager.AddParameter("Rows", rows);
        objDBManager.AddParameter("PageNumber", pageNumber);

        return objDBManager.ExecuteDataSet("FinancialGuarantor_GetBySearchCriteria");
    }
}