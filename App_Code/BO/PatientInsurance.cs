using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PatientInsurance
/// </summary>
public class PatientInsurance
{
	public PatientInsurance()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    #region " Private Members "

    long _PatientInsuranceId;
    long _PatientId;
    long _InsuranceId;
    string _PriSecOthType ;
    string _PolicyNumber ;
    string _GroupNumber;
    string _GroupName;
    string _Relationship;
    DateTime? _EffectiveDate ;
    DateTime? _TerminationDate;
    int? _SubscriberId;
    int? _CoPay;
    string _CoPayType;
    int? _CoInsurance;
    string _CoInsuranceType;
    int? _Deductable;
    string _DeductableType;
    string _EligibilityStatus;

    string _InsuranceCardFrontFilePath;
    string _InsuranceCardBackFilePath;

    long _CreatedById;
    DateTime _CreatedDate;
    long _ModifiedById;
    DateTime _ModifiedDate;
    bool _Deleted = false;

    #endregion

    #region " Properties "

    public long PatientInsuranceId
    {
        get { return _PatientInsuranceId; }
        set { _PatientInsuranceId = value; }
    }

    public long PatientId
    {
        get { return _PatientId; }
        set { _PatientId = value; }
    }

    public long InsuranceId
    {
        get { return _InsuranceId; }
        set { _InsuranceId = value; }
    }

    public string PriSecOthType
    {
        get { return _PriSecOthType; }
        set { _PriSecOthType = value; }
    }

    public string PolicyNumber
    {
        get { return _PolicyNumber; }
        set { _PolicyNumber = value; }
    }

    public string GroupNumber
    {
        get { return _GroupNumber; }
        set { _GroupNumber = value; }
    }

    public string GroupName
    {
        get { return _GroupName; }
        set { _GroupName = value; }
    }

    public string Relationship
    {
        get { return _Relationship; }
        set { _Relationship = value; }
    }

    public DateTime? EffectiveDate
    {
        get { return _EffectiveDate; }
        set { _EffectiveDate = value; }
    }

    public DateTime? TerminationDate
    {
        get { return _TerminationDate; }
        set { _TerminationDate = value; }
    }

    public int? SubscriberId
    {
        get { return _SubscriberId; }
        set { _SubscriberId = value; }
    }

    public int? CoPay
    {
        get { return _CoPay; }
        set { _CoPay = value; }
    }

    public string CoPayType
    {
        get { return _CoPayType; }
        set { _CoPayType = value; }
    }

    public int? CoInsurance
    {
        get { return _CoInsurance; }
        set { _CoInsurance = value; }
    }

    public string CoInsuranceType
    {
        get { return _CoInsuranceType; }
        set { _CoInsuranceType = value; }
    }

    public int? Deductable
    {
        get { return _Deductable; }
        set { _Deductable = value; }
    }
    
    public string DeductableType
    {
        get { return _DeductableType; }
        set { _DeductableType = value; }
    }
    
    public string EligibilityStatus
    {
        get { return _EligibilityStatus; }
        set { _EligibilityStatus = value; }
    }

    public string InsuranceCardFrontFilePath
    {
        get { return _InsuranceCardFrontFilePath; }
        set { _InsuranceCardFrontFilePath = value; }
    }

    public string InsuranceCardBackFilePath
    {
        get { return _InsuranceCardBackFilePath; }
        set { _InsuranceCardBackFilePath = value; }
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