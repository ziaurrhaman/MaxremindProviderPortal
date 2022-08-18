using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
/// <summary>
/// Summary description for ERAMasterDB
/// </summary>
public class ERAMasterDB
{
    public ERAMasterDB()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public long Add(ERAMaster objERAMaster, long? uploadfileId = null)
    {
        DBManager objDBManager = new DBManager();
        try
        {
            objDBManager.AddParameter("ERAMasterId", objERAMaster.ERAMasterId, SqlDbType.BigInt, 8, ParameterDirection.Output);

            objDBManager.AddParameter("PracticeId", objERAMaster.PracticeId);
            objDBManager.AddParameter("TransactionHandlingCode", objERAMaster.TransactionHandlingCode, SqlDbType.VarChar, 2);

            objDBManager.AddParameter("PaymentMethodCode", objERAMaster.PaymentMethodCode, SqlDbType.VarChar, 50);
            objDBManager.AddParameter("CheckIssueDate", objERAMaster.CheckIssueDate, SqlDbType.DateTime, 8);
            objDBManager.AddParameter("CheckNumber", objERAMaster.CheckNumber, SqlDbType.VarChar, 50);
            objDBManager.AddParameter("PaymentAmount", objERAMaster.PaymentAmount, SqlDbType.Money, 8);
            objDBManager.AddParameter("PaymentType", objERAMaster.PaymentType);
            objDBManager.AddParameter("PayerID837", objERAMaster.PayerID837);

            objDBManager.AddParameter("SenderDFIIdentifier", objERAMaster.SenderDFIIdentifier, SqlDbType.VarChar, 12);
            objDBManager.AddParameter("SenderBankAccountNumber", objERAMaster.SenderBankAccountNumber, SqlDbType.VarChar, 35);
            objDBManager.AddParameter("PayerIdentifier", objERAMaster.PayerIdentifier, SqlDbType.VarChar, 10);
            objDBManager.AddParameter("SupplementalCode", objERAMaster.SupplementalCode, SqlDbType.VarChar, 9);

            objDBManager.AddParameter("ReceiverDFINumber", objERAMaster.ReceiverDFINumber, SqlDbType.VarChar, 12);
            objDBManager.AddParameter("ReceiverAccountQualifier", objERAMaster.ReceiverAccountQualifier, SqlDbType.VarChar, 3);
            objDBManager.AddParameter("ReceiverAccountNumber", objERAMaster.ReceiverAccountNumber, SqlDbType.VarChar, 35);



            objDBManager.AddParameter("OrganizationId", objERAMaster.OrganizationId, SqlDbType.VarChar, 10);
            objDBManager.AddParameter("ReceiverIdentifier", objERAMaster.ReceiverIdentifier, SqlDbType.VarChar, 50);
            objDBManager.AddParameter("ERAGenerationDate", objERAMaster.ERAGenerationDate, SqlDbType.DateTime, 8);

            objDBManager.AddParameter("PayerName", objERAMaster.PayerName, SqlDbType.VarChar, 60);
            objDBManager.AddParameter("PayerAddress", objERAMaster.PayerAddress, SqlDbType.VarChar, 55);
            objDBManager.AddParameter("PayerCity", objERAMaster.PayerCity, SqlDbType.VarChar, 30);
            objDBManager.AddParameter("PayerState", objERAMaster.PayerState, SqlDbType.VarChar, 2);
            objDBManager.AddParameter("ZipCode", objERAMaster.ZipCode, SqlDbType.VarChar, 15);
            objDBManager.AddParameter("PayerContactPerson", objERAMaster.PayerContactPerson, SqlDbType.VarChar, 60);

            objDBManager.AddParameter("CommunicationNumberQualifier1", objERAMaster.CommunicationNumberQualifier1, SqlDbType.VarChar, 2);
            objDBManager.AddParameter("CommunicationNumber1", objERAMaster.CommunicationNumber1, SqlDbType.VarChar, 150);
            objDBManager.AddParameter("CommunicationNumberQualifier2", objERAMaster.CommunicationNumberQualifier2, SqlDbType.VarChar, 2);
            objDBManager.AddParameter("CommunicationNumber2", objERAMaster.CommunicationNumber2, SqlDbType.VarChar, 150);

            objDBManager.AddParameter("PayeeName", objERAMaster.PayeeName, SqlDbType.VarChar, 50);
            objDBManager.AddParameter("PayeeCodeQualifier", objERAMaster.PayeeCodeQualifier, SqlDbType.VarChar, 2);
            objDBManager.AddParameter("PayeeCode", objERAMaster.PayeeCode, SqlDbType.VarChar, 80);
            objDBManager.AddParameter("PayeeAddress", objERAMaster.PayeeAddress, SqlDbType.VarChar, 110);
            objDBManager.AddParameter("PayeeCity", objERAMaster.PayeeCity, SqlDbType.VarChar, 30);
            objDBManager.AddParameter("PayeeState", objERAMaster.PayeeState, SqlDbType.VarChar, 2);
            objDBManager.AddParameter("PayeeZip", objERAMaster.PayeeZip, SqlDbType.VarChar, 15);

            objDBManager.AddParameter("PaymentPosted", objERAMaster.PaymentPosted);
            objDBManager.AddParameter("Status", objERAMaster.Status);
            objDBManager.AddParameter("ClaimLevelPayments", objERAMaster.ClaimLevelPayments);

            objDBManager.AddParameter("PatientId", objERAMaster.PatientId);

            objDBManager.AddParameter("CreatedById", objERAMaster.CreatedById, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("CreatedDate", objERAMaster.CreatedDate, SqlDbType.DateTime, 8);
            objDBManager.AddParameter("Deleted", objERAMaster.Deleted, SqlDbType.Bit, 1);
            //Added by Khayyam adeel desc: ERAMaster Payment For
            objDBManager.AddParameter("PaymentFor", objERAMaster.PaymentFor);
            objDBManager.AddParameter("uploadfileId", uploadfileId);
            objDBManager.ExecuteNonQuery("ERAMaster_Add");

            objERAMaster.ERAMasterId = long.Parse(objDBManager.Parameters[0].Value.ToString());
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return objERAMaster.ERAMasterId;
    }
    public int Update(ERAMaster objERAMaster, long? uploadfileId = null, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager();

            objDBManager.AddParameter("ERAMasterId", objERAMaster.ERAMasterId, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("PracticeId", objERAMaster.PracticeId);
            objDBManager.AddParameter("PaymentAmount", objERAMaster.PaymentAmount);
            objDBManager.AddParameter("PaymentMethodCode", objERAMaster.PaymentMethodCode);
            objDBManager.AddParameter("CheckIssueDate", objERAMaster.CheckIssueDate);
            objDBManager.AddParameter("CheckNumber", objERAMaster.CheckNumber);
            objDBManager.AddParameter("PayerName", objERAMaster.PayerName);
            objDBManager.AddParameter("PayerAddress", objERAMaster.PayerAddress);
            objDBManager.AddParameter("PayerCity", objERAMaster.PayerCity);
            objDBManager.AddParameter("PayerState", objERAMaster.PayerState);
            objDBManager.AddParameter("ZipCode", objERAMaster.ZipCode);
            objDBManager.AddParameter("PayerID837", objERAMaster.PayerID837);
            objDBManager.AddParameter("PayerIdentifier", objERAMaster.PayerIdentifier, SqlDbType.VarChar, 10);
            objDBManager.AddParameter("PayerContactPerson", objERAMaster.PayerContactPerson);
            objDBManager.AddParameter("CommunicationNumberQualifier1", objERAMaster.CommunicationNumberQualifier1);
            objDBManager.AddParameter("CommunicationNumber1", objERAMaster.CommunicationNumber1);
            objDBManager.AddParameter("CommunicationNumberQualifier2", objERAMaster.CommunicationNumberQualifier2);
            objDBManager.AddParameter("CommunicationNumber2", objERAMaster.CommunicationNumber2);
            objDBManager.AddParameter("PayeeName", objERAMaster.PayeeName);
            objDBManager.AddParameter("PayeeCodeQualifier", objERAMaster.PayeeCodeQualifier);
            objDBManager.AddParameter("PayeeCode", objERAMaster.PayeeCode);
            objDBManager.AddParameter("PayeeAddress", objERAMaster.PayeeAddress);
            objDBManager.AddParameter("PayeeCity", objERAMaster.PayeeCity);
            objDBManager.AddParameter("PayeeState", objERAMaster.PayeeState);
            objDBManager.AddParameter("PayeeZip", objERAMaster.PayeeZip);
            objDBManager.AddParameter("PaymentType", objERAMaster.PaymentType);
            objDBManager.AddParameter("Status", objERAMaster.Status);
            objDBManager.AddParameter("ClaimLevelPayments", objERAMaster.ClaimLevelPayments);
            objDBManager.AddParameter("PatientId", objERAMaster.PatientId);
            objDBManager.AddParameter("ModifiedById", objERAMaster.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objERAMaster.ModifiedDate);
            if (!string.IsNullOrEmpty(uploadfileId.ToString()))
            {
                objDBManager.AddParameter("uploadfileId", uploadfileId);
            }
            return objDBManager.ExecuteNonQuery("ERAMaster_Update");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    /***************************added by QasimSAEED 4/2/2020************************************/
    public DataSet ERAMaster_GetClaimDetailbyMasterId(long ERAMasterId, long? claimid)
    {
        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("ERAMasterId", ERAMasterId);
        objDBManager.AddParameter("ClaimId", claimid);
        return objDBManager.ExecuteDataSet("ERAMaster_GetCheckDetailsOfEOB_CLMandChargesLevel");
    }
    /***************************END by QasimSAEED 4/2/2020************************************/
    public DataTable ERAMaster_GetAll()
    {
        DBManager objDBManager = new DBManager();

        return objDBManager.ExecuteDataTable("ERAMaster_GetAll");
    }

    public DataSet GetAllFilterByPatient(long PatientId, string PaymentDate, string PaymentMethodCode, string CheckNumber, string PaymentAmount, bool IsLeftToAllocatedGreaterThanZero, int Rows, int PageNumber, string SortBy)
    {
        DBManager objDbManager = new DBManager();

        objDbManager.AddParameter("PatientId", PatientId);

        if (!string.IsNullOrEmpty(CheckNumber))
        {
            objDbManager.AddParameter("CheckNumber", CheckNumber);
        }

        if (!string.IsNullOrEmpty(PaymentDate))
        {
            objDbManager.AddParameter("PaymentDate", Convert.ToDateTime(PaymentDate));
        }

        if (!string.IsNullOrEmpty(PaymentMethodCode))
        {
            objDbManager.AddParameter("PaymentMethodCode", PaymentMethodCode);
        }

        if (!string.IsNullOrEmpty(PaymentAmount))
        {
            objDbManager.AddParameter("PaymentAmount", Convert.ToDecimal(PaymentAmount));
        }

        if (IsLeftToAllocatedGreaterThanZero)
        {
            objDbManager.AddParameter("IsLeftToAllocatedGreaterThanZero", IsLeftToAllocatedGreaterThanZero);
        }



        objDbManager.AddParameter("Rows", Rows);
        objDbManager.AddParameter("PageNumber", PageNumber);
        objDbManager.AddParameter("SortBy", SortBy);

        return objDbManager.ExecuteDataSet("ERA_GetAllFilterByPatient");
    }

    public DataSet ERAMaster_GetBySearchCriteria(long practiceId, string checkNumber, string insurance, string paymentDate, string paymentType, string paymentMethodCode, string checkAmount, string paymentPosted, string status, string Unapplied, int rows, int pageNumber, string sortBy, string PostedDate, string UnappliedCheckBox)
    {
        DBManager objDbManager = new DBManager();

        objDbManager.AddParameter("@PracticeID", practiceId);

        if (!string.IsNullOrEmpty(checkNumber))
        {
            objDbManager.AddParameter("@CheckNumber", checkNumber);
        }

        if (!string.IsNullOrEmpty(Unapplied))
        {
            objDbManager.AddParameter("@Unapplied", Unapplied);
        }

        if (!string.IsNullOrEmpty(insurance))
        {
            objDbManager.AddParameter("@Insurance", insurance);
        }

        if (!string.IsNullOrEmpty(paymentDate))
        {
            objDbManager.AddParameter("@PaymentDate", Convert.ToDateTime(paymentDate));
        }

        if (!string.IsNullOrEmpty(paymentType))
        {
            objDbManager.AddParameter("@PaymentType", paymentType);
        }

        if (!string.IsNullOrEmpty(paymentMethodCode))
        {
            objDbManager.AddParameter("PaymentMethodCode", paymentMethodCode);
        }

        if (!string.IsNullOrEmpty(checkAmount))
        {
            objDbManager.AddParameter("CheckAmount", Convert.ToDecimal(checkAmount));
        }

        if (!string.IsNullOrEmpty(paymentPosted))
        {
            objDbManager.AddParameter("PaymentPosted", Convert.ToDecimal(paymentPosted));
        }

        if (!string.IsNullOrEmpty(status))
        {
            objDbManager.AddParameter("Status", status);
        }


        objDbManager.AddParameter("@Rows", rows);
        objDbManager.AddParameter("@PageNumber", pageNumber);
        objDbManager.AddParameter("@SortBy", sortBy);

        //Added By Rizwan kharal 21May2018
        if (!string.IsNullOrEmpty(PostedDate))
        {
            objDbManager.AddParameter("@PostedDate", PostedDate);
        }
        //Added By Rizwan kharal 27June2018
        if (!string.IsNullOrEmpty(UnappliedCheckBox))
        {
            objDbManager.AddParameter("@UnappliedCheckBox", UnappliedCheckBox);
        }
        return objDbManager.ExecuteDataSet("ERA_GetBySearchCriteria");

    }

    public int ERAMaster_GetMaximumRecordNumber()
    {
        DBManager objDBManager = new DBManager();
        return Convert.ToInt32(objDBManager.ExecuteScalar("ERAMaster_GetMaximumRecordNumber"));
    }

    public DataTable ERAMaster_GetLatestRecords(int MaximumRecordNumber)
    {
        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("@MaxERAMasterId", MaximumRecordNumber);
        return objDBManager.ExecuteDataTable("ERAMaster_GetLatestRecords");
    }

    public void ERAMaster_AddPaymentPosted(double PaymentPosted, long ERAMasterId)
    {
        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("PaymentPosted", PaymentPosted);
        objDBManager.AddParameter("ERAMasterId", ERAMasterId);
        objDBManager.ExecuteNonQuery("ERAMaster_AddPaymentPosted");
    }

    public decimal ERAMaster_GetPaymentAmount(long ERAMasterId)
    {
        DBManager objDbManager = new DBManager();
        objDbManager.AddParameter("ERAMasterId", ERAMasterId);
        return Convert.ToDecimal(objDbManager.ExecuteScalar("ERAMaster_GetPaymentAmount"));
    }

    public DataTable ERAMaster_GetByERAMasterId(long ERAMasterId)
    {
        DBManager objDbManager = new DBManager();
        objDbManager.AddParameter("ERAMasterId", ERAMasterId);
        return objDbManager.ExecuteDataTable("ERAMaster_GetByERAMasterId");
    }

    public void ERAMaster_UpdatePaymentPosted(long ERAMasterId, decimal PaymentPosted)
    {
        DBManager objDbManager = new DBManager();
        objDbManager.AddParameter("ERAMasterId", ERAMasterId);
        objDbManager.AddParameter("PaymentPosted", PaymentPosted);
        objDbManager.ExecuteNonQuery("ERAMaster_UpdatePaymentPosted");
    }

    public DataTable GetByCheckNumber(string CheckNumber, string PaymentDate = "", string PaymentAmount = "")
    {
        DBManager objDBManager = new DBManager();

        objDBManager.AddParameter("CheckNumber", CheckNumber);

        if (!string.IsNullOrEmpty(PaymentDate))
        {
            objDBManager.AddParameter("PaymentDate", Convert.ToDateTime(PaymentDate));
        }

        if (!string.IsNullOrEmpty(PaymentAmount))
        {
            objDBManager.AddParameter("PaymentAmount", Convert.ToDecimal(PaymentAmount));
        }

        return objDBManager.ExecuteDataTable("ERAMaster_GetByCheckNumber");
    }
    public DataTable GetByCheckNumber(string CheckNumber, string PaymentType, long? PracticeId)
    {
        DBManager objDBManager = new DBManager();

        objDBManager.AddParameter("CheckNumber", CheckNumber);
        if (!string.IsNullOrEmpty(PracticeId.ToString()))
        {
            objDBManager.AddParameter("PracticeId", PracticeId);
        }
        objDBManager.AddParameter("PaymentType", PaymentType);
        //if (!string.IsNullOrEmpty(PaymentDate))
        //{
        //    objDBManager.AddParameter("PaymentDate", Convert.ToDateTime(PaymentDate));
        //}

        //if (!string.IsNullOrEmpty(PaymentAmount))
        //{
        //    objDBManager.AddParameter("PaymentAmount", Convert.ToDecimal(PaymentAmount));
        //}

        return objDBManager.ExecuteDataTable("ERAMaster_GetByCheckNumber");
    }

    public DataTable GetPayerInformationForERA(long PayerId, string PaymentType)
    {
        DBManager objDBManager = new DBManager();

        objDBManager.AddParameter("PayerId", PayerId);
        objDBManager.AddParameter("PaymentType", PaymentType);

        return objDBManager.ExecuteDataTable("ERAMaster_GetPayerInformationForERA");
    }

    public DataTable VerifyImportedCheck(string CheckNumber, DateTime? CheckDate, string PayerCode)
    {
        DBManager objDbManager = new DBManager();

        objDbManager.AddParameter("CheckNumber", CheckNumber);
        objDbManager.AddParameter("CheckDate", CheckDate);
        objDbManager.AddParameter("PayerCode", PayerCode);

        return objDbManager.ExecuteDataTable("ERA_VerifyImportedCheck");
    }

    public DataTable GetPracticeID(string sNPI, string sTaxId)
    {
        DBManager objDbManager = new DBManager();

        if (sNPI != "")
            objDbManager.AddParameter("NPI", sNPI);

        if (sTaxId != "")
            objDbManager.AddParameter("TAXID", sTaxId);


        return objDbManager.ExecuteDataTable("GetPracticeID");
    }

    public DataSet PatientPayment_GetAllFilter(long PatientId, string PayerID837p, string PayerID837s, string PayerID837o, string PaymentDate, string CheckNumber, string PayerName, string PaymentAmount, string PaymentPosted, bool IsLeftToAllocatedGreaterThanZero, int Rows, int PageNumber, string SortBy)
    {
        DBManager objDBManager = new DBManager();

        if (PatientId != 0)
        {
            objDBManager.AddParameter("PatientId", PatientId);
        }

        if (!string.IsNullOrEmpty(PayerID837p))
        {
            objDBManager.AddParameter("PayerID837p", PayerID837p);
        }

        if (!string.IsNullOrEmpty(PayerID837s))
        {
            objDBManager.AddParameter("PayerID837s", PayerID837s);
        }

        if (!string.IsNullOrEmpty(PayerID837o))
        {
            objDBManager.AddParameter("PayerID837o", PayerID837o);
        }


        if (!string.IsNullOrEmpty(PaymentDate))
        {
            objDBManager.AddParameter("PaymentDate", Convert.ToDateTime(PaymentDate));
        }

        if (!string.IsNullOrEmpty(CheckNumber))
        {
            objDBManager.AddParameter("CheckNumber", CheckNumber);
        }

        if (!string.IsNullOrEmpty(PayerName))
        {
            objDBManager.AddParameter("PayerName", PayerName);
        }

        if (!string.IsNullOrEmpty(PaymentAmount))
        {
            objDBManager.AddParameter("PaymentAmount", Convert.ToDecimal(PaymentAmount));
        }

        if (!string.IsNullOrEmpty(PaymentPosted))
        {
            objDBManager.AddParameter("PaymentPosted", PaymentPosted);
        }

        if (IsLeftToAllocatedGreaterThanZero)
        {
            objDBManager.AddParameter("IsLeftToAllocatedGreaterThanZero", IsLeftToAllocatedGreaterThanZero);
        }

        objDBManager.AddParameter("Rows", Rows);
        objDBManager.AddParameter("PageNumber", PageNumber);
        objDBManager.AddParameter("SortBy", SortBy);

        return objDBManager.ExecuteDataSet("ERA_PatientPayment_GetAllFilter");
    }

    public DataSet PatientPayment_GetByPracticeId(long PracticeId, string PaymentDate, string CheckNumber, string PayerName, string PaymentAmount, string PaymentPosted, bool IsLeftToAllocatedGreaterThanZero, int Rows, int PageNumber, string SortBy)
    {
        DBManager objDBManager = new DBManager();

        objDBManager.AddParameter("PracticeId", PracticeId);

        if (!string.IsNullOrEmpty(PaymentDate))
        {
            objDBManager.AddParameter("PaymentDate", Convert.ToDateTime(PaymentDate));
        }

        if (!string.IsNullOrEmpty(CheckNumber))
        {
            objDBManager.AddParameter("CheckNumber", CheckNumber);
        }

        if (!string.IsNullOrEmpty(PayerName))
        {
            objDBManager.AddParameter("PayerName", PayerName);
        }

        if (!string.IsNullOrEmpty(PaymentAmount))
        {
            objDBManager.AddParameter("PaymentAmount", Convert.ToDecimal(PaymentAmount));
        }

        if (!string.IsNullOrEmpty(PaymentPosted))
        {
            objDBManager.AddParameter("PaymentPosted", PaymentPosted);
        }

        if (IsLeftToAllocatedGreaterThanZero)
        {
            objDBManager.AddParameter("IsLeftToAllocatedGreaterThanZero", IsLeftToAllocatedGreaterThanZero);
        }

        objDBManager.AddParameter("Rows", Rows);
        objDBManager.AddParameter("PageNumber", PageNumber);
        objDBManager.AddParameter("SortBy", SortBy);

        return objDBManager.ExecuteDataSet("ERA_PatientPayment_GetByPracticeId");
    }

    //public DataSet Report_PatientPayments(int Rows, int PageNumber, string SortBy)
    //{
    //    DBManager objDBManager = new DBManager();

    //    objDBManager.AddParameter("Rows", Rows);
    //    objDBManager.AddParameter("PageNumber", PageNumber);

    //    if (!string.IsNullOrEmpty(SortBy))
    //    {
    //        objDBManager.AddParameter("SortBy", SortBy);
    //    }

    //    return objDBManager.ExecuteDataSet("ERAMaster_Report_PatientPayments");
    //}
    public DataSet Report_PatientPayments(long PracticeId, int Rows, int PageNumber, string SortBy)
    {
        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("PracticeId", PracticeId);
        objDBManager.AddParameter("Rows", Rows);
        objDBManager.AddParameter("PageNumber", PageNumber);

        if (!string.IsNullOrEmpty(SortBy))
        {
            objDBManager.AddParameter("SortBy", SortBy);
        }

        return objDBManager.ExecuteDataSet("ERAMaster_Report_PatientPayments");
    }
    public DataSet Report_PatientPayments(long PracticeId, int Rows, int PageNumber, string SortBy, string DateType, string DateFrom, string DateTo)
    {
        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("PracticeId", PracticeId);
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
            objDBManager.AddParameter("DateFrom", DateFrom);
        }
        if (!string.IsNullOrEmpty(DateTo))
        {
            objDBManager.AddParameter("DateTo", DateTo);
        }

        return objDBManager.ExecuteDataSet("ERAMaster_Report_PatientPayments");
    }

    public DataSet Report_DailyPayments(long PracticeID, string PaymentDate, int Rows, int PageNumber, string SortBy)
    {
        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("practiceID", PracticeID);
        if (!string.IsNullOrEmpty(PaymentDate))
        {
            objDBManager.AddParameter("PaymentDate", PaymentDate);
        }

        objDBManager.AddParameter("Rows", Rows);
        objDBManager.AddParameter("PageNumber", PageNumber);

        if (!string.IsNullOrEmpty(SortBy))
        {
            objDBManager.AddParameter("SortBy", SortBy);
        }

        return objDBManager.ExecuteDataSet("ERAMaster_Report_DailyPayments");
    }

    public DataSet GetBySearchCriteria(long PracticeId, string CheckNumber, string CheckDateStr, string PostDateStr, string CheckAmount,
        string PostedAmount, string Insurance, int Rows, int PageNumber, string SortBy, bool ERA, bool EOB, bool Unsettled,
        string verify, bool? IsImportedDataOnly,
        string PostDateFrom = null, string PostDateTo = null, string DATEOFSERIVCEFROM = null,
        string DATEOFSERIVCETO = null, string BillingProviderId = null, string @DateType = null)
    {
        DBManager objDbManager = new DBManager();

        objDbManager.AddParameter("PracticeId", PracticeId);
        objDbManager.AddParameter("Rows", Rows);
        objDbManager.AddParameter("PageNumber", PageNumber);
        objDbManager.AddParameter("SortBy", SortBy);

        if (!string.IsNullOrEmpty(CheckNumber))
        {
            objDbManager.AddParameter("CheckNumber", CheckNumber);
        }

        // DateTime CheckDate;

        if (!string.IsNullOrEmpty(CheckDateStr))
        {
            //if (DateTime.TryParse(CheckDateStr, out CheckDate))
            //{
            objDbManager.AddParameter("CheckDate", CheckDateStr);
            //}
        }
        //DateTime PostDate;
        if (!string.IsNullOrEmpty(PostDateStr))
        {
            //if (DateTime.TryParse(PostDateStr, out PostDate))
            //{
            objDbManager.AddParameter("CreatedDate", PostDateStr);
            //}
        }

        if (!string.IsNullOrEmpty(CheckAmount))
            objDbManager.AddParameter("CheckAmount", CheckAmount);

        if (!string.IsNullOrEmpty(PostedAmount))
            objDbManager.AddParameter("PostedAmount", PostedAmount);

        if (Insurance != "Patient Payment")
        {
            if (!string.IsNullOrEmpty(Insurance))
                objDbManager.AddParameter("Insurance", Insurance);
        }
        string PaymentMethod = "";
        if (ERA)
            PaymentMethod += "ERA";

        if (EOB)
            PaymentMethod += ",EOB";
        if (Insurance == "Patient Payment")
        {
            PaymentMethod = "PAT";
        }

        if (!string.IsNullOrEmpty(PaymentMethod))
            objDbManager.AddParameter("PaymentType", PaymentMethod);

        if (Unsettled)
            objDbManager.AddParameter("Unsettled", Unsettled);

        if (!string.IsNullOrEmpty(verify))
            objDbManager.AddParameter("@Verified", verify);

        if (IsImportedDataOnly != null)
        {
            objDbManager.AddParameter("@IsImported", IsImportedDataOnly);
        }

        if (PostDateFrom != null && PostDateFrom != "")
        {
            objDbManager.AddParameter("@DateFrom", PostDateFrom);
        }

        if (PostDateTo != null && PostDateTo != "")
        {
            objDbManager.AddParameter("@DateTo", @PostDateTo);
        }
        if (DATEOFSERIVCEFROM != null && DATEOFSERIVCEFROM != "")
        {
            objDbManager.AddParameter("@DateFrom", DATEOFSERIVCEFROM);
        }
        if (DATEOFSERIVCETO != null && DATEOFSERIVCETO != "")
        {
            objDbManager.AddParameter("@DateTo", DATEOFSERIVCETO);
        }
        if (BillingProviderId != null && BillingProviderId != "")
        {
            objDbManager.AddParameter("@PhysicianNPI", BillingProviderId);
        }
        if (DateType != null && DateType != "")
        {
            objDbManager.AddParameter("@DateType", @DateType);
        }

        return objDbManager.ExecuteDataSet("ERAMaster_GetBySearchCriteriaFilterbyProvider");
    }

    public DataTable GetChargesPaymentSummary(long PracticeId, DateTime DateFrom, DateTime DateTo, int InsuranceId = 0, int PracticeLocationsId = 0,
        int ProviderId = 0, bool? IsImportedDataOnly = null)
    {
        DBManager objDbManager = new DBManager();

        if (PracticeId != null)
            objDbManager.AddParameter("PracticeId", PracticeId);

        if (DateFrom.ToString() != "")
            objDbManager.AddParameter("DateFrom", DateFrom);

        if (DateTo.ToString() != "")
            objDbManager.AddParameter("DateTo", DateTo);

        if (InsuranceId != null && InsuranceId != 0)
            objDbManager.AddParameter("InsuranceId", InsuranceId);

        if (PracticeLocationsId != null && PracticeLocationsId != 0)
            objDbManager.AddParameter("PracticeLocationsId", PracticeLocationsId);

        if (ProviderId != null && ProviderId != 0)
            objDbManager.AddParameter("ProviderId", ProviderId);
        if (IsImportedDataOnly != null)
        {
            objDbManager.AddParameter("@IsImported", IsImportedDataOnly);
        }

        return objDbManager.ExecuteDataTable("GetChargesPaymentSummary");
    }



    //Rizwan kharal
    //10 Nov 2017
    // For Payment Summary Report
    public DataSet PaymentSummary(long PracticeId, string DateType, string DateFrom, string DateTo, string PayerType, string Insurance, string Patient)
    {
        DBManager objDBManager = new DBManager();

        if (PracticeId != 0)
        {
            objDBManager.AddParameter("PracticeId", PracticeId);
        }
        if (DateType != "")
        {
            objDBManager.AddParameter("DateType", DateType);
        }

        if (DateFrom != "")
        {
            objDBManager.AddParameter("FromDate", DateFrom);
        }
        if (DateTo != "")
        {
            objDBManager.AddParameter("ToDate", DateTo);
        }
        if (PayerType != "")
        {
            objDBManager.AddParameter("PayerType", PayerType);
        }
        if (Insurance != "")
        {
            objDBManager.AddParameter("Insurance", Insurance);
        }
        if (Patient != "")
        {
            objDBManager.AddParameter("Patient", Patient);
        }

        return objDBManager.ExecuteDataSet("PaymentSummary");
    }

    public DataSet UpdateCheckVerifingStatus(long practiceId, int ERAMasterId, bool Verifiedstatus)
    {
        DBManager objDbManager = new DBManager();
        if (practiceId != null)
            objDbManager.AddParameter("@practiceId", practiceId);
        if (ERAMasterId != null)
            objDbManager.AddParameter("@MasterId", ERAMasterId);
        if (Verifiedstatus != null)
            objDbManager.AddParameter("@Verified", Verifiedstatus);


        return objDbManager.ExecuteDataSet("UpdateVerifiedStatus");
    }

    //Rizwan kharal
    // 29 Nov 2017
    // Showing Payments Againts UserId
    public DataSet Payments_GetAllByUserId(long PracticeId, int UserId, string CheckNumber, string CheckDateStr, string PostDateStr, string CheckAmount, string PostedAmount, string Insurance, int Rows, int PageNumber, string SortBy, bool ERA, bool EOB, bool Unsettled, string verify)
    {
        DBManager objDbManager = new DBManager();

        objDbManager.AddParameter("PracticeId", PracticeId);
        objDbManager.AddParameter("Rows", Rows);
        objDbManager.AddParameter("PageNumber", PageNumber);
        objDbManager.AddParameter("SortBy", SortBy);
        objDbManager.AddParameter("@CreatedId", UserId);

        if (!string.IsNullOrEmpty(CheckNumber))
        {
            objDbManager.AddParameter("CheckNumber", CheckNumber);
        }

        DateTime CheckDate;

        if (!string.IsNullOrEmpty(CheckDateStr))
        {
            if (DateTime.TryParse(CheckDateStr, out CheckDate))
            {
                objDbManager.AddParameter("CheckDate", CheckDate);
            }
        }
        DateTime PostDate;
        if (!string.IsNullOrEmpty(PostDateStr))
        {
            if (DateTime.TryParse(PostDateStr, out PostDate))
            {
                objDbManager.AddParameter("CreatedDate", PostDate);
            }
        }

        if (!string.IsNullOrEmpty(CheckAmount))
            objDbManager.AddParameter("CheckAmount", CheckAmount);

        if (!string.IsNullOrEmpty(PostedAmount))
            objDbManager.AddParameter("PostedAmount", PostedAmount);

        if (!string.IsNullOrEmpty(Insurance))
            objDbManager.AddParameter("Insurance", Insurance);

        string PaymentMethod = "";
        if (ERA)
            PaymentMethod += "ERA";

        if (EOB)
            PaymentMethod += ",EOB";

        if (!string.IsNullOrEmpty(PaymentMethod))
            objDbManager.AddParameter("PaymentType", PaymentMethod);

        if (Unsettled)
            objDbManager.AddParameter("Unsettled", Unsettled);

        if (!string.IsNullOrEmpty(verify))
            objDbManager.AddParameter("@Verified", verify);

        return objDbManager.ExecuteDataSet("Payments_GetAllByUserId");
    }
    public DataSet VerifyImportedCheck(long practiceID, string CheckNumber, DateTime? CheckDate, string PayerCode, string PayerName)
    {
        DBManager objDbManager = new DBManager();
        objDbManager.AddParameter("practiceId", practiceID);
        objDbManager.AddParameter("CheckNumber", CheckNumber);
        objDbManager.AddParameter("CheckDate", CheckDate);
        objDbManager.AddParameter("PayerCode", PayerCode);
        //payerName parameter added by ali imran 2/16/2017
        objDbManager.AddParameter("payerName", PayerName);
        return objDbManager.ExecuteDataSet("ERA_VerifyImportedCheck");
    }
    public DataSet Report_DailyPayments(long PracticeID, int Rows, int PageNumber, string SortBy, string DateType, string PaymentDate, string PostDate)
    {
        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("practiceID", PracticeID);


        objDBManager.AddParameter("Rows", Rows);
        objDBManager.AddParameter("PageNumber", PageNumber);

        if (!string.IsNullOrEmpty(SortBy))
        {
            objDBManager.AddParameter("SortBy", SortBy);
        }
        //Changed Added By Rizwan 4May2018
        //Added 2 Parameters DateType Created Date
        if (!string.IsNullOrEmpty(DateType))
        {
            objDBManager.AddParameter("DateType", DateType);
        }
        if (!string.IsNullOrEmpty(PaymentDate))
        {
            objDBManager.AddParameter("PaymentDate", PaymentDate);
        }
        if (!string.IsNullOrEmpty(PostDate))
        {
            objDBManager.AddParameter("PostDate", PostDate);
        }
        return objDBManager.ExecuteDataSet("ERAMaster_Report_DailyPayments");
    }
    public DataSet Report_DailyPayments(long PracticeID, int Rows, int PageNumber, string SortBy, string DateType)
    {
        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("practiceID", PracticeID);


        objDBManager.AddParameter("Rows", Rows);
        objDBManager.AddParameter("PageNumber", PageNumber);

        if (!string.IsNullOrEmpty(SortBy))
        {
            objDBManager.AddParameter("SortBy", SortBy);
        }
        //Changed Added By Rizwan 4May2018
        //Added 2 Parameters DateType Created Date
        if (!string.IsNullOrEmpty(DateType))
        {
            objDBManager.AddParameter("DateType", DateType);
        }
        //if (!string.IsNullOrEmpty(PaymentDate))
        //{
        //    objDBManager.AddParameter("PaymentDate", PaymentDate);
        //}
        //if (!string.IsNullOrEmpty(PostDate))
        //{
        //    objDBManager.AddParameter("PostDate", PostDate);
        //}
        return objDBManager.ExecuteDataSet("ERAMaster_Report_DailyPayments");
    }
}