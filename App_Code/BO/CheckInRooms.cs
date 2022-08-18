using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CheckInRooms
/// </summary>
public class CheckInRooms
{
    public CheckInRooms()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    #region " Private Members "

    int _RoomId = 0;
    string _Name = string.Empty;
    string _RoomNo = string.Empty;
    int _RoomTypeId = 0;
    long _PracticeId = 0;
    int _PracticeLocationsId = 0;
    long _CreatedById = 0;
    DateTime _CreatedDate;
    long _ModifiedById;
    DateTime _ModifiedDate;

    bool _Deleted = false;
    #endregion

    #region " Properties "

    public int RoomId
    {
        get { return _RoomId; }
        set { _RoomId = value; }
    }

    public string Name
    {
        get { return _Name; }
        set { _Name = value; }
    }
    public string RoomNo
    {
        get { return _RoomNo; }
        set { _RoomNo = value; }
    }
    public int RoomTypeId
    {
        get { return _RoomTypeId; }
        set { _RoomTypeId = value; }
    }
    public long PracticeId
    {
        get { return _PracticeId; }
        set { _PracticeId = value; }
    }
    public int PracticeLocationsId
    {
        get { return _PracticeLocationsId; }
        set { _PracticeLocationsId = value; }
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
