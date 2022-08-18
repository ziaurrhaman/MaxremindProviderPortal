using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Patient
/// </summary>
public class Patient
{
    #region " Private Members "

    private long _PatientId;
    private long _PracticeId;
    private long? _PracticeLocationsId;
    private string _FirstName = string.Empty;
    private string _LastName = string.Empty;
    private string _MiddleName = string.Empty;
    private DateTime? _DateOfBirth;
    private string _TimeOfBirth;
    private string _SSN = string.Empty;
    private string _Gender = string.Empty;
    private string _MaritalStatus = string.Empty;
    private string _RaceId = string.Empty;
    private string _EthnicityId = string.Empty;
    private string _PreferredLanguageId;
    private string _Address = string.Empty;
    private string _AddressType = string.Empty;
    private string _Zip = string.Empty;
    private string _City = string.Empty;
    private string _State = string.Empty;
    private string _HomePhone = string.Empty;
    private string _Cell = string.Empty;
    private string _WorkPhone = string.Empty;
    private string _Ext = string.Empty;
    private string _Email = string.Empty;
    private string _CCP = string.Empty;
    private string _EmergencyContactName = string.Empty;
    private string _Relationship = string.Empty;
    private string _Phone = string.Empty;
    private Int32? _FinancialGuarantorId;
    private string _GuarantorRelationship = string.Empty;
    private DateTime? _DisabilityDate;
   

  

    private DateTime? _DeathDate;
    private string _CauseOfDeath = string.Empty;
    private string _NCPDP = string.Empty;
    private long _PhysicianId;
    private string _AdmissionSource = string.Empty;
    private string _AdmissionType = string.Empty;
    private string _InternalReferral = string.Empty;
    private string _ExternalReferral = string.Empty;
    private DateTime? _ReferralDate;
    private string _ImagePath = string.Empty;
    private string _Notes = string.Empty;
    private string _CommunicationBarriers = string.Empty;
    
    
    private string _UserName = string.Empty;
    private string _Password = string.Empty;
    private bool _ActiveWebAccount = false;

    private bool _IsActive;

    private bool _IsPTL;
    private string _PTLReasons = string.Empty;
    private string _PTLNotes = string.Empty;
    
    private long _CreatedById;
    private DateTime? _CreatedDate;
    private long _ModifiedById;
    private DateTime? _ModifiedByDate;
    private bool _Deleted;


    private string _FinancialGuarantorFirstName;
    private string _FinancialGuarantorLastName;
    private string _FinancialGuarantorMiddleName;


    #endregion

    #region "Properties"

    public long PatientId
    {
        get { return _PatientId; }
        set { _PatientId = value; }
    }
    
    public long PracticeId
    {
        get { return _PracticeId; }
        set { _PracticeId = value; }
    }
    
    public long? PracticeLocationsId
    {
        get { return _PracticeLocationsId; }
        set { _PracticeLocationsId = value; }
    }
    
    public string FirstName
    {
        get { return _FirstName; }
        set { _FirstName = value; }
    }
    
    public string LastName
    {
        get { return _LastName; }
        set { _LastName = value; }
    }
    
    public string MiddleName
    {
        get { return _MiddleName; }
        set { _MiddleName = value; }
    }
    
    public DateTime? DateOfBirth
    {
        get { return _DateOfBirth; }
        set { _DateOfBirth = value; }
    }
    
    public string TimeOfBirth
    {
        get { return _TimeOfBirth; }
        set { _TimeOfBirth = value; }
    }
    
    public string SSN
    {
        get { return _SSN; }
        set { _SSN = value; }
    }

    public string Gender
    {
        get { return _Gender; }
        set { _Gender = value; }
    }

    public string MaritalStatus
    {
        get { return _MaritalStatus; }
        set { _MaritalStatus = value; }
    }

    public string RaceId
    {
        get { return _RaceId; }
        set { _RaceId = value; }
    }

    public string EthnicityId
    {
        get { return _EthnicityId; }
        set { _EthnicityId = value; }
    }

    public string PreferredLanguageId
    {
        get { return _PreferredLanguageId; }
        set { _PreferredLanguageId = value; }
    }

    public string Address
    {
        get { return _Address; }
        set { _Address = value; }
    }

    public string AddressType
    {
        get { return _AddressType; }
        set { _AddressType = value; }
    }

    public string Zip
    {
        get { return _Zip; }
        set { _Zip = value; }
    }

    public string City
    {
        get { return _City; }
        set { _City = value; }
    }

    public string State
    {
        get { return _State; }
        set { _State = value; }
    }

    public string HomePhone
    {
        get { return _HomePhone; }
        set { _HomePhone = value; }
    }

    public string Cell
    {
        get { return _Cell; }
        set { _Cell = value; }
    }

    public string WorkPhone
    {
        get { return _WorkPhone; }
        set { _WorkPhone = value; }
    }

    public string Ext
    {
        get { return _Ext; }
        set { _Ext = value; }
    }

    public string Email
    {
        get { return _Email; }
        set { _Email = value; }
    }

    public string CCP
    {
        get { return _CCP; }
        set { _CCP = value; }
    }

    public string EmergencyContactName
    {
        get { return _EmergencyContactName; }
        set { _EmergencyContactName = value; }
    }

    public string Relationship
    {
        get { return _Relationship; }
        set { _Relationship = value; }
    }

    public string Phone
    {
        get { return _Phone; }
        set { _Phone = value; }
    }

    public Int32? FinancialGuarantorId
    {
        get { return _FinancialGuarantorId; }
        set { _FinancialGuarantorId = value; }
    }

    //Rizwan kharal
    //27 oct 2017
    //For  showing the all name on demographics page for update the FinancialGuarantor Full Name
    public string FinancialGuarantorFirstName
    {
        get { return _FinancialGuarantorFirstName; }
        set { _FinancialGuarantorFirstName = value; }
    }
    public string FinancialGuarantorLastName
    {
        get { return _FinancialGuarantorLastName; }
        set { _FinancialGuarantorLastName = value; }
    }
    public string FinancialGuarantorMiddleName
    {
        get { return _FinancialGuarantorMiddleName; }
        set { _FinancialGuarantorMiddleName = value; }
    }
    //End
    
    public string GuarantorRelationship
    {
        get { return _GuarantorRelationship; }
        set { _GuarantorRelationship = value; }
    }

    public DateTime? DisabilityDate
    {
        get { return _DisabilityDate; }
        set { _DisabilityDate = value; }
    }

    public DateTime? DeathDate
    {
        get { return _DeathDate; }
        set { _DeathDate = value; }
    }

    public string CauseOfDeath
    {
        get { return _CauseOfDeath; }
        set { _CauseOfDeath = value; }
    }

    public string NCPDP
    {
        get { return _NCPDP; }
        set { _NCPDP = value; }
    }

    public long PhysicianID
    {
        get { return _PhysicianId; }
        set { _PhysicianId = value; }
    }

    public string AdmissionType
    {
        get { return _AdmissionType; }
        set { _AdmissionType = value; }
    }

    public string AdmissionSource
    {
        get { return _AdmissionSource; }
        set { _AdmissionSource = value; }
    }

    public string InternalReferral
    {
        get { return _InternalReferral; }
        set { _InternalReferral = value; }
    }

    public string ExternalReferral
    {
        get { return _ExternalReferral; }
        set { _ExternalReferral = value; }
    }

    public DateTime? ReferralDate
    {
        get { return _ReferralDate; }
        set { _ReferralDate = value; }
    }

    public string ImagePath
    {
        get { return _ImagePath; }
        set { _ImagePath = value; }
    }

    public string Notes
    {
        get { return _Notes; }
        set { _Notes = value; }
    }

    public string CommunicationBarriers
    {
        get { return _CommunicationBarriers; }
        set { _CommunicationBarriers = value; }
    }

    public string UserName
    {
        get { return _UserName; }
        set { _UserName = value; }
    }

    public string Password
    {
        get { return _Password; }
        set { _Password = value; }
    }

    public bool ActiveWebAccount
    {
        get { return _ActiveWebAccount; }
        set { _ActiveWebAccount = value; }
    }

    public bool IsActive
    {
        get { return _IsActive; }
        set { _IsActive = value; }
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
    
    
    
    public long CreatedById
    {
        get { return _CreatedById; }
        set { _CreatedById = value; }
    }

    public DateTime? CreatedDate
    {
        get { return _CreatedDate; }
        set { _CreatedDate = value; }
    }

    public long ModifiedById
    {
        get { return _ModifiedById; }
        set { _ModifiedById = value; }
    }

    public DateTime? ModifiedDate
    {
        get { return _ModifiedByDate; }
        set { _ModifiedByDate = value; }
    }

    public bool Deleted
    {
        get { return _Deleted; }
        set { _Deleted = value; }
    }


    //rizwan kharal start
    //28 sep 2017
    // created for update the  Demographic on demographic page

    public string uDateOfBirth { get; set; }
    public string uDisabilityDate { get; set; }
    public string uDeathDate { get; set; }
    public string uReferralDate { get; set; }

    //rizwan kharal End

    #endregion
}