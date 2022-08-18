using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for ReportsFinancialDB
/// </summary>
public class ReportsFinancialDB
{
	public ReportsFinancialDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataSet LoadFilterDropDowns_ClaimSubmissionStatusSummary(long PracticeId)
    {
        DBManager objDBManager = new DBManager();

        objDBManager.AddParameter("PracticeId", PracticeId);

        return objDBManager.ExecuteDataSet("Reports_LoadFilterDropDowns_ClaimSubmissionStatusSummary");
    }

    public DataSet ClaimSubmissionStatusSummary(long PracticeId, string PracticeLocationsId, int Rows, int PageNumber, string SortBy,  string DateFrom = "",
    string DateTo = "", string DateType = "")
    {
        try
        {
            DBManager objDBManager = new DBManager();

            objDBManager.AddParameter("PracticeId", PracticeId);
            if (!string.IsNullOrEmpty(PracticeLocationsId))
            {
                objDBManager.AddParameter("PracticeLocationsId", PracticeLocationsId);
            }

            objDBManager.AddParameter("Rows", Rows);
            objDBManager.AddParameter("PageNumber", PageNumber);

            if (!string.IsNullOrEmpty(SortBy))
            {
                objDBManager.AddParameter("SortBy", SortBy);
            }
            if (!string.IsNullOrEmpty(DateType))
            {
                objDBManager.AddParameter("DateType", DateType);
            }
            if (!string.IsNullOrEmpty(DateFrom))
            {
                objDBManager.AddParameter("FromDate",(DateFrom));
            }
            if (!string.IsNullOrEmpty(DateTo))
            {
                objDBManager.AddParameter("ToDate", (DateTo));
            }
            return objDBManager.ExecuteDataSet("Reports_ClaimSubmissionStatusSummary");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet ClaimPayments(long PracticeId, int Rows, int PageNumber, string SortBy)
    {
        try
        {
            DBManager objDBManager = new DBManager();

            objDBManager.AddParameter("PracticeId", PracticeId);

            objDBManager.AddParameter("Rows", Rows);
            objDBManager.AddParameter("PageNumber", PageNumber);

            if (!string.IsNullOrEmpty(SortBy))
            {
                objDBManager.AddParameter("SortBy", SortBy);
            }
            
            return objDBManager.ExecuteDataSet("Reports_ClaimPayments");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}