using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for HipaaConsent
/// </summary>
public class HipaaConsent
{
	public HipaaConsent()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    #region " Private Members "

    Int64 _HipaaConsentId;
    Int64 _PatientId;
    DateTime? _SignedDate;
    string _Signed = string.Empty;
    string _RelationshipToPatient = string.Empty;
    Int64 _CreatedById;
    DateTime _CreatedDate;
    Int64 _ModifiedById;
    DateTime _ModifiedDate;

    bool _Deleted = false;
    #endregion

    #region " Properties "

    public Int64 HipaaConsentId
    {
        get { return _HipaaConsentId; }
        set { _HipaaConsentId = value; }
    }

    public Int64 PatientId
    {
        get { return _PatientId; }
        set { _PatientId = value; }
    }

    public DateTime? SignedDate
    {
        get { return _SignedDate; }
        set { _SignedDate = value; }
    }

    public string Signed
    {
        get { return _Signed; }
        set { _Signed = value; }
    }

    public string RelationshipToPatient
    {
        get { return _RelationshipToPatient; }
        set { _RelationshipToPatient = value; }
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