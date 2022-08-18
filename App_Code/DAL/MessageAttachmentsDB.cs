using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for MessageAttachmentsDB
/// </summary>
public class MessageAttachmentsDB
{
	public MessageAttachmentsDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    
    public long Add(MessageAttachments objMessageAttachments, SqlTransaction objSqlTransaction = null)
    {
        
        DBManager objDBManager = new DBManager(objSqlTransaction);
        
        
        try
        {
            objDBManager.AddParameter("MessageAttachmentsId", objMessageAttachments.MessageAttachmentsId, SqlDbType.BigInt, 8, ParameterDirection.Output);

            objDBManager.AddParameter("MessagesId", objMessageAttachments.MessagesId, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("FileName", objMessageAttachments.FileName, SqlDbType.VarChar, 100);
            objDBManager.AddParameter("FilePath", objMessageAttachments.FilePath, SqlDbType.VarChar, 250);
            objDBManager.AddParameter("CreatedById", objMessageAttachments.CreatedById, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("CreatedDate", objMessageAttachments.CreatedDate, SqlDbType.DateTime, 8);
            objDBManager.AddParameter("ModifiedById", objMessageAttachments.ModifiedById, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("ModifiedDate", objMessageAttachments.ModifiedDate, SqlDbType.DateTime, 8);
            objDBManager.AddParameter("Deleted", objMessageAttachments.Deleted, SqlDbType.Bit, 1);

            objDBManager.ExecuteNonQuery("MessageAttachments_Add");
            
            
            
        }
        catch (Exception ex)
        {

            throw ex;

        }

        return 1;

    }

    public int Update(MessageAttachments objMessageAttachments, SqlTransaction objSqlTransaction = null)
    {

        DBManager objDBManager = new DBManager(objSqlTransaction);
        int ReturnValue = 0;

        try
        {

            objDBManager.AddParameter("MessageAttachmentsId", objMessageAttachments.MessageAttachmentsId, SqlDbType.BigInt, 8, ParameterDirection.Output);

            objDBManager.AddParameter("MessagesId", objMessageAttachments.MessagesId, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("FileName", objMessageAttachments.FileName, SqlDbType.VarChar, 100);
            objDBManager.AddParameter("FilePath", objMessageAttachments.FilePath, SqlDbType.VarChar, 250);
            objDBManager.AddParameter("CreatedById", objMessageAttachments.CreatedById, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("CreatedDate", objMessageAttachments.CreatedDate, SqlDbType.DateTime, 8);
            objDBManager.AddParameter("ModifiedById", objMessageAttachments.ModifiedById, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("ModifiedDate", objMessageAttachments.ModifiedDate, SqlDbType.DateTime, 8);
            objDBManager.AddParameter("Deleted", objMessageAttachments.Deleted, SqlDbType.Bit, 1);

            ReturnValue = objDBManager.ExecuteNonQuery("MessageAttachments_Update");


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
            objDBManager.AddParameter("MessageAttachmentsId", ID, SqlDbType.BigInt, 8);
            return objDBManager.ExecuteNonQuery("MessageAttachments_Delete");
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
            objDBManager.AddParameter("MessageAttachmentsId", ID, SqlDbType.BigInt, 8);

            return objDBManager.ExecuteDataTable("MessageAttachments_GetByID");
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
            return objDBManager.ExecuteDataTable("MessageAttachments_GetAll");
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

}