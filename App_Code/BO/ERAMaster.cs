using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ERAMaster
/// </summary>
public class ERAMaster
{
	public ERAMaster()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    
    #region " Private Members "
    
    long _ERAMasterId;
    
    
    long _PracticeId;
    string _TransactionHandlingCode;
    decimal _PaymentAmount;
    string _PaymentMethodCode;
    string _SenderDFIIdentifier;
    string _SenderBankAccountNumber;
    string _PayerIdentifier;
    string _SupplementalCode;
    string _ReceiverDFINumber;
    string _ReceiverAccountQualifier;
    string _ReceiverAccountNumber;
    DateTime? _CheckIssueDate;
    string _CheckNumber;
    string _OrganizationId;
    string _ReceiverIdentifier;
    DateTime? _ERAGenerationDate;
    string _PayerName;
    string _PayerAddress;
    string _PayerCity;
    string _PayerState;
    string _ZipCode;
    string _PayerContactPerson;
    string _CommunicationNumberQualifier1;
    string _CommunicationNumber1;
    string _CommunicationNumberQualifier2;
    string _CommunicationNumber2;
    string _PayeeName;
    string _PayeeCodeQualifier;
    string _PayeeCode;
    string _PayeeAddress;
    string _PayeeCity;
    string _PayeeState;
    string _PayeeZip;
    private string _PaymentType;
    private double _PaymentPosted;
    private string _Status;
    private double _ClaimLevelPayments;

    private long? _PatientId;

    private string _PayerID837 = string.Empty;

    private long _CreatedById;
    private DateTime _CreatedDate;
    private long _ModifiedById;
    private DateTime _ModifiedDate;
    private bool _Deleted = false;
    private string _PaymentFor = null;
    
    #endregion
    
    #region " Properties "
    
    public long ERAMasterId
    {
        get { return _ERAMasterId; }
        set { _ERAMasterId = value; }
    }
    
    public long PracticeId
    {
        get { return _PracticeId; }
        set { _PracticeId = value; }
    }
    
    public string TransactionHandlingCode
    {
        get { return _TransactionHandlingCode; }
        set { _TransactionHandlingCode = value; }
    }
    
    public decimal PaymentAmount
    {
        get { return _PaymentAmount; }
        set { _PaymentAmount = value; }
    }
    
    public string PaymentMethodCode
    {
        get { return _PaymentMethodCode; }
        set { _PaymentMethodCode = value; }
    }
    
    public string SenderDFIIdentifier
    {
        get { return _SenderDFIIdentifier; }
        set { _SenderDFIIdentifier = value; }
    }
    
    public string SenderBankAccountNumber
    {
        get { return _SenderBankAccountNumber; }
        set { _SenderBankAccountNumber = value; }
    }
    
    public string PayerIdentifier
    {
        get { return _PayerIdentifier; }
        set { _PayerIdentifier = value; }
    }
    
    public string SupplementalCode
    {
        get { return _SupplementalCode; }
        set { _SupplementalCode = value; }
    }
    
    public string ReceiverDFINumber
    {
        get { return _ReceiverDFINumber; }
        set { _ReceiverDFINumber = value; }
    }

    public string ReceiverAccountQualifier
    {
        get { return _ReceiverAccountQualifier; }
        set { _ReceiverAccountQualifier = value; }
    }

    public string ReceiverAccountNumber
    {
        get { return _ReceiverAccountNumber; }
        set { _ReceiverAccountNumber = value; }
    }

    public DateTime? CheckIssueDate
    {
        get { return _CheckIssueDate; }
        set { _CheckIssueDate = value; }
    }

    public string CheckNumber
    {
        get { return _CheckNumber; }
        set { _CheckNumber = value; }
    }

    public string OrganizationId
    {
        get { return _OrganizationId; }
        set { _OrganizationId = value; }
    }

    public string ReceiverIdentifier
    {
        get { return _ReceiverIdentifier; }
        set { _ReceiverIdentifier = value; }
    }

    public DateTime? ERAGenerationDate
    {
        get { return _ERAGenerationDate; }
        set { _ERAGenerationDate = value; }
    }

    public string PayerName
    {
        get { return _PayerName; }
        set { _PayerName = value; }
    }

    public string PayerAddress
    {
        get { return _PayerAddress; }
        set { _PayerAddress = value; }
    }

    public string PayerCity
    {
        get { return _PayerCity; }
        set { _PayerCity = value; }
    }

    public string PayerState
    {
        get { return _PayerState; }
        set { _PayerState = value; }
    }

    public string ZipCode
    {
        get { return _ZipCode; }
        set { _ZipCode = value; }
    }

    public string PayerContactPerson
    {
        get { return _PayerContactPerson; }
        set { _PayerContactPerson = value; }
    }

    public string CommunicationNumberQualifier1
    {
        get { return _CommunicationNumberQualifier1; }
        set { _CommunicationNumberQualifier1 = value; }
    }

    public string CommunicationNumber1
    {
        get { return _CommunicationNumber1; }
        set { _CommunicationNumber1 = value; }
    }

    public string CommunicationNumberQualifier2
    {
        get { return _CommunicationNumberQualifier2; }
        set { _CommunicationNumberQualifier2 = value; }
    }

    public string CommunicationNumber2
    {
        get { return _CommunicationNumber2; }
        set { _CommunicationNumber2 = value; }
    }

    public string PayeeName
    {
        get { return _PayeeName; }
        set { _PayeeName = value; }
    }

    public string PayeeCodeQualifier
    {
        get { return _PayeeCodeQualifier; }
        set { _PayeeCodeQualifier = value; }
    }

    public string PayeeCode
    {
        get { return _PayeeCode; }
        set { _PayeeCode = value; }
    }

    public string PayeeAddress
    {
        get { return _PayeeAddress; }
        set { _PayeeAddress = value; }
    }

    public string PayeeCity
    {
        get { return _PayeeCity; }
        set { _PayeeCity = value; }
    }

    public string PayeeState
    {
        get { return _PayeeState; }
        set { _PayeeState = value; }
    }

    public string PayeeZip
    {
        get { return _PayeeZip; }
        set { _PayeeZip = value; }
    }

    public  string PaymentType
    {
        get { return _PaymentType; }
        set { _PaymentType = value; }
    }

    public  double PaymentPosted
    {
        get { return _PaymentPosted; }
        set { _PaymentPosted = value; }
    }

    public  string Status
    {
        get { return _Status; }
        set { _Status = value; }
    }

    public  double ClaimLevelPayments
    {
        get { return _ClaimLevelPayments; }
        set { _ClaimLevelPayments = value; }
    }
    
    public long? PatientId
    {
        get { return _PatientId; }
        set { _PatientId = value; }
    }

    public string PayerID837
    {
        get { return _PayerID837; }
        set { _PayerID837 = value; }
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
    public string PaymentFor
    {
        get { return _PaymentFor; }
        set { _PaymentFor = value; }
    }

    #endregion
}