using System;

/// <summary>
/// Summary description for PatientAllergy
/// </summary>
public class PatientAllergy
{
	public PatientAllergy()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    #region " Private Members "
    private Int64 _AllergyId;
    private Int64 _PatientId;
    private Int64? _ChartId;
    private Int64 _PracticeId;
    private int? _AllergyCode;
    private int? _SeverityId;
    private int? _AllergyTypeId;
    private string _Status = string.Empty;
    private string _Reaction = string.Empty;
    private bool _OnSet = false;
    private DateTime? _OnSetDate;
    private bool _Resolved = false;
    private DateTime? _ResolvedDate;
    private bool _Reviewed = false;
    private DateTime? _ReviewedDate;
    private string _ReviewedBy = string.Empty;
    private bool _Confidential = false;
    private Int64? _CreatedById;
    private DateTime _CreatedDate;
    private Int64? _ModifiedById;
    private DateTime? _ModifiedDate;
    private bool _Deleted;
    #endregion

    #region " Properties "

    public Int64 AllergyId
    {
        get { return _AllergyId; }
        set { _AllergyId = value; }
    }

    public Int64 PatientId
    {
        get { return _PatientId; }
        set { _PatientId = value; }
    }

    public Int64? ChartId
    {
        get { return _ChartId; }
        set { _ChartId = value; }
    }
    public Int64 PracticeId
    {
        get { return _PracticeId; }
        set { _PracticeId = value; }
    }
    public int? AllergyCode
    {
        get { return _AllergyCode; }
        set { _AllergyCode = value; }
    }

    public int? SeverityId
    {
        get { return _SeverityId; }
        set { _SeverityId = value; }
    }

    public int? AllergyTypeId
    {
        get { return _AllergyTypeId; }
        set { _AllergyTypeId = value; }
    }

    public string Status
    {
        get { return _Status; }
        set { _Status = value; }
    }

    public string Reaction
    {
        get { return _Reaction; }
        set { _Reaction = value; }
    }

    public bool OnSet
    {
        get { return _OnSet; }
        set { _OnSet = value; }
    }

    public DateTime? OnSetDate
    {
        get { return _OnSetDate; }
        set { _OnSetDate = value; }
    }

    public bool Resolved
    {
        get { return _Resolved; }
        set { _Resolved = value; }
    }

    public DateTime? ResolvedDate
    {
        get { return _ResolvedDate; }
        set { _ResolvedDate = value; }
    }

    public bool Reviewed
    {
        get { return _Reviewed; }
        set { _Reviewed = value; }
    }

    public DateTime? ReviewedDate
    {
        get { return _ReviewedDate; }
        set { _ReviewedDate = value; }
    }

    public string ReviewedBy
    {
        get { return _ReviewedBy; }
        set { _ReviewedBy = value; }
    }

    public bool Confidential
    {
        get { return _Confidential; }
        set { _Confidential = value; }
    }

    public Int64? CreatedById
    {
        get { return _CreatedById; }
        set { _CreatedById = value; }
    }

    public DateTime CreatedDate
    {
        get { return _CreatedDate; }
        set { _CreatedDate = value; }
    }

    public Int64? ModifiedById
    {
        get { return _ModifiedById; }
        set { _ModifiedById = value; }
    }

    public DateTime? ModifiedDate
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