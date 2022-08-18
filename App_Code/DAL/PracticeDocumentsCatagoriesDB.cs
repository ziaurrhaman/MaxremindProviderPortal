using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for PracticeDocumentsCatagoriesDB
/// </summary>
public class PracticeDocumentsCatagoriesDB
{
	public PracticeDocumentsCatagoriesDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public long Add(PracticeDocumentsCatagories objPracticeDocumentsCatagories, SqlTransaction objSqlTransaction = null)
    {
        DBManager objDBManager = new DBManager(objSqlTransaction);
        try
        {
            objDBManager.AddParameter("PracticeDocumentsCatagoriesId", objPracticeDocumentsCatagories.PracticeDocumentsCatagoriesId, SqlDbType.Int, 4, ParameterDirection.Output);

            objDBManager.AddParameter("PracticeId", objPracticeDocumentsCatagories.PracticeId);
            objDBManager.AddParameter("DocumentsCategoryName", objPracticeDocumentsCatagories.DocumentsCategoryName);
            objDBManager.AddParameter("CreatedById", objPracticeDocumentsCatagories.CreatedById);
            objDBManager.AddParameter("CreatedDate", objPracticeDocumentsCatagories.CreatedDate);

            objDBManager.ExecuteNonQuery("PracticeDocumentsCatagories_Add");
            objPracticeDocumentsCatagories.PracticeDocumentsCatagoriesId = long.Parse(objDBManager.Parameters[0].Value.ToString());
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return objPracticeDocumentsCatagories.PracticeDocumentsCatagoriesId;
    }

    public int Update(PracticeDocumentsCatagories objPracticeDocumentsCatagories, SqlTransaction objSqlTransaction = null)
    {
        DBManager objDBManager = new DBManager(objSqlTransaction);
        int ReturnValue = 0;
        try
        {
            objDBManager.AddParameter("PracticeDocumentsCatagoriesId", objPracticeDocumentsCatagories.PracticeDocumentsCatagoriesId, SqlDbType.Int, 4);

            objDBManager.AddParameter("PracticeId", objPracticeDocumentsCatagories.PracticeId);
            objDBManager.AddParameter("DocumentsCategoryName", objPracticeDocumentsCatagories.DocumentsCategoryName);
            objDBManager.AddParameter("ModifiedById", objPracticeDocumentsCatagories.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objPracticeDocumentsCatagories.ModifiedDate);

            ReturnValue = objDBManager.ExecuteNonQuery("PracticeDocumentsCatagories_Update");
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ReturnValue;
    }

    public int Delete(PracticeDocumentsCatagories objPracticeDocumentsCatagories, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);

            objDBManager.AddParameter("PracticeDocumentsCatagoriesId", objPracticeDocumentsCatagories.PracticeDocumentsCatagoriesId);
            objDBManager.AddParameter("ModifiedById", objPracticeDocumentsCatagories.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objPracticeDocumentsCatagories.ModifiedDate);

            return objDBManager.ExecuteNonQuery("PracticeDocumentsCatagories_Delete");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable GetAllByPractice(long PracticeId, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);

            objDBManager.AddParameter("PracticeId", PracticeId);

            return objDBManager.ExecuteDataTable("PracticeDocumentsCatagories_GetAllByPractice");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}