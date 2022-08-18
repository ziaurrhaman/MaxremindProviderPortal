using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for OrganTemplates
/// </summary>
public class OrganTemplates
{
	public OrganTemplates()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    #region " Private Members "

    long _OrganTemplatesId;
    string _TemplateName = string.Empty;
    string _TemplateType = string.Empty;
    long _ServiceProviderId;
    long _PracticeId;
    int _PracticeLocationsId;
    bool _IsActive = false;
    long _CreatedById;
    DateTime _CreatedDate;
    long _ModifiedById;
    DateTime _ModifiedDate;
    bool _Deleted = false;
    
    #endregion

    #region " Properties "

    public long OrganTemplatesId
    {
        get { return _OrganTemplatesId; }
        set { _OrganTemplatesId = value; }
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

    public int PracticeLocationsId
    {
        get { return _PracticeLocationsId; }
        set { _PracticeLocationsId = value; }
    }

    public bool IsActive
    {
        get { return _IsActive; }
        set { _IsActive = value; }
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