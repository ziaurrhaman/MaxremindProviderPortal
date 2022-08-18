using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for InsurancesCategory
/// </summary>
public class InsurancesCategory
{
	public InsurancesCategory()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    #region " Private Members "

    private int _InsuranceCategoryId;
    private string _CategoryName = string.Empty;
    private string _InsuranceCategory = string.Empty;
    private System.Nullable<int> _CreatedById;
    private System.Nullable<DateTime> _CreatedDate;
    private System.Nullable<int> _ModifiedById;
    private System.Nullable<DateTime> _ModifiedDate;
    private bool _InActive = false;
    private bool _Deleted = false;
    #endregion

    #region " Properties "

    public int InsuranceCategoryId
    {
        get { return _InsuranceCategoryId; }
        set { _InsuranceCategoryId = value; }
    }

    public string CategoryName
    {
        get { return _CategoryName; }
        set { _CategoryName = value; }
    }

    public string InsuranceCategory
    {
        get { return _InsuranceCategory; }
        set { _InsuranceCategory = value; }
    }

    public System.Nullable<int> CreatedById
    {
        get { return _CreatedById; }
        set { _CreatedById = value; }
    }

    public System.Nullable<DateTime> CreatedDate
    {
        get { return _CreatedDate; }
        set { _CreatedDate = value; }
    }

    public System.Nullable<int> ModifiedById
    {
        get { return _ModifiedById; }
        set { _ModifiedById = value; }
    }

    public System.Nullable<DateTime> ModifiedDate
    {
        get { return _ModifiedDate; }
        set { _ModifiedDate = value; }
    }

    public bool InActive
    {
        get { return _InActive; }
        set { _InActive = value; }
    }

    public bool Deleted
    {
        get { return _Deleted; }
        set { _Deleted = value; }
    }

    #endregion
}