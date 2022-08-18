using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for ReportsSchedulingDB
/// </summary>
public class ReportsSchedulingDB
{
	public ReportsSchedulingDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataSet LoadFilterDropDowns_AppointmentSummary(long PracticeId)
    {
        DBManager objDBManager = new DBManager();

        objDBManager.AddParameter("PracticeId", PracticeId);

        return objDBManager.ExecuteDataSet("Reports_LoadFilterDropDowns_AppointmentSummary");
    }

    public DataSet AppointmentSummary(long PracticeId, long PracticeLocationsId, string AppointmentDateFrom, string AppointmentDateTo, int Rows, int PageNumber, string SortBy)
    {
        try
        {
            DBManager objDBManager = new DBManager();
            
            objDBManager.AddParameter("PracticeId", PracticeId);
            
            if (PracticeLocationsId != 0)
            {
                objDBManager.AddParameter("PracticeLocationsId", PracticeLocationsId);
            }
            
            if (!string.IsNullOrEmpty(AppointmentDateFrom))
            {
                objDBManager.AddParameter("AppointmentDateFrom", DateTime.Parse(AppointmentDateFrom));
            }
            
            if (!string.IsNullOrEmpty(AppointmentDateTo))
            {
                objDBManager.AddParameter("AppointmentDateTo", DateTime.Parse(AppointmentDateTo));
            }
            
            objDBManager.AddParameter("Rows", Rows);
            objDBManager.AddParameter("PageNumber", PageNumber);
            
            if (!string.IsNullOrEmpty(SortBy))
            {
                objDBManager.AddParameter("SortBy", SortBy);
            }
            
            return objDBManager.ExecuteDataSet("Reports_AppointmentSummary");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}