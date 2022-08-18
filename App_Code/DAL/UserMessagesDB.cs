using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for UserMessagesDB
/// </summary>
public class UserMessagesDB
{
    
	public UserMessagesDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    
    public long Add(UserMessages objUserMessages, SqlTransaction objSqlTransaction = null)
    {
        
        DBManager objDBManager = new DBManager(objSqlTransaction);
        
        try
        {
            objDBManager.AddParameter("UserMessagesId", objUserMessages.UserMessagesId, SqlDbType.BigInt, 8, ParameterDirection.Output);
            
            objDBManager.AddParameter("MessagesId", objUserMessages.MessagesId, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("MessageCode", objUserMessages.MessageCode, SqlDbType.VarChar, 40);
            objDBManager.AddParameter("ReceiverId", objUserMessages.ReceiverId, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("ReceiverType", objUserMessages.ReceiverType, SqlDbType.VarChar, 10);
            objDBManager.AddParameter("MessageStatus", objUserMessages.MessageStatus, SqlDbType.VarChar, 50);
            objDBManager.AddParameter("CreatedById", objUserMessages.CreatedById, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("CreatedDate", objUserMessages.CreatedDate, SqlDbType.DateTime, 8);
            objDBManager.AddParameter("ModifiedById", objUserMessages.ModifiedById, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("ModifiedDate", objUserMessages.ModifiedDate, SqlDbType.DateTime, 8);
            objDBManager.AddParameter("Deleted", objUserMessages.Deleted, SqlDbType.Bit, 1);
            
            objDBManager.ExecuteNonQuery("UserMessages_Add");
            
            objUserMessages.UserMessagesId = Convert.ToInt64(objDBManager.Parameters[0].Value);
            
        }
        catch (Exception ex)
        {

            throw ex;

        }

        return objUserMessages.MessagesId;

    }
    
    public int Update(UserMessages objUserMessages, SqlTransaction objSqlTransaction = null)
    {

        DBManager objDBManager = new DBManager(objSqlTransaction);
        int ReturnValue = 0;

        try
        {

            objDBManager.AddParameter("UserMessagesId", objUserMessages.UserMessagesId, SqlDbType.BigInt, 8, ParameterDirection.Output);

            objDBManager.AddParameter("MessagesId", objUserMessages.MessagesId, SqlDbType.BigInt, 8, ParameterDirection.Output);
            objDBManager.AddParameter("MessageCode", objUserMessages.MessageCode, SqlDbType.VarChar, 40);
            objDBManager.AddParameter("ReceiverId", objUserMessages.ReceiverId, SqlDbType.VarChar, 250);
            objDBManager.AddParameter("ReceiverType", objUserMessages.ReceiverType, SqlDbType.VarChar, 10);
            objDBManager.AddParameter("MessageStatus", objUserMessages.MessageStatus, SqlDbType.VarChar, 50);
            objDBManager.AddParameter("CreatedById", objUserMessages.CreatedById, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("CreatedDate", objUserMessages.CreatedDate, SqlDbType.DateTime, 8);
            objDBManager.AddParameter("ModifiedById", objUserMessages.ModifiedById, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("ModifiedDate", objUserMessages.ModifiedDate, SqlDbType.DateTime, 8);
            objDBManager.AddParameter("Deleted", objUserMessages.Deleted, SqlDbType.Bit, 1);

            ReturnValue = objDBManager.ExecuteNonQuery("UserMessages_Update");


        }
        catch (Exception ex)
        {
            throw ex;
        }

        return ReturnValue;

    }
    
    public int Delete(int ID, SqlTransaction objSqlTransaction = null)
    {

        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);
            objDBManager.AddParameter("UserMessagesId", ID, SqlDbType.BigInt, 8);
            return objDBManager.ExecuteNonQuery("UserMessages_Delete");
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
            objDBManager.AddParameter("UserMessagesId", ID, SqlDbType.BigInt, 8);

            return objDBManager.ExecuteDataTable("UserMessages_GetByID");
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
            return objDBManager.ExecuteDataTable("UserMessages_GetAll");
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    public DataSet GetAllByReceiverId(string ReceiverId, string SearchValue, int Rows, int PageNumber, string SortBy, bool IsDelete, bool IsDraft, SqlTransaction objSqlTransaction = null)
    {

        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);
            objDBManager.AddParameter("ReceiverId", ReceiverId);
            if (!string.IsNullOrEmpty(SearchValue))
            {
                objDBManager.AddParameter("@SearchValue", SearchValue);
            }

            if (!string.IsNullOrEmpty(SortBy))
            {
                objDBManager.AddParameter("@SortBy", SortBy);
            }

            objDBManager.AddParameter("@IsDelete", IsDelete);
            objDBManager.AddParameter("@IsDraft", IsDraft);
            
            objDBManager.AddParameter("@Rows", Rows);
            objDBManager.AddParameter("@PageNumber", PageNumber);


            return objDBManager.ExecuteDataSet("Messages_GetAllByReceiverId");
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    public DataSet GetSentMessagesByUserId(string ReceiverId, string SearchValue, int Rows, int PageNumber, string SortBy)
    {
        try
        {
            DBManager objDBManager = new DBManager();
            objDBManager.AddParameter("@UserId", ReceiverId);
            if (!string.IsNullOrEmpty(SearchValue))
            {
                objDBManager.AddParameter("@SearchValue", SearchValue);
            }

            if (!string.IsNullOrEmpty(SortBy))
            {
                objDBManager.AddParameter("@SortBy", SortBy);
            }

           
            objDBManager.AddParameter("@Rows", Rows);
            objDBManager.AddParameter("@PageNumber", PageNumber);


            return objDBManager.ExecuteDataSet("Messages_GetUserSentMessages");
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    public DataSet GetAllDeleted(string ReceiverId, string SearchValue, int Rows, int PageNumber, string SortBy)
    {

        try
        {
            DBManager objDBManager = new DBManager();
            objDBManager.AddParameter("ReceiverId", ReceiverId);
            if (!string.IsNullOrEmpty(SearchValue))
            {
                objDBManager.AddParameter("@SearchValue", SearchValue);
            }

            if (!string.IsNullOrEmpty(SortBy))
            {
                objDBManager.AddParameter("@SortBy", SortBy);
            }

            objDBManager.AddParameter("@Rows", Rows);
            objDBManager.AddParameter("@PageNumber", PageNumber);


            return objDBManager.ExecuteDataSet("Messages_GetAllDeleted");
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

}