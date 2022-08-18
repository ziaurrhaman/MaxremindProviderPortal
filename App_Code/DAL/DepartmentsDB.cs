
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

public class DepartmentsDB
{
    public long Add(Departments objDepartments, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);

            objDBManager.AddParameter("DepartmentsId", objDepartments.DepartmentsId, SqlDbType.BigInt, 8, ParameterDirection.Output);


            objDBManager.AddParameter("PracticeId", objDepartments.PracticeId);
            objDBManager.AddParameter("PracticeLocationsId", objDepartments.PracticeLocationsId);
            objDBManager.AddParameter("DepartmentName", objDepartments.DepartmentName);
            objDBManager.AddParameter("CreatedById", objDepartments.CreatedById);
            objDBManager.AddParameter("CreatedDate", objDepartments.CreatedDate);

            objDBManager.ExecuteNonQuery("Departments_Add");

            return long.Parse(objDBManager.Parameters[0].Value.ToString());
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    
    public int Update(Departments objDepartments, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager();

            objDBManager.AddParameter("DepartmentsId", objDepartments.DepartmentsId, SqlDbType.BigInt, 8);
            
            objDBManager.AddParameter("DepartmentName", objDepartments.DepartmentName);
            
            objDBManager.AddParameter("ModifiedById", objDepartments.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objDepartments.ModifiedDate);

            return objDBManager.ExecuteNonQuery("Departments_Update");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int UpdateDepartmentAccoutingCode(Departments objDepartments, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager();
            
            objDBManager.AddParameter("PracticeId", objDepartments.PracticeId);
            objDBManager.AddParameter("DepartmentName", objDepartments.DepartmentName);
            objDBManager.AddParameter("DepartmentAccoutingCode", objDepartments.DepartmentAccoutingCode);
            
            objDBManager.AddParameter("ModifiedById", objDepartments.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objDepartments.ModifiedDate);
            
            return objDBManager.ExecuteNonQuery("Departments_UpdateDepartmentAccoutingCode");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    
    public int Delete(Departments objDepartments, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);
            
            objDBManager.AddParameter("DepartmentsId", objDepartments.DepartmentsId);
            
            objDBManager.AddParameter("ModifiedById", objDepartments.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objDepartments.ModifiedDate);
            
            return objDBManager.ExecuteNonQuery("Departments_Delete");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    
    public DataTable GetByID(long DepartmentsId, long PracticeId, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);
            
            objDBManager.AddParameter("DepartmentsId", DepartmentsId);
            objDBManager.AddParameter("PracticeId", PracticeId);
            
            return objDBManager.ExecuteDataTable("Departments_GetByID");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet GetAllFilter(long PracticeId, long PracticeLocationsId, int Rows, int PageNumber, string SortBy)
    {
        try
        {
            DBManager objDBManager = new DBManager();
            
            objDBManager.AddParameter("PracticeId", PracticeId);
            
            if (PracticeLocationsId != 0)
            {
                objDBManager.AddParameter("PracticeLocationsId", PracticeLocationsId);
            }
            
            objDBManager.AddParameter("Rows", Rows);
            objDBManager.AddParameter("PageNumber", PageNumber);
            
            if (!string.IsNullOrEmpty(SortBy))
            {
                objDBManager.AddParameter("SortBy", SortBy);
            }
            
            return objDBManager.ExecuteDataSet("Departments_GetAllFilter");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}