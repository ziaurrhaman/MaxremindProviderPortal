using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PatientReasonOfVisit
/// </summary>
public class PatientReasonOfVisit
{
	public PatientReasonOfVisit()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    #region " Private Members "

    private Int64 _ReasonOfVisitId ;
    private string _ReasonOfVisit = string.Empty;
    private string _HPI = string.Empty;
    private string _ProvidedBy = string.Empty;
    private Int64 _ReferringPhysicainId;
    private Int64 _PatientId;
    private Int64 _ChartId;
    private Int64 _PracticeId;
    private Int64 _CreatedById;
    private DateTime _CreatedDate;
    private Int64? _ModifiedById;
    private DateTime? _ModifiedDate;
    private bool _Deleted = false;
    
    #endregion

    #region " Properties "

    public Int64 ReasonOfVisitId
    {
        get { return _ReasonOfVisitId; }
        set { _ReasonOfVisitId = value; }
    }

    public string ReasonOfVisit
    {
        get { return _ReasonOfVisit; }
        set { _ReasonOfVisit = value; }
    }

    public string HPI
    {
        get { return _HPI; }
        set { _HPI = value; }
    }

    public string ProvidedBy
    {
        get { return _ProvidedBy; }
        set { _ProvidedBy = value; }
    }
    public Int64 ReferringPhysicainId
    {
        get { return _ReferringPhysicainId; }
        set { _ReferringPhysicainId = value; }
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

    public Int64? ModifiedById
    {
        get { return _ModifiedById; }
        set { _ModifiedById = value; }
    }

    public DateTime? ModifiedDate
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