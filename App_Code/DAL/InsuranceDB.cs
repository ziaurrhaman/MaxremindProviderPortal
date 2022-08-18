using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for InsuranceDB
/// </summary>
public class InsuranceDB
{
    public InsuranceDB()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public void Add(Insurance objInsurance)
    {

        DBManager objDBManager = new DBManager();


        try
        {
            objDBManager.AddParameter("InsuranceID", objInsurance.InsuranceId, SqlDbType.BigInt, 8, ParameterDirection.Output);
            objDBManager.AddParameter("PracticeId", objInsurance.PracticeId);
            objDBManager.AddParameter("Name", objInsurance.Name, SqlDbType.VarChar, 100);
            objDBManager.AddParameter("TaxId", objInsurance.TaxId, SqlDbType.VarChar, 25);
            objDBManager.AddParameter("HeadOfficeAddress", objInsurance.HeadOfficeAddress, SqlDbType.VarChar, 100);
            objDBManager.AddParameter("InsuranceType", objInsurance.InsuranceType, SqlDbType.VarChar, 30);
            objDBManager.AddParameter("InsuranceCategoryId", objInsurance.InsuranceCategoryId);
            objDBManager.AddParameter("InsuranceCategory", objInsurance.InsuranceCategory);
            objDBManager.AddParameter("City", objInsurance.City, SqlDbType.VarChar, 30);
            objDBManager.AddParameter("State", objInsurance.State, SqlDbType.VarChar, 2);
            objDBManager.AddParameter("Zip", objInsurance.Zip, SqlDbType.VarChar, 16);
            objDBManager.AddParameter("ContacatPerson", objInsurance.ContacatPerson, SqlDbType.VarChar, 25);
            objDBManager.AddParameter("Email", objInsurance.Email, SqlDbType.VarChar, 50);
            objDBManager.AddParameter("Fax", objInsurance.Fax, SqlDbType.VarChar, 25);
            objDBManager.AddParameter("Phone1", objInsurance.Phone1, SqlDbType.VarChar, 25);
            objDBManager.AddParameter("Phone2", objInsurance.Phone2, SqlDbType.VarChar, 25);
            objDBManager.AddParameter("Phone3", objInsurance.Phone3, SqlDbType.VarChar, 25);
            objDBManager.AddParameter("CreatedById", objInsurance.CreatedById, SqlDbType.Int, 4);
            objDBManager.AddParameter("CreatedDate", objInsurance.CreatedDate, SqlDbType.DateTime, 8);
            objDBManager.AddParameter("InActive", objInsurance.InActive, SqlDbType.Bit, 1);
            objDBManager.AddParameter("Deleted", objInsurance.Deleted, SqlDbType.Bit, 1);

            objDBManager.ExecuteNonQuery("Insurance_Add");

            objInsurance.InsuranceId = (long)objDBManager.Parameters[0].Value;

        }
        catch (Exception ex)
        {

            throw ex;

        }

        //return objInsurance.InsuranceId;

    }

    public int Update(Insurance objInsurance)
    {

        DBManager objDBManager = new DBManager();
        int ReturnValue = 0;

        try
        {

            objDBManager.AddParameter("InsuranceId", objInsurance.InsuranceId, SqlDbType.BigInt, 8);

            objDBManager.AddParameter("Name", objInsurance.Name, SqlDbType.VarChar, 100);
            objDBManager.AddParameter("TaxId", objInsurance.TaxId, SqlDbType.VarChar, 25);
            objDBManager.AddParameter("HeadOfficeAddress", objInsurance.HeadOfficeAddress, SqlDbType.VarChar, 100);
            objDBManager.AddParameter("InsuranceType", objInsurance.InsuranceType, SqlDbType.VarChar, 30);
            objDBManager.AddParameter("InsuranceCategoryId", objInsurance.InsuranceCategoryId);
            objDBManager.AddParameter("InsuranceCategory", objInsurance.InsuranceCategory);
            objDBManager.AddParameter("City", objInsurance.City, SqlDbType.VarChar, 30);
            objDBManager.AddParameter("State", objInsurance.State, SqlDbType.VarChar, 2);
            objDBManager.AddParameter("Zip", objInsurance.Zip, SqlDbType.VarChar, 16);
            objDBManager.AddParameter("ContacatPerson", objInsurance.ContacatPerson, SqlDbType.VarChar, 25);
            objDBManager.AddParameter("Email", objInsurance.Email, SqlDbType.VarChar, 50);
            objDBManager.AddParameter("Fax", objInsurance.Fax, SqlDbType.VarChar, 25);
            objDBManager.AddParameter("Phone1", objInsurance.Phone1, SqlDbType.VarChar, 25);
            objDBManager.AddParameter("Phone2", objInsurance.Phone2, SqlDbType.VarChar, 25);
            objDBManager.AddParameter("Phone3", objInsurance.Phone3, SqlDbType.VarChar, 25);
            objDBManager.AddParameter("ModifiedById", objInsurance.ModifiedById, SqlDbType.Int, 4);
            objDBManager.AddParameter("ModifiedDate", objInsurance.ModifiedDate, SqlDbType.DateTime, 8);
            objDBManager.AddParameter("InActive", objInsurance.InActive, SqlDbType.Bit, 1);
            objDBManager.AddParameter("Deleted", objInsurance.Deleted, SqlDbType.Bit, 1);

            ReturnValue = objDBManager.ExecuteNonQuery("Insurance_Update");


        }
        catch (Exception ex)
        {
            throw ex;

        }

        return ReturnValue;

    }

    public DataSet GetInsurances(long PracticeId, int Rows, int PageNo, string SortBy, string InsuranceName)
    {
        DBManager ObjDBManager = new DBManager();
        ObjDBManager.AddParameter("PracticeId", PracticeId);
        ObjDBManager.AddParameter("Rows", Rows);
        ObjDBManager.AddParameter("PageNumber", PageNo);
        ObjDBManager.AddParameter("SortBy", SortBy);
        ObjDBManager.AddParameter("InsuranceName", InsuranceName);
        return ObjDBManager.ExecuteDataSet("GetInsurances");
    }
    public DataTable GetAllInsurances(long PracticeId)
    {
        DBManager ObjDBManager = new DBManager();
        ObjDBManager.AddParameter("PracticeId", PracticeId);
        return ObjDBManager.ExecuteDataTable("Insurance_GetAll");
    }

    public DataTable GetAllInsurancesHavingClaims(long PracticeId, string InsuranceName)
    {
        DBManager ObjDBManager = new DBManager();
        ObjDBManager.AddParameter("PracticeId", PracticeId);
        if (!string.IsNullOrEmpty("InsuranceName"))
        {
            ObjDBManager.AddParameter("SearchInsurance", InsuranceName);
        }
        return ObjDBManager.ExecuteDataTable("Insurance_GetAllHavingClaims");
    }
    /**********added by shahid kazmi 1/29/2018******/
    public DataTable GetAllinsurancePayerID()
    {
        DBManager ObjDBManager = new DBManager();
        return ObjDBManager.ExecuteDataTable("Get_insurancePayerID");
    }
    /**********end shahid kazmi 1/29/2018********/
    public DataSet Insurance_GetBySearchCriteria(long PracticeId, string Name, string City, string State, string Zip, int Rows, int PageNumber, string SortBy)
    {
        DBManager ObjDBManager = new DBManager();

        ObjDBManager.AddParameter("PracticeId", PracticeId);

        if (!string.IsNullOrEmpty(Name))
        {
            ObjDBManager.AddParameter("Name", Name);
        }

        if (!string.IsNullOrEmpty(City))
        {
            ObjDBManager.AddParameter("City", City);
        }

        if (!string.IsNullOrEmpty(State))
        {
            ObjDBManager.AddParameter("State", State);
        }

        if (!string.IsNullOrEmpty(Zip))
        {
            ObjDBManager.AddParameter("Zip", Zip);
        }

        ObjDBManager.AddParameter("Rows", Rows);
        ObjDBManager.AddParameter("PageNumber", PageNumber);
        ObjDBManager.AddParameter("SortBy", SortBy);

        return ObjDBManager.ExecuteDataSet("Insurance_GetBySearchCriteria");
    }

    public DataTable GetInsuranceDetails(long insuranceId)
    {
        DBManager ObjDBManager = new DBManager();
        ObjDBManager.AddParameter("InsuranceId", insuranceId);
        return ObjDBManager.ExecuteDataTable("Insurance_GetInsuranceDetails");
    }

    public DataTable GetInsuranceDetailsByPatientInsuranceID(long PatientinsuranceId)
    {
        DBManager ObjDBManager = new DBManager();
        ObjDBManager.AddParameter("@PatientInsuranceId", PatientinsuranceId);
        return ObjDBManager.ExecuteDataTable("Insurance_GetInsuranceDetailsByPatientInsuranceID");
    }

    public DataSet deleteInsurance(long InsuranceId)
    {
        DBManager ObjDBManager = new DBManager();
        ObjDBManager.AddParameter("InsuranceId", InsuranceId);
        return ObjDBManager.ExecuteDataSet("Insurance_Delete");
    }

    public DataSet CheckInsuranceeExistWithNameAndAddress(long insuranceId, long PracticeId, string InsuranceName, string InsuranceAddress, string TaxId)
    {
        DBManager ObjDBManager = new DBManager();

        ObjDBManager.AddParameter("InsuranceId", insuranceId);

        ObjDBManager.AddParameter("PracticeId", PracticeId);

        ObjDBManager.AddParameter("InsuranceName", InsuranceName);
        ObjDBManager.AddParameter("InsuranceAddress", InsuranceAddress);
        ObjDBManager.AddParameter("TaxId", TaxId);

        return ObjDBManager.ExecuteDataSet("Insurance_CheckInsuranceeExistWithNameAndAddress");
    }

    public DataTable GetReceiverId270(long InsuranceId)
    {
        DBManager objDbManager = new DBManager();
        objDbManager.AddParameter("InsuranceId", InsuranceId);

        return objDbManager.ExecuteDataTable("Insurance_GetReceiverId270");
    }
    public DataTable GetSubmitterReceiverPayerId(long InsuranceId)
    {
        DBManager objDbManager = new DBManager();
        objDbManager.AddParameter("InsuranceId", InsuranceId);

        return objDbManager.ExecuteDataTable("Insurance_Get270SubmitterandPayerId");
    }

    //Rizwan kharal Start
    //29 sep 2017
    //getting the Insurance ByName
    public DataTable InsuranceFilterByName(long Practiceid)
    {
        DBManager objDbManager = new DBManager();
        objDbManager.AddParameter("@PracticeId", Practiceid);


        return objDbManager.ExecuteDataTable("ShowInsuranceNames");
    }
    //Rizwan kharal Start
   
    
    /**************added by shahid kazmi 11/29/2017****************/


    public DataTable GetDenialPayerName(long PracticeId)
    {
        DBManager ObjDBManager = new DBManager();
        ObjDBManager.AddParameter("PracticeId", PracticeId);
        return ObjDBManager.ExecuteDataTable("ERAMaster_GetDenialPayerName");
    }

    public DataTable GetAllPayersDetail(long PracticeId, string PayerName, string CheckNumber, string Segment)
    {
        DBManager ObjDBManager = new DBManager();
        ObjDBManager.AddParameter("PracticeId", PracticeId);
        ObjDBManager.AddParameter("PayerName", PayerName);
        ObjDBManager.AddParameter("CheckNumber", CheckNumber);
        ObjDBManager.AddParameter("Segment", Segment);
        return ObjDBManager.ExecuteDataTable("GetPayersDetail");
    }
    public DataTable CheckNoList(long PracticeId, string PayerName, string CheckNumber, string Segment)
    {
        DBManager ObjDBManager = new DBManager();
        ObjDBManager.AddParameter("PracticeId", PracticeId);
        if (!string.IsNullOrEmpty(PayerName))
        {
            ObjDBManager.AddParameter("PayerName", PayerName);
        }
        ObjDBManager.AddParameter("Segment", Segment);
        return ObjDBManager.ExecuteDataTable("GetPayersDetail");
    }
    public DataTable GetPayersByPracticeId(long PracticeId, string SearchValue, string SearchSplitValue)
    {
        DBManager ObjDBManager = new DBManager();
        ObjDBManager.AddParameter("PracticeId", PracticeId);
        if (SearchValue != "")
        {
            ObjDBManager.AddParameter("SearchValue", SearchValue);
        }
        if (SearchSplitValue != "")
        {
            ObjDBManager.AddParameter("@SearchSplitValue", SearchSplitValue);
        }
        return ObjDBManager.ExecuteDataTable("Claim_GetPayersByPracticeId");
    }
    /***************end shahid kazmi 11/29/2017*****************/

    // Rizwan kharal 
    //20 feb 2018
    // unpaid insurances data
    public DataTable GetUnpaidInsurancedata(long PracticeId)
    {
        DBManager ObjDBManager = new DBManager();
        ObjDBManager.AddParameter("PracticeId", PracticeId);
        return ObjDBManager.ExecuteDataTable("UnapiadInsurances");
    }
    
    public DataTable GetAllPayersFromERAMaster(long PracticeId)
    {
        DBManager ObjDBManager = new DBManager();
        ObjDBManager.AddParameter("PracticeId", PracticeId);

        return ObjDBManager.ExecuteDataTable("GetPayerNameFromERAMaster");
    }

    public DataTable GetPayersFromERAMasterByPracticeId(long PracticeId, string SearchValue, string SearchSplitValue)
    {
        DBManager ObjDBManager = new DBManager();
        ObjDBManager.AddParameter("PracticeId", PracticeId);
        if (SearchValue != "")
        {
            ObjDBManager.AddParameter("SearchValue", SearchValue);
        }
        if (SearchSplitValue != "")
        {
            ObjDBManager.AddParameter("@SearchSplitValue", SearchSplitValue);
        }
        return ObjDBManager.ExecuteDataTable("GetPayerNameFromERATable");
    }
    public DataTable GetTotalClaimByPracticeLocation(long PracticeId)
    {
        DBManager ObjDBManager = new DBManager();
        ObjDBManager.AddParameter("PracticeId", PracticeId);
        return ObjDBManager.ExecuteDataTable("GetTotalClaimByPracticeLocation");
    }

    public DataTable CheckedlistSelPay(long ClaimId)
    {
        DBManager ObjDBManager = new DBManager();
        ObjDBManager.AddParameter("ClaimId", ClaimId);

        return ObjDBManager.ExecuteDataTable("CheckedlistSelPay");
    }
}