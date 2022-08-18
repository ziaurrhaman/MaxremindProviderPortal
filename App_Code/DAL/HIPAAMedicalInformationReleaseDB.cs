using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for HIPAAMedicalInformationReleaseDB
/// </summary>
public class HIPAAMedicalInformationReleaseDB
{
	public HIPAAMedicalInformationReleaseDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public long Add(HIPAAMedicalInformationRelease objHIPAAMedicalInformationRelease, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);

            objDBManager.AddParameter("HIPAAMedicalInformationReleaseId", objHIPAAMedicalInformationRelease.HIPAAMedicalInformationReleaseId, SqlDbType.BigInt, 8, ParameterDirection.Output);


            objDBManager.AddParameter("PatientId", objHIPAAMedicalInformationRelease.PatientId);
            objDBManager.AddParameter("PatientAuthorize", objHIPAAMedicalInformationRelease.PatientAuthorize);
            objDBManager.AddParameter("SpouseAuthorize", objHIPAAMedicalInformationRelease.SpouseAuthorize);
            objDBManager.AddParameter("SpouseName", objHIPAAMedicalInformationRelease.SpouseName);
            objDBManager.AddParameter("ChildAuthorize", objHIPAAMedicalInformationRelease.ChildAuthorize);
            objDBManager.AddParameter("ChildName", objHIPAAMedicalInformationRelease.ChildName);
            objDBManager.AddParameter("OtherAuthorize", objHIPAAMedicalInformationRelease.OtherAuthorize);
            objDBManager.AddParameter("OtherName", objHIPAAMedicalInformationRelease.OtherName);
            objDBManager.AddParameter("NoAuthorization", objHIPAAMedicalInformationRelease.NoAuthorization);
            objDBManager.AddParameter("HomeMessage", objHIPAAMedicalInformationRelease.HomeMessage);
            objDBManager.AddParameter("OfficeMessage", objHIPAAMedicalInformationRelease.OfficeMessage);
            objDBManager.AddParameter("CellPhoneMessage", objHIPAAMedicalInformationRelease.CellPhoneMessage);
            objDBManager.AddParameter("CellNumber", objHIPAAMedicalInformationRelease.CellNumber);
            objDBManager.AddParameter("DetailedMessage", objHIPAAMedicalInformationRelease.DetailedMessage);
            objDBManager.AddParameter("ReturnCall", objHIPAAMedicalInformationRelease.ReturnCall);
            objDBManager.AddParameter("OtherMessage", objHIPAAMedicalInformationRelease.OtherMessage);
            objDBManager.AddParameter("OtherMessageText", objHIPAAMedicalInformationRelease.OtherMessageText);
            objDBManager.AddParameter("DayMessage", objHIPAAMedicalInformationRelease.DayMessage);
            objDBManager.AddParameter("TimeMessage", objHIPAAMedicalInformationRelease.TimeMessage);
            objDBManager.AddParameter("PatientSigned", objHIPAAMedicalInformationRelease.PatientSigned);
            objDBManager.AddParameter("PatientSignedDate", objHIPAAMedicalInformationRelease.PatientSignedDate);
            objDBManager.AddParameter("WitnessSigned", objHIPAAMedicalInformationRelease.WitnessSigned);
            objDBManager.AddParameter("WitnessSignedDate", objHIPAAMedicalInformationRelease.WitnessSignedDate);
            objDBManager.AddParameter("CreatedById", objHIPAAMedicalInformationRelease.CreatedById);
            objDBManager.AddParameter("CreatedDate", objHIPAAMedicalInformationRelease.CreatedDate);

            objDBManager.ExecuteNonQuery("HIPAAMedicalInformationRelease_Add");

            return long.Parse(objDBManager.Parameters[0].Value.ToString());
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int Update(HIPAAMedicalInformationRelease objHIPAAMedicalInformationRelease, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager();

            objDBManager.AddParameter("HIPAAMedicalInformationReleaseId", objHIPAAMedicalInformationRelease.HIPAAMedicalInformationReleaseId, SqlDbType.BigInt, 8);


            objDBManager.AddParameter("PatientId", objHIPAAMedicalInformationRelease.PatientId);
            objDBManager.AddParameter("PatientAuthorize", objHIPAAMedicalInformationRelease.PatientAuthorize);
            objDBManager.AddParameter("SpouseAuthorize", objHIPAAMedicalInformationRelease.SpouseAuthorize);
            objDBManager.AddParameter("SpouseName", objHIPAAMedicalInformationRelease.SpouseName);
            objDBManager.AddParameter("ChildAuthorize", objHIPAAMedicalInformationRelease.ChildAuthorize);
            objDBManager.AddParameter("ChildName", objHIPAAMedicalInformationRelease.ChildName);
            objDBManager.AddParameter("OtherAuthorize", objHIPAAMedicalInformationRelease.OtherAuthorize);
            objDBManager.AddParameter("OtherName", objHIPAAMedicalInformationRelease.OtherName);
            objDBManager.AddParameter("NoAuthorization", objHIPAAMedicalInformationRelease.NoAuthorization);
            objDBManager.AddParameter("HomeMessage", objHIPAAMedicalInformationRelease.HomeMessage);
            objDBManager.AddParameter("OfficeMessage", objHIPAAMedicalInformationRelease.OfficeMessage);
            objDBManager.AddParameter("CellPhoneMessage", objHIPAAMedicalInformationRelease.CellPhoneMessage);
            objDBManager.AddParameter("CellNumber", objHIPAAMedicalInformationRelease.CellNumber);
            objDBManager.AddParameter("DetailedMessage", objHIPAAMedicalInformationRelease.DetailedMessage);
            objDBManager.AddParameter("ReturnCall", objHIPAAMedicalInformationRelease.ReturnCall);
            objDBManager.AddParameter("OtherMessage", objHIPAAMedicalInformationRelease.OtherMessage);
            objDBManager.AddParameter("OtherMessageText", objHIPAAMedicalInformationRelease.OtherMessageText);
            objDBManager.AddParameter("DayMessage", objHIPAAMedicalInformationRelease.DayMessage);
            objDBManager.AddParameter("TimeMessage", objHIPAAMedicalInformationRelease.TimeMessage);
            objDBManager.AddParameter("PatientSigned", objHIPAAMedicalInformationRelease.PatientSigned);
            objDBManager.AddParameter("PatientSignedDate", objHIPAAMedicalInformationRelease.PatientSignedDate);
            objDBManager.AddParameter("WitnessSigned", objHIPAAMedicalInformationRelease.WitnessSigned);
            objDBManager.AddParameter("WitnessSignedDate", objHIPAAMedicalInformationRelease.WitnessSignedDate);
            objDBManager.AddParameter("ModifiedById", objHIPAAMedicalInformationRelease.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objHIPAAMedicalInformationRelease.ModifiedDate);

            return objDBManager.ExecuteNonQuery("HIPAAMedicalInformationRelease_Update");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int Delete(long HIPAAMedicalInformationReleaseId, SqlTransaction objSqlTransaction = null)
    {

        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);

            objDBManager.AddParameter("HIPAAMedicalInformationReleaseId", HIPAAMedicalInformationReleaseId);
            return objDBManager.ExecuteNonQuery("HIPAAMedicalInformationRelease_Delete");
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
            return objDBManager.ExecuteDataTable("HIPAAMedicalInformationRelease_GetByPatient");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}