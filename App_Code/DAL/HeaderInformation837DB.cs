using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for HeaderInformation837DB
/// </summary>
public class HeaderInformation837DB
{
	public HeaderInformation837DB()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    
    public DataSet GetInformation_837()
    {
        DBManager objDBManager = new DBManager();
        
        return objDBManager.ExecuteDataSet("GetInformation_837");
    }

    public DataTable GetInformation_837_Claim(int HeaderID837, long PatientId, long InsuranceId, long PracticeId)
    {
        DBManager objDBManager = new DBManager();
        
        objDBManager.AddParameter("HeaderID837", HeaderID837);

        if (PatientId != 0)
        {
            objDBManager.AddParameter("PatientId", PatientId);
        }

        if (InsuranceId != 0)
        {
            objDBManager.AddParameter("InsuranceId", InsuranceId);
        }

        if (PracticeId != 0)
        {
            objDBManager.AddParameter("PracticeId", PracticeId);
        }
        
        return objDBManager.ExecuteDataTable("GetInformation_837_Claim");
    }

    public DataTable GetInformation_837_ClaimCharges(long ClaimId)
    {
        DBManager objDBManager = new DBManager();

        objDBManager.AddParameter("ClaimId", ClaimId);

        return objDBManager.ExecuteDataTable("GetInformation_837_ClaimCharges");
    }
}