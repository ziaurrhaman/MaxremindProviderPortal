using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for HIPAA270LogDB
/// </summary>
public class HIPAA270LogDB
{
	public HIPAA270LogDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public long Add(HIPAA270Log objHIPAA270Log)
    {
        DBManager objDBManager = new DBManager();

        try
        {
            objDBManager.AddParameter("HIPAA270Id", objHIPAA270Log.HIPAA270Id, SqlDbType.Int, 4, ParameterDirection.Output);

            objDBManager.AddParameter("PracticeId", objHIPAA270Log.PracticeId);
            objDBManager.AddParameter("PatientId", objHIPAA270Log.PatientId);
            objDBManager.AddParameter("DateFrom", objHIPAA270Log.DateFrom);
            objDBManager.AddParameter("DateTo", objHIPAA270Log.DateTo);
            objDBManager.AddParameter("InsuranceId", objHIPAA270Log.InsuranceId);
            objDBManager.AddParameter("EligibilityStatus", objHIPAA270Log.EligibilityStatus);
            objDBManager.AddParameter("EligibilityInquiryDate", objHIPAA270Log.EligibilityInquiryDate);
            objDBManager.AddParameter("ResponseString", objHIPAA270Log.ResponseString);
            
            objDBManager.AddParameter("CreatedById", objHIPAA270Log.CreatedById);
            objDBManager.AddParameter("CreatedDate", objHIPAA270Log.CreatedDate);

            objDBManager.ExecuteNonQuery("HIPAA270Log_Add");

            objHIPAA270Log.HIPAA270Id = long.Parse(objDBManager.Parameters[0].Value.ToString());
        }
        catch (Exception ex)
        {
            throw ex;
        }
        
        return objHIPAA270Log.HIPAA270Id;
    }
    
    public int Update(HIPAA270Log objHIPAA270Log)
    {
        DBManager objDBManager = new DBManager();
        int ReturnValue = 0;
        
        try
        {
            objDBManager.AddParameter("HIPAA270Id", objHIPAA270Log.HIPAA270Id, SqlDbType.Int, 4);
            
            objDBManager.AddParameter("PracticeId", objHIPAA270Log.PracticeId);
            objDBManager.AddParameter("PatientId", objHIPAA270Log.PatientId);
            objDBManager.AddParameter("DateFrom", objHIPAA270Log.DateFrom);
            objDBManager.AddParameter("DateTo", objHIPAA270Log.DateTo);
            objDBManager.AddParameter("InsuranceId", objHIPAA270Log.InsuranceId);
            objDBManager.AddParameter("EligibilityStatus", objHIPAA270Log.EligibilityStatus);
            objDBManager.AddParameter("ResponseString", objHIPAA270Log.ResponseString);
            
            objDBManager.AddParameter("CreatedById", objHIPAA270Log.CreatedById);
            objDBManager.AddParameter("CreatedDate", objHIPAA270Log.CreatedDate);

            ReturnValue = objDBManager.ExecuteNonQuery("HIPAA270Log_Update");
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return ReturnValue;
    }
}