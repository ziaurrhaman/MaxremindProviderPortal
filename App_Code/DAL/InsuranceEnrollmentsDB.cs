using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for InsuranceEnrollmentsDB
/// </summary>
public class InsuranceEnrollmentsDB
{
    public long Add(InsuranceEnrollments objInsuranceEnrollments, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);

            objDBManager.AddParameter("InsuranceEnrollmentId", objInsuranceEnrollments.InsuranceEnrollmentId, SqlDbType.BigInt, 8, ParameterDirection.Output);

            objDBManager.AddParameter("@PracticeId", objInsuranceEnrollments.PracticeId);
            objDBManager.AddParameter("@InsuranceId", objInsuranceEnrollments.InsuranceId);
            objDBManager.AddParameter("@ClaimStatusId", objInsuranceEnrollments.ClaimStatusId);
            objDBManager.AddParameter("@EligibilityStatusId", objInsuranceEnrollments.EligibilityStatusId);
            objDBManager.AddParameter("@ERAStatusId", objInsuranceEnrollments.ERAStatusId);
            objDBManager.AddParameter("@CreatedById", objInsuranceEnrollments.CreatedById);
            objDBManager.AddParameter("@CreatedDate", objInsuranceEnrollments.CreatedDate);
            objDBManager.AddParameter("@Notes", objInsuranceEnrollments.Notes);


            objDBManager.ExecuteNonQuery("InsuranceEnrollments_Add");

            return long.Parse(objDBManager.Parameters[0].Value.ToString());
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int Update(InsuranceEnrollments objInsuranceEnrollments, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager();

            objDBManager.AddParameter("InsuranceEnrollmentId", objInsuranceEnrollments.InsuranceEnrollmentId, SqlDbType.BigInt, 8);

            objDBManager.AddParameter("PracticeId", objInsuranceEnrollments.PracticeId);
            objDBManager.AddParameter("InsuranceId", objInsuranceEnrollments.InsuranceId);
            objDBManager.AddParameter("ClaimStatusId", objInsuranceEnrollments.ClaimStatusId);
            objDBManager.AddParameter("EligibilityStatusId", objInsuranceEnrollments.EligibilityStatusId);
            objDBManager.AddParameter("ERAStatusId", objInsuranceEnrollments.ERAStatusId);
            objDBManager.AddParameter("ModifiedById", objInsuranceEnrollments.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objInsuranceEnrollments.ModifiedDate);
            objDBManager.AddParameter("@Notes", objInsuranceEnrollments.Notes);

            return objDBManager.ExecuteNonQuery("InsuranceEnrollments_Update");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int Delete(InsuranceEnrollments objInsuranceEnrollments, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);

            objDBManager.AddParameter("@InsuranceEnrollmentId", objInsuranceEnrollments.InsuranceEnrollmentId);

            objDBManager.AddParameter("@modifiedbyid", objInsuranceEnrollments.ModifiedById);
            objDBManager.AddParameter("@ModifiedDate", objInsuranceEnrollments.ModifiedDate);

            return objDBManager.ExecuteNonQuery("InsuranceEnrollments_Delete");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable GetByID(long InsuranceEnrollmentsId, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);

            objDBManager.AddParameter("InsuranceEnrollmentsId", InsuranceEnrollmentsId);

            return objDBManager.ExecuteDataTable("InsuranceEnrollments_GetByID");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet GetAllFilter(int Rows, int PageNumber, long practiceId, string insuranceName, string payerId, string SortBy)
    {
        try
        {
            DBManager objDBManager = new DBManager();

            objDBManager.AddParameter("Rows", Rows);
            objDBManager.AddParameter("PageNumber", PageNumber);
            objDBManager.AddParameter("PracticeId", practiceId);

            if (!string.IsNullOrEmpty(SortBy))
            {
                objDBManager.AddParameter("SortBy", SortBy);
            }
            if (!string.IsNullOrEmpty(insuranceName))
            {
                objDBManager.AddParameter("InsuranceName", insuranceName);
            }
            if (!string.IsNullOrEmpty(payerId))
            {
                objDBManager.AddParameter("PayerId", payerId);
            }

            return objDBManager.ExecuteDataSet("InsuranceEnrollments_GetAllFilter");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable GetEnrollmentStatuses(SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);
            return objDBManager.ExecuteDataTable("GetEnrollmentStatuses");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}