using System;

/// <summary>
/// Summary description for ServiceProvider
/// </summary>
public class ServiceProvider
{
    public ServiceProvider()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    #region " Private Members "
    private  Int64 _ServiceProviderId;
    private long _PracticeId;
    private int? _PracticeLocationsId;
    private string _FirstName = string.Empty;
    private string _MiddleName = string.Empty;
    private string _LastName = string.Empty;
    private string _ProviderType = string.Empty;
    private string _Gender = string.Empty;
    private DateTime? _DOB;
    private string _Title = string.Empty;
    private string _City = string.Empty;
    private string _State = string.Empty;
    private string _Zip = string.Empty;
    private string _StreetAddress = string.Empty;
    private string _Cell = string.Empty;
    private string _OtherPhone = string.Empty;
    private string _Email = string.Empty;
    private string _NPI = string.Empty;
    private string _ProviderNo = string.Empty;
    private string _ImagePath = string.Empty;
    private string _LicenseNo = string.Empty;
    private string _LicenseState = string.Empty;
    private System.Nullable<DateTime> _LicenseIssuDate;
    private System.Nullable<DateTime> _LicenseExpiry;
    private string _CommunityCareNumber = string.Empty;
    private string _UPIN = string.Empty;
    private bool _ExternalReferral = false;
    private string _FaxNumber = string.Empty;
    public string DAE { get; set; }
    public string Degree { get; set; }
    public string Speciality { get; set; }
    private bool _Active = true;
    private bool _IsAuthorized = false;
    private string _EmploymentType = string.Empty;
    
    private long _CreatedById;
    private DateTime _CreatedDate;
    private long _ModifiedById;
    private DateTime _ModifiedDate;
    private bool _Deleted = false;
    
    #endregion

   #region " Properties "

   public Int64 ServiceProviderId
   {
       get { return _ServiceProviderId; }
       set { _ServiceProviderId = value; }
   }

   public long PracticeId
   {
       get { return _PracticeId; }
       set { _PracticeId = value; }
   }

   public int? PracticeLocationsId
   {
       get { return _PracticeLocationsId; }
       set { _PracticeLocationsId = value; }
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
   public string ProviderType
   {
       get { return _ProviderType; }
       set { _ProviderType = value; }
   }
   public string Gender
   {
       get { return _Gender; }
       set { _Gender = value; }
   }
   public DateTime? DOB
   {
       get { return _DOB; }
       set { _DOB = value; }
   }
   public string Title
   {
       get { return _Title; }
       set { _Title = value; }
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

   public string StreetAddress
   {
       get { return _StreetAddress; }
       set { _StreetAddress = value; }
   }

   public string Cell
   {
       get { return _Cell; }
       set { _Cell = value; }
   }

   public string OtherPhone
   {
       get { return _OtherPhone; }
       set { _OtherPhone = value; }
   }

   public string Email
   {
       get { return _Email; }
       set { _Email = value; }
   }

   public string NPI
   {
       get { return _NPI; }
       set { _NPI = value; }
   }

   public string ProviderNo
   {
       get { return _ProviderNo; }
       set { _ProviderNo = value; }
   }

   public string ImagePath
   {
       get { return _ImagePath; }
       set { _ImagePath = value; }
   }

   public string LicenseNo
   {
       get { return _LicenseNo; }
       set { _LicenseNo = value; }
   }

   public string LicenseState
   {
       get { return _LicenseState; }
       set { _LicenseState = value; }
   }

   public System.Nullable<DateTime> LicenseIssuDate
   {
       get { return _LicenseIssuDate; }
       set { _LicenseIssuDate = value; }
   }

   public System.Nullable<DateTime> LicenseExpiry
   {
       get { return _LicenseExpiry; }
       set { _LicenseExpiry = value; }
   }

   public string CommunityCareNumber
   {
       get { return _CommunityCareNumber; }
       set { _CommunityCareNumber = value; }
   }

   public string UPIN
   {
       get { return _UPIN; }
       set { _UPIN = value; }
   }

   public bool ExternalReferral
   {
       get { return _ExternalReferral; }
       set { _ExternalReferral = value; }
   }

   public string FaxNumber
   {
       get { return _FaxNumber; }
       set { _FaxNumber = value; }
   }
   public bool Active
   {
       get { return _Active; }
       set { _Active = value; }
   }
   public bool IsAuthorized
   {
       get { return _IsAuthorized; }
       set { _IsAuthorized = value; }
   }
   public string EmploymentType
   {
       get { return _EmploymentType; }
       set { _EmploymentType = value; }
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