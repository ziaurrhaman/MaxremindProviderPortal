using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for ServiceProviderQualificationDB
/// </summary>
public class ServiceProviderQualificationDB
{
    public ServiceProviderQualificationDB()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public long Add(ServiceProviderQualification objServiceProviderQualification)
    {

        DBManager objDBManager = new DBManager();


        try
        {
            objDBManager.AddParameter("ServiceProviderQualificationId", objServiceProviderQualification.ServiceProviderQualificationId, SqlDbType.BigInt, 8, ParameterDirection.Output);
            objDBManager.AddParameter("ServiceProviderId", objServiceProviderQualification.ServiceProviderId);
            objDBManager.AddParameter("QualificationId", objServiceProviderQualification.QualificationId);
            objDBManager.AddParameter("IssueDate", objServiceProviderQualification.IssueDate);
            objDBManager.AddParameter("ExpiryDate", objServiceProviderQualification.ExpiryDate);
            objDBManager.AddParameter("QualificationNumber", objServiceProviderQualification.QualificationNumber);
            objDBManager.AddParameter("Attachment  ", objServiceProviderQualification.Attachment);
            objDBManager.AddParameter("CreatedById", objServiceProviderQualification.CreatedById);
            objDBManager.AddParameter("CreatedDate", objServiceProviderQualification.CreatedDate);            
            objDBManager.AddParameter("Deleted", objServiceProviderQualification.Deleted);
            objDBManager.ExecuteNonQuery("ServiceProviderQualification_Add");

            objServiceProviderQualification.ServiceProviderQualificationId = long.Parse(objDBManager.Parameters[0].Value.ToString());

        }
        catch (Exception ex)
        {

            throw ex;

        }

        return objServiceProviderQualification.ServiceProviderQualificationId;

    }

    public void Update(ServiceProviderQualification objServiceProviderQualification)
    {
        DBManager objDBManager = new DBManager();        
        try
        {

            objDBManager.AddParameter("ServiceProviderQualificationId", objServiceProviderQualification.ServiceProviderQualificationId);
            objDBManager.AddParameter("QualificationId", objServiceProviderQualification.QualificationId);
            objDBManager.AddParameter("IssueDate", objServiceProviderQualification.IssueDate);
            objDBManager.AddParameter("ExpiryDate", objServiceProviderQualification.ExpiryDate);
            objDBManager.AddParameter("QualificationNumber  ", objServiceProviderQualification.QualificationNumber);
            objDBManager.AddParameter("Attachment  ", objServiceProviderQualification.Attachment);
            objDBManager.AddParameter("ModifiedById", objServiceProviderQualification.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objServiceProviderQualification.ModifiedDate);            
            objDBManager.ExecuteNonQuery("ServiceProviderQualification_Update");

        }
        catch (Exception ex)
        {
            throw ex;

        }        

    }
    public DataTable GetServiceProviderQualification(long ServiceProviderID)
    {
        DBManager objDBManager = new DBManager();
        try
        {
            objDBManager.AddParameter("@ServiceProviderID", ServiceProviderID);
        }
        catch (Exception exc)
        {
            throw exc;
        }

        return objDBManager.ExecuteDataTable("GetServiceProviderQualification");
    }
    public DataTable GetLicenceCertificate_Expired(long PracticeId)
    {
        DBManager objDBManager = new DBManager();
        try
        {
            objDBManager.AddParameter("PracticeId", PracticeId);
            return objDBManager.ExecuteDataTable("GetLicenceCertificate_Expired");
        }
        catch (Exception exc)
        {
            throw exc;
        }        
    }
}