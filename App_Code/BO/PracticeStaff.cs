using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PracticeStaff
/// </summary>
public class PracticeStaff
{
    public PracticeStaff()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    #region " Private Members "

    long _PracticeStaffId;
    long _PracticeId;
    private int _PracticeLocationsId;
    string _StaffFirstName = string.Empty;
    string _StaffLastName = string.Empty;
    string _StaffMiddleName = string.Empty;
    string _StaffTitle = string.Empty;
    DateTime? _StaffDateOfBirth;
    string _StaffGender = string.Empty;
    string _StaffPhoto = string.Empty;
    string _StaffNPI = string.Empty;
    string _StaffUPIN = string.Empty;
    string _StaffTaxID = string.Empty;
    string _StaffTaxonomyId = string.Empty;
    string _StaffType = string.Empty;
    string _StaffEmailAddress = string.Empty;
    string _StaffHomePhone = string.Empty;
    string _StaffCellPhone = string.Empty;
    string _StaffFax = string.Empty;
    string _StaffAddress = string.Empty;
    string _StaffCity = string.Empty;
    string _StaffState = string.Empty;
    string _StaffZip = string.Empty;
    private string _UserName;
    private string _Password;
    long _CreatedById;
    DateTime _CreatedDate;
    long? _ModifiedById;
    DateTime? _ModifiedDate;
    bool _Deleted = false;

    #endregion

    #region " Properties "

    public long PracticeStaffId
    {
        get { return _PracticeStaffId; }
        set { _PracticeStaffId = value; }
    }

    public long PracticeId
    {
        get { return _PracticeId; }
        set { _PracticeId = value; }
    }

    public int PracticeLocationsId
    {
        get { return _PracticeLocationsId; }
        set { _PracticeLocationsId = value; }
    }

    public string StaffFirstName
    {
        get { return _StaffFirstName; }
        set { _StaffFirstName = value; }
    }

    public string StaffLastName
    {
        get { return _StaffLastName; }
        set { _StaffLastName = value; }
    }

    public string StaffMiddleName
    {
        get { return _StaffMiddleName; }
        set { _StaffMiddleName = value; }
    }

    public string StaffTitle
    {
        get { return _StaffTitle; }
        set { _StaffTitle = value; }
    }

    public DateTime? StaffDateOfBirth
    {
        get { return _StaffDateOfBirth; }
        set { _StaffDateOfBirth = value; }
    }

    public string StaffGender
    {
        get { return _StaffGender; }
        set { _StaffGender = value; }
    }

    public string StaffPhoto
    {
        get { return _StaffPhoto; }
        set { _StaffPhoto = value; }
    }

    public string StaffNPI
    {
        get { return _StaffNPI; }
        set { _StaffNPI = value; }
    }

    public string StaffUPIN
    {
        get { return _StaffUPIN; }
        set { _StaffUPIN = value; }
    }

    public string StaffTaxID
    {
        get { return _StaffTaxID; }
        set { _StaffTaxID = value; }
    }

    public string StaffTaxonomyId
    {
        get { return _StaffTaxonomyId; }
        set { _StaffTaxonomyId = value; }
    }

    public string StaffType
    {
        get { return _StaffType; }
        set { _StaffType = value; }
    }

    public string StaffEmailAddress
    {
        get { return _StaffEmailAddress; }
        set { _StaffEmailAddress = value; }
    }

    public string StaffHomePhone
    {
        get { return _StaffHomePhone; }
        set { _StaffHomePhone = value; }
    }

    public string StaffCellPhone
    {
        get { return _StaffCellPhone; }
        set { _StaffCellPhone = value; }
    }

    public string StaffAddress
    {
        get { return _StaffAddress; }
        set { _StaffAddress = value; }
    }

    public string StaffFax
    {
        get { return _StaffFax; }
        set { _StaffFax = value; }
    }

    public string StaffCity
    {
        get { return _StaffCity; }
        set { _StaffCity = value; }
    }

    public string StaffState
    {
        get { return _StaffState; }
        set { _StaffState = value; }
    }

    public string StaffZip
    {
        get { return _StaffZip; }
        set { _StaffZip = value; }
    }

    public string UserName
    {
        get { return _UserName; }
        set { _UserName = value; }
    }

    public string Password
    {
        get { return _Password; }
        set { _Password = value; }
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