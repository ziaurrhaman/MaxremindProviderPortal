using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;

/// <summary>
/// Summary description for ClaimChargesDB
/// </summary>
public class ClaimChargesDB
{
	public ClaimChargesDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    
    public long Add(ClaimCharges objClaimCharges, SqlTransaction objSqlTransaction = null)
    {
        DBManager objDBManager = new DBManager(objSqlTransaction);
        
        try
        {
            objDBManager.AddParameter("ClaimChargesId", objClaimCharges.ClaimChargesId, SqlDbType.Int, 4, ParameterDirection.Output);
            
            objDBManager.AddParameter("ClaimId", objClaimCharges.ClaimId);
            
            objDBManager.AddParameter("CPTCode", objClaimCharges.CPTCode);
            objDBManager.AddParameter("ServiceDate", objClaimCharges.ServiceDate);
            objDBManager.AddParameter("ServiceUnits", objClaimCharges.ServiceUnits);
            objDBManager.AddParameter("TotalCharges", objClaimCharges.TotalCharges);
            objDBManager.AddParameter("SequenceNumber", objClaimCharges.SequenceNumber);
            objDBManager.AddParameter("Modifier1", objClaimCharges.Modifier1);
            objDBManager.AddParameter("Modifier2", objClaimCharges.Modifier2);
            objDBManager.AddParameter("Modifier3", objClaimCharges.Modifier3);
            objDBManager.AddParameter("Modifier4", objClaimCharges.Modifier4);
            objDBManager.AddParameter("DXPointer1", objClaimCharges.DXPointer1);
            objDBManager.AddParameter("DXPointer2", objClaimCharges.DXPointer2);
            objDBManager.AddParameter("DXPointer3", objClaimCharges.DXPointer3);
            objDBManager.AddParameter("DXPointer4", objClaimCharges.DXPointer4);
            objDBManager.AddParameter("DXPointer5", objClaimCharges.DXPointer5);
            objDBManager.AddParameter("DXPointer6", objClaimCharges.DXPointer6);
            objDBManager.AddParameter("DXPointer7", objClaimCharges.DXPointer7);
            objDBManager.AddParameter("DXPointer8", objClaimCharges.DXPointer8);
            objDBManager.AddParameter("IncludeInSubmission", objClaimCharges.IncludeInSubmission);
            objDBManager.AddParameter("BillingStatus", objClaimCharges.BillingStatus);
            objDBManager.AddParameter("Drug", objClaimCharges.Drug);
            objDBManager.AddParameter("UnitCode", objClaimCharges.UnitCode);
            
            objDBManager.AddParameter("IsSuperBill", objClaimCharges.IsSuperBill);
            
            objDBManager.AddParameter("AllowedAmount", objClaimCharges.AllowedAmount);
            objDBManager.AddParameter("PaidAmount", objClaimCharges.PaidAmount);
            objDBManager.AddParameter("PriInsPaidAmount", objClaimCharges.PriInsPaidAmount);
            objDBManager.AddParameter("SecInsPaidAmount", objClaimCharges.SecInsPaidAmount);
            objDBManager.AddParameter("OTHInsPaidAmount", objClaimCharges.OTHInsPaidAmount);
            objDBManager.AddParameter("PatPaidAmount", objClaimCharges.PatPaidAmount);
            objDBManager.AddParameter("AdjustedAmount", objClaimCharges.AdjustedAmount);
            objDBManager.AddParameter("WriteOffAmount", objClaimCharges.WriteOffAmount);
            objDBManager.AddParameter("BalanceDue", objClaimCharges.BalanceDue);
            
            objDBManager.AddParameter("CreatedDate", objClaimCharges.CreatedDate);
            objDBManager.AddParameter("CreatedById", objClaimCharges.CreatedById);
            
            objDBManager.ExecuteNonQuery("ClaimCharges_Add");
            
            objClaimCharges.ClaimChargesId = long.Parse(objDBManager.Parameters[0].Value.ToString());
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return objClaimCharges.ClaimChargesId;
    }
    
    public int Update(ClaimCharges objClaimCharges, SqlTransaction objSqlTransaction = null)
    {
        DBManager objDBManager = new DBManager(objSqlTransaction);
        int ReturnValue = 0;
        try
        {
            objDBManager.AddParameter("ClaimChargesId", objClaimCharges.ClaimChargesId, SqlDbType.Int, 4);

            objDBManager.AddParameter("ClaimId", objClaimCharges.ClaimId);
            objDBManager.AddParameter("CPTCode", objClaimCharges.CPTCode);
            objDBManager.AddParameter("ServiceDate", objClaimCharges.ServiceDate);
            objDBManager.AddParameter("ServiceUnits", objClaimCharges.ServiceUnits);
            objDBManager.AddParameter("TotalCharges", objClaimCharges.TotalCharges);
            objDBManager.AddParameter("SequenceNumber", objClaimCharges.SequenceNumber);
            objDBManager.AddParameter("Modifier1", objClaimCharges.Modifier1);
            objDBManager.AddParameter("Modifier2", objClaimCharges.Modifier2);
            objDBManager.AddParameter("Modifier3", objClaimCharges.Modifier3);
            objDBManager.AddParameter("Modifier4", objClaimCharges.Modifier4);
            objDBManager.AddParameter("DXPointer1", objClaimCharges.DXPointer1);
            objDBManager.AddParameter("DXPointer2", objClaimCharges.DXPointer2);
            objDBManager.AddParameter("DXPointer3", objClaimCharges.DXPointer3);
            objDBManager.AddParameter("DXPointer4", objClaimCharges.DXPointer4);
            objDBManager.AddParameter("DXPointer5", objClaimCharges.DXPointer5);
            objDBManager.AddParameter("DXPointer6", objClaimCharges.DXPointer6);
            objDBManager.AddParameter("DXPointer7", objClaimCharges.DXPointer7);
            objDBManager.AddParameter("DXPointer8", objClaimCharges.DXPointer8);
            objDBManager.AddParameter("IncludeInSubmission", objClaimCharges.IncludeInSubmission);
            objDBManager.AddParameter("BillingStatus", objClaimCharges.BillingStatus);
            objDBManager.AddParameter("Drug", objClaimCharges.Drug);
            objDBManager.AddParameter("UnitCode", objClaimCharges.UnitCode);
            objDBManager.AddParameter("ModifiedDate", objClaimCharges.ModifiedDate);
            objDBManager.AddParameter("ModifiedById", objClaimCharges.ModifiedById);
            objDBManager.AddParameter("Deleted", objClaimCharges.Deleted);
            
            ReturnValue = objDBManager.ExecuteNonQuery("ClaimCharges_Update");
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ReturnValue;
    }
    
    public int UpdateFromSuperBill(ClaimCharges objClaimCharges, SqlTransaction objSqlTransaction = null)
    {
        DBManager objDBManager = new DBManager(objSqlTransaction);
        int ReturnValue = 0;
        
        try
        {
            objDBManager.AddParameter("ClaimChargesId", objClaimCharges.ClaimChargesId, SqlDbType.Int, 4);
            
            objDBManager.AddParameter("ClaimId", objClaimCharges.ClaimId);
            
            objDBManager.AddParameter("CPTCode", objClaimCharges.CPTCode);
            objDBManager.AddParameter("ServiceDate", objClaimCharges.ServiceDate);
            objDBManager.AddParameter("ServiceUnits", objClaimCharges.ServiceUnits);
            objDBManager.AddParameter("Modifier1", objClaimCharges.Modifier1);
            
            objDBManager.AddParameter("IsSuperBill", objClaimCharges.IsSuperBill);
            
            objDBManager.AddParameter("ModifiedDate", objClaimCharges.ModifiedDate);
            objDBManager.AddParameter("ModifiedById", objClaimCharges.ModifiedById);
            
            objDBManager.AddParameter("Deleted", objClaimCharges.Deleted);
            
            ReturnValue = objDBManager.ExecuteNonQuery("ClaimCharges_UpdateFromSuperBill");
        }
        catch (Exception ex)
        {
            throw ex;
        }
        
        return ReturnValue;
    }
    
    public int UpdateFromPaymentAllocation(ClaimCharges objClaimCharges, SqlTransaction objSqlTransaction = null)
    {
        DBManager objDBManager = new DBManager(objSqlTransaction);
        int ReturnValue = 0;
        
        try
        {
            objDBManager.AddParameter("ClaimChargesId", objClaimCharges.ClaimChargesId, SqlDbType.Int, 4);
            
            objDBManager.AddParameter("BalanceDue", objClaimCharges.BalanceDue);
            objDBManager.AddParameter("WriteOffAmount", objClaimCharges.WriteOffAmount);
            objDBManager.AddParameter("PaidAmount", objClaimCharges.PaidAmount);
            objDBManager.AddParameter("PatPaidAmount", objClaimCharges.PatPaidAmount);
            
            objDBManager.AddParameter("ModifiedById", objClaimCharges.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objClaimCharges.ModifiedDate);
            
            ReturnValue = objDBManager.ExecuteNonQuery("ClaimCharges_UpdateFromPaymentAllocation");
        }
        catch (Exception ex)
        {
            throw ex;
        }
        
        return ReturnValue;
    }
    
    public int Delete(ClaimCharges objClaimCharges, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);
            
            objDBManager.AddParameter("ClaimChargesId", objClaimCharges.ClaimChargesId);
            objDBManager.AddParameter("ModifiedDate", objClaimCharges.ModifiedDate);
            objDBManager.AddParameter("ModifiedById", objClaimCharges.ModifiedById);
            
            return objDBManager.ExecuteNonQuery("ClaimCharges_Delete");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int DeleteByClaimId(long ClaimId, long ModifiedById, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);
            
            objDBManager.AddParameter("ClaimId", ClaimId);

            objDBManager.AddParameter("ModifiedById", ModifiedById);
            objDBManager.AddParameter("ModifiedDate", DateTime.Now);
            
            return objDBManager.ExecuteNonQuery("ClaimCharges_DeleteByClaimId");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    
    public void DeleteClaimCharges(string claimChargesId, long claimId, long modifiedBy, DateTime modifiedDate)
    {
        var objDbManager = new DBManager();
        objDbManager.AddParameter("ClaimChargesId", claimChargesId);
        objDbManager.AddParameter("ClaimId", claimId);
        objDbManager.AddParameter("ModifiedBy", modifiedBy);
        objDbManager.AddParameter("ModifiedDate", modifiedDate);
        objDbManager.ExecuteNonQuery("Claim_DeleteClaimCharges");
    }
    
    public DataTable ClaimCharges_GetByClaimId(long ClaimId)
    {
        DBManager objDBManager = new DBManager();

        objDBManager.AddParameter("ClaimId", ClaimId);

        return objDBManager.ExecuteDataTable("ClaimCharges_GetByClaimId");
    }
    
    public DataTable GetByClaimForClaimServicesInClaimDetail(long ClaimId)
    {
        DBManager objDBManager = new DBManager();
        
        objDBManager.AddParameter("ClaimId", ClaimId);
        
        return objDBManager.ExecuteDataTable("ClaimCharges_GetByClaim_ForClaimServicesInClaimDetail");
    }
    
    public DataTable GetByClaimId_SuperBill(long ClaimId)
    {
        DBManager objDBManager = new DBManager();
        
        objDBManager.AddParameter("ClaimId", ClaimId);

        return objDBManager.ExecuteDataTable("ClaimCharges_GetForSuperBill");
    }

    public DataTable GetAllForPaymentAllocation(long PatientId, string DOS, bool IsAmountDueGreaterThanZero, bool IsServicesBilledToPatient)
    {
        DBManager objDBManager = new DBManager();
        
        objDBManager.AddParameter("PatientId", PatientId);

        if (!string.IsNullOrEmpty(DOS))
        {
            objDBManager.AddParameter("DOS", DOS);
        }

        if (IsAmountDueGreaterThanZero)
        {
            objDBManager.AddParameter("IsAmountDueGreaterThanZero", IsAmountDueGreaterThanZero);
        }

        if (IsServicesBilledToPatient)
        {
            objDBManager.AddParameter("IsServicesBilledToPatient", IsServicesBilledToPatient);
        }
        
        return objDBManager.ExecuteDataTable("ClaimCharges_GetAllForPaymentAllocation");
    }

    public DataSet TOPTENPROCEDURES_SUMMARYReport(int rows, int pageno, long PracticeId, string CptCode)
    {
        try
        {
            DBManager objDBManager = new DBManager();

            objDBManager.AddParameter("PracticeId", PracticeId);
            objDBManager.AddParameter("Rows", rows);
            objDBManager.AddParameter("PageNumber", pageno);
            if (!string.IsNullOrEmpty(CptCode))
            {
                objDBManager.AddParameter("CPTCode", CptCode);
            }

            return objDBManager.ExecuteDataSet("TOPTENPROCEDURES_SUMMARYReport");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet TOPTENPayers_SUMMARYReport(int rows, int pageno, long PracticeId, string PayerId)
    {
        try
        {
            DBManager objDBManager = new DBManager();

            objDBManager.AddParameter("PracticeId", PracticeId);
            objDBManager.AddParameter("Rows", rows);
            objDBManager.AddParameter("PageNumber", pageno);
            if (!string.IsNullOrEmpty(PayerId))
            {
                objDBManager.AddParameter("PayersId", PayerId);
            }
            return objDBManager.ExecuteDataSet("TOPTENPayers_SUMMARYReport");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

   
    //Rizwan kharal 
    //17 oct, 2017
    //Change the function according to sir instruction passing Dos and Post both parameters for showing the amount on Dashboard
    public DataSet GetPaymentChargesAdjustmentBalanceDue(long PracticeId, string LocationId, string DosStartDate, string DosEndDate,string PostStartDate,string PostEndDate, string BillingProviderId,bool? IsImportedDataOnly) 
    {
        DBManager objDBManager = new DBManager();

        objDBManager.AddParameter("PracticeId", PracticeId);

        if (!string.IsNullOrEmpty(LocationId))
            objDBManager.AddParameter("PracticeLocationsId", LocationId);

        if (!string.IsNullOrEmpty(BillingProviderId))
            objDBManager.AddParameter("BillingPhysicianId", BillingProviderId);

        if (!string.IsNullOrEmpty(DosStartDate))
            objDBManager.AddParameter("DATEOFSERIVCEFROM", DosStartDate);

        if (!string.IsNullOrEmpty(DosEndDate))
            objDBManager.AddParameter("DATEOFSERIVCETO", DosEndDate);


        if (!string.IsNullOrEmpty(PostStartDate))
            objDBManager.AddParameter("@PostDateFrom", PostStartDate);

        if (!string.IsNullOrEmpty(PostEndDate))
            objDBManager.AddParameter("@PostDateTo", PostEndDate);
        if (IsImportedDataOnly != null)
        {
            objDBManager.AddParameter("@IsImported", IsImportedDataOnly);
        }

        return objDBManager.ExecuteDataSet("Claim_CHARGES_PAYMENTS_DUES_ADJUSTMENTS");
    }

    public DataTable ClaimChargesPaymentAdjustment(long PracticeId, string LocationId, string StartDate, string EndDate, string BillingProviderId,string PostStartDate,string PostEndDate)
    {
        DBManager objDBManager = new DBManager();

        objDBManager.AddParameter("PracticeId", PracticeId);

        if (!string.IsNullOrEmpty(LocationId))
            objDBManager.AddParameter("PracticeLocationsId", LocationId);

        if (!string.IsNullOrEmpty(BillingProviderId))
            objDBManager.AddParameter("BillingPhysicianId", BillingProviderId);

        if (!string.IsNullOrEmpty(StartDate))
            objDBManager.AddParameter("DATEOFSERIVCEFROM", StartDate);

        if (!string.IsNullOrEmpty(EndDate))
            objDBManager.AddParameter("DATEOFSERIVCETO", EndDate);

        if (!string.IsNullOrEmpty(PostStartDate))
            objDBManager.AddParameter("PostDateFrom", PostStartDate);

        if (!string.IsNullOrEmpty(PostEndDate))
            objDBManager.AddParameter("PostDateTo", PostEndDate);

        return objDBManager.ExecuteDataTable("Claim_BAAR_CHART");
    }

    // Payment and Adjustment Charges ratio graph  @PostDateFrom @PostDateTo
    public DataTable PaymentChargesAdjustmentRatio(long PracticeId, string LocationId, string DosStartDate, string DosEndDate,  string PostStartDate,string PostEndDate ,string BillingProviderId)
    {
        DBManager objDBManager = new DBManager();

        objDBManager.AddParameter("PracticeId", PracticeId);

        if (!string.IsNullOrEmpty(LocationId))
            objDBManager.AddParameter("PracticeLocationsId", LocationId);

        if (!string.IsNullOrEmpty(BillingProviderId))
            objDBManager.AddParameter("BillingPhysicianId", BillingProviderId);

        if (!string.IsNullOrEmpty(DosStartDate))
            objDBManager.AddParameter("@DATEOFSERIVCEFROM", DosStartDate);

        if (!string.IsNullOrEmpty(DosEndDate))
            objDBManager.AddParameter("@DATEOFSERIVCETO", DosEndDate);
        if (!string.IsNullOrEmpty(PostStartDate))
            objDBManager.AddParameter("@PostDateFrom", PostStartDate);

        if (!string.IsNullOrEmpty(PostEndDate))
            objDBManager.AddParameter("@PostDateTo", PostEndDate);


      

        return objDBManager.ExecuteDataTable("PAYMENT_CHARGES_ADJUSTMENT_RATIO");
    }

    public DataSet GetPaymentChargesAdjustmentRation(long PracticeId, string LocationId, string StartDate, string EndDate, string BillingProviderId)
    {
        DBManager objDBManager = new DBManager();

        objDBManager.AddParameter("PracticeId", PracticeId);

        if (!string.IsNullOrEmpty(LocationId))
            objDBManager.AddParameter("PracticeLocationsId", LocationId);

        if (!string.IsNullOrEmpty(BillingProviderId))
            objDBManager.AddParameter("BillingPhysicianId", BillingProviderId);

        if (!string.IsNullOrEmpty(StartDate))
            objDBManager.AddParameter("DATEOFSERIVCEFROM", StartDate);

        if (!string.IsNullOrEmpty(EndDate))
            objDBManager.AddParameter("DATEOFSERIVCETO", EndDate);

        return objDBManager.ExecuteDataSet("PAYMENT_CHARGES_ADJUSTMENT_RATIO");
    }

   
    


    //Rizwan
    //Rizwan kharal start
    // 12 oct 2017
    // Showing the PaymentChargesRatio and ChargesAdjustmentRatio graph according to Post(created Date) on dashboard
    public DataTable PaymentChargesAdjustmentRatioOnCreatedDate(long PracticeId, string LocationId, string StartDate, string EndDate, string BillingProviderId)
    {
        DBManager objDBManager = new DBManager();

        objDBManager.AddParameter("@PracticeId", PracticeId);

        if (!string.IsNullOrEmpty(LocationId))
            objDBManager.AddParameter("PracticeLocationsId", LocationId);

        if (!string.IsNullOrEmpty(BillingProviderId))
            objDBManager.AddParameter("BillingPhysicianId", BillingProviderId);

        if (!string.IsNullOrEmpty(StartDate))
            objDBManager.AddParameter("@CreatedDateFrom", StartDate);

        if (!string.IsNullOrEmpty(EndDate))
            objDBManager.AddParameter("@CreatedDateTo", EndDate);

        return objDBManager.ExecuteDataTable("PAYMENT_CHARGES_ADJUSTMENT_RATIO_on_CreatedDate");
    }

    //Rizwan kharal 
    //20 Nov, 2017
    //Creating a function to show payments on dashboard.data getting from EraMasterTable column paymentposted on posted date(created date)

    public DataTable PaymentsCalculation(long PracticeId, string PostStartDate, string PostEndDate)
    {
        DBManager objDBManager = new DBManager();

        objDBManager.AddParameter("PracticeId", PracticeId);
        if (!string.IsNullOrEmpty(PostStartDate))
            objDBManager.AddParameter("@PostDateFrom", PostStartDate);

        if (!string.IsNullOrEmpty(PostEndDate))
            objDBManager.AddParameter("@PostDateTo", PostEndDate);

        return objDBManager.ExecuteDataTable("PaymentsCalculation");
    }












    //Rizwan kharal 
    //28 Dec 2017
    //Showing the details of CLAIM SUBMISSION STATUS PIE CHART on Dashboard when click on the chart slice
    public DataSet CLAIMSUBMISSIONSTATUSPIECHARTDetail(long PracticeId, int Rows, int PageNumber, string SortBy, string PracticeLocationsId, string StartDate, string EndDate, string BillingPhysicianId, string SubmissionStatus, string Patientid, string PatientName, string ClaimId, string DOS, string Location, string PhysicianName, string PostDateFrom, string PostDateTO, string PostDate)
  
{
        DBManager objDBManager = new DBManager();

        objDBManager.AddParameter("PracticeId", PracticeId);
        objDBManager.AddParameter("Rows", Rows);
        objDBManager.AddParameter("PageNumber", PageNumber);
        

        if (!string.IsNullOrEmpty(SortBy))
            objDBManager.AddParameter("SortBy", SortBy);

        if (!string.IsNullOrEmpty(PracticeLocationsId))
      objDBManager.AddParameter("PracticeLocationsId", PracticeLocationsId);

      if (!string.IsNullOrEmpty(StartDate))
          objDBManager.AddParameter("DATEOFSERIVCEFROM", StartDate);

      if (!string.IsNullOrEmpty(EndDate))
          objDBManager.AddParameter("DATEOFSERIVCETO", EndDate);


      if (!string.IsNullOrEmpty(BillingPhysicianId))
      objDBManager.AddParameter("@BillingPhysicianId", BillingPhysicianId);

      if (!string.IsNullOrEmpty(SubmissionStatus))
          objDBManager.AddParameter("@SubmissionStatus", SubmissionStatus);

      if (!string.IsNullOrEmpty(Patientid))
          objDBManager.AddParameter("@PatientId", Patientid);

      if (!string.IsNullOrEmpty(PatientName))
          objDBManager.AddParameter("@PatientName", PatientName);

      if (!string.IsNullOrEmpty(ClaimId))
      objDBManager.AddParameter("@ClaimId", ClaimId);

      if (!string.IsNullOrEmpty(DOS))
          objDBManager.AddParameter("@DOS", DOS);

      if (!string.IsNullOrEmpty(Location))
          objDBManager.AddParameter("@Location", Location);

      if (!string.IsNullOrEmpty(PhysicianName))
          objDBManager.AddParameter("@PhysicianName", PhysicianName);


      if (!string.IsNullOrEmpty(PostDateFrom))
          objDBManager.AddParameter("PostDateFROM", PostDateFrom);

      if (!string.IsNullOrEmpty(PostDateTO))
          objDBManager.AddParameter("PostDateTO", PostDateTO);
     
     if (!string.IsNullOrEmpty(PostDate))
         objDBManager.AddParameter("PostDate", PostDate);


         return objDBManager.ExecuteDataSet("CLAIM_SUBMISSION_STATUS_PIE_CHARTDetail");
    }

    //Rizwan kharal 
    //1 jan 2018
    //Showing the details of Payer CLAIM Distribution PIE CHART on Dashboard when click on the chart                                                                                  
 public DataSet PayerCLAIMDistributionPIECHARTDetail(long PracticeId, int Rows, int PageNumber, string SortBy, string PracticeLocationsId, string StartDate, string EndDate, string BillingPhysicianId, string PayerName, string Patientid, string PatientName, string ClaimId, string DOS, string Location, string PhysicianName, string PostDateFrom, string PostDateTO, string PostDate)
    {
        DBManager objDBManager = new DBManager();

        objDBManager.AddParameter("PracticeId", PracticeId);
        objDBManager.AddParameter("Rows", Rows);
        objDBManager.AddParameter("PageNumber", PageNumber);


        if (!string.IsNullOrEmpty(SortBy))
            objDBManager.AddParameter("SortBy", SortBy);

        if (!string.IsNullOrEmpty(PracticeLocationsId))
            objDBManager.AddParameter("PracticeLocationsId", PracticeLocationsId);

        if (!string.IsNullOrEmpty(StartDate))
            objDBManager.AddParameter("DATEOFSERIVCEFROM", StartDate);

        if (!string.IsNullOrEmpty(EndDate))
            objDBManager.AddParameter("DATEOFSERIVCETO", EndDate);


        if (!string.IsNullOrEmpty(BillingPhysicianId))
            objDBManager.AddParameter("@BillingPhysicianId", BillingPhysicianId);

        if (!string.IsNullOrEmpty(PayerName))
            objDBManager.AddParameter("PayerName", PayerName);

        if (!string.IsNullOrEmpty(Patientid))
            objDBManager.AddParameter("@PatientId", Patientid);

        if (!string.IsNullOrEmpty(PatientName))
            objDBManager.AddParameter("@PatientName", PatientName);

        if (!string.IsNullOrEmpty(ClaimId))
            objDBManager.AddParameter("@ClaimId", ClaimId);

        if (!string.IsNullOrEmpty(DOS))
            objDBManager.AddParameter("@DOS", DOS);

        if (!string.IsNullOrEmpty(Location))
            objDBManager.AddParameter("@Location", Location);

        if (!string.IsNullOrEmpty(PhysicianName))
            objDBManager.AddParameter("@PhysicianName", PhysicianName);


        if (!string.IsNullOrEmpty(PostDateFrom))
            objDBManager.AddParameter("PostDateFROM", PostDateFrom);

        if (!string.IsNullOrEmpty(PostDateTO))
            objDBManager.AddParameter("PostDateTO", PostDateTO);

        if (!string.IsNullOrEmpty(PostDate))
            objDBManager.AddParameter("PostDate", PostDate);


        return objDBManager.ExecuteDataSet("PAYER_CLAIM_DISTRIBUTION_PIE_CHARTDetail");
    }



 //Rizwan kharal 
 //28 Dec 2017
 //Showing the details of CLAIM SUBMISSION STATUS Aging Chart Detail on Dashboard when click on the chart slice

 //
 public DataSet CLAIMSUBMISSIONSTATUSAgingChartDetail(long PracticeId, int Rows, int PageNumber, string SortBy, string PracticeLocationsId, string StartDate, string EndDate, string BillingPhysicianId, string SubmissionStatus, string Patientid, string PatientName, string ClaimId, string DOS, string Location, string PhysicianName, string Aging, string PostDateFrom, string PostDateTO, string PostDate)
 {
     DBManager objDBManager = new DBManager();

     objDBManager.AddParameter("PracticeId", PracticeId);
     objDBManager.AddParameter("Rows", Rows);
     objDBManager.AddParameter("PageNumber", PageNumber);


     if (!string.IsNullOrEmpty(SortBy))
         objDBManager.AddParameter("SortBy", SortBy);

     if (!string.IsNullOrEmpty(PracticeLocationsId))
         objDBManager.AddParameter("PracticeLocationsId", PracticeLocationsId);

     if (!string.IsNullOrEmpty(StartDate))
         objDBManager.AddParameter("DATEOFSERIVCEFROM", StartDate);

     if (!string.IsNullOrEmpty(EndDate))
         objDBManager.AddParameter("DATEOFSERIVCETO", EndDate);


     if (!string.IsNullOrEmpty(BillingPhysicianId))
         objDBManager.AddParameter("@BillingPhysicianId", BillingPhysicianId);

     if (!string.IsNullOrEmpty(SubmissionStatus))
         objDBManager.AddParameter("@SubmissionStatus", SubmissionStatus);

     if (!string.IsNullOrEmpty(Patientid))
         objDBManager.AddParameter("@PatientId", Patientid);

     if (!string.IsNullOrEmpty(PatientName))
         objDBManager.AddParameter("@PatientName", PatientName);

     if (!string.IsNullOrEmpty(ClaimId))
         objDBManager.AddParameter("@ClaimId", ClaimId);

     if (!string.IsNullOrEmpty(DOS))
         objDBManager.AddParameter("@DOS", DOS);

     if (!string.IsNullOrEmpty(Location))
         objDBManager.AddParameter("@Location", Location);

     if (!string.IsNullOrEmpty(PhysicianName))
         objDBManager.AddParameter("@PhysicianName", PhysicianName);

     if (!string.IsNullOrEmpty(Aging))
         objDBManager.AddParameter("@Aging", Aging);

     if (!string.IsNullOrEmpty(PostDateFrom))
         objDBManager.AddParameter("PostDateFROM", PostDateFrom);

     if (!string.IsNullOrEmpty(PostDateTO))
         objDBManager.AddParameter("PostDateTO", PostDateTO);

     if (!string.IsNullOrEmpty(PostDate))
         objDBManager.AddParameter("PostDate", PostDate);


     return objDBManager.ExecuteDataSet("Claim_SUBMISSION_STATUS_AgingReportDetail");
 }

}





