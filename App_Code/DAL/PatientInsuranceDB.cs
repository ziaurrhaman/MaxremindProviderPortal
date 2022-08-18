using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
/// <summary>
/// Summary description for PatientInsuranceDB
/// </summary>
public class PatientInsuranceDB
{
    public PatientInsuranceDB()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public long Add(PatientInsurance objPatientInsurance)
    {
        DBManager objDBManager = new DBManager();
        try
        {
            objDBManager.AddParameter("@PatientInsuranceId", objPatientInsurance.PatientInsuranceId, SqlDbType.BigInt, 8, ParameterDirection.Output);

            objDBManager.AddParameter("@PatientId", objPatientInsurance.PatientId);
            objDBManager.AddParameter("InsuranceId", objPatientInsurance.InsuranceId);

            objDBManager.AddParameter("@PriSecOthType", objPatientInsurance.PriSecOthType);
            objDBManager.AddParameter("@PolicyNumber", objPatientInsurance.PolicyNumber);
            objDBManager.AddParameter("@GroupNumber", objPatientInsurance.GroupNumber);
            objDBManager.AddParameter("@GroupName", objPatientInsurance.GroupName);
            objDBManager.AddParameter("@Relationship", objPatientInsurance.Relationship);
            objDBManager.AddParameter("@EffectiveDate", objPatientInsurance.EffectiveDate);
            objDBManager.AddParameter("@TerminationDate", objPatientInsurance.TerminationDate);
            objDBManager.AddParameter("@SubscriberId", objPatientInsurance.SubscriberId);
            objDBManager.AddParameter("@CoPay", objPatientInsurance.CoPay);
            objDBManager.AddParameter("@CoPayType", objPatientInsurance.CoPayType);
            objDBManager.AddParameter("@CoInsurance", objPatientInsurance.CoInsurance);
            objDBManager.AddParameter("@CoInsuranceType", objPatientInsurance.CoInsuranceType);
            objDBManager.AddParameter("@Deductable", objPatientInsurance.Deductable);
            objDBManager.AddParameter("@DeductableType", objPatientInsurance.DeductableType);

            objDBManager.AddParameter("@InsuranceCardFrontFilePath", objPatientInsurance.InsuranceCardFrontFilePath);
            objDBManager.AddParameter("@InsuranceCardBackFilePath", objPatientInsurance.InsuranceCardBackFilePath);

            objDBManager.AddParameter("@CreatedById", objPatientInsurance.CreatedById);
            objDBManager.AddParameter("@CreatedDate", objPatientInsurance.CreatedDate);

            objDBManager.ExecuteNonQuery("PatientInsurance_Add");

            objPatientInsurance.PatientInsuranceId = (long)objDBManager.Parameters[0].Value;
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return objPatientInsurance.PatientInsuranceId;
    }

    public int Update(PatientInsurance objPatientInsurance)
    {
        DBManager objDBManager = new DBManager();
        int ReturnValue = 0;

        try
        {
            objDBManager.AddParameter("@PatientInsuranceId", objPatientInsurance.PatientInsuranceId);

            objDBManager.AddParameter("@PatientId", objPatientInsurance.PatientId);
            objDBManager.AddParameter("@InsuranceId", objPatientInsurance.InsuranceId);

            objDBManager.AddParameter("@PriSecOthType", objPatientInsurance.PriSecOthType);
            objDBManager.AddParameter("@PolicyNumber", objPatientInsurance.PolicyNumber);
            objDBManager.AddParameter("@GroupNumber", objPatientInsurance.GroupNumber);
            objDBManager.AddParameter("@GroupName", objPatientInsurance.GroupName);
            objDBManager.AddParameter("@Relationship", objPatientInsurance.Relationship);
            objDBManager.AddParameter("@EffectiveDate", objPatientInsurance.EffectiveDate);
            objDBManager.AddParameter("@TerminationDate", objPatientInsurance.TerminationDate);
            objDBManager.AddParameter("@SubscriberId", objPatientInsurance.SubscriberId);
            objDBManager.AddParameter("@CoPay", objPatientInsurance.CoPay);
            objDBManager.AddParameter("@CoPayType", objPatientInsurance.CoPayType);
            objDBManager.AddParameter("@CoInsurance", objPatientInsurance.CoInsurance);
            objDBManager.AddParameter("@CoInsuranceType", objPatientInsurance.CoInsuranceType);
            objDBManager.AddParameter("@Deductable", objPatientInsurance.Deductable);
            objDBManager.AddParameter("@DeductableType", objPatientInsurance.DeductableType);

            objDBManager.AddParameter("@ModifiedById", objPatientInsurance.ModifiedById);
            objDBManager.AddParameter("@ModifiedDate", objPatientInsurance.ModifiedDate);

            ReturnValue = objDBManager.ExecuteNonQuery("PatientInsurance_Update");
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return ReturnValue;
    }

    public int UpdateInsuranceCardInfo(PatientInsurance objPatientInsurance)
    {
        DBManager objDBManager = new DBManager();
        int ReturnValue = 0;

        try
        {
            objDBManager.AddParameter("PatientInsuranceId", objPatientInsurance.PatientInsuranceId);

            objDBManager.AddParameter("InsuranceCardFrontFilePath", objPatientInsurance.InsuranceCardFrontFilePath);
            objDBManager.AddParameter("InsuranceCardBackFilePath", objPatientInsurance.InsuranceCardBackFilePath);

            objDBManager.AddParameter("ModifiedById", objPatientInsurance.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objPatientInsurance.ModifiedDate);

            ReturnValue = objDBManager.ExecuteNonQuery("PatientInsurance_UpdateInsuranceCardInfo");
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return ReturnValue;
    }

    public DataTable PatientInsurance_GetByPatientId(long PatientId)
    {
        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("PatientId", PatientId);
        return objDBManager.ExecuteDataTable("PatientInsurance_GetByPatientId ");
    }

    public DataTable GetByPatient(long PatientId)
    {
        DBManager ObjDBManager = new DBManager();
        ObjDBManager.AddParameter("PatientId", PatientId);

        return ObjDBManager.ExecuteDataTable("PatientInsurance_GetInsuranceByPatientId");
    }

    public void PatientInsurance_Delete(long PatientInsuranceId)
    {
        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("@PatientInsuranceId", PatientInsuranceId);
        objDBManager.ExecuteNonQuery("PatientInsurance_Delete");
    }

    public DataTable GetById(long PatientInsuranceId)
    {
        DBManager objDBManager = new DBManager();

        objDBManager.AddParameter("PatientInsuranceId", PatientInsuranceId);

        return objDBManager.ExecuteDataTable("PatientInsurance_GetById");
    }

    public DataTable PatientInsurance_SubscriberSearchByCriteria(string FirstName, string LastName, string PolicyNumber, string PriSecOthType)
    {
        DBManager objDBManager = new DBManager();
        if (!string.IsNullOrEmpty(FirstName))
        {
            objDBManager.AddParameter("FirstName", FirstName);
        }

        if (!string.IsNullOrEmpty(LastName))
        {
            objDBManager.AddParameter("LastName", LastName);
        }

        if (!string.IsNullOrEmpty(PolicyNumber))
        {
            objDBManager.AddParameter("PolicyNumber", PolicyNumber);
        }

        objDBManager.AddParameter("PriSecOthType", PriSecOthType, SqlDbType.Char, 1);
        return objDBManager.ExecuteDataTable("PatientInsurance_SubscriberSearchByCriteria");
    }

    public DataTable PatientInsurance_GetByEpisodeId(long EpisodeId)
    {
        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("EpisodeId", EpisodeId);
        return objDBManager.ExecuteDataTable("PatientInsurance_GetByEpisodeId");
    }

    public DataTable ShowPatientInsuranceDateForDialog(int Pid, int Iid)
    {
        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("@patientid", Pid);
        objDBManager.AddParameter("@patientinsuranceid", Iid);
        return objDBManager.ExecuteDataTable("ShowPatientInsuranceInformationOnUpdateDialog");
    }
}