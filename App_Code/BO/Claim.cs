using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Claim
/// </summary>
public class Claim
{
	public Claim()
	{
		//
		// TODO: Add constructor logic here
		//
	}


    #region " Private Members "

    long _ClaimId;
    long _PatientId;
    DateTime? _BillDate;
    DateTime? _DOS;
    long _PracticeId;
    int _PracticeLocationsId;
    long _AttendingPhysician;
    long _BillingPhysicianId;
    long _SupervisingPhysicianId;
    long _ReferringPhysicianId;
    string _PANumber = string.Empty;
    string _ReferralNumber = string.Empty;
    string _ICNNumber = string.Empty;
    long _FacilityId;
    DateTime? _HospitalFrom;
    DateTime? _HospitalTo;
    string _PRIStatus = string.Empty;
    string _SECStatus = string.Empty;
    string _OTHStatus = string.Empty;
    string _PATStatus = string.Empty;
    long _AttachmentTypeId;
    string _ClaimStatus = string.Empty;
    DateTime? _ClaimStatusDate;
    string _CurrentVisit = string.Empty;
    string _AllowedVisit = string.Empty;
    bool _AccidentAuto = false;
    bool _AccidentOther = false;
    bool _Employment = false;
    bool _AccidentEmergency = false;
    bool _AccidentTime = false;
    DateTime? _AccidentDate;
    string _AccidentState = string.Empty;
    string _SpinalManipulationConditionCode = string.Empty;
    string _SpinalManipulationDescription = string.Empty;
    bool _SpinalManipulationXrayAvailability = false;
    string _PhysicalExamCode = string.Empty;
    string _PhysicalExamDescription = string.Empty;
    DateTime? _SOCDate;
    DateTime? _LastSeenDate;
    DateTime? _CurrentIllnessDate;
    DateTime? _XRayDate;
    decimal _PrimaryInsurancePayment;
    decimal _SecondaryInsurancePayment;
    decimal _OtherInsurancePayment;
    decimal _PatientPayment;
    decimal _Adjustment;
    decimal _AmountDue;
    decimal _AmountPaid;
    decimal _ClaimTotal;
    string _DxCode1 = string.Empty;
    string _DxCode2 = string.Empty;
    string _DxCode3 = string.Empty;
    string _DxCode4 = string.Empty;
    string _DxCode5 = string.Empty;
    string _DxCode6 = string.Empty;
    string _DxCode7 = string.Empty;
    string _DxCode8 = string.Empty;
    int _SubmissionStatusId;
    long _PatientInsuranceId;
    long? _InsuranceId;
    long? _SecInsuranceId;
    long? _OthInsuranceId;
    int? _PriSubmissionStatusId;
    int? _SecSubmissionStatusId;
    int? _OthSubmissionStatusId;
    byte _AA;
    string _Block1213 = string.Empty;
    string _POS = string.Empty;
    DateTime? _ReBillDate;
    bool _PTLStatus = false;
    string _DelayReasonCode = string.Empty;
    DateTime? _RefDate;
    bool _AddCLIANumber = false;
    string _SpecialProgramCode = string.Empty;
    DateTime? _InjuryDate;
    DateTime? _InjuryTime;
    string _EpsdtServices = string.Empty;
    string _HCFA_Note = string.Empty;
    bool _PatientPaymentPlan = false;
    bool _PatientStatement = false;
    bool _IncludeInSdf = false;
    bool _IsSelfPay = false;
    string _EligibilityStatus = string.Empty;
    DateTime? _EligibilityInquiryDate;
    string _ReferenceNumber = string.Empty;
    long _OrderingPhysician;
    byte _ResponseCode;
    string _ConditionCode = string.Empty;
    string _ReferenceClaimNo = string.Empty;
    DateTime? _ResolveDate;
    DateTime? _LMPDate;
    string _PageNo = string.Empty;
    string _Weight = string.Empty;
    string _TransportDistance = string.Empty;
    string _TransportationReasonCode = string.Empty;
    string _TransportationConditionCode = string.Empty;
    string _TransportCode = string.Empty;
    string _ConditionIndicator = string.Empty;
    DateTime? _EDCDate;
    string _InstitutionConditionCode = string.Empty;
    string _ServiceAuthExceptionCode = string.Empty;
    
    int _ClaimType;
    DateTime? _AdmissionDate;
    DateTime? _DischargeDate;
    DateTime? _OnSetOfCurrentIllness;
    DateTime? _InitialTreatmentDate;
    DateTime? _AcuteManifestation;
    decimal _PatientPaidAmmount;
    string _ServiceAuthorizationException = string.Empty;
    string _MammographyCertificationNumber = string.Empty;
    string _CLIANumber = string.Empty;
    string _ICNDCN = string.Empty;
    string _AmbulancePickUpLocationAddress = string.Empty;
    string _AmbulancePickUpLocationCity = string.Empty;
    string _AmbulancePickUpLocationState = string.Empty;
    string _AmbulancePickUpLocationZip = string.Empty;
    string _AmbulanceDropLocationAddress = string.Empty;
    string _AmbulanceDropLocationCity = string.Empty;
    string _AmbulanceDropLocationState = string.Empty;
    string _AmbulanceDropLocationZip = string.Empty;
    string _PatientWeight = string.Empty;
    string _PatientWeightUnit = string.Empty;
    string _PatientCondition = string.Empty;
    string _EpsdtCode = string.Empty;
    long? _RenderingPhysicianId;
    string _ServiceFacilityLocationName = string.Empty;
    string _ServiceFacilityNPI = string.Empty;
    string _ServiceFacilityAddress = string.Empty;
    string _ServiceFacilityCity = string.Empty;
    string _ServiceFacilityState = string.Empty;
    string _ServiceFacilityZip = string.Empty;
    
    private bool _IsPTL;
    private string _PTLReasons = string.Empty;
    private string _PTLNotes = string.Empty;
    
    private bool _IsSuperBill = false;
    private string _SuperBillReferenceNo = string.Empty;
    private string _SuperBillNotes = string.Empty;
    
    private long? _AppointmentsId;
    private long? _ChartId;
    
    long _CreatedById;
    DateTime _CreatedDate;
    long _ModifiedById;
    DateTime _ModifiedDate;
    bool _Deleted = false;

    #endregion

    #region "Properties"

    public long ClaimId
    {
        get { return _ClaimId; }
        set { _ClaimId = value; }
    }

    public long PatientId
    {
        get { return _PatientId; }
        set { _PatientId = value; }
    }

    public DateTime? BillDate
    {
        get { return _BillDate; }
        set { _BillDate = value; }
    }

    public DateTime? DOS
    {
        get { return _DOS; }
        set { _DOS = value; }
    }

    public long PracticeId
    {
        get { return _PracticeId; }
        set { _PracticeId = value; }
    }

    public int PracticeLocationsId
    {
        get { return _PracticeLocationsId; }
        set { _PracticeLocationsId = value; }
    }

    public long AttendingPhysician
    {
        get { return _AttendingPhysician; }
        set { _AttendingPhysician = value; }
    }

    public long BillingPhysicianId
    {
        get { return _BillingPhysicianId; }
        set { _BillingPhysicianId = value; }
    }

    public long SupervisingPhysicianId
    {
        get { return _SupervisingPhysicianId; }
        set { _SupervisingPhysicianId = value; }
    }

    public long ReferringPhysicianId
    {
        get { return _ReferringPhysicianId; }
        set { _ReferringPhysicianId = value; }
    }

    public string PANumber
    {
        get { return _PANumber; }
        set { _PANumber = value; }
    }

    public string ReferralNumber
    {
        get { return _ReferralNumber; }
        set { _ReferralNumber = value; }
    }

    public string ICNNumber
    {
        get { return _ICNNumber; }
        set { _ICNNumber = value; }
    }

    public long FacilityId
    {
        get { return _FacilityId; }
        set { _FacilityId = value; }
    }

    public DateTime? HospitalFrom
    {
        get { return _HospitalFrom; }
        set { _HospitalFrom = value; }
    }

    public DateTime? HospitalTo
    {
        get { return _HospitalTo; }
        set { _HospitalTo = value; }
    }

    public string PRIStatus
    {
        get { return _PRIStatus; }
        set { _PRIStatus = value; }
    }

    public string SECStatus
    {
        get { return _SECStatus; }
        set { _SECStatus = value; }
    }

    public string OTHStatus
    {
        get { return _OTHStatus; }
        set { _OTHStatus = value; }
    }

    public string PATStatus
    {
        get { return _PATStatus; }
        set { _PATStatus = value; }
    }

    public long AttachmentTypeId
    {
        get { return _AttachmentTypeId; }
        set { _AttachmentTypeId = value; }
    }

    public string ClaimStatus
    {
        get { return _ClaimStatus; }
        set { _ClaimStatus = value; }
    }

    public DateTime? ClaimStatusDate
    {
        get { return _ClaimStatusDate; }
        set { _ClaimStatusDate = value; }
    }

    public string CurrentVisit
    {
        get { return _CurrentVisit; }
        set { _CurrentVisit = value; }
    }

    public string AllowedVisit
    {
        get { return _AllowedVisit; }
        set { _AllowedVisit = value; }
    }

    public bool AccidentAuto
    {
        get { return _AccidentAuto; }
        set { _AccidentAuto = value; }
    }

    public bool AccidentOther
    {
        get { return _AccidentOther; }
        set { _AccidentOther = value; }
    }

    public bool Employment
    {
        get { return _Employment; }
        set { _Employment = value; }
    }

    public bool AccidentEmergency
    {
        get { return _AccidentEmergency; }
        set { _AccidentEmergency = value; }
    }

    public bool AccidentTime
    {
        get { return _AccidentTime; }
        set { _AccidentTime = value; }
    }

    public DateTime? AccidentDate
    {
        get { return _AccidentDate; }
        set { _AccidentDate = value; }
    }

    public string AccidentState
    {
        get { return _AccidentState; }
        set { _AccidentState = value; }
    }

    public string SpinalManipulationConditionCode
    {
        get { return _SpinalManipulationConditionCode; }
        set { _SpinalManipulationConditionCode = value; }
    }

    public string SpinalManipulationDescription
    {
        get { return _SpinalManipulationDescription; }
        set { _SpinalManipulationDescription = value; }
    }

    public bool SpinalManipulationXrayAvailability
    {
        get { return _SpinalManipulationXrayAvailability; }
        set { _SpinalManipulationXrayAvailability = value; }
    }

    public string PhysicalExamCode
    {
        get { return _PhysicalExamCode; }
        set { _PhysicalExamCode = value; }
    }

    public string PhysicalExamDescription
    {
        get { return _PhysicalExamDescription; }
        set { _PhysicalExamDescription = value; }
    }

    public DateTime? SOCDate
    {
        get { return _SOCDate; }
        set { _SOCDate = value; }
    }

    public DateTime? LastSeenDate
    {
        get { return _LastSeenDate; }
        set { _LastSeenDate = value; }
    }

    public DateTime? CurrentIllnessDate
    {
        get { return _CurrentIllnessDate; }
        set { _CurrentIllnessDate = value; }
    }

    public DateTime? XRayDate
    {
        get { return _XRayDate; }
        set { _XRayDate = value; }
    }

    public decimal PrimaryInsurancePayment
    {
        get { return _PrimaryInsurancePayment; }
        set { _PrimaryInsurancePayment = value; }
    }

    public decimal SecondaryInsurancePayment
    {
        get { return _SecondaryInsurancePayment; }
        set { _SecondaryInsurancePayment = value; }
    }

    public decimal OtherInsurancePayment
    {
        get { return _OtherInsurancePayment; }
        set { _OtherInsurancePayment = value; }
    }

    public decimal PatientPayment
    {
        get { return _PatientPayment; }
        set { _PatientPayment = value; }
    }

    public decimal Adjustment
    {
        get { return _Adjustment; }
        set { _Adjustment = value; }
    }

    public decimal AmountDue
    {
        get { return _AmountDue; }
        set { _AmountDue = value; }
    }

    public decimal AmountPaid
    {
        get { return _AmountPaid; }
        set { _AmountPaid = value; }
    }

    public decimal ClaimTotal
    {
        get { return _ClaimTotal; }
        set { _ClaimTotal = value; }
    }

    public string DxCode1
    {
        get { return _DxCode1; }
        set { _DxCode1 = value; }
    }

    public string DxCode2
    {
        get { return _DxCode2; }
        set { _DxCode2 = value; }
    }

    public string DxCode3
    {
        get { return _DxCode3; }
        set { _DxCode3 = value; }
    }

    public string DxCode4
    {
        get { return _DxCode4; }
        set { _DxCode4 = value; }
    }

    public string DxCode5
    {
        get { return _DxCode5; }
        set { _DxCode5 = value; }
    }

    public string DxCode6
    {
        get { return _DxCode6; }
        set { _DxCode6 = value; }
    }

    public string DxCode7
    {
        get { return _DxCode7; }
        set { _DxCode7 = value; }
    }

    public string DxCode8
    {
        get { return _DxCode8; }
        set { _DxCode8 = value; }
    }

    public int SubmissionStatusId
    {
        get { return _SubmissionStatusId; }
        set { _SubmissionStatusId = value; }
    }

    public long PatientInsuranceId
    {
        get { return _PatientInsuranceId; }
        set { _PatientInsuranceId = value; }
    }

    public long? InsuranceId
    {
        get { return _InsuranceId; }
        set { _InsuranceId = value; }
    }

    public long? SecInsuranceId
    {
        get { return _SecInsuranceId; }
        set { _SecInsuranceId = value; }
    }

    public long? OthInsuranceId
    {
        get { return _OthInsuranceId; }
        set { _OthInsuranceId = value; }
    }

    public int? PriSubmissionStatusId
    {
        get { return _PriSubmissionStatusId; }
        set { _PriSubmissionStatusId = value; }
    }

    public int? SecSubmissionStatusId
    {
        get { return _SecSubmissionStatusId; }
        set { _SecSubmissionStatusId = value; }
    }

    public int? OthSubmissionStatusId
    {
        get { return _OthSubmissionStatusId; }
        set { _OthSubmissionStatusId = value; }
    }

    public byte AA
    {
        get { return _AA; }
        set { _AA = value; }
    }

    public string Block1213
    {
        get { return _Block1213; }
        set { _Block1213 = value; }
    }

    public string POS
    {
        get { return _POS; }
        set { _POS = value; }
    }

    public DateTime? ReBillDate
    {
        get { return _ReBillDate; }
        set { _ReBillDate = value; }
    }

    public bool PTLStatus
    {
        get { return _PTLStatus; }
        set { _PTLStatus = value; }
    }

    public string DelayReasonCode
    {
        get { return _DelayReasonCode; }
        set { _DelayReasonCode = value; }
    }

    public DateTime? RefDate
    {
        get { return _RefDate; }
        set { _RefDate = value; }
    }

    public bool AddCLIANumber
    {
        get { return _AddCLIANumber; }
        set { _AddCLIANumber = value; }
    }

    public string SpecialProgramCode
    {
        get { return _SpecialProgramCode; }
        set { _SpecialProgramCode = value; }
    }

    public DateTime? InjuryDate
    {
        get { return _InjuryDate; }
        set { _InjuryDate = value; }
    }

    public DateTime? InjuryTime
    {
        get { return _InjuryTime; }
        set { _InjuryTime = value; }
    }

    public string EpsdtServices
    {
        get { return _EpsdtServices; }
        set { _EpsdtServices = value; }
    }

    public string HCFA_Note
    {
        get { return _HCFA_Note; }
        set { _HCFA_Note = value; }
    }

    public bool PatientPaymentPlan
    {
        get { return _PatientPaymentPlan; }
        set { _PatientPaymentPlan = value; }
    }

    public bool PatientStatement
    {
        get { return _PatientStatement; }
        set { _PatientStatement = value; }
    }

    public bool IncludeInSdf
    {
        get { return _IncludeInSdf; }
        set { _IncludeInSdf = value; }
    }

    public bool IsSelfPay
    {
        get { return _IsSelfPay; }
        set { _IsSelfPay = value; }
    }

    public string EligibilityStatus
    {
        get { return _EligibilityStatus; }
        set { _EligibilityStatus = value; }
    }

    public DateTime? EligibilityInquiryDate
    {
        get { return _EligibilityInquiryDate; }
        set { _EligibilityInquiryDate = value; }
    }

    public string ReferenceNumber
    {
        get { return _ReferenceNumber; }
        set { _ReferenceNumber = value; }
    }

    public long OrderingPhysician
    {
        get { return _OrderingPhysician; }
        set { _OrderingPhysician = value; }
    }

    public byte ResponseCode
    {
        get { return _ResponseCode; }
        set { _ResponseCode = value; }
    }

    public string ConditionCode
    {
        get { return _ConditionCode; }
        set { _ConditionCode = value; }
    }

    public string ReferenceClaimNo
    {
        get { return _ReferenceClaimNo; }
        set { _ReferenceClaimNo = value; }
    }

    public DateTime? ResolveDate
    {
        get { return _ResolveDate; }
        set { _ResolveDate = value; }
    }

    public DateTime? LMPDate
    {
        get { return _LMPDate; }
        set { _LMPDate = value; }
    }

    public string PageNo
    {
        get { return _PageNo; }
        set { _PageNo = value; }
    }

    public string Weight
    {
        get { return _Weight; }
        set { _Weight = value; }
    }

    public string TransportDistance
    {
        get { return _TransportDistance; }
        set { _TransportDistance = value; }
    }

    public string TransportationReasonCode
    {
        get { return _TransportationReasonCode; }
        set { _TransportationReasonCode = value; }
    }

    public string TransportationConditionCode
    {
        get { return _TransportationConditionCode; }
        set { _TransportationConditionCode = value; }
    }

    public string TransportCode
    {
        get { return _TransportCode; }
        set { _TransportCode = value; }
    }

    public string ConditionIndicator
    {
        get { return _ConditionIndicator; }
        set { _ConditionIndicator = value; }
    }

    public DateTime? EDCDate
    {
        get { return _EDCDate; }
        set { _EDCDate = value; }
    }

    public string InstitutionConditionCode
    {
        get { return _InstitutionConditionCode; }
        set { _InstitutionConditionCode = value; }
    }

    public string ServiceAuthExceptionCode
    {
        get { return _ServiceAuthExceptionCode; }
        set { _ServiceAuthExceptionCode = value; }
    }

    public int ClaimType
    {
        get { return _ClaimType; }
        set { _ClaimType = value; }
    }

    public DateTime? AdmissionDate
    {
        get { return _AdmissionDate; }
        set { _AdmissionDate = value; }
    }

    public DateTime? DischargeDate
    {
        get { return _DischargeDate; }
        set { _DischargeDate = value; }
    }

    public DateTime? OnSetOfCurrentIllness
    {
        get { return _OnSetOfCurrentIllness; }
        set { _OnSetOfCurrentIllness = value; }
    }

    public DateTime? InitialTreatmentDate
    {
        get { return _InitialTreatmentDate; }
        set { _InitialTreatmentDate = value; }
    }

    public DateTime? AcuteManifestation
    {
        get { return _AcuteManifestation; }
        set { _AcuteManifestation = value; }
    }

    public decimal PatientPaidAmmount
    {
        get { return _PatientPaidAmmount; }
        set { _PatientPaidAmmount = value; }
    }

    public string ServiceAuthorizationException
    {
        get { return _ServiceAuthorizationException; }
        set { _ServiceAuthorizationException = value; }
    }

    public string MammographyCertificationNumber
    {
        get { return _MammographyCertificationNumber; }
        set { _MammographyCertificationNumber = value; }
    }

    public string CLIANumber
    {
        get { return _CLIANumber; }
        set { _CLIANumber = value; }
    }

    public string ICNDCN
    {
        get { return _ICNDCN; }
        set { _ICNDCN = value; }
    }

    public string AmbulancePickUpLocationAddress
    {
        get { return _AmbulancePickUpLocationAddress; }
        set { _AmbulancePickUpLocationAddress = value; }
    }

    public string AmbulancePickUpLocationCity
    {
        get { return _AmbulancePickUpLocationCity; }
        set { _AmbulancePickUpLocationCity = value; }
    }

    public string AmbulancePickUpLocationState
    {
        get { return _AmbulancePickUpLocationState; }
        set { _AmbulancePickUpLocationState = value; }
    }

    public string AmbulancePickUpLocationZip
    {
        get { return _AmbulancePickUpLocationZip; }
        set { _AmbulancePickUpLocationZip = value; }
    }

    public string AmbulanceDropLocationAddress
    {
        get { return _AmbulanceDropLocationAddress; }
        set { _AmbulanceDropLocationAddress = value; }
    }

    public string AmbulanceDropLocationCity
    {
        get { return _AmbulanceDropLocationCity; }
        set { _AmbulanceDropLocationCity = value; }
    }

    public string AmbulanceDropLocationState
    {
        get { return _AmbulanceDropLocationState; }
        set { _AmbulanceDropLocationState = value; }
    }

    public string AmbulanceDropLocationZip
    {
        get { return _AmbulanceDropLocationZip; }
        set { _AmbulanceDropLocationZip = value; }
    }

    public string PatientWeight
    {
        get { return _PatientWeight; }
        set { _PatientWeight = value; }
    }

    public string PatientWeightUnit
    {
        get { return _PatientWeightUnit; }
        set { _PatientWeightUnit = value; }
    }

    public string PatientCondition
    {
        get { return _PatientCondition; }
        set { _PatientCondition = value; }
    }

    public string EpsdtCode
    {
        get { return _EpsdtCode; }
        set { _EpsdtCode = value; }
    }

    public long? RenderingPhysicianId
    {
        get { return _RenderingPhysicianId; }
        set { _RenderingPhysicianId = value; }
    }

    public string ServiceFacilityLocationName
    {
        get { return _ServiceFacilityLocationName; }
        set { _ServiceFacilityLocationName = value; }
    }

    public string ServiceFacilityNPI
    {
        get { return _ServiceFacilityNPI; }
        set { _ServiceFacilityNPI = value; }
    }

    public string ServiceFacilityAddress
    {
        get { return _ServiceFacilityAddress; }
        set { _ServiceFacilityAddress = value; }
    }

    public string ServiceFacilityCity
    {
        get { return _ServiceFacilityCity; }
        set { _ServiceFacilityCity = value; }
    }
    
    public string ServiceFacilityState
    {
        get { return _ServiceFacilityState; }
        set { _ServiceFacilityState = value; }
    }
    
    public string ServiceFacilityZip
    {
        get { return _ServiceFacilityZip; }
        set { _ServiceFacilityZip = value; }
    }
    
    public bool IsPTL
    {
        get { return _IsPTL; }
        set { _IsPTL = value; }
    }
    
    public string PTLReasons
    {
        get { return _PTLReasons; }
        set { _PTLReasons = value; }
    }
    
    public string PTLNotes
    {
        get { return _PTLNotes; }
        set { _PTLNotes = value; }
    }
    
    public bool IsSuperBill
    {
        get { return _IsSuperBill; }
        set { _IsSuperBill = value; }
    }

    public string SuperBillReferenceNo
    {
        get { return _SuperBillReferenceNo; }
        set { _SuperBillReferenceNo = value; }
    }
    
    public string SuperBillNotes
    {
        get { return _SuperBillNotes; }
        set { _SuperBillNotes = value; }
    }
    
    public long? ChartId
    {
        get { return _ChartId; }
        set { _ChartId = value; }
    }

    public long? AppointmentsId
    {
        get { return _AppointmentsId; }
        set { _AppointmentsId = value; }
    }

    
    public long CreatedById
    {
        get { return _CreatedById; }
        set { _CreatedById = value; }
    }
    
    public DateTime CreatedDate
    {
        get { return _CreatedDate; }
        set { _CreatedDate = value; }
    }
    
    public long ModifiedById
    {
        get { return _ModifiedById; }
        set { _ModifiedById = value; }
    }
    
    public DateTime ModifiedDate
    {
        get { return _ModifiedDate; }
        set { _ModifiedDate = value; }
    }
    
    public bool Deleted
    {
        get { return _Deleted; }
        set { _Deleted = value; }
    }
    
    #endregion
}