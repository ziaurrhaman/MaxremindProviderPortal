using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Physicians
/// </summary>
public class Physicians
{
	public Physicians()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    #region " Private Members "

    private long _PhysicianId;
    private long _PracticeId;
    private string _FirstName;
    private string _MiddleName;
    private string _LastName;
    private char _Gender;
    private string _Title;
    private string _City;
    private string _State;
    private string _Zip;
    private string _StreetAddress;
    private string _Cell;
    private string _OtherPhone;
    private string _Email;
    private string _FaxNumber;
    private int _ServiceProviderQualififcationId;
    private string _LicenseNumber;
    private string _NPI;
    private string _ProviderNo;
    private string _LicenseExpiry;
    private string _CommunityCareNumber;
    private string _UPIN;
    private string _EternalReferral;
    private long _CreatedById;
    private DateTime _CreatedDate;
    private System.Nullable<DateTime> _ModifiedDate;
    private System.Nullable<int> _ModifiedById;
    private string _ImagePath;
    private bool _Active = true;
    private bool _Deleted = false;
    #endregion

    #region " Properties "

    public long PhysicianId
    {
        get { return _PhysicianId; }
        set { _PhysicianId = value; }
    }

    public long PracticeId
    {
        get { return _PracticeId; }
        set { _PracticeId = value; }
    }

    public string FirstName
    {
        get { return _FirstName; }
        set { _FirstName = value; }
    }

    public string MiddleName
    {
        get { return _MiddleName; }
        set { _MiddleName = value; }
    }

    public string LastName
    {
        get { return _LastName; }
        set { _LastName = value; }
    }
    public char Gender
    {
        get { return _Gender; }
        set { _Gender = value; }
    }
    public string Title
    {
        get { return _Title; }
        set { _Title = value; }
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

    public string StreetAddress
    {
        get { return _StreetAddress; }
        set { _StreetAddress = value; }
    }

    public string Cell
    {
        get { return _Cell; }
        set { _Cell = value; }
    }

    public string OtherPhone
    {
        get { return _OtherPhone; }
        set { _OtherPhone = value; }
    }

    public string Email
    {
        get { return _Email; }
        set { _Email = value; }
    }
    public string FaxNumber
    {
        get { return _FaxNumber; }
        set { _FaxNumber = value; }
    }
    public int ServiceProviderQualififcationId
    {
        get { return _ServiceProviderQualififcationId; }
        set { _ServiceProviderQualififcationId = value; }
    }

    public string LicenseNumber
    {
        get { return _LicenseNumber;  }
        set { _LicenseNumber = value; }
    }

    public string NPI
    {
        get { return _NPI; }
        set { _NPI = value; }
    }

    public string ProviderNo
    {
        get { return _ProviderNo; }
        set { _ProviderNo = value; }
    }
    public string LicenseExpiry
    {
        get { return _LicenseExpiry; }
        set { _LicenseExpiry = value; }
    }
    public string CommunityCareNumber
    {
        get { return _CommunityCareNumber; }
        set { _CommunityCareNumber = value; }
    }
    public string UPIN
    {
        get { return _UPIN; }
        set { _UPIN = value; }
    }
    public string EternalReferral
    {
        get { return _EternalReferral; }
        set { _EternalReferral = value; }
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


    public System.Nullable<DateTime> ModifiedDate
    {
        get { return _ModifiedDate; }
        set { _ModifiedDate = value; }
    }

    public System.Nullable<int> ModifiedById
    {
        get { return _ModifiedById; }
        set { _ModifiedById = value; }
    }
    public string ImagePath
    {
        get { return _ImagePath; }
        set { _ImagePath = value; }
    }
    public bool Active
    {
        get { return _Active; }
        set { _Active = value; }
    }

    public bool Deleted
    {
        get { return _Deleted; }
        set { _Deleted = value; }
    }

    #endregion
}