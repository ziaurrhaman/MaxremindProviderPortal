using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PracticeLocations
/// </summary>
public class PracticeLocations
{
	public PracticeLocations()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    
    #region " Private Members "
    
    private int _PracticeLocationsId;
    long _PracticeId;
    string _Name = string.Empty;
    string _City = string.Empty;
    string _StateCode = string.Empty;
    string _Zip = string.Empty;
    string _Address = string.Empty;
    string _PrimaryContact = string.Empty;
    string _SecondaryContact = string.Empty;
    string _OtherContact = string.Empty;
    string _EmailAddress = string.Empty;
    string _LicenseNo = string.Empty;
    string _TaxId = string.Empty;
    string _NPI = string.Empty;
    private Nullable<int> _ConcurrentPatients;
    string _FaxNo = string.Empty;
    string _ContactPerson = string.Empty;
    private Nullable<long> _CreatedById;
    private DateTime _CreatedDate;
    long? _ModifiedById;
    private Nullable<DateTime> _ModifiedDate;
    bool _Deleted = false;
    private Nullable<int> _Bussiness_start_Time;
    
    private Nullable<int> _Bussiness_end_Time;
    #endregion

    #region " Properties "
    
    public int PracticeLocationsId
    {
        get { return _PracticeLocationsId; }
        set { _PracticeLocationsId = value; }
    }

    public long PracticeId
    {
        get { return _PracticeId; }
        set { _PracticeId = value; }
    }

    public string Name
    {
        get { return _Name; }
        set { _Name = value; }
    }

    public string City
    {
        get { return _City; }
        set { _City = value; }
    }

    public string StateCode
    {
        get { return _StateCode; }
        set { _StateCode = value; }
    }

    public string Zip
    {
        get { return _Zip; }
        set { _Zip = value; }
    }

    public string Address
    {
        get { return _Address; }
        set { _Address = value; }
    }

    public string PrimaryContact
    {
        get { return _PrimaryContact; }
        set { _PrimaryContact = value; }
    }

    public string SecondaryContact
    {
        get { return _SecondaryContact; }
        set { _SecondaryContact = value; }
    }

    public string OtherContact
    {
        get { return _OtherContact; }
        set { _OtherContact = value; }
    }

    public string EmailAddress
    {
        get { return _EmailAddress; }
        set { _EmailAddress = value; }
    }

    public string LicenseNo
    {
        get { return _LicenseNo; }
        set { _LicenseNo = value; }
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

    public Nullable<int> ConcurrentPatients
    {
        get { return _ConcurrentPatients; }
        set { _ConcurrentPatients = value; }
    }
    
    public string FaxNo
    {
        get { return _FaxNo; }
        set { _FaxNo = value; }
    }

    public string ContactPerson
    {
        get { return _ContactPerson; }
        set { _ContactPerson = value; }
    }

    public Nullable<long> CreatedById
    {
        get { return _CreatedById; }
        set { _CreatedById = value; }
    }

    public DateTime CreatedDate
    {
        get { return _CreatedDate; }
        set { _CreatedDate = value; }
    }

    public long? ModifiedById
    {
        get { return _ModifiedById; }
        set { _ModifiedById = value; }
    }

    public Nullable<DateTime> ModifiedDate
    {
        get { return _ModifiedDate; }
        set { _ModifiedDate = value; }
    }

    public bool Deleted
    {
        get { return _Deleted; }
        set { _Deleted = value; }
    }

    public Nullable<int> Bussiness_start_Time
    {
        get { return _Bussiness_start_Time; }
        set { _Bussiness_start_Time = value; }
    }

    public Nullable<int> Bussiness_end_Time
    {
        get { return _Bussiness_end_Time; }
        set { _Bussiness_end_Time = value; }
    }

    #endregion
}