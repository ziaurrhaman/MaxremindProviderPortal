using System;
using System.Data;
/// <summary>
/// Summary description for PatientAllergyDb
/// </summary>
public class PatientAllergyDB
{
	public PatientAllergyDB()
	{
		//
		// TODO: Add constructor logic here
		//
    }
    public Int64 Add(PatientAllergy objPatientAllergy)
    {
        DBManager objDbManager = new DBManager();
        try
        {
            objDbManager.AddParameter("AllergyId", objPatientAllergy.AllergyId, SqlDbType.BigInt, 8, ParameterDirection.Output);
            objDbManager.AddParameter("PatientId", objPatientAllergy.PatientId);
            objDbManager.AddParameter("ChartId", objPatientAllergy.ChartId);
            objDbManager.AddParameter("PracticeId", objPatientAllergy.PracticeId);
            objDbManager.AddParameter("AllergyCode", objPatientAllergy.AllergyCode);
            objDbManager.AddParameter("SeverityId", objPatientAllergy.SeverityId);
            objDbManager.AddParameter("AllergyTypeId", objPatientAllergy.AllergyTypeId);
            objDbManager.AddParameter("Status", objPatientAllergy.Status);
            objDbManager.AddParameter("Reaction", objPatientAllergy.Reaction);
            objDbManager.AddParameter("OnSet", objPatientAllergy.OnSet);
            objDbManager.AddParameter("OnSetDate", objPatientAllergy.OnSetDate);
            objDbManager.AddParameter("Resolved", objPatientAllergy.Resolved);
            objDbManager.AddParameter("ResolvedDate", objPatientAllergy.ResolvedDate);
            objDbManager.AddParameter("Reviewed", objPatientAllergy.Reviewed);
            objDbManager.AddParameter("ReviewedDate", objPatientAllergy.ReviewedDate);
            objDbManager.AddParameter("ReviewedBy", objPatientAllergy.ReviewedBy);
            objDbManager.AddParameter("Confidential", objPatientAllergy.Confidential);
            objDbManager.AddParameter("CreatedById", objPatientAllergy.CreatedById);
            objDbManager.AddParameter("CreatedDate", objPatientAllergy.CreatedDate);            
            objDbManager.AddParameter("Deleted", objPatientAllergy.Deleted);
            objDbManager.ExecuteNonQuery("Chart_AddPatientAllergy");
            objPatientAllergy.AllergyId = (Int64)objDbManager.Parameters[0].Value;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return objPatientAllergy.AllergyId;

    }

    public void Update(PatientAllergy objPatientAllergy)
    {
        DBManager objDbManager = new DBManager();        
        try
        {
            objDbManager.AddParameter("AllergyId", objPatientAllergy.AllergyId);
            objDbManager.AddParameter("AllergyCode", objPatientAllergy.AllergyCode);
            objDbManager.AddParameter("SeverityId", objPatientAllergy.SeverityId);
            objDbManager.AddParameter("AllergyTypeId", objPatientAllergy.AllergyTypeId);
            objDbManager.AddParameter("Status", objPatientAllergy.Status);
            objDbManager.AddParameter("Reaction", objPatientAllergy.Reaction);
            objDbManager.AddParameter("OnSet", objPatientAllergy.OnSet);
            objDbManager.AddParameter("OnSetDate", objPatientAllergy.OnSetDate);
            objDbManager.AddParameter("Resolved", objPatientAllergy.Resolved);
            objDbManager.AddParameter("ResolvedDate", objPatientAllergy.ResolvedDate);
            objDbManager.AddParameter("Reviewed", objPatientAllergy.Reviewed);
            objDbManager.AddParameter("ReviewedDate", objPatientAllergy.ReviewedDate);
            objDbManager.AddParameter("ReviewedBy", objPatientAllergy.ReviewedBy);
            objDbManager.AddParameter("Confidential", objPatientAllergy.Confidential);
            objDbManager.AddParameter("ModifiedById", objPatientAllergy.ModifiedById);
            objDbManager.AddParameter("ModifiedDate", objPatientAllergy.ModifiedDate);
            objDbManager.AddParameter("Deleted", objPatientAllergy.Deleted);
            objDbManager.ExecuteNonQuery("Chart_UpdatePatientAllergy");
        }
        catch (Exception ex)
        {
            throw ex;

        }        
    }
    public DataTable GetPatientAllergiesByPatientId(Int64 PatientId, long ChartId, string status, string Allergy, string Type, string Severity)
    {
        DBManager objDbManager = new DBManager();
        objDbManager.AddParameter("PatientId", PatientId);
        if (ChartId != 0)
        {
            objDbManager.AddParameter("ChartId", ChartId);
        }
        if (!string.IsNullOrEmpty(status))
        {
            objDbManager.AddParameter("Status", status);
        }
        if (!string.IsNullOrEmpty(Allergy))
        {
            objDbManager.AddParameter("Allergy", Allergy);
        }
        if (!string.IsNullOrEmpty(Type))
        {
            objDbManager.AddParameter("Type", Type);
        }
        if (!string.IsNullOrEmpty(Severity))
        {
            objDbManager.AddParameter("Severity", Severity);
        }

        return objDbManager.ExecuteDataTable("Chart_GetPatientAllergiesByPatient");
    }
    public DataSet GetAllergyTypesSoverityReferringPhy(Int64 practiceId)
    {
        DBManager objDbManager = new DBManager();
        objDbManager.AddParameter("PracticeId", practiceId);
        return objDbManager.ExecuteDataSet("Chart_GetAllergyTypes_Soverity_ReferringPhy");
    }
    public void DeletePatientAllergy(long AllergyId)
    {
        DBManager objDbManager = new DBManager();
        objDbManager.AddParameter("AllergyId", AllergyId);
        objDbManager.ExecuteNonQuery("Chart_DeletePatientAllergy");
    }
    
}