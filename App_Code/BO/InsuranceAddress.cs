using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for InsuranceAddress
/// </summary>
public class InsuranceAddress
{
	public InsuranceAddress()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    #region " Private Members "

    long _InsuranceAddressId;
    long _InsuranceId;
    string _Department = string.Empty;
    string _Address = string.Empty;
    string _City = string.Empty;
    string _State = string.Empty;
    string _Zip = string.Empty;
    string _ContactPerson = string.Empty;
    string _Email = string.Empty;
    string _Fax = string.Empty;
    string _Phone1 = string.Empty;
    string _Phone2 = string.Empty;
    string _Phone3 = string.Empty;
    long _CraetedById;
    DateTime _CreatedDate;
    long _ModifiedById;
    DateTime _ModifiedDate;
    bool _InAcative = false;

    bool _Deleted = false;
    #endregion

    #region " Properties "

    public long InsuranceAddressId
    {
        get { return _InsuranceAddressId; }
        set { _InsuranceAddressId = value; }
    }

    public long InsuranceId
    {
        get { return _InsuranceId; }
        set { _InsuranceId = value; }

    }

    public string Department
    {
        get { return _Department; }
        set { _Department = value; }
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

    public string ContactPerson
    {
        get { return _ContactPerson; }
        set { _ContactPerson = value; }
    }

    public string Email
    {
        get { return _Email; }
        set { _Email = value; }
    }

    public string Fax
    {
        get { return _Fax; }
        set { _Fax = value; }
    }

    public string Phone1
    {
        get { return _Phone1; }
        set { _Phone1 = value; }
    }

    public string Phone2
    {
        get { return _Phone2; }
        set { _Phone2 = value; }
    }

    public string Phone3
    {
        get { return _Phone3; }
        set { _Phone3 = value; }
    }

    public long CraetedById
    {
        get { return _CraetedById; }
        set { _CraetedById = value; }
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

    public bool InAcative
    {
        get { return _InAcative; }
        set { _InAcative = value; }
    }

    public bool Deleted
    {
        get { return _Deleted; }
        set { _Deleted = value; }
    }

    #endregion
}