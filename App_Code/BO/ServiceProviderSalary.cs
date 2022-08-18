using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ServiceProviderSalary
/// </summary>
public class ServiceProviderSalary
{
	public ServiceProviderSalary()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    #region " Private Members "

    private long _ServiceProviderSalaryId;
    private long _ServiceProviderId;
    private Nullable<decimal> _Salary;
    private string _SalaryType = string.Empty;
    private Nullable<decimal> _Commission;
    private string _CommissionType = string.Empty;
    
    private long _CreatedById;
    private DateTime _CreatedDate;
    private long _ModifiedById;
    private DateTime _ModifiedDate;
    
    private bool _Deleted = false;

    #endregion

    #region " Properties "

    public long ServiceProviderSalaryId
    {
        get { return _ServiceProviderSalaryId; }
        set { _ServiceProviderSalaryId = value; }
    }

    public long ServiceProviderId
    {
        get { return _ServiceProviderId; }
        set { _ServiceProviderId = value; }
    }

    public Nullable<decimal> Salary
    {
        get { return _Salary; }
        set { _Salary = value; }
    }

    public string SalaryType
    {
        get { return _SalaryType; }
        set { _SalaryType = value; }
    }

    public Nullable<decimal> Commission
    {
        get { return _Commission; }
        set { _Commission = value; }
    }

    public string CommissionType
    {
        get { return _CommissionType; }
        set { _CommissionType = value; }
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