using System;

/// <summary>
/// Summary description for ChartVisitType
/// </summary>
public class ChartVisitType
{
	public ChartVisitType()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    #region " Private Members "

   private Int64 _VisitTypeId ;
   private string _Description = string.Empty;
   private Int64 _PracticeId;
   private Int64 _CreatedById;
   private DateTime _CreatedDate;
   private Int64? _ModifiedById;
   private DateTime? _ModifiedDate;

    bool _Deleted = false;
    #endregion

    #region " Properties "

    public Int64 VisitTypeId
    {
        get { return _VisitTypeId; }
        set { _VisitTypeId = value; }
    }

    public string Description
    {
        get { return _Description; }
        set { _Description = value; }
    }

    public Int64 PracticeId
    {
        get { return _PracticeId; }
        set { _PracticeId = value; }
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