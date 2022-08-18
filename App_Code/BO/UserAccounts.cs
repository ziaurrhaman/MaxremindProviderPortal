using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PracticeUsers
/// </summary>
public class UserAccounts
{
    public UserAccounts()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    
    private long _UserAccountsId;
    private string _UserType;
    private string _UserName;
    private string _Password;
    private string _EmailAddress;
    private string _FirstName;
    private string _LastName;
    private string _MiddleName;
    private string _Gender;
    private DateTime _DateOfBirth;
    private string _ProfilePicturePath;
    private string _City;
    private string _State;
    private string _Zip;
    private string _PhoneNumber;
    private string _Address;
    private long _CreatedById;
    private DateTime _CreatedDate;
    private System.Nullable<int> _ModifiedById;
    private System.Nullable<DateTime> _ModifiedDate;
    
    private bool _IsActive = true;
    private bool _Deleted = false;
    
    public long UserAccountsId
    {
        get
        {
            return _UserAccountsId;
        }
        set
        {
            _UserAccountsId = value;
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
    
    public string Gender
    {
        get
        {
            return _Gender;
        }
        set
        {
            _Gender = value;
        }
    }
    
    public DateTime DateOfBirth
    {
        get { return _DateOfBirth; }
        set { _DateOfBirth = value; }
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
    
    public string City
    {
        get
        {
            return _City;
        }
        set
        {
            _City = value;
        }
    }
    
    public string State
    {
        get
        {
            return _State;
        }
        set
        {
            _State = value;
        }
    }
    
    public string Zip
    {
        get
        {
            return _Zip;
        }
        set
        {
            _Zip = value;
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

    public string Address
    {
        get
        {
            return _Address;
        }
        set
        {
            _Address = value;
        }
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
    
    public Nullable<int> ModifiedById
    {
        get { return _ModifiedById; }
        set { _ModifiedById = value; }
    }

    public Nullable<DateTime> ModifiedDate
    {
        get { return _ModifiedDate; }
        set { _ModifiedDate = value; }
    }

    public bool IsActive
    {
        get { return _IsActive; }
        set { _IsActive = value; }
    }

    public bool Deleted
    {
        get { return _Deleted; }
        set { _Deleted = value; }
    }


}