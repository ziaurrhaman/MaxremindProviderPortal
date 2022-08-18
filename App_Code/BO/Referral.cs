using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Referral
/// </summary>
public class Referral
{
	public Referral()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    #region " Private Members "

    Int64 _ReferralId;
    string _FirstName;
    string _MiddleName;
    string _LastName;
    string _Phone;
    string _Cell;
    string _Email;
    string _City;
    string _State;
    string _Zip;
    string _TaxId;
    string _NPI;
    bool _ReferralType = false;
    long _CreatedById;
    DateTime _CreatedDate;
    int _ModifiedId;
    DateTime _ModifiedDate;
    bool _InActive = false;

    bool _Deleted = false;
    #endregion

    #region " Properties "

    public Int64 ReferralId
    {
        get { return _ReferralId; }
        set { _ReferralId = value; }
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

    public string Phone
    {
        get { return _Phone; }
        set { _Phone = value; }
    }

    public string Cell
    {
        get { return _Cell; }
        set { _Cell = value; }
    }

    public string Email
    {
        get { return _Email; }
        set { _Email = value; }
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

    public string TaxId
    {
        get { return _TaxId; }
        set { _TaxId = value; }
    }

    public string NPI
    {
        get { return _NPI; }
        set { _NPI = value; }
    }

    public bool ReferralType
    {
        get { return _ReferralType; }
        set { _ReferralType = value; }
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

    public int ModifiedId
    {
        get { return _ModifiedId; }
        set { _ModifiedId = value; }
    }

    public DateTime ModifiedDate
    {
        get { return _ModifiedDate; }
        set { _ModifiedDate = value; }
    }

    public bool InActive
    {
        get { return _InActive; }
        set { _InActive = value; }
    }

    public bool Deleted
    {
        get { return _Deleted; }
        set { _Deleted = value; }
    }

    #endregion
}