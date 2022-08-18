using System;
using System.Data;

/// <summary>
/// Summary description for SubmissionFilesDB
/// </summary>
public class SubmissionFilesDB
{
	public SubmissionFilesDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public Int64 Add(SubmissionFiles objSubmissionFiles)
    {
        DBManager objDBManager = new DBManager();
        try
        {
            objDBManager.AddParameter("SubmissionFileId", objSubmissionFiles.SubmissionFileId, SqlDbType.BigInt, 8, ParameterDirection.Output);
            objDBManager.AddParameter("PracticeId", objSubmissionFiles.PracticeId);
            objDBManager.AddParameter("FileName", objSubmissionFiles.FileName);
            objDBManager.AddParameter("FileStatus", objSubmissionFiles.FileStatus);
            objDBManager.AddParameter("SubmissionResults", objSubmissionFiles.SubmissionResults);
            objDBManager.AddParameter("CreatedDate", objSubmissionFiles.CreatedDate);
            objDBManager.AddParameter("CreatedById", objSubmissionFiles.CreatedById);            
            objDBManager.AddParameter("Deleted", objSubmissionFiles.Deleted);
            objDBManager.ExecuteNonQuery("Claim_AddSubmissionFile");
            objSubmissionFiles.SubmissionFileId = (Int64)objDBManager.Parameters[0].Value;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return objSubmissionFiles.SubmissionFileId;
    }
    public Int32 Update(SubmissionFiles objSubmissionFiles)
    {
        DBManager objDBManager = new DBManager();
        int ReturnValue = 0;
        try
        {
            objDBManager.AddParameter("SubmissionFileId", objSubmissionFiles.SubmissionFileId);            
            objDBManager.AddParameter("FileName", objSubmissionFiles.FileName);
            objDBManager.AddParameter("FileStatus", objSubmissionFiles.FileStatus);
            objDBManager.AddParameter("SubmissionResults", objSubmissionFiles.SubmissionResults);            
            objDBManager.AddParameter("ModifiedDate", objSubmissionFiles.ModifiedDate);
            objDBManager.AddParameter("ModifiedById", objSubmissionFiles.ModifiedById);
            ReturnValue = objDBManager.ExecuteNonQuery("Claim_UpdateSubmissionFile");
        }
        catch (Exception ex)
        {
            throw ex;

        }
        return ReturnValue;
    }
    public DataSet GetSubmissionFiles(Int64 practiceId, Int32 rows, Int32 pageNo, string FileName, string CreatedDate)
    {
        DBManager objDbManager = new DBManager();
        objDbManager.AddParameter("PracticeId", practiceId);
        objDbManager.AddParameter("Rows", rows);
        objDbManager.AddParameter("PageNumber", pageNo);

        if (!string.IsNullOrEmpty(FileName))
            objDbManager.AddParameter("FileName", FileName);

        if (!string.IsNullOrEmpty(CreatedDate))
            objDbManager.AddParameter("CreatedDate", CreatedDate);

        return objDbManager.ExecuteDataSet("Claim_GetSubmissionFiles");
    }
    public void ChangeFileStatus(Int64 submissionFileId, long userId)
    {
        DBManager objDbManager = new DBManager();
        objDbManager.AddParameter("SubmissionFileId", submissionFileId);
        objDbManager.AddParameter("ModifiedById", userId);
        objDbManager.AddParameter("ModifiedDate", DateTime.Now);
        objDbManager.ExecuteNonQuery("Claim_ChangeFileStatus");
    }

}