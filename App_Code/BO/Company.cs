using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Company
/// </summary>
public class Company
{
	public Company()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    #region " Private Members "

    Int64 _CompanyId;
    string _CompanyName;
    string _Address;
    string _City;
    string _State;
    string _Zip;
    int _NPI;
    string _PhoneNumber1;
    string _PhoneNumber2;
    string _PhoneNumber3;
    string _EmailAddress1;
    string _EmailAddress2;
    string _FaxNumber;
    string _DEANumber;
    string _StateRXId;
    int _TaxID;
    string _FeeSchedule;
    string _MedicaidNumber;
    string _MedicareNumber;
    string _StateLicense;
    string _ContactPersonName;
    Int64 _CreatedById;
    DateTime _CreatedDate;
    Int64 _ModifiedById;
    DateTime _ModifiedDate;

    bool _Deleted = false;
    #endregion

    #region " Properties "

    public Int64 CompanyId
    {
        get { return _CompanyId; }
        set { _CompanyId = value; }
    }

    public string CompanyName
    {
        get { return _CompanyName; }
        set { _CompanyName = value; }
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

    public int NPI
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

    public int TaxID
    {
        get { return _TaxID; }
        set { _TaxID = value; }
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

    public Int64 CreatedById
    {
        get { return _CreatedById; }
        set { _CreatedById = value; }
    }

    public DateTime CreatedDate
    {
        get { return _CreatedDate; }
        set { _CreatedDate = value; }
    }

    public Int64 ModifiedById
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