using System;
using System.Data;

/// <summary>
/// Summary description for PatientOrderResultsDB
/// </summary>
public class PatientOrderResultsDB
{
    public PatientOrderResultsDB()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public Int64 Add(PatientOrderResults objPatientOrderResults)
    {
        DBManager objDBManager = new DBManager();
        try
        {
            objDBManager.AddParameter("PatientOrderResultId", objPatientOrderResults.PatientOrderResultId, SqlDbType.BigInt, 8, ParameterDirection.Output);
            objDBManager.AddParameter("PatientOrderId", objPatientOrderResults.PatientOrderId);
            objDBManager.AddParameter("PatientId", objPatientOrderResults.PatientId);
            objDBManager.AddParameter("TestName", objPatientOrderResults.TestName);
            objDBManager.AddParameter("GroupId", objPatientOrderResults.GroupId);
            objDBManager.AddParameter("PatientOrderTestId", objPatientOrderResults.PatientOrderTestId);
            objDBManager.AddParameter("RangeValueRecomended", objPatientOrderResults.RangeValueRecomended);
            objDBManager.AddParameter("RangeValueModerate", objPatientOrderResults.RangeValueModerate);
            objDBManager.AddParameter("RangeValueHigh", objPatientOrderResults.RangeValueHigh);
            objDBManager.AddParameter("Comments", objPatientOrderResults.Comments);
            objDBManager.AddParameter("AbnormalRangeCode", objPatientOrderResults.AbnormalRangeCode);
            objDBManager.AddParameter("ResultStatusCode", objPatientOrderResults.ResultStatusCode);
            objDBManager.AddParameter("ResultId", objPatientOrderResults.ResultId);
            objDBManager.AddParameter("ResultUnit", objPatientOrderResults.ResultUnit);
            objDBManager.AddParameter("ResultValue", objPatientOrderResults.ResultValue);
            objDBManager.AddParameter("ObservationDate", objPatientOrderResults.ObservationDate);
            objDBManager.AddParameter("AssignTo", objPatientOrderResults.AssignTo);
            objDBManager.AddParameter("Review", objPatientOrderResults.Review);
            objDBManager.AddParameter("ReviewedBy", objPatientOrderResults.ReviewedBy);
            objDBManager.AddParameter("ReviewedDate", objPatientOrderResults.ReviewedDate);
            objDBManager.AddParameter("ModifiedById", objPatientOrderResults.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objPatientOrderResults.ModifiedDate);
            objDBManager.AddParameter("Deleted", objPatientOrderResults.Deleted);
            objDBManager.ExecuteNonQuery("Lab_AddPatientOrderResults");
            objPatientOrderResults.PatientOrderResultId = Convert.ToInt64(objDBManager.Parameters[0].Value.ToString());
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return objPatientOrderResults.PatientOrderResultId;
    }

    public void Update(PatientOrderResults objPatientOrderResults)
    {
        DBManager objDBManager = new DBManager();
        try
        {
            objDBManager.AddParameter("PatientOrderResultId", objPatientOrderResults.PatientOrderResultId);
            objDBManager.AddParameter("PatientOrderId", objPatientOrderResults.PatientOrderId);
            objDBManager.AddParameter("TestName", objPatientOrderResults.TestName);
            objDBManager.AddParameter("GroupId", objPatientOrderResults.GroupId);
            objDBManager.AddParameter("PatientOrderTestId", objPatientOrderResults.PatientOrderTestId);
            objDBManager.AddParameter("RangeValueRecomended", objPatientOrderResults.RangeValueRecomended);
            objDBManager.AddParameter("RangeValueModerate", objPatientOrderResults.RangeValueModerate);
            objDBManager.AddParameter("RangeValueHigh", objPatientOrderResults.RangeValueHigh);
            objDBManager.AddParameter("Comments", objPatientOrderResults.Comments);
            objDBManager.AddParameter("AbnormalRangeCode", objPatientOrderResults.AbnormalRangeCode);
            objDBManager.AddParameter("ResultStatusCode", objPatientOrderResults.ResultStatusCode);
            objDBManager.AddParameter("ResultId", objPatientOrderResults.ResultId);
            objDBManager.AddParameter("ResultUnit", objPatientOrderResults.ResultUnit);
            objDBManager.AddParameter("ResultValue", objPatientOrderResults.ResultValue);
            objDBManager.AddParameter("ObservationDate", objPatientOrderResults.ObservationDate);
            objDBManager.AddParameter("AssignTo", objPatientOrderResults.AssignTo);
            objDBManager.AddParameter("Review", objPatientOrderResults.Review);
            objDBManager.AddParameter("ReviewedBy", objPatientOrderResults.ReviewedBy);
            objDBManager.AddParameter("ReviewedDate", objPatientOrderResults.ReviewedDate);
            objDBManager.AddParameter("ModifiedById", objPatientOrderResults.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objPatientOrderResults.ModifiedDate);
            objDBManager.ExecuteNonQuery("Lab_UpdatePatientOrderResults");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataSet GetLabOrderResultsData(Int64 patientId, Int64 labOrderId, Int64 practiceId)
    {
        DBManager objDbManager = new DBManager();
        objDbManager.AddParameter("LabOrderId", labOrderId);
        objDbManager.AddParameter("PatientId", patientId);
        objDbManager.AddParameter("PracticeId", practiceId);
        return objDbManager.ExecuteDataSet("Lab_GetLabOrderResultsData");
    }
    public DataTable GetTestResults(Int64 labOrderId, Int64 orderTestId)
    {
        DBManager objDbManager = new DBManager();
        objDbManager.AddParameter("LabOrderId", labOrderId);
        objDbManager.AddParameter("OrderTestId", orderTestId);
        return objDbManager.ExecuteDataTable("Lab_GetTestResults");
    }
    public DataSet SearchLabOrderResults(string orderDate, string dueDate, Int64 patientId, Int64 providerId, Int64 labId, Int64 labTestId, Int64 labTestGroupId, string assignTo, string loinc, int rows, int pageNumber)
    {
        DBManager ObjDBManager = new DBManager();
        if (!string.IsNullOrEmpty(orderDate))
        {
            ObjDBManager.AddParameter("OrderDate", orderDate);
        }
        if (!string.IsNullOrEmpty(dueDate))
        {
            ObjDBManager.AddParameter("DueDate", dueDate);
        }
        if (patientId != 0)
        {
            ObjDBManager.AddParameter("PatientId", patientId);
        }
        if (providerId != 0)
        {
            ObjDBManager.AddParameter("ProviderId", providerId);
        } if (labId != 0)
        {
            ObjDBManager.AddParameter("LabId", labId);
        }
        if (labTestId != 0)
        {
            ObjDBManager.AddParameter("LabTestId", labTestId);
        }
        if (labTestGroupId != 0)
        {
            ObjDBManager.AddParameter("LabTestGroupId", labTestGroupId);
        }
        if (!string.IsNullOrEmpty(assignTo))
        {
            ObjDBManager.AddParameter("AssignTo", assignTo);
        }
        if (!string.IsNullOrEmpty(loinc))
        {
            ObjDBManager.AddParameter("Loinc", loinc);
        }
        ObjDBManager.AddParameter("Rows", rows);
        ObjDBManager.AddParameter("PageNumber", pageNumber);
        return ObjDBManager.ExecuteDataSet("Lab_SearchLabOrderResults");
    }
    public DataSet SearchLabManagerResults(Int64 practiceId, string dateFrom, string dateTo, int rows, int pageNo, string PatientOrderIds, string ResultStatus)
    {
        DBManager objDbManager = new DBManager();
        objDbManager.AddParameter("PracticeId", practiceId);
        if (!string.IsNullOrEmpty(dateFrom))
            objDbManager.AddParameter("DateFrom", dateFrom);
        if (!string.IsNullOrEmpty(dateTo))
            objDbManager.AddParameter("DateTo", dateTo);
        if (!string.IsNullOrEmpty(ResultStatus))
        {
            bool b = bool.Parse(ResultStatus);
            objDbManager.AddParameter("ResultStatus", b);
        }
        objDbManager.AddParameter("Rows", rows);
        objDbManager.AddParameter("PageNumber", pageNo);
        objDbManager.AddParameter("PatientOrderIds", PatientOrderIds);
        return objDbManager.ExecuteDataSet("Lab_SearchLabManagerResults");
    }
    public DataSet GetLabManagerData(Int64 practiceId, string dateFrom, string dateTo)
    {
        DBManager objDbManager = new DBManager();
        objDbManager.AddParameter("PracticeId", practiceId);
        if (!string.IsNullOrEmpty(dateFrom))
        {
            objDbManager.AddParameter("DateFrom", dateFrom);
        }
        if (!string.IsNullOrEmpty(dateTo))
        {
            objDbManager.AddParameter("DateTo", dateTo);
        }
        return objDbManager.ExecuteDataSet("Lab_GetLabManagerData");
    }
    public DataTable LabManagerGetSummary(Int64 practiceId)
    {
        DBManager objDbManager = new DBManager();
        objDbManager.AddParameter("PracticeId", practiceId);
        return objDbManager.ExecuteDataTable("Lab_LabManagerGetSummary");
    }
    public DataTable GetPendingSignedResults(Int64 practiceId, string dateFrom, string dateTo)
    {
        DBManager objDbManager = new DBManager();
        objDbManager.AddParameter("PracticeId", practiceId);
        objDbManager.AddParameter("DateFrom", dateFrom);
        objDbManager.AddParameter("DateTo", dateTo);
        return objDbManager.ExecuteDataTable("Lab_GetPendingSignedResults");
    }
    public void SignLabResults(string orderResultId, int modifiedBy, long ReviewedBy, DateTime SignedDate)
    {
        DBManager objDbManager = new DBManager();
        objDbManager.AddParameter("OrderResultIds", orderResultId);
        objDbManager.AddParameter("ReviewedBy", ReviewedBy);
        objDbManager.AddParameter("SignedDate", SignedDate);
        objDbManager.AddParameter("ModifiedById", modifiedBy);
        objDbManager.AddParameter("ModifiedDate", DateTime.Now);
        objDbManager.ExecuteNonQuery("Lab_SignLabResult");
    }
    public void DeleteLabOrderResult(Int64 orderResultId, Int64 orderId, int modifiedBy)
    {
        DBManager objDbManager = new DBManager();
        objDbManager.AddParameter("OrderResultId", orderResultId);
        objDbManager.AddParameter("OrderId", orderId);
        objDbManager.AddParameter("ModifiedById", modifiedBy);
        objDbManager.AddParameter("ModifiedDate", DateTime.Now);
        objDbManager.ExecuteNonQuery("Lab_DeleteLabOrderResult");
    }
    public DataSet GetLabOrderResultsByOrder(Int64 PatientId, long LabOrderId)
    {
        DBManager objDbManager = new DBManager();
        objDbManager.AddParameter("LabOrderId", LabOrderId);
        objDbManager.AddParameter("PatientId", PatientId);
        return objDbManager.ExecuteDataSet("Report_GetLabOrderResultsByOrder");
    }
}