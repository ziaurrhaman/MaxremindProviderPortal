using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PatientPrescription
/// </summary>
public class PatientPrescription
{
	public PatientPrescription()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    #region " Private Members "

	private long _PatientPrescriptionId;
    private Nullable<long> _PatientId;
    private Nullable<long> _ChartId;
    private Nullable<DateTime> _PrescriptionDate;
    private Nullable<long> _PhysicianId;
    private Nullable<int> _PharmacyId;
    private Nullable<long> _MedicineCode;
    private Nullable<long> _FormulationCode;
    private string _Sig = string.Empty;
    private string _Dispense = string.Empty;
    private string _DurationNo = string.Empty;
    private string _DurationUnit = string.Empty;
    private string _Total = string.Empty;
    private string _Route = string.Empty;
    private string _Refill = string.Empty;
    private bool _Substitute = false;
    private string _Advice = string.Empty;
	private bool _Active = false;
	private bool _Print = false;
    private bool _PrintDEA = false;
    private Nullable<DateTime> _RxDate;
    private Nullable<DateTime> _DateWritten;
    private Nullable<DateTime> _DateDispensed;
    private Nullable<DateTime> _DateDiscard;
    private Nullable<DateTime> _DateExpire;
    private bool _Complete = false;
    private string _PrescriptionType = string.Empty;
    private bool _OverrideAdverse = false;
    private string _OverrideReason = string.Empty;
    private bool _CheckContraIndication = false;
    private string _NotesPharmacy = string.Empty;
    private bool _IsConfidential = false;
    private bool _PrescriptionReviewed = false;
    private Nullable<long> _PrescriptionReviewBy;
    private Nullable<DateTime> _PrescriptionReviewDate;
    private string _PrescriptionDX = string.Empty;
    private string _ProviderInstruction = string.Empty;
    private Nullable<DateTime> _StartDate;
    private Nullable<DateTime> _EndDate;
    private string _DrugToDrug = string.Empty;
    private string _DrugToDisease = string.Empty;
    private string _DrugToAllergy = string.Empty;
    private string _PrescriptionStatus = string.Empty;
    private string _UnitCode = string.Empty;
    private string _EPMsgFunction = string.Empty;
    private string _EPMsgRefNo = string.Empty;
    private string _EPMsgStatus = string.Empty;
    private string _EPMsgReason = string.Empty;
    private string _EPMsgDetail = string.Empty;
    private bool _OnHold = false;
    private string _DrugToFood = string.Empty;
    private string _MedicineTrade = string.Empty;
    private string _EPFreeText = string.Empty;
    private string _EPInitialRefIdentifier = string.Empty;
    private string _EPPrescriberOrderNo = string.Empty;
    private string _EPSureScripRefNo = string.Empty;
    private string _EPTransControlNo = string.Empty;
    private string _EPResponse_code = string.Empty;
    private string _EPResponseQualifier = string.Empty;
    private Nullable<long> _PracticeId;
    private string _PharmacyDescription = string.Empty;
    private string _Status = string.Empty;
    private string _Status_Comments = string.Empty;
    private string _RxNorm = string.Empty;
    private string _FormularyDetailForEARReport = string.Empty;
    private string _EligPatientIdentificationNo = string.Empty;
    private string _EligBinLocationNumber = string.Empty;
    private string _EligPayerID = string.Empty;
    private string _EligPayerName = string.Empty;
    private string _EligCardHolderID = string.Empty;
    private string _EligCardHolderName = string.Empty;
    private string _EligGroupID = string.Empty;
    private string _DrugDatabaseSource = string.Empty;
    private bool _IsCarryForward = false;
    private Nullable<long> _CreatedById;
    private Nullable<DateTime> _CreatedDate;
    private Nullable<long> _ModifiedById;
    private Nullable<DateTime> _ModifiedDate;
    private bool _Deleted = false;
    bool _IncludeNPI = false;
    bool _IncludeDEA = false;
    bool _IncludeStateId = false;
    bool _DispenseAs = false;
    private DateTime? _Refill1Date;
    private DateTime? _Refill2Date;
    private DateTime? _Refill3Date;
    private DateTime? _Refill4Date;
    private DateTime? _Refill5Date;
    private DateTime? _Refill6Date;
    #endregion


    #region " Properties "

    public long PatientPrescriptionId
    {
        get { return _PatientPrescriptionId; }
        set { _PatientPrescriptionId = value; }
    }

    public Nullable<long> PatientId
    {
        get { return _PatientId; }
        set { _PatientId = value; }
    }

    public Nullable<long> ChartId
    {
        get { return _ChartId; }
        set { _ChartId = value; }
    }

    public Nullable<DateTime> PrescriptionDate
    {
        get { return _PrescriptionDate; }
        set { _PrescriptionDate = value; }
    }

    public Nullable<long> PhysicianId
    {
        get { return _PhysicianId; }
        set { _PhysicianId = value; }
    }

    public Nullable<int> PharmacyId
    {
        get { return _PharmacyId; }
        set { _PharmacyId = value; }
    }

    public Nullable<long> MedicineCode
    {
        get { return _MedicineCode; }
        set { _MedicineCode = value; }
    }

    public Nullable<long> FormulationCode
    {
        get { return _FormulationCode; }
        set { _FormulationCode = value; }
    }

    public string Sig
    {
        get { return _Sig; }
        set { _Sig = value; }
    }

    public string Dispense
    {
        get { return _Dispense; }
        set { _Dispense = value; }
    }

    public string DurationNo
    {
        get { return _DurationNo; }
        set { _DurationNo = value; }
    }

    public string DurationUnit
    {
        get { return _DurationUnit; }
        set { _DurationUnit = value; }
    }

    public string Total
    {
        get { return _Total; }
        set { _Total = value; }
    }

    public string Route
    {
        get { return _Route; }
        set { _Route = value; }
    }

    public string Refill
    {
        get { return _Refill; }
        set { _Refill = value; }
    }

    public bool Substitute
    {
        get { return _Substitute; }
        set { _Substitute = value; }
    }

    public string Advice
    {
        get { return _Advice; }
        set { _Advice = value; }
    }

    public bool Active
    {
        get { return _Active; }
        set { _Active = value; }
    }

    public bool Print
    {
        get { return _Print; }
        set { _Print = value; }
    }

    public bool PrintDEA
    {
        get { return _PrintDEA; }
        set { _PrintDEA = value; }
    }

    public Nullable<DateTime> RxDate
    {
        get { return _RxDate; }
        set { _RxDate = value; }
    }

    public Nullable<DateTime> DateWritten
    {
        get { return _DateWritten; }
        set { _DateWritten = value; }
    }

    public Nullable<DateTime> DateDispensed
    {
        get { return _DateDispensed; }
        set { _DateDispensed = value; }
    }

    public Nullable<DateTime> DateDiscard
    {
        get { return _DateDiscard; }
        set { _DateDiscard = value; }
    }

    public Nullable<DateTime> DateExpire
    {
        get { return _DateExpire; }
        set { _DateExpire = value; }
    }

    public bool Complete
    {
        get { return _Complete; }
        set { _Complete = value; }
    }

    public string PrescriptionType
    {
        get { return _PrescriptionType; }
        set { _PrescriptionType = value; }
    }

    public bool OverrideAdverse
    {
        get { return _OverrideAdverse; }
        set { _OverrideAdverse = value; }
    }

    public string OverrideReason
    {
        get { return _OverrideReason; }
        set { _OverrideReason = value; }
    }

    public bool CheckContraIndication
    {
        get { return _CheckContraIndication; }
        set { _CheckContraIndication = value; }
    }

    public string NotesPharmacy
    {
        get { return _NotesPharmacy; }
        set { _NotesPharmacy = value; }
    }

    public bool IsConfidential
    {
        get { return _IsConfidential; }
        set { _IsConfidential = value; }
    }

    public bool PrescriptionReviewed
    {
        get { return _PrescriptionReviewed; }
        set { _PrescriptionReviewed = value; }
    }

    public Nullable<long> PrescriptionReviewBy
    {
        get { return _PrescriptionReviewBy; }
        set { _PrescriptionReviewBy = value; }
    }

    public Nullable<DateTime> PrescriptionReviewDate
    {
        get { return _PrescriptionReviewDate; }
        set { _PrescriptionReviewDate = value; }
    }

    public string PrescriptionDX
    {
        get { return _PrescriptionDX; }
        set { _PrescriptionDX = value; }
    }

    public string ProviderInstruction
    {
        get { return _ProviderInstruction; }
        set { _ProviderInstruction = value; }
    }

    public Nullable<DateTime> StartDate
    {
        get { return _StartDate; }
        set { _StartDate = value; }
    }

    public Nullable<DateTime> EndDate
    {
        get { return _EndDate; }
        set { _EndDate = value; }
    }

    public string DrugToDrug
    {
        get { return _DrugToDrug; }
        set { _DrugToDrug = value; }
    }

    public string DrugToDisease
    {
        get { return _DrugToDisease; }
        set { _DrugToDisease = value; }
    }

    public string DrugToAllergy
    {
        get { return _DrugToAllergy; }
        set { _DrugToAllergy = value; }
    }

    public string PrescriptionStatus
    {
        get { return _PrescriptionStatus; }
        set { _PrescriptionStatus = value; }
    }

    public string UnitCode
    {
        get { return _UnitCode; }
        set { _UnitCode = value; }
    }

    public string EPMsgFunction
    {
        get { return _EPMsgFunction; }
        set { _EPMsgFunction = value; }
    }

    public string EPMsgRefNo
    {
        get { return _EPMsgRefNo; }
        set { _EPMsgRefNo = value; }
    }

    public string EPMsgStatus
    {
        get { return _EPMsgStatus; }
        set { _EPMsgStatus = value; }
    }

    public string EPMsgReason
    {
        get { return _EPMsgReason; }
        set { _EPMsgReason = value; }
    }

    public string EPMsgDetail
    {
        get { return _EPMsgDetail; }
        set { _EPMsgDetail = value; }
    }

    public bool OnHold
    {
        get { return _OnHold; }
        set { _OnHold = value; }
    }

    public string DrugToFood
    {
        get { return _DrugToFood; }
        set { _DrugToFood = value; }
    }

    public string MedicineTrade
    {
        get { return _MedicineTrade; }
        set { _MedicineTrade = value; }
    }

    public string EPFreeText
    {
        get { return _EPFreeText; }
        set { _EPFreeText = value; }
    }

    public string EPInitialRefIdentifier
    {
        get { return _EPInitialRefIdentifier; }
        set { _EPInitialRefIdentifier = value; }
    }

    public string EPPrescriberOrderNo
    {
        get { return _EPPrescriberOrderNo; }
        set { _EPPrescriberOrderNo = value; }
    }

    public string EPSureScripRefNo
    {
        get { return _EPSureScripRefNo; }
        set { _EPSureScripRefNo = value; }
    }

    public string EPTransControlNo
    {
        get { return _EPTransControlNo; }
        set { _EPTransControlNo = value; }
    }

    public string EPResponse_code
    {
        get { return _EPResponse_code; }
        set { _EPResponse_code = value; }
    }

    public string EPResponseQualifier
    {
        get { return _EPResponseQualifier; }
        set { _EPResponseQualifier = value; }
    }

    public Nullable<long> PracticeId
    {
        get { return _PracticeId; }
        set { _PracticeId = value; }
    }

    public string PharmacyDescription
    {
        get { return _PharmacyDescription; }
        set { _PharmacyDescription = value; }
    }

    public string Status
    {
        get { return _Status; }
        set { _Status = value; }
    }

    public string Status_Comments
    {
        get { return _Status_Comments; }
        set { _Status_Comments = value; }
    }

    public string RxNorm
    {
        get { return _RxNorm; }
        set { _RxNorm = value; }
    }

    public string FormularyDetailForEARReport
    {
        get { return _FormularyDetailForEARReport; }
        set { _FormularyDetailForEARReport = value; }
    }

    public string EligPatientIdentificationNo
    {
        get { return _EligPatientIdentificationNo; }
        set { _EligPatientIdentificationNo = value; }
    }

    public string EligBinLocationNumber
    {
        get { return _EligBinLocationNumber; }
        set { _EligBinLocationNumber = value; }
    }

    public string EligPayerID
    {
        get { return _EligPayerID; }
        set { _EligPayerID = value; }
    }

    public string EligPayerName
    {
        get { return _EligPayerName; }
        set { _EligPayerName = value; }
    }

    public string EligCardHolderID
    {
        get { return _EligCardHolderID; }
        set { _EligCardHolderID = value; }
    }

    public string EligCardHolderName
    {
        get { return _EligCardHolderName; }
        set { _EligCardHolderName = value; }
    }

    public string EligGroupID
    {
        get { return _EligGroupID; }
        set { _EligGroupID = value; }
    }

    public string DrugDatabaseSource
    {
        get { return _DrugDatabaseSource; }
        set { _DrugDatabaseSource = value; }
    }

    public bool IsCarryForward
    {
        get { return _IsCarryForward; }
        set { _IsCarryForward = value; }
    }

    public Nullable<long> CreatedById
    {
        get { return _CreatedById; }
        set { _CreatedById = value; }
    }

    public Nullable<DateTime> CreatedDate
    {
        get { return _CreatedDate; }
        set { _CreatedDate = value; }
    }

    public Nullable<long> ModifiedById
    {
        get { return _ModifiedById; }
        set { _ModifiedById = value; }
    }

    public Nullable<DateTime> ModifiedDate
    {
        get { return _ModifiedDate; }
        set { _ModifiedDate = value; }
    }

    public bool Deleted
    {
        get { return _Deleted; }
        set { _Deleted = value; }
    }
    public bool IncludeNPI
    {
        get { return _IncludeNPI; }
        set { _IncludeNPI = value; }
    }

    public bool IncludeDEA
    {
        get { return _IncludeDEA; }
        set { _IncludeDEA = value; }
    }

    public bool IncludeStateId
    {
        get { return _IncludeStateId; }
        set { _IncludeStateId = value; }
    }

    public bool DispenseAs
    {
        get { return _DispenseAs; }
        set { _DispenseAs = value; }
    }
    public DateTime? Refill1Date
    {
        get { return _Refill1Date; }
        set { _Refill1Date = value; }
    }
    public DateTime? Refill2Date
    {
        get { return _Refill2Date; }
        set { _Refill2Date = value; }
    }
    public DateTime? Refill3Date
    {
        get { return _Refill3Date; }
        set { _Refill3Date = value; }
    }
    public DateTime? Refill4Date
    {
        get { return _Refill4Date; }
        set { _Refill4Date = value; }
    }
    public DateTime? Refill5Date
    {
        get { return _Refill5Date; }
        set { _Refill5Date = value; }
    }
    public DateTime? Refill6Date
    {
        get { return _Refill6Date; }
        set { _Refill6Date = value; }
    }
    #endregion
}