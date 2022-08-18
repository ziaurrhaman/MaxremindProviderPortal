using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ROSCategoryItems
/// </summary>
public class ROSCategoryItems
{
	public ROSCategoryItems()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    #region " Private Members "
    private int _ROSCategoryItemId;
    private int _ROSCategoryId;
    private string _ItemName;
    private int _Position = 0;
    private long _CreatedById;
    private DateTime _CreatedDate;
    private long _ModifiedById;
    private DateTime _ModifiedDate;    
    private bool _Deleted;
    #endregion

    #region " Properties "

    public int ROSCategoryItemId
    {
        get { return _ROSCategoryItemId; }
        set { _ROSCategoryItemId = value; }
    }

    public int ROSCategoryId
    {
        get { return _ROSCategoryId; }
        set { _ROSCategoryId = value; }
    }
    public string ItemName
    {
        get { return _ItemName; }
        set { _ItemName = value; }
    }
    public int Position
    {
        get { return _Position; }
        set { _Position = value; }
    }
    public DateTime CreatedDate
    {
        get { return _CreatedDate; }
        set { _CreatedDate = value; }
    }

    public long CreatedById
    {
        get { return _CreatedById; }
        set { _CreatedById = value; }
    }

    public DateTime ModifiedDate
    {
        get { return _ModifiedDate; }
        set { _ModifiedDate = value; }
    }

    public long ModifiedById
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