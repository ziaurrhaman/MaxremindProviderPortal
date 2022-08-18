using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for HIPAA270Log
/// </summary>
public class HIPAA270Log
{
	public HIPAA270Log()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    
    #region " Private Members "
    
    long _HIPAA270Id;
    long _PracticeId;
    
    long _PatientId;
    DateTime _DateFrom;
    DateTime _DateTo;
    long _InsuranceId;

    string _EligibilityStatus = string.Empty;
    DateTime _EligibilityInquiryDate;
    string _ResponseString = string.Empty;
    
    long _CreatedById;
    DateTime _CreatedDate;
    bool _Deleted = false;
    
    #endregion
    
    #region " Properties "
    
    public long HIPAA270Id
    {
        get { return _HIPAA270Id; }
        set { _HIPAA270Id = value; }
    }
    
    public long PracticeId
    {
        get { return _PracticeId; }
        set { _PracticeId = value; }
    }
    
    public long PatientId
    {
        get { return _PatientId; }
        set { _PatientId = value; }
    }
    
    public DateTime DateFrom
    {
        get { return _DateFrom; }
        set { _DateFrom = value; }
    }
    
    public DateTime DateTo
    {
        get { return _DateTo; }
        set { _DateTo = value; }
    }
    
    public long InsuranceId
    {
        get { return _InsuranceId; }
        set { _InsuranceId = value; }
    }
    
    public string EligibilityStatus
    {
        get { return _EligibilityStatus; }
        set { _EligibilityStatus = value; }
    }

    public DateTime EligibilityInquiryDate
    {
        get { return _EligibilityInquiryDate; }
        set { _EligibilityInquiryDate = value; }
    }
    
    public string ResponseString
    {
        get { return _ResponseString; }
        set { _ResponseString = value; }
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
    
    public bool Deleted
    {
        get { return _Deleted; }
        set { _Deleted = value; }
    }
    
    #endregion
}