using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PatientDocument
/// </summary>
public class PatientDocuments
{
	public PatientDocuments()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    #region " Private Members "

    Int64 _DocumentId;
    Int64 _PatientId;
    int _CategoryId;
    string _Status = string.Empty;
    DateTime? _DocumentDate;
    bool _IsConfedential = false;
    string _DocumentName = string.Empty;
    string _DocumentPath = string.Empty;
    Int64 _AssignedTo;
    bool _Signed = false;
    Int64 _SignedById;
    DateTime? _SignDate;
    string _Comments = string.Empty;
    Int64 _CreatedById;
    DateTime _CreatedDate;
    Int64 _ModifiedById;
    DateTime _ModifiedDate;

    bool _Deleted = false;
    #endregion

    #region " Properties "

    public Int64 DocumentId
    {
        get { return _DocumentId; }
        set { _DocumentId = value; }
    }

    public Int64 PatientId
    {
        get { return _PatientId; }
        set { _PatientId = value; }
    }

    public int CategoryId
    {
        get { return _CategoryId; }
        set { _CategoryId = value; }
    }

    public string Status
    {
        get { return _Status; }
        set { _Status = value; }
    }

    public DateTime? DocumentDate
    {
        get { return _DocumentDate; }
        set { _DocumentDate = value; }
    }

    public bool IsConfedential
    {
        get { return _IsConfedential; }
        set { _IsConfedential = value; }
    }

    public string DocumentName
    {
        get { return _DocumentName; }
        set { _DocumentName = value; }
    }

    public string DocumentPath
    {
        get { return _DocumentPath; }
        set { _DocumentPath = value; }
    }

    public Int64 AssignedTo
    {
        get { return _AssignedTo; }
        set { _AssignedTo = value; }
    }

    public bool Signed
    {
        get { return _Signed; }
        set { _Signed = value; }
    }

    public Int64 SignedById
    {
        get { return _SignedById; }
        set { _SignedById = value; }
    }

    public DateTime? SignDate
    {
        get { return _SignDate; }
        set { _SignDate = value; }
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