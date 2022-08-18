using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for StatesDB
/// </summary>
public class StatesDB
{
    public StatesDB()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GetAllAsDataTable(SqlTransaction objDBTransaction = null)
    {

        try
        {
            DBManager objDBManager = new DBManager(objDBTransaction);
            return objDBManager.ExecuteDataTable("States_GetAll");
        }
        catch (Exception ex)
        {
            throw ex;

        }

    }

    public DataTable GetStatesUTC(SqlTransaction objDBTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objDBTransaction);
            return objDBManager.ExecuteDataTable("States_GetStatesUTC");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}