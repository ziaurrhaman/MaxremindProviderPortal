using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for PracticeUsersManager
/// </summary>
public class PracticeUsersManager
{
	public PracticeUsersManager()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public long Add(PracticeUsers objPracticeUsers, SqlTransaction objSqlTransaction = null)
    {
        PracticeUsersDB objPracticeUsersDB = new PracticeUsersDB();
        return objPracticeUsersDB.Add(objPracticeUsers, objSqlTransaction);
    }

    public int Update(PracticeUsers objPracticeUsers, SqlTransaction objSqlTransaction = null)
    {
        PracticeUsersDB objPracticeUsersDB = new PracticeUsersDB();
        return objPracticeUsersDB.Update(objPracticeUsers, objSqlTransaction);
    }
    
    public DataTable GetEmailAndNameByPracticeId(long PracticeId, SqlTransaction objSqlTransaction = null)
    {
        PracticeUsersDB objPracticeUsersDB = new PracticeUsersDB();
        return objPracticeUsersDB.GetEmailAndNameByPracticeId(PracticeId);
    }
}