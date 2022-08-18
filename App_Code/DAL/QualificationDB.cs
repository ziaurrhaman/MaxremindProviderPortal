using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for QualificationDB
/// </summary>
public class QualificationDB
{
	public QualificationDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public long Add(Qualification objQualification, SqlTransaction objSqlTransaction = null)
    {

        DBManager objDBManager = new DBManager(objSqlTransaction);


        try
        {
            objDBManager.AddParameter("ID", objQualification.QualificationId, SqlDbType.Int, 4, ParameterDirection.Output);

            objDBManager.AddParameter("Name", objQualification.Name, SqlDbType.VarChar, 50);
            objDBManager.AddParameter("Description", objQualification.Description, SqlDbType.VarChar, 1000);
            objDBManager.AddParameter("CreatedDate", objQualification.CreatedDate, SqlDbType.DateTime, 8);
            objDBManager.AddParameter("CreatedById", objQualification.CreatedById, SqlDbType.Int, 4);
            objDBManager.AddParameter("ModifiedDate", objQualification.ModifiedDate, SqlDbType.DateTime, 8);
            objDBManager.AddParameter("ModifiedById", objQualification.ModifiedById, SqlDbType.Int, 4);
            objDBManager.AddParameter("Deleted", objQualification.Deleted, SqlDbType.Bit, 1);

            objDBManager.ExecuteNonQuery("Qualification_Add");

            objQualification.QualificationId = long.Parse(objDBManager.Parameters[0].Value.ToString());

        }
        catch (Exception ex)
        {

            throw ex;

        }

        return objQualification.QualificationId;

    }

    public int Update(Qualification objQualification, SqlTransaction objSqlTransaction = null)
    {

        DBManager objDBManager = new DBManager(objSqlTransaction);
        int ReturnValue = 0;

        try
        {

            objDBManager.AddParameter("ID", objQualification.QualificationId, SqlDbType.Int, 4);

            objDBManager.AddParameter("Name", objQualification.Name, SqlDbType.VarChar, 50);
            objDBManager.AddParameter("Description", objQualification.Description, SqlDbType.VarChar, 1000);
            objDBManager.AddParameter("CreatedDate", objQualification.CreatedDate, SqlDbType.DateTime, 8);
            objDBManager.AddParameter("CreatedById", objQualification.CreatedById, SqlDbType.Int, 4);
            objDBManager.AddParameter("ModifiedDate", objQualification.ModifiedDate, SqlDbType.DateTime, 8);
            objDBManager.AddParameter("ModifiedById", objQualification.ModifiedById, SqlDbType.Int, 4);
            objDBManager.AddParameter("Deleted", objQualification.Deleted, SqlDbType.Bit, 1);

            ReturnValue = objDBManager.ExecuteNonQuery("Qualification_Update");


        }
        catch (Exception ex)
        {
            throw ex;

        }

        return ReturnValue;

    }

    public DataTable GetAllQualifications()
    {
        DBManager ObjDBManager = new DBManager();
        return ObjDBManager.ExecuteDataTable("Qualifications_GetAllQualifications");
    }        
}