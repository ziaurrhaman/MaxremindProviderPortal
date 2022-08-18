using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
/// <summary>
/// Summary description for PatientInvoiceDB
/// </summary>
public class PatientInvoiceDB
{
	public PatientInvoiceDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    //Changes By Syed Sajid Ali Date:4/20/2018 Description:Get Patient Invoice Detials
    public DataSet GetInvoiceData(long PracticeId, string patientId,string Type)
    {
        var objDbManager = new DBManager();

        objDbManager.AddParameter("PracticeId", PracticeId);       

        if (patientId != "")
            objDbManager.AddParameter("PatientId", patientId);
        objDbManager.AddParameter("Type", Type);
        return objDbManager.ExecuteDataSet("GetInvoiceData_Portal");
    }
    //Changes By Syed Sajid Ali Date:4/20/2018 Description:Get Patient Invoice Detials
    public DataSet GetUnProcessedInvoices(long practiceId, int rows, int pageNumber, string PatientName, string InsuranceName, string ClaimId)
    {
        var objDBManager = new DBManager();

        objDBManager.AddParameter("PracticeId", practiceId);
        objDBManager.AddParameter("Rows", rows);
        objDBManager.AddParameter("PageNumber", pageNumber);

        if (!string.IsNullOrEmpty(PatientName))
            objDBManager.AddParameter("PatientName", PatientName);

        if (!string.IsNullOrEmpty(InsuranceName))
            objDBManager.AddParameter("InsuranceName", InsuranceName);

        if (!string.IsNullOrEmpty(ClaimId))
            objDBManager.AddParameter("ClaimId", ClaimId);

        return objDBManager.ExecuteDataSet("GetUnProcessedInvoices");
    }

    public DataSet GetPendingSubmissions(long PracticeId, int Rows, int PageNumber)
    {
        var objDBManager = new DBManager();

        objDBManager.AddParameter("PracticeId", PracticeId);
        objDBManager.AddParameter("Rows", Rows);
        objDBManager.AddParameter("PageNumber", PageNumber);
        return objDBManager.ExecuteDataSet("Invoices_GetPendingSubmissions");
    }
    //Date 4/19/2018
    //Added By Syed Sajid Ali Date:4/20/2018 Description:Get Patient Invoice Detials For Print View
    public DataSet GetPatientInvoiceDetails(long PracticeId, int Rows, int PageNumber, int? payerId,string PatientName, 
      string LastInvoice, string TotalPendingAmount, int? T030, int? T3160, int? T6190, int? T90,string type=null)
    {
        var objDBManager = new DBManager();


        objDBManager.AddParameter("PracticeId", PracticeId);
        objDBManager.AddParameter("Rows", Rows);
        objDBManager.AddParameter("PageNumber", PageNumber);
        objDBManager.AddParameter("PatientId", payerId);
        objDBManager.AddParameter("PatientName", PatientName);
        objDBManager.AddParameter("LastInvoice", LastInvoice);
        objDBManager.AddParameter("TotalPendingAmount", TotalPendingAmount);
        objDBManager.AddParameter("T030", T030);
        objDBManager.AddParameter("T3160", T3160);
        objDBManager.AddParameter("T6190", T6190);
        objDBManager.AddParameter("T90", T90);
        objDBManager.AddParameter("type", type);

        return objDBManager.ExecuteDataSet("GetPatientInvoices");
    }
    //Added By Syed Sajid Ali Date:4/20/2018 Description:Get Patient Invoice Detials For Print View
    public DataSet GetInvoiceAdjustments(long PracticeId, string patientId, long ClaimId, long claimChargesId)
    {
        var objDbManager = new DBManager();

        objDbManager.AddParameter("PracticeId", PracticeId);

        if (patientId != "")
            objDbManager.AddParameter("PatientId", patientId);

        if (ClaimId != null)
            objDbManager.AddParameter("ClaimId", ClaimId);
        if (claimChargesId != null)
            objDbManager.AddParameter("ClaimChargesID", claimChargesId);
        return objDbManager.ExecuteDataSet("GetInvoiceAdjustments");
    }

    public long Add(PatientInvoices objPatientInvoices, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);

            objDBManager.AddParameter("PatientInvoiceId", objPatientInvoices.PatientInvoiceId, SqlDbType.BigInt, 8, ParameterDirection.Output);

            objDBManager.AddParameter("InvoiceFileId", objPatientInvoices.InvoiceFileId);
            objDBManager.AddParameter("PatientId", objPatientInvoices.PatientId);
            objDBManager.AddParameter("PracticeId", objPatientInvoices.PracticeId);
            objDBManager.AddParameter("TotalCharges", objPatientInvoices.TotalCharges);
            objDBManager.AddParameter("AdjustedAmount", objPatientInvoices.AdjustedAmount);
            objDBManager.AddParameter("WriteOff", objPatientInvoices.WriteOff);
            objDBManager.AddParameter("TotalPaidAmount", objPatientInvoices.TotalPaidAmount);
            objDBManager.AddParameter("InsPaidAmount", objPatientInvoices.InsPaidAmount);
            objDBManager.AddParameter("PatPaidAmount", objPatientInvoices.PatPaidAmount);
            objDBManager.AddParameter("TotalBalance", objPatientInvoices.TotalBalance);
            objDBManager.AddParameter("AmountDue", objPatientInvoices.AmountDue);
            objDBManager.AddParameter("StatementDate", objPatientInvoices.StatementDate);
            objDBManager.AddParameter("DueDate", objPatientInvoices.DueDate);
            objDBManager.AddParameter("LastPrintingDate", objPatientInvoices.LastPrintingDate);
            objDBManager.AddParameter("SubmissionMethod", objPatientInvoices.SubmissionMethod);
            objDBManager.AddParameter("SubmissionDate", objPatientInvoices.SubmissionDate);
            objDBManager.AddParameter("InvoiceContents", objPatientInvoices.InvoiceContents);
            objDBManager.AddParameter("CreatedById", objPatientInvoices.CreatedById);
            objDBManager.AddParameter("CreatedDate", objPatientInvoices.CreatedDate);

            objDBManager.ExecuteNonQuery("PatientInvoices_Add");

            return long.Parse(objDBManager.Parameters[0].Value.ToString());
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int Update(PatientInvoices objPatientInvoices, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager();

            objDBManager.AddParameter("PatientInvoiceId", objPatientInvoices.PatientInvoiceId, SqlDbType.BigInt, 8);

            objDBManager.AddParameter("InvoiceFileId", objPatientInvoices.InvoiceFileId);
            objDBManager.AddParameter("PatientId", objPatientInvoices.PatientId);
            objDBManager.AddParameter("PracticeId", objPatientInvoices.PracticeId);
            objDBManager.AddParameter("TotalCharges", objPatientInvoices.TotalCharges);
            objDBManager.AddParameter("AdjustedAmount", objPatientInvoices.AdjustedAmount);
            objDBManager.AddParameter("WriteOff", objPatientInvoices.WriteOff);
            objDBManager.AddParameter("TotalPaidAmount", objPatientInvoices.TotalPaidAmount);
            objDBManager.AddParameter("InsPaidAmount", objPatientInvoices.InsPaidAmount);
            objDBManager.AddParameter("PatPaidAmount", objPatientInvoices.PatPaidAmount);
            objDBManager.AddParameter("TotalBalance", objPatientInvoices.TotalBalance);
            objDBManager.AddParameter("AmountDue", objPatientInvoices.AmountDue);
            objDBManager.AddParameter("StatementDate", objPatientInvoices.StatementDate);
            objDBManager.AddParameter("DueDate", objPatientInvoices.DueDate);
            objDBManager.AddParameter("LastPrintingDate", objPatientInvoices.LastPrintingDate);
            objDBManager.AddParameter("SubmissionMethod", objPatientInvoices.SubmissionMethod);
            objDBManager.AddParameter("SubmissionDate", objPatientInvoices.SubmissionDate);
            objDBManager.AddParameter("InvoiceContents", objPatientInvoices.InvoiceContents);
            objDBManager.AddParameter("ModifiedById", objPatientInvoices.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objPatientInvoices.ModifiedDate);

            return objDBManager.ExecuteNonQuery("PatientInvoices_Update");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int Delete(PatientInvoices objPatientInvoices, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);

            objDBManager.AddParameter("PatientInvoiceId", objPatientInvoices.PatientInvoiceId);

            objDBManager.AddParameter("ModifiedById", objPatientInvoices.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objPatientInvoices.ModifiedDate);

            return objDBManager.ExecuteNonQuery("PatientInvoices_Delete");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable GetByID(long PatientInvoiceId, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);

            objDBManager.AddParameter("PatientInvoiceId", PatientInvoiceId);

            return objDBManager.ExecuteDataTable("PatientInvoices_GetByID");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet GetAllFilter(long PracticeId, int Rows, int PageNumber, string SortBy)
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

            return objDBManager.ExecuteDataSet("PatientInvoices_GetAllFilter");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    /****************ADDED BY SAHHID KAZMI 2/20/2018***************/
    public DataSet GetGeneratedClientInvoices(long practiceId, int Rows, int PageNumber, string SortBy, string CheckNumber)
    {
        var objDBManager = new DBManager();

        objDBManager.AddParameter("PracticeId", practiceId);
        objDBManager.AddParameter("Rows", Rows);
        objDBManager.AddParameter("PageNumber", PageNumber);

        if (!string.IsNullOrEmpty(SortBy))
            objDBManager.AddParameter("SortBy", SortBy);
        if (!string.IsNullOrEmpty(CheckNumber))
            objDBManager.AddParameter("CheckNumber", CheckNumber);

        return objDBManager.ExecuteDataSet("EraMaster_GetCheckNumber");
    }
    public DataSet GetGeneratedClientInvoiceDetail(long practiceId, string CheckNumber, long ClientinvoiceId)
    {
        var objDBManager = new DBManager();

        objDBManager.AddParameter("PracticeId", practiceId);
        if (!string.IsNullOrEmpty(CheckNumber))
            objDBManager.AddParameter("CheckNumber", CheckNumber);
        if (ClientinvoiceId!=null)
            objDBManager.AddParameter("ClientinvoiceId", ClientinvoiceId);
        return objDBManager.ExecuteDataSet("Get_ClientInvoice");
    }

    public DataSet GetGeneratedClientInvoices(long PracticeId, int Rows, int PageNumber, string SortBy, string InvoiceNumber, string StatementFrom, string InvoiceDueDate, string BillDate, string Amount, string PayStatus)
    {
        var objDbManager = new DBManager();

        objDbManager.AddParameter("PracticeId", PracticeId);

        objDbManager.AddParameter("Rows", Rows);
        objDbManager.AddParameter("PageNumber", PageNumber);

        if (!string.IsNullOrEmpty(SortBy))
        {
            objDbManager.AddParameter("SortBy", SortBy);
        }

        if (!string.IsNullOrEmpty(InvoiceNumber))
            objDbManager.AddParameter("InvoiceNumber ", InvoiceNumber);
        if (!string.IsNullOrEmpty(StatementFrom))
            objDbManager.AddParameter("StatementFrom", StatementFrom);
        if (!string.IsNullOrEmpty(InvoiceDueDate))
            objDbManager.AddParameter("InvoiceDueDate", InvoiceDueDate);
        if (!string.IsNullOrEmpty(BillDate))
            objDbManager.AddParameter("BillDate", BillDate);
        if (!string.IsNullOrEmpty(Amount))
            objDbManager.AddParameter("Amount", Amount);
        if (!string.IsNullOrEmpty(PayStatus))
            objDbManager.AddParameter("PayStatus", PayStatus);
        return objDbManager.ExecuteDataSet("GeneratedClientInvoices_GetBySearchCriteria");
    }
    public DataSet GetClientInvoicesList(long PracticeId, int Rows, int PageNumber, string SortBy,long ClientInvoiceId, string PaymentType, string PayerName, string PaymentMethodCode, string CheckNumber, string PaymentDate, string PaymentAmount)
    {
        var objDbManager = new DBManager();

        objDbManager.AddParameter("PracticeId", PracticeId);

        objDbManager.AddParameter("Rows", Rows);
        objDbManager.AddParameter("PageNumber", PageNumber);

        if (!string.IsNullOrEmpty(SortBy))
        {
            objDbManager.AddParameter("SortBy", SortBy);
        }
        if (ClientInvoiceId !=0)
            objDbManager.AddParameter("ClientInvoiceId ", ClientInvoiceId);
        if (!string.IsNullOrEmpty(PaymentType))
            objDbManager.AddParameter("PaymentType ", PaymentType);
        if (!string.IsNullOrEmpty(PayerName))
            objDbManager.AddParameter("PayerName", PayerName);
        if (!string.IsNullOrEmpty(PaymentMethodCode))
            objDbManager.AddParameter("PaymentMethodCode", PaymentMethodCode);

        if (!string.IsNullOrEmpty(CheckNumber))
            objDbManager.AddParameter("CheckNumber",CheckNumber);
        if (!string.IsNullOrEmpty(PaymentDate))
            objDbManager.AddParameter("PaymentDate", PaymentDate);
        if (!string.IsNullOrEmpty(PaymentAmount))
            objDbManager.AddParameter("PaymentAmount", PaymentAmount);
        return objDbManager.ExecuteDataSet("GeneratedClientInvoicesList");
    }
    /*************END SHAHID KAZMI 2/20/2018************/

}