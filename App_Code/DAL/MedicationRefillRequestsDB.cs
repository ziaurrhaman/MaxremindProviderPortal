using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for MedicationRefillRequestsDB
/// </summary>
public class MedicationRefillRequestsDB
{
	public MedicationRefillRequestsDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public long Add(MedicationRefillRequests objMedicationRefillRequests, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);

            objDBManager.AddParameter("MedicationRefillRequestsId", objMedicationRefillRequests.MedicationRefillRequestsId, SqlDbType.BigInt, 8, ParameterDirection.Output);


            objDBManager.AddParameter("PatientId", objMedicationRefillRequests.PatientId);
            objDBManager.AddParameter("PracticeId", objMedicationRefillRequests.PracticeId);
            objDBManager.AddParameter("PatientPrescriptionId", objMedicationRefillRequests.PatientPrescriptionId);
            objDBManager.AddParameter("MedicationCode", objMedicationRefillRequests.MedicationCode);
            objDBManager.AddParameter("PhramacyId", objMedicationRefillRequests.PhramacyId);
            objDBManager.AddParameter("Phramacy", objMedicationRefillRequests.Phramacy);
            objDBManager.AddParameter("Address", objMedicationRefillRequests.Address);
            objDBManager.AddParameter("City", objMedicationRefillRequests.City);
            objDBManager.AddParameter("State", objMedicationRefillRequests.State);
            objDBManager.AddParameter("ZipCode", objMedicationRefillRequests.ZipCode);
            objDBManager.AddParameter("Phone", objMedicationRefillRequests.Phone);
            objDBManager.AddParameter("Fax", objMedicationRefillRequests.Fax);
            objDBManager.AddParameter("Email", objMedicationRefillRequests.Email);
            objDBManager.AddParameter("RequestStatus", objMedicationRefillRequests.RequestStatus);
            objDBManager.AddParameter("RequestType", objMedicationRefillRequests.RequestType);
            objDBManager.AddParameter("CreatedById", objMedicationRefillRequests.CreatedById);
            objDBManager.AddParameter("CreatedDate", objMedicationRefillRequests.CreatedDate);

            objDBManager.ExecuteNonQuery("MedicationRefillRequests_Add");

            return long.Parse(objDBManager.Parameters[0].Value.ToString());
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int Update(MedicationRefillRequests objMedicationRefillRequests, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager();

            objDBManager.AddParameter("MedicationRefillRequestsId", objMedicationRefillRequests.MedicationRefillRequestsId, SqlDbType.BigInt, 8);


            objDBManager.AddParameter("PatientId", objMedicationRefillRequests.PatientId);
            objDBManager.AddParameter("PracticeId", objMedicationRefillRequests.PracticeId);
            objDBManager.AddParameter("PatientPrescriptionId", objMedicationRefillRequests.PatientPrescriptionId);
            objDBManager.AddParameter("MedicationCode", objMedicationRefillRequests.MedicationCode);
            objDBManager.AddParameter("PhramacyId", objMedicationRefillRequests.PhramacyId);
            objDBManager.AddParameter("Phramacy", objMedicationRefillRequests.Phramacy);
            objDBManager.AddParameter("Address", objMedicationRefillRequests.Address);
            objDBManager.AddParameter("City", objMedicationRefillRequests.City);
            objDBManager.AddParameter("State", objMedicationRefillRequests.State);
            objDBManager.AddParameter("ZipCode", objMedicationRefillRequests.ZipCode);
            objDBManager.AddParameter("Phone", objMedicationRefillRequests.Phone);
            objDBManager.AddParameter("Fax", objMedicationRefillRequests.Fax);
            objDBManager.AddParameter("Email", objMedicationRefillRequests.Email);
            objDBManager.AddParameter("RequestStatus", objMedicationRefillRequests.RequestStatus);
            objDBManager.AddParameter("RequestType", objMedicationRefillRequests.RequestType);
            objDBManager.AddParameter("ModifiedById", objMedicationRefillRequests.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objMedicationRefillRequests.ModifiedDate);

            return objDBManager.ExecuteNonQuery("MedicationRefillRequests_Update");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int Delete(MedicationRefillRequests objMedicationRefillRequests, SqlTransaction objSqlTransaction = null)
    {

        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);

            objDBManager.AddParameter("MedicationRefillRequestsId", objMedicationRefillRequests.MedicationRefillRequestsId);

            objDBManager.AddParameter("ModifiedById", objMedicationRefillRequests.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objMedicationRefillRequests.ModifiedDate);

            return objDBManager.ExecuteNonQuery("MedicationRefillRequests_Delete");
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    public DataTable CheckExist(long patientId, long MedicationCode)
    {
        DBManager objDbManager = new DBManager();
        objDbManager.AddParameter("PatientId", patientId);
        objDbManager.AddParameter("MedicationCode", MedicationCode);
        return objDbManager.ExecuteDataTable("MedicationRefillRequests_CheckExist");
    }
    public DataTable GetAll(long PracticeId)
    {
        DBManager objDbManager = new DBManager();
        objDbManager.AddParameter("PracticeId", PracticeId);
        return objDbManager.ExecuteDataTable("MedicationRefillRequests_GetAll");
    }
    public DataTable GetByPatient(long PatientId, string RequestStatus)
    {
        DBManager objDbManager = new DBManager();
        objDbManager.AddParameter("PatientId", PatientId);
        if (!string.IsNullOrEmpty(RequestStatus))
            objDbManager.AddParameter("RequestStatus", RequestStatus);
        return objDbManager.ExecuteDataTable("MedicationRefillRequests_GetByPatient");
    }
}