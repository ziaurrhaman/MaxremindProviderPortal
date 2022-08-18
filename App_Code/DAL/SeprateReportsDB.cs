using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SeprateReportsDB
/// </summary>
public class SeprateReportsDB
{
    public SeprateReportsDB()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataSet PostClaim(long PracticeId, int Rows, int PageNumber, string physicains
        , string DateType,string StartDate,string EndDate,string PracticeLocationId,string POSCode,string ClaimStatus
        , string FileSearchId,string SubmissionDate, string CPTCode,string Payer, string ClaimOrProcedurelevel, string Provider)
    {
        DBManager objDBManager = new DBManager();

        objDBManager.AddParameter("@PracticeId", PracticeId);
        objDBManager.AddParameter("@Rows", Rows);
        objDBManager.AddParameter("@PageNumber", PageNumber);

        if (!string.IsNullOrEmpty(physicains)){objDBManager.AddParameter("physicains", physicains);}
        if (!string.IsNullOrEmpty(DateType)) { objDBManager.AddParameter("DateType", DateType); }
        if (!string.IsNullOrEmpty(StartDate)) { objDBManager.AddParameter("StartDate", StartDate); }
        if (!string.IsNullOrEmpty(EndDate)) { objDBManager.AddParameter("EndDate", EndDate); }
        if (!string.IsNullOrEmpty(PracticeLocationId)) { objDBManager.AddParameter("PracticeLocationId", PracticeLocationId); }
        if (!string.IsNullOrEmpty(POSCode)) { objDBManager.AddParameter("POSCode", POSCode); }
        if (!string.IsNullOrEmpty(ClaimStatus)) { objDBManager.AddParameter("ClaimStatus", ClaimStatus); }
        if (!string.IsNullOrEmpty(FileSearchId)) { objDBManager.AddParameter("FileSearchId", FileSearchId); }
        if (!string.IsNullOrEmpty(SubmissionDate)) { objDBManager.AddParameter("SubmissionDate", SubmissionDate); }
        if (!string.IsNullOrEmpty(Payer)) { objDBManager.AddParameter("Payer", Payer); }
        if (!string.IsNullOrEmpty(CPTCode)) { objDBManager.AddParameter("CPTCode", CPTCode); }
        if (!string.IsNullOrEmpty(ClaimOrProcedurelevel)) { objDBManager.AddParameter("ClaimOrProcedurelevel", ClaimOrProcedurelevel); }
        if (!string.IsNullOrEmpty(Provider)) { objDBManager.AddParameter("Provider", Provider); }
        return objDBManager.ExecuteDataSet("Reports_Claim_GetAdmissionStatusSummary");
    }
}