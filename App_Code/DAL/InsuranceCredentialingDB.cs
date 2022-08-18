using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for InsuranceCredentialingDB
/// </summary>
public class InsuranceCredentialingDB
{
    public InsuranceCredentialingDB()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public long Add(InsuranceCredentialing objInsuranceCredentialing, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);

          //  objDBManager.AddParameter("InsuranceCredentialingId", objInsuranceCredentialing.InsuranceCredentialingID, SqlDbType.BigInt, 8, ParameterDirection.Output);
          //  objDBManager.AddParameter("PracticeId", objInsuranceCredentialing.PracticeId);
          //  objDBManager.AddParameter("InsuranceId", objInsuranceCredentialing.InsuranceId);
          //  //objDBManager.AddParameter("GroupCode", objInsuranceCredentialing.GroupCode);
          //  //objDBManager.AddParameter("GroupCodeDescription", objInsuranceCredentialing.GroupCodeDescription);
          //  //objDBManager.AddParameter("IndividualCode", objInsuranceCredentialing.IndividualCode);
          //  //objDBManager.AddParameter("IndividualCodeDescription", objInsuranceCredentialing.IndividualCodeDescription);
          //  //objDBManager.AddParameter("IndividualCode1", objInsuranceCredentialing.IndividualCode1);
          //  //objDBManager.AddParameter("IndividualCodeDescription1", objInsuranceCredentialing.IndividualCodeDescription1);
          //  //objDBManager.AddParameter("CreatedDate", objInsuranceCredentialing.CreatedDate);
          //  objDBManager.AddParameter("CreatedById", objInsuranceCredentialing.CreatedById);
          //  objDBManager.AddParameter("Status", objInsuranceCredentialing.Status);
          //  objDBManager.AddParameter("Notes", objInsuranceCredentialing.Notes);
          ////  objDBManager.AddParameter("PracticeDocumentsId", objInsuranceCredentialing.PracticeDocumentsId);
          //  objDBManager.AddParameter("ProviderId", objInsuranceCredentialing.ProviderId);
          //  objDBManager.AddParameter("Source", objInsuranceCredentialing.Source);
          //  objDBManager.AddParameter("TargetDate", objInsuranceCredentialing.TargetDate);
          //  objDBManager.AddParameter("GroupId", objInsuranceCredentialing.GroupId);
          //  objDBManager.AddParameter("ProviderPTAN", objInsuranceCredentialing.ProviderPTAN);
          //  objDBManager.AddParameter("Remarks", objInsuranceCredentialing.Remarks);
          //  objDBManager.AddParameter("NPI", objInsuranceCredentialing.NPI);
          //  objDBManager.AddParameter("TaxId", objInsuranceCredentialing.TaxId);
          //  objDBManager.AddParameter("SSN", objInsuranceCredentialing.SSN);
          //  objDBManager.ExecuteNonQuery("InsuranceCredentialing_Add");

            return long.Parse(objDBManager.Parameters[0].Value.ToString());
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int Update(InsuranceCredentialing objInsuranceCredentialing, SqlTransaction objSqlTransaction = null)
    {
        try
        {

            DBManager objDBManager = new DBManager();

            objDBManager.AddParameter("InsuranceCredentialingID", objInsuranceCredentialing.InsuranceCredentialingID, SqlDbType.BigInt, 8);

            objDBManager.AddParameter("InsuranceId", objInsuranceCredentialing.InsuranceId);
            //objDBManager.AddParameter("GroupCode", objInsuranceCredentialing.GroupCode);
            //objDBManager.AddParameter("GroupCodeDescription", objInsuranceCredentialing.GroupCodeDescription);
            //objDBManager.AddParameter("IndividualCode", objInsuranceCredentialing.IndividualCode);
            //objDBManager.AddParameter("IndividualCodeDescription", objInsuranceCredentialing.IndividualCodeDescription);
            //objDBManager.AddParameter("IndividualCode1", objInsuranceCredentialing.IndividualCode1);
            //objDBManager.AddParameter("IndividualCodeDescription1", objInsuranceCredentialing.IndividualCodeDescription1);
            objDBManager.AddParameter("Status", objInsuranceCredentialing.Status);
            objDBManager.AddParameter("Notes", objInsuranceCredentialing.Notes);
            objDBManager.AddParameter("PracticeDocumentsId", objInsuranceCredentialing.PracticeDocumentsId);
            objDBManager.AddParameter("ProviderId", objInsuranceCredentialing.ProviderId);
            objDBManager.AddParameter("Source", objInsuranceCredentialing.Source);
            objDBManager.AddParameter("TargetDate", objInsuranceCredentialing.TargetDate);
            objDBManager.AddParameter("GroupId", objInsuranceCredentialing.GroupId);
            objDBManager.AddParameter("ProviderPTAN", objInsuranceCredentialing.ProviderPTAN);
            objDBManager.AddParameter("Remarks", objInsuranceCredentialing.Remarks);
            objDBManager.AddParameter("NPI", objInsuranceCredentialing.NPI);
            objDBManager.AddParameter("TaxId", objInsuranceCredentialing.TaxId);
            objDBManager.AddParameter("SSN", objInsuranceCredentialing.SSN);
            objDBManager.AddParameter("ModifiedDate", objInsuranceCredentialing.ModifiedDate);
            objDBManager.AddParameter("ModifiedById", objInsuranceCredentialing.ModifiedById);

            return objDBManager.ExecuteNonQuery("InsuranceCredentialing_Update");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int Delete(InsuranceCredentialing objInsuranceCredentialing, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);

            objDBManager.AddParameter("InsuranceCredentialingID", objInsuranceCredentialing.InsuranceCredentialingID);
            objDBManager.AddParameter("ModifiedDate", objInsuranceCredentialing.ModifiedDate);
            objDBManager.AddParameter("ModifiedById", objInsuranceCredentialing.ModifiedById);

            return objDBManager.ExecuteNonQuery("InsuranceCredentialing_Delete");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable GetByID(long InsuranceCredentialingID, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);

            objDBManager.AddParameter("InsuranceCredentialingID", InsuranceCredentialingID);

            return objDBManager.ExecuteDataTable("InsuranceCredentialing_GetByID");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet GetAllFilter(long PracticeId, int Rows, int PageNumber, string SortBy, string InsuranceName, string status, string Source, string Provider, string GroupId, string Remarks, int npi, int taxid, DateTime? EffectiveDate, DateTime? StartDate, string ProviderPTAN)
    {
        try
        {
            DBManager objDBManager = new DBManager();
            objDBManager.AddParameter("PracticeId", PracticeId);
            objDBManager.AddParameter("Rows", Rows);
            objDBManager.AddParameter("PageNumber", PageNumber);

            if (!string.IsNullOrEmpty(SortBy))
            {
                objDBManager.AddParameter("SortBy", SortBy);
            }

            if (!string.IsNullOrEmpty(InsuranceName))
            {
                objDBManager.AddParameter("InsuranceName", InsuranceName);
            }
            if (!string.IsNullOrEmpty(status))
            {
                objDBManager.AddParameter("@Status", status);
            }
            //if (!string.IsNullOrEmpty(Notes))
            //{
            //    objDBManager.AddParameter("@Notes", Notes);
            //}
            if (!string.IsNullOrEmpty(Source))
            {
                objDBManager.AddParameter("@Source", Source);
            }
            if (!string.IsNullOrEmpty(Provider))
            {
                objDBManager.AddParameter("@Provider", Provider);
            }
            if (!string.IsNullOrEmpty(GroupId))
            {
                objDBManager.AddParameter("@GroupId", GroupId);
            }
            if (!string.IsNullOrEmpty(Remarks))
            {
                objDBManager.AddParameter("@Remarks", Remarks);
            }
            if (npi > 0)
            {
                objDBManager.AddParameter("@npi", npi);
            }
            if (taxid > 0)
            {
                objDBManager.AddParameter("@taxid", taxid);
            }
            objDBManager.AddParameter("@Startdate", StartDate);
            objDBManager.AddParameter("@effectivedate", EffectiveDate);
            if (!string.IsNullOrEmpty(ProviderPTAN))
            {
                objDBManager.AddParameter("@ProviderPTAN", ProviderPTAN);
            }
            return objDBManager.ExecuteDataSet("InsuranceCredentialing_GetAllFilter");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    } 
    public int Delete(FileDocumentAttachments objFileDocumentAttachments, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);

            objDBManager.AddParameter("FileDocumentAttachmentsId", objFileDocumentAttachments.FileDocumentAttachmentsId);
            objDBManager.AddParameter("Deleted", objFileDocumentAttachments.Deleted);
            return objDBManager.ExecuteNonQuery("FileDocumentAttachments_Delete_InsuranceEnrollment");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable GetddlProviders(long PracticeId, SqlTransaction objDBTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objDBTransaction);
            objDBManager.AddParameter("practiceid", PracticeId);
            return objDBManager.ExecuteDataTable("GetProvidersforInsuranceEnroll");
        }
        catch (Exception ex)
        {
            throw ex;

        }

    }

    public DataTable GetNipTaxId(long PracticeId, string Source, long ProviderId, SqlTransaction objDBTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objDBTransaction);
            objDBManager.AddParameter("practiceid", PracticeId);
            objDBManager.AddParameter("Source", Source);
            objDBManager.AddParameter("ProviderId", ProviderId);
            return objDBManager.ExecuteDataTable("GetNPITaxId");
        }
        catch (Exception ex)
        {
            throw ex;

        }

    }
}