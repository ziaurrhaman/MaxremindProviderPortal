using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for PatientDB
/// </summary>
public class PatientDB
{
    public long Add(Patient objPatient)
    {
        DBManager objDBManager = new DBManager();
        try
        {
            objDBManager.AddParameter("PatientId", objPatient.PatientId, SqlDbType.Int, 4, ParameterDirection.Output);
            
            objDBManager.AddParameter("PracticeId", objPatient.PracticeId);
            objDBManager.AddParameter("PracticeLocationsId", objPatient.PracticeLocationsId);

            objDBManager.AddParameter("LastName", objPatient.LastName);
            objDBManager.AddParameter("FirstName", objPatient.FirstName);
            objDBManager.AddParameter("MiddleName", objPatient.MiddleName);
            objDBManager.AddParameter("DateOfBirth", objPatient.DateOfBirth);
            objDBManager.AddParameter("TimeOfBirth", objPatient.TimeOfBirth);
            objDBManager.AddParameter("SSN", objPatient.SSN);
            objDBManager.AddParameter("Gender", objPatient.Gender);
            objDBManager.AddParameter("MaritalStatus", objPatient.MaritalStatus);
            objDBManager.AddParameter("RaceId", objPatient.RaceId);
            objDBManager.AddParameter("EthnicityId", objPatient.EthnicityId);
            objDBManager.AddParameter("PreferredLanguageId", objPatient.PreferredLanguageId);
            objDBManager.AddParameter("Address", objPatient.Address);
            objDBManager.AddParameter("AddressType", objPatient.AddressType);
            objDBManager.AddParameter("Zip", objPatient.Zip);
            objDBManager.AddParameter("City", objPatient.City);
            objDBManager.AddParameter("State", objPatient.State);
            objDBManager.AddParameter("HomePhone", objPatient.HomePhone);
            objDBManager.AddParameter("Cell", objPatient.Cell);
            objDBManager.AddParameter("WorkPhone", objPatient.WorkPhone);
            objDBManager.AddParameter("Ext", objPatient.Ext);
            objDBManager.AddParameter("Email", objPatient.Email);
            objDBManager.AddParameter("CCP", objPatient.CCP);
            objDBManager.AddParameter("EmergencyContactName", objPatient.EmergencyContactName);
            objDBManager.AddParameter("Relationship", objPatient.Relationship);
            objDBManager.AddParameter("Phone", objPatient.Phone);
            objDBManager.AddParameter("FinancialGuarantorId", objPatient.FinancialGuarantorId);
            objDBManager.AddParameter("GuarantorRelationship", objPatient.GuarantorRelationship);
            objDBManager.AddParameter("DisabilityDate", objPatient.DisabilityDate);
            objDBManager.AddParameter("DeathDate", objPatient.DeathDate);
            objDBManager.AddParameter("CauseOfDeath", objPatient.CauseOfDeath);
            objDBManager.AddParameter("NCPDP", objPatient.NCPDP);
            objDBManager.AddParameter("PhysicianId", objPatient.PhysicianID);
            objDBManager.AddParameter("AdmissionSource", objPatient.AdmissionSource);
            objDBManager.AddParameter("AdmissionType", objPatient.AdmissionType);
            objDBManager.AddParameter("InternalReferral", objPatient.InternalReferral);
            objDBManager.AddParameter("ExternalReferral", objPatient.ExternalReferral);
            objDBManager.AddParameter("ReferralDate", objPatient.ReferralDate);
            objDBManager.AddParameter("Notes", objPatient.Notes);
            objDBManager.AddParameter("CommunicationBarrier", objPatient.CommunicationBarriers);
            
            objDBManager.AddParameter("UserName", objPatient.UserName);
            objDBManager.AddParameter("Password", objPatient.Password);
            objDBManager.AddParameter("ActiveWebAccount", objPatient.ActiveWebAccount);
            
            objDBManager.AddParameter("CreatedById", objPatient.CreatedById);
            objDBManager.AddParameter("CreatedDate", objPatient.CreatedDate);
            objDBManager.AddParameter("IsActive", 1);
            objDBManager.ExecuteNonQuery("Patient_Add");
            
            objPatient.PatientId = long.Parse(objDBManager.Parameters[0].Value.ToString());
        }
        catch (Exception ex)
        {
            throw ex;
        }
        
        return objPatient.PatientId;
    }

    

    public void Update(Patient objPatient)
    {
        DBManager objDBManager = new DBManager();
        try
        {
            objDBManager.AddParameter("@PatientId", objPatient.PatientId);
            objDBManager.AddParameter("@LastName", objPatient.LastName);
            objDBManager.AddParameter("@FirstName", objPatient.FirstName);
            objDBManager.AddParameter("@MiddleName", objPatient.MiddleName);
            objDBManager.AddParameter("@DateOfBirth", objPatient.DateOfBirth);
            objDBManager.AddParameter("@TimeOfBirth", objPatient.TimeOfBirth);
            objDBManager.AddParameter("@SSN", objPatient.SSN);
            objDBManager.AddParameter("@Gender", objPatient.Gender);
            objDBManager.AddParameter("@MaritalStatus", objPatient.MaritalStatus);
            objDBManager.AddParameter("@RaceId", objPatient.RaceId);
            objDBManager.AddParameter("@EthnicityId", objPatient.EthnicityId);
            objDBManager.AddParameter("@PreferredLanguageId", objPatient.PreferredLanguageId);
            objDBManager.AddParameter("@Address", objPatient.Address);
            objDBManager.AddParameter("@AddressType", objPatient.AddressType);
            objDBManager.AddParameter("@Zip", objPatient.Zip);
            objDBManager.AddParameter("@City", objPatient.City);
            objDBManager.AddParameter("@State", objPatient.State);
            objDBManager.AddParameter("@HomePhone", objPatient.HomePhone);
            objDBManager.AddParameter("@Cell", objPatient.Cell);
            objDBManager.AddParameter("@WorkPhone", objPatient.WorkPhone);
            objDBManager.AddParameter("@Ext", objPatient.Ext);
            objDBManager.AddParameter("@Email", objPatient.Email);
            objDBManager.AddParameter("@CCP", objPatient.CCP);
            objDBManager.AddParameter("@EmergencyContactName", objPatient.EmergencyContactName);
            objDBManager.AddParameter("@Relationship", objPatient.Relationship);
            objDBManager.AddParameter("@Phone", objPatient.Phone);
            objDBManager.AddParameter("@FinancialGuarantorId", objPatient.FinancialGuarantorId);
            objDBManager.AddParameter("@GuarantorRelationship", objPatient.GuarantorRelationship);
            objDBManager.AddParameter("@DisabilityDate", objPatient.DisabilityDate);
            objDBManager.AddParameter("@DeathDate", objPatient.DeathDate);
            objDBManager.AddParameter("NCPDP", objPatient.NCPDP);
            objDBManager.AddParameter("PhysicianId", objPatient.PhysicianID);
            objDBManager.AddParameter("AdmissionSource", objPatient.AdmissionSource);
            objDBManager.AddParameter("AdmissionType", objPatient.AdmissionType);
            objDBManager.AddParameter("InternalReferral", objPatient.InternalReferral);
            objDBManager.AddParameter("ExternalReferral", objPatient.ExternalReferral);
            objDBManager.AddParameter("ReferralDate", objPatient.ReferralDate);
            objDBManager.AddParameter("Notes", objPatient.Notes);
            objDBManager.AddParameter("CommunicationBarrier", objPatient.CommunicationBarriers);
            objDBManager.AddParameter("CauseOfDeath", objPatient.CauseOfDeath);

            objDBManager.AddParameter("UserName", objPatient.UserName);
            objDBManager.AddParameter("Password", objPatient.Password);
            objDBManager.AddParameter("ActiveWebAccount", objPatient.ActiveWebAccount);

            objDBManager.AddParameter("ModifiedById", objPatient.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objPatient.ModifiedDate);
            

            //Patient_Update

            objDBManager.ExecuteNonQuery("Update_PatientDemographics");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    
    public void UpdatePTLInfo(Patient objPatient)
    {
        DBManager objDBManager = new DBManager();
        
        try
        {
            objDBManager.AddParameter("PatientId", objPatient.PatientId);
            
            objDBManager.AddParameter("IsPTL", objPatient.IsPTL);
            objDBManager.AddParameter("PTLReasons", objPatient.PTLReasons);
            objDBManager.AddParameter("PTLNotes", objPatient.PTLNotes);
            
            objDBManager.AddParameter("ModifiedById", objPatient.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objPatient.ModifiedDate);
            
            objDBManager.ExecuteNonQuery("Patient_UpdatePTLInfo");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    
    public void ResolvePTLStatus(Patient objPatient)
    {
        DBManager objDBManager = new DBManager();
        
        try
        {
            objDBManager.AddParameter("PatientId", objPatient.PatientId);
            
            objDBManager.AddParameter("ModifiedById", objPatient.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objPatient.ModifiedDate);
            
            objDBManager.ExecuteNonQuery("Patient_ResolvePTLStatus");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    
    public void UpdateImagePath(long PatientId, string ImagePath)
    {
        DBManager objDBManager = new DBManager();
        
        objDBManager.AddParameter("PatientId", PatientId);
        objDBManager.AddParameter("ImagePath", ImagePath);
        
        objDBManager.ExecuteNonQuery("Patient_ImagePath");
    }
    
    public void UpdatePatientCondition(long PatientId, string Condition)
    {
        DBManager objDBManager = new DBManager();

        objDBManager.AddParameter("PatientId", PatientId);
        objDBManager.AddParameter("Condition", Condition);

        objDBManager.ExecuteNonQuery("Patient_UpdatePatientCondition");
    } 
    
    public DataTable GetAllPatients(long PracticeId)
    {
        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("@PracticeId", PracticeId);
        return objDBManager.ExecuteDataTable("GetAllPatients");
    }

    public DataTable GetAllPatientswithPaidUpStatus(long PracticeId)
    {
        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("@PracticeId", PracticeId);
        return objDBManager.ExecuteDataTable("GetAllPatientsStatusPaidUp");
    }

    

    //rizwan kharal start
    //21 sep 2017
    // showing patient insurance on demographic page 

    public DataSet InsurancePatient(string patientId)
    {
        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("@PatiendId", patientId);
       
        return objDBManager.ExecuteDataSet("ShowPatientInsuranceData");
    }

   
    //Rizwan End


    //rizwan kharal start
    //21 sep 2017
    // showing patient Claims on demographic page 
    public DataTable ClaimsPatient(string patientId,string practiceId)
    {
        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("@PatientId", patientId);
        objDBManager.AddParameter("@practiceId", practiceId);
        return objDBManager.ExecuteDataTable("ShowPatientClaimsData");
    }
    //Rizwan End

    //rizwan kharal start
    //21 sep 2017
    // showing Submission status codes  on demographic page 
    public DataTable SubmissionStatusCodes()
    {
        DBManager objDBManager = new DBManager();
        return objDBManager.ExecuteDataTable("ShowSubmissionStatusCodes");
    }
    //Rizwan End

    //rizwan kharal start
    //21 sep 2017
    // showing PTL Reasons on demographic page 
    public DataTable PTLReasons(long practiseId)
    {
        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("@practiseId", practiseId);
        return objDBManager.ExecuteDataTable("ShowPTLReasons");
    }
    //Rizwan End

    //rizwan kharal start
    //22 sep 2017
    // Getting the practise id of patient from patient table
    public DataTable PatientGetByPractiseId(object patientId)
    {
        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("@PatiendId", patientId);
        return objDBManager.ExecuteDataTable("PatientGetByPractiseId");
    }
    //Rizwan End

    //rizwan kharal start
    //22 sep 2017
    // Getting the practise id of patient from Claim table


   
    public DataTable CalimGetByPractiseId(object patientId)
    {
        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("@PatientId", patientId);
        return objDBManager.ExecuteDataTable("ClaimGetByPracticeId");
    }

    //Rizwan End




    //rizwan kharal start
    //26 sep 2017
    // UpdatePatientDemographicsInformation

    public void UpdatePatientDemographicsInformation(Patient objPatient)
    { 
            
        
        try{


       DBManager objDBManager=new DBManager();
        objDBManager.AddParameter("@PatientId", objPatient.PatientId);
        objDBManager.AddParameter("@GuarantorRelationshipId", objPatient.FinancialGuarantorId);
            objDBManager.AddParameter("@LastName", objPatient.LastName);
            objDBManager.AddParameter("@FirstName", objPatient.FirstName);
            objDBManager.AddParameter("@MiddleName", objPatient.MiddleName);
            objDBManager.AddParameter("@DateOfBirth", objPatient.uDateOfBirth);
            objDBManager.AddParameter("@TimeOfBirth", objPatient.TimeOfBirth);
            objDBManager.AddParameter("@SSN", objPatient.SSN);
            objDBManager.AddParameter("@Gender", objPatient.Gender);
            objDBManager.AddParameter("@MaritalStatus", objPatient.MaritalStatus);
            objDBManager.AddParameter("@RaceId", objPatient.RaceId);
            objDBManager.AddParameter("@EthnicityId", objPatient.EthnicityId);
            objDBManager.AddParameter("@PreferredLanguageId", objPatient.PreferredLanguageId);
            objDBManager.AddParameter("@Address", objPatient.Address);
            objDBManager.AddParameter("@AddressType", objPatient.AddressType);
            objDBManager.AddParameter("@Zip", objPatient.Zip);
            objDBManager.AddParameter("@City", objPatient.City);
            objDBManager.AddParameter("@State", objPatient.State);
            objDBManager.AddParameter("@HomePhone", objPatient.HomePhone);
            objDBManager.AddParameter("@Cell", objPatient.Cell);
            objDBManager.AddParameter("@WorkPhone", objPatient.WorkPhone);
            objDBManager.AddParameter("@Ext", objPatient.Ext);
            objDBManager.AddParameter("@Email", objPatient.Email);
            objDBManager.AddParameter("@CCP", objPatient.CCP);
            objDBManager.AddParameter("@EmergencyContactName", objPatient.EmergencyContactName);
            objDBManager.AddParameter("@Relationship", objPatient.Relationship);
            objDBManager.AddParameter("@Phone", objPatient.Phone);
      
            objDBManager.AddParameter("@GuarantorRelationship", objPatient.GuarantorRelationship);
        
            objDBManager.AddParameter("@DisabilityDate", objPatient.uDisabilityDate);
            objDBManager.AddParameter("@DeathDate", objPatient.uDeathDate);
           
            objDBManager.AddParameter("Notes", objPatient.Notes);
         
            objDBManager.AddParameter("CauseOfDeath", objPatient.CauseOfDeath);
            objDBManager.AddParameter("NCPDP", objPatient.NCPDP);
            objDBManager.ExecuteNonQuery("Update_PatientDemographics");
        }
        catch (Exception ex)
        {
            throw ex;
        }






    }



    //Rizwan End


    //rizwan kharal start
    //3 oct 2017
    // Created to check insurance type already exists are not
    public DataTable CheckPatientInsuranceType(int patientId, string InsType)
    {
        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("@PatiendId", patientId);
        objDBManager.AddParameter("@PriSecOthType", InsType);
        return objDBManager.ExecuteDataTable("CheckPatientInsurancePriSecOthType");
    }
    //Rizwan End

    //rizwan kharal start
    //6 oct 2017
    //  Showing the PtlReason list on Home page in Pendng transition  of patient
    public DataSet ShowPTlOfpatient(long practiseid) 
    {
        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("@practiceId", practiseid);
        return objDBManager.ExecuteDataSet("ShowPTlOfpatient");
    }
    //Rizwan End

    //rizwan kharal start
    //10 oct 2017
    // Getting the ProSecothType to make a check if the patient have already inshurance type that type will not show next time
    public DataTable PriSecothinsuranceTypeCheck(int PatientId)
    {
        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("@Patientid", PatientId);
        return objDBManager.ExecuteDataTable("ShowpatientPriSecOthType");
    }
    //Rizwan End

    //rizwan kharal start
    //11 oct 2017
    // Description:Showing and Filtering the patient claims on Demographics claim grid
    public DataSet FilterClaims(int PracticeId, int PatientId, int Rows, int PageNumber, string PTLReasons, string SubmissionStatus, string DOS, long ClaimId, string AmountPaid, string ClaimTotal, string Adjustment, string AmountDue, string InsuranceNames)
    {
        DBManager objDBManager = new DBManager();
    
        objDBManager.AddParameter("@PracticeId", PracticeId);
        objDBManager.AddParameter("@Rows", Rows);
        objDBManager.AddParameter("@PageNumber", PageNumber);
        //objDBManager.AddParameter("@SortBy", SortBy); string SortBy,
        objDBManager.AddParameter("@PatientId", PatientId);


        if (!string.IsNullOrEmpty(DOS))
        {
            objDBManager.AddParameter("@DOS", DOS);
        }
        if (ClaimId != 0)
        {
            objDBManager.AddParameter("@ClaimId", ClaimId);
        }

        if (!string.IsNullOrEmpty(ClaimTotal))
        {
            objDBManager.AddParameter("@ClaimTotal", ClaimTotal);
        }
            

        //if (ClaimTotal != 0)
        //{
        //    objDBManager.AddParameter("@ClaimTotal", ClaimTotal);
        //}

        if (!string.IsNullOrEmpty(AmountPaid))
        {
            objDBManager.AddParameter("@AmountPaid", AmountPaid);
        }

        if (!string.IsNullOrEmpty(Adjustment))
        {
            objDBManager.AddParameter("@Adjustment", Adjustment);
        }

        if (!string.IsNullOrEmpty(AmountDue))
        {
            objDBManager.AddParameter("@AmountDue", AmountDue);
        }


        if (!string.IsNullOrEmpty(SubmissionStatus))
        {
            objDBManager.AddParameter("@SubmissionStatus", (SubmissionStatus));
        }

        if (!string.IsNullOrEmpty(PTLReasons))
        {
            objDBManager.AddParameter("@PTLReasons", PTLReasons);
        }
        if (!string.IsNullOrEmpty(InsuranceNames))
        {
            objDBManager.AddParameter("@Name", InsuranceNames);
        }
        return objDBManager.ExecuteDataSet("ShowPatientClaimsFilterData");
    }
//End
    //rizwan kharal start
    //27 oct 2017
    // UpdateFinancialGurantorNameDemographicsInformation

    public void UpdateFinancialGurantorNames(Patient objPatient, long practiceId)
    {
        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("@practiceId", practiceId);
        objDBManager.AddParameter("@FgfirstName", objPatient.FinancialGuarantorFirstName);
        objDBManager.AddParameter("@FgLastName", objPatient.FinancialGuarantorLastName);
        objDBManager.AddParameter("@FgMiddleName", objPatient.FinancialGuarantorMiddleName);
        objDBManager.AddParameter("@FinancialGuarantorId",objPatient.FinancialGuarantorId);
        objDBManager.ExecuteNonQuery("UpdateFinancialGuarantorName");
   }

    //

    public DataSet PatientsDemographics(long PatientId,long PracticeId, int Rows, int PageNumber, string DateFrom = "", string DateTo = "", string DateType = "", string InsuranceID = "", string Gender="")
    {
        DBManager objDBManager = new DBManager();

        objDBManager.AddParameter("@PracticeId", PracticeId);
        objDBManager.AddParameter("@Rows", Rows);
        objDBManager.AddParameter("@PageNumber", PageNumber);
        objDBManager.AddParameter("@SortBy", "Account Number desc");

        if (PatientId != 0)
        {
            objDBManager.AddParameter("@PatientId", PatientId);
        }
        if (!string.IsNullOrEmpty(InsuranceID))
        {
            objDBManager.AddParameter("@InsuranceId", InsuranceID);
        }
        if (!string.IsNullOrEmpty(Gender))
        {
            objDBManager.AddParameter("@Gender", Gender);
        }

        objDBManager.AddParameter("@DateFrom", DateFrom);
        objDBManager.AddParameter("@DateTo", DateTo);
        objDBManager.AddParameter("@DateType", DateType);

        ///End  Modified By Irfan Mahmood 25-Oct-2021///
        return objDBManager.ExecuteDataSet("Patient_GetPatientBySearchCriteria");
    }
    public DataSet FilterPatients(long PatientId, string FirstName, string LastName, string DOB, 
        string Phone, string Gender, string Address, string PatientCondition, long PracticeId, 
        int Rows, int PageNumber, string SortBy, bool IsPTL = false, string PTLReasons = "",string PriInsurance="",string dateFrom=null,string dateTo=null,bool isRPM=false)
    {
        DBManager objDBManager = new DBManager();

        objDBManager.AddParameter("@PracticeId", PracticeId);
        objDBManager.AddParameter("@Rows", Rows);
        objDBManager.AddParameter("@PageNumber", PageNumber);
        objDBManager.AddParameter("@isRPM", isRPM);
        objDBManager.AddParameter("@SortBy", SortBy);
        if (PatientId != 0)
        {
            objDBManager.AddParameter("@PatientId", PatientId);
        }

        if (!string.IsNullOrEmpty(FirstName))
        {
            objDBManager.AddParameter("@FirstName", FirstName);
        }

        if (!string.IsNullOrEmpty(LastName))
        {
            objDBManager.AddParameter("@LastName", LastName);
        }

        if (!string.IsNullOrEmpty(DOB))
        {
            objDBManager.AddParameter("@DateOfBirth", Convert.ToDateTime(DOB));
        }

        if (!string.IsNullOrEmpty(Gender))
        {
            objDBManager.AddParameter("@Gender", Gender);
        }

        if (!string.IsNullOrEmpty(Phone))
        {
            objDBManager.AddParameter("@Phone", Phone);
        }

        if (!string.IsNullOrEmpty(Address))
        {
            objDBManager.AddParameter("@Address", Address);
        }

        if (!string.IsNullOrEmpty(PatientCondition))
        {
            objDBManager.AddParameter("@PatientCondition", PatientCondition);
        }

        if (IsPTL)
        {
            objDBManager.AddParameter("IsPTL", IsPTL);
        }

        if (!string.IsNullOrEmpty(PTLReasons))
        {
            objDBManager.AddParameter("PTLReasons", PTLReasons);
        }
        if (!string.IsNullOrEmpty(PriInsurance))
        {
            objDBManager.AddParameter("PriInsurance", PriInsurance);
        }
        if (!string.IsNullOrEmpty(dateFrom))
        {
            objDBManager.AddParameter("DateFrom", Convert.ToDateTime(dateFrom));
        }
        if (!string.IsNullOrEmpty(dateTo))
        {
            objDBManager.AddParameter("DateTo", Convert.ToDateTime(dateTo));
        }


        return objDBManager.ExecuteDataSet("Patient_GetPatientBySearchCriteria");
    }
    public DataSet FilterPatientss(long PatientId, string FirstName, string LastName, string DOB, string Phone, string Gender, string Address, string PriInsurance, string PatientCondition, long PracticeId, int Rows, int PageNumber, string SortBy, bool IsPTL = false, string PTLReasons = "", bool IsRPM = false,
        string SSN = "", string PolicyNumber = "", DateTime? DateFrom = null, DateTime? DateTo = null, string InsuranceID = "", string City = "", string Zip = "", string State = "")
    {
        DBManager objDBManager = new DBManager();

        objDBManager.AddParameter("@PracticeId", PracticeId);
        objDBManager.AddParameter("@Rows", Rows);
        objDBManager.AddParameter("@PageNumber", PageNumber);
        objDBManager.AddParameter("@SortBy", SortBy);

        if (PatientId != 0)
        {
            objDBManager.AddParameter("@PatientId", PatientId);
        }
        if (!string.IsNullOrEmpty(PriInsurance))
        {
            objDBManager.AddParameter("@PriInsurance", PriInsurance);
        }
        if (!string.IsNullOrEmpty(FirstName))
        {
            objDBManager.AddParameter("@FirstName", FirstName);
        }

        if (!string.IsNullOrEmpty(LastName))
        {
            objDBManager.AddParameter("@LastName", LastName);
        }

        if (!string.IsNullOrEmpty(DOB))
        {
            objDBManager.AddParameter("@DateOfBirth", Convert.ToDateTime(DOB));
        }

        if (!string.IsNullOrEmpty(Gender))
        {
            objDBManager.AddParameter("@Gender", Gender);
        }

        if (!string.IsNullOrEmpty(Phone))
        {
            objDBManager.AddParameter("@Phone", Phone);
        }

        if (!string.IsNullOrEmpty(Address))
        {
            objDBManager.AddParameter("@Address", Address);
        }

        if (!string.IsNullOrEmpty(PatientCondition))
        {
            objDBManager.AddParameter("@PatientCondition", PatientCondition);
        }

        if (IsPTL)
        {
            objDBManager.AddParameter("IsPTL", IsPTL);
        }
        if (IsRPM)
        {
            objDBManager.AddParameter("IsRPM", IsRPM);
        }
        if (!string.IsNullOrEmpty(PTLReasons))
        {
            objDBManager.AddParameter("PTLReasons", PTLReasons);
        }
        ///Start  Modified By Irfan Mahmood 15-Oct-2021///
        if (!string.IsNullOrEmpty(SSN))
        {
            objDBManager.AddParameter("@SSN", SSN);
        }
        if (!string.IsNullOrEmpty(PolicyNumber))
        {
            objDBManager.AddParameter("@PolicyNo", PolicyNumber);
        }
        if (!string.IsNullOrEmpty(InsuranceID))
        {
            objDBManager.AddParameter("@InsuranceId", InsuranceID);
        }
        ///Start  Modified By Irfan Mahmood 25-Oct-2021///
        if (!string.IsNullOrEmpty(City))
        {
            objDBManager.AddParameter("@City", City);
        }
        if (!string.IsNullOrEmpty(Zip))
        {
            objDBManager.AddParameter("@ZIP", Zip);
        }
        if (!string.IsNullOrEmpty(State))
        {
            objDBManager.AddParameter("@State", State);
        }

        objDBManager.AddParameter("@DateFrom", DateFrom);
        objDBManager.AddParameter("@DateTo", DateTo);

        ///End  Modified By Irfan Mahmood 25-Oct-2021///
        return objDBManager.ExecuteDataSet("Patient_GetPatientBySearchCriteria");
    }

    /**********added by shahid kazmi 1/29/2018***********/
    public DataSet GetAllPatientsForEligibility(long PracticeId,int Rows,int PageNumber,string SortBy,long PatientId , string FirstName, string LastName, string Gender, string DOB,string Payer)
    {
        DBManager objDBManager = new DBManager();

        objDBManager.AddParameter("@PracticeId", PracticeId);
        
        objDBManager.AddParameter("@Rows", Rows);
        objDBManager.AddParameter("@PageNumber", PageNumber);
        objDBManager.AddParameter("@SortBy", SortBy);
        
        if (PatientId != 0)
        {
            objDBManager.AddParameter("@PatientId", PatientId);
        }

        if (!string.IsNullOrEmpty(FirstName))
        {
            objDBManager.AddParameter("@FirstName", FirstName);
        }

        if (!string.IsNullOrEmpty(LastName))
        {
            objDBManager.AddParameter("@LastName", LastName);
        }

        if (!string.IsNullOrEmpty(DOB))
        {
            objDBManager.AddParameter("@DateOfBirth", Convert.ToDateTime(DOB));
        }

        if (!string.IsNullOrEmpty(Gender))
        {
            objDBManager.AddParameter("@Gender", Gender);
        }

        if (!string.IsNullOrEmpty(Payer))
        {
            objDBManager.AddParameter("@Payer", Payer);
        }


        return objDBManager.ExecuteDataSet("GetAllPatientsForEligibility");
    }


    /***********end shahid kazmi 1/29/2018********/
    public DataSet PendingTransitionFilterPatients(long PatientId, string FirstName, string LastName, string DOB, string Phone, string Gender, string Address, string PTLReasons, long PracticeId, int Rows, int PageNumber, string SortBy, bool IsPTL = false)
    {
        DBManager objDBManager = new DBManager();

        objDBManager.AddParameter("@PracticeId", PracticeId);
        objDBManager.AddParameter("@Rows", Rows);
        objDBManager.AddParameter("@PageNumber", PageNumber);
        objDBManager.AddParameter("@SortBy", SortBy);

        if (PatientId != 0)
        {
                objDBManager.AddParameter("@PatientId", PatientId);
        }
        if (!string.IsNullOrEmpty(FirstName))
        {
            objDBManager.AddParameter("@FirstName", FirstName);
        }

        if (!string.IsNullOrEmpty(LastName))
        {
            objDBManager.AddParameter("@LastName", LastName);
        }

        if (!string.IsNullOrEmpty(DOB))
        {
            objDBManager.AddParameter("@DateOfBirth", Convert.ToDateTime(DOB));
        }

        if (!string.IsNullOrEmpty(Gender))
        {
            objDBManager.AddParameter("@Gender", Gender);
        }

        if (!string.IsNullOrEmpty(Phone))
        {
            objDBManager.AddParameter("@Phone", Phone);
        }

        if (!string.IsNullOrEmpty(Address))
        {
            objDBManager.AddParameter("@Address", Address);
        }

       
        
        if (IsPTL)
        {
            objDBManager.AddParameter("IsPTL", IsPTL);
        }
        else
        {
            objDBManager.AddParameter("IsPTL", true);
        }
        if (!string.IsNullOrEmpty(PTLReasons))
        {
            objDBManager.AddParameter("PTLReasons", PTLReasons);
        }
        
        return objDBManager.ExecuteDataSet("Patient_GetPatientBySearchCriteria");
    }
    


    public DataSet Patient_GetById(long PatientId, long PracticeId = 0)
    {
        DBManager objDBManager = new DBManager();
        
        objDBManager.AddParameter("PatientId", PatientId);
        
        if (PracticeId != 0)
        {
            objDBManager.AddParameter("PracticeId", PracticeId);
        }
        
        return objDBManager.ExecuteDataSet("Patient_GetById");
    }

    public DataSet GetByIdAsDataSet(long PatientId, long PracticeId = 0)
    {
        DBManager objDBManager = new DBManager();

        objDBManager.AddParameter("PatientId", PatientId);

        if (PracticeId != 0)
        {
            objDBManager.AddParameter("PracticeId", PracticeId);
        }

        return objDBManager.ExecuteDataSet("Patient_GetById");
    }
    
 
    public DataTable Patient_GetInfoById(long PatientId)
    {
        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("PatientId", PatientId);
        return objDBManager.ExecuteDataTable("Patient_GetInfoById");
    }

    public DataTable Patient_GetPatientAddressById(string PatientIDs)
    {
        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("PatientId", PatientIDs);
        return objDBManager.ExecuteDataTable("GetPatientAddressById");
    }
    
    public DataTable GetPatientVisitListByServiceProvider(string ServiceProviderId, DateTime VisitDate)
    {
        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("VisitDate", VisitDate);
        if (!string.IsNullOrEmpty(ServiceProviderId))
            objDBManager.AddParameter("ServiceProviderId", ServiceProviderId);
        return objDBManager.ExecuteDataTable("GetPatientVisitListByServiceProvider");
    }
    
    public DataTable GetPatientDetailByPatientId(long PatientId, int EpisodeTaskId)
    {
        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("@PatientId", PatientId);
        objDBManager.AddParameter("@EpisodeTaskId", EpisodeTaskId);
        return objDBManager.ExecuteDataTable("Patient_GetPatientDetailByPatientId");
    }
    
    public DataTable GetPatientInformationByPatientId(long PatientId)
    {
        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("@PatientId", PatientId);
        return objDBManager.ExecuteDataTable("Patient_GetPatientInformationByPatientId");
    }
    
    public DataSet GetPatientRelatedData()
    {
        DBManager objDBManager = new DBManager();

        return objDBManager.ExecuteDataSet("Patient_GetPatientRelatedData");
    }
    
    public DataSet GetPatientOrderMedications(long PatientId, long AppointmentsId)
    {
        var objDBManager = new DBManager();
        objDBManager.AddParameter("PatientId", PatientId);
        objDBManager.AddParameter("AppointmentsId", AppointmentsId);
        return objDBManager.ExecuteDataSet("Report_GetPatientOrderMedications");
    }
    
    public DataSet AllPatientForms(long PatientId)
    {
        var objDBManager = new DBManager();
        objDBManager.AddParameter("PatientId", PatientId);
        return objDBManager.ExecuteDataSet("Patient_AllPatientForms");
    }
    
    public DataTable GetInfoForEligibility(long PatientId)
    {
        DBManager objDBManager = new DBManager();

        objDBManager.AddParameter("PatientId", PatientId);

        return objDBManager.ExecuteDataTable("Patient_GetInfoForEligibility");
    }
    
    public void UpdatePatientEligibilityStatus(long PatientId, string EligibilityStatus, DateTime EligibilityInquiryDate)
    {
        DBManager objDBManager = new DBManager();
        
        objDBManager.AddParameter("PatientId", PatientId);
        
        objDBManager.AddParameter("EligibilityStatus", EligibilityStatus);
        objDBManager.AddParameter("EligibilityInquiryDate", EligibilityInquiryDate);
        
        objDBManager.ExecuteNonQuery("Patient_UpdateEligibilityStatus");
    }
    
    public DataTable GetByUserNameAndPass(string UserName, string Password)
    {
        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("@UserName", UserName);
        objDBManager.AddParameter("@Password", Password);
        return objDBManager.ExecuteDataTable("Patient_GetByUserNameAndPass");
    }
    
    public DataTable CheckExistingUserName(string UserName, long PatientId)
    {
        DBManager objDBManager = new DBManager();
        if (PatientId != 0)
            objDBManager.AddParameter("@PatientId", PatientId);
        objDBManager.AddParameter("@UserName", UserName);

        return objDBManager.ExecuteDataTable("Patient_CheckExistingUserName");
    }
    
    public DataTable GetPatientDetailsBySSN(string SSN)
    {
        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("@SSN", SSN);
        return objDBManager.ExecuteDataTable("Patient_GetPatientDetailsBySSN");
    }
    
    public void PatientRegisterUpdate(Patient objPatient)
    {
        DBManager objDBManager = new DBManager();
        try
        {
            objDBManager.AddParameter("PatientId", objPatient.PatientId);
            objDBManager.AddParameter("FirstName", objPatient.FirstName);
            objDBManager.AddParameter("LastName", objPatient.LastName);
            objDBManager.AddParameter("MiddleName", objPatient.MiddleName);
            objDBManager.AddParameter("SSN", objPatient.SSN);

            objDBManager.AddParameter("UserName", objPatient.UserName);
            objDBManager.AddParameter("Password", objPatient.Password);
            objDBManager.AddParameter("ActiveWebAccount", objPatient.ActiveWebAccount);

            objDBManager.AddParameter("ModifiedById", objPatient.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objPatient.ModifiedDate);

            objDBManager.ExecuteNonQuery("Patient_PatientRegisterUpdate");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    
    public DataTable FilterPatientsByName(long PracticeId, string LastName, string FirstName, string Phone)
    {
        DBManager objDBManager = new DBManager();
        
        objDBManager.AddParameter("PracticeId", PracticeId);
        
        objDBManager.AddParameter("LastName", LastName);
        objDBManager.AddParameter("FirstName", FirstName);
        objDBManager.AddParameter("Phone", Phone);
        
        return objDBManager.ExecuteDataTable("Patient_FilterPatientsByName");
    }
    
    public DataTable GetByName(long PracticeId, string LastName, string FirstName)
    {
        DBManager objDBManager = new DBManager();
        
        objDBManager.AddParameter("PracticeId", PracticeId);
        objDBManager.AddParameter("LastName", LastName);
        objDBManager.AddParameter("FirstName", FirstName);
       
        return objDBManager.ExecuteDataTable("Patient_GetByName");
    }

    public DataSet LoadWalkoutInformation(long PatientId, DateTime DOS)
    {
        DBManager objDBManager = new DBManager();

        objDBManager.AddParameter("PatientId", PatientId);
        objDBManager.AddParameter("DOS", DOS);

        return objDBManager.ExecuteDataSet("Patient_LoadWalkoutInformation");
    }

    public DataSet LoadDashboardInformation(long PatientId)
    {
        DBManager objDBManager = new DBManager();

        objDBManager.AddParameter("PatientId", PatientId);

        return objDBManager.ExecuteDataSet("Patient_LoadDashboardInformation");
    }

    public DataSet PATIENTVISITS(int rows, int pageno, string SortBy, long PracticeId, long? PracticeLocationsId , long? ServiceProviderId, string DateFrom, string DateTo)
    {
        try
        {
            DBManager objDBManager = new DBManager();

            objDBManager.AddParameter("PracticeId", PracticeId);

            if (PracticeLocationsId != 0)
            {
                objDBManager.AddParameter("PracticeLocationsId", PracticeLocationsId);
            }

            if (ServiceProviderId != 0)
            {
                objDBManager.AddParameter("ServiceProviderId", ServiceProviderId);
            }

            objDBManager.AddParameter("Rows", rows);
            objDBManager.AddParameter("PageNumber", pageno);

            if (!string.IsNullOrEmpty(SortBy))
            {
                objDBManager.AddParameter("SortBy", SortBy);
            }
            if (!string.IsNullOrEmpty(DateFrom))
            {
                objDBManager.AddParameter("DateFrom", DateFrom);
            }
            if (!string.IsNullOrEmpty(DateTo))
            {
                objDBManager.AddParameter("DateTo", DateTo);
            }

            return objDBManager.ExecuteDataSet("PATIENTVISITS");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable GetByPatientName(string PatientName, long PracticeId)
    {
        DBManager ObjDBManager = new DBManager();

        ObjDBManager.AddParameter("PracticeId", PracticeId);
        ObjDBManager.AddParameter("PatientName", PatientName);

        return ObjDBManager.ExecuteDataTable("Patient_GetByPatientName");
    }
}