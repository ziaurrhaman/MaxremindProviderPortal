using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ProviderTaskSettings
/// </summary>
public class ProviderTaskSettings
{
    public ProviderTaskSettings()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    #region " Private Members "

    private long _ProviderTaskSettingsId;
    private long _TaskId;
    private long _TaskTypeId;
    private long _ServiceProviderId;
    private List<long> _ListAssignedProviders;
    private string _ProviderSkillLevel;
    private long _CreatedById;
    private DateTime _CreatedDate;
    private System.Nullable<DateTime> _ModifiedDate;
    private System.Nullable<int> _ModifiedById;
    private bool _Deleted = false;

    #endregion

    #region " Properties "

    public long ProviderTaskSettingsId
    {
        get { return _ProviderTaskSettingsId; }
        set { _ProviderTaskSettingsId = value; }
    }

    public long TaskTypeId
    {
        get { return _TaskTypeId; }
        set { _TaskTypeId = value; }
    }

    public long TaskId
    {
        get { return _TaskId; }
        set { _TaskId = value; }
    }

    public long ServiceProviderId
    {
        get { return _ServiceProviderId; }
        set { _ServiceProviderId = value; }
    }

    public List<long> ListAssignedProviders
    {
        get { return _ListAssignedProviders; }
        set { _ListAssignedProviders = value; }
    }

    public string ProviderSkillLevel
    {
        get { return _ProviderSkillLevel; }
        set { _ProviderSkillLevel = value; }
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

    public System.Nullable<int> ModifiedById
    {
        get { return _ModifiedById; }
        set { _ModifiedById = value; }
    }

    public bool Deleted
    {
        get { return _Deleted; }
        set { _Deleted = value; }
    }

    #endregion

}