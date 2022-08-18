using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for MessagesDB
/// </summary>
public class MessagesDB
{
    public MessagesDB()
    {
        //
        // TODO: Add constructor logic here
        //
    }


    public long Add(Messages objMessages, SqlTransaction objSqlTransaction = null)
    {

        DBManager objDBManager = new DBManager(objSqlTransaction);


        try
        {
            objDBManager.AddParameter("MessagesId", objMessages.MessagesId, SqlDbType.Int, 4, ParameterDirection.Output);

            objDBManager.AddParameter("MessageCode", objMessages.MessageCode, SqlDbType.VarChar, 40);
            objDBManager.AddParameter("Subject", objMessages.Subject, SqlDbType.VarChar, 200);
            objDBManager.AddParameter("Body", objMessages.Body, SqlDbType.NVarChar, 2000);
            objDBManager.AddParameter("IsDraft", objMessages.IsDraft);
            objDBManager.AddParameter("ShowInSent", objMessages.ShowInSent);
            objDBManager.AddParameter("MessageFromUserId", objMessages.MessageFromUserId, SqlDbType.NVarChar, 250);
            objDBManager.AddParameter("Priority", objMessages.Priority, SqlDbType.Char, 1);
            objDBManager.AddParameter("CreatedById", objMessages.CreatedById, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("CreatedDate", objMessages.CreatedDate, SqlDbType.DateTime, 8);
            objDBManager.AddParameter("ModifiedById", objMessages.ModifiedById, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("ModifiedDate", objMessages.ModifiedDate, SqlDbType.DateTime, 8);
            objDBManager.AddParameter("Deleted", objMessages.Deleted, SqlDbType.Bit, 1);

            objDBManager.ExecuteNonQuery("Messages_Add");

            objMessages.MessagesId = Convert.ToInt64(objDBManager.Parameters[0].Value);

        }
        catch (Exception ex)
        {

            throw ex;

        }

        return objMessages.MessagesId;

    }

    public int Update(Messages objMessages, SqlTransaction objSqlTransaction = null)
    {

        DBManager objDBManager = new DBManager(objSqlTransaction);
        int ReturnValue = 0;

        try
        {

            objDBManager.AddParameter("MessagesId", objMessages.MessagesId, SqlDbType.Int, 4);

            objDBManager.AddParameter("MessageCode", objMessages.MessageCode, SqlDbType.VarChar, 40);
            objDBManager.AddParameter("Subject", objMessages.Subject, SqlDbType.VarChar, 200);
            objDBManager.AddParameter("Body", objMessages.Body, SqlDbType.NVarChar, 2000);
            objDBManager.AddParameter("MessageFromEmail", objMessages.MessageFromUserId, SqlDbType.VarChar, 250);
            objDBManager.AddParameter("Priority", objMessages.Priority, SqlDbType.Char, 1);
            objDBManager.AddParameter("CreatedById", objMessages.CreatedById, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("CreatedDate", objMessages.CreatedDate, SqlDbType.DateTime, 8);
            objDBManager.AddParameter("ModifiedById", objMessages.ModifiedById, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("ModifiedDate", objMessages.ModifiedDate, SqlDbType.DateTime, 8);
            objDBManager.AddParameter("Deleted", objMessages.Deleted, SqlDbType.Bit, 1);

            ReturnValue = objDBManager.ExecuteNonQuery("Messages_Update");


        }
        catch (Exception ex)
        {
            throw ex;
        }

        return ReturnValue;

    }

    public int Delete(string IDs, long userId, string deleteFrom)
    {
        try
        {
            DBManager objDBManager = new DBManager();
            objDBManager.AddParameter("MessagesId", IDs);
            objDBManager.AddParameter("UserId", userId);
            objDBManager.AddParameter("DeleteFrom", deleteFrom);
            objDBManager.AddParameter("ModifiedDate", DateTime.Now.ToString("MM/dd/yyyy"));
            return objDBManager.ExecuteNonQuery("Messages_Delete");
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    public int DeleteFromDeleted(string IDs, long userId, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);
            objDBManager.AddParameter("MessagesId", IDs);
            objDBManager.AddParameter("@UserId", userId);
            return objDBManager.ExecuteNonQuery("Messages_DeleteFromDeleted");
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    public DataTable GetByID(int ID, SqlTransaction objSqlTransaction = null)
    {

        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);
            objDBManager.AddParameter("MessagesId", ID, SqlDbType.BigInt, 8);

            return objDBManager.ExecuteDataTable("Messages_GetByID");
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    public DataTable GetAll(SqlTransaction objSqlTransaction = null)
    {

        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);
            return objDBManager.ExecuteDataTable("Messages_GetAll");
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    public DataTable GetEmailByKey(string key, long PracticeId, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);

            objDBManager.AddParameter("key", key, SqlDbType.VarChar, 100);
            objDBManager.AddParameter("PracticeId", PracticeId, SqlDbType.Int, 4);

            return objDBManager.ExecuteDataTable("Messages_GetContactEmails");
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    public DataTable GetPracticeUserList(long PracticeId)
    {
        try
        {
            DBManager objDBManager = new DBManager();
            objDBManager.AddParameter("PracticeId", PracticeId);
            return objDBManager.ExecuteDataTable("Messages_GetPracticeUserList");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet GetMessageDetailByMessagesId(long MessagesId, long ReceiverId, SqlTransaction objSqlTransaction = null)
    {

        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);

            objDBManager.AddParameter("MessagesId", MessagesId);
            objDBManager.AddParameter("ReceiverId", ReceiverId);

            return objDBManager.ExecuteDataSet("Messages_GetMessageDetailByMessagesId");
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    public DataTable UnreadMessageCount(long ReceiverId, SqlTransaction objSqlTransaction = null)
    {
        DBManager objDBManager = new DBManager(objSqlTransaction);
        objDBManager.AddParameter("ReceiverId", ReceiverId);
        return objDBManager.ExecuteDataTable("Messages_UnreadMessageCount");
    }

}