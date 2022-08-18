using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
/// <summary>
/// Summary description for ServiceProviders
/// </summary>
public class ServiceProviderMaster
{
    public ServiceProviderMaster()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region " Private Members "

    private int _ServiceProviderTypeId;
    private string _ProviderType;
    private int _CreatedById;
    private DateTime _CreatedByDate;
    private int _ModifiedById;
    private DateTime _ModifiedByDate;

    #endregion
    #region " Properties "

    public int ServiceProviderTypeId
    {
        get { return _ServiceProviderTypeId; }
        set { _ServiceProviderTypeId = value; }
    }

    public string ProviderType
    {
        get { return _ProviderType; }
        set { _ProviderType = value; }
    }

    public int CreatedById
    {
        get { return _CreatedById; }
        set { _CreatedById = value; }
    }

    public DateTime CreatedByDate
    {
        get { return _CreatedByDate; }
        set { _CreatedByDate = value; }
    }

    public int ModifiedById
    {
        get { return _ModifiedById; }
        set { _ModifiedById = value; }
    }

    public DateTime ModifiedByDate
    {
        get { return _ModifiedByDate; }
        set { _ModifiedByDate = value; }
    }

    #endregion
}