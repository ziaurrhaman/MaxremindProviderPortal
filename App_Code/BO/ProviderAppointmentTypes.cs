using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ProviderAppointmentTypes
/// </summary>
public class ProviderAppointmentTypes
{
	public ProviderAppointmentTypes()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    
    #region " Private Members "
    
    int _ProviderAppointmentTypeId;
    int _ServiceProviderId;
    int _AppointmentTypeId;
    TimeSpan _DefaultTime;
    
    private long? _CreatedById;
    private DateTime? _CreatedDate;
    private long? _ModifiedById;
    private DateTime? _ModifiedDate;
    bool _Deleted = false;
    
    #endregion
    
    #region " Properties "
    
    public int ProviderAppointmentTypeId
    {
        get { return _ProviderAppointmentTypeId; }
        set { _ProviderAppointmentTypeId = value; }
    }
    
    public int ServiceProviderId
    {
        get { return _ServiceProviderId; }
        set { _ServiceProviderId = value; }
    }
    
    public int AppointmentTypeId
    {
        get { return _AppointmentTypeId; }
        set { _AppointmentTypeId = value; }
    }
    
    public TimeSpan DefaultTime
    {
        get { return _DefaultTime; }
        set { _DefaultTime = value; }
    }
    
    public long? CreatedById
    {
        get { return _CreatedById; }
        set { _CreatedById = value; }
    }
    
    public DateTime? CreatedDate
    {
        get { return _CreatedDate; }
        set { _CreatedDate = value; }
    }
    
    public long? ModifiedById
    {
        get { return _ModifiedById; }
        set { _ModifiedById = value; }
    }
    
    public DateTime? ModifiedDate
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