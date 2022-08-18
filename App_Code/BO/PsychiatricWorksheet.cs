using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PsychiatricWorksheet
/// </summary>
public class PsychiatricWorksheet
{
	public PsychiatricWorksheet()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    #region " Private Members "

    Int64 _PsychiatricWorksheetId;
    int _PracticeId;
    Int64 _PatientId;
    Int64 _ChartId;
    string _MariageStatus = string.Empty;
    bool _SignificantChange = false;
    string _DetailsSignificantChange = string.Empty;
    bool _DeathOfLoved = false;
    string _DetailsDeathOfLoved = string.Empty;
    bool _ChangedJobs = false;
    string _DetailsChangedJobs = string.Empty;
    bool _StatusChanged = false;
    string _DetailsStatusChanged = string.Empty;
    bool _LegalIssues = false;
    string _DetailsLegalIssues = string.Empty;
    string _HobbiesInterests = string.Empty;
    string _PSHAbuse = string.Empty;
    string _AlcoholAmount = string.Empty;
    string _AlcoholFrequency = string.Empty;
    string _AlcoholTimePeriod = string.Empty;
    string _MarijuanaAmount = string.Empty;
    string _MarijuanaFrequency = string.Empty;
    string _MarijuanaTimePeriod = string.Empty;
    string _CocaineAmount = string.Empty;
    string _CocaineFrequency = string.Empty;
    string _CocaineTimePeriod = string.Empty;
    string _InhalantsAmount = string.Empty;
    string _InhalantsFrequency = string.Empty;
    string _InhalantsTimePeriod = string.Empty;
    string _StimulantsAmount = string.Empty;
    string _StimulantsFrequency = string.Empty;
    string _StimulantsTimePeriod = string.Empty;
    string _HallucinogensAmount = string.Empty;
    string _HallucinogensFrequency = string.Empty;
    string _HallucinogensTimePeriod = string.Empty;
    string _HeroinAmount = string.Empty;
    string _HeroinFrequency = string.Empty;
    string _HeroinTimePeriod = string.Empty;
    string _PrescriptionAmount = string.Empty;
    string _PrescriptionFrequency = string.Empty;
    string _PrescriptionTimePeriod = string.Empty;
    string _OtherAmount = string.Empty;
    string _OtherFrequency = string.Empty;
    string _OtherTimePeriod = string.Empty;
    DateTime? _HospitalizationsFromDate;
    DateTime? _HospitalizationsToDate;
    string _HospitalizationsDuration = string.Empty;
    string _HospitalizationsTreatment = string.Empty;
    string _HospitalizationsComments = string.Empty;
    DateTime? _PsychiatricPsychotherapyFromDate;
    DateTime? _PsychiatricPsychotherapyToDate;
    string _PsychiatricPsychotherapyDuration = string.Empty;
    string _PsychiatricPsychotherapyTreatment = string.Empty;
    string _PsychiatricPsychotherapyComments = string.Empty;
    DateTime? _PsychiatricTreatmentFromDate;
    DateTime? _PsychiatricTreatmentToDate;
    string _PsychiatricTreatmentDuration = string.Empty;
    string _PsychiatricTreatmentTreatment = string.Empty;
    string _PsychiatricTreatmentComments = string.Empty;
    string _PatientPsychiatricHistory = string.Empty;
    string _FamilyPsychiatricHistory = string.Empty;
    string _PatientMedicalHistory = string.Empty;
    string _FamilyMedicalHistory = string.Empty;
    string _Appearance = string.Empty;
    string _Affect = string.Empty;
    string _Posture = string.Empty;
    string _Perception = string.Empty;
    string _BodyMovements = string.Empty;
    string _Cognitive = string.Empty;
    string _Speech = string.Empty;
    string _Judgement = string.Empty;
    string _Attitude = string.Empty;
    string _ThoughtContent = string.Empty;
    string _Orientation = string.Empty;
    string _LevelOfInsight = string.Empty;
    int? _ScoreBPRS;
    bool _NotIndicatedBPRS = false;
    int? _ScoreCSDD;
    bool _NotIndicatedCSDD = false;
    int? _ScoreGDS;
    bool _NotIndicatedGDS = false;
    int? _ScoreHAMA;
    bool _NotIndicatedHAMA = false;
    int? _ScoreSPMSQ;
    bool _NotIndicatedSPMSQ = false;
    int? _ScoreAIMS;
    bool _NotIndicatedAIMS = false;
    int? _ScoreSLUMS;
    bool _NotIndicatedSLUMS = false;
    int? _ScorePHQ2;
    bool _NotIndicatedPHQ2 = false;
    int? _ScorePHQ9;
    bool _NotIndicatedPHQ9 = false;
    int? _ScoreGAD7;
    bool _NotIndicatedGAD7 = false;
    
    DateTime _CreatedDate;
    int _CreatedById;
    DateTime _ModifiedDate;
    int _ModifiedById;
    bool _Deleted = false;

    #endregion

    #region " Properties "

    public Int64 PsychiatricWorksheetId
    {
        get { return _PsychiatricWorksheetId; }
        set { _PsychiatricWorksheetId = value; }
    }

    public int PracticeId
    {
        get { return _PracticeId; }
        set { _PracticeId = value; }
    }

    public Int64 PatientId
    {
        get { return _PatientId; }
        set { _PatientId = value; }
    }

    public Int64 ChartId
    {
        get { return _ChartId; }
        set { _ChartId = value; }
    }


    /*Start Patient Social History*/
    public string MariageStatus
    {
        get { return _MariageStatus; }
        set { _MariageStatus = value; }
    }

    public bool SignificantChange
    {
        get { return _SignificantChange; }
        set { _SignificantChange = value; }
    }

    public string DetailsSignificantChange
    {
        get { return _DetailsSignificantChange; }
        set { _DetailsSignificantChange = value; }
    }

    public bool DeathOfLoved
    {
        get { return _DeathOfLoved; }
        set { _DeathOfLoved = value; }
    }

    public string DetailsDeathOfLoved
    {
        get { return _DetailsDeathOfLoved; }
        set { _DetailsDeathOfLoved = value; }
    }

    public bool ChangedJobs
    {
        get { return _ChangedJobs; }
        set { _ChangedJobs = value; }
    }

    public string DetailsChangedJobs
    {
        get { return _DetailsChangedJobs; }
        set { _DetailsChangedJobs = value; }
    }

    public bool StatusChanged
    {
        get { return _StatusChanged; }
        set { _StatusChanged = value; }
    }

    public string DetailsStatusChanged
    {
        get { return _DetailsStatusChanged; }
        set { _DetailsStatusChanged = value; }
    }

    public bool LegalIssues
    {
        get { return _LegalIssues; }
        set { _LegalIssues = value; }
    }

    public string DetailsLegalIssues
    {
        get { return _DetailsLegalIssues; }
        set { _DetailsLegalIssues = value; }
    }

    public string HobbiesInterests
    {
        get { return _HobbiesInterests; }
        set { _HobbiesInterests = value; }
    }

    public string PSHAbuse
    {
        get { return _PSHAbuse; }
        set { _PSHAbuse = value; }
    }
    /*End Patient Social History*/


    /*Start Patient Substance Abuse History*/
    public string AlcoholAmount
    {
        get { return _AlcoholAmount; }
        set { _AlcoholAmount = value; }
    }

    public string AlcoholFrequency
    {
        get { return _AlcoholFrequency; }
        set { _AlcoholFrequency = value; }
    }

    public string AlcoholTimePeriod
    {
        get { return _AlcoholTimePeriod; }
        set { _AlcoholTimePeriod = value; }
    }

    public string MarijuanaAmount
    {
        get { return _MarijuanaAmount; }
        set { _MarijuanaAmount = value; }
    }

    public string MarijuanaFrequency
    {
        get { return _MarijuanaFrequency; }
        set { _MarijuanaFrequency = value; }
    }

    public string MarijuanaTimePeriod
    {
        get { return _MarijuanaTimePeriod; }
        set { _MarijuanaTimePeriod = value; }
    }

    public string CocaineAmount
    {
        get { return _CocaineAmount; }
        set { _CocaineAmount = value; }
    }

    public string CocaineFrequency
    {
        get { return _CocaineFrequency; }
        set { _CocaineFrequency = value; }
    }

    public string CocaineTimePeriod
    {
        get { return _CocaineTimePeriod; }
        set { _CocaineTimePeriod = value; }
    }

    public string InhalantsAmount
    {
        get { return _InhalantsAmount; }
        set { _InhalantsAmount = value; }
    }

    public string InhalantsFrequency
    {
        get { return _InhalantsFrequency; }
        set { _InhalantsFrequency = value; }
    }

    public string InhalantsTimePeriod
    {
        get { return _InhalantsTimePeriod; }
        set { _InhalantsTimePeriod = value; }
    }

    public string StimulantsAmount
    {
        get { return _StimulantsAmount; }
        set { _StimulantsAmount = value; }
    }

    public string StimulantsFrequency
    {
        get { return _StimulantsFrequency; }
        set { _StimulantsFrequency = value; }
    }

    public string StimulantsTimePeriod
    {
        get { return _StimulantsTimePeriod; }
        set { _StimulantsTimePeriod = value; }
    }

    public string HallucinogensAmount
    {
        get { return _HallucinogensAmount; }
        set { _HallucinogensAmount = value; }
    }

    public string HallucinogensFrequency
    {
        get { return _HallucinogensFrequency; }
        set { _HallucinogensFrequency = value; }
    }

    public string HallucinogensTimePeriod
    {
        get { return _HallucinogensTimePeriod; }
        set { _HallucinogensTimePeriod = value; }
    }

    public string HeroinAmount
    {
        get { return _HeroinAmount; }
        set { _HeroinAmount = value; }
    }

    public string HeroinFrequency
    {
        get { return _HeroinFrequency; }
        set { _HeroinFrequency = value; }
    }

    public string HeroinTimePeriod
    {
        get { return _HeroinTimePeriod; }
        set { _HeroinTimePeriod = value; }
    }

    public string PrescriptionAmount
    {
        get { return _PrescriptionAmount; }
        set { _PrescriptionAmount = value; }
    }

    public string PrescriptionFrequency
    {
        get { return _PrescriptionFrequency; }
        set { _PrescriptionFrequency = value; }
    }

    public string PrescriptionTimePeriod
    {
        get { return _PrescriptionTimePeriod; }
        set { _PrescriptionTimePeriod = value; }
    }

    public string OtherAmount
    {
        get { return _OtherAmount; }
        set { _OtherAmount = value; }
    }

    public string OtherFrequency
    {
        get { return _OtherFrequency; }
        set { _OtherFrequency = value; }
    }

    public string OtherTimePeriod
    {
        get { return _OtherTimePeriod; }
        set { _OtherTimePeriod = value; }
    }
    /*End Patient Substance Abuse History*/


    /*Start Patient Psychiatric History*/
    public DateTime? HospitalizationsFromDate
    {
        get { return _HospitalizationsFromDate; }
        set { _HospitalizationsFromDate = value; }
    }

    public DateTime? HospitalizationsToDate
    {
        get { return _HospitalizationsToDate; }
        set { _HospitalizationsToDate = value; }
    }

    public string HospitalizationsDuration
    {
        get { return _HospitalizationsDuration; }
        set { _HospitalizationsDuration = value; }
    }

    public string HospitalizationsTreatment
    {
        get { return _HospitalizationsTreatment; }
        set { _HospitalizationsTreatment = value; }
    }

    public string HospitalizationsComments
    {
        get { return _HospitalizationsComments; }
        set { _HospitalizationsComments = value; }
    }

    public DateTime? PsychiatricPsychotherapyFromDate
    {
        get { return _PsychiatricPsychotherapyFromDate; }
        set { _PsychiatricPsychotherapyFromDate = value; }
    }

    public DateTime? PsychiatricPsychotherapyToDate
    {
        get { return _PsychiatricPsychotherapyToDate; }
        set { _PsychiatricPsychotherapyToDate = value; }
    }

    public string PsychiatricPsychotherapyDuration
    {
        get { return _PsychiatricPsychotherapyDuration; }
        set { _PsychiatricPsychotherapyDuration = value; }
    }

    public string PsychiatricPsychotherapyTreatment
    {
        get { return _PsychiatricPsychotherapyTreatment; }
        set { _PsychiatricPsychotherapyTreatment = value; }
    }

    public string PsychiatricPsychotherapyComments
    {
        get { return _PsychiatricPsychotherapyComments; }
        set { _PsychiatricPsychotherapyComments = value; }
    }

    public DateTime? PsychiatricTreatmentFromDate
    {
        get { return _PsychiatricTreatmentFromDate; }
        set { _PsychiatricTreatmentFromDate = value; }
    }

    public DateTime? PsychiatricTreatmentToDate
    {
        get { return _PsychiatricTreatmentToDate; }
        set { _PsychiatricTreatmentToDate = value; }
    }

    public string PsychiatricTreatmentDuration
    {
        get { return _PsychiatricTreatmentDuration; }
        set { _PsychiatricTreatmentDuration = value; }
    }

    public string PsychiatricTreatmentTreatment
    {
        get { return _PsychiatricTreatmentTreatment; }
        set { _PsychiatricTreatmentTreatment = value; }
    }

    public string PsychiatricTreatmentComments
    {
        get { return _PsychiatricTreatmentComments; }
        set { _PsychiatricTreatmentComments = value; }
    }

    public string PatientPsychiatricHistory
    {
        get { return _PatientPsychiatricHistory; }
        set { _PatientPsychiatricHistory = value; }
    }
    /*End Patient Psychiatric History*/

    /*Start Family Psychiatric History*/
    public string FamilyPsychiatricHistory
    {
        get { return _FamilyPsychiatricHistory; }
        set { _FamilyPsychiatricHistory = value; }
    }
    /*End Family Psychiatric History*/

    /*Start Patient Medical History*/
    public string PatientMedicalHistory
    {
        get { return _PatientMedicalHistory; }
        set { _PatientMedicalHistory = value; }
    }
    /*End Patient Medical History*/

    /*Start Family Medical History*/
    public string FamilyMedicalHistory
    {
        get { return _FamilyMedicalHistory; }
        set { _FamilyMedicalHistory = value; }
    }
    /*End Family Medical History*/

    public string Appearance
    {
        get { return _Appearance; }
        set { _Appearance = value; }
    }

    public string Affect
    {
        get { return _Affect; }
        set { _Affect = value; }
    }

    public string Posture
    {
        get { return _Posture; }
        set { _Posture = value; }
    }

    public string Perception
    {
        get { return _Perception; }
        set { _Perception = value; }
    }

    public string BodyMovements
    {
        get { return _BodyMovements; }
        set { _BodyMovements = value; }
    }

    public string Cognitive
    {
        get { return _Cognitive; }
        set { _Cognitive = value; }
    }

    public string Speech
    {
        get { return _Speech; }
        set { _Speech = value; }
    }

    public string Judgement
    {
        get { return _Judgement; }
        set { _Judgement = value; }
    }

    public string Attitude
    {
        get { return _Attitude; }
        set { _Attitude = value; }
    }

    public string ThoughtContent
    {
        get { return _ThoughtContent; }
        set { _ThoughtContent = value; }
    }

    public string Orientation
    {
        get { return _Orientation; }
        set { _Orientation = value; }
    }

    public string LevelOfInsight
    {
        get { return _LevelOfInsight; }
        set { _LevelOfInsight = value; }
    }

    public int? ScoreBPRS
    {
        get { return _ScoreBPRS; }
        set { _ScoreBPRS = value; }
    }

    public bool NotIndicatedBPRS
    {
        get { return _NotIndicatedBPRS; }
        set { _NotIndicatedBPRS = value; }
    }

    public int? ScoreCSDD
    {
        get { return _ScoreCSDD; }
        set { _ScoreCSDD = value; }
    }

    public bool NotIndicatedCSDD
    {
        get { return _NotIndicatedCSDD; }
        set { _NotIndicatedCSDD = value; }
    }

    public int? ScoreGDS
    {
        get { return _ScoreGDS; }
        set { _ScoreGDS = value; }
    }

    public bool NotIndicatedGDS
    {
        get { return _NotIndicatedGDS; }
        set { _NotIndicatedGDS = value; }
    }

    public int? ScoreHAMA
    {
        get { return _ScoreHAMA; }
        set { _ScoreHAMA = value; }
    }

    public bool NotIndicatedHAMA
    {
        get { return _NotIndicatedHAMA; }
        set { _NotIndicatedHAMA = value; }
    }

    public int? ScoreSPMSQ
    {
        get { return _ScoreSPMSQ; }
        set { _ScoreSPMSQ = value; }
    }

    public bool NotIndicatedSPMSQ
    {
        get { return _NotIndicatedSPMSQ; }
        set { _NotIndicatedSPMSQ = value; }
    }

    public int? ScoreAIMS
    {
        get { return _ScoreAIMS; }
        set { _ScoreAIMS = value; }
    }

    public bool NotIndicatedAIMS
    {
        get { return _NotIndicatedAIMS; }
        set { _NotIndicatedAIMS = value; }
    }

    public int? ScoreSLUMS
    {
        get { return _ScoreSLUMS; }
        set { _ScoreSLUMS = value; }
    }

    public bool NotIndicatedSLUMS
    {
        get { return _NotIndicatedSLUMS; }
        set { _NotIndicatedSLUMS = value; }
    }

    public int? ScorePHQ2
    {
        get { return _ScorePHQ2; }
        set { _ScorePHQ2 = value; }
    }

    public bool NotIndicatedPHQ2
    {
        get { return _NotIndicatedPHQ2; }
        set { _NotIndicatedPHQ2 = value; }
    }

    public int? ScorePHQ9
    {
        get { return _ScorePHQ9; }
        set { _ScorePHQ9 = value; }
    }

    public bool NotIndicatedPHQ9
    {
        get { return _NotIndicatedPHQ9; }
        set { _NotIndicatedPHQ9 = value; }
    }

    public int? ScoreGAD7
    {
        get { return _ScoreGAD7; }
        set { _ScoreGAD7 = value; }
    }

    public bool NotIndicatedGAD7
    {
        get { return _NotIndicatedGAD7; }
        set { _NotIndicatedGAD7 = value; }
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

    #endregion
}