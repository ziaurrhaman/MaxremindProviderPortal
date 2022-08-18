
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

[Serializable]
public class UserRegistration
{
    public UserRegistration()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    #region Private Members

    long _UserRegistrationId;
    string _FirstName = string.Empty;
    string _LastName = string.Empty;
    string _Email = string.Empty;
    string _PracticeName = string.Empty;
    string _TaxID = string.Empty;
    string _GroupNPI = string.Empty;
    string _MedicaidProvider = string.Empty;
    string _ServicingProviderName = string.Empty;
    string _ProviderNPI = string.Empty;
    string _ProviderTaxonomyCode = string.Empty;
    string _StateLicenseNumber = string.Empty;
    string _MedicaidGroup = string.Empty;
    string _GroupNPIMedicareGroupPTAN = string.Empty;
    string _MedicareProviderPTAN = string.Empty;
    string _Phone = string.Empty;
    string _Fax = string.Empty;
    string _Notes = string.Empty;
    string _PhysicalAddress = string.Empty;
    string _MailingAddress = string.Empty;
    string _Password = string.Empty;
    string _UserName = string.Empty;
    string _UserImage = string.Empty;

    long _CreatedById;
    DateTime _CreatedDate=DateTime.Now;
    long _ModifiedById;
    DateTime _ModifiedDate=DateTime.Now;
    bool _Deleted;

    #endregion

    #region Properties

    public long UserRegistrationId
    {
        get { return _UserRegistrationId; }
        set { _UserRegistrationId = value; }
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

    public string Email
    {
        get { return _Email; }
        set { _Email = value; }
    }

    public string PracticeName
    {
        get { return _PracticeName; }
        set { _PracticeName = value; }
    }

    public string TaxID
    {
        get { return _TaxID; }
        set { _TaxID = value; }
    }

    public string GroupNPI
    {
        get { return _GroupNPI; }
        set { _GroupNPI = value; }
    }

    public string MedicaidProvider
    {
        get { return _MedicaidProvider; }
        set { _MedicaidProvider = value; }
    }

    public string ServicingProviderName
    {
        get { return _ServicingProviderName; }
        set { _ServicingProviderName = value; }
    }

    public string ProviderNPI
    {
        get { return _ProviderNPI; }
        set { _ProviderNPI = value; }
    }

    public string ProviderTaxonomyCode
    {
        get { return _ProviderTaxonomyCode; }
        set { _ProviderTaxonomyCode = value; }
    }

    public string StateLicenseNumber
    {
        get { return _StateLicenseNumber; }
        set { _StateLicenseNumber = value; }
    }

    public string MedicaidGroup
    {
        get { return _MedicaidGroup; }
        set { _MedicaidGroup = value; }
    }

    public string GroupNPIMedicareGroupPTAN
    {
        get { return _GroupNPIMedicareGroupPTAN; }
        set { _GroupNPIMedicareGroupPTAN = value; }
    }

    public string MedicareProviderPTAN
    {
        get { return _MedicareProviderPTAN; }
        set { _MedicareProviderPTAN = value; }
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

    public string Notes
    {
        get { return _Notes; }
        set { _Notes = value; }
    }

    public string PhysicalAddress
    {
        get { return _PhysicalAddress; }
        set { _PhysicalAddress = value; }
    }

    public string MailingAddress
    {
        get { return _MailingAddress; }
        set { _MailingAddress = value; }
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
    public string Password
    {
        get { return _Password; }
        set { _Password = value; }
    }
    public string UserName
    {
        get { return _UserName; }
        set { _UserName = value; }
    }
    public string UserImage
    {
        get { return _UserImage; }
        set { _UserImage = value; }
    }

    #endregion
}