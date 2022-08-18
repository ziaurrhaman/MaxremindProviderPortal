using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PatientSocialHistory
/// </summary>
public class PatientSocialHistory
{
	public PatientSocialHistory()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    #region " Private Members "

    Int64 _SocialHistoryId ;
    Int64 _ChartId ;
    Int64 _PatientId ;
    string _MaritalStatus;
    string _Children;
    string _Education;
    string _Occupation;
    string _SexualOrientation;
    string _Exercise;
    string _DrugUse;
    string _SeatBelt;
    string _Exposure;
    bool _CafeineUse = false;
    string _CafeineDay;
    bool _AlcoholUse = false;
    string _AlcoholDay;
    string _AgeAtMenarche;
    DateTime? _LMP ;
    string _Cycle;
    string _Flow;
    string _Gravida;
    bool _Pregnant = false;
    DateTime? _Edd ;
    bool _Dysmenomhea = false;
    string _Para;
    Int64 _PracticeId ;
    Int64 _CreatedById ;
    DateTime _CreatedDate ;
    Int64 _ModifiedById ;
    DateTime _ModifiedDate ;

    bool _Deleted = false;
    #endregion

   

    public Int64 SocialHistoryId
    {
        get { return _SocialHistoryId; }
        set { _SocialHistoryId = value; }
    }

    public Int64 ChartId
    {
        get { return _ChartId; }
        set { _ChartId = value; }
    }

    public Int64 PatientId
    {
        get { return _PatientId; }
        set { _PatientId = value; }
    }

    public string MaritalStatus
    {
        get { return _MaritalStatus; }
        set { _MaritalStatus = value; }
    }

    public string Children
    {
        get { return _Children; }
        set { _Children = value; }
    }

    public string Education
    {
        get { return _Education; }
        set { _Education = value; }
    }

    public string Occupation
    {
        get { return _Occupation; }
        set { _Occupation = value; }
    }

    public string SexualOrientation
    {
        get { return _SexualOrientation; }
        set { _SexualOrientation = value; }
    }

    public string Exercise
    {
        get { return _Exercise; }
        set { _Exercise = value; }
    }

    public string DrugUse
    {
        get { return _DrugUse; }
        set { _DrugUse = value; }
    }

    public string SeatBelt
    {
        get { return _SeatBelt; }
        set { _SeatBelt = value; }
    }

    public string Exposure
    {
        get { return _Exposure; }
        set { _Exposure = value; }
    }

    public bool CafeineUse
    {
        get { return _CafeineUse; }
        set { _CafeineUse = value; }
    }

    public string CafeineDay
    {
        get { return _CafeineDay; }
        set { _CafeineDay = value; }
    }

    public bool AlcoholUse
    {
        get { return _AlcoholUse; }
        set { _AlcoholUse = value; }
    }

    public string AlcoholDay
    {
        get { return _AlcoholDay; }
        set { _AlcoholDay = value; }
    }

    public string AgeAtMenarche
    {
        get { return _AgeAtMenarche; }
        set { _AgeAtMenarche = value; }
    }

    public DateTime? LMP
    {
        get { return _LMP; }
        set { _LMP = value; }
    }

    public string Cycle
    {
        get { return _Cycle; }
        set { _Cycle = value; }
    }

    public string Flow
    {
        get { return _Flow; }
        set { _Flow = value; }
    }

    public string Gravida
    {
        get { return _Gravida; }
        set { _Gravida = value; }
    }

    public bool Pregnant
    {
        get { return _Pregnant; }
        set { _Pregnant = value; }
    }

    public DateTime? Edd
    {
        get { return _Edd; }
        set { _Edd = value; }
    }

    public bool Dysmenomhea
    {
        get { return _Dysmenomhea; }
        set { _Dysmenomhea = value; }
    }

    public string Para
    {
        get { return _Para; }
        set { _Para = value; }
    }

    public Int64 PracticeId
    {
        get { return _PracticeId; }
        set { _PracticeId = value; }
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
}