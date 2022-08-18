using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SupplyMaster
/// </summary>
public class SupplyMaster
{
	public SupplyMaster()
	{
		
	}
    #region " Private Members "

    Int64 _SupplyMasterId;
    long _PracticeId;
    string _HCPCSCode ;
    string _SupplyName ;
    string _SubCategory ;
    string _Package ;
    decimal _Charges;
    string _RevenueCode ;
    string _SupplyType ;
    bool _Active = false;
    long _CreatedById;
    DateTime _CreatedByDate;
    long _ModifiedById;
    DateTime _ModifiedByDate;

    bool _Deleted = false;
    #endregion

    #region " Properties "

    public Int64 SupplyMasterId
    {
        get { return _SupplyMasterId; }
        set { _SupplyMasterId = value; }
    }

    public long PracticeId
    {
        get { return _PracticeId; }
        set { _PracticeId = value; }
    }

    public string HCPCSCode
    {
        get { return _HCPCSCode; }
        set { _HCPCSCode = value; }
    }

    public string SupplyName
    {
        get { return _SupplyName; }
        set { _SupplyName = value; }
    }

    public string SubCategory
    {
        get { return _SubCategory; }
        set { _SubCategory = value; }
    }

    public string Package
    {
        get { return _Package; }
        set { _Package = value; }
    }

    public decimal Charges
    {
        get { return _Charges; }
        set { _Charges = value; }
    }

    public string RevenueCode
    {
        get { return _RevenueCode; }
        set { _RevenueCode = value; }
    }

    public string SupplyType
    {
        get { return _SupplyType; }
        set { _SupplyType = value; }
    }

    public bool Active
    {
        get { return _Active; }
        set { _Active = value; }
    }

    public long CreatedById
    {
        get { return _CreatedById; }
        set { _CreatedById = value; }
    }

    public DateTime CreatedByDate
    {
        get { return _CreatedByDate; }
        set { _CreatedByDate = value; }
    }

    public long ModifiedById
    {
        get { return _ModifiedById; }
        set { _ModifiedById = value; }
    }

    public DateTime ModifiedByDate
    {
        get { return _ModifiedByDate; }
        set { _ModifiedByDate = value; }
    }

    public bool Deleted
    {
        get { return _Deleted; }
        set { _Deleted = value; }
    }

    #endregion
}