using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
/// <summary>
/// Summary description for ClaimsDB
/// </summary>
public class ClaimsDB
{
	public ClaimsDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    //rizwan kharal start
    //9 oct 2017
    //  Showing the PtlReason list on Home page in Pendng transition  of claims
    public DataSet ShowPTlOfclaim(long practiceId)
    {
        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("@practiseId", practiceId);
        return objDBManager.ExecuteDataSet("ShowPTlOfClaim");
    }
    //Rizwan End





    //Coded befor my development 9 oct 2017 
    public long Add(Claim objClaim, SqlTransaction objSqlTransaction = null)
    {
        DBManager objDBManager = new DBManager(objSqlTransaction);

        try
        {
            objDBManager.AddParameter("ClaimId", objClaim.ClaimId, SqlDbType.Int, 4, ParameterDirection.Output);

            objDBManager.AddParameter("PracticeId", objClaim.PracticeId);
            objDBManager.AddParameter("PracticeLocationsId", objClaim.PracticeLocationsId);

            objDBManager.AddParameter("PatientId", objClaim.PatientId);
            objDBManager.AddParameter("DOS", objClaim.DOS);

            objDBManager.AddParameter("BillDate", objClaim.BillDate);
            objDBManager.AddParameter("AttendingPhysician", objClaim.AttendingPhysician);
            objDBManager.AddParameter("BillingPhysicianId", objClaim.BillingPhysicianId);
            objDBManager.AddParameter("SupervisingPhysicianId", objClaim.SupervisingPhysicianId);
            objDBManager.AddParameter("ReferringPhysicianId", objClaim.ReferringPhysicianId);

            objDBManager.AddParameter("PANumber", objClaim.PANumber);
            objDBManager.AddParameter("ReferralNumber", objClaim.ReferralNumber);
            objDBManager.AddParameter("ICNNumber", objClaim.ICNNumber);
            objDBManager.AddParameter("FacilityId", objClaim.FacilityId);
            objDBManager.AddParameter("HospitalFrom", objClaim.HospitalFrom);
            objDBManager.AddParameter("HospitalTo", objClaim.HospitalTo);
            objDBManager.AddParameter("PRIStatus", objClaim.PRIStatus);
            objDBManager.AddParameter("SECStatus", objClaim.SECStatus);
            objDBManager.AddParameter("OTHStatus", objClaim.OTHStatus);
            objDBManager.AddParameter("PATStatus", objClaim.PATStatus);
            objDBManager.AddParameter("AttachmentTypeId", objClaim.AttachmentTypeId);
            objDBManager.AddParameter("ClaimStatus", objClaim.ClaimStatus);
            objDBManager.AddParameter("ClaimStatusDate", objClaim.ClaimStatusDate);
            objDBManager.AddParameter("CurrentVisit", objClaim.CurrentVisit);
            objDBManager.AddParameter("AllowedVisit", objClaim.AllowedVisit);
            objDBManager.AddParameter("AccidentAuto", objClaim.AccidentAuto);
            objDBManager.AddParameter("AccidentOther", objClaim.AccidentOther);
            objDBManager.AddParameter("Employment", objClaim.Employment);
            objDBManager.AddParameter("AccidentEmergency", objClaim.AccidentEmergency);
            objDBManager.AddParameter("AccidentTime", objClaim.AccidentTime);
            objDBManager.AddParameter("AccidentDate", objClaim.AccidentDate);
            objDBManager.AddParameter("AccidentState", objClaim.AccidentState);
            objDBManager.AddParameter("SpinalManipulationConditionCode", objClaim.SpinalManipulationConditionCode);
            objDBManager.AddParameter("SpinalManipulationDescription", objClaim.SpinalManipulationDescription);
            objDBManager.AddParameter("SpinalManipulationXrayAvailability", objClaim.SpinalManipulationXrayAvailability);
            objDBManager.AddParameter("PhysicalExamCode", objClaim.PhysicalExamCode);
            objDBManager.AddParameter("PhysicalExamDescription", objClaim.PhysicalExamDescription);
            objDBManager.AddParameter("SOCDate", objClaim.SOCDate);
            objDBManager.AddParameter("LastSeenDate", objClaim.LastSeenDate);
            objDBManager.AddParameter("CurrentIllnessDate", objClaim.CurrentIllnessDate);
            objDBManager.AddParameter("XRayDate", objClaim.XRayDate);

            objDBManager.AddParameter("PrimaryInsurancePayment", objClaim.PrimaryInsurancePayment);
            objDBManager.AddParameter("SecondaryInsurancePayment", objClaim.SecondaryInsurancePayment);
            objDBManager.AddParameter("OtherInsurancePayment", objClaim.OtherInsurancePayment);
            objDBManager.AddParameter("PatientPayment", objClaim.PatientPayment);
            objDBManager.AddParameter("Adjustment", objClaim.Adjustment);
            objDBManager.AddParameter("AmountDue", objClaim.AmountDue);
            objDBManager.AddParameter("AmountPaid", objClaim.AmountPaid);
            objDBManager.AddParameter("PatientPaidAmmount", objClaim.PatientPaidAmmount);
            objDBManager.AddParameter("ClaimTotal", objClaim.ClaimTotal);

            objDBManager.AddParameter("DxCode1", objClaim.DxCode1);
            objDBManager.AddParameter("DxCode2", objClaim.DxCode2);
            objDBManager.AddParameter("DxCode3", objClaim.DxCode3);
            objDBManager.AddParameter("DxCode4", objClaim.DxCode4);
            objDBManager.AddParameter("DxCode5", objClaim.DxCode5);
            objDBManager.AddParameter("DxCode6", objClaim.DxCode6);
            objDBManager.AddParameter("DxCode7", objClaim.DxCode7);
            objDBManager.AddParameter("DxCode8", objClaim.DxCode8);
            objDBManager.AddParameter("SubmissionStatusId", objClaim.SubmissionStatusId);
            objDBManager.AddParameter("PatientInsuranceId", objClaim.PatientInsuranceId);
            objDBManager.AddParameter("InsuranceId", objClaim.InsuranceId);
            objDBManager.AddParameter("SecInsuranceId", objClaim.SecInsuranceId);
            objDBManager.AddParameter("OthInsuranceId", objClaim.OthInsuranceId);
            objDBManager.AddParameter("PriSubmissionStatusId", objClaim.PriSubmissionStatusId);
            objDBManager.AddParameter("SecSubmissionStatusId", objClaim.SecSubmissionStatusId);
            objDBManager.AddParameter("OthSubmissionStatusId", objClaim.OthSubmissionStatusId);
            objDBManager.AddParameter("AA", objClaim.AA);
            objDBManager.AddParameter("Block1213", objClaim.Block1213);
            objDBManager.AddParameter("POS", objClaim.POS);
            objDBManager.AddParameter("ReBillDate", objClaim.ReBillDate);
            objDBManager.AddParameter("PTLStatus", objClaim.PTLStatus);
            objDBManager.AddParameter("DelayReasonCode", objClaim.DelayReasonCode);
            objDBManager.AddParameter("RefDate", objClaim.RefDate);
            objDBManager.AddParameter("AddCLIANumber", objClaim.AddCLIANumber);
            objDBManager.AddParameter("SpecialProgramCode", objClaim.SpecialProgramCode);
            objDBManager.AddParameter("InjuryDate", objClaim.InjuryDate);
            objDBManager.AddParameter("InjuryTime", objClaim.InjuryTime);
            objDBManager.AddParameter("EpsdtServices", objClaim.EpsdtServices);
            objDBManager.AddParameter("HCFA_Note", objClaim.HCFA_Note);
            objDBManager.AddParameter("PatientPaymentPlan", objClaim.PatientPaymentPlan);
            objDBManager.AddParameter("PatientStatement", objClaim.PatientStatement);
            objDBManager.AddParameter("IncludeInSdf", objClaim.IncludeInSdf);
            objDBManager.AddParameter("IsSelfPay", objClaim.IsSelfPay);
            objDBManager.AddParameter("EligibilityStatus", objClaim.EligibilityStatus);
            objDBManager.AddParameter("EligibilityInquiryDate", objClaim.EligibilityInquiryDate);
            objDBManager.AddParameter("ReferenceNumber", objClaim.ReferenceNumber);
            objDBManager.AddParameter("OrderingPhysician", objClaim.OrderingPhysician);
            objDBManager.AddParameter("ResponseCode", objClaim.ResponseCode);
            objDBManager.AddParameter("ConditionCode", objClaim.ConditionCode);
            objDBManager.AddParameter("ReferenceClaimNo", objClaim.ReferenceClaimNo);
            objDBManager.AddParameter("ResolveDate", objClaim.ResolveDate);
            objDBManager.AddParameter("LMPDate", objClaim.LMPDate);
            objDBManager.AddParameter("PageNo", objClaim.PageNo);
            objDBManager.AddParameter("Weight", objClaim.Weight);
            objDBManager.AddParameter("TransportDistance", objClaim.TransportDistance);
            objDBManager.AddParameter("TransportationReasonCode", objClaim.TransportationReasonCode);
            objDBManager.AddParameter("TransportationConditionCode", objClaim.TransportationConditionCode);
            objDBManager.AddParameter("TransportCode", objClaim.TransportCode);
            objDBManager.AddParameter("ConditionIndicator", objClaim.ConditionIndicator);
            objDBManager.AddParameter("EDCDate", objClaim.EDCDate);
            objDBManager.AddParameter("InstitutionConditionCode", objClaim.InstitutionConditionCode);
            objDBManager.AddParameter("ServiceAuthExceptionCode", objClaim.ServiceAuthExceptionCode);
            objDBManager.AddParameter("ClaimType", objClaim.ClaimType);

            objDBManager.AddParameter("AdmissionDate", objClaim.AdmissionDate);
            objDBManager.AddParameter("DischargeDate", objClaim.DischargeDate);
            objDBManager.AddParameter("OnSetOfCurrentIllness", objClaim.OnSetOfCurrentIllness);
            objDBManager.AddParameter("InitialTreatmentDate", objClaim.InitialTreatmentDate);
            objDBManager.AddParameter("AcuteManifestation", objClaim.AcuteManifestation);
            objDBManager.AddParameter("ServiceAuthorizationException", objClaim.ServiceAuthorizationException);
            objDBManager.AddParameter("MammographyCertificationNumber", objClaim.MammographyCertificationNumber);
            objDBManager.AddParameter("CLIANumber", objClaim.CLIANumber);
            objDBManager.AddParameter("ICNDCN", objClaim.ICNDCN);
            objDBManager.AddParameter("AmbulancePickUpLocationAddress", objClaim.AmbulancePickUpLocationAddress);
            objDBManager.AddParameter("AmbulancePickUpLocationCity", objClaim.AmbulancePickUpLocationCity);
            objDBManager.AddParameter("AmbulancePickUpLocationState", objClaim.AmbulancePickUpLocationState);
            objDBManager.AddParameter("AmbulancePickUpLocationZip", objClaim.AmbulancePickUpLocationZip);
            objDBManager.AddParameter("AmbulanceDropLocationAddress", objClaim.AmbulanceDropLocationAddress);
            objDBManager.AddParameter("AmbulanceDropLocationCity", objClaim.AmbulanceDropLocationCity);
            objDBManager.AddParameter("AmbulanceDropLocationState", objClaim.AmbulanceDropLocationState);
            objDBManager.AddParameter("AmbulanceDropLocationZip", objClaim.AmbulanceDropLocationZip);
            objDBManager.AddParameter("PatientWeight", objClaim.PatientWeight);
            objDBManager.AddParameter("PatientWeightUnit", objClaim.PatientWeightUnit);
            objDBManager.AddParameter("PatientCondition", objClaim.PatientCondition);
            objDBManager.AddParameter("EpsdtCode", objClaim.EpsdtCode);
            objDBManager.AddParameter("RenderingPhysicianId", objClaim.RenderingPhysicianId);
            objDBManager.AddParameter("ServiceFacilityLocationName", objClaim.ServiceFacilityLocationName);
            objDBManager.AddParameter("ServiceFacilityNPI", objClaim.ServiceFacilityNPI);
            objDBManager.AddParameter("ServiceFacilityAddress", objClaim.ServiceFacilityAddress);
            objDBManager.AddParameter("ServiceFacilityCity", objClaim.ServiceFacilityCity);
            objDBManager.AddParameter("ServiceFacilityState", objClaim.ServiceFacilityState);
            objDBManager.AddParameter("ServiceFacilityZip", objClaim.ServiceFacilityZip);

            objDBManager.AddParameter("IsSuperBill", objClaim.IsSuperBill);
            objDBManager.AddParameter("SuperBillReferenceNo", objClaim.SuperBillReferenceNo);
            objDBManager.AddParameter("SuperBillNotes", objClaim.SuperBillNotes);

            objDBManager.AddParameter("AppointmentsId", objClaim.AppointmentsId);
            objDBManager.AddParameter("ChartId", objClaim.ChartId);

            objDBManager.AddParameter("CreatedById", objClaim.CreatedById);
            objDBManager.AddParameter("CreatedDate", objClaim.CreatedDate);

            objDBManager.ExecuteNonQuery("Claim_Add");
            objClaim.ClaimId = long.Parse(objDBManager.Parameters[0].Value.ToString());
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return objClaim.ClaimId;
    }

    public int Update(Claim objClaim, SqlTransaction objSqlTransaction = null)
    {
        DBManager objDBManager = new DBManager(objSqlTransaction);
        int ReturnValue = 0;

        try
        {
            objDBManager.AddParameter("ClaimId", objClaim.ClaimId, SqlDbType.Int, 4);

            objDBManager.AddParameter("PatientId", objClaim.PatientId);
            objDBManager.AddParameter("DOS", objClaim.DOS);

            objDBManager.AddParameter("PracticeLocationsId", objClaim.PracticeLocationsId);

            objDBManager.AddParameter("BillDate", objClaim.BillDate);
            objDBManager.AddParameter("AttendingPhysician", objClaim.AttendingPhysician);
            objDBManager.AddParameter("BillingPhysicianId", objClaim.BillingPhysicianId);
            objDBManager.AddParameter("SupervisingPhysicianId", objClaim.SupervisingPhysicianId);
            objDBManager.AddParameter("ReferringPhysicianId", objClaim.ReferringPhysicianId);

            objDBManager.AddParameter("PANumber", objClaim.PANumber);
            objDBManager.AddParameter("ReferralNumber", objClaim.ReferralNumber);
            objDBManager.AddParameter("ICNNumber", objClaim.ICNNumber);
            objDBManager.AddParameter("FacilityId", objClaim.FacilityId);
            objDBManager.AddParameter("HospitalFrom", objClaim.HospitalFrom);
            objDBManager.AddParameter("HospitalTo", objClaim.HospitalTo);
            objDBManager.AddParameter("PRIStatus", objClaim.PRIStatus);
            objDBManager.AddParameter("SECStatus", objClaim.SECStatus);
            objDBManager.AddParameter("OTHStatus", objClaim.OTHStatus);
            objDBManager.AddParameter("PATStatus", objClaim.PATStatus);
            objDBManager.AddParameter("AttachmentTypeId", objClaim.AttachmentTypeId);
            objDBManager.AddParameter("ClaimStatus", objClaim.ClaimStatus);
            objDBManager.AddParameter("ClaimStatusDate", objClaim.ClaimStatusDate);
            objDBManager.AddParameter("CurrentVisit", objClaim.CurrentVisit);
            objDBManager.AddParameter("AllowedVisit", objClaim.AllowedVisit);
            objDBManager.AddParameter("AccidentAuto", objClaim.AccidentAuto);
            objDBManager.AddParameter("AccidentOther", objClaim.AccidentOther);
            objDBManager.AddParameter("Employment", objClaim.Employment);
            objDBManager.AddParameter("AccidentEmergency", objClaim.AccidentEmergency);
            objDBManager.AddParameter("AccidentTime", objClaim.AccidentTime);
            objDBManager.AddParameter("AccidentDate", objClaim.AccidentDate);
            objDBManager.AddParameter("AccidentState", objClaim.AccidentState);
            objDBManager.AddParameter("SpinalManipulationConditionCode", objClaim.SpinalManipulationConditionCode);
            objDBManager.AddParameter("SpinalManipulationDescription", objClaim.SpinalManipulationDescription);
            objDBManager.AddParameter("SpinalManipulationXrayAvailability", objClaim.SpinalManipulationXrayAvailability);
            objDBManager.AddParameter("PhysicalExamCode", objClaim.PhysicalExamCode);
            objDBManager.AddParameter("PhysicalExamDescription", objClaim.PhysicalExamDescription);
            objDBManager.AddParameter("SOCDate", objClaim.SOCDate);
            objDBManager.AddParameter("LastSeenDate", objClaim.LastSeenDate);
            objDBManager.AddParameter("CurrentIllnessDate", objClaim.CurrentIllnessDate);
            objDBManager.AddParameter("XRayDate", objClaim.XRayDate);

            /*
            objDBManager.AddParameter("PrimaryInsurancePayment", objClaim.PrimaryInsurancePayment);
            objDBManager.AddParameter("SecondaryInsurancePayment", objClaim.SecondaryInsurancePayment);
            objDBManager.AddParameter("OtherInsurancePayment", objClaim.OtherInsurancePayment);
            objDBManager.AddParameter("PatientPayment", objClaim.PatientPayment);
            objDBManager.AddParameter("Adjustment", objClaim.Adjustment);
            objDBManager.AddParameter("AmountDue", objClaim.AmountDue);
            objDBManager.AddParameter("AmountPaid", objClaim.AmountPaid);
            objDBManager.AddParameter("PatientPaidAmmount", objClaim.PatientPaidAmmount);
            */

            objDBManager.AddParameter("ClaimTotal", objClaim.ClaimTotal);

            objDBManager.AddParameter("DxCode1", objClaim.DxCode1);
            objDBManager.AddParameter("DxCode2", objClaim.DxCode2);
            objDBManager.AddParameter("DxCode3", objClaim.DxCode3);
            objDBManager.AddParameter("DxCode4", objClaim.DxCode4);
            objDBManager.AddParameter("DxCode5", objClaim.DxCode5);
            objDBManager.AddParameter("DxCode6", objClaim.DxCode6);
            objDBManager.AddParameter("DxCode7", objClaim.DxCode7);
            objDBManager.AddParameter("DxCode8", objClaim.DxCode8);
            objDBManager.AddParameter("SubmissionStatusId", objClaim.SubmissionStatusId);
            objDBManager.AddParameter("PatientInsuranceId", objClaim.PatientInsuranceId);
            objDBManager.AddParameter("InsuranceId", objClaim.InsuranceId);
            objDBManager.AddParameter("SecInsuranceId", objClaim.SecInsuranceId);
            objDBManager.AddParameter("OthInsuranceId", objClaim.OthInsuranceId);
            objDBManager.AddParameter("PriSubmissionStatusId", objClaim.PriSubmissionStatusId);
            objDBManager.AddParameter("SecSubmissionStatusId", objClaim.SecSubmissionStatusId);
            objDBManager.AddParameter("OthSubmissionStatusId", objClaim.OthSubmissionStatusId);
            objDBManager.AddParameter("AA", objClaim.AA);
            objDBManager.AddParameter("Block1213", objClaim.Block1213);
            objDBManager.AddParameter("POS", objClaim.POS);
            objDBManager.AddParameter("ReBillDate", objClaim.ReBillDate);
            objDBManager.AddParameter("PTLStatus", objClaim.PTLStatus);
            objDBManager.AddParameter("DelayReasonCode", objClaim.DelayReasonCode);
            objDBManager.AddParameter("RefDate", objClaim.RefDate);
            objDBManager.AddParameter("AddCLIANumber", objClaim.AddCLIANumber);
            objDBManager.AddParameter("SpecialProgramCode", objClaim.SpecialProgramCode);
            objDBManager.AddParameter("InjuryDate", objClaim.InjuryDate);
            objDBManager.AddParameter("InjuryTime", objClaim.InjuryTime);
            objDBManager.AddParameter("EpsdtServices", objClaim.EpsdtServices);
            objDBManager.AddParameter("HCFA_Note", objClaim.HCFA_Note);
            objDBManager.AddParameter("PatientPaymentPlan", objClaim.PatientPaymentPlan);
            objDBManager.AddParameter("PatientStatement", objClaim.PatientStatement);
            objDBManager.AddParameter("IncludeInSdf", objClaim.IncludeInSdf);
            objDBManager.AddParameter("IsSelfPay", objClaim.IsSelfPay);
            objDBManager.AddParameter("EligibilityStatus", objClaim.EligibilityStatus);
            objDBManager.AddParameter("EligibilityInquiryDate", objClaim.EligibilityInquiryDate);
            objDBManager.AddParameter("ReferenceNumber", objClaim.ReferenceNumber);
            objDBManager.AddParameter("OrderingPhysician", objClaim.OrderingPhysician);
            objDBManager.AddParameter("ResponseCode", objClaim.ResponseCode);
            objDBManager.AddParameter("ConditionCode", objClaim.ConditionCode);
            objDBManager.AddParameter("ReferenceClaimNo", objClaim.ReferenceClaimNo);
            objDBManager.AddParameter("ResolveDate", objClaim.ResolveDate);
            objDBManager.AddParameter("LMPDate", objClaim.LMPDate);
            objDBManager.AddParameter("PageNo", objClaim.PageNo);
            objDBManager.AddParameter("Weight", objClaim.Weight);
            objDBManager.AddParameter("TransportDistance", objClaim.TransportDistance);
            objDBManager.AddParameter("TransportationReasonCode", objClaim.TransportationReasonCode);
            objDBManager.AddParameter("TransportationConditionCode", objClaim.TransportationConditionCode);
            objDBManager.AddParameter("TransportCode", objClaim.TransportCode);
            objDBManager.AddParameter("ConditionIndicator", objClaim.ConditionIndicator);
            objDBManager.AddParameter("EDCDate", objClaim.EDCDate);
            objDBManager.AddParameter("InstitutionConditionCode", objClaim.InstitutionConditionCode);
            objDBManager.AddParameter("ServiceAuthExceptionCode", objClaim.ServiceAuthExceptionCode);
            objDBManager.AddParameter("ClaimType", objClaim.ClaimType);

            objDBManager.AddParameter("AdmissionDate", objClaim.AdmissionDate);
            objDBManager.AddParameter("DischargeDate", objClaim.DischargeDate);
            objDBManager.AddParameter("OnSetOfCurrentIllness", objClaim.OnSetOfCurrentIllness);
            objDBManager.AddParameter("InitialTreatmentDate", objClaim.InitialTreatmentDate);
            objDBManager.AddParameter("AcuteManifestation", objClaim.AcuteManifestation);

            objDBManager.AddParameter("ServiceAuthorizationException", objClaim.ServiceAuthorizationException);
            objDBManager.AddParameter("MammographyCertificationNumber", objClaim.MammographyCertificationNumber);
            objDBManager.AddParameter("CLIANumber", objClaim.CLIANumber);
            objDBManager.AddParameter("ICNDCN", objClaim.ICNDCN);
            objDBManager.AddParameter("AmbulancePickUpLocationAddress", objClaim.AmbulancePickUpLocationAddress);
            objDBManager.AddParameter("AmbulancePickUpLocationCity", objClaim.AmbulancePickUpLocationCity);
            objDBManager.AddParameter("AmbulancePickUpLocationState", objClaim.AmbulancePickUpLocationState);
            objDBManager.AddParameter("AmbulancePickUpLocationZip", objClaim.AmbulancePickUpLocationZip);
            objDBManager.AddParameter("AmbulanceDropLocationAddress", objClaim.AmbulanceDropLocationAddress);
            objDBManager.AddParameter("AmbulanceDropLocationCity", objClaim.AmbulanceDropLocationCity);
            objDBManager.AddParameter("AmbulanceDropLocationState", objClaim.AmbulanceDropLocationState);
            objDBManager.AddParameter("AmbulanceDropLocationZip", objClaim.AmbulanceDropLocationZip);
            objDBManager.AddParameter("PatientWeight", objClaim.PatientWeight);
            objDBManager.AddParameter("PatientWeightUnit", objClaim.PatientWeightUnit);
            objDBManager.AddParameter("PatientCondition", objClaim.PatientCondition);
            objDBManager.AddParameter("EpsdtCode", objClaim.EpsdtCode);
            objDBManager.AddParameter("RenderingPhysicianId", objClaim.RenderingPhysicianId);
            objDBManager.AddParameter("ServiceFacilityLocationName", objClaim.ServiceFacilityLocationName);
            objDBManager.AddParameter("ServiceFacilityNPI", objClaim.ServiceFacilityNPI);
            objDBManager.AddParameter("ServiceFacilityAddress", objClaim.ServiceFacilityAddress);
            objDBManager.AddParameter("ServiceFacilityCity", objClaim.ServiceFacilityCity);
            objDBManager.AddParameter("ServiceFacilityState", objClaim.ServiceFacilityState);
            objDBManager.AddParameter("ServiceFacilityZip", objClaim.ServiceFacilityZip);

            objDBManager.AddParameter("SuperBillNotes", objClaim.SuperBillNotes);

            objDBManager.AddParameter("ModifiedById", objClaim.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objClaim.ModifiedDate);

            ReturnValue = objDBManager.ExecuteNonQuery("Claim_Update");
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ReturnValue;
    }

    public void UpdatePTLInfo(Claim objClaim)
    {
        DBManager objDbManager = new DBManager();

        try
        {
            objDbManager.AddParameter("ClaimId", objClaim.ClaimId);

            objDbManager.AddParameter("IsPTL", objClaim.IsPTL);
            objDbManager.AddParameter("PTLReasons", objClaim.PTLReasons);
            objDbManager.AddParameter("PTLNotes", objClaim.PTLNotes);

            objDbManager.AddParameter("ModifiedById", objClaim.ModifiedById);
            objDbManager.AddParameter("ModifiedDate", objClaim.ModifiedDate);

            objDbManager.ExecuteNonQuery("Claim_UpdatePTLInfo");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public void UpdateClaimStatus(long ClaimId, int StatusCode, String PaymentSource, int ModifiedById)
    {
        DBManager objDBManager = new DBManager();

        try
        {
            objDBManager.AddParameter("ClaimId", ClaimId);

            objDBManager.AddParameter("StatusCode", StatusCode);
            objDBManager.AddParameter("PaymentSource", PaymentSource);
            objDBManager.AddParameter("ModifiedById", ModifiedById);

            objDBManager.ExecuteNonQuery("UpdateClaimStatus");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public void UpdateAmountDue(long ClaimId)
    {
        DBManager objDBManager = new DBManager();

        try
        {
            objDBManager.AddParameter("ClaimId", ClaimId);

            objDBManager.ExecuteNonQuery("Claim_UpdateAmountDue");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public void ResolvePTLStatus(Claim objClaim)
    {
        DBManager objDbManager = new DBManager();

        try
        {
            objDbManager.AddParameter("ClaimId", objClaim.ClaimId);

            objDbManager.AddParameter("ModifiedById", objClaim.ModifiedById);
            objDbManager.AddParameter("ModifiedDate", objClaim.ModifiedDate);

            objDbManager.ExecuteNonQuery("Claim_ResolvePTLStatus");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet GetPatients(long insuranceId, long patientId, int rows, int pageNumber)
    {
        var objDbManager = new DBManager();
        objDbManager.AddParameter("Rows", rows);
        objDbManager.AddParameter("PageNumber", pageNumber);

        if (insuranceId != 0)
            objDbManager.AddParameter("InsuranceId", insuranceId);
        if (patientId != 0)
            objDbManager.AddParameter("PatientId", patientId);
        return objDbManager.ExecuteDataSet("Claim_GetPatients");
    }

    public DataSet GetAllClaims(int rows, int pageno, long insuranceId, int submissingStatusId, int claimType)
    {
        try
        {
            DBManager objDBManager = new DBManager();
            objDBManager.AddParameter("Rows", rows);
            objDBManager.AddParameter("PageNumber", pageno);
            if (insuranceId != 0)
            {
                objDBManager.AddParameter("InsuranceId", insuranceId);
            }
            if (submissingStatusId != 0)
            {
                objDBManager.AddParameter("SubmissionStatusId", submissingStatusId);
            }
            if (claimType != 0)
            {
                objDBManager.AddParameter("ClaimType", claimType);
            }

            return objDBManager.ExecuteDataSet("Claim_GetAllClaims");
        }
        catch (Exception ex)
        {
            throw ex;

        }

    }

    public DataSet GetAllByPractice(long PracticeId, string Location, string ClaimId, string PatientId, string PatientName, string DateOfService, string BillDate, string InsuranceId, string SubmissionStatusId, int Rows, int PageNumber, bool IsPTL = false, string PTLReasons = "")
    {
        try
        {
            DBManager objDBManager = new DBManager();

            objDBManager.AddParameter("Rows", Rows);
            objDBManager.AddParameter("PageNumber", PageNumber);
            objDBManager.AddParameter("PracticeId", PracticeId);

            if (!string.IsNullOrEmpty(ClaimId))
            {
                objDBManager.AddParameter("ClaimId", ClaimId);
            }

            if (!string.IsNullOrEmpty(PatientId))
            {
                objDBManager.AddParameter("PatientId", PatientId);
            }

            if (!string.IsNullOrEmpty(PatientName))
            {
                objDBManager.AddParameter("PatientName", PatientName);
            }

            DateTime DateOfServices;
            if (DateTime.TryParse(DateOfService, out DateOfServices))
            {
                objDBManager.AddParameter("DateOfService", DateOfServices);
            }

            DateTime BillDates;
            if (DateTime.TryParse(BillDate, out BillDates))
            {
                objDBManager.AddParameter("BillDate", BillDates);
            }

            if (!string.IsNullOrEmpty(InsuranceId))
            {
                objDBManager.AddParameter("InsuranceId", long.Parse(InsuranceId));
            }

            if (!string.IsNullOrEmpty(SubmissionStatusId))
            {
                objDBManager.AddParameter("SubmissionStatusId", SubmissionStatusId);
            }

            if (IsPTL)
            {
                objDBManager.AddParameter("IsPTL", IsPTL);
            }

            if (!string.IsNullOrEmpty(PTLReasons))
            {
                objDBManager.AddParameter("PTLReasons", PTLReasons);
            }
            if (!string.IsNullOrEmpty(Location))
            {
                objDBManager.AddParameter("@location", Location);
            }
            return objDBManager.ExecuteDataSet("Claims_GetAllByPractice");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable GetAllByPatient(long PatientId, long ClaimId)
    {
        DBManager objDbManager = new DBManager();

        if (PatientId != 0)
        {
            objDbManager.AddParameter("PatientId", PatientId);
        }

        if (ClaimId != 0)
        {
            objDbManager.AddParameter("ClaimId", ClaimId);
        }

        return objDbManager.ExecuteDataTable("Claims_GetAllByPatient");
    }

    public void ChangeClaimStatus(long claimId, int statusId, long userId)
    {
        DBManager objDBManager = new DBManager();

        objDBManager.AddParameter("ClaimId", claimId);
        objDBManager.AddParameter("StatusId", statusId);

        objDBManager.AddParameter("ModifiedById", userId);
        objDBManager.AddParameter("ModifiedDate", DateTime.Now);

        objDBManager.ExecuteNonQuery("Claim_ChangeClaimStatus");
    }

    public DataSet GetUnProcessedClaims(long practiceId, int rows, int pageNumber, string PatientName, string InsuranceName, string ClaimId)
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

        return objDBManager.ExecuteDataSet("Claim_GetUnProcessedClaims");
    }



    public DataSet GetClaimDetails(long patientId, long claimId)
    {
        var objDBManager = new DBManager();

        objDBManager.AddParameter("ClaimId", claimId);
        objDBManager.AddParameter("PatientId", patientId);

        return objDBManager.ExecuteDataSet("Claim_GetClaimDetails");
    }

    public DataSet GetClaimDetailsEDI(long patientId, long claimId)
    {
        var objDBManager = new DBManager();

        objDBManager.AddParameter("ClaimId", claimId);
        objDBManager.AddParameter("PatientId", patientId);

        return objDBManager.ExecuteDataSet("Claim_GetClaimDetailsEDI");
    }

    public int Delete(Claim objClaim)
    {
        try
        {
            DBManager objDBManager = new DBManager();

            objDBManager.AddParameter("ClaimId", objClaim.ClaimId);

            objDBManager.AddParameter("ModifiedById", objClaim.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objClaim.ModifiedDate);

            return objDBManager.ExecuteNonQuery("Claim_DeleteClaim");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet Claims_GetByInsuranceId(long InsuranceId)
    {
        DBManager objDbManager = new DBManager();

        objDbManager.AddParameter("InsuranceId", InsuranceId);

        DataSet ds = objDbManager.ExecuteDataSet("Claims_GetByInsuranceId");

        ds.Relations.Add("EpisodeClaimsRelations", ds.Tables[0].Columns["ClaimId"], ds.Tables[1].Columns["ClaimId"]);

        return ds;
    }

    public DataTable Claim_GetStatusById(long ClaimId)
    {
        DBManager objDbManager = new DBManager();

        objDbManager.AddParameter("ClaimId", ClaimId);

        return objDbManager.ExecuteDataTable("Claim_GetStatusById");
    }

    public int Claim_UpdateAfterERA(long ClaimId, decimal Adjustments, decimal PaidAmount)
    {
        DBManager objDbManager = new DBManager();

        objDbManager.AddParameter("ClaimId", ClaimId);

        objDbManager.AddParameter("ClaimPayments", PaidAmount);
        objDbManager.AddParameter("ClaimAdjustments", Adjustments);

        return objDbManager.ExecuteNonQuery("Claim_UpdateAfterERA");
    }

    public DataSet GetInformationForCMS1500(long ClaimId, long PatientId)
    {
        DBManager objDbManager = new DBManager();

        objDbManager.AddParameter("ClaimId", ClaimId);

        objDbManager.AddParameter("PatientId", PatientId);

        return objDbManager.ExecuteDataSet("Claims_GetInformationForCMS1500");
    }

    public DataSet GetClaimForSuperBill(long AppointmentsId, long ChartId, long PatientId = 0)
    {
        DBManager objDbManager = new DBManager();

        if (AppointmentsId != 0)
        {
            objDbManager.AddParameter("AppointmentsId", AppointmentsId);
        }

        if (ChartId != 0)
        {
            objDbManager.AddParameter("ChartId", ChartId);
        }

        if (PatientId != 0)
        {
            objDbManager.AddParameter("PatientId", PatientId);
        }

        return objDbManager.ExecuteDataSet("Claims_GetClaimForSuperBill");
    }

    public DataTable GetSuperBillReferenceNo()
    {
        DBManager objDbManager = new DBManager();

        return objDbManager.ExecuteDataTable("Claim_GetSuperBillReferenceNo");
    }

    public DataTable GetClaimDetailsForERA(long ClaimId)
    {
        DBManager objDbManager = new DBManager();

        objDbManager.AddParameter("ClaimId", ClaimId);

        return objDbManager.ExecuteDataTable("GetClaimDetailsForERA");
    }

    public DataTable GetPatientPaymentSummary(long PatientId, string DOS, bool IsAmountDueGreaterThanZero)
    {
        DBManager objDbManager = new DBManager();

        objDbManager.AddParameter("PatientId", PatientId);

        if (!string.IsNullOrEmpty(DOS))
        {
            objDbManager.AddParameter("DOS", DOS);
        }

        if (IsAmountDueGreaterThanZero)
        {
            objDbManager.AddParameter("IsAmountDueGreaterThanZero", IsAmountDueGreaterThanZero);
        }

        return objDbManager.ExecuteDataTable("Claim_GetPatientPaymentSummary");
    }

    public DataSet GetPaymentsData(long ClaimId)
    {
        DBManager objDbManager = new DBManager();

        objDbManager.AddParameter("ClaimId", ClaimId);

        return objDbManager.ExecuteDataSet("Claim_GetPaymentsData");
    }

    public DataSet GetPaymentsDataForView(long ClaimId)
    {
        DBManager objDBManager = new DBManager();

        objDBManager.AddParameter("ClaimId", ClaimId);

        return objDBManager.ExecuteDataSet("Claim_GetPaymentsDataForView");
    }

    public DataTable GetPaymentHistory(long ClaimId)
    {
        DBManager objDbManager = new DBManager();

        objDbManager.AddParameter("ClaimId", ClaimId);

        return objDbManager.ExecuteDataTable("Claim_GetPaymentHistory");
    }

    public DataTable GetPayerIds837For_ERA_PatientPayment_GetAllFilter(long ClaimId, bool IsPrimary, bool IsSecondary, bool IsOther)
    {
        DBManager objDBManager = new DBManager();

        objDBManager.AddParameter("ClaimId", ClaimId);

        objDBManager.AddParameter("IsPrimary", IsPrimary);
        objDBManager.AddParameter("IsSecondary", IsSecondary);
        objDBManager.AddParameter("IsOther", IsOther);

        return objDBManager.ExecuteDataTable("Claim_GetPayerIds837For_ERA_PatientPayment_GetAllFilter");
    }

    public DataSet GetPendingSubmissions(long PracticeId, int Rows, int PageNumber)
    {
        var objDBManager = new DBManager();

        objDBManager.AddParameter("PracticeId", PracticeId);
        objDBManager.AddParameter("Rows", Rows);
        objDBManager.AddParameter("PageNumber", PageNumber);
        return objDBManager.ExecuteDataSet("Claim_GetPendingSubmissions");
    }

    public DataTable ClaimSubmissionStatus(long PracticeId, string LocationId, string StartDate, string EndDate, string BillingProviderId, string PostDateFrom, string PostDateTO)
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

        if (!string.IsNullOrEmpty(PostDateFrom))
            objDBManager.AddParameter("PostDateFrom", PostDateFrom);

        if (!string.IsNullOrEmpty(PostDateTO))
            objDBManager.AddParameter("PostDateTO", PostDateTO);

        return objDBManager.ExecuteDataTable("CLAIM_SUBMISSION_STATUS_PIE_CHART");
    }

    public DataTable ClaimSubmissionStatusAging(long PracticeId, string LocationId, string StartDate, string EndDate, string BillingProviderId, string PostDateFrom, string PostDateTO)
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

        if (!string.IsNullOrEmpty(PostDateFrom))
            objDBManager.AddParameter("PostDateFrom", PostDateFrom);

        if (!string.IsNullOrEmpty(PostDateTO))
            objDBManager.AddParameter("PostDateTO", PostDateTO);

        return objDBManager.ExecuteDataTable("Claim_SUBMISSION_STATUS_AgingReport");
    }

    public DataTable ClaimPayerDistribution(long PracticeId, string LocationId, string StartDate, string EndDate, string BillingProviderId, string PostDateFrom, string PostDateTO)
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

        if (!string.IsNullOrEmpty(PostDateFrom))
            objDBManager.AddParameter("PostDateFrom", PostDateFrom);

        if (!string.IsNullOrEmpty(PostDateTO))
            objDBManager.AddParameter("PostDateTO", PostDateTO);

        return objDBManager.ExecuteDataTable("PAYER_CLAIM_DISTRIBUTION_PIE_CHART");
    }



    //Rizwan kharal
    // 29 Nov,2017
    // showing claims againts the user id
    public DataSet GetClaims_AllByUserId(long PracticeId, string Location, int UserId, string ClaimId, string PatientId, string PatientName, string DateOfService, string BillDate, string InsuranceId, string SubmissionStatusId, int Rows, int PageNumber, bool IsPTL = false, string PTLReasons = "")
    {
        try
        {
            DBManager objDBManager = new DBManager();

            objDBManager.AddParameter("Rows", Rows);
            objDBManager.AddParameter("PageNumber", PageNumber);
            objDBManager.AddParameter("PracticeId", PracticeId);
            objDBManager.AddParameter("@CreatedId", UserId);

            if (!string.IsNullOrEmpty(ClaimId))
            {
                objDBManager.AddParameter("ClaimId", ClaimId);
            }

            if (!string.IsNullOrEmpty(PatientId))
            {
                objDBManager.AddParameter("PatientId", PatientId);
            }

            if (!string.IsNullOrEmpty(PatientName))
            {
                objDBManager.AddParameter("PatientName", PatientName);
            }

            DateTime DateOfServices;
            if (DateTime.TryParse(DateOfService, out DateOfServices))
            {
                objDBManager.AddParameter("DateOfService", DateOfServices);
            }

            DateTime BillDates;
            if (DateTime.TryParse(BillDate, out BillDates))
            {
                objDBManager.AddParameter("BillDate", BillDates);
            }

            if (!string.IsNullOrEmpty(InsuranceId))
            {
                objDBManager.AddParameter("InsuranceId", long.Parse(InsuranceId));
            }

            if (!string.IsNullOrEmpty(SubmissionStatusId))
            {
                objDBManager.AddParameter("SubmissionStatusId", SubmissionStatusId);
            }

            if (IsPTL)
            {
                objDBManager.AddParameter("IsPTL", IsPTL);
            }

            if (!string.IsNullOrEmpty(PTLReasons))
            {
                objDBManager.AddParameter("PTLReasons", PTLReasons);
            }
            if (!string.IsNullOrEmpty(Location))
            {
                objDBManager.AddParameter("location", Location);
            }

            return objDBManager.ExecuteDataSet("Claims_GetAllByUserId");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    public DataSet GetManagedCareClaim(long patientId, long episodeId, long claimId)
    {
        var objDbManager = new DBManager();

        objDbManager.AddParameter("PatientId", patientId);
        objDbManager.AddParameter("Episodeid", episodeId);
        objDbManager.AddParameter("ClaimId", claimId);

        return objDbManager.ExecuteDataSet("Claim_GetManagedCareClaim");
    }

    public DataSet GetCreateClaimsData(int PracticeId, int rows, int pageNumber, long insuranceId, int branchId, long patientId, int claimType)
    {
        var objDbManager = new DBManager();
        objDbManager.AddParameter("PracticeId", PracticeId);
        objDbManager.AddParameter("Rows", rows);
        objDbManager.AddParameter("PageNumber", pageNumber);
        objDbManager.AddParameter("ClaimTypeId", claimType);

        if (insuranceId != 0)
            objDbManager.AddParameter("InsuranceId", insuranceId);
        if (branchId != 0)
            objDbManager.AddParameter("PracticeLocationsId", branchId);
        if (patientId != 0)
            objDbManager.AddParameter("PatientId", patientId);

        return objDbManager.ExecuteDataSet("Claim_GetCreateClaimsData");
    }

    public DataTable UpdateRapWorkSheet(long episodeId)
    {
        var objDbManager = new DBManager();
        objDbManager.AddParameter("EpisodeId", episodeId);
        return objDbManager.ExecuteDataTable("Claim_UpdateRapWorkSheet");
    }

    public DataTable UpdateEoeWorkSheet(long episodeId)
    {
        var objDbManager = new DBManager();
        objDbManager.AddParameter("EpisodeId", episodeId);
        return objDbManager.ExecuteDataTable("Claim_UpdateEoeWorkSheet");
    }

    public DataTable GetHIPPSCodes(string HIPPSCodes)
    {
        var objDbManager = new DBManager();
        objDbManager.AddParameter("HIPPSCodes", HIPPSCodes);
        return objDbManager.ExecuteDataTable("Claim_GetHIPPSCodes");
    }

    public DataSet GetUnProcessedClaims(int PracticeId, int rows, int pageNumber)
    {
        var objDbManager = new DBManager();
        objDbManager.AddParameter("PracticeId", PracticeId);
        objDbManager.AddParameter("Rows", rows);
        objDbManager.AddParameter("PageNumber", pageNumber);
        return objDbManager.ExecuteDataSet("Claim_GetUnProcessedClaims");
    }

    public void UpdateEpisodeTaskHcpcsStatus(long episodeTaskHcpcsId, string status)
    {
        var objDbManager = new DBManager();
        objDbManager.AddParameter("EpisodeTaskHCPCSId", episodeTaskHcpcsId);
        objDbManager.AddParameter("Status", status);
        objDbManager.ExecuteNonQuery("Claim_UpdateEpisodeTaskHcpcsStatus");
    }

    public DataSet GetFilterCriteria(int PracticeId)
    {
        var objDbManager = new DBManager();
        objDbManager.AddParameter("PracticeId", PracticeId);
        return objDbManager.ExecuteDataSet("Claim_GetFilterCriteria");
    }

    public DataSet GetRapAndEoeData(long episodeId, long patientId, long claimId)
    {
        var objDbManager = new DBManager();
        objDbManager.AddParameter("EpisodeId", episodeId);
        objDbManager.AddParameter("PatientId", patientId);
        objDbManager.AddParameter("ClaimId", claimId);
        return objDbManager.ExecuteDataSet("Claim_GetRapAndEoeData");
    }

    public DataSet EpisodeClaims_GetByInsuranceId(long insuranceId)
    {
        DBManager objDbManager = new DBManager();
        objDbManager.AddParameter("@InsuranceId", insuranceId);
        DataSet ds = objDbManager.ExecuteDataSet("EpisodeClaims_GetByInsuranceId");
        ds.Relations.Add("EpisodeClaimsRelations", ds.Tables[0].Columns["EpisodeClaimsId"],
                         ds.Tables[1].Columns["EpisodeclaimsId"]);
        return ds;
    }

    public DataSet GetERAClaimsDetail(long ClaimCheckId, long PracticeId)
    {
        DBManager objDbManager = new DBManager();
        objDbManager.AddParameter("ClaimCheckId", ClaimCheckId);
        objDbManager.AddParameter("PracticeId", PracticeId);
        return objDbManager.ExecuteDataSet("GetERAClaimsDetail");

    }

    public DataTable GetERAProcedurePaymentDetail(long ERAClaimPaymentId)
    {
        DBManager objDbManager = new DBManager();
        objDbManager.AddParameter("ERAClaimPaymentsId", ERAClaimPaymentId);
        return objDbManager.ExecuteDataTable("GetERAProcedurePaymentDetail");
    }

    public DataTable GetERAProcedureAdjustmentDetail(long ERAClaimPaymentsId, long ERAProcedureAdjustmentsId)
    {
        DBManager objDbManager = new DBManager();
        objDbManager.AddParameter("ERAClaimPaymentsId", ERAClaimPaymentsId);
        objDbManager.AddParameter("ERAProcedureAdjustmentsId", ERAProcedureAdjustmentsId);
        return objDbManager.ExecuteDataTable("GetERAProcedureAdjustmentDetail");
    }
   

}