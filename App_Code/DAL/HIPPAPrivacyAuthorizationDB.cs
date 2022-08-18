using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for HIPPAPrivacyAuthorizationDB
/// </summary>
public class HIPPAPrivacyAuthorizationDB
{
	public HIPPAPrivacyAuthorizationDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public long Add(HIPPAPrivacyAuthorization objHIPPAPrivacyAuthorization, SqlTransaction objSqlTransaction = null)
    {

        DBManager objDBManager = new DBManager(objSqlTransaction);


        try
        {
            objDBManager.AddParameter("HIIPAAuthorizationId", objHIPPAPrivacyAuthorization.HIIPAAuthorizationId, SqlDbType.Int, 4, ParameterDirection.Output);

            objDBManager.AddParameter("PatientId", objHIPPAPrivacyAuthorization.PatientId);
            objDBManager.AddParameter("ServiceProviderId", objHIPPAPrivacyAuthorization.ServiceProviderId);
            objDBManager.AddParameter("PracticeId", objHIPPAPrivacyAuthorization.PracticeId);
            objDBManager.AddParameter("AuthorizeTo", objHIPPAPrivacyAuthorization.AuthorizeTo);
            objDBManager.AddParameter("EffectivePeriod", objHIPPAPrivacyAuthorization.EffectivePeriod);
            objDBManager.AddParameter("EffectivePeriodFrom", objHIPPAPrivacyAuthorization.EffectivePeriodFrom);
            objDBManager.AddParameter("EffectivePeriodTo", objHIPPAPrivacyAuthorization.EffectivePeriodTo);
            objDBManager.AddParameter("AllPeriod", objHIPPAPrivacyAuthorization.AllPeriod);
            objDBManager.AddParameter("AuthorizeCompleteHealthRecrod", objHIPPAPrivacyAuthorization.AuthorizeCompleteHealthRecrod);
            objDBManager.AddParameter("AuthorizeCompleteHealthRecrodExcep", objHIPPAPrivacyAuthorization.AuthorizeCompleteHealthRecrodExcep);
            objDBManager.AddParameter("MentalHealthRecord", objHIPPAPrivacyAuthorization.MentalHealthRecord);
            objDBManager.AddParameter("CommunicableDiseases", objHIPPAPrivacyAuthorization.CommunicableDiseases);
            objDBManager.AddParameter("AlcohalTreatment", objHIPPAPrivacyAuthorization.AlcohalTreatment);
            objDBManager.AddParameter("OtherRecord", objHIPPAPrivacyAuthorization.OtherRecord);
            objDBManager.AddParameter("OtherRecordDesc", objHIPPAPrivacyAuthorization.OtherRecordDesc);
            objDBManager.AddParameter("AuthorizationForceDate", objHIPPAPrivacyAuthorization.AuthorizationForceDate);
            objDBManager.AddParameter("SigDate", objHIPPAPrivacyAuthorization.SigDate);
            objDBManager.AddParameter("SigPerson", objHIPPAPrivacyAuthorization.SigPerson);
            objDBManager.AddParameter("PrintedName", objHIPPAPrivacyAuthorization.PrintedName);
            objDBManager.AddParameter("CreatedById", objHIPPAPrivacyAuthorization.CreatedById);
            objDBManager.AddParameter("CreatedDate", objHIPPAPrivacyAuthorization.CreatedDate);
            objDBManager.ExecuteNonQuery("HIPPAPrivacyAuthorization_Add");

            objHIPPAPrivacyAuthorization.HIIPAAuthorizationId = long.Parse(objDBManager.Parameters[0].Value.ToString());

        }
        catch (Exception ex)
        {

            throw ex;

        }

        return objHIPPAPrivacyAuthorization.HIIPAAuthorizationId;

    }

    public int Update(HIPPAPrivacyAuthorization objHIPPAPrivacyAuthorization, SqlTransaction objSqlTransaction = null)
    {

        DBManager objDBManager = new DBManager(objSqlTransaction);
        int ReturnValue = 0;

        try
        {

            objDBManager.AddParameter("HIIPAAuthorizationId", objHIPPAPrivacyAuthorization.HIIPAAuthorizationId, SqlDbType.Int, 4);

            objDBManager.AddParameter("PatientId", objHIPPAPrivacyAuthorization.PatientId);
            objDBManager.AddParameter("ServiceProviderId", objHIPPAPrivacyAuthorization.ServiceProviderId);
            objDBManager.AddParameter("PracticeId", objHIPPAPrivacyAuthorization.PracticeId);
            objDBManager.AddParameter("AuthorizeTo", objHIPPAPrivacyAuthorization.AuthorizeTo);
            objDBManager.AddParameter("EffectivePeriod", objHIPPAPrivacyAuthorization.EffectivePeriod);
            objDBManager.AddParameter("EffectivePeriodFrom", objHIPPAPrivacyAuthorization.EffectivePeriodFrom);
            objDBManager.AddParameter("EffectivePeriodTo", objHIPPAPrivacyAuthorization.EffectivePeriodTo);
            objDBManager.AddParameter("AllPeriod", objHIPPAPrivacyAuthorization.AllPeriod);
            objDBManager.AddParameter("AuthorizeCompleteHealthRecrod", objHIPPAPrivacyAuthorization.AuthorizeCompleteHealthRecrod);
            objDBManager.AddParameter("AuthorizeCompleteHealthRecrodExcep", objHIPPAPrivacyAuthorization.AuthorizeCompleteHealthRecrodExcep);
            objDBManager.AddParameter("MentalHealthRecord", objHIPPAPrivacyAuthorization.MentalHealthRecord);
            objDBManager.AddParameter("CommunicableDiseases", objHIPPAPrivacyAuthorization.CommunicableDiseases);
            objDBManager.AddParameter("AlcohalTreatment", objHIPPAPrivacyAuthorization.AlcohalTreatment);
            objDBManager.AddParameter("OtherRecord", objHIPPAPrivacyAuthorization.OtherRecord);
            objDBManager.AddParameter("OtherRecordDesc", objHIPPAPrivacyAuthorization.OtherRecordDesc);
            objDBManager.AddParameter("AuthorizationForceDate", objHIPPAPrivacyAuthorization.AuthorizationForceDate);
            objDBManager.AddParameter("SigDate", objHIPPAPrivacyAuthorization.SigDate);
            objDBManager.AddParameter("SigPerson", objHIPPAPrivacyAuthorization.SigPerson);
            objDBManager.AddParameter("PrintedName", objHIPPAPrivacyAuthorization.PrintedName);
            objDBManager.AddParameter("ModifiedById", objHIPPAPrivacyAuthorization.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objHIPPAPrivacyAuthorization.ModifiedDate);
            ReturnValue = objDBManager.ExecuteNonQuery("HIPPAPrivacyAuthorization_Update");
        }
        catch (Exception ex)
        {
            throw ex;

        }

        return ReturnValue;

    }

    public int Delete(long HIIPAAuthorizationId, SqlTransaction objSqlTransaction = null)
    {


        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);
            objDBManager.AddParameter("HIIPAAuthorizationId", HIIPAAuthorizationId);
            return objDBManager.ExecuteNonQuery("HIPPAPrivacyAuthorization_Delete");


        }
        catch (Exception ex)
        {
            throw ex;

        }

    }
    public DataTable GetByPatient(long PatientId)
    {
        try
        {
            DBManager objDBManager = new DBManager();
            objDBManager.AddParameter("PatientId", PatientId);
            return objDBManager.ExecuteDataTable("HIPPAPrivacyAuthorization_GetByPatient");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}