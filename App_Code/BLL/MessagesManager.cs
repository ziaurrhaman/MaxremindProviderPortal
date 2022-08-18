using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for MessagesManager
/// </summary>
public class MessagesManager
{
	public MessagesManager()
	{
		//
		// TODO: Add constructor logic here
		//
	}


    public long Add(Messages objMessages, SqlTransaction objSqlTransaction = null)
    {

        MessagesDB objMessagesDB = new MessagesDB();

        return objMessagesDB.Add(objMessages, objSqlTransaction);

    }

    public int Update(Messages objMessages, SqlTransaction objSqlTransaction = null)
    {

        MessagesDB objMessagesDB = new MessagesDB();
        return objMessagesDB.Update(objMessages, objSqlTransaction);

    }

    public int Delete(string IDs, long userId, string deleteFrom, SqlTransaction objSqlTransaction = null)
    {
        MessagesDB objMessagesDB = new MessagesDB();
        return objMessagesDB.Delete(IDs, userId, deleteFrom);
    }

    public DataTable GetByID(int ID, SqlTransaction objSqlTransaction = null)
    {

        MessagesDB objMessagesDB = new MessagesDB();

        return objMessagesDB.GetByID(ID);

    }

    public DataTable GetAll(SqlTransaction objSqlTransaction = null)
    {

        MessagesDB objMessagesDB = new MessagesDB();
        return objMessagesDB.GetAll(objSqlTransaction);

    }

    public DataSet GetMessageDetailByMessagesId(long MessagesId, long ReceiverId, SqlTransaction objSqlTransaction = null)
    {
        MessagesDB objMessagesDB = new MessagesDB();
        return objMessagesDB.GetMessageDetailByMessagesId(MessagesId, ReceiverId);
    }
    
}