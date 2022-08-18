using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ItemTaxTypes
/// </summary>
public class ItemTaxTypes
{
	public ItemTaxTypes()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    
    #region " Private Members "
    
    private long _ItemTaxTypesId;
    private long _PracticeId;
    private string _Name = string.Empty;
    private double _Rate = double.MinValue;
    private bool _IsFullyTaxExempt = false;
    private string _Status = string.Empty;
    private long _CreatedById;
    private DateTime _CreatedDate;
    private Nullable<long> _ModifiedById;
    private Nullable<DateTime> _ModifiedDate;
    private bool _Deleted = false;
    
    #endregion
    
    #region " Properties "
    
    public long ItemTaxTypesId
    {
        get { return _ItemTaxTypesId; }
        set { _ItemTaxTypesId = value; }
    }
    
    public long PracticeId
    {
        get { return _PracticeId; }
        set { _PracticeId = value; }
    }
    
    public string Name
    {
        get { return _Name; }
        set { _Name = value; }
    }

    public double Rate
    {
        get { return _Rate; }
        set { _Rate = value; }
    }

    public bool IsFullyTaxExempt
    {
        get { return _IsFullyTaxExempt; }
        set { _IsFullyTaxExempt = value; }
    }

    public string Status
    {
        get { return _Status; }
        set { _Status = value; }
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

    public Nullable<long> ModifiedById
    {
        get { return _ModifiedById; }
        set { _ModifiedById = value; }
    }

    public Nullable<DateTime> ModifiedDate
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