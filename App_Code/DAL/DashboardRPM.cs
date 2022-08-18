using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DashboardRPM
/// </summary>
/// Created by Faiza Bilal 8/6/2021
public class DashboardRPM
{
    public DashboardRPM()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public DataSet GETRPMDashBoard(long PracticeId, bool? IsImportedDataOnly, string dateFrom=null,string DateTo=null)
    {
        try
        {
            DBManager objDBManager = new DBManager();
            objDBManager.AddParameter("PracticeId", PracticeId);
            if (!string.IsNullOrEmpty(dateFrom)) {
                objDBManager.AddParameter("DateFrom", Convert.ToDateTime(dateFrom));
            }
            if (!string.IsNullOrEmpty(DateTo))
            {
                objDBManager.AddParameter("DateTo", Convert.ToDateTime(DateTo));
            }
            
           
            objDBManager.AddParameter("@IsImported", IsImportedDataOnly);
            return objDBManager.ExecuteDataSet("GETRPMDashBoard_ClaimAndPatientDetail");
        }
        
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GETRPMDashBoard_ClaimAndPatientDetailWise(long PracticeId,string DetailType, string Code,string dateFrom=null,string dateTo=null)
    {
        try
        {
            DBManager objDBManager = new DBManager();
            objDBManager.AddParameter("PracticeId", PracticeId);
            objDBManager.AddParameter("DetailType", DetailType);
            objDBManager.AddParameter("CPTCode", Code);
            //added by Khayyam adeel apply date filter on CPTcode dated 09/12/2021
            if(!string.IsNullOrEmpty(dateFrom))
            {
                objDBManager.AddParameter("@DATEFROM", Convert.ToDateTime(dateFrom));
            }
            if (!string.IsNullOrEmpty(dateTo))
            {
                objDBManager.AddParameter("@DATETO", Convert.ToDateTime(dateTo));
             }
            //End of change

            return objDBManager.ExecuteDataTable("GETRPMDashBoard_ClaimAndPatientDetailWise");
        }

        catch (Exception ex)
        {
            throw ex;
        }
    }
}