using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for PracticeLocationsDB
/// </summary>
public class PracticeLocationsDB
{
    public PracticeLocationsDB()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public int Add(PracticeLocations objPracticeLocations, SqlTransaction objSqlTransaction = null)
    {
        DBManager objDBManager = new DBManager(objSqlTransaction);
        try
        {
            objDBManager.AddParameter("PracticeLocationsId", objPracticeLocations.PracticeLocationsId, SqlDbType.Int, 4, ParameterDirection.Output);

            objDBManager.AddParameter("PracticeId", objPracticeLocations.PracticeId);
            objDBManager.AddParameter("Name", objPracticeLocations.Name);
            objDBManager.AddParameter("City", objPracticeLocations.City);
            objDBManager.AddParameter("StateCode", objPracticeLocations.StateCode);
            objDBManager.AddParameter("Zip", objPracticeLocations.Zip);
            objDBManager.AddParameter("Address", objPracticeLocations.Address);
            objDBManager.AddParameter("PrimaryContact", objPracticeLocations.PrimaryContact);
            objDBManager.AddParameter("SecondaryContact", objPracticeLocations.SecondaryContact);
            objDBManager.AddParameter("OtherContact", objPracticeLocations.OtherContact);
            objDBManager.AddParameter("EmailAddress", objPracticeLocations.EmailAddress);
            objDBManager.AddParameter("LicenseNo", objPracticeLocations.LicenseNo);
            objDBManager.AddParameter("TaxId", objPracticeLocations.TaxId);
            objDBManager.AddParameter("NPI", objPracticeLocations.NPI);
            objDBManager.AddParameter("ConcurrentPatients", objPracticeLocations.ConcurrentPatients);
            objDBManager.AddParameter("FaxNo", objPracticeLocations.FaxNo);
            objDBManager.AddParameter("ContactPerson", objPracticeLocations.ContactPerson);
            objDBManager.AddParameter("CreatedById", objPracticeLocations.CreatedById);
            objDBManager.AddParameter("CreatedDate", objPracticeLocations.CreatedDate);
            objDBManager.AddParameter("Bussiness_start_Time", objPracticeLocations.Bussiness_start_Time);
            objDBManager.AddParameter("Bussiness_end_Time", objPracticeLocations.Bussiness_end_Time);

            objDBManager.ExecuteNonQuery("PracticeLocations_Add");
            objPracticeLocations.PracticeLocationsId = int.Parse(objDBManager.Parameters[0].Value.ToString());
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return objPracticeLocations.PracticeLocationsId;
    }

    public int Update(PracticeLocations objPracticeLocations, SqlTransaction objSqlTransaction = null)
    {
        DBManager objDBManager = new DBManager(objSqlTransaction);
        int ReturnValue = 0;
        try
        {
            objDBManager.AddParameter("PracticeLocationsId", objPracticeLocations.PracticeLocationsId, SqlDbType.Int, 4);

            objDBManager.AddParameter("PracticeId", objPracticeLocations.PracticeId);
            objDBManager.AddParameter("Name", objPracticeLocations.Name);
            objDBManager.AddParameter("City", objPracticeLocations.City);
            objDBManager.AddParameter("StateCode", objPracticeLocations.StateCode);
            objDBManager.AddParameter("Zip", objPracticeLocations.Zip);
            objDBManager.AddParameter("Address", objPracticeLocations.Address);
            objDBManager.AddParameter("PrimaryContact", objPracticeLocations.PrimaryContact);
            objDBManager.AddParameter("SecondaryContact", objPracticeLocations.SecondaryContact);
            objDBManager.AddParameter("OtherContact", objPracticeLocations.OtherContact);
            objDBManager.AddParameter("EmailAddress", objPracticeLocations.EmailAddress);
            objDBManager.AddParameter("LicenseNo", objPracticeLocations.LicenseNo);
            objDBManager.AddParameter("TaxId", objPracticeLocations.TaxId);
            objDBManager.AddParameter("NPI", objPracticeLocations.NPI);
            objDBManager.AddParameter("ConcurrentPatients", objPracticeLocations.ConcurrentPatients);
            objDBManager.AddParameter("FaxNo", objPracticeLocations.FaxNo);
            objDBManager.AddParameter("ContactPerson", objPracticeLocations.ContactPerson);
            objDBManager.AddParameter("ModifiedById", objPracticeLocations.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objPracticeLocations.ModifiedDate);
            objDBManager.AddParameter("Bussiness_start_Time", objPracticeLocations.Bussiness_start_Time);
            objDBManager.AddParameter("Bussiness_end_Time", objPracticeLocations.Bussiness_end_Time);

            ReturnValue = objDBManager.ExecuteNonQuery("PracticeLocations_Update");
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return ReturnValue;
    }

    public int Delete(PracticeLocations objPracticeLocations, SqlTransaction objSqlTransaction = null)
    {

        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);
            objDBManager.AddParameter("PracticeLocationsId", objPracticeLocations.PracticeLocationsId);
            objDBManager.AddParameter("ModifiedById", objPracticeLocations.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objPracticeLocations.ModifiedDate);
            return objDBManager.ExecuteNonQuery("PracticeLocations_Delete");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable GetByID(long LocationId, SqlTransaction objSqlTransaction = null)
    {

        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);
            objDBManager.AddParameter("ID", LocationId);

            return objDBManager.ExecuteDataTable("PracticeLocations_GetByID");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet GetPracticeLocationsAndProviderTypes(long PracticeId)
    {
        try
        {
            DBManager objDBManager = new DBManager();
            objDBManager.AddParameter("PracticeId", PracticeId);
            return objDBManager.ExecuteDataSet("Settings_GetLocationsAndProviderTypes");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable GetPracticeLocationsByPractice(long PracticeId)
    {
        try
        {
            DBManager objDBManager = new DBManager();

            objDBManager.AddParameter("PracticeId", PracticeId);

            return objDBManager.ExecuteDataTable("PracticeLocations_GetAllByPracticeId");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable GetPracticeLocationsByViewRights(long PracticeId, string PracticeLocationsId)
    {
        try
        {
            DBManager objDBManager = new DBManager();

            objDBManager.AddParameter("PracticeId", PracticeId);
            if (string.IsNullOrEmpty(PracticeLocationsId))
            {
                objDBManager.AddParameter("PracticeLocationsId", "");
            }
            else
                objDBManager.AddParameter("PracticeLocationsId", PracticeLocationsId);
            return objDBManager.ExecuteDataTable("PracticeLocations_GetPracticeLocationsByViewRights");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable PracaticeLocation_GetIdByPracticeId(long PracticeId)
    {
        DBManager objDbManager = new DBManager();
        objDbManager.AddParameter("@PracticeId", PracticeId);
        return objDbManager.ExecuteDataTable("PracaticeLocation_GetIdByPracticeId");
    }

    public DataTable GetLocationStatesUTC(long PracticeId, SqlTransaction objDBTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objDBTransaction);

            objDBManager.AddParameter("PracticeId", PracticeId);

            return objDBManager.ExecuteDataTable("PracaticeLocations_GetLocationStatesUTC");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataSet GetClaimLocationYearMonth(long PracticeId, string PracticeLocationsId, string ProviderType, string Provider, long year)
    {
        try
        {
            DBManager objDBManager = new DBManager();

            objDBManager.AddParameter("PracticeId", PracticeId);
            if (!string.IsNullOrEmpty(PracticeLocationsId))
            {

                objDBManager.AddParameter("PracticeLocationsId", PracticeLocationsId);

            }

            if (!string.IsNullOrEmpty(ProviderType))
            {
                objDBManager.AddParameter("ProviderType", ProviderType);
            }
            if (!string.IsNullOrEmpty(Provider))
            {
                objDBManager.AddParameter("Provider", Provider);
            }

            if (year != null)
            {
                if (year != 0)
                {
                    objDBManager.AddParameter("year", year);
                }
            }

            return objDBManager.ExecuteDataSet("Report_GetClaimLocationYearMonth");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

}