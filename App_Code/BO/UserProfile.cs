using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UserProfile
/// </summary>
public class UserProfile
{
	public UserProfile()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    #region " Private Members "

    private long _UserId;
    long _ServiceProviderId;

    /***PERSONAL INFORMATION***/
    string _Title = string.Empty;
    string _FirstName = string.Empty;
    string _LastName = string.Empty;
    string _MiddleName = string.Empty;
    string _Gender = string.Empty;
    
    
    /***GENERAL INFORMATION***/
    string _NPI = string.Empty;
    string _UPIN = string.Empty;
    string _LicenseNo = string.Empty;
    
    
    /***CONTACT INFORMATION***/
    string _PhoneNumber = string.Empty;
    string _Cell = string.Empty;
    string _OtherPhone = string.Empty;
    string _Fax = string.Empty;
    string _EmailAddress = string.Empty;
    
    
    /***ADDRESS INFORMATION***/
    string _StreetAddress = string.Empty;
    string _Zip = string.Empty;
    string _City = string.Empty;
    string _State = string.Empty;
    
    
    /***DRIVING LICENSE INFORMATION***/
    string _DrivingLicenseNo = string.Empty;
    string _LicenseState = string.Empty;
    DateTime? _LicenseIssuDate;
    DateTime? _LicenseExpiryDate;
    
    
    /***DIGITAL SIGNATURE***/
    string _PINCode = string.Empty;
    string _PINFilePath = string.Empty;
    string _OldPINCode = string.Empty;
    
    
    
    /***WEB ACCOUNT***/
    string _Password = string.Empty;
    string _OldPassword = string.Empty;
    
    
    long? _ModifiedById;
    DateTime? _ModifiedDate;

    #endregion

    #region " Properties "

    public long UserId
    {
        get { return _UserId; }
        set { _UserId = value; }
    }

    public long ServiceProviderId
    {
        get { return _ServiceProviderId; }
        set { _ServiceProviderId = value; }
    }


    /***PERSONAL INFORMATION***/
    public string Title
    {
        get { return _Title; }
        set { _Title = value; }
    }

    public string LastName
    {
        get { return _LastName; }
        set { _LastName = value; }
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

    public string Gender
    {
        get { return _Gender; }
        set { _Gender = value; }
    }


    /***GENERAL INFORMATION***/
    public string NPI
    {
        get { return _NPI; }
        set { _NPI = value; }
    }

    public string UPIN
    {
        get { return _UPIN; }
        set { _UPIN = value; }
    }

    public string LicenseNo
    {
        get { return _LicenseNo; }
        set { _LicenseNo = value; }
    }


    /***CONTACT INFORMATION***/
    public string PhoneNumber
    {
        get { return _PhoneNumber; }
        set { _PhoneNumber = value; }
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

    public string Fax
    {
        get { return _Fax; }
        set { _Fax = value; }
    }

    public string EmailAddress
    {
        get { return _EmailAddress; }
        set { _EmailAddress = value; }
    }


    /***ADDRESS INFORMATION***/
    public string StreetAddress
    {
        get { return _StreetAddress; }
        set { _StreetAddress = value; }
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


    /***DRIVING LICENSE INFORMATION***/
    public string DrivingLicenseNo
    {
        get { return _DrivingLicenseNo; }
        set { _DrivingLicenseNo = value; }
    }

    public string LicenseState
    {
        get { return _LicenseState; }
        set { _LicenseState = value; }
    }

    public DateTime? LicenseIssuDate
    {
        get { return _LicenseIssuDate; }
        set { _LicenseIssuDate = value; }
    }

    public DateTime? LicenseExpiryDate
    {
        get { return _LicenseExpiryDate; }
        set { _LicenseExpiryDate = value; }
    }

    /***DIGITAL SIGNATURE***/
    public string PINCode
    {
        get { return _PINCode; }
        set { _PINCode = value; }
    }

    public string PINFilePath
    {
        get { return _PINFilePath; }
        set { _PINFilePath = value; }
    }

    public string OldPINCode
    {
        get { return _OldPINCode; }
        set { _OldPINCode = value; }
    }



    public string Password
    {
        get { return _Password; }
        set { _Password = value; }
    }

    public string OldPassword
    {
        get { return _OldPassword; }
        set { _OldPassword = value; }
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

    #endregion
}