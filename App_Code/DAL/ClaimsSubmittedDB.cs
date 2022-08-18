using System;
using System.Data;

/// <summary>
/// Summary description for ClaimsSubmittedDB
/// </summary>
public class ClaimsSubmittedDB
{
    public ClaimsSubmittedDB()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public long Add(ClaimsSubmitted objClaimsSubmitted)
    {
        DBManager objDBManager = new DBManager();
        try
        {
            objDBManager.AddParameter("ClaimsSubmissionId", objClaimsSubmitted.ClaimsSubmissionId, SqlDbType.BigInt, 8, ParameterDirection.Output);
            objDBManager.AddParameter("PatientAccount", objClaimsSubmitted.PatientAccount);
            objDBManager.AddParameter("PracticeId", objClaimsSubmitted.PracticeId);
            objDBManager.AddParameter("LocationId", objClaimsSubmitted.LocationId);
            objDBManager.AddParameter("ClaimNo", objClaimsSubmitted.ClaimNo);
            objDBManager.AddParameter("InsuranceId", objClaimsSubmitted.InsuranceId);
            objDBManager.AddParameter("PriSecOthType", objClaimsSubmitted.PriSecOthType);
            objDBManager.AddParameter("SubmissionFileId", objClaimsSubmitted.SubmissionFileId);
            objDBManager.AddParameter("SubmissionDate", objClaimsSubmitted.SubmissionDate);
            objDBManager.AddParameter("ClaimWorkDate", objClaimsSubmitted.ClaimWorkDate);
            objDBManager.AddParameter("BatchId", objClaimsSubmitted.BatchId);
            objDBManager.AddParameter("SubmissionResults", objClaimsSubmitted.SubmissionResults);
            objDBManager.AddParameter("ErrorCode", objClaimsSubmitted.ErrorCode);
            objDBManager.AddParameter("CreatedDate", objClaimsSubmitted.CreatedDate);
            objDBManager.AddParameter("CreatedById", objClaimsSubmitted.CreatedById);
            objDBManager.AddParameter("Deleted", objClaimsSubmitted.Deleted);

            objDBManager.ExecuteNonQuery("Claim_AddClaimsSubmitted");

            objClaimsSubmitted.ClaimsSubmissionId = (long)objDBManager.Parameters[0].Value;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return objClaimsSubmitted.ClaimsSubmissionId;
    }

    public DataSet GetClaimsSubmittedLog(long practiceId, int rows, int pageNo, string PatientName, string InsuranceName,
        string FileName, string ClaimId, string SubmissionDate, string SubmissionResults)
    {
        DBManager objDbManager = new DBManager();
        objDbManager.AddParameter("PracticeId", practiceId);
        objDbManager.AddParameter("Rows", rows);
        objDbManager.AddParameter("PageNumber", pageNo);

        if (!string.IsNullOrEmpty(PatientName))
            objDbManager.AddParameter("PatientName", PatientName);

        if (!string.IsNullOrEmpty(InsuranceName))
            objDbManager.AddParameter("InsuranceName", InsuranceName);

        if (!string.IsNullOrEmpty(FileName))
            objDbManager.AddParameter("FileName", FileName);

        if (!string.IsNullOrEmpty(ClaimId))
            objDbManager.AddParameter("ClaimId", ClaimId);

        if (!string.IsNullOrEmpty(SubmissionDate))
            objDbManager.AddParameter("SubmissionDate", SubmissionDate);

        if (!string.IsNullOrEmpty(SubmissionResults))
            objDbManager.AddParameter("SubmissionResults", SubmissionResults);

        return objDbManager.ExecuteDataSet("Claim_GetClaimsSubmittedLog");
    }

    public DataTable ClaimsSubmissionStatus(long PracticeId)
    {
        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("PracticeId", PracticeId);
        return objDBManager.ExecuteDataTable("DashBoardClaimsSubmissionStatus_GetAll");
    }

    public DataTable ClaimStatusAgingReport(long PracticeId)
    {
        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("PracticeId", PracticeId);
        return objDBManager.ExecuteDataTable("DashBoardClaimStatusAgingReport_GetAll");
    }
}