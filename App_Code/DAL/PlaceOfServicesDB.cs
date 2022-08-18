using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for PlaceOfServicesDB
/// </summary>
public class PlaceOfServicesDB
{
    public PlaceOfServicesDB()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public DataTable GetAllByPractice(long PracticeId)
    {
        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("PracticeId", PracticeId);

        return objDBManager.ExecuteDataTable("PlaceOfServices_GetAllByPractice");
    }
}