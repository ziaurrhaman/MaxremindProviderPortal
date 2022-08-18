
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

public class ClaimNotesDB
{
    public long Add(ClaimNotes objClaimNotes, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);

            objDBManager.AddParameter("ClaimNotesId", objClaimNotes.ClaimNotesId, SqlDbType.BigInt, 8, ParameterDirection.Output);

            objDBManager.AddParameter("PracticeId", objClaimNotes.PracticeId);
            objDBManager.AddParameter("ClaimId", objClaimNotes.ClaimId);
            objDBManager.AddParameter("PatientId", objClaimNotes.PatientId);

            objDBManager.AddParameter("ClaimNoteCategoriesId", objClaimNotes.ClaimNoteCategoriesId);
            objDBManager.AddParameter("Notes", objClaimNotes.Notes);

            objDBManager.AddParameter("CreatedById", objClaimNotes.CreatedById);
            objDBManager.AddParameter("CreatedDate", objClaimNotes.CreatedDate);

            objDBManager.ExecuteNonQuery("ClaimNotes_Add");

            return long.Parse(objDBManager.Parameters[0].Value.ToString());
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int Update(ClaimNotes objClaimNotes, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager();

            objDBManager.AddParameter("ClaimNotesId", objClaimNotes.ClaimNotesId, SqlDbType.BigInt, 8);

            objDBManager.AddParameter("ClaimNoteCategoriesId", objClaimNotes.ClaimNoteCategoriesId);
            objDBManager.AddParameter("Notes", objClaimNotes.Notes);

            objDBManager.AddParameter("ModifiedById", objClaimNotes.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objClaimNotes.ModifiedDate);

            return objDBManager.ExecuteNonQuery("ClaimNotes_Update");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int Delete(ClaimNotes objClaimNotes, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);

            objDBManager.AddParameter("ClaimNotesId", objClaimNotes.ClaimNotesId);

            objDBManager.AddParameter("ModifiedById", objClaimNotes.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objClaimNotes.ModifiedDate);

            return objDBManager.ExecuteNonQuery("ClaimNotes_Delete");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable GetByID(long ClaimNotesId, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);

            objDBManager.AddParameter("ClaimNotesId", ClaimNotesId);

            return objDBManager.ExecuteDataTable("ClaimNotes_GetByID");
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

            return objDBManager.ExecuteDataSet("ClaimNotes_GetAllFilter");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable GetAllByClaim(long ClaimId, long PracticeId)
    {
        try
        {
            DBManager objDBManager = new DBManager();
            
            objDBManager.AddParameter("ClaimId", ClaimId);
            objDBManager.AddParameter("PracticeId", PracticeId);
            
            return objDBManager.ExecuteDataTable("ClaimNotes_GetAllByClaim");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}