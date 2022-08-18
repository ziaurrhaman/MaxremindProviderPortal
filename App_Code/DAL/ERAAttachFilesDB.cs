using System;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for ERAAttachFilesDB
/// </summary>
public class ERAAttachFilesDB
{
    public ERAAttachFilesDB()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public long Add(ERAAttachFile objAttachfiles, SqlTransaction objSqlTransaction = null)
    {
        DBManager objDBManager = new DBManager(objSqlTransaction);

        try
        {
            objDBManager.AddParameter("ERAAttachfileId", objAttachfiles.ERAAttachfileId, SqlDbType.Int, 4, ParameterDirection.Output);
            objDBManager.AddParameter("UploadFileId", objAttachfiles.UploadFileId);
            objDBManager.AddParameter("ERAMasterId", objAttachfiles.ERAMasterId);
            objDBManager.AddParameter("PracticeId", objAttachfiles.PracticeId);
            objDBManager.AddParameter("CreatedbyId", objAttachfiles.CreatedById);
            objDBManager.AddParameter("CreatedDate", objAttachfiles.CreatedDate); ;
            objDBManager.AddParameter("Deleted", objAttachfiles.Deleted);
            objDBManager.ExecuteNonQuery("ERAAttachFile_Add");

            objAttachfiles.ERAAttachfileId = long.Parse(objDBManager.Parameters[0].Value.ToString());

        }
        catch (Exception ex)
        {
            throw ex;
        }
        return objAttachfiles.ERAAttachfileId;
    }

    public long AddEOBPatients(EOBPatients objEOBPatients, SqlTransaction objSqlTransaction = null)
    {
        DBManager objDBManager = new DBManager(objSqlTransaction);

        try
        {
            objDBManager.AddParameter("EOBPatientId", objEOBPatients.EOBPatientId, SqlDbType.Int, 4, ParameterDirection.Output);
            objDBManager.AddParameter("PatientId", objEOBPatients.PatientId);
            objDBManager.AddParameter("ERAMasterId", objEOBPatients.ERAMasterId);
            objDBManager.AddParameter("PracticeId", objEOBPatients.PracticeId);
            objDBManager.AddParameter("CreatedbyId", objEOBPatients.CreatedById);
            objDBManager.AddParameter("CreatedDate", objEOBPatients.CreatedDate);
            objDBManager.AddParameter("Deleted", objEOBPatients.Deleted);
            objDBManager.AddParameter("@PaymentReason", objEOBPatients.PaymentReason);

            objDBManager.ExecuteNonQuery("EOBPatients_Add");
            //objEOBPatients.EOBPatientId = long.Parse(objDBManager.Parameters[0].Value.ToString());


        }
        catch (Exception ex)
        {
            throw ex;
        }
        return objEOBPatients.EOBPatientId;
    }
    //Added by khayyam Adeel on 7/07/2021 desc: Update Eob Patient and Get EobPatient
    public long UpdateEOBPatients(EOBPatients objEOBPatients)
    {
        DBManager objDBManager = new DBManager();

        try
        {
            objDBManager.AddParameter("EOBPatientId", objEOBPatients.EOBPatientId);
            objDBManager.AddParameter("PatientId", objEOBPatients.PatientId);
            objDBManager.AddParameter("ERAMasterId", objEOBPatients.ERAMasterId);
            objDBManager.AddParameter("PracticeId", objEOBPatients.PracticeId);
            objDBManager.AddParameter("ModifiedById", objEOBPatients.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", Convert.ToDateTime(objEOBPatients.ModifiedDate));
            objDBManager.AddParameter("PaymentReason", objEOBPatients.PaymentReason);
            objDBManager.ExecuteNonQuery("EOBPatients_Update");

            //objEOBPatients.EOBPatientId = long.Parse(objDBManager.Parameters[0].Value.ToString());

        }
        catch (Exception ex)
        {
            throw ex;
        }
        return objEOBPatients.EOBPatientId;
    }
    public DataTable GetEOBPatients(string ERAMasterId, string PatientId)
    {
        DBManager objDBManager = new DBManager();
        try
        {
            objDBManager.AddParameter("@ERAMasterId", Convert.ToInt32(ERAMasterId));
            objDBManager.AddParameter("@PatientId", PatientId);
            return objDBManager.ExecuteDataTable("GetEOBPatients");

        }
        catch (Exception ex)
        {

            throw ex;
        }

    }
    //End Added by Khayyam Adeel
    public DataSet ERAGetPatandUploadFileDetails(long ERAMasterId)
    {
        DBManager ObjDBManager = new DBManager();
        ObjDBManager.AddParameter("ERAMasterId", ERAMasterId);
        return ObjDBManager.ExecuteDataSet("GetEOBPatientAndFiles");
    }

    public DataTable DeletePatUploadfiles(long ERAMasterId, long PatUFId)
    {
        DBManager ObjDBManager = new DBManager();
        ObjDBManager.AddParameter("ERAMasterId", ERAMasterId);
        ObjDBManager.AddParameter("PatientId", PatUFId);
        ObjDBManager.AddParameter("UploadFileId", PatUFId);
        return ObjDBManager.ExecuteDataTable("DeleteEOBPatientAndFiles");
    }

}