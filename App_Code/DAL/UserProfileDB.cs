using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for UserProfileDB
/// </summary>
public class UserProfileDB
{
	public UserProfileDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    
    public int UpdateProfilePersonalInformation(UserProfile objUserProfile, SqlTransaction objSqlTransaction = null)
    {
        DBManager objDBManager = new DBManager(objSqlTransaction);
        int ReturnValue = 0;
        try
        {
            objDBManager.AddParameter("UserId", objUserProfile.UserId, SqlDbType.BigInt, 8);
            
            objDBManager.AddParameter("ServiceProviderId", objUserProfile.ServiceProviderId);
            
            objDBManager.AddParameter("Title", objUserProfile.Title);
            objDBManager.AddParameter("LastName", objUserProfile.LastName);
            objDBManager.AddParameter("FirstName", objUserProfile.FirstName);
            objDBManager.AddParameter("Gender", objUserProfile.Gender);
            
            objDBManager.AddParameter("ModifiedById", objUserProfile.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objUserProfile.ModifiedDate);
            
            ReturnValue = objDBManager.ExecuteNonQuery("UserProfile_UpdateProfilePersonalInformation");
        }
        catch (Exception ex)
        {
            throw ex;
        }
        
        return ReturnValue;
    }
    
    public int UpdateProfileGeneralInformation(UserProfile objUserProfile, SqlTransaction objSqlTransaction = null)
    {
        DBManager objDBManager = new DBManager(objSqlTransaction);
        int ReturnValue = 0;
        try
        {
            objDBManager.AddParameter("UserId", objUserProfile.UserId, SqlDbType.BigInt, 8);
            
            objDBManager.AddParameter("ServiceProviderId", objUserProfile.ServiceProviderId);
            
            objDBManager.AddParameter("UPIN", objUserProfile.UPIN);
            objDBManager.AddParameter("NPI", objUserProfile.NPI);
            objDBManager.AddParameter("LicenseNo", objUserProfile.LicenseNo);
            
            objDBManager.AddParameter("ModifiedById", objUserProfile.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objUserProfile.ModifiedDate);
            
            ReturnValue = objDBManager.ExecuteNonQuery("UserProfile_UpdateProfileGeneralInformation");
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return ReturnValue;
    }

    public int UpdateProfileContactInformation(UserProfile objUserProfile, SqlTransaction objSqlTransaction = null)
    {
        DBManager objDBManager = new DBManager(objSqlTransaction);
        int ReturnValue = 0;
        try
        {
            objDBManager.AddParameter("UserId", objUserProfile.UserId, SqlDbType.BigInt, 8);

            objDBManager.AddParameter("ServiceProviderId", objUserProfile.ServiceProviderId);

            objDBManager.AddParameter("PhoneNumber", objUserProfile.PhoneNumber);
            objDBManager.AddParameter("OtherPhone", objUserProfile.OtherPhone);
            objDBManager.AddParameter("Fax", objUserProfile.Fax);
            objDBManager.AddParameter("EmailAddress", objUserProfile.EmailAddress);

            objDBManager.AddParameter("ModifiedById", objUserProfile.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objUserProfile.ModifiedDate);

            ReturnValue = objDBManager.ExecuteNonQuery("UserProfile_UpdateProfileContactInformation");
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return ReturnValue;
    }
    
    public int UpdateProfileAddressInformation(UserProfile objUserProfile, SqlTransaction objSqlTransaction = null)
    {
        DBManager objDBManager = new DBManager(objSqlTransaction);
        int ReturnValue = 0;
        try
        {
            objDBManager.AddParameter("UserId", objUserProfile.UserId, SqlDbType.BigInt, 8);
            
            objDBManager.AddParameter("ServiceProviderId", objUserProfile.ServiceProviderId);
            
            objDBManager.AddParameter("StreetAddress", objUserProfile.StreetAddress);
            objDBManager.AddParameter("Zip", objUserProfile.Zip);
            objDBManager.AddParameter("City", objUserProfile.City);
            objDBManager.AddParameter("State", objUserProfile.State);
            
            objDBManager.AddParameter("ModifiedById", objUserProfile.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objUserProfile.ModifiedDate);
            
            ReturnValue = objDBManager.ExecuteNonQuery("UserProfile_UpdateProfileAddressInformation");
        }
        catch (Exception ex)
        {
            throw ex;
        }
        
        return ReturnValue;
    }
    
    public int UpdateProfileDrivingLicenseInformation(UserProfile objUserProfile, SqlTransaction objSqlTransaction = null)
    {
        DBManager objDBManager = new DBManager(objSqlTransaction);
        int ReturnValue = 0;
        try
        {
            objDBManager.AddParameter("UserId", objUserProfile.UserId, SqlDbType.BigInt, 8);
            
            objDBManager.AddParameter("ServiceProviderId", objUserProfile.ServiceProviderId);
            
            objDBManager.AddParameter("DrivingLicenseNo", objUserProfile.DrivingLicenseNo);
            objDBManager.AddParameter("LicenseState", objUserProfile.LicenseState);
            objDBManager.AddParameter("LicenseIssuDate", objUserProfile.LicenseIssuDate);
            objDBManager.AddParameter("LicenseExpiryDate", objUserProfile.LicenseExpiryDate);
            
            objDBManager.AddParameter("ModifiedById", objUserProfile.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objUserProfile.ModifiedDate);

            ReturnValue = objDBManager.ExecuteNonQuery("UserProfile_UpdateProfileDrivingLicenseInformation");
        }
        catch (Exception ex)
        {
            throw ex;
        }
        
        return ReturnValue;
    }
    
    public int UpdateProfileDigitalPIN(UserProfile objUserProfile, SqlTransaction objSqlTransaction = null)
    {
        DBManager objDBManager = new DBManager(objSqlTransaction);
        int ReturnValue = 0;
        try
        {
            objDBManager.AddParameter("UserId", objUserProfile.UserId);
            
            objDBManager.AddParameter("PINCode", objUserProfile.PINCode);
            
            objDBManager.AddParameter("ModifiedById", objUserProfile.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objUserProfile.ModifiedDate);

            ReturnValue = objDBManager.ExecuteNonQuery("UserProfile_UpdateProfileDigitalPIN");
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return ReturnValue;
    }

    public DataTable VerifyProfileDigitalPIN(long UserId, string PINCode, SqlTransaction objSqlTransaction = null)
    {
        DBManager objDBManager = new DBManager(objSqlTransaction);
        try
        {
            objDBManager.AddParameter("UserId", UserId);
            
            objDBManager.AddParameter("PINCode", PINCode);
            
            return objDBManager.ExecuteDataTable("UserProfile_VerifyProfileDigitalPIN");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable VerifyProviderDigitalPIN(long ServiceProviderId, string PINCode, SqlTransaction objSqlTransaction = null)
    {
        DBManager objDBManager = new DBManager(objSqlTransaction);
        try
        {
            objDBManager.AddParameter("ServiceProviderId", ServiceProviderId);

            objDBManager.AddParameter("PINCode", PINCode);

            return objDBManager.ExecuteDataTable("UserProfile_VerifyProviderDigitalPIN");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int UpdateProfileDigitalSignatureImage(UserProfile objUserProfile, SqlTransaction objSqlTransaction = null)
    {
        DBManager objDBManager = new DBManager(objSqlTransaction);
        int ReturnValue = 0;
        try
        {
            objDBManager.AddParameter("UserId", objUserProfile.UserId);

            objDBManager.AddParameter("PINFilePath", objUserProfile.PINFilePath);

            objDBManager.AddParameter("ModifiedById", objUserProfile.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objUserProfile.ModifiedDate);

            ReturnValue = objDBManager.ExecuteNonQuery("UserProfile_UpdateProfileDigitalSignatureImage");
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return ReturnValue;
    }
    
    public int UpdateProfileWebAccount(UserProfile objUserProfile, SqlTransaction objSqlTransaction = null)
    {
        DBManager objDBManager = new DBManager(objSqlTransaction);
        int ReturnValue = 0;
        try
        {
            objDBManager.AddParameter("UserId", objUserProfile.UserId);
            
            objDBManager.AddParameter("Password", objUserProfile.Password);
            
            objDBManager.AddParameter("ModifiedById", objUserProfile.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objUserProfile.ModifiedDate);
            
            ReturnValue = objDBManager.ExecuteNonQuery("UserProfile_UpdateProfileWebAccount");
        }
        catch (Exception ex)
        {
            throw ex;
        }
        
        return ReturnValue;
    }
    
    public DataTable VerifyProfilePassword(long UserId, string Password, SqlTransaction objSqlTransaction = null)
    {
        DBManager objDBManager = new DBManager(objSqlTransaction);
        try
        {
            objDBManager.AddParameter("UserId", UserId);
            
            objDBManager.AddParameter("Password", Password);
            
            return objDBManager.ExecuteDataTable("UserProfile_VerifyProfilePassword");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}