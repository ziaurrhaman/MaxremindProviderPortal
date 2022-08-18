using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for ROSCategoriesDB
/// </summary>
public class ROSCategoriesDB
{
	public ROSCategoriesDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public int Add(ROSCategories objROSCategories)
    {
        DBManager objDBManager = new DBManager();
        try
        {
            objDBManager.AddParameter("ROSCategoryId", objROSCategories.ROSCategoryId, SqlDbType.Int, 4, ParameterDirection.Output);
            objDBManager.AddParameter("ROSTemplatesId", objROSCategories.ROSTemplatesId);
            objDBManager.AddParameter("CategoryName", objROSCategories.CategoryName);
            objDBManager.AddParameter("PracticeId", objROSCategories.PracticeId);
            objDBManager.AddParameter("Position", objROSCategories.Position);
            objDBManager.AddParameter("CreatedById", objROSCategories.CreatedById);
            objDBManager.AddParameter("CreatedDate", objROSCategories.CreatedDate);
            objDBManager.ExecuteNonQuery("ROSCategories_Add");
            objROSCategories.ROSCategoryId = int.Parse(objDBManager.Parameters[0].Value.ToString());
        }
        catch (Exception ex)
        {
            
            throw ex;
        }
        return objROSCategories.ROSCategoryId;
    }

    public int Update(ROSCategories objROSCategories, SqlTransaction objSqlTransaction = null)
    {
        DBManager objDBManager = new DBManager(objSqlTransaction);        
        try
        {
            objDBManager.AddParameter("ROSCategoryId", objROSCategories.ROSCategoryId);
            objDBManager.AddParameter("ROSTemplatesId", objROSCategories.ROSTemplatesId);
            objDBManager.AddParameter("CategoryName", objROSCategories.CategoryName);
            objDBManager.AddParameter("PracticeId", objROSCategories.PracticeId);
            objDBManager.AddParameter("Position", objROSCategories.Position);
            objDBManager.AddParameter("ModifiedById", objROSCategories.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objROSCategories.ModifiedDate);

            return objDBManager.ExecuteNonQuery("ROSCategories_Update");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int Delete(ROSCategories objROSCategories, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);
            objDBManager.AddParameter("ROSCategoryId", objROSCategories.ROSCategoryId);
            objDBManager.AddParameter("ModifiedById", objROSCategories.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objROSCategories.ModifiedDate);

            return objDBManager.ExecuteNonQuery("ROSCategories_Delete");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    
    public DataTable GetROSCategories(Int64 practiceId)
    {
        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("PracticeId", practiceId);
        return objDBManager.ExecuteDataTable("Chart_GetROSCategories");
    }
    
    //Please waqas bhai (From Haseeb)
    public DataTable GetROSCategoriesByTemplateId(int ROSTemplatesId)
    {
        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("ROSTemplatesId", ROSTemplatesId);
        return objDBManager.ExecuteDataTable("ROSCategories_GetByROSTemplatesId");
    }

}