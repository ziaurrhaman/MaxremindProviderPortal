
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

public class PTLReasonsDB
{


    //rizwan kharal start
    //9 oct 2017
    //  Showing the PtlReason list on Home page in Pendng transition
    public DataSet ShowPTlReasons(long practiceId)
    {
        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("@practiseId", practiceId);
        return objDBManager.ExecuteDataSet("ShowPTLReasons");
    }
    //Rizwan End

    //Coded befor my development 9 oct 2017
    public long Add(PTLReasons objPTLReasons, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);

            objDBManager.AddParameter("PTLReasonsId", objPTLReasons.PTLReasonsId, SqlDbType.BigInt, 8, ParameterDirection.Output);

            objDBManager.AddParameter("PracticeId", objPTLReasons.PracticeId);
            objDBManager.AddParameter("PracticeLocationsId", objPTLReasons.PracticeLocationsId);

            objDBManager.AddParameter("PTLType", objPTLReasons.PTLType);
            objDBManager.AddParameter("Reason", objPTLReasons.Reason);

            objDBManager.AddParameter("CreatedById", objPTLReasons.CreatedById);
            objDBManager.AddParameter("CreatedDate", objPTLReasons.CreatedDate);

            objDBManager.ExecuteNonQuery("PTLReasons_Add");

            return long.Parse(objDBManager.Parameters[0].Value.ToString());
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int Update(PTLReasons objPTLReasons, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager();

            objDBManager.AddParameter("PTLReasonsId", objPTLReasons.PTLReasonsId, SqlDbType.BigInt, 8);

            objDBManager.AddParameter("PTLType", objPTLReasons.PTLType);
            objDBManager.AddParameter("Reason", objPTLReasons.Reason);

            objDBManager.AddParameter("ModifiedById", objPTLReasons.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objPTLReasons.ModifiedDate);

            return objDBManager.ExecuteNonQuery("PTLReasons_Update");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int Delete(PTLReasons objPTLReasons, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);

            objDBManager.AddParameter("PTLReasonsId", objPTLReasons.PTLReasonsId);

            objDBManager.AddParameter("ModifiedById", objPTLReasons.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objPTLReasons.ModifiedDate);

            return objDBManager.ExecuteNonQuery("PTLReasons_Delete");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable GetByID(long PTLReasonsId, long PracticeId, long PracticeLocationsId = 0, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);

            objDBManager.AddParameter("PTLReasonsId", PTLReasonsId);

            objDBManager.AddParameter("PracticeId", PracticeId);

            if (PracticeLocationsId != 0)
            {
                objDBManager.AddParameter("PracticeLocationsId", PracticeLocationsId);
            }

            return objDBManager.ExecuteDataTable("PTLReasons_GetByID");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet PTL_LoadReasons_Patient(long PatientId, long PracticeId, long PracticeLocationsId = 0, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);

            objDBManager.AddParameter("PatientId", PatientId);

           // objDBManager.AddParameter("PracticeId", PracticeId);

            if (PracticeLocationsId != 0)
            {
                objDBManager.AddParameter("PracticeLocationsId", PracticeLocationsId);
            }

            return objDBManager.ExecuteDataSet("PTLReasons_LoadPTLReasons_Patient");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet PTL_LoadReasons_Claim(long ClaimId, long PracticeId, long PracticeLocationsId = 0, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);

            objDBManager.AddParameter("ClaimId", ClaimId);

            //objDBManager.AddParameter("PracticeId", PracticeId);

            if (PracticeLocationsId != 0)
            {
                objDBManager.AddParameter("PracticeLocationsId", PracticeLocationsId);
            }

            return objDBManager.ExecuteDataSet("PTLReasons_LoadPTLReasons_Claim");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable GetAllPTLReasonsByType(string PTLType, long PracticeLocationsId = 0, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);

            //objDBManager.AddParameter("PracticeId", PracticeId);

            if (PracticeLocationsId != 0)
            {
                objDBManager.AddParameter("PracticeLocationsId", PracticeLocationsId);
            }

            objDBManager.AddParameter("PTLType", PTLType);

            return objDBManager.ExecuteDataTable("PTLReasons_GetAllPTLReasonsByType");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet GetAllPTLReasons(long PracticeLocationsId = 0, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);

            //objDBManager.AddParameter("PracticeId", PracticeId);

            if (PracticeLocationsId != 0)
            {
                objDBManager.AddParameter("PracticeLocationsId", PracticeLocationsId);
            }

            return objDBManager.ExecuteDataSet("PTLReasons_GetAllPTLReasons");
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

            return objDBManager.ExecuteDataSet("PTLReasons_GetAllFilter");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet TotalCounts(long PracticeId)
    {
        try
        {
            DBManager objDBManager = new DBManager();

            objDBManager.AddParameter("PracticeId", PracticeId);

            return objDBManager.ExecuteDataSet("PTL_TotalCounts");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}