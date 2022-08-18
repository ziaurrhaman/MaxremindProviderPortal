using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CompanyEMRModules
/// </summary>
public class CompanyEMRModules
{
	public CompanyEMRModules()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    #region " Private Members "

    Int64 _CompanyEMRModulesId;
    Int64 _CompanyModulesId;
    string _Scheduler = string.Empty;
    string _PatientManager = string.Empty;
    string _BillingManager = string.Empty;
    string _Message = string.Empty;
    string _Settings = string.Empty;
    string _TriageManager = string.Empty;
    string _CCM = string.Empty;
    private string _LabManager = string.Empty;
    Int64 _CreatedById;
    DateTime _CreatedDate;
    Int64 _ModifiedById;
    DateTime _ModifiedDate;

    bool _Deleted = false;
    #endregion

    #region " Properties "

    public Int64 CompanyEMRModulesId
    {
        get { return _CompanyEMRModulesId; }
        set { _CompanyEMRModulesId = value; }
    }

    public Int64 CompanyModulesId
    {
        get { return _CompanyModulesId; }
        set { _CompanyModulesId = value; }
    }

    public string Scheduler
    {
        get { return _Scheduler; }
        set { _Scheduler = value; }
    }

    public string PatientManager
    {
        get { return _PatientManager; }
        set { _PatientManager = value; }
    }

    public string BillingManager
    {
        get { return _BillingManager; }
        set { _BillingManager = value; }
    }

    public string Message
    {
        get { return _Message; }
        set { _Message = value; }
    }

    public string Settings
    {
        get { return _Settings; }
        set { _Settings = value; }
    }

    public string TriageManager
    {
        get { return _TriageManager; }
        set { _TriageManager = value; }
    }

    public string CCM
    {
        get { return _CCM; }
        set { _CCM = value; }
    }

    public  string LabManager
    {
        get { return _LabManager; }
        set { _LabManager = value; }
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