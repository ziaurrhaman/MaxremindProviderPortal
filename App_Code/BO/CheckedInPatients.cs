
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class CheckedInPatients
{
    public CheckedInPatients()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    #region Private Members

    long _CheckedInPatientsId;
    
    long _PracticeId;
    long _PracticeLocationsId;

    long _AppointmentsId;
    long? _PatientId;
    DateTime? _AppointmentDate;
    DateTime? _ArrivalTime;
    int? _RoomId;
    DateTime? _TimeInRoom;
    DateTime? _CheckInTime;
    DateTime? _TimeInOffice;

    long _CreatedById;
    DateTime _CreatedDate;
    long _ModifiedById;
    DateTime _ModifiedDate;
    bool _Deleted;

    #endregion

    #region Properties

    public long CheckedInPatientsId
    {
        get { return _CheckedInPatientsId; }
        set { _CheckedInPatientsId = value; }
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

    public long AppointmentsId
    {
        get { return _AppointmentsId; }
        set { _AppointmentsId = value; }
    }

    public long? PatientId
    {
        get { return _PatientId; }
        set { _PatientId = value; }
    }

    public DateTime? AppointmentDate
    {
        get { return _AppointmentDate; }
        set { _AppointmentDate = value; }
    }

    public DateTime? ArrivalTime
    {
        get { return _ArrivalTime; }
        set { _ArrivalTime = value; }
    }

    public int? RoomId
    {
        get { return _RoomId; }
        set { _RoomId = value; }
    }

    public DateTime? TimeInRoom
    {
        get { return _TimeInRoom; }
        set { _TimeInRoom = value; }
    }

    public DateTime? CheckInTime
    {
        get { return _CheckInTime; }
        set { _CheckInTime = value; }
    }

    public DateTime? TimeInOffice
    {
        get { return _TimeInOffice; }
        set { _TimeInOffice = value; }
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