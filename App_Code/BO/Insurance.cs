using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Insurance
/// </summary>
public class Insurance
{
	public Insurance()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    #region " Private Members "

    long _InsuranceId;
    long _PracticeId;   
    string _Name = string.Empty;
    string _TaxId = string.Empty;
    string _HeadOfficeAddress = string.Empty;
    string _InsuranceType = string.Empty;
    private int? _InsuranceCategoryId;
    private string _InsuranceCategory = string.Empty;
    string _City = string.Empty;
    string _State = string.Empty;
    string _Zip = string.Empty;
    string _ContacatPerson = string.Empty;
    string _Email = string.Empty;
    string _Fax = string.Empty;
    string _Phone1 = string.Empty;
    string _Phone2 = string.Empty;
    string _Phone3 = string.Empty;
    long _CreatedById;
    DateTime _CreatedDate;
    long _ModifiedById;
    DateTime _ModifiedDate;
    bool _InActive = false;

    bool _Deleted = false;
    #endregion

    #region " Properties "

    public long InsuranceId
    {
        get { return _InsuranceId; }
        set { _InsuranceId = value; }
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

    public string TaxId
    {
        get { return _TaxId; }
        set { _TaxId = value; }
    }

    public string HeadOfficeAddress
    {
        get { return _HeadOfficeAddress; }
        set { _HeadOfficeAddress = value; }
    }

    public string InsuranceType
    {
        get { return _InsuranceType; }
        set { _InsuranceType = value; }
    }
    public int? InsuranceCategoryId
    {
        get { return _InsuranceCategoryId; }
        set { _InsuranceCategoryId = value; }
    }

    public string InsuranceCategory
    {
        get { return _InsuranceCategory; }
        set { _InsuranceCategory = value; }
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

    public string ContacatPerson
    {
        get { return _ContacatPerson; }
        set { _ContacatPerson = value; }
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