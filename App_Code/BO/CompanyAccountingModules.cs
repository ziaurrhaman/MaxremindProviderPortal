using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CompanyAccountingModules
/// </summary>
public class CompanyAccountingModules
{
	public CompanyAccountingModules()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    #region " Private Members "

    Int64 _CompanyAccountingModulesId;
    Int64 _CompanyModulesId;
    string _Sales = string.Empty;
    string _Purchase = string.Empty;
    string _ItemsAndInventory = string.Empty;
    string _Manufacturing = string.Empty;
    string _Dimensions = string.Empty;
    string _BankingAndGeneralLedger = string.Empty;
    private string _Setup;
    Int64 _CreatedById;
    DateTime _CreatedDate;
    Int64 _ModifiedById;
    DateTime _ModifiedDate;

    bool _Deleted = false;
    #endregion

    #region " Properties "

    public Int64 CompanyAccountingModulesId
    {
        get { return _CompanyAccountingModulesId; }
        set { _CompanyAccountingModulesId = value; }
    }

    public Int64 CompanyModulesId
    {
        get { return _CompanyModulesId; }
        set { _CompanyModulesId = value; }
    }

    public string Sales
    {
        get { return _Sales; }
        set { _Sales = value; }
    }

    public string Purchase
    {
        get { return _Purchase; }
        set { _Purchase = value; }
    }

    public string ItemsAndInventory
    {
        get { return _ItemsAndInventory; }
        set { _ItemsAndInventory = value; }
    }

    public string Manufacturing
    {
        get { return _Manufacturing; }
        set { _Manufacturing = value; }
    }

    public string Dimensions
    {
        get { return _Dimensions; }
        set { _Dimensions = value; }
    }

    public string BankingAndGeneralLedger
    {
        get { return _BankingAndGeneralLedger; }
        set { _BankingAndGeneralLedger = value; }
    }

    public  string Setup
    {
        get { return _Setup; }
        set { _Setup = value; }
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