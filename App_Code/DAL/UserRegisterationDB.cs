
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

public class UserRegistrationDB
{
    public long Add(UserRegistration objUserRegistration, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);
            objDBManager.AddParameter("UserRegistrationId", objUserRegistration.UserRegistrationId, SqlDbType.BigInt, 8, ParameterDirection.Output);

            objDBManager.AddParameter("FirstName", objUserRegistration.FirstName);
            objDBManager.AddParameter("LastName", objUserRegistration.LastName);
            objDBManager.AddParameter("Email", objUserRegistration.Email);
            //objDBManager.AddParameter("PracticeName", objUserRegistration.PracticeName);
            //objDBManager.AddParameter("TaxID", objUserRegistration.TaxID);
            //objDBManager.AddParameter("GroupNPI", objUserRegistration.GroupNPI);
            //objDBManager.AddParameter("MedicaidProvider", objUserRegistration.MedicaidProvider);
            //objDBManager.AddParameter("ServicingProviderName", objUserRegistration.ServicingProviderName);
            objDBManager.AddParameter("ProviderNPI", objUserRegistration.ProviderNPI);
            //objDBManager.AddParameter("ProviderTaxonomyCode", objUserRegistration.ProviderTaxonomyCode);
           // objDBManager.AddParameter("StateLicenseNumber", objUserRegistration.StateLicenseNumber);
           // objDBManager.AddParameter("MedicaidGroup", objUserRegistration.MedicaidGroup);
            //objDBManager.AddParameter("GroupNPIMedicareGroupPTAN", objUserRegistration.GroupNPIMedicareGroupPTAN);
            //objDBManager.AddParameter("MedicareProviderPTAN", objUserRegistration.MedicareProviderPTAN);
            //objDBManager.AddParameter("Phone", objUserRegistration.Phone);
            //objDBManager.AddParameter("Fax", objUserRegistration.Fax);
            //objDBManager.AddParameter("Notes", objUserRegistration.Notes);
           // objDBManager.AddParameter("PhysicalAddress", objUserRegistration.PhysicalAddress);
           // objDBManager.AddParameter("MailingAddress", objUserRegistration.MailingAddress);
           // objDBManager.AddParameter("CreatedById", objUserRegistration.CreatedById);
            //objDBManager.AddParameter("CreatedDate", objUserRegistration.CreatedDate);
            objDBManager.AddParameter("Password", objUserRegistration.Password);
            objDBManager.AddParameter("UserName", objUserRegistration.UserName);
            objDBManager.ExecuteNonQuery("UserRegistration_Add");
            long returnvalue = long.Parse(objDBManager.Parameters[0].Value.ToString());

            return returnvalue;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int Update(UserRegistration objUserRegistration, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager();

            objDBManager.AddParameter("UserRegistrationId", objUserRegistration.UserRegistrationId, SqlDbType.BigInt, 8);

            objDBManager.AddParameter("FirstName", objUserRegistration.FirstName);
            objDBManager.AddParameter("LastName", objUserRegistration.LastName);
            objDBManager.AddParameter("Email", objUserRegistration.Email);
            objDBManager.AddParameter("UserImage", objUserRegistration.UserImage);
            objDBManager.AddParameter("PracticeName", objUserRegistration.PracticeName);
            objDBManager.AddParameter("GroupNPI", objUserRegistration.GroupNPI);
            objDBManager.AddParameter("TaxID", objUserRegistration.TaxID);
            //objDBManager.AddParameter("MedicaidProvider", objUserRegistration.MedicaidProvider);
            //objDBManager.AddParameter("ServicingProviderName", objUserRegistration.ServicingProviderName);
            //objDBManager.AddParameter("ProviderNPI", objUserRegistration.ProviderNPI);
            //objDBManager.AddParameter("ProviderTaxonomyCode", objUserRegistration.ProviderTaxonomyCode);
            //objDBManager.AddParameter("StateLicenseNumber", objUserRegistration.StateLicenseNumber);
            //objDBManager.AddParameter("MedicaidGroup", objUserRegistration.MedicaidGroup);
            //objDBManager.AddParameter("GroupNPIMedicareGroupPTAN", objUserRegistration.GroupNPIMedicareGroupPTAN);
            //objDBManager.AddParameter("MedicareProviderPTAN", objUserRegistration.MedicareProviderPTAN);
            //objDBManager.AddParameter("Phone", objUserRegistration.Phone);
            //objDBManager.AddParameter("Fax", objUserRegistration.Fax);
            //objDBManager.AddParameter("Notes", objUserRegistration.Notes);
            //objDBManager.AddParameter("PhysicalAddress", objUserRegistration.PhysicalAddress);
            //objDBManager.AddParameter("MailingAddress", objUserRegistration.MailingAddress);
            //objDBManager.AddParameter("ModifiedById", objUserRegistration.ModifiedById);
            //objDBManager.AddParameter("ModifiedDate", objUserRegistration.ModifiedDate);
            //objDBManager.AddParameter("Password", objUserRegistration.Password);
           

            return objDBManager.ExecuteNonQuery("UserRegistration_Update");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int Delete(UserRegistration objUserRegistration, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);

            objDBManager.AddParameter("UserRegistrationId", objUserRegistration.UserRegistrationId);

            objDBManager.AddParameter("ModifiedById", objUserRegistration.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objUserRegistration.ModifiedDate);

            return objDBManager.ExecuteNonQuery("UserRegistration_Delete");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable GetByID(UserRegistration objUserRegistration, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);
            if (objUserRegistration.UserRegistrationId == -1)
            {
                objDBManager.AddParameter("UserName", objUserRegistration.UserName);
                objDBManager.AddParameter("ProviderNPI", null);
                objDBManager.AddParameter("UserRegistrationId", null);
                objDBManager.AddParameter("Password", null);
            }
            else if (objUserRegistration.UserRegistrationId == -2)
            {
                objDBManager.AddParameter("ProviderNPI", objUserRegistration.ProviderNPI);
            }
            else
            {
                objDBManager.AddParameter("UserRegistrationId", objUserRegistration.UserRegistrationId);
                objDBManager.AddParameter("UserName", objUserRegistration.UserName);
                objDBManager.AddParameter("Password", objUserRegistration.Password);
            }
            return objDBManager.ExecuteDataTable("UserRegistration_GetByID");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet GetAllFilter(int Rows, int PageNumber, string SortBy)
    {
        try
        {
            DBManager objDBManager = new DBManager();

            objDBManager.AddParameter("Rows", Rows);
            objDBManager.AddParameter("PageNumber", PageNumber);

            if (!string.IsNullOrEmpty(SortBy))
            {
                objDBManager.AddParameter("SortBy", SortBy);
            }

            return objDBManager.ExecuteDataSet("UserRegistration_GetAllFilter");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public void UpdateUserImagePath(UserRegistration objuserRegisteration)
    {
        DBManager objDBManager = new DBManager();

        objDBManager.AddParameter("UserId", objuserRegisteration.UserRegistrationId);
        objDBManager.AddParameter("ProfilePicturePath", objuserRegisteration.UserImage);
        objDBManager.AddParameter("ModifiedById", objuserRegisteration.ModifiedById);
        objDBManager.AddParameter("ModifiedDate", objuserRegisteration.ModifiedDate);

        objDBManager.ExecuteNonQuery("RegisterUser_UpdateUserImagePath");
    }

    public void UpdateUserPassword(UserRegistration objuserRegistration)
    {
        DBManager objDBManager = new DBManager();

        objDBManager.AddParameter("UserRegistrationId", objuserRegistration.UserRegistrationId);
        objDBManager.AddParameter("Password", objuserRegistration.Password);
        objDBManager.ExecuteNonQuery("UserRegistrationPasswordUpdate");
    }
}