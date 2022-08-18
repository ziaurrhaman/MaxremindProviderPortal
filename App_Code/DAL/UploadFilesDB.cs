
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

public class UploadFilesDB
{
    public long Add(UploadFiles objUploadFiles, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);

            objDBManager.AddParameter("UploadFilesId", objUploadFiles.UploadFilesId, SqlDbType.BigInt, 8, ParameterDirection.Output);

            objDBManager.AddParameter("PracticeId", objUploadFiles.PracticeId);
            objDBManager.AddParameter("UploadDate", objUploadFiles.UploadDate);
            objDBManager.AddParameter("FileName", objUploadFiles.FileName);
            objDBManager.AddParameter("SubmissionMethodId", objUploadFiles.SubmissionMethodId);
            objDBManager.AddParameter("SubmissionDate", objUploadFiles.SubmissionDate);
            objDBManager.AddParameter("FileTypeId", objUploadFiles.FileTypeId);
            objDBManager.AddParameter("FileStatusId", objUploadFiles.FileStatusId);
            objDBManager.AddParameter("FileFormatId", objUploadFiles.FileFormatId);
            objDBManager.AddParameter("Notes", objUploadFiles.Notes);
            objDBManager.AddParameter("FileLocation", objUploadFiles.FileLocation);
            objDBManager.AddParameter("Patients", objUploadFiles.Patients);
            objDBManager.AddParameter("Claims", objUploadFiles.Claims);
            objDBManager.AddParameter("Charges", objUploadFiles.Charges);
            objDBManager.AddParameter("TagName", objUploadFiles.TagName);
            objDBManager.AddParameter("CreatedById", objUploadFiles.CreatedById);
            //objDBManager.AddParameter("CreatedDate", objUploadFiles.CreatedDate);

            objDBManager.ExecuteNonQuery("UploadFiles_Add");


            objUploadFiles.UploadFilesId = long.Parse(objDBManager.Parameters[0].Value.ToString());
            return objUploadFiles.UploadFilesId;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int Update(UploadFiles objUploadFiles, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager();

            objDBManager.AddParameter("UploadFilesId", objUploadFiles.UploadFilesId, SqlDbType.BigInt, 8);

            objDBManager.AddParameter("PracticeId", objUploadFiles.PracticeId);
            objDBManager.AddParameter("UploadDate", objUploadFiles.UploadDate);
            objDBManager.AddParameter("FileName", objUploadFiles.FileName);
            objDBManager.AddParameter("SubmissionMethodId", objUploadFiles.SubmissionMethodId);
            objDBManager.AddParameter("SubmissionDate", objUploadFiles.SubmissionDate);
            objDBManager.AddParameter("FileTypeId", objUploadFiles.FileTypeId);
            objDBManager.AddParameter("FileStatusId", objUploadFiles.FileStatusId);
            objDBManager.AddParameter("FileFormatId", objUploadFiles.FileFormatId);
            objDBManager.AddParameter("Notes", objUploadFiles.Notes);
            objDBManager.AddParameter("FileLocation", objUploadFiles.FileLocation);
            objDBManager.AddParameter("Patients", objUploadFiles.Patients);
            objDBManager.AddParameter("Claims", objUploadFiles.Claims);
            objDBManager.AddParameter("Charges", objUploadFiles.Charges);
            objDBManager.AddParameter("TagName", objUploadFiles.TagName);
            objDBManager.AddParameter("ModifiedById", objUploadFiles.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objUploadFiles.ModifiedDate);

            return objDBManager.ExecuteNonQuery("UploadFiles_Update");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int Delete(UploadFiles objUploadFiles, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);

            objDBManager.AddParameter("UploadFilesId", objUploadFiles.UploadFilesId);

            objDBManager.AddParameter("ModifiedById", objUploadFiles.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objUploadFiles.ModifiedDate);

            return objDBManager.ExecuteNonQuery("UploadFiles_Delete");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable GetByID(long UploadFilesId, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);

            objDBManager.AddParameter("UploadFilesId", UploadFilesId);

            return objDBManager.ExecuteDataTable("UploadFiles_GetByID");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet GetAllFilter(int Rows, int PageNumber, string SortBy)
    {
        try
        {
            DBManager objDBManager = new DBManager();

            objDBManager.AddParameter("Rows", Rows);
            objDBManager.AddParameter("PageNumber", PageNumber);

            if (!string.IsNullOrEmpty(SortBy))
            {
                objDBManager.AddParameter("SortBy", SortBy);
            }

            return objDBManager.ExecuteDataSet("UploadFiles_GetAllFilter");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable GetByPracticeId(long PracticeId)
    {
        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("PracticeId", PracticeId);
        
        return objDBManager.ExecuteDataTable("UploadFiles_GetByPracticeId");
    }


    //Rizwan kharal 
    //11 oct 2017
    //showing the uploaded files just on practice id
    //updated 4 Nov 2017 
    public DataSet ShowUploadedFiles(long practiceId, int Rows, int PageNumber, string CreatedDate, string FileName, string FileStaus, string FileSubmissionMethods, string Patients, string Claims)
    {
        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("@practiseId", practiceId);
         objDBManager.AddParameter("@Rows", Rows);
        objDBManager.AddParameter("@PageNumber", PageNumber);
       
        if (!string.IsNullOrEmpty(CreatedDate))
        {
            objDBManager.AddParameter("@CreatedDate", CreatedDate);
        }
        if (!string.IsNullOrEmpty(FileName))
        {
            objDBManager.AddParameter("@FileName", FileName);
        }
        if (!string.IsNullOrEmpty(FileStaus))
        {
            objDBManager.AddParameter("@FileStatus", FileStaus);
        }
        if (!string.IsNullOrEmpty(FileSubmissionMethods))
        {
            objDBManager.AddParameter("@FileSubmissionMethods", FileSubmissionMethods);
        }
      
        if (!string.IsNullOrEmpty(Patients))
        {
            objDBManager.AddParameter("@Patients", Patients);
        }

        if (!string.IsNullOrEmpty(Claims))
        {
            objDBManager.AddParameter("@Claims", Claims);
        }
      return  objDBManager.ExecuteDataSet("ShowUploadedFile");
    }

    public DataTable GetFilesOfClaim(Int32 PracticeId, string filename)
    {
        DBManager ObjDBManager = new DBManager();
        ObjDBManager.AddParameter("practiceId", PracticeId);
        ObjDBManager.AddParameter("filename", filename);
        DataTable ddtfilename = ObjDBManager.ExecuteDataTable("GetClaimFiles");
        return ddtfilename;
    }
    public DataTable PracticeUsersearch(string userNmae, long PracticeId)
    {
        DBManager ObjDBManager = new DBManager();
        if (PracticeId == 1000)
        {
            ObjDBManager.AddParameter("PracticeId", PracticeId);
        }
        ObjDBManager.AddParameter("@userName", userNmae);
        DataTable ddtuserpractice = ObjDBManager.ExecuteDataTable("ShowAllPracticeUsers"); //GetPracticeUser prev sp change by Daniyal 01Nov2018
        return ddtuserpractice;
    }

}