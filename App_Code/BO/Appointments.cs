using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Appointments
/// </summary>
public class Appointments
{
    public Appointments()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    
    #region " Private Members "
    
    private long _AppointmentsId;
    long _PracticeId;
    private long _PracticeLocationsId;
    private int? _ReasonId;
    private long? _PatientId;
    private long? _ServiceProviderId;
    private int? _ResourceId;
    string _Notes = string.Empty;
    private DateTime _AppointmentDate;
    private DateTime _StartTime;
    private DateTime _EndTime;
    private decimal? _TotalCharges;
    private int? _AppointmentTypeId;
    public int? CheckInRoomId { get; set; }
    public DateTime? CheckInTime { get; set; }
    string _DeleteReason = string.Empty;
    string _BookingReferenceNo = string.Empty;
    private int? _StatusId;


    public long? ParentAppointmentId { get; set; }
    
    private bool _IsRecurrence = false;
    public bool IsRecurrence
    {
        get { return _IsRecurrence; }
        set { _IsRecurrence = value; }
    }
    
    public string RecurrenceDays { get; set; }
    public int? RecurrenceFrequency { get; set; }
    public string RecurrenceUnit { get; set; }
    
    private long? _CreatedById;
    private DateTime _CreatedDate;
    private long? _ModifiedById;
    private DateTime _ModifiedDate;
    bool _Deleted = false;
    
    #endregion
    
    #region " Properties "

    public long AppointmentsId
    {
        get { return _AppointmentsId; }
        set { _AppointmentsId = value; }
    }

    public long PracticeId
    {
        get { return _PracticeId; }
        set { _PracticeId = value; }
    }

    public long PracticeLocationsId
    {
        get { return _PracticeLocationsId; }
        set { _PracticeLocationsId = value; }
    }

    public int? ReasonId
    {
        get { return _ReasonId; }
        set { _ReasonId = value; }
    }

    public long? PatientId
    {
        get { return _PatientId; }
        set { _PatientId = value; }
    }

    public long? ServiceProviderId
    {
        get { return _ServiceProviderId; }
        set { _ServiceProviderId = value; }
    }

    public int? ResourceId
    {
        get { return _ResourceId; }
        set { _ResourceId = value; }
    }

    public string Notes
    {
        get { return _Notes; }
        set { _Notes = value; }
    }

    public DateTime AppointmentDate
    {
        get { return _AppointmentDate; }
        set { _AppointmentDate = value; }
    }

    public DateTime StartTime
    {
        get { return _StartTime; }
        set { _StartTime = value; }
    }

    public DateTime EndTime
    {
        get { return _EndTime; }
        set { _EndTime = value; }
    }

    public decimal? TotalCharges
    {
        get { return _TotalCharges; }
        set { _TotalCharges = value; }
    }

    public string DeleteReason
    {
        get { return _DeleteReason; }
        set { _DeleteReason = value; }
    }

    public string BookingReferenceNo
    {
        get { return _BookingReferenceNo; }
        set { _BookingReferenceNo = value; }
    }

    public int? StatusId
    {
        get { return _StatusId; }
        set { _StatusId = value; }
    }

    public int? AppointmentTypeId
    {
        get { return _AppointmentTypeId; }
        set { _AppointmentTypeId = value; }
    }

    public long? CreatedById
    {
        get { return _CreatedById; }
        set { _CreatedById = value; }
    }

    public DateTime CreatedDate
    {
        get { return _CreatedDate; }
        set { _CreatedDate = value; }
    }

    public long? ModifiedById
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