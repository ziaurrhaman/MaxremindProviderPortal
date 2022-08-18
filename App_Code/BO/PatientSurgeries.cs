using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PatientSurgery
/// </summary>
public class PatientSurgeries
{
    public PatientSurgeries()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    #region " Private Members "

    Int64 _SurgeryId;
    Int64 _PatientId;
    Int64 _ChartId;
    Int64 _PracticeId;
    DateTime _SurgeryDate;
    string _ProcedureCode = string.Empty;
    string _Comments = string.Empty;
    bool _Deleted = false;
    Int64 _CreatedById;
    DateTime _CreatedDate;
    Int64 _ModifiedById;

    DateTime _ModifiedDate;
    #endregion

    #region " Properties "

    public Int64 SurgeryId
    {
        get { return _SurgeryId; }
        set { _SurgeryId = value; }
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

    public DateTime SurgeryDate
    {
        get { return _SurgeryDate; }
        set { _SurgeryDate = value; }
    }

    public string ProcedureCode
    {
        get { return _ProcedureCode; }
        set { _ProcedureCode = value; }
    }

    public string Comments
    {
        get { return _Comments; }
        set { _Comments = value; }
    }

    public bool Deleted
    {
        get { return _Deleted; }
        set { _Deleted = value; }
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

    #endregion
}