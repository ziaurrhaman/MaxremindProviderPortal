using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ReferringPhysician
/// </summary>
public class ReferringPhysician
{
	public ReferringPhysician()
	{
		//
		// TODO: Add constructor logic here
		//
    }
    #region " Private Members "

    Int64 _ReferringPhysicianId;
    string _FirstName ;
    string _MiddleName ;
    string _LastName ;
    string _Gender;
    string _UPin ;
    string _NPI ;
    string _LicenseNo ;
    DateTime? _DateOfBirth;
    DateTime? _LicenseExpiration;
    string _CommunityCareNo ;
    string _ContactPerson ;
    string _Address ;
    string _Zip ;
    string _City ;
    string _State ;
    string _Phone ;
    string _Cell;
    string _Fax ;
    string _Email ;
    bool _ExternalReferral = false;
    string _Comments ;
    string _TaxId ;
    long _CreatedById;
    DateTime _CreatedDate;
    long _ModifiedById;
    DateTime _ModifiedDate;
    bool _InActive = false;

    bool _Deleted = false;
    #endregion

    #region " Properties "

    public Int64 ReferringPhysicianId
    {
        get { return _ReferringPhysicianId; }
        set { _ReferringPhysicianId = value; }
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

    public string UPin
    {
        get { return _UPin; }
        set { _UPin = value; }
    }

    public string NPI
    {
        get { return _NPI; }
        set { _NPI = value; }
    }

    public string LicenseNo
    {
        get { return _LicenseNo; }
        set { _LicenseNo = value; }
    }

    public DateTime? DateOfBirth
    {
        get { return _DateOfBirth; }
        set { _DateOfBirth = value; }
    }

    public string Gender
    {
        get { return _Gender; }
        set { _Gender = value; }
    }

    public string Cell
    {
        get { return _Cell; }
        set { _Cell = value; }
    }
    public DateTime? LicenseExpiration
    {
        get { return _LicenseExpiration; }
        set { _LicenseExpiration = value; }
    }

    public string CommunityCareNo
    {
        get { return _CommunityCareNo; }
        set { _CommunityCareNo = value; }
    }

    public string ContactPerson
    {
        get { return _ContactPerson; }
        set { _ContactPerson = value; }
    }

    public string Address
    {
        get { return _Address; }
        set { _Address = value; }
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

    public string Phone
    {
        get { return _Phone; }
        set { _Phone = value; }
    }

    public string Fax
    {
        get { return _Fax; }
        set { _Fax = value; }
    }

    public string Email
    {
        get { return _Email; }
        set { _Email = value; }
    }

    public bool ExternalReferral
    {
        get { return _ExternalReferral; }
        set { _ExternalReferral = value; }
    }

    public string Comments
    {
        get { return _Comments; }
        set { _Comments = value; }
    }

    public string TaxId
    {
        get { return _TaxId; }
        set { _TaxId = value; }
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