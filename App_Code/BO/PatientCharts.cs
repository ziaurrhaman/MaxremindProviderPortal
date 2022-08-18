using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PatientCharts
/// </summary>
public class PatientCharts
{
    public PatientCharts()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    #region " Private Members "

    private long _ChartId;
    private long _PatientId;
    private long _AppointmentsId;
    private DateTime? _VisitDate;
    private long? _VisitTypeId;
    private long? _LocationId;
    private long? _ApprovedByProviderId;
    private long? _SeenByProviderId;
    private long _PracticeId;
    private bool _Signed = false;
    private long? _SignedBy;
    private DateTime? _SignedDate;
    private bool _CoSigned = false;
    private long? _CoSignedBy;
    private DateTime? _CoSignedDate;
    private bool _Complete = false;
    private long? _CompleteBy;
    private DateTime? _CompleteDate;
    private long _CreatedById;
    private DateTime _CreatedDate;
    private long _ModifiedById;
    private DateTime _ModifiedDate;
    bool _Deleted = false;
    string _PresentIllness = string.Empty;
    string _ReviewOfSystem = string.Empty;
    string _PastMedicalHistory = string.Empty;
    string _SocialHistory = string.Empty;
    string _TobaccoUse = string.Empty;
    int? _PacksPerDay;
    int? _YearsSmoked;
    string _FamilyHistory = string.Empty;
    string _ReasonOfVisit = string.Empty;
    string _ReasonForOutPatient = string.Empty;
    string _PlaceOfService = string.Empty;
    
    #endregion

    #region " Properties "

    public long ChartId
    {
        get { return _ChartId; }
        set { _ChartId = value; }
    }

    public long PatientId
    {
        get { return _PatientId; }
        set { _PatientId = value; }
    }

    public long AppointmentsId
    {
        get { return _AppointmentsId; }
        set { _AppointmentsId = value; }
    }

    public DateTime? VisitDate
    {
        get { return _VisitDate; }
        set { _VisitDate = value; }
    }

    public long? VisitTypeId
    {
        get { return _VisitTypeId; }
        set { _VisitTypeId = value; }
    }

    public long? LocationId
    {
        get { return _LocationId; }
        set { _LocationId = value; }
    }

    public long? ApprovedByProviderId
    {
        get { return _ApprovedByProviderId; }
        set { _ApprovedByProviderId = value; }
    }
    public long? SeenByProviderId
    {
        get { return _SeenByProviderId; }
        set { _SeenByProviderId = value; }
    }
    public long PracticeId
    {
        get { return _PracticeId; }
        set { _PracticeId = value; }
    }

    public bool Signed
    {
        get { return _Signed; }
        set { _Signed = value; }
    }

    public long? SignedBy
    {
        get { return _SignedBy; }
        set { _SignedBy = value; }
    }

    public DateTime? SignedDate
    {
        get { return _SignedDate; }
        set { _SignedDate = value; }
    }

    public bool CoSigned
    {
        get { return _CoSigned; }
        set { _CoSigned = value; }
    }

    public long? CoSignedBy
    {
        get { return _CoSignedBy; }
        set { _CoSignedBy = value; }
    }

    public DateTime? CoSignedDate
    {
        get { return _CoSignedDate; }
        set { _CoSignedDate = value; }
    }

    public bool Complete
    {
        get { return _Complete; }
        set { _Complete = value; }
    }

    public long? CompleteBy
    {
        get { return _CompleteBy; }
        set { _CompleteBy = value; }
    }

    public DateTime? CompleteDate
    {
        get { return _CompleteDate; }
        set { _CompleteDate = value; }
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
    public string PresentIllness
    {
        get { return _PresentIllness; }
        set { _PresentIllness = value; }
    }
    public string ReviewOfSystem
    {
        get { return _ReviewOfSystem; }
        set { _ReviewOfSystem = value; }
    }

    public string PastMedicalHistory
    {
        get { return _PastMedicalHistory; }
        set { _PastMedicalHistory = value; }
    }

    public string SocialHistory
    {
        get { return _SocialHistory; }
        set { _SocialHistory = value; }
    }

    public string TobaccoUse
    {
        get { return _TobaccoUse; }
        set { _TobaccoUse = value; }
    }

    public int? PacksPerDay
    {
        get { return _PacksPerDay; }
        set { _PacksPerDay = value; }
    }

    public int? YearsSmoked
    {
        get { return _YearsSmoked; }
        set { _YearsSmoked = value; }
    }

    public string FamilyHistory
    {
        get { return _FamilyHistory; }
        set { _FamilyHistory = value; }
    }
    public string ReasonOfVisit
    {
        get { return _ReasonOfVisit; }
        set { _ReasonOfVisit = value; }
    }
    public string ReasonForOutPatient
    {
        get { return _ReasonForOutPatient; }
        set { _ReasonForOutPatient = value; }
    }
    public string PlaceOfService
    {
        get { return _PlaceOfService; }
        set { _PlaceOfService = value; }
    }
    #endregion
}