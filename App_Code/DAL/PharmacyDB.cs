using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for PharmacyDB
/// </summary>
public class PharmacyDB
{
	public PharmacyDB()
	{
		
	}
    public int Add(Pharmacy objPharmacy)
    {

        DBManager objDBManager = new DBManager();


        try
        {
            objDBManager.AddParameter("ID", objPharmacy.PharmacyId, SqlDbType.Int, 4, ParameterDirection.Output);

            objDBManager.AddParameter("PharmacyCode", objPharmacy.PharmacyCode, SqlDbType.Int, 4);
            objDBManager.AddParameter("Status", objPharmacy.Status, SqlDbType.NVarChar, 1);
            objDBManager.AddParameter("NCPDP_Id", objPharmacy.NCPDP_Id, SqlDbType.NVarChar, 10);
            objDBManager.AddParameter("Store", objPharmacy.Store, SqlDbType.NVarChar, 20);
            objDBManager.AddParameter("StoreName", objPharmacy.StoreName, SqlDbType.NVarChar, 50);
            objDBManager.AddParameter("Address1", objPharmacy.Address1, SqlDbType.NVarChar, 100);
            objDBManager.AddParameter("Address2", objPharmacy.Address2, SqlDbType.NVarChar, 100);
            objDBManager.AddParameter("Telephone1", objPharmacy.Telephone1, SqlDbType.NVarChar, 25);
            objDBManager.AddParameter("Telephone2", objPharmacy.Telephone2, SqlDbType.NVarChar, 25);
            objDBManager.AddParameter("Fax", objPharmacy.Fax, SqlDbType.NVarChar, 25);
            objDBManager.AddParameter("PhoneAlt1", objPharmacy.PhoneAlt1, SqlDbType.NVarChar, 25);
            objDBManager.AddParameter("PhoneAlt2", objPharmacy.PhoneAlt2, SqlDbType.NVarChar, 25);
            objDBManager.AddParameter("PhoneAlt3", objPharmacy.PhoneAlt3, SqlDbType.NVarChar, 25);
            objDBManager.AddParameter("PhoneAlt4", objPharmacy.PhoneAlt4, SqlDbType.NVarChar, 25);
            objDBManager.AddParameter("PhoneAlt5", objPharmacy.PhoneAlt5, SqlDbType.NVarChar, 25);
            objDBManager.AddParameter("City", objPharmacy.City, SqlDbType.NVarChar, 100);
            objDBManager.AddParameter("State", objPharmacy.State, SqlDbType.Int, 4);
            objDBManager.AddParameter("Zip", objPharmacy.Zip, SqlDbType.NVarChar, 15);
            objDBManager.AddParameter("TouchDate", objPharmacy.TouchDate, SqlDbType.DateTime, 8);
            objDBManager.AddParameter("TypeID", objPharmacy.TypeID, SqlDbType.Int, 4);
            objDBManager.AddParameter("DetailTypeID", objPharmacy.DetailTypeID, SqlDbType.SmallInt, 2);

            objDBManager.ExecuteNonQuery("Pharmacy_Add");

            objPharmacy.PharmacyId = Convert.ToInt32( objDBManager.Parameters[0].Value);

        }
        catch (Exception ex)
        {

            throw ex;

        }

        return objPharmacy.PharmacyId;

    }

    public int Update(Pharmacy objPharmacy)
    {

        DBManager objDBManager = new DBManager();
        int ReturnValue = 0;

        try
        {

            objDBManager.AddParameter("ID", objPharmacy.PharmacyId, SqlDbType.Int, 4);

            objDBManager.AddParameter("PharmacyCode", objPharmacy.PharmacyCode, SqlDbType.Int, 4);
            objDBManager.AddParameter("Status", objPharmacy.Status, SqlDbType.NVarChar, 1);
            objDBManager.AddParameter("NCPDP_Id", objPharmacy.NCPDP_Id, SqlDbType.NVarChar, 10);
            objDBManager.AddParameter("Store", objPharmacy.Store, SqlDbType.NVarChar, 20);
            objDBManager.AddParameter("StoreName", objPharmacy.StoreName, SqlDbType.NVarChar, 50);
            objDBManager.AddParameter("Address1", objPharmacy.Address1, SqlDbType.NVarChar, 100);
            objDBManager.AddParameter("Address2", objPharmacy.Address2, SqlDbType.NVarChar, 100);
            objDBManager.AddParameter("Telephone1", objPharmacy.Telephone1, SqlDbType.NVarChar, 25);
            objDBManager.AddParameter("Telephone2", objPharmacy.Telephone2, SqlDbType.NVarChar, 25);
            objDBManager.AddParameter("Fax", objPharmacy.Fax, SqlDbType.NVarChar, 25);
            objDBManager.AddParameter("PhoneAlt1", objPharmacy.PhoneAlt1, SqlDbType.NVarChar, 25);
            objDBManager.AddParameter("PhoneAlt2", objPharmacy.PhoneAlt2, SqlDbType.NVarChar, 25);
            objDBManager.AddParameter("PhoneAlt3", objPharmacy.PhoneAlt3, SqlDbType.NVarChar, 25);
            objDBManager.AddParameter("PhoneAlt4", objPharmacy.PhoneAlt4, SqlDbType.NVarChar, 25);
            objDBManager.AddParameter("PhoneAlt5", objPharmacy.PhoneAlt5, SqlDbType.NVarChar, 25);
            objDBManager.AddParameter("City", objPharmacy.City, SqlDbType.NVarChar, 100);
            objDBManager.AddParameter("State", objPharmacy.State, SqlDbType.Int, 4);
            objDBManager.AddParameter("Zip", objPharmacy.Zip, SqlDbType.NVarChar, 15);
            objDBManager.AddParameter("TouchDate", objPharmacy.TouchDate, SqlDbType.DateTime, 8);
            objDBManager.AddParameter("TypeID", objPharmacy.TypeID, SqlDbType.Int, 4);
            objDBManager.AddParameter("DetailTypeID", objPharmacy.DetailTypeID, SqlDbType.SmallInt, 2);

            ReturnValue = objDBManager.ExecuteNonQuery("Pharmacy_Update");


        }
        catch (Exception ex)
        {
            throw ex;

        }

        return ReturnValue;

    }

    public int Pharmacy_GetCountSearch(string Name, string City, string State, string Zip, string Address, string Phone, string Fax)
    {
        DBManager ObjDBManger = new DBManager();
        if (!string.IsNullOrEmpty(Name))
        {
            ObjDBManger.AddParameter("Name", Name, SqlDbType.VarChar, 20);
        }
        if (!string.IsNullOrEmpty(City))
        {
            ObjDBManger.AddParameter("City", City, SqlDbType.VarChar, 100);
        }

        if (!string.IsNullOrEmpty(State))
        {
            ObjDBManger.AddParameter("State", State, SqlDbType.VarChar, 2);
        }

        if (!string.IsNullOrEmpty(Zip))
        {
            ObjDBManger.AddParameter("Zip", Zip, SqlDbType.VarChar, 16);
        }

        if (!string.IsNullOrEmpty(Address))
        {
            ObjDBManger.AddParameter("Address", Address, SqlDbType.VarChar, 100);
        }
        if (!string.IsNullOrEmpty(Phone))
        {
            ObjDBManger.AddParameter("Phone", Phone, SqlDbType.VarChar, 25);
        }

        if (!string.IsNullOrEmpty(Fax))
        {
            ObjDBManger.AddParameter("Fax", Fax, SqlDbType.VarChar, 25);
        }

        int TotalRecord = int.Parse(ObjDBManger.ExecuteScalar("Pharmacy_GetCountSearch"));
        return TotalRecord;

    }
    public DataTable Pharmacy_GetBySearchCriteria(string Name, string City, string State, string Zip, string Address, string Phone, string Fax, int MaximumRecords, int StartRowIndex)
    {
        DBManager ObjDBManger = new DBManager();
        ObjDBManger.AddParameter("StartRowIndex", StartRowIndex );
        ObjDBManger.AddParameter("MaximumRows", MaximumRecords);
        if (!string.IsNullOrEmpty(Name))
        {
            ObjDBManger.AddParameter("Name", Name, SqlDbType.VarChar, 20);
        }
        if(!string.IsNullOrEmpty(City))
        {
         ObjDBManger.AddParameter("City", City, SqlDbType.VarChar, 100);
        }

        if(!string.IsNullOrEmpty(State))
        {
            ObjDBManger.AddParameter("State", State, SqlDbType.VarChar, 2);
        }

        if (!string.IsNullOrEmpty(Zip))
        {
            ObjDBManger.AddParameter("Zip", Zip, SqlDbType.VarChar, 16);
        }

        if (!string.IsNullOrEmpty(Address))
        {
            ObjDBManger.AddParameter("Address", Address, SqlDbType.VarChar, 100);
        }
        if (!string.IsNullOrEmpty(Phone))
        {
            ObjDBManger.AddParameter("Phone", Phone, SqlDbType.VarChar, 25);
        }
       
        if(!string.IsNullOrEmpty(Fax))
        {
            ObjDBManger.AddParameter("Fax", Fax, SqlDbType.VarChar, 25);
        }
        DataTable ddtResult = ObjDBManger.ExecuteDataTable("Pharmacy_GetBySearchCriteria");
        return ddtResult;
    }

    public DataSet Pharmacy_GetAllBySearchCriteria(string storeName, string Address, string City, string State, string Zip, string Phone, string Fax, int rows, int pageNumber, string sortBy)
    {
        DBManager objDbManager = new DBManager();

        if (!string.IsNullOrEmpty(storeName))
        {
            objDbManager.AddParameter("@StoreName", storeName);
        }

        if (!string.IsNullOrEmpty(Address))
        {
            objDbManager.AddParameter("@Address", Address);
        }
        if (!string.IsNullOrEmpty(City))
        {
            objDbManager.AddParameter("@City", City);
        }
        if (!string.IsNullOrEmpty(State))
        {
            objDbManager.AddParameter("@State", State);
        }
        if (!string.IsNullOrEmpty(Zip))
        {
            objDbManager.AddParameter("@Zip", Zip);
        }
        if (!string.IsNullOrEmpty(Phone))
        {
            objDbManager.AddParameter("@Phone", Phone);
        }
        if (!string.IsNullOrEmpty(Fax))
        {
            objDbManager.AddParameter("@Fax", Fax);
        }

        objDbManager.AddParameter("@Rows", rows);
        objDbManager.AddParameter("@PageNumber", pageNumber);
        objDbManager.AddParameter("@SortBy", sortBy);
        return objDbManager.ExecuteDataSet("Pharmacy_GetAllBySearchCriteria");

    }

}