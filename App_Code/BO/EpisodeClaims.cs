using System;
/// <summary>
/// Summary description for EpisodeClaims
/// </summary>
public class EpisodeClaims
{
    public EpisodeClaims()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    #region " Private Members "
    private Int64 _EpisodeClaimsId;
    private long _PracticeId;
    private int? _PracticeLocationsId;
    private Int64? _InsuranceId;
    private Int64? _SecInsuranceId;
    private Int64? _OthInsuranceId;
    private Int64 _EpisodeId;
    private Int64 _EpisodTaskId;
    private Int64 _PatientId;
    private int _ClaimTypeId;
    private int _PriSubmissionStatusId;
    private int _SecSubmissionStatusId;
    private int _OthSubmissionStatusId;
    private int _PatSubmissionStatusId;
    private DateTime? _BillDate;   
    private decimal _TotalCharges;
    private decimal _TotalPayments;
    private decimal _PrimaryPayment;
    private decimal _SecondaryPayment;
    private decimal _OtherPayment;
    private decimal _PatientPayment;
    private string _PatientStatusCode = string.Empty;
    private DateTime _CreatedDate;
    private long _CreatedById;
    private DateTime? _ModifiedDate;
    private int? _ModifiedById;
    private bool _Deleted = false;


    #endregion
    #region " Properties "
    public Int64 EpisodeClaimsId
    {
        get { return _EpisodeClaimsId; }
        set { _EpisodeClaimsId = value; }
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

    public Int64? InsuranceId
    {
        get { return _InsuranceId; }
        set { _InsuranceId = value; }
    }
    public Int64? SecInsuranceId
    {
        get { return _SecInsuranceId; }
        set { _SecInsuranceId = value; }
    }
    public Int64? OthInsuranceId
    {
        get { return _OthInsuranceId; }
        set { _OthInsuranceId = value; }
    }
    public Int64 EpisodeId
    {
        get { return _EpisodeId; }
        set { _EpisodeId = value; }
    }

    public Int64 EpisodTaskId
    {
        get { return _EpisodTaskId; }
        set { _EpisodTaskId = value; }
    }

    public Int64 PatientId
    {
        get { return _PatientId; }
        set { _PatientId = value; }
    }

    public int ClaimTypeId
    {
        get { return _ClaimTypeId; }
        set { _ClaimTypeId = value; }
    }

    public int PriSubmissionStatusId
    {
        get { return _PriSubmissionStatusId; }
        set { _PriSubmissionStatusId = value; }
    }
    public int SecSubmissionStatusId
    {
        get { return _SecSubmissionStatusId; }
        set { _SecSubmissionStatusId = value; }
    }
    public int OthSubmissionStatusId
    {
        get { return _OthSubmissionStatusId; }
        set { _OthSubmissionStatusId = value; }
    }
    public int PatSubmissionStatusId
    {
        get { return _PatSubmissionStatusId; }
        set { _PatSubmissionStatusId = value; }
    }

    public DateTime? BillDate
    {
        get { return _BillDate; }
        set { _BillDate = value; }
    }   

    public decimal TotalCharges
    {
        get { return _TotalCharges; }
        set { _TotalCharges = value; }
    }
    public decimal TotalPayments
    {
        get { return _TotalPayments; }
        set { _TotalPayments = value; }
    }
    public decimal PrimaryPayment
    {
        get { return _PrimaryPayment; }
        set { _PrimaryPayment = value; }
    }

    public decimal SecondaryPayment
    {
        get { return _SecondaryPayment; }
        set { _SecondaryPayment = value; }
    }

    public decimal OtherPayment
    {
        get { return _OtherPayment; }
        set { _OtherPayment = value; }
    }

    public decimal PatientPayment
    {
        get { return _PatientPayment; }
        set { _PatientPayment = value; }
    }
    public string PatientStatusCode
    {
        get { return _PatientStatusCode; }
        set { _PatientStatusCode = value; }
    }
    public DateTime CreatedDate
    {
        get { return _CreatedDate; }
        set { _CreatedDate = value; }
    }

    public long CreatedById
    {
        get { return _CreatedById; }
        set { _CreatedById = value; }
    }

    public DateTime? ModifiedDate
    {
        get { return _ModifiedDate; }
        set { _ModifiedDate = value; }
    }

    public int? ModifiedById
    {
        get { return _ModifiedById; }
        set { _ModifiedById = value; }
    }

    public bool Deleted
    {
        get { return _Deleted; }
        set { _Deleted = value; }
    }

    #endregion
}