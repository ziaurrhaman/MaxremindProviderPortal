using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for FaceEncounter
/// </summary>
public class FaceEncounter
{
	public FaceEncounter()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    #region " Private Members "

    private long _FaceEncounterId;
    private long _PatientId;
    private long _PracticeId;
    private long _ServiceProviderId;
    private long _ReferringPhysicianId;
    private DateTime _EncounterDate;
    private string _ReasonForEncounter;
    private string _EvidenceToStatus;
    private bool _SkilledNursing;
    private bool _PhysicalTherapy;
    private bool _OccupationalTherapy;
    private bool _SpeechTherapy;
    private bool _SocialWorker;
    private bool _HHAide;
    private DateTime _SignatureDate;
    private long _CreatedById;
    private DateTime _CreatedDate;
    private Nullable<int> _ModifiedById;
    private Nullable<DateTime> _ModifiedDate;
    private bool _Deleted;
    
    #endregion
    
    #region " Properties "
    
    public long FaceEncounterId
    {
        get { return _FaceEncounterId; }
        set { _FaceEncounterId = value; }
    }
    
    public long PatientId
    {
        get { return _PatientId; }
        set { _PatientId = value; }
    }

    public long PracticeId
    {
        get { return _PracticeId; }
        set { _PracticeId = value; }
    }

    public long ServiceProviderId
    {
        get { return _ServiceProviderId; }
        set { _ServiceProviderId = value; }
    }

    public long ReferringPhysicianId
    {
        get { return _ReferringPhysicianId; }
        set { _ReferringPhysicianId = value; }
    }

    public DateTime EncounterDate
    {
        get { return _EncounterDate; }
        set { _EncounterDate = value; }
    }

    public string ReasonForEncounter
    {
        get { return _ReasonForEncounter; }
        set { _ReasonForEncounter = value; }
    }

    public string EvidenceToStatus
    {
        get { return _EvidenceToStatus; }
        set { _EvidenceToStatus = value; }
    }

    public bool SkilledNursing
    {
        get { return _SkilledNursing; }
        set { _SkilledNursing = value; }
    }

    public bool PhysicalTherapy
    {
        get { return _PhysicalTherapy; }
        set { _PhysicalTherapy = value; }
    }

    public bool OccupationalTherapy
    {
        get { return _OccupationalTherapy; }
        set { _OccupationalTherapy = value; }
    }

    public bool SpeechTherapy
    {
        get { return _SpeechTherapy; }
        set { _SpeechTherapy = value; }
    }

    public bool SocialWorker
    {
        get { return _SocialWorker; }
        set { _SocialWorker = value; }
    }

    public bool HHAide
    {
        get { return _HHAide; }
        set { _HHAide = value; }
    }

    public DateTime SignatureDate
    {
        get { return _SignatureDate; }
        set { _SignatureDate = value; }
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

    public Nullable<int> ModifiedById
    {
        get { return _ModifiedById; }
        set { _ModifiedById = value; }
    }

    public Nullable<DateTime> ModifiedDate
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