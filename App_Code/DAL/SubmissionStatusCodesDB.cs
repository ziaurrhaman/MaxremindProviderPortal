using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for SubmissionStatusCodesDB
/// </summary>
public class SubmissionStatusCodesDB
{
	public SubmissionStatusCodesDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataTable GetSubmissionStatusCodes()
    {
        try
        {
            DBManager objDBManager = new DBManager();
            return objDBManager.ExecuteDataTable("GetSubmissionStatusCodes");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}