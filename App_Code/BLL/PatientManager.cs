using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for PatientManager
/// </summary>
public class PatientManager
{
	public PatientManager()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    
    public bool CheckPatientByName(long PracticeId, string LastName, string FirstName)
    {
        PatientDB objPatientDB = new PatientDB();
        
        DataTable dtPatient = objPatientDB.GetByName(PracticeId, LastName, FirstName);
        
        return (dtPatient.Rows.Count > 0);
    }

    public string ConvertPatientEligibilityStatus(string EligibilityStatus)
    {
        EligibilityStatus = EligibilityStatus.Trim();
        
        if (EligibilityStatus == "A")
        {
            EligibilityStatus = "Actice";
        }
        else if (EligibilityStatus == "I")
        {
            EligibilityStatus = "In Active";
        }
        else if (EligibilityStatus == "R")
        {
            EligibilityStatus = "Rejected";
        }
        else
        {
            EligibilityStatus = "Check Eligibility";
        }

        return EligibilityStatus;
    }
}