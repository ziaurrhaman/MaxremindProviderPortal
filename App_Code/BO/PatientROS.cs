using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PatientROS
/// </summary>
public class PatientROS
{
	public PatientROS()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    #region " Private Members "

    private Int64 _PatientROSId;
    private Int64 _ChartId;
    private Int64 _PatientId;
    private Int64 _PracticeId;
    private string _RosDetails = string.Empty;
    private string _Comments = string.Empty;
    private Int64 _CreatedById;
    private DateTime _CreatedDate;
    private Int64? _ModifiedById;
    private DateTime? _ModifiedDate;
    private bool _Deleted = false;
    
    #endregion

    #region " Properties "

    public Int64 PatientROSId
    {
        get { return _PatientROSId; }
        set { _PatientROSId = value; }
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

    public Int64 PracticeId
    {
        get { return _PracticeId; }
        set { _PracticeId = value; }
    }

    

    public string RosDetails
    {
        get { return _RosDetails; }
        set { _RosDetails = value; }
    }

   
    public string Comments
    {
        get { return _Comments; }
        set { _Comments = value; }
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