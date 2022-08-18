using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for MessageAttachmentsManager
/// </summary>
public class MessageAttachmentsManager
{
	public MessageAttachmentsManager()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public long Add(MessageAttachments objMessageAttachments, SqlTransaction objSqlTransaction = null)
    {

        MessageAttachmentsDB objMessagesDB = new MessageAttachmentsDB();

        return objMessagesDB.Add(objMessageAttachments, objSqlTransaction);

    }

    public int Update(MessageAttachments objMessageAttachments, SqlTransaction objSqlTransaction = null)
    {

        MessageAttachmentsDB objMessagesDB = new MessageAttachmentsDB();
        return objMessagesDB.Update(objMessageAttachments, objSqlTransaction);

    }

    public int Delete(int ID, SqlTransaction objSqlTransaction = null)
    {


        MessageAttachmentsDB objMessagesDB = new MessageAttachmentsDB();
        return objMessagesDB.Delete(ID, objSqlTransaction);


    }

    public DataTable GetByID(int ID, SqlTransaction objSqlTransaction = null)
    {

        MessageAttachmentsDB objMessagesDB = new MessageAttachmentsDB();

        return objMessagesDB.GetByID(ID);

    }

    public DataTable GetAll(SqlTransaction objSqlTransaction = null)
    {

        MessageAttachmentsDB objMessagesDB = new MessageAttachmentsDB();
        return objMessagesDB.GetAll(objSqlTransaction);

    }

}