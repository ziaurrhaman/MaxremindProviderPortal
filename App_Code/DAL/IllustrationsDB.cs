using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for IllustrationsDB
/// </summary>
public class IllustrationsDB
{
	public IllustrationsDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataTable GetALL(string Type, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);
            objDBManager.AddParameter("@Type", Type);
            return objDBManager.ExecuteDataTable("Illustrations_GetALL");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}