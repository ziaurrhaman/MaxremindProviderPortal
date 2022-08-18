using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for PracticeLicensesDB
/// </summary>
public class PracticeLicensesDB
{
	public PracticeLicensesDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public Int64 Add(PracticeLicenses objPracticeLicenses)
    {
        DBManager objDBManager = new DBManager();
        try
        {
            objDBManager.AddParameter("LicenseId", objPracticeLicenses.LicenseId, SqlDbType.BigInt, 8, ParameterDirection.Output);
            objDBManager.AddParameter("PracticeId", objPracticeLicenses.PracticeId);
            objDBManager.AddParameter("LicenseName", objPracticeLicenses.LicenseName);
            objDBManager.AddParameter("CreatedById", objPracticeLicenses.CreatedById);
            objDBManager.AddParameter("CreatedDate", objPracticeLicenses.CreatedDate);

            objDBManager.ExecuteNonQuery("PracticeLicenses_Add");
            objPracticeLicenses.LicenseId = long.Parse(objDBManager.Parameters[0].Value.ToString());
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return objPracticeLicenses.LicenseId;
    }

    public void Update(PracticeLicenses objPracticeLicenses)
    {
        DBManager objDBManager = new DBManager();
        try
        {
            objDBManager.AddParameter("LicenseId", objPracticeLicenses.LicenseId);
            objDBManager.AddParameter("LicenseName", objPracticeLicenses.LicenseName);
            objDBManager.AddParameter("ModifiedDate", objPracticeLicenses.ModifiedDate);
            objDBManager.AddParameter("ModifiedById", objPracticeLicenses.ModifiedById);
            
            objDBManager.ExecuteNonQuery("PracticeLicenses_Update");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable GetByPractice(long PracticeId)
    {
        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("PracticeId", PracticeId);
        return objDBManager.ExecuteDataTable("PracticeLicenses_GetByPractice");
    }
}