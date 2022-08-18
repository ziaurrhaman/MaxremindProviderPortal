
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class ProcedureRemarkCodes
{
    public ProcedureRemarkCodes()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    #region Private Members

    long _ProcedureRemarkCodesId;
    long? _ProcedurePaymentsId;
    long? _ClaimId;
    string _RemarkCodeQualifier = string.Empty;
    string _RemarkCode = string.Empty;

    long _CreatedById;
    DateTime _CreatedDate;
    long _ModifiedById;
    DateTime _ModifiedDate;
    bool _Deleted;

    #endregion

    #region Properties

    public long ProcedureRemarkCodesId
    {
        get { return _ProcedureRemarkCodesId; }
        set { _ProcedureRemarkCodesId = value; }
    }

    public long? ProcedurePaymentsId
    {
        get { return _ProcedurePaymentsId; }
        set { _ProcedurePaymentsId = value; }
    }

    public long? ClaimId
    {
        get { return _ClaimId; }
        set { _ClaimId = value; }
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

    public long ModifiedById
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