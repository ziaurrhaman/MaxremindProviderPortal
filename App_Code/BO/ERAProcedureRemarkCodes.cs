using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ProcedureRemarksCode
/// </summary>
public class ERAProcedureRemarkCodes
{
	public ERAProcedureRemarkCodes()
	{
		//
		// TODO: Add constructor logic here 
		//
	}

    #region " Private Members "

    long _ProcedurePaymentsId;
    Int64 _ERAProcedureRemarkCodeId;
    Int64 _ERAProcedurePaymentsId;
    Int64 _ERAProcedureAdjustmentsId;
    string _RemarkCodeQualifier;
    string _RemarkCode;
    Int64 _CreatedById;
    DateTime _CreatedDate;
    Int64 _ModifiedById;
    DateTime _ModifiedDate;

    bool _Deleted = false;
    #endregion

    #region " Properties "

    public Int64 ERAProcedureRemarkCodeId
    {
        get { return _ERAProcedureRemarkCodeId; }
        set { _ERAProcedureRemarkCodeId = value; }
    }

    public Int64 ERAProcedurePaymentsId
    {
        get { return _ERAProcedurePaymentsId; }
        set { _ERAProcedurePaymentsId = value; }
    }

    public Int64 ERAProcedureAdjustmentsId
    {
        get { return _ERAProcedureAdjustmentsId; }
        set { _ERAProcedureAdjustmentsId = value; }
    }

    public string RemarkCodeQualifier
    {
        get { return _RemarkCodeQualifier; }
        set { _RemarkCodeQualifier = value; }
    }

    public string RemarkCode
    {
        get { return _RemarkCode; }
        set { _RemarkCode = value; }
    }

    public long ProcedurePaymentsId
    {
        get { return _ProcedurePaymentsId; }
        set { _ProcedurePaymentsId = value; }
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

    #endregion

   
}