using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MedicationRefillRequests
/// </summary>
public class MedicationRefillRequests
{
	public MedicationRefillRequests()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    #region " Private Members "

    Int64 _MedicationRefillRequestsId;
    Int64 _PatientId;
    Int64 _PracticeId;
    Int64 _PatientPrescriptionId;
    Int64 _MedicationCode;
    Int64 _PhramacyId;
    string _Phramacy = string.Empty;
    string _Address = string.Empty;
    string _City = string.Empty;
    string _State = string.Empty;
    string _ZipCode = string.Empty;
    string _Phone = string.Empty;
    string _Fax = string.Empty;
    string _Email = string.Empty;
    string _RequestStatus = string.Empty;
    string _RequestType = string.Empty;
    Int64 _CreatedById;
    DateTime _CreatedDate;
    Int64 _ModifiedById;
    DateTime _ModifiedDate;

    bool _Deleted = false;
    #endregion

    #region " Properties "

    public Int64 MedicationRefillRequestsId
    {
        get { return _MedicationRefillRequestsId; }
        set { _MedicationRefillRequestsId = value; }
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

    public Int64 PatientPrescriptionId
    {
        get { return _PatientPrescriptionId; }
        set { _PatientPrescriptionId = value; }
    }

    public Int64 MedicationCode
    {
        get { return _MedicationCode; }
        set { _MedicationCode = value; }
    }

    public Int64 PhramacyId
    {
        get { return _PhramacyId; }
        set { _PhramacyId = value; }
    }
    public string Phramacy
    {
        get { return _Phramacy; }
        set { _Phramacy = value; }
    }
    public string Address
    {
        get { return _Address; }
        set { _Address = value; }
    }

    public string City
    {
        get { return _City; }
        set { _City = value; }
    }

    public string State
    {
        get { return _State; }
        set { _State = value; }
    }

    public string ZipCode
    {
        get { return _ZipCode; }
        set { _ZipCode = value; }
    }

    public string Phone
    {
        get { return _Phone; }
        set { _Phone = value; }
    }

    public string Fax
    {
        get { return _Fax; }
        set { _Fax = value; }
    }

    public string Email
    {
        get { return _Email; }
        set { _Email = value; }
    }

    public string RequestStatus
    {
        get { return _RequestStatus; }
        set { _RequestStatus = value; }
    }

    public string RequestType
    {
        get { return _RequestType; }
        set { _RequestType = value; }
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