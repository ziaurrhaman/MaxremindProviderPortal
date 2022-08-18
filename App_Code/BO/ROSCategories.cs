using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ROSCategories
/// </summary>
public class ROSCategories
{
	public ROSCategories()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    
    #region " Private Members "
    
    private int _ROSCategoryId;
    private int _ROSTemplatesId;
    private string _CategoryName;
    private Int64 _PracticeId;
    private int _Position = 0;
    private DateTime _CreatedDate;
    private long _CreatedById;
    private DateTime? _ModifiedDate;
    private long _ModifiedById;    
    private bool _Deleted;
    
    private List<ROSCategoryItems> _listROSCategoryItems;
    
    #endregion
    
    #region " Properties "
    
    public int ROSCategoryId
    {
        get { return _ROSCategoryId; }
        set { _ROSCategoryId = value; }
    }
    
    public int ROSTemplatesId
    {
        get { return _ROSTemplatesId; }
        set { _ROSTemplatesId = value; }
    }
    
    public string CategoryName
    {
        get { return _CategoryName; }
        set { _CategoryName = value; }
    }
    public Int64 PracticeId
    {
        get { return _PracticeId; }
        set { _PracticeId = value; }
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

    public DateTime? ModifiedDate
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

    public List<ROSCategoryItems> listROSCategoryItems
    {
        get { return _listROSCategoryItems; }
        set { _listROSCategoryItems = value; }
    }

    #endregion
}