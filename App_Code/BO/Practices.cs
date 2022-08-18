using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Agencies
/// </summary>
public class Practices
{
    public Practices()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    #region " Private Members "

    long _PracticeId;
    string _PracticeName = string.Empty;
    string _UPIN = string.Empty;
    string _PracticeType = string.Empty;
    string _Address = string.Empty;
    string _City = string.Empty;
    string _State = string.Empty;
    string _Zip = string.Empty;
    string _PracticeExt = string.Empty;
    int? _NPI;
    string _PhoneNumber1 = string.Empty;
    string _PhoneNumber2 = string.Empty;
    string _PhoneNumber3 = string.Empty;
    string _EmailAddress1 = string.Empty;
    string _EmailAddress2 = string.Empty;
    string _FaxNumber = string.Empty;
    string _DEANumber = string.Empty;
    string _StateRXId = string.Empty;
    int? _TaxID;
    string _TaxonomyCode = string.Empty;
    string _ContractType = string.Empty;
    string _FeeSchedule = string.Empty;
    string _MedicaidNumber = string.Empty;
    string _MedicareNumber = string.Empty;
    string _StateLicense = string.Empty;
    string _ContactPersonName = string.Empty;
    string _ContactPersonPhone = string.Empty;
    long? _CreatedById;
    DateTime? _CreatedDate;
    long? _ModifiedById;
    DateTime? _ModifiedDate;

    bool _Deleted = false;
    #endregion

    #region " Properties "

    public long PracticeId
    {
        get { return _PracticeId; }
        set { _PracticeId = value; }
    }

    public string PracticeName
    {
        get { return _PracticeName; }
        set { _PracticeName = value; }
    }

    public string UPIN
    {
        get { return _UPIN; }
        set { _UPIN = value; }
    }

    public string PracticeType
    {
        get { return _PracticeType; }
        set { _PracticeType = value; }
    }

    public string Address
    {
        get { return _Address; }
        set { _Address = value; }
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
    
    public string Zip
    {
        get { return _Zip; }
        set { _Zip = value; }
    }
    
    public string PracticeExt
    {
        get { return _PracticeExt; }
        set { _PracticeExt = value; }
    }

    public int? NPI
    {
        get { return _NPI; }
        set { _NPI = value; }
    }

    public string PhoneNumber1
    {
        get { return _PhoneNumber1; }
        set { _PhoneNumber1 = value; }
    }

    public string PhoneNumber2
    {
        get { return _PhoneNumber2; }
        set { _PhoneNumber2 = value; }
    }

    public string PhoneNumber3
    {
        get { return _PhoneNumber3; }
        set { _PhoneNumber3 = value; }
    }

    public string EmailAddress1
    {
        get { return _EmailAddress1; }
        set { _EmailAddress1 = value; }
    }

    public string EmailAddress2
    {
        get { return _EmailAddress2; }
        set { _EmailAddress2 = value; }
    }

    public string FaxNumber
    {
        get { return _FaxNumber; }
        set { _FaxNumber = value; }
    }

    public string DEANumber
    {
        get { return _DEANumber; }
        set { _DEANumber = value; }
    }

    public string StateRXId
    {
        get { return _StateRXId; }
        set { _StateRXId = value; }
    }

    public int? TaxID
    {
        get { return _TaxID; }
        set { _TaxID = value; }
    }
    
    public string TaxonomyCode
    {
        get { return _TaxonomyCode; }
        set { _TaxonomyCode = value; }
    }

    public string ContractType
    {
        get { return _ContractType; }
        set { _ContractType = value; }
    }
    
    public string FeeSchedule
    {
        get { return _FeeSchedule; }
        set { _FeeSchedule = value; }
    }

    public string MedicaidNumber
    {
        get { return _MedicaidNumber; }
        set { _MedicaidNumber = value; }
    }

    public string MedicareNumber
    {
        get { return _MedicareNumber; }
        set { _MedicareNumber = value; }
    }

    public string StateLicense
    {
        get { return _StateLicense; }
        set { _StateLicense = value; }
    }
    
    public string ContactPersonName
    {
        get { return _ContactPersonName; }
        set { _ContactPersonName = value; }
    }

    public string ContactPersonPhone
    {
        get { return _ContactPersonPhone; }
        set { _ContactPersonPhone = value; }
    }

    public long? CreatedById
    {
        get { return _CreatedById; }
        set { _CreatedById = value; }
    }

    public DateTime? CreatedDate
    {
        get { return _CreatedDate; }
        set { _CreatedDate = value; }
    }

    public long? ModifiedById
    {
        get { return _ModifiedById; }
        set { _ModifiedById = value; }
    }

    public DateTime? ModifiedDate
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