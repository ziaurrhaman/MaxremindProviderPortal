using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for PracticeStaffDB
/// </summary>
public class PracticeStaffDB
{
    public PracticeStaffDB()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    
    public long Add(PracticeStaff objPracticeStaff, SqlTransaction objSqlTransaction = null)
    {
        DBManager objDBManager = new DBManager(objSqlTransaction);

        try
        {
            objDBManager.AddParameter("PracticeStaffId", objPracticeStaff.PracticeStaffId, SqlDbType.Int, 4, ParameterDirection.Output);

            objDBManager.AddParameter("PracticeId", objPracticeStaff.PracticeId);
            objDBManager.AddParameter("PracticeLocationsId", objPracticeStaff.PracticeLocationsId);
            objDBManager.AddParameter("StaffFirstName", objPracticeStaff.StaffFirstName);
            objDBManager.AddParameter("StaffLastName", objPracticeStaff.StaffLastName);
            objDBManager.AddParameter("StaffMiddleName", objPracticeStaff.StaffMiddleName);
            objDBManager.AddParameter("StaffTitle", objPracticeStaff.StaffTitle);
            objDBManager.AddParameter("StaffDateOfBirth", objPracticeStaff.StaffDateOfBirth);
            objDBManager.AddParameter("StaffGender", objPracticeStaff.StaffGender);
            objDBManager.AddParameter("StaffPhoto", objPracticeStaff.StaffPhoto);
            objDBManager.AddParameter("StaffNPI", objPracticeStaff.StaffNPI);
            objDBManager.AddParameter("StaffUPIN", objPracticeStaff.StaffUPIN);
            objDBManager.AddParameter("StaffTaxID", objPracticeStaff.StaffTaxID);
            objDBManager.AddParameter("StaffTaxonomyId", objPracticeStaff.StaffTaxonomyId);
            objDBManager.AddParameter("StaffType", objPracticeStaff.StaffType);
            objDBManager.AddParameter("StaffEmailAddress", objPracticeStaff.StaffEmailAddress);
            objDBManager.AddParameter("StaffHomePhone", objPracticeStaff.StaffHomePhone);
            objDBManager.AddParameter("StaffCellPhone", objPracticeStaff.StaffCellPhone);
            objDBManager.AddParameter("StaffFax", objPracticeStaff.StaffFax);
            objDBManager.AddParameter("StaffAddress", objPracticeStaff.StaffAddress);
            objDBManager.AddParameter("StaffCity", objPracticeStaff.StaffCity);
            objDBManager.AddParameter("StaffState", objPracticeStaff.StaffState);
            objDBManager.AddParameter("StaffZip", objPracticeStaff.StaffZip);
            objDBManager.AddParameter("CreatedById", objPracticeStaff.CreatedById);
            objDBManager.AddParameter("CreatedDate", objPracticeStaff.CreatedDate);

            objDBManager.ExecuteNonQuery("PracticeStaff_Add");
            objPracticeStaff.PracticeStaffId = long.Parse(objDBManager.Parameters[0].Value.ToString());
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return objPracticeStaff.PracticeStaffId;
    }
    
    public int Update(PracticeStaff objPracticeStaff, SqlTransaction objSqlTransaction = null)
    {
        DBManager objDBManager = new DBManager(objSqlTransaction);
        int ReturnValue = 0;
        try
        {
            objDBManager.AddParameter("PracticeStaffId", objPracticeStaff.PracticeStaffId, SqlDbType.Int, 4);

            objDBManager.AddParameter("PracticeId", objPracticeStaff.PracticeId);
            objDBManager.AddParameter("PracticeLocationsId", objPracticeStaff.PracticeLocationsId);
            objDBManager.AddParameter("StaffFirstName", objPracticeStaff.StaffFirstName);
            objDBManager.AddParameter("StaffLastName", objPracticeStaff.StaffLastName);
            objDBManager.AddParameter("StaffMiddleName", objPracticeStaff.StaffMiddleName);
            objDBManager.AddParameter("StaffTitle", objPracticeStaff.StaffTitle);
            objDBManager.AddParameter("StaffDateOfBirth", objPracticeStaff.StaffDateOfBirth);
            objDBManager.AddParameter("StaffGender", objPracticeStaff.StaffGender);
            objDBManager.AddParameter("StaffPhoto", objPracticeStaff.StaffPhoto);
            objDBManager.AddParameter("StaffNPI", objPracticeStaff.StaffNPI);
            objDBManager.AddParameter("StaffUPIN", objPracticeStaff.StaffUPIN);
            objDBManager.AddParameter("StaffTaxID", objPracticeStaff.StaffTaxID);
            objDBManager.AddParameter("StaffTaxonomyId", objPracticeStaff.StaffTaxonomyId);
            objDBManager.AddParameter("StaffType", objPracticeStaff.StaffType);
            objDBManager.AddParameter("StaffEmailAddress", objPracticeStaff.StaffEmailAddress);
            objDBManager.AddParameter("StaffHomePhone", objPracticeStaff.StaffHomePhone);
            objDBManager.AddParameter("StaffCellPhone", objPracticeStaff.StaffCellPhone);
            objDBManager.AddParameter("StaffFax", objPracticeStaff.StaffFax);
            objDBManager.AddParameter("StaffAddress", objPracticeStaff.StaffAddress);
            objDBManager.AddParameter("StaffCity", objPracticeStaff.StaffCity);
            objDBManager.AddParameter("StaffState", objPracticeStaff.StaffState);
            objDBManager.AddParameter("StaffZip", objPracticeStaff.StaffZip);
            objDBManager.AddParameter("ModifiedById", objPracticeStaff.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objPracticeStaff.ModifiedDate);

            ReturnValue = objDBManager.ExecuteNonQuery("PracticeStaff_Update");
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return ReturnValue;
    }
    
    public int Delete(PracticeStaff objPracticeStaff, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);
            objDBManager.AddParameter("PracticeStaffId", objPracticeStaff.PracticeStaffId);
            objDBManager.AddParameter("ModifiedById", objPracticeStaff.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objPracticeStaff.ModifiedDate);
            return objDBManager.ExecuteNonQuery("PracticeStaff_Delete");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    
    public DataTable GetById(long PracticeStaffId, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);
            objDBManager.AddParameter("PracticeStaffId", PracticeStaffId);
            return objDBManager.ExecuteDataTable("PracticeStaff_GetById");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    
    public DataSet GetAllFilter(long PracticeId, string Locations, int Rows, int PageNumber, string SortBy, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);

            objDBManager.AddParameter("PracticeId", PracticeId);

            if (!string.IsNullOrEmpty(Locations))
            {
                objDBManager.AddParameter("Locations", Locations);
            }
            
            objDBManager.AddParameter("Rows", Rows);
            objDBManager.AddParameter("PageNumber", PageNumber);
            objDBManager.AddParameter("SortBy", SortBy);

            return objDBManager.ExecuteDataSet("PracticeStaff_GetAllFilter");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    
    public DataSet GetAllFilterByPracticeLocation(long PracticeLocationsId, int Rows, int PageNumber, string SortBy, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);

            objDBManager.AddParameter("PracticeLocationsId", PracticeLocationsId);
            objDBManager.AddParameter("Rows", Rows);
            objDBManager.AddParameter("PageNumber", PageNumber);
            objDBManager.AddParameter("SortBy", SortBy);

            return objDBManager.ExecuteDataSet("PracticeStaff_GetAllFilterByPracticeLocation");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    
    public DataTable GetProvidersByPractice(long PracticeId)
    {
        try
        {
            DBManager objDBManager = new DBManager();

            objDBManager.AddParameter("PracticeId", PracticeId);

            return objDBManager.ExecuteDataTable("PracticeStaff_GetProvidersByPractice");
        }
        catch (Exception ex)
        {
            throw ex;
        }
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

    public DataTable GetProvidersByPractice(long PracticeId, long PracticeLocationsId)
    {
        try
        {
            DBManager objDBManager = new DBManager();

            objDBManager.AddParameter("PracticeId", PracticeId);

            if (PracticeLocationsId != 0)
            {
                objDBManager.AddParameter("PracticeLocationsId", PracticeLocationsId);
            }

            return objDBManager.ExecuteDataTable("PracticeStaff_GetProvidersByPracticeLocationPatientDocuments");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    
    public DataTable GetProvidersByPracticeLocation(long PracticeLocationsId, long PracticeStaffId = 0)
    {
        try
        {
            DBManager objDBManager = new DBManager();

            objDBManager.AddParameter("PracticeId", HttpContext.Current.Profile.GetPropertyValue("PracticeId"));

            if (PracticeLocationsId != 0)
            {
                objDBManager.AddParameter("PracticeLocationsId", PracticeLocationsId);
            }

            if (PracticeStaffId != 0)
            {
                objDBManager.AddParameter("PracticeStaffId", PracticeStaffId);
            }

            return objDBManager.ExecuteDataTable("PracticeStaff_GetProvidersByPracticeLocation");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    
    public DataTable GetPracticeStaffByType(long PracticeId, long PracticeLocationsId, string StaffType)
    {
        try
        {
            DBManager objDBManager = new DBManager();
            
            objDBManager.AddParameter("PracticeId", PracticeId);
            
            if (PracticeLocationsId != 0)
            {
                objDBManager.AddParameter("PracticeLocationsId", PracticeLocationsId);
            }
            
            if (!string.IsNullOrEmpty(StaffType))
            {
                objDBManager.AddParameter("StaffType", StaffType);
            }
            
            return objDBManager.ExecuteDataTable("PracticeStaff_GetPracticeStaffByType");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    
    public DataTable GetPrescriberByPracticeLocation(long PracticeLocationsId, long PracticeId)
    {
        try
        {
            DBManager objDBManager = new DBManager();
            if (PracticeLocationsId != 0)
            {
                objDBManager.AddParameter("PracticeLocationsId", PracticeLocationsId);
            }
            objDBManager.AddParameter("PracticeId", PracticeId);
            return objDBManager.ExecuteDataTable("PracticeStaff_GetPrescriberByPracticeLocation");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    
    public DataTable GetClaimsProvidersByPracticeLocation(int PracticeLocationsId, long PracticeId)
    {
        try
        {
            DBManager objDBManager = new DBManager();
            if (PracticeLocationsId != 0)
            {
                objDBManager.AddParameter("PracticeLocationsId", PracticeLocationsId);
            }
            if (PracticeId != 0)
            {
                objDBManager.AddParameter("PracticeId", PracticeId);
            }
            return objDBManager.ExecuteDataTable("PracticeStaff_GetClaimsProvidersByPracticeLocation");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    
    public string GetTop1ByPracticeLocation(long PracticeLocationsId)
    {
        try
        {
            DBManager objDBManager = new DBManager();

            objDBManager.AddParameter("PracticeLocationsId", PracticeLocationsId);

            return objDBManager.ExecuteScalar("PracticeStaff_GetTop1ByPracticeLocation");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}