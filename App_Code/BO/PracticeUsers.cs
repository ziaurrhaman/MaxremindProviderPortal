using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PracticeUsers
/// </summary>
public class PracticeUsers
{
    public PracticeUsers()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    private long _UserId;
    private string _UserName;
    private string _Password;
    private string _FirstName;
    private string _LastName;
    private string _MiddleName;
    private string _UserType;
    private string _EmailAddress;
    private string _PhoneNumber;
    private long _ServiceProviderId;
    private long _PracticeId;
    private int _PracticeLocationsId;
    private bool _IsActive;
    private string _ProfilePicturePath;
    private DateTime _CreatedDate;
    private long _CreatedById;
    private System.Nullable<DateTime> _ModifiedDate;
    private long _ModifiedById;
    private bool _Deleted = false;
    private string _StaffShift;
    private bool _ProviderPortalUsers = false;
    public long UserId
    {
        get { return _UserId; }
        set { _UserId = value; }
    }

    public string UserName
    {
        get
        {
            return _UserName;
        }
        set
        {
            _UserName = value;
        }
    }

    public string Password
    {
        get
        {
            return _Password;
        }
        set
        {
            _Password = value;
        }
    }

    public string FirstName
    {
        get
        {
            return _FirstName;
        }
        set
        {
            _FirstName = value;
        }
    }

    public string LastName
    {
        get
        {
            return _LastName;
        }
        set
        {
            _LastName = value;
        }
    }

    public string MiddleName
    {
        get
        {
            return _MiddleName;
        }
        set
        {
            _MiddleName = value;
        }
    }

    public string UserType
    {
        get
        {
            return _UserType;
        }
        set
        {
            _UserType = value;
        }
    }

    public string EmailAddress
    {
        get
        {
            return _EmailAddress;
        }
        set
        {
            _EmailAddress = value;
        }
    }

    public string PhoneNumber
    {
        get
        {
            return _PhoneNumber;
        }
        set
        {
            _PhoneNumber = value;
        }
    }

    public long ServiceProviderId
    {
        get
        {
            return _ServiceProviderId;
        }
        set
        {
            _ServiceProviderId = value;
        }
    }

    public long PracticeId
    {
        get
        {
            return _PracticeId;
        }
        set
        {
            _PracticeId = value;
        }
    }

    public int PracticeLocationsId
    {
        get
        {
            return _PracticeLocationsId;
        }
        set
        {
            _PracticeLocationsId = value;
        }
    }

    public bool IsActive
    {
        get
        {
            return _IsActive;
        }
        set
        {
            _IsActive = value;
        }
    }

    public string ProfilePicturePath
    {
        get
        {
            return _ProfilePicturePath;
        }
        set
        {
            _ProfilePicturePath = value;
        }
    }

    public DateTime CreatedDate
    {
        get { return _CreatedDate; }
        set { _CreatedDate = value; }
    }

    public long CreatedById
    {
        get { return _CreatedById; }
        set { _CreatedById = value; }
    }

    public System.Nullable<DateTime> ModifiedDate
    {
        get { return _ModifiedDate; }
        set { _ModifiedDate = value; }
    }

    public long ModifiedById
    {
        get { return _ModifiedById; }
        set { _ModifiedById = value; }
    }

    public bool Deleted
    {
        get { return _Deleted; }
        set { _Deleted = value; }
    }
    public string StaffShift
    {
        get { return _StaffShift; }
        set { _StaffShift = value; }
    }
    public bool ProviderPortalUsers
    {
        get { return _ProviderPortalUsers; }
        set { _ProviderPortalUsers = value; }
    }
}