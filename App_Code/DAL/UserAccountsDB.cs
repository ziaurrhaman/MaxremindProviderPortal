using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for UserAccountsDB
/// </summary>
public class UserAccountsDB
{
    
	public UserAccountsDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public long Add(UserAccounts objUserAccounts, SqlTransaction objSqlTransaction = null)
    {
        
        DBManager objDBManager = new DBManager(objSqlTransaction);
        
        try
        {
            objDBManager.AddParameter("UserAccountsId", objUserAccounts.UserAccountsId, SqlDbType.Int, 4, ParameterDirection.Output);
            
            objDBManager.AddParameter("UserType", objUserAccounts.UserType);
            objDBManager.AddParameter("UserName", objUserAccounts.UserName);
            objDBManager.AddParameter("Password", objUserAccounts.Password);
            objDBManager.AddParameter("EmailAddress", objUserAccounts.EmailAddress);
            objDBManager.AddParameter("FirstName", objUserAccounts.FirstName);
            objDBManager.AddParameter("LastName", objUserAccounts.LastName);
            objDBManager.AddParameter("MiddleName", objUserAccounts.MiddleName);
            objDBManager.AddParameter("Gender", objUserAccounts.Gender);
            objDBManager.AddParameter("DateOfBirth", objUserAccounts.DateOfBirth);
            objDBManager.AddParameter("ProfilePicturePath", objUserAccounts.ProfilePicturePath);
            objDBManager.AddParameter("City", objUserAccounts.City);
            objDBManager.AddParameter("State", objUserAccounts.State);
            objDBManager.AddParameter("Zip", objUserAccounts.Zip);
            objDBManager.AddParameter("PhoneNumber", objUserAccounts.PhoneNumber);
            objDBManager.AddParameter("Address", objUserAccounts.Address);
            objDBManager.AddParameter("CreatedById", objUserAccounts.CreatedById);
            objDBManager.AddParameter("CreatedDate", objUserAccounts.CreatedDate);
            
            objDBManager.ExecuteNonQuery("PracticeUsers_Add");
            
            objUserAccounts.UserAccountsId = long.Parse(objDBManager.Parameters[0].Value.ToString());
            
        }
        catch (Exception ex)
        {
            throw ex;
        }
        
        return objUserAccounts.UserAccountsId;
        
    }
    
    public int Update(UserAccounts objUserAccounts, SqlTransaction objSqlTransaction = null)
    {
        
        DBManager objDBManager = new DBManager(objSqlTransaction);
        int ReturnValue = 0;
        
        try
        {
            
            objDBManager.AddParameter("UserAccountsId", objUserAccounts.UserAccountsId, SqlDbType.Int, 4);
            
            objDBManager.AddParameter("UserType", objUserAccounts.UserType);
            objDBManager.AddParameter("UserName", objUserAccounts.UserName);
            objDBManager.AddParameter("Password", objUserAccounts.Password);
            objDBManager.AddParameter("EmailAddress", objUserAccounts.EmailAddress);
            objDBManager.AddParameter("FirstName", objUserAccounts.FirstName);
            objDBManager.AddParameter("LastName", objUserAccounts.LastName);
            objDBManager.AddParameter("MiddleName", objUserAccounts.MiddleName);
            objDBManager.AddParameter("Gender", objUserAccounts.Gender);
            objDBManager.AddParameter("DateOfBirth", objUserAccounts.DateOfBirth);
            objDBManager.AddParameter("ProfilePicturePath", objUserAccounts.ProfilePicturePath);
            objDBManager.AddParameter("City", objUserAccounts.City);
            objDBManager.AddParameter("State", objUserAccounts.State);
            objDBManager.AddParameter("Zip", objUserAccounts.Zip);
            objDBManager.AddParameter("PhoneNumber", objUserAccounts.PhoneNumber);
            objDBManager.AddParameter("Address", objUserAccounts.Address);
            objDBManager.AddParameter("ModifiedById", objUserAccounts.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objUserAccounts.ModifiedDate);
            
            ReturnValue = objDBManager.ExecuteNonQuery("PracticeUsers_Update");
            
        }
        catch (Exception ex)
        {
            throw ex;
        }
        
        return ReturnValue;
        
    }
    
    
    public int ValidateUser(string userName, string password)
    {
        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("UserName", userName);
        objDBManager.AddParameter("Password", password);
        
        return int.Parse(objDBManager.ExecuteScalar("ValidateUser"));
    }
    
    public DataTable GetUserProfile(string userName)
    {
        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("UserName", userName);
        
        return objDBManager.ExecuteDataTable("GetUserProfile");
    }
    
    
}