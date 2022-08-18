using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PatientImmunization
/// </summary>
public class PatientImmunization
{
	public PatientImmunization()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    #region " Private Members "

	long _PatientImmunizationId;
	DateTime _ImmunizationDate;
	string _ImmunizationName = string.Empty;
	string _Manufacturer = string.Empty;
	string _LotNumber = string.Empty;
	bool _NotPerformed = false;
	string _NotPerformedReason = string.Empty;
	string _CvxCode = string.Empty;
	string _ImmunizationDose = string.Empty;
	string _ImmunizationUnits = string.Empty;
	Nullable<DateTime> _ImmunizationTime;
	Nullable<DateTime> _ExpirationDate;
	string _Site = string.Empty;
	string _Routs = string.Empty;
	bool _IsCompleted = false;
	string _AdversReaction = string.Empty;
	string _Comments = string.Empty;
	Nullable<long> _PatientId;
	Nullable<long> _ImmunizationId;
	Nullable<long> _ChartId;
	Nullable<long> _CreatedById;
	Nullable<DateTime> _CreatedDate;
	Nullable<long> _ModifiedById;
	Nullable<DateTime> _ModifiedDate;
	bool _Deleted = false;

    #endregion

    #region " Properties "

    public long PatientImmunizationId
    {
        get { return _PatientImmunizationId; }
        set { _PatientImmunizationId = value; }
    }

    public DateTime ImmunizationDate
    {
        get { return _ImmunizationDate; }
        set { _ImmunizationDate = value; }
    }

    public string ImmunizationName
    {
        get { return _ImmunizationName; }
        set { _ImmunizationName = value; }
    }

    public string Manufacturer
    {
        get { return _Manufacturer; }
        set { _Manufacturer = value; }
    }

    public string LotNumber
    {
        get { return _LotNumber; }
        set { _LotNumber = value; }
    }

    public bool NotPerformed
    {
        get { return _NotPerformed; }
        set { _NotPerformed = value; }
    }

    public string NotPerformedReason
    {
        get { return _NotPerformedReason; }
        set { _NotPerformedReason = value; }
    }

    public string CvxCode
    {
        get { return _CvxCode; }
        set { _CvxCode = value; }
    }

    public string ImmunizationDose
    {
        get { return _ImmunizationDose; }
        set { _ImmunizationDose = value; }
    }

    public string ImmunizationUnits
    {
        get { return _ImmunizationUnits; }
        set { _ImmunizationUnits = value; }
    }

    public Nullable<DateTime> ImmunizationTime
    {
        get { return _ImmunizationTime; }
        set { _ImmunizationTime = value; }
    }

    public Nullable<DateTime> ExpirationDate
    {
        get { return _ExpirationDate; }
        set { _ExpirationDate = value; }
    }

    public string Site
    {
        get { return _Site; }
        set { _Site = value; }
    }

    public string Routs
    {
        get { return _Routs; }
        set { _Routs = value; }
    }

    public bool IsCompleted
    {
        get { return _IsCompleted; }
        set { _IsCompleted = value; }
    }

    public string AdversReaction
    {
        get { return _AdversReaction; }
        set { _AdversReaction = value; }
    }

    public string Comments
    {
        get { return _Comments; }
        set { _Comments = value; }
    }

    public Nullable<long> PatientId
    {
        get { return _PatientId; }
        set { _PatientId = value; }
    }

    public Nullable<long> ImmunizationId
    {
        get { return _ImmunizationId; }
        set { _ImmunizationId = value; }
    }

    public Nullable<long> ChartId
    {
        get { return _ChartId; }
        set { _ChartId = value; }
    }

    public Nullable<long> CreatedById
    {
        get { return _CreatedById; }
        set { _CreatedById = value; }
    }

    public Nullable<DateTime> CreatedDate
    {
        get { return _CreatedDate; }
        set { _CreatedDate = value; }
    }

    public Nullable<long> ModifiedById
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