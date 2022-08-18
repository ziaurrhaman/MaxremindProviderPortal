using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for PracticeStaffManager
/// </summary>
public class PracticeStaffManager
{
	public PracticeStaffManager()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    
    PracticeStaffDB objPracticeStaffDB = new PracticeStaffDB();
    
    /// <summary>
    /// Returns Practice Staff with names and IDs. (PracticeStaffId, Name)
    /// </summary>
    /// <param name="PracticeId"></param>
    /// <returns>Practice Staff with names and IDs.</returns>
    public DataTable GetProvidersByPractice(long PracticeId)
    {
        return objPracticeStaffDB.GetProvidersByPractice(PracticeId);
    }
    
    public DataTable GetProvidersByPracticeLocation(long PracticeLocationsId, long PracticeStaffId = 0)
    {
        return objPracticeStaffDB.GetProvidersByPracticeLocation(PracticeLocationsId, PracticeStaffId);
    }
    
    public DataTable GetPracticeStaffByType(long PracticeId, long PracticeLocationsId, string StaffType)
    {
        return objPracticeStaffDB.GetPracticeStaffByType(PracticeId, PracticeLocationsId, StaffType);
    }
}