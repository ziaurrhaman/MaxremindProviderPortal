using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Suppliers
/// </summary>
public class Suppliers
{
	public Suppliers()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    
    #region " Private Members "
    
    long _SuppliersId;
    long _PracticeId;
    string _SupplierName = string.Empty;
    string _GSTNo = string.Empty;
    string _Website = string.Empty;
    int _CurrencyId;
    Nullable<long> _OurCustomerNo;
    string _BankAccount = string.Empty;
    string _BankName = string.Empty;
    double _CreditLimit = double.MinValue;
    string _PaymentTerms = string.Empty;
    bool _PricesTaxIncluded = false;
    string _PhoneNumber = string.Empty;
    string _SecondaryPhone = string.Empty;
    string _MailingAddress = string.Empty;
    string _PhysicalAddress = string.Empty;
    string _City = string.Empty;
    string _StateCode = string.Empty;
    string _Zip = string.Empty;
    string _Notes = string.Empty;
    string _Status = string.Empty;
    long _CreatedById;
    DateTime _CreatedDate;
    long _ModifiedById;
    DateTime _ModifiedDate;
    
    bool _Deleted = false;
    #endregion
    
    #region " Properties "

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

    public string SupplierName
    {
        get { return _SupplierName; }
        set { _SupplierName = value; }
    }

    public string GSTNo
    {
        get { return _GSTNo; }
        set { _GSTNo = value; }
    }

    public string Website
    {
        get { return _Website; }
        set { _Website = value; }
    }

    public int CurrencyId
    {
        get { return _CurrencyId; }
        set { _CurrencyId = value; }
    }

    public Nullable<long> OurCustomerNo
    {
        get { return _OurCustomerNo; }
        set { _OurCustomerNo = value; }
    }

    public string BankAccount
    {
        get { return _BankAccount; }
        set { _BankAccount = value; }
    }

    public string BankName
    {
        get { return _BankName; }
        set { _BankName = value; }
    }

    public double CreditLimit
    {
        get { return _CreditLimit; }
        set { _CreditLimit = value; }
    }

    public string PaymentTerms
    {
        get { return _PaymentTerms; }
        set { _PaymentTerms = value; }
    }

    public bool PricesTaxIncluded
    {
        get { return _PricesTaxIncluded; }
        set { _PricesTaxIncluded = value; }
    }

    public string PhoneNumber
    {
        get { return _PhoneNumber; }
        set { _PhoneNumber = value; }
    }

    public string SecondaryPhone
    {
        get { return _SecondaryPhone; }
        set { _SecondaryPhone = value; }
    }

    public string MailingAddress
    {
        get { return _MailingAddress; }
        set { _MailingAddress = value; }
    }

    public string PhysicalAddress
    {
        get { return _PhysicalAddress; }
        set { _PhysicalAddress = value; }
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

    public string Notes
    {
        get { return _Notes; }
        set { _Notes = value; }
    }

    public string Status
    {
        get { return _Status; }
        set { _Status = value; }
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