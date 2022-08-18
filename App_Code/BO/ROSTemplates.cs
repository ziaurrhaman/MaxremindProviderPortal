using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ROSTemplates
/// </summary>
public class ROSTemplates
{
	public ROSTemplates()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    
    #region " Private Members "
    
    int _ROSTemplatesId;
    string _TemplateName = string.Empty;
    string _TemplateType = string.Empty;
    long _ServiceProviderId;
    long _PracticeId;
    Nullable<int> _PracticeLocationsId;
    long _CreatedById;
    DateTime _CreatedDate;
    long _ModifiedById;
    DateTime _ModifiedDate;
    bool _IsActive = false;
    bool _Deleted = false;

    private List<ROSCategories> _listROSCategories;
    
    #endregion
    
    #region " Properties "
    
    public int ROSTemplatesId
    {
        get { return _ROSTemplatesId; }
        set { _ROSTemplatesId = value; }
    }

    public string TemplateName
    {
        get { return _TemplateName; }
        set { _TemplateName = value; }
    }

    public string TemplateType
    {
        get { return _TemplateType; }
        set { _TemplateType = value; }
    }

    public long ServiceProviderId
    {
        get { return _ServiceProviderId; }
        set { _ServiceProviderId = value; }
    }

    public long PracticeId
    {
        get { return _PracticeId; }
        set { _PracticeId = value; }
    }

    public Nullable<int> PracticeLocationsId
    {
        get { return _PracticeLocationsId; }
        set { _PracticeLocationsId = value; }
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

    public bool IsActive
    {
        get { return _IsActive; }
        set { _IsActive = value; }
    }

    public bool Deleted
    {
        get { return _Deleted; }
        set { _Deleted = value; }
    }

    public List<ROSCategories> listROSCategories
    {
        get { return _listROSCategories; }
        set { _listROSCategories = value; }
    }

    #endregion
}