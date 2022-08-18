using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SuppliersContacts
/// </summary>
public class SuppliersContacts
{
	public SuppliersContacts()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    
    #region " Private Members "
    
    long _SuppliersContactsId;
    long _SuppliersId;
    long _PracticeId;
    string _FirstName = string.Empty;
    string _LastName = string.Empty;
    string _Reference = string.Empty;
    string _ContactActiveFor = string.Empty;
    string _ContactPhone = string.Empty;
    string _ContactSecondaryPhone = string.Empty;
    string _FaxNumber = string.Empty;
    string _Email = string.Empty;
    string _Address = string.Empty;
    string _DocumentLanguage = string.Empty;
    string _ContactNotes = string.Empty;
    long _CreatedById;
    DateTime _CreatedDate;
    long _ModifiedById;
    DateTime _ModifiedDate;
    
    bool _Deleted = false;
    #endregion

    #region " Properties "
    
    public long SuppliersContactsId
    {
        get { return _SuppliersContactsId; }
        set { _SuppliersContactsId = value; }
    }
    
    public long SuppliersId
    {
        get { return _SuppliersId; }
        set { _SuppliersId = value; }
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

    public string LastName
    {
        get { return _LastName; }
        set { _LastName = value; }
    }

    public string Reference
    {
        get { return _Reference; }
        set { _Reference = value; }
    }

    public string ContactActiveFor
    {
        get { return _ContactActiveFor; }
        set { _ContactActiveFor = value; }
    }

    public string ContactPhone
    {
        get { return _ContactPhone; }
        set { _ContactPhone = value; }
    }

    public string ContactSecondaryPhone
    {
        get { return _ContactSecondaryPhone; }
        set { _ContactSecondaryPhone = value; }
    }

    public string FaxNumber
    {
        get { return _FaxNumber; }
        set { _FaxNumber = value; }
    }

    public string Email
    {
        get { return _Email; }
        set { _Email = value; }
    }

    public string Address
    {
        get { return _Address; }
        set { _Address = value; }
    }

    public string DocumentLanguage
    {
        get { return _DocumentLanguage; }
        set { _DocumentLanguage = value; }
    }

    public string ContactNotes
    {
        get { return _ContactNotes; }
        set { _ContactNotes = value; }
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

    public bool Deleted
    {
        get { return _Deleted; }
        set { _Deleted = value; }
    }

    #endregion
}