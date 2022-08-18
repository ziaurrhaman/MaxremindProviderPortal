
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

public class ClaimNoteCategoriesDB
{
    public long Add(ClaimNoteCategories objClaimNoteCategories, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);

            objDBManager.AddParameter("ClaimNoteCategoriesId", objClaimNoteCategories.ClaimNoteCategoriesId, SqlDbType.BigInt, 8, ParameterDirection.Output);

            objDBManager.AddParameter("PracticeId", objClaimNoteCategories.PracticeId);
            objDBManager.AddParameter("CategoryName", objClaimNoteCategories.CategoryName);
            objDBManager.AddParameter("CreatedById", objClaimNoteCategories.CreatedById);
            objDBManager.AddParameter("CreatedDate", objClaimNoteCategories.CreatedDate);

            objDBManager.ExecuteNonQuery("ClaimNoteCategories_Add");

            return long.Parse(objDBManager.Parameters[0].Value.ToString());
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int Update(ClaimNoteCategories objClaimNoteCategories, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager();

            objDBManager.AddParameter("ClaimNoteCategoriesId", objClaimNoteCategories.ClaimNoteCategoriesId, SqlDbType.BigInt, 8);

            objDBManager.AddParameter("CategoryName", objClaimNoteCategories.CategoryName);

            objDBManager.AddParameter("ModifiedById", objClaimNoteCategories.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objClaimNoteCategories.ModifiedDate);

            return objDBManager.ExecuteNonQuery("ClaimNoteCategories_Update");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int Delete(ClaimNoteCategories objClaimNoteCategories, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);

            objDBManager.AddParameter("ClaimNoteCategoriesId", objClaimNoteCategories.ClaimNoteCategoriesId);

            objDBManager.AddParameter("ModifiedById", objClaimNoteCategories.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objClaimNoteCategories.ModifiedDate);

            return objDBManager.ExecuteNonQuery("ClaimNoteCategories_Delete");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable GetByID(long ClaimNoteCategoriesId, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);

            objDBManager.AddParameter("ClaimNoteCategoriesId", ClaimNoteCategoriesId);

            return objDBManager.ExecuteDataTable("ClaimNoteCategories_GetByID");
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

            return objDBManager.ExecuteDataSet("ClaimNoteCategories_GetAllFilter");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable GetAllByPractice(long PracticeId)
    {
        DBManager objDBManager = new DBManager();

        objDBManager.AddParameter("PracticeId", PracticeId);

        return objDBManager.ExecuteDataTable("ClaimNoteCategories_GetAllByPractice");
    }
}