using System;


/// <summary>
/// Summary description for LabPointers
/// </summary>
public class LabPointers
{
	public LabPointers()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    #region " Private Members "

    private Int64 _PointerId;
    private Int64 _LabOrderId;
    private string _CptCode = string.Empty;
    private string _CptDescription = string.Empty;
    private DateTime _DosFrom;
    private DateTime _DosTo;
    private int? _Pointer1;
    private int? _Pointer2;
    private int? _Pointer3;
    private int? _Pointer4;
    private long _CreatedById;
    private DateTime _CreatedDate;
    private long _ModifiedById;
    private DateTime _ModifiedDate;
    private  bool _Deleted = false;
    #endregion
    #region " Properties "

    public Int64 PointerId
    {
        get { return _PointerId; }
        set { _PointerId = value; }
    }

    public Int64 LabOrderId
    {
        get { return _LabOrderId; }
        set { _LabOrderId = value; }
    }

    public string CptCode
    {
        get { return _CptCode; }
        set { _CptCode = value; }
    }

    public string CptDescription
    {
        get { return _CptDescription; }
        set { _CptDescription = value; }
    }

    public DateTime DosFrom
    {
        get { return _DosFrom; }
        set { _DosFrom = value; }
    }

    public DateTime DosTo
    {
        get { return _DosTo; }
        set { _DosTo = value; }
    }

    public int? Pointer1
    {
        get { return _Pointer1; }
        set { _Pointer1 = value; }
    }

    public int? Pointer2
    {
        get { return _Pointer2; }
        set { _Pointer2 = value; }
    }

    public int? Pointer3
    {
        get { return _Pointer3; }
        set { _Pointer3 = value; }
    }

    public int? Pointer4
    {
        get { return _Pointer4; }
        set { _Pointer4 = value; }
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