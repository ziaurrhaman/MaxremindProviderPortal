using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for LcdDB
/// </summary>
public class LcdDB
{
	public LcdDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable GetDXSupportedLCDS(string DXCode, string title, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);

            objDBManager.AddParameter("DXCode", DXCode);

            if (!string.IsNullOrEmpty(title))
            {
                objDBManager.AddParameter("title", title);
            }

            return objDBManager.ExecuteDataTable("LCD_GetDXSupportedLCDS");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet GetSupportedCPTICD9Wise(long LcdId, string DXCode, string Procedure, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);

            objDBManager.AddParameter("LCDID", LcdId);
            objDBManager.AddParameter("ICDCode", DXCode);

            if (!string.IsNullOrEmpty(Procedure))
            {
                objDBManager.AddParameter("Procedure", Procedure);
            }

            return objDBManager.ExecuteDataSet("LCD_GetSupportedCPTICD9Wise");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }




    public DataTable GetPRSupportedLCDS(string HCPCSCode, string title, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);

            objDBManager.AddParameter("HCPCSCode", HCPCSCode);

            if (!string.IsNullOrEmpty(title))
            {
                objDBManager.AddParameter("title", title);
            }

            return objDBManager.ExecuteDataTable("LCD_GetProcedureLCDS");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet GetSupportedICD9CPTWise(long LcdId, string HCPCSCode, string Diagnose, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);

            objDBManager.AddParameter("LCDID", LcdId);
            objDBManager.AddParameter("HCPCSCode", HCPCSCode);

            if (!string.IsNullOrEmpty(Diagnose))
            {
                objDBManager.AddParameter("Diagnose", Diagnose);
            }

            return objDBManager.ExecuteDataSet("LCD_GetSupportedICD9CPTWise");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable GetICD9CPTWise_Detail(long LcdId, string HCPCSCode, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);

            objDBManager.AddParameter("LCDID", LcdId);
            objDBManager.AddParameter("HCPCSCode", HCPCSCode);

            return objDBManager.ExecuteDataTable("LCD_GetICD9CPTWise_Detail");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable GetICD9CPTWise_Supported_Filter(string HCPCSCode, string Diagnose, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);

            objDBManager.AddParameter("HCPCSCode", HCPCSCode);

            if (!string.IsNullOrEmpty(Diagnose))
            {
                objDBManager.AddParameter("Diagnose", Diagnose);
            }

            return objDBManager.ExecuteDataTable("LCD_GetICD9CPTWise_Supported_Filter");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable GetICD9CPTWise_NotSupported_Filter(string HCPCSCode, string Diagnose, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);

            objDBManager.AddParameter("HCPCSCode", HCPCSCode);

            if (!string.IsNullOrEmpty(Diagnose))
            {
                objDBManager.AddParameter("Diagnose", Diagnose);
            }

            return objDBManager.ExecuteDataTable("LCD_GetICD9CPTWise_NotSupported_Filter");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}