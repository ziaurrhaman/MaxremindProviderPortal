using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for CheckInRoomManager
/// </summary>
public class CheckInRoomManager
{
	public CheckInRoomManager()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    
    public DataTable GetRoomsByPracticeLocations(long PracticeLocationsId)
    {
        CheckInRoomDB objCheckInRoomDB = new CheckInRoomDB();
        
        return objCheckInRoomDB.GetRoomsByPracticeLocations(PracticeLocationsId);
    }
}