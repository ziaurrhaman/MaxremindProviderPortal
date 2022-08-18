using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for TimeSettings
/// </summary>
public class TimeSettings
{
    public TimeSettings()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    #region " Private Members "

    private long _TimeSettingsId;
    private string _NameOfDay;
    private int _DayNumber;
    private long _BreakTypeId;
    private TimeSpan? _TimeFrom;
    private TimeSpan? _TimeTo;
    private TimeSpan? _BreakStart;
    private TimeSpan? _BreakEnd;
    private string _ResourceType;
    private int _ResourceId;
    private string _SettingType;
    private DateTime? _TimingStartDate;
    private DateTime? _TimingExpireDate;
    private bool _IsExpire = false;
    private bool _IsBlock = false;
    private long _CreatedById;
    private DateTime _CreatedDate;
    private System.Nullable<DateTime> _ModifiedDate;
    private long? _ModifiedById;
    private bool _Deleted = false;
    private List<TimeSettingsBreak> _listTimeSettingsBreak;
    private string _Time_From;
    private string _Time_To;
    
    #endregion

    #region " Properties "

    public long TimeSettingsId
    {
        get { return _TimeSettingsId; }
        set { _TimeSettingsId = value; }
    }

    public string NameOfDay
    {
        get { return _NameOfDay; }
        set { _NameOfDay = value; }
    }

    public int DayNumber
    {
        get { return _DayNumber; }
        set { _DayNumber = value; }
    }

    public int ResourceId
    {
        get { return _ResourceId; }
        set { _ResourceId = value; }
    }

    public TimeSpan? TimeFrom
    {
        get { return _TimeFrom; }
        set { _TimeFrom = value; }
    }

    public TimeSpan? TimeTo
    {
        get { return _TimeTo; }
        set { _TimeTo = value; }
    }

    public string Time_From
    {
        get { return _Time_From; }
        set { _Time_From = value; }
    }

    public string Time_To
    {
        get { return _Time_To; }
        set { _Time_To = value; }
    }
    public TimeSpan? BreakStart
    {
        get { return _BreakStart; }
        set { _BreakStart = value; }
    }

    public TimeSpan? BreakEnd
    {
        get { return _BreakEnd; }
        set { _BreakEnd = value; }
    }

    public string ResourceType
    {
        get { return _ResourceType; }
        set { _ResourceType = value; }
    }

    public long BreakTypeId
    {
        get { return _BreakTypeId; }
        set { _BreakTypeId = value; }
    }

    public string SettingType
    {
        get { return _SettingType; }
        set { _SettingType = value; }
    }

    public DateTime? TimingStartDate
    {
        get { return _TimingStartDate; }
        set { _TimingStartDate = value; }
    }

    public DateTime? TimingExpireDate
    {
        get { return _TimingExpireDate; }
        set { _TimingExpireDate = value; }
    }

    public bool IsExpire
    {
        get { return _IsExpire; }
        set { _IsExpire = value; }
    }
    public bool IsBlock
    {
        get { return _IsBlock; }
        set { _IsBlock = value; }
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

    public System.Nullable<DateTime> ModifiedDate
    {
        get { return _ModifiedDate; }
        set { _ModifiedDate = value; }
    }

    public long? ModifiedById
    {
        get { return _ModifiedById; }
        set { _ModifiedById = value; }
    }

    public bool Deleted
    {
        get { return _Deleted; }
        set { _Deleted = value; }
    }

    public List<TimeSettingsBreak> listTimeSettingsBreak
    {
        get { return _listTimeSettingsBreak; }
        set { _listTimeSettingsBreak = value; }
    }


    #endregion
}

