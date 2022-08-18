using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for PracticeUsersDB
/// </summary>
public class PracticeUsersDB
{
	public PracticeUsersDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    
    public long Add(PracticeUsers objPracticeUsers, SqlTransaction objSqlTransaction = null)
    {
        DBManager objDBManager = new DBManager(objSqlTransaction);
        try
        {
            objDBManager.AddParameter("UserId", objPracticeUsers.UserId, SqlDbType.BigInt, 8, ParameterDirection.Output);
            
            objDBManager.AddParameter("UserName", objPracticeUsers.UserName);
            objDBManager.AddParameter("Password", objPracticeUsers.Password);
            objDBManager.AddParameter("FirstName", objPracticeUsers.FirstName);
            objDBManager.AddParameter("LastName", objPracticeUsers.LastName);
            objDBManager.AddParameter("MiddleName", objPracticeUsers.MiddleName);
            //objDBManager.AddParameter("UserType", objPracticeUsers.UserType);
            objDBManager.AddParameter("EmailAddress", objPracticeUsers.EmailAddress);
            objDBManager.AddParameter("PhoneNumber", objPracticeUsers.PhoneNumber);
            objDBManager.AddParameter("ServiceProviderId", objPracticeUsers.ServiceProviderId);
            objDBManager.AddParameter("PracticeId", objPracticeUsers.PracticeId);
            objDBManager.AddParameter("PracticeLocationsId", objPracticeUsers.PracticeLocationsId);
            objDBManager.AddParameter("IsActive", objPracticeUsers.IsActive);
            objDBManager.AddParameter("ProfilePicturePath", objPracticeUsers.ProfilePicturePath);
            objDBManager.AddParameter("ProviderPortalUsers", objPracticeUsers.ProviderPortalUsers);
            objDBManager.AddParameter("StaffShift", objPracticeUsers.StaffShift);
            objDBManager.AddParameter("CreatedById", objPracticeUsers.CreatedById);
            objDBManager.AddParameter("CreatedDate", objPracticeUsers.CreatedDate);
            
            objDBManager.ExecuteNonQuery("PracticeUsers_Add");
            objPracticeUsers.UserId = long.Parse(objDBManager.Parameters[0].Value.ToString());
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return objPracticeUsers.UserId;
    }
    
    public int Update(PracticeUsers objPracticeUsers, SqlTransaction objSqlTransaction = null)
    {
        DBManager objDBManager = new DBManager(objSqlTransaction);
        int ReturnValue = 0;
        try
        {
            objDBManager.AddParameter("UserId", objPracticeUsers.UserId);
            objDBManager.AddParameter("UserName", objPracticeUsers.UserName);
            objDBManager.AddParameter("Password", objPracticeUsers.Password);
            objDBManager.AddParameter("FirstName", objPracticeUsers.FirstName);
            objDBManager.AddParameter("LastName", objPracticeUsers.LastName);
            objDBManager.AddParameter("MiddleName", objPracticeUsers.MiddleName);
            //objDBManager.AddParameter("UserType", objPracticeUsers.UserType);
            objDBManager.AddParameter("EmailAddress", objPracticeUsers.EmailAddress);
            objDBManager.AddParameter("PhoneNumber", objPracticeUsers.PhoneNumber);
            objDBManager.AddParameter("ServiceProviderId", objPracticeUsers.ServiceProviderId);
            //objDBManager.AddParameter("PracticeId", objPracticeUsers.PracticeId);
            objDBManager.AddParameter("PracticeLocationsId", objPracticeUsers.PracticeLocationsId);
            objDBManager.AddParameter("IsActive", objPracticeUsers.IsActive);
            objDBManager.AddParameter("ProfilePicturePath", objPracticeUsers.ProfilePicturePath);
            objDBManager.AddParameter("ModifiedById", objPracticeUsers.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objPracticeUsers.ModifiedDate);
            objDBManager.AddParameter("ProviderPortalUsers", objPracticeUsers.ProviderPortalUsers);
            objDBManager.AddParameter("StaffShift", objPracticeUsers.StaffShift);
            ReturnValue = objDBManager.ExecuteNonQuery("PracticeUsers_Update");
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ReturnValue;
    }
    
    public int Delete(PracticeUsers objPracticeUsers)
    {
        DBManager objDBManager = new DBManager();
        
        objDBManager.AddParameter("UserId", objPracticeUsers.UserId);
        objDBManager.AddParameter("ModifiedById", objPracticeUsers.ModifiedById);
        objDBManager.AddParameter("ModifiedDate", objPracticeUsers.ModifiedDate);
        
        return objDBManager.ExecuteNonQuery("PracticeUsers_Delete");
    }
    
    public int ValidateUser(string userName, string password)
    {
        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("UserName", userName, SqlDbType.VarChar, 20);
        objDBManager.AddParameter("Password", password, SqlDbType.VarChar, 20);

        return int.Parse(objDBManager.ExecuteScalar("ValidateUser"));
    }
    
    public DataTable GetUserProfile(string userName, string password)
    {
        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("UserName", userName);
        objDBManager.AddParameter("Password", password);

        return objDBManager.ExecuteDataTable("GetUserProfile_ProviderPortal");
    }
    public DataTable GetUserProfile_WithSelectedPractice(long UserId, long PracticeId)
    {
        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("UserId", UserId);
        objDBManager.AddParameter("PracticeId", PracticeId);

        return objDBManager.ExecuteDataTable("GetUserProfile_New");
    }
    
    public DataSet GetUserProfileInformationById(long UserId)
    {
        DBManager objDBManager = new DBManager();

        objDBManager.AddParameter("UserId", UserId);

        return objDBManager.ExecuteDataSet("PracticeUsers_GetUserProfileInformationById");
    }
    
    public DataTable GetEmailAndNameByPracticeId(long PracticeId, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);
            
            objDBManager.AddParameter("PracticeId", PracticeId, SqlDbType.Int, 4);
            
            return objDBManager.ExecuteDataTable("PracticeUsers_GetEmailAndNameByPracticeId");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    
    public DataTable PracticeUsers_GetByPracticeId(long PracticeId)
    {
        DBManager objDbManager = new DBManager();
        objDbManager.AddParameter("PracticeId", PracticeId);
        return objDbManager.ExecuteDataTable("PracticeUsers_GetByPracticeId");
    }
    
    public DataTable GetUsers(long practiceId)
    {
        DBManager objDbManager = new DBManager();
        objDbManager.AddParameter("PracticeId", practiceId);
        return objDbManager.ExecuteDataTable("PracticeUsers_GetUsers");
    }

    public DataTable PracticeUsers_GetByServiceProviderId(long ServiceProviderId)
    {
        DBManager objDbManager = new DBManager();
        objDbManager.AddParameter("ServiceProviderId", ServiceProviderId);
        return objDbManager.ExecuteDataTable("PracticeUsers_GetByServiceProviderId");
    }

    public DataSet GetAllFilter(long PracticeId, long PracticeLocationsId, long UserId, long ServiceProviderId, int Rows, int PageNumber, string SortBy)
    {
        DBManager objDbManager = new DBManager();
        
        objDbManager.AddParameter("PracticeId", PracticeId);
        
        //if (PracticeLocationsId != 0)
        //{
        //    objDbManager.AddParameter("PracticeLocationsId", PracticeLocationsId);
        //}
        
        if (UserId != 0)
        {
            objDbManager.AddParameter("UserId", UserId);
        }
        
        if (ServiceProviderId != 0)
        {
            objDbManager.AddParameter("ServiceProviderId", ServiceProviderId);
        }
        
        objDbManager.AddParameter("Rows", Rows);
        objDbManager.AddParameter("PageNumber", PageNumber);
        objDbManager.AddParameter("SortBy", SortBy);

        return objDbManager.ExecuteDataSet("PracticeUsers_GetAllFilter_ProviderPortal");
    }

    public void UpdateUserImagePath(PracticeUsers objPracticeUsers)
    {
        DBManager objDBManager = new DBManager();

        objDBManager.AddParameter("UserId", objPracticeUsers.UserId);
        objDBManager.AddParameter("ServiceProviderId", objPracticeUsers.ServiceProviderId);
        objDBManager.AddParameter("ProfilePicturePath", objPracticeUsers.ProfilePicturePath);
        objDBManager.AddParameter("ModifiedById", objPracticeUsers.ModifiedById);
        objDBManager.AddParameter("ModifiedDate", objPracticeUsers.ModifiedDate);

        objDBManager.ExecuteNonQuery("PracticeUsers_UpdateUserImagePath");
    }

    public int CheckUserExist(long userId, string useName)
    {
        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("UserId", userId);
        objDBManager.AddParameter("UserName", useName);
        return int.Parse(objDBManager.ExecuteScalar("CheckUserExist"));
    }

    public DataTable GetEmailByUserId(string UserId)
    {
        DBManager objDBManager = new DBManager();

        objDBManager.AddParameter("UserId", UserId);

        return objDBManager.ExecuteDataTable("PracticeUsers_GetEmailByUserId");
    }
    public DataSet ShowUserAssignedPractices(long UserId)
    {
        try
        {
            DBManager objDBManager = new DBManager();
            objDBManager.AddParameter("UserId", UserId);
            return objDBManager.ExecuteDataSet("ShowAssignedPracticesFor_SpecificUser");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    //Added by Syed Sajid Ali Date:10-09-2019 Des:delete/Inactive User
    public int UserAssignedPracticesDelete(long UserId, long PracticeId, string Type)
    {
        try
        {
            DBManager objDBManager = new DBManager();
            objDBManager.AddParameter("UserId", UserId);
            objDBManager.AddParameter("PracticeId", PracticeId);
            objDBManager.AddParameter("Type ", Type);
            return objDBManager.ExecuteNonQuery("DeleteInActiveAssignedPracticeUser");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    //Added by Syed Sajid Ali Date:10-09-2019 Des:delete/Inactive User

    //Added by Syed Sajid Ali Date:12-05-2019
    public DataTable GetUserSpecific(string userName, string password)
    {
        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("UserName", userName);
        objDBManager.AddParameter("Password", password);

        return objDBManager.ExecuteDataTable("UserRegistration_GetByID");
    }
    //End by Syed Sajid Ali
}