using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for HipaaConsentDB
/// </summary>
public class HipaaConsentDB
{
    public HipaaConsentDB()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public long Add(HipaaConsent objHipaaConsent, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);

            objDBManager.AddParameter("HipaaConsentId", objHipaaConsent.HipaaConsentId, SqlDbType.BigInt, 8, ParameterDirection.Output);


            objDBManager.AddParameter("PatientId", objHipaaConsent.PatientId);
            objDBManager.AddParameter("SignedDate", objHipaaConsent.SignedDate);
            objDBManager.AddParameter("Signed", objHipaaConsent.Signed);
            objDBManager.AddParameter("RelationshipToPatient", objHipaaConsent.RelationshipToPatient);
            objDBManager.AddParameter("CreatedById", objHipaaConsent.CreatedById);
            objDBManager.AddParameter("CreatedDate", objHipaaConsent.CreatedDate);

            objDBManager.ExecuteNonQuery("HipaaConsent_Add");

            return long.Parse(objDBManager.Parameters[0].Value.ToString());
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int Update(HipaaConsent objHipaaConsent, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager();

            objDBManager.AddParameter("HipaaConsentId", objHipaaConsent.HipaaConsentId, SqlDbType.BigInt, 8);


            objDBManager.AddParameter("PatientId", objHipaaConsent.PatientId);
            objDBManager.AddParameter("SignedDate", objHipaaConsent.SignedDate);
            objDBManager.AddParameter("Signed", objHipaaConsent.Signed);
            objDBManager.AddParameter("RelationshipToPatient", objHipaaConsent.RelationshipToPatient);
            objDBManager.AddParameter("ModifiedById", objHipaaConsent.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objHipaaConsent.ModifiedDate);

            return objDBManager.ExecuteNonQuery("HipaaConsent_Update");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int Delete(long HipaaConsentId, SqlTransaction objSqlTransaction = null)
    {

        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);

            objDBManager.AddParameter("HipaaConsentId", HipaaConsentId);
            return objDBManager.ExecuteNonQuery("HipaaConsent_Delete");
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    public DataTable GetByPatient(long PatientId, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);

            objDBManager.AddParameter("PatientId", PatientId);

            return objDBManager.ExecuteDataTable("HipaaConsent_GetByPatient");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}