using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for PatientContactMessagesDB
/// </summary>
public class PatientContactMessagesDB
{
    public PatientContactMessagesDB()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public long Add(PatientContactMessages objPatientContactMessages, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);

            objDBManager.AddParameter("PatientContactMessagesId", objPatientContactMessages.PatientContactMessagesId, SqlDbType.BigInt, 8, ParameterDirection.Output);
            objDBManager.AddParameter("PracticeId", objPatientContactMessages.PracticeId);
            objDBManager.AddParameter("PatientId", objPatientContactMessages.PatientId);
            objDBManager.AddParameter("PatientEmail", objPatientContactMessages.PatientEmail);
            objDBManager.AddParameter("Priority", objPatientContactMessages.Priority);
            objDBManager.AddParameter("Subject", objPatientContactMessages.Subject);
            objDBManager.AddParameter("Message", objPatientContactMessages.Message);
            objDBManager.AddParameter("IsRead", objPatientContactMessages.IsRead);
            objDBManager.AddParameter("MessageReply", objPatientContactMessages.MessageReply);
            objDBManager.AddParameter("CreatedById", objPatientContactMessages.CreatedById);
            objDBManager.AddParameter("CreatedDate", objPatientContactMessages.CreatedDate);
            objDBManager.ExecuteNonQuery("PatientContactMessages_Add");

            return long.Parse(objDBManager.Parameters[0].Value.ToString());
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int Update(PatientContactMessages objPatientContactMessages, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager();

            objDBManager.AddParameter("PatientContactMessagesId", objPatientContactMessages.PatientContactMessagesId, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("PracticeId", objPatientContactMessages.PracticeId);
            objDBManager.AddParameter("PatientId", objPatientContactMessages.PatientId);
            objDBManager.AddParameter("PatientEmail", objPatientContactMessages.PatientEmail);
            objDBManager.AddParameter("Priority", objPatientContactMessages.Priority);
            objDBManager.AddParameter("Subject", objPatientContactMessages.Subject);
            objDBManager.AddParameter("Message", objPatientContactMessages.Message);
            objDBManager.AddParameter("IsRead", objPatientContactMessages.IsRead);
            objDBManager.AddParameter("MessageReply", objPatientContactMessages.MessageReply);
            objDBManager.AddParameter("ModifiedById", objPatientContactMessages.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objPatientContactMessages.ModifiedDate);
            return objDBManager.ExecuteNonQuery("PatientContactMessages_Update");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int Delete(long PatientContactMessagesId, SqlTransaction objSqlTransaction = null)
    {

        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);

            objDBManager.AddParameter("PatientContactMessagesId", PatientContactMessagesId);
            return objDBManager.ExecuteNonQuery("PatientContactMessages_Delete");
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }


    public DataTable GetByID(long PatientContactMessagesId, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);
            objDBManager.AddParameter("PatientContactMessagesId", PatientContactMessagesId);
            return objDBManager.ExecuteDataTable("PatientContactMessages_GetByID");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataSet GetAllFilter(string PatientName, string Subject, long PatientId, string Priority, long PracticeId, int Rows, int PageNumber, string SortBy, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);

            objDBManager.AddParameter("PracticeId", PracticeId);
            objDBManager.AddParameter("Rows", Rows);
            objDBManager.AddParameter("PageNumber", PageNumber);
            objDBManager.AddParameter("SortBy", SortBy);

            if (!string.IsNullOrEmpty(PatientName))
                objDBManager.AddParameter("PatientName", PatientName);

            if (!string.IsNullOrEmpty(Subject))
                objDBManager.AddParameter("Subject", Subject);

            if (PatientId != 0)
                objDBManager.AddParameter("PatientId", PatientId);
            if (!string.IsNullOrEmpty(Priority))
                objDBManager.AddParameter("Priority", Priority);

            return objDBManager.ExecuteDataSet("PatientContactMessages_GetAllFilter");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int MessageRead(long PatientContactMessagesId, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager();

            objDBManager.AddParameter("PatientContactMessagesId", PatientContactMessagesId, SqlDbType.BigInt, 8);
            return objDBManager.ExecuteNonQuery("PatientContactMessages_Read");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}