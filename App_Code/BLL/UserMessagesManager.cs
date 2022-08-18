using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for UserMessagesManager
/// </summary>
public class UserMessagesManager
{
	public UserMessagesManager()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    
    public long Add(UserMessages objUserMessages, SqlTransaction objSqlTransaction = null)
    {
        UserMessagesDB objUserMessagesDB = new UserMessagesDB();
        return objUserMessagesDB.Add(objUserMessages, objSqlTransaction);
    }

    public int Update(UserMessages objUserMessages, SqlTransaction objSqlTransaction = null)
    {
        UserMessagesDB objUserMessagesDB = new UserMessagesDB();
        return objUserMessagesDB.Update(objUserMessages, objSqlTransaction);
    }

    public int Delete(int ID, SqlTransaction objSqlTransaction = null)
    {
        UserMessagesDB objUserMessagesDB = new UserMessagesDB();
        return objUserMessagesDB.Delete(ID, objSqlTransaction);
    }

    public DataTable GetByID(int ID, SqlTransaction objSqlTransaction = null)
    {
        UserMessagesDB objUserMessagesDB = new UserMessagesDB();
        return objUserMessagesDB.GetByID(ID);
    }

    public DataTable GetAll(SqlTransaction objSqlTransaction = null)
    {
        UserMessagesDB objUserMessagesDB = new UserMessagesDB();
        return objUserMessagesDB.GetAll(objSqlTransaction);
    }

    public void GetAllByReceiverId(string ReceiverId, SqlTransaction objSqlTransaction = null)
    {
        //UserMessagesDB objUserMessagesDB = new UserMessagesDB();
        //return objUserMessagesDB.GetAllByReceiverId(ReceiverId, objSqlTransaction);
    }

}