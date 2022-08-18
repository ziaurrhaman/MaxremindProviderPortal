using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PatientPhysicalExam
/// </summary>
public class PatientPhysicalExam
{
	public PatientPhysicalExam()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    #region " Private Members "

    private Int64 _PatientPhysicalExamId;
    private Int64 _PatientId;
    private Int64 _ChartId;
    private Int64 _PracticeId;
    private string _PEDetails = string.Empty;
    private Int64 _CreatedById;
    private DateTime _CreatedDate;
    private Int64? _ModifiedById;
    private DateTime? _ModifiedDate;

    bool _Deleted = false;
    #endregion

    #region " Properties "

    public Int64 PatientPhysicalExamId
    {
        get { return _PatientPhysicalExamId; }
        set { _PatientPhysicalExamId = value; }
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

    public string PEDetails
    {
        get { return _PEDetails; }
        set { _PEDetails = value; }
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