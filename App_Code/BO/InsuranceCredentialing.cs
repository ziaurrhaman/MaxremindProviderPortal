using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for InsuranceCredentialing
/// </summary>
public class InsuranceCredentialing 
{
    public InsuranceCredentialing()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    #region Private Members

    int _InsuranceCredentialingID;
    int? _InsuranceId;
    DateTime _CreatedDate;
    int _CreatedById;
    DateTime _ModifiedDate;
    int _ModifiedById;
    bool _Deleted = false;
    long _PracticeId;
    string _Status;
    string _Notes;
    int? _PracticeDocumentsId;
    long _ProviderId;
    string _Source = string.Empty;
    DateTime _TargetDate;
    string _GroupId = string.Empty;
    string _ProviderPTAN = string.Empty;
    string _Remarks = string.Empty;
    long _NPI;
    long _TaxId;
    string _SSN = string.Empty;
    #endregion

    #region Properties

    public int InsuranceCredentialingID
    {
        get { return _InsuranceCredentialingID; }
        set { _InsuranceCredentialingID = value; }
    }
    public int? InsuranceId
    {
        get { return _InsuranceId; }
        set { _InsuranceId = value; }
    }
    public DateTime CreatedDate
    {
        get { return _CreatedDate; }
        set { _CreatedDate = value; }
    }
    public int CreatedById
    {
        get { return _CreatedById; }
        set { _CreatedById = value; }
    }
    public DateTime ModifiedDate
    {
        get { return _ModifiedDate; }
        set { _ModifiedDate = value; }
    }
    public int ModifiedById
    {
        get { return _ModifiedById; }
        set { _ModifiedById = value; }
    }
    public bool Deleted
    {
        get { return _Deleted; }
        set { _Deleted = value; }
    }
    public long PracticeId
    {
        get { return _PracticeId; }
        set { _PracticeId = value; }
    }
    public string Status
    {
        get { return _Status; }
        set { _Status = value; }
    }
    public string Notes
    {
        get { return _Notes; }
        set { _Notes = value; }
    }
    public int? PracticeDocumentsId
    {
        get { return _PracticeDocumentsId; }
        set { _PracticeDocumentsId = value; }
    }
    public long ProviderId
    {
        get { return _ProviderId; }
        set { _ProviderId = value; }
    }
    public string Source
    {
        get { return _Source; }
        set { _Source = value; }
    }
    public DateTime TargetDate
    {
        get { return _TargetDate; }
        set { _TargetDate = value; }
    }
    public string GroupId
    {
        get { return _GroupId; }
        set { _GroupId = value; }
    }
    public string ProviderPTAN
    {
        get { return _ProviderPTAN; }
        set { _ProviderPTAN = value; }
    }
    public string Remarks
    {
        get { return _Remarks; }
        set { _Remarks = value; }
    }
    public long NPI
    {
        get { return _NPI; }
        set { _NPI = value; }
    }
    public long TaxId
    {
        get { return _TaxId; }
        set { _TaxId = value; }
    }

    public string SSN
    {
        get { return _SSN; }
        set { _SSN = value; }
    }

    #endregion


}