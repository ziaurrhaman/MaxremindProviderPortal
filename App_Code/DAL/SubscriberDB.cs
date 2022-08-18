using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for SubscriberDB
/// </summary>
public class SubscriberDB
{
	public SubscriberDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public int Add(Subscriber objSubscriber)
    {

        DBManager objDBManager = new DBManager();


        try
        {
            objDBManager.AddParameter("SubscriberId", objSubscriber.SubscriberId, SqlDbType.Int, 4, ParameterDirection.Output);
            objDBManager.AddParameter("PracticeId", objSubscriber.PracticeId);
            objDBManager.AddParameter("FirstName", objSubscriber.FirstName, SqlDbType.VarChar, 25);
            objDBManager.AddParameter("LastName", objSubscriber.LastName, SqlDbType.VarChar, 25);
            objDBManager.AddParameter("MiddleName", objSubscriber.MiddleName, SqlDbType.VarChar, 25);
            objDBManager.AddParameter("DateOfBirth", objSubscriber.DateOfBirth, SqlDbType.DateTime, 3);
            objDBManager.AddParameter("SSN", objSubscriber.SSN, SqlDbType.VarChar, 15);
            objDBManager.AddParameter("Gender", objSubscriber.Gender, SqlDbType.VarChar, 8);
            objDBManager.AddParameter("MaritalStatus", objSubscriber.MaritalStatus, SqlDbType.VarChar, 15);
            objDBManager.AddParameter("Address", objSubscriber.Address, SqlDbType.VarChar, 100);
            objDBManager.AddParameter("Zip", objSubscriber.Zip, SqlDbType.VarChar, 15);
            objDBManager.AddParameter("City", objSubscriber.City, SqlDbType.VarChar, 25);
            objDBManager.AddParameter("State", objSubscriber.State, SqlDbType.Char, 2);
            objDBManager.AddParameter("HomePhone", objSubscriber.HomePhone, SqlDbType.VarChar, 16);
            objDBManager.AddParameter("Cell", objSubscriber.Cell, SqlDbType.VarChar, 16);
            objDBManager.AddParameter("WorkPhone", objSubscriber.WorkPhone, SqlDbType.VarChar, 16);
            objDBManager.AddParameter("Ext", objSubscriber.Ext, SqlDbType.VarChar, 5);
            objDBManager.AddParameter("Email", objSubscriber.Email, SqlDbType.VarChar, 50);
            objDBManager.AddParameter("CreatedById", objSubscriber.CreatedById, SqlDbType.Int, 4);
            objDBManager.AddParameter("CreatedDate", objSubscriber.CreatedDate, SqlDbType.DateTime, 8);

            objDBManager.ExecuteNonQuery("Subscriber_Add");

            objSubscriber.SubscriberId = int.Parse(objDBManager.Parameters[0].Value.ToString());

        }
        catch (Exception ex)
        {

            throw ex;

        }

        return objSubscriber.SubscriberId;

    }

    public int Update(Subscriber objSubscriber)
    {

        DBManager objDBManager = new DBManager();
        int ReturnValue = 0;

        try
        {

            objDBManager.AddParameter("SubscriberId", objSubscriber.SubscriberId, SqlDbType.Int, 4);

            objDBManager.AddParameter("FirstName", objSubscriber.FirstName, SqlDbType.VarChar, 25);
            objDBManager.AddParameter("LastName", objSubscriber.LastName, SqlDbType.VarChar, 25);
            objDBManager.AddParameter("MiddleName", objSubscriber.MiddleName, SqlDbType.VarChar, 25);
            objDBManager.AddParameter("DateOfBirth", objSubscriber.DateOfBirth, SqlDbType.DateTime, 3);
            objDBManager.AddParameter("SSN", objSubscriber.SSN, SqlDbType.VarChar, 15);
            objDBManager.AddParameter("Gender", objSubscriber.Gender, SqlDbType.VarChar, 8);
            objDBManager.AddParameter("MaritalStatus", objSubscriber.MaritalStatus, SqlDbType.VarChar, 15);
            objDBManager.AddParameter("Address", objSubscriber.Address, SqlDbType.VarChar, 100);
            objDBManager.AddParameter("Zip", objSubscriber.Zip, SqlDbType.VarChar, 15);
            objDBManager.AddParameter("City", objSubscriber.City, SqlDbType.VarChar, 25);
            objDBManager.AddParameter("State", objSubscriber.State, SqlDbType.Char, 2);
            objDBManager.AddParameter("HomePhone", objSubscriber.HomePhone, SqlDbType.VarChar, 16);
            objDBManager.AddParameter("Cell", objSubscriber.Cell, SqlDbType.VarChar, 16);
            objDBManager.AddParameter("WorkPhone", objSubscriber.WorkPhone, SqlDbType.VarChar, 16);
            objDBManager.AddParameter("Ext", objSubscriber.Ext, SqlDbType.VarChar, 5);
            objDBManager.AddParameter("Email", objSubscriber.Email, SqlDbType.VarChar, 50);
            objDBManager.AddParameter("ModifiedById", objSubscriber.ModifiedById, SqlDbType.Int, 4);
            objDBManager.AddParameter("ModifiedDate", objSubscriber.ModifiedDate, SqlDbType.DateTime, 8);

            ReturnValue = objDBManager.ExecuteNonQuery("Subscriber_Update");


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

        return objDBManager.ExecuteDataSet("Subscriber_GetBySearchCriteria");
    }
}