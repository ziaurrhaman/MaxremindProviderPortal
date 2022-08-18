using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for HIPAAMedicalInformationRelease
/// </summary>
public class HIPAAMedicalInformationRelease
{
	public HIPAAMedicalInformationRelease()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    #region " Private Members "

    Int64 _HIPAAMedicalInformationReleaseId;
    Int64 _PatientId ;
    bool _PatientAuthorize = false;
    bool _SpouseAuthorize = false;
    string _SpouseName = string.Empty;
    bool _ChildAuthorize = false;
    string _ChildName = string.Empty;
    bool _OtherAuthorize = false;
    string _OtherName = string.Empty;
    bool _NoAuthorization = false;
    bool _HomeMessage = false;
    bool _OfficeMessage = false;
    bool _CellPhoneMessage = false;
    string _CellNumber = string.Empty;
    bool _DetailedMessage = false;
    bool _ReturnCall = false;
    string _OtherMessageText = string.Empty;
    bool _OtherMessage = false;
    string _DayMessage = string.Empty;
    string _TimeMessage = string.Empty;
    string _PatientSigned = string.Empty;
    DateTime? _PatientSignedDate;
    string _WitnessSigned = string.Empty;
    DateTime? _WitnessSignedDate;
    Int64 _CreatedById;
    DateTime _CreatedDate;
    Int64 _ModifiedById;
    DateTime _ModifiedDate;

    bool _Deleted = false;
    #endregion

    #region " Properties "

    public Int64 HIPAAMedicalInformationReleaseId
    {
        get { return _HIPAAMedicalInformationReleaseId; }
        set { _HIPAAMedicalInformationReleaseId = value; }
    }

    public Int64 PatientId
    {
        get { return _PatientId; }
        set { _PatientId = value; }
    }

    public bool PatientAuthorize
    {
        get { return _PatientAuthorize; }
        set { _PatientAuthorize = value; }
    }

    public bool SpouseAuthorize
    {
        get { return _SpouseAuthorize; }
        set { _SpouseAuthorize = value; }
    }

    public string SpouseName
    {
        get { return _SpouseName; }
        set { _SpouseName = value; }
    }

    public bool ChildAuthorize
    {
        get { return _ChildAuthorize; }
        set { _ChildAuthorize = value; }
    }

    public string ChildName
    {
        get { return _ChildName; }
        set { _ChildName = value; }
    }

    public bool OtherAuthorize
    {
        get { return _OtherAuthorize; }
        set { _OtherAuthorize = value; }
    }

    public string OtherName
    {
        get { return _OtherName; }
        set { _OtherName = value; }
    }
    public bool NoAuthorization
    {
        get { return _NoAuthorization; }
        set { _NoAuthorization = value; }
    }
    public bool HomeMessage
    {
        get { return _HomeMessage; }
        set { _HomeMessage = value; }
    }

    public bool OfficeMessage
    {
        get { return _OfficeMessage; }
        set { _OfficeMessage = value; }
    }

    public bool CellPhoneMessage
    {
        get { return _CellPhoneMessage; }
        set { _CellPhoneMessage = value; }
    }

    public string CellNumber
    {
        get { return _CellNumber; }
        set { _CellNumber = value; }
    }

    public bool DetailedMessage
    {
        get { return _DetailedMessage; }
        set { _DetailedMessage = value; }
    }

    public bool ReturnCall
    {
        get { return _ReturnCall; }
        set { _ReturnCall = value; }
    }

    public string OtherMessageText
    {
        get { return _OtherMessageText; }
        set { _OtherMessageText = value; }
    }
    public bool OtherMessage
    {
        get { return _OtherMessage; }
        set { _OtherMessage = value; }
    }
    public string DayMessage
    {
        get { return _DayMessage; }
        set { _DayMessage = value; }
    }

    public string TimeMessage
    {
        get { return _TimeMessage; }
        set { _TimeMessage = value; }
    }

    public string PatientSigned
    {
        get { return _PatientSigned; }
        set { _PatientSigned = value; }
    }

    public DateTime? PatientSignedDate
    {
        get { return _PatientSignedDate; }
        set { _PatientSignedDate = value; }
    }

    public string WitnessSigned
    {
        get { return _WitnessSigned; }
        set { _WitnessSigned = value; }
    }

    public DateTime? WitnessSignedDate
    {
        get { return _WitnessSignedDate; }
        set { _WitnessSignedDate = value; }
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