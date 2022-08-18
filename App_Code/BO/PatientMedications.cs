using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PatientMedications
/// </summary>
public class PatientMedications
{
	public PatientMedications()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    #region " Private Members "

    Int64 _PatientMedicationId;
    private Int64 _PracticeId;
    Int64 _PatientId;
    Int64? _ChartId;
    Int64? _MEDID;
    string _MedicationName = string.Empty;
    string _Sig = string.Empty;
    string _PrescribedBy = string.Empty;
    string _Reason = string.Empty;
    DateTime? _DateStarted;
    DateTime? _DateEnd;
    bool _IsTakingNow = false;
    string _Comments = string.Empty;
    bool _MedReconciliationComplete = false;
    private Nullable<long> _CreatedById;
    private Nullable<DateTime> _CreatedDate;
    private Nullable<long> _ModifiedById;
    private Nullable<DateTime> _ModifiedDate;
    private bool _Deleted = false;
    #endregion

    #region " Properties "

    public Int64 PatientMedicationId
    {
        get { return _PatientMedicationId; }
        set { _PatientMedicationId = value; }
    }
    public Int64 PracticeId
    {
        get { return _PracticeId; }
        set { _PracticeId = value; }
    }
    public Int64 PatientId
    {
        get { return _PatientId; }
        set { _PatientId = value; }
    }

    public Int64? ChartId
    {
        get { return _ChartId; }
        set { _ChartId = value; }
    }

    public Int64? MEDID
    {
        get { return _MEDID; }
        set { _MEDID = value; }
    }

    public string MedicationName
    {
        get { return _MedicationName; }
        set { _MedicationName = value; }
    }

    public string Sig
    {
        get { return _Sig; }
        set { _Sig = value; }
    }

    public string PrescribedBy
    {
        get { return _PrescribedBy; }
        set { _PrescribedBy = value; }
    }

    public string Reason
    {
        get { return _Reason; }
        set { _Reason = value; }
    }

    public DateTime? DateStarted
    {
        get { return _DateStarted; }
        set { _DateStarted = value; }
    }
    public DateTime? DateEnd
    {
        get { return _DateEnd; }
        set { _DateEnd = value; }
    }
    public bool IsTakingNow
    {
        get { return _IsTakingNow; }
        set { _IsTakingNow = value; }
    }

    public string Comments
    {
        get { return _Comments; }
        set { _Comments = value; }
    }

    public bool MedReconciliationComplete
    {
        get { return _MedReconciliationComplete; }
        set { _MedReconciliationComplete = value; }
    }

    public long? CreatedById
    {
        get { return _CreatedById; }
        set { _CreatedById = value; }
    }

    public System.Nullable<DateTime> CreatedDate
    {
        get { return _CreatedDate; }
        set { _CreatedDate = value; }
    }

    public long? ModifiedById
    {
        get { return _ModifiedById; }
        set { _ModifiedById = value; }
    }

    public System.Nullable<DateTime> ModifiedDate
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