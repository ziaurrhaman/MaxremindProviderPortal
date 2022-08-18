using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
/// <summary>
/// Summary description for CommonDB
/// </summary>
public class CommonDB
{
	public CommonDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataTable GetLocationsByPractice(long PracticeId)
    {
        try
        {
            DBManager objDBManager = new DBManager();
            objDBManager.AddParameter("@PracticeId", PracticeId);
            return objDBManager.ExecuteDataTable("GetBranchesByPractice");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetClaimsType()
    {
        try
        {
            DBManager objDBManager = new DBManager();
            return objDBManager.ExecuteDataTable("GetClaimsType");
        }
        catch (Exception ex)
        {
            throw ex;
        }
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
    public DataTable Insurance_GetAll(long PracticeId)
    {
        DBManager ObjDBManager = new DBManager();
        ObjDBManager.AddParameter("@PracticeId", PracticeId);
        return ObjDBManager.ExecuteDataTable("Insurance_GetAll");
    }
}