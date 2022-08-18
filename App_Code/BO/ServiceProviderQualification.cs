using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ServiceProviderQualification
/// </summary>
public class ServiceProviderQualification
{
    public ServiceProviderQualification()
    {
        //
        // TODO: Add constructor logic here
        //
    }


    #region " Private Members "
	private Int64 _ServiceProviderQualificationId ;
    private Int64 _ServiceProviderId;
    private Int64 _QualificationId;
    private DateTime _IssueDate;
    private DateTime _ExpiryDate;
    private string _QualificationNumber = string.Empty;
    private string _Attachment = string.Empty;
    private Int64 _CreatedById;
    private DateTime _CreatedDate;
    private Int64 _ModifiedById;
    private DateTime _ModifiedDate;
    private bool _Deleted = false;

    #endregion

    #region " Properties "

    public Int64 ServiceProviderQualificationId
    {
        get { return _ServiceProviderQualificationId; }
        set { _ServiceProviderQualificationId = value; }
    }

    public Int64 ServiceProviderId
    {
        get { return _ServiceProviderId; }
        set { _ServiceProviderId = value; }
    }

    public Int64 QualificationId
    {
        get { return _QualificationId; }
        set { _QualificationId = value; }
    }

    public DateTime IssueDate
    {
        get { return _IssueDate; }
        set { _IssueDate = value; }
    }

    public DateTime ExpiryDate
    {
        get { return _ExpiryDate; }
        set { _ExpiryDate = value; }
    }

    public string QualificationNumber
    {
        get { return _QualificationNumber; }
        set { _QualificationNumber = value; }
    }
    public string Attachment
    {
        get { return _Attachment; }
        set { _Attachment = value; }
    }
    public Int64 CreatedById
    {
        get { return _CreatedById; }
        set { _CreatedById = value; }
    }

    public DateTime CreatedDate
    {
        get { return _CreatedDate; }
        set { _CreatedDate = value; }
    }

    public Int64 ModifiedById
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