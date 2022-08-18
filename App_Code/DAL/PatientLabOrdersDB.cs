using System;
using System.Data;

/// <summary>
/// Summary description for PatientLabOrdersDB
/// </summary>
public class PatientLabOrdersDB
{
	public PatientLabOrdersDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    
    public long Add(PatientLabOrders objPatientLabOrders)
    {
        DBManager objDBManager = new DBManager();
        
        try
        {
            objDBManager.AddParameter("PatientOrderId", objPatientLabOrders.PatientOrderId, SqlDbType.BigInt, 8, ParameterDirection.Output);
            
            objDBManager.AddParameter("PracticeId", objPatientLabOrders.PracticeId);
            
            objDBManager.AddParameter("PatientId", objPatientLabOrders.PatientId);
            objDBManager.AddParameter("ProviderId", objPatientLabOrders.ProviderId);
            objDBManager.AddParameter("LabId", objPatientLabOrders.LabId);
            objDBManager.AddParameter("LocationId", objPatientLabOrders.LocationId);
            objDBManager.AddParameter("OrderDate", objPatientLabOrders.OrderDate);
            objDBManager.AddParameter("DueDate", objPatientLabOrders.DueDate);
            objDBManager.AddParameter("AssignedTo", objPatientLabOrders.AssignedTo);
            objDBManager.AddParameter("PromptTo", objPatientLabOrders.PromptTo);
            objDBManager.AddParameter("Fasting", objPatientLabOrders.Fasting);
            objDBManager.AddParameter("Stat", objPatientLabOrders.Stat);
            objDBManager.AddParameter("PscHold", objPatientLabOrders.PscHold);
            objDBManager.AddParameter("Comments", objPatientLabOrders.Comments);
            objDBManager.AddParameter("Status", objPatientLabOrders.Status);
            objDBManager.AddParameter("Priority", objPatientLabOrders.Priority);
            objDBManager.AddParameter("BillType", objPatientLabOrders.BillType);
            objDBManager.AddParameter("NotPerformed", objPatientLabOrders.NotPerformed);
            objDBManager.AddParameter("NotPerformedReason", objPatientLabOrders.NotPerformedReason);
            objDBManager.AddParameter("ReadyToSend", objPatientLabOrders.ReadyToSend);
            objDBManager.AddParameter("OrderSent", objPatientLabOrders.OrderSent);
            objDBManager.AddParameter("OrderSentDate", objPatientLabOrders.OrderSentDate);
            objDBManager.AddParameter("ChartId", objPatientLabOrders.ChartId);
            objDBManager.AddParameter("OrderType", objPatientLabOrders.OrderType);
            
            objDBManager.AddParameter("ModifiedById", objPatientLabOrders.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objPatientLabOrders.ModifiedDate);
            objDBManager.AddParameter("Deleted", objPatientLabOrders.Deleted);
            
            objDBManager.ExecuteNonQuery("Lab_AddLabOrder");
            
            objPatientLabOrders.PatientOrderId = long.Parse(objDBManager.Parameters[0].Value.ToString());
        }
        catch (Exception ex)
        {
            throw ex;
        }
        
        return objPatientLabOrders.PatientOrderId;
    }
    
    public void Update(PatientLabOrders objPatientLabOrders)
    {
        DBManager objDBManager = new DBManager();        
        try
        {
            objDBManager.AddParameter("PatientOrderId", objPatientLabOrders.PatientOrderId);
            
            objDBManager.AddParameter("PracticeId", objPatientLabOrders.PracticeId);
            
            objDBManager.AddParameter("PatientId", objPatientLabOrders.PatientId);
            objDBManager.AddParameter("ProviderId", objPatientLabOrders.ProviderId);
            objDBManager.AddParameter("LabId", objPatientLabOrders.LabId);
            objDBManager.AddParameter("LocationId", objPatientLabOrders.LocationId);
            objDBManager.AddParameter("OrderDate", objPatientLabOrders.OrderDate);
            objDBManager.AddParameter("DueDate", objPatientLabOrders.DueDate);
            objDBManager.AddParameter("AssignedTo", objPatientLabOrders.AssignedTo);
            objDBManager.AddParameter("PromptTo", objPatientLabOrders.PromptTo);
            objDBManager.AddParameter("Fasting", objPatientLabOrders.Fasting);
            objDBManager.AddParameter("Stat", objPatientLabOrders.Stat);
            objDBManager.AddParameter("PscHold", objPatientLabOrders.PscHold);
            objDBManager.AddParameter("Comments", objPatientLabOrders.Comments);
            objDBManager.AddParameter("Status", objPatientLabOrders.Status);
            objDBManager.AddParameter("Priority", objPatientLabOrders.Priority);
            objDBManager.AddParameter("BillType", objPatientLabOrders.BillType);
            objDBManager.AddParameter("NotPerformed", objPatientLabOrders.NotPerformed);
            objDBManager.AddParameter("NotPerformedReason", objPatientLabOrders.NotPerformedReason);
            objDBManager.AddParameter("ReadyToSend", objPatientLabOrders.ReadyToSend);
            objDBManager.AddParameter("OrderSent", objPatientLabOrders.OrderSent);
            objDBManager.AddParameter("OrderSentDate", objPatientLabOrders.OrderSentDate);
            objDBManager.AddParameter("ChartId", objPatientLabOrders.ChartId);
            objDBManager.AddParameter("OrderType", objPatientLabOrders.OrderType);
            
            objDBManager.AddParameter("ModifiedById", objPatientLabOrders.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objPatientLabOrders.ModifiedDate);
            
            objDBManager.ExecuteNonQuery("Lab_UpdateLabOrder");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    
    public DataSet GetLabOrder(long PracticeId, long PatientId, long PatientOrderId)
    {
        var objDbManager = new DBManager();
        objDbManager.AddParameter("PracticeId", PracticeId);
        objDbManager.AddParameter("PatientId", PatientId);
        objDbManager.AddParameter("PatientOrderId", PatientOrderId);
        return objDbManager.ExecuteDataSet("Lab_GetLabOrder");
    }
    
    //Don't using this
    public DataSet GetLabTestsByProvider(long PracticeId, long PracticeStaffId)
    {
        var objDbManager = new DBManager();

        objDbManager.AddParameter("PracticeId", PracticeId);
        objDbManager.AddParameter("ProviderId", PracticeStaffId);
      
        return objDbManager.ExecuteDataSet("Lab_GetLabTestsByProvider");
    }
    
    public DataSet GetPatientDiagnosisAndTests(long patientOrderId)
    {
        var objDbManager = new DBManager();
        
        objDbManager.AddParameter("PatientOrderId", patientOrderId);
        
        return objDbManager.ExecuteDataSet("Lab_GetPatientDiagnosisAndTests");
    }
    
    public DataSet SearchLabOrders(long PatientId, long PracticeStaffId, long labId, string orderDate, string DueDate, string Priority, string AssignTo, string OrderType, int Rows, int PageNumber, string PscHold)
    {
        DBManager ObjDBManager = new DBManager();
        
        if (PatientId != 0)
        {
            ObjDBManager.AddParameter("PatientId", PatientId);
        }
        
        if (PracticeStaffId != 0)
        {
            ObjDBManager.AddParameter("ProviderId", PracticeStaffId);
        }
        
        if (labId != 0)
        {
            ObjDBManager.AddParameter("LabId", labId);
        }

        if (!string.IsNullOrEmpty(orderDate))
        {
            ObjDBManager.AddParameter("OrderDate", orderDate);
        }

        if (!string.IsNullOrEmpty(DueDate))
        {
            ObjDBManager.AddParameter("DueDate", DueDate);
        }

        if (!string.IsNullOrEmpty(Priority))
        {
            ObjDBManager.AddParameter("Priority", Priority);
        }

        if (!string.IsNullOrEmpty(AssignTo))
        {
            ObjDBManager.AddParameter("AssignTo", AssignTo);
        }

        if (!string.IsNullOrEmpty(OrderType))
        {
            ObjDBManager.AddParameter("OrderType", OrderType);
        }

        if (!string.IsNullOrEmpty(PscHold))
        {
            bool b = bool.Parse(PscHold);
            ObjDBManager.AddParameter("PscHold", b);
        }

        ObjDBManager.AddParameter("Rows", Rows);
        ObjDBManager.AddParameter("PageNumber", PageNumber);

        return ObjDBManager.ExecuteDataSet("Lab_SearchLabOrders");
    }
    
    public void DeletePatientLabOrders(long PatientOrderId)
    {
        DBManager objDbManager = new DBManager();

        objDbManager.AddParameter("PatientOrderId", PatientOrderId);

        objDbManager.ExecuteNonQuery("Lab_DeletePatientLabOrders");
    }
    
    public DataTable PatientOrders(long PatientId, long ChartId)
    {
        var objDbManager = new DBManager();

        objDbManager.AddParameter("PatientId", PatientId);

        if (ChartId != 0)
        {
            objDbManager.AddParameter("ChartId", ChartId);
        }

        return objDbManager.ExecuteDataTable("Lab_PatientOrders");
    }
    
    public DataSet LabPendingSearchOrders(long PracticeId, string orderDate, string DueDate, int Rows, int PageNumber)
    {
        DBManager ObjDBManager = new DBManager();

        ObjDBManager.AddParameter("PracticeId", PracticeId);

        if (!string.IsNullOrEmpty(orderDate))
        {
            ObjDBManager.AddParameter("OrderDate", orderDate);
        }

        if (!string.IsNullOrEmpty(DueDate))
        {
            ObjDBManager.AddParameter("DueDate", DueDate);
        }

        ObjDBManager.AddParameter("Rows", Rows);
        ObjDBManager.AddParameter("PageNumber", PageNumber);

        return ObjDBManager.ExecuteDataSet("Lab_LabPendingSearchOrders");
    }
    
    public DataSet LabCompletedSearchOrders(long PracticeId, string orderDate, string DueDate, int Rows, int PageNumber)
    {
        DBManager ObjDBManager = new DBManager();
        ObjDBManager.AddParameter("PracticeId", PracticeId);
        if (!string.IsNullOrEmpty(orderDate))
        {
            ObjDBManager.AddParameter("OrderDate", orderDate);
        }
        if (!string.IsNullOrEmpty(DueDate))
        {
            ObjDBManager.AddParameter("DueDate", DueDate);
        }
       
        ObjDBManager.AddParameter("Rows", Rows);
        ObjDBManager.AddParameter("PageNumber", PageNumber);
        return ObjDBManager.ExecuteDataSet("Lab_LabCompletedSearchOrders");
    }
    
    public DataSet GetPatientOrderReportByCategory(long PracticeId, long PatientId, long patientOrderId, long LabTestGroupId)
    {
        var objDbManager = new DBManager();
        objDbManager.AddParameter("PracticeId", PracticeId);
        objDbManager.AddParameter("PatientId", PatientId);
        objDbManager.AddParameter("PatientOrderId", patientOrderId);
        objDbManager.AddParameter("LabTestGroupId", LabTestGroupId);
        return objDbManager.ExecuteDataSet("Report_GetPatientOrderByOrderCategory");
    }
}