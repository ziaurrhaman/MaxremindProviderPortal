using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for HIPPAPrivacyAuthorization
/// </summary>
public class HIPPAPrivacyAuthorization
{
	public HIPPAPrivacyAuthorization()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    #region " Private Members "

    Int64 _HIIPAAuthorizationId;
    Int64 _PatientId;
    Int64 _ServiceProviderId;
    Int64 _PracticeId;
    string _AuthorizeTo = string.Empty;
    bool _EffectivePeriod = false;
    DateTime? _EffectivePeriodFrom;
    DateTime? _EffectivePeriodTo;
    bool _AllPeriod = false;
    bool _AuthorizeCompleteHealthRecrod = false;
    bool _AuthorizeCompleteHealthRecrodExcep = false;
    bool _MentalHealthRecord = false;
    bool _CommunicableDiseases = false;
    bool _AlcohalTreatment = false;
    bool _OtherRecord = false;
    string _OtherRecordDesc = string.Empty;
    DateTime? _AuthorizationForceDate;
    DateTime? _SigDate;
    string _SigPerson = string.Empty;
    string _PrintedName = string.Empty;
    long _CreatedById = 0;
    DateTime _CreatedDate;
    long _ModifiedById;
    DateTime _ModifiedDate;
    bool _Deleted = false;

    #endregion

    #region " Properties "

    public Int64 HIIPAAuthorizationId
    {
        get { return _HIIPAAuthorizationId; }
        set { _HIIPAAuthorizationId = value; }
    }
    public Int64 ServiceProviderId
    {
        get { return _ServiceProviderId; }
        set { _ServiceProviderId = value; }
    }

    public Int64 PatientId
    {
        get { return _PatientId; }
        set { _PatientId = value; }
    }

    public Int64 PracticeId
    {
        get { return _PracticeId; }
        set { _PracticeId = value; }
    }

    public string AuthorizeTo
    {
        get { return _AuthorizeTo; }
        set { _AuthorizeTo = value; }
    }

    public DateTime? EffectivePeriodFrom
    {
        get { return _EffectivePeriodFrom; }
        set { _EffectivePeriodFrom = value; }
    }

    public DateTime? EffectivePeriodTo
    {
        get { return _EffectivePeriodTo; }
        set { _EffectivePeriodTo = value; }
    }

    public bool EffectivePeriod
    {
        get { return _EffectivePeriod; }
        set { _EffectivePeriod = value; }
    }
    public bool AllPeriod
    {
        get { return _AllPeriod; }
        set { _AllPeriod = value; }
    }

    public bool AuthorizeCompleteHealthRecrod
    {
        get { return _AuthorizeCompleteHealthRecrod; }
        set { _AuthorizeCompleteHealthRecrod = value; }
    }

    public bool AuthorizeCompleteHealthRecrodExcep
    {
        get { return _AuthorizeCompleteHealthRecrodExcep; }
        set { _AuthorizeCompleteHealthRecrodExcep = value; }
    }

    public bool MentalHealthRecord
    {
        get { return _MentalHealthRecord; }
        set { _MentalHealthRecord = value; }
    }

    public bool CommunicableDiseases
    {
        get { return _CommunicableDiseases; }
        set { _CommunicableDiseases = value; }
    }

    public bool AlcohalTreatment
    {
        get { return _AlcohalTreatment; }
        set { _AlcohalTreatment = value; }
    }

    public bool OtherRecord
    {
        get { return _OtherRecord; }
        set { _OtherRecord = value; }
    }
    public string OtherRecordDesc
    {
        get { return _OtherRecordDesc; }
        set { _OtherRecordDesc = value; }
    }

    public DateTime? AuthorizationForceDate
    {
        get { return _AuthorizationForceDate; }
        set { _AuthorizationForceDate = value; }
    }

    public DateTime? SigDate
    {
        get { return _SigDate; }
        set { _SigDate = value; }
    }

    public string SigPerson
    {
        get { return _SigPerson; }
        set { _SigPerson = value; }
    }

    public string PrintedName
    {
        get { return _PrintedName; }
        set { _PrintedName = value; }
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