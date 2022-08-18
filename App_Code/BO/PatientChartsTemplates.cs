using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PatientChartsTemplates
/// </summary>
public class PatientChartsTemplates
{
	public PatientChartsTemplates()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    #region " Private Members "
    Int64 _ChartTemplateId;
	string _TemplateType = string.Empty;
	string _TemplateName = string.Empty;
	string _TemplateText = string.Empty;
	bool _Shared = false;
    private Int64? _ServiceProviderId;
    private Int64 _PracticeId;
	private long _CreatedById;
    private DateTime _CreatedDate;
    private long _ModifiedById;
    private DateTime _ModifiedDate;
    private bool _Deleted = false;
    #endregion

    #region
    public Int64 ChartTemplateId
    {
        get { return _ChartTemplateId; }
        set { _ChartTemplateId = value; }
    }
    public string TemplateType
    {
        get { return _TemplateType; }
        set { _TemplateType = value; }
    }
    public string TemplateName
    {
        get { return _TemplateName; }
        set { _TemplateName = value; }
    }
    public string TemplateText
    {
        get { return _TemplateText; }
        set { _TemplateText = value; }
    }
    public bool Shared
    {
        get { return _Shared; }
        set { _Shared = value; }
    }
    public Int64? ServiceProviderId
    {
        get { return _ServiceProviderId; }
        set { _ServiceProviderId = value; }
    }

    public long PracticeId
    {
        get { return _PracticeId; }
        set { _PracticeId = value; }
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