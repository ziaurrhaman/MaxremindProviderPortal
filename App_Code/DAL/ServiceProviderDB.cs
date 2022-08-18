using System;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for ServiceProviderDB
/// </summary>
public class ServiceProviderDB
{
    public ServiceProviderDB()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    
    public long Add(ServiceProvider objServiceProvider, SqlTransaction objSqlTransaction = null)
    {
        long serviceProviderId = 0;
        DBManager objDBManager = new DBManager(objSqlTransaction);
        try
        {
            objDBManager.AddParameter("ServiceProviderId", objServiceProvider.ServiceProviderId, SqlDbType.BigInt, 8, ParameterDirection.Output);
            objDBManager.AddParameter("PracticeId", objServiceProvider.PracticeId);
            objDBManager.AddParameter("PracticeLocationsId", objServiceProvider.PracticeLocationsId);
            objDBManager.AddParameter("FirstName", objServiceProvider.FirstName);
            objDBManager.AddParameter("MiddleName", objServiceProvider.MiddleName);
            objDBManager.AddParameter("LastName", objServiceProvider.LastName);
            objDBManager.AddParameter("ProviderType", objServiceProvider.ProviderType);
            objDBManager.AddParameter("Title", objServiceProvider.Title);
            objDBManager.AddParameter("NPI", objServiceProvider.NPI);
            objDBManager.AddParameter("UPIN", objServiceProvider.UPIN);
            objDBManager.AddParameter("Gender", objServiceProvider.Gender);
            objDBManager.AddParameter("DOB", objServiceProvider.DOB);
            objDBManager.AddParameter("ProviderNo", objServiceProvider.ProviderNo);
            objDBManager.AddParameter("StreetAddress", objServiceProvider.StreetAddress);
            objDBManager.AddParameter("City", objServiceProvider.City);
            objDBManager.AddParameter("State", objServiceProvider.State);
            objDBManager.AddParameter("Zip", objServiceProvider.Zip);            
            objDBManager.AddParameter("Cell", objServiceProvider.Cell);
            objDBManager.AddParameter("OtherPhone", objServiceProvider.OtherPhone);
            objDBManager.AddParameter("FaxNumber", objServiceProvider.FaxNumber);
            objDBManager.AddParameter("Email", objServiceProvider.Email);            
            objDBManager.AddParameter("LicenseNo", objServiceProvider.LicenseNo);
            objDBManager.AddParameter("LicenseState", objServiceProvider.LicenseState);
            objDBManager.AddParameter("LicenseIssuDate", objServiceProvider.LicenseIssuDate);
            objDBManager.AddParameter("LicenseExpiry", objServiceProvider.LicenseExpiry);                       
            objDBManager.AddParameter("CommunityCareNumber", objServiceProvider.CommunityCareNumber);
            objDBManager.AddParameter("ExternalReferral", objServiceProvider.ExternalReferral);
            objDBManager.AddParameter("EmploymentType", objServiceProvider.EmploymentType);
            objDBManager.AddParameter("DAE", objServiceProvider.DAE);
            objDBManager.AddParameter("Degree", objServiceProvider.Degree);
            objDBManager.AddParameter("Speciality", objServiceProvider.Speciality);
            objDBManager.AddParameter("Active", objServiceProvider.Active);
            objDBManager.AddParameter("IsAuthorized", objServiceProvider.IsAuthorized);
            objDBManager.AddParameter("ImagePath", objServiceProvider.ImagePath);

            objDBManager.AddParameter("CreatedById", objServiceProvider.CreatedById);
            objDBManager.AddParameter("CreatedDate", objServiceProvider.CreatedDate);

            objDBManager.ExecuteNonQuery("ServiceProvider_Add");
            serviceProviderId = int.Parse(objDBManager.Parameters[0].Value.ToString());
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return serviceProviderId;
    }
    
    public int Update(ServiceProvider objServiceProvider, SqlTransaction objSqlTransaction = null)
    {
        DBManager objDBManager = new DBManager(objSqlTransaction);
        int ReturnValue = 0;

        try
        {
            objDBManager.AddParameter("ServiceProviderId", objServiceProvider.ServiceProviderId);
            objDBManager.AddParameter("PracticeLocationsId", objServiceProvider.PracticeLocationsId);
            objDBManager.AddParameter("FirstName", objServiceProvider.FirstName);
            objDBManager.AddParameter("MiddleName", objServiceProvider.MiddleName);
            objDBManager.AddParameter("LastName", objServiceProvider.LastName);
            objDBManager.AddParameter("ProviderType", objServiceProvider.ProviderType);
            objDBManager.AddParameter("Title", objServiceProvider.Title);
            objDBManager.AddParameter("NPI", objServiceProvider.NPI);
            objDBManager.AddParameter("UPIN", objServiceProvider.UPIN);
            objDBManager.AddParameter("Gender", objServiceProvider.Gender);
            objDBManager.AddParameter("DOB", objServiceProvider.DOB);
            objDBManager.AddParameter("ProviderNo", objServiceProvider.ProviderNo);
            objDBManager.AddParameter("StreetAddress", objServiceProvider.StreetAddress);
            objDBManager.AddParameter("City", objServiceProvider.City);
            objDBManager.AddParameter("State", objServiceProvider.State);
            objDBManager.AddParameter("Zip", objServiceProvider.Zip);
            objDBManager.AddParameter("Cell", objServiceProvider.Cell);
            objDBManager.AddParameter("OtherPhone", objServiceProvider.OtherPhone);
            objDBManager.AddParameter("FaxNumber", objServiceProvider.FaxNumber);
            objDBManager.AddParameter("Email", objServiceProvider.Email);
            objDBManager.AddParameter("LicenseNo", objServiceProvider.LicenseNo);
            objDBManager.AddParameter("LicenseState", objServiceProvider.LicenseState);
            objDBManager.AddParameter("LicenseIssuDate", objServiceProvider.LicenseIssuDate);
            objDBManager.AddParameter("LicenseExpiry", objServiceProvider.LicenseExpiry);
            objDBManager.AddParameter("CommunityCareNumber", objServiceProvider.CommunityCareNumber);
            objDBManager.AddParameter("ExternalReferral", objServiceProvider.ExternalReferral);
            objDBManager.AddParameter("EmploymentType", objServiceProvider.EmploymentType);
            objDBManager.AddParameter("DAE", objServiceProvider.DAE);
            objDBManager.AddParameter("Degree", objServiceProvider.Degree);
            objDBManager.AddParameter("Speciality", objServiceProvider.Speciality);
            objDBManager.AddParameter("Active", objServiceProvider.Active);
            objDBManager.AddParameter("IsAuthorized", objServiceProvider.IsAuthorized);
            objDBManager.AddParameter("ImagePath", objServiceProvider.ImagePath);

            objDBManager.AddParameter("ModifiedById", objServiceProvider.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objServiceProvider.ModifiedDate);            
            
            ReturnValue = objDBManager.ExecuteNonQuery("ServiceProvider_Update");
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ReturnValue;
    }
    
    public void ServiceProvider_UpdateFromUser(ServiceProvider objServiceProvider)
    {
        DBManager objDBManager = new DBManager();        
        try
        {
            objDBManager.AddParameter("ServiceProviderId", objServiceProvider.ServiceProviderId);
            objDBManager.AddParameter("PracticeLocationsId", objServiceProvider.PracticeLocationsId);
            objDBManager.AddParameter("FirstName", objServiceProvider.FirstName);
            objDBManager.AddParameter("MiddleName", objServiceProvider.MiddleName);
            objDBManager.AddParameter("LastName", objServiceProvider.LastName);            
            objDBManager.AddParameter("Cell", objServiceProvider.Cell);            
            objDBManager.AddParameter("Email", objServiceProvider.Email);
            objDBManager.AddParameter("ImagePath", objServiceProvider.ImagePath);

            objDBManager.AddParameter("ModifiedById", objServiceProvider.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objServiceProvider.ModifiedDate);

            objDBManager.ExecuteNonQuery("ServiceProvider_UpdateFromUser");
        }
        catch (Exception ex)
        {
            throw ex;
        }       
    }
    
    public DataTable GetProvidersByPractice(long PracticeId)
    {
        DBManager objDBManager = new DBManager();
        
        objDBManager.AddParameter("PracticeId", PracticeId);

        return objDBManager.ExecuteDataTable("ServiceProvider_GetProvidersByPractice");
    }
    
    public int DeleteServiceProvider(long ServiceProviderId, long ModifiedById, DateTime ModifiedDate)
    {
        DBManager objDBManager = new DBManager();
        try
        {
            objDBManager.AddParameter("@ServiceProviderId", ServiceProviderId);
            objDBManager.AddParameter("@ModifiedById", ModifiedById);
            objDBManager.AddParameter("@ModifiedByDate", ModifiedDate);
            
            return objDBManager.ExecuteNonQuery("DeleteServiceProvider");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    
    public int DeleteServiceProviderQualification(long ServiceProviderQualificationId,long ModifiedById,DateTime ModifiedDate)
    {
        DBManager objDBManager = new DBManager();
        try
        {
            objDBManager.AddParameter("@ServiceProviderQualificationId", ServiceProviderQualificationId);
            objDBManager.AddParameter("@ModifiedById", ModifiedById);
            objDBManager.AddParameter("@ModifiedByDate", ModifiedDate);
            
            return objDBManager.ExecuteNonQuery("DeleteServiceProviderQualification");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    
    public DataTable GetServiceProviderListByVisitDate(string ServiceProviderId, string PracticeId, DateTime VisitDate)
    {
        DBManager objDBManager = new DBManager();

        objDBManager.AddParameter("PracticeId", PracticeId);
        objDBManager.AddParameter("ScheduledDate", VisitDate);

        if (!string.IsNullOrEmpty(ServiceProviderId))
        {
            objDBManager.AddParameter("ServiceProviderId", ServiceProviderId);
        }

        return objDBManager.ExecuteDataTable("GetServiceProviderListByVisitDate");
    }
    
    public DataTable GetServiceProviderById(long ServiceProviderId)
    {
        DBManager objDBManager = new DBManager();

        objDBManager.AddParameter("ServiceProviderId", ServiceProviderId);

        return objDBManager.ExecuteDataTable("GetServiceProviderById");
    }
    
    public DataSet ServiceProviderGetDetails(long serviceProviderId, long PracticeId)
    {
        DBManager objDBManager = new DBManager();
        
        objDBManager.AddParameter("ServiceProviderId", serviceProviderId);
        objDBManager.AddParameter("PracticeId", PracticeId);

        return objDBManager.ExecuteDataSet("ServiceProvider_GetDetails");
    }
    
    public void SaveServiceProviderPicture(long intserviceProviderId, string ImagePath)
    {
        DBManager objDBManager = new DBManager();

        objDBManager.AddParameter("ServiceProviderId", intserviceProviderId);
        objDBManager.AddParameter("ImagePath", ImagePath);

        objDBManager.ExecuteNonQuery("SaveServiceProviderPicture");
    }
    
    public DataTable GetServiceProvidersDetailsById(long serviceProviderId)
    {
        DBManager objDBManager = new DBManager();

        objDBManager.AddParameter("ServiceProviderId", serviceProviderId);

        return objDBManager.ExecuteDataTable("ServiceProviders_GetServiceProvidersDetailsById");
    }
    
    public DataTable GetProvidersByPracticeLocation(long PracticeLocationsId, long ServiceProviderId)
    {
        DBManager objDBManager = new DBManager();

        if (PracticeLocationsId != 0)
        {
            objDBManager.AddParameter("PracticeLocationsId", PracticeLocationsId);
        }
        
        if (ServiceProviderId != 0)
        {
            objDBManager.AddParameter("ServiceProviderId", ServiceProviderId);
        }

        return objDBManager.ExecuteDataTable("ServiceProvider_GetProvidersByPracticeLocation");
    }
    
    public DataTable GetTop1ByPracticeLocation(int PracticeLocationsId)
    {
        try
        {
            DBManager objDBManager = new DBManager();

            objDBManager.AddParameter("PracticeLocationsId", PracticeLocationsId);

            return objDBManager.ExecuteDataTable("ServiceProvider_GetTop1ByPracticeLocation");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    
    public DataSet GetAllFilter(long PracticeId, string LastName, string FirstName, int PageNumber, int Rows, string SortBy)
    {
        DBManager objDBManager = new DBManager();

        objDBManager.AddParameter("PracticeId", PracticeId);

        if (!string.IsNullOrEmpty(LastName))
        {
            objDBManager.AddParameter("LastName", LastName);
        }

        if (!string.IsNullOrEmpty(FirstName))
        {
            objDBManager.AddParameter("FirstName", FirstName);
        }

        objDBManager.AddParameter("PageNumber", PageNumber);

        objDBManager.AddParameter("Rows", Rows);

        if (!string.IsNullOrEmpty(SortBy))
        {
            objDBManager.AddParameter("SortBy", SortBy);
        }

        return objDBManager.ExecuteDataSet("ServiceProvider_GetAllFilter");
    }
    
    public DataTable GetProvidersIdAndNameByPractice(long PracticeId)
    {
        DBManager objDBManager = new DBManager();
        
        objDBManager.AddParameter("PracticeId", PracticeId);
        
        return objDBManager.ExecuteDataTable("ServiceProvider_GetProvidersIdAndNameByPractice");
    }

    /***********added by shahid kazmi 12/8/2017**********/
    public DataTable GetServiceProviderByPracticeLocationsId(string PracticeLocationsId,string PracticeId)
    {
        DBManager objDBManager = new DBManager();

        if (PracticeLocationsId != "")
        {
            objDBManager.AddParameter("PracticeLocationsId", PracticeLocationsId);
        }
        objDBManager.AddParameter("PracticeId", PracticeId);

        return objDBManager.ExecuteDataTable("Claim_GetServiceProviderByPracticeLocationsId");
    }
    /************end shahid kazmi 12/8/2017*************/
    public DataTable GetProvidersforMonthlyReconciliation(string PracticeLocationsId, string PracticeId, string ProviderType)
    {
        DBManager objDBManager = new DBManager();

        if (PracticeLocationsId != "")
        {
            objDBManager.AddParameter("practicelocationsId", PracticeLocationsId);
        }

        if (!string.IsNullOrEmpty(ProviderType))
        {
            objDBManager.AddParameter("ProviderType", ProviderType);
        }

        objDBManager.AddParameter("PracticeId", PracticeId);

        return objDBManager.ExecuteDataTable("GetProvidersforMonthlyReconciliation");
    }

    public DataTable GetPracticeStaffonNPINum(long Practiceid) 
    {
        DBManager objDBManager = new DBManager();

        objDBManager.AddParameter("@PracticeId", Practiceid);

        return objDBManager.ExecuteDataTable("PracticeStaffonNPINum");
    }

    public DataTable GetProvidersByPracticeForPP(long PracticeId)
    {
        try
        {
            DBManager objDBManager = new DBManager();

            objDBManager.AddParameter("PracticeId", PracticeId);

            return objDBManager.ExecuteDataTable("GetAllPracticeProviders");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

}