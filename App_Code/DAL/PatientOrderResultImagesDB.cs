using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for PatientOrderResultImagesDB
/// </summary>
public class PatientOrderResultImagesDB
{
    public PatientOrderResultImagesDB()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public long Add(PatientOrderResultImages objPatientOrderResultImages, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);

            objDBManager.AddParameter("PatientOrderResultImagesId", objPatientOrderResultImages.PatientOrderResultImagesId, SqlDbType.BigInt, 8, ParameterDirection.Output);
            objDBManager.AddParameter("ResultImage", objPatientOrderResultImages.ResultImage);
            objDBManager.AddParameter("Description", objPatientOrderResultImages.Description);
            objDBManager.AddParameter("PatientOrderResultId", objPatientOrderResultImages.PatientOrderResultId);
            objDBManager.AddParameter("CreatedById", objPatientOrderResultImages.CreatedById);
            objDBManager.AddParameter("CreatedDate", objPatientOrderResultImages.CreatedDate);
            objDBManager.ExecuteNonQuery("PatientOrderResultImages_Add");

            return long.Parse(objDBManager.Parameters[0].Value.ToString());
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int Update(PatientOrderResultImages objPatientOrderResultImages, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager();

            objDBManager.AddParameter("PatientOrderResultImagesId", objPatientOrderResultImages.PatientOrderResultImagesId, SqlDbType.BigInt, 8);


            objDBManager.AddParameter("ResultImage", objPatientOrderResultImages.ResultImage);
            objDBManager.AddParameter("Description", objPatientOrderResultImages.Description);
            objDBManager.AddParameter("PatientOrderResultId", objPatientOrderResultImages.PatientOrderResultId);
            objDBManager.AddParameter("ModifiedById", objPatientOrderResultImages.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objPatientOrderResultImages.ModifiedDate);

            return objDBManager.ExecuteNonQuery("PatientOrderResultImages_Update");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int Delete(long PatientOrderResultImagesId, SqlTransaction objSqlTransaction = null)
    {

        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);

            objDBManager.AddParameter("PatientOrderResultImagesId", PatientOrderResultImagesId);
            return objDBManager.ExecuteNonQuery("PatientOrderResultImages_Delete");
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    public DataTable GetByID(long PatientOrderResultImagesId, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);
            objDBManager.AddParameter("PatientOrderResultImagesId", PatientOrderResultImagesId);
            return objDBManager.ExecuteDataTable("PatientOrderResultImages_GetByID");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetByPatientOrderResultId(long PatientOrderResultId, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);
            objDBManager.AddParameter("PatientOrderResultId", PatientOrderResultId);
            return objDBManager.ExecuteDataTable("PatientOrderResultImages_GetByPatientOrderResultId");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}