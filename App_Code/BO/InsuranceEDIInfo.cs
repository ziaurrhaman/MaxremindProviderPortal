using System;

/// <summary>
/// Summary description for InsuranceEDIInfo
/// </summary>
public class InsuranceEDIInfo
{
	public InsuranceEDIInfo()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    #region " Private Members "

    private int _InsuranceEDIinfoID;
    private string _TransactionType = string.Empty;
    private string _SubmitterID = string.Empty;
    private string _ReceiverID = string.Empty;
    private string _ISA06 = string.Empty;
    private string _ISA08 = string.Empty;
    private string _ISA05 = string.Empty;
    private string _ISA07 = string.Empty;
    private string _GS02 = string.Empty;
    private string _GS03 = string.Empty;
    private string _ReceiverName = string.Empty;
    private string _SubmitterName = string.Empty;
    private string _SubmitterContactName = string.Empty;
    private string _SubmitterContactNumber = string.Empty;
    private string _ReceiverContactName = string.Empty;
    private string _ReceiverContactNumber = string.Empty;
    private Int64 _CreatedById;
    private DateTime _CreatedDate;
    private Int64 _ModifiedById;
    private DateTime _ModifiedDate;
    private bool _Deleted = false;
    #endregion

    #region " Properties "

    public int InsuranceEDIinfoID
    {
        get { return _InsuranceEDIinfoID; }
        set { _InsuranceEDIinfoID = value; }
    }

    public string TransactionType
    {
        get { return _TransactionType; }
        set { _TransactionType = value; }
    }

    public string SubmitterID
    {
        get { return _SubmitterID; }
        set { _SubmitterID = value; }
    }

    public string ReceiverID
    {
        get { return _ReceiverID; }
        set { _ReceiverID = value; }
    }

    public string ISA06
    {
        get { return _ISA06; }
        set { _ISA06 = value; }
    }

    public string ISA08
    {
        get { return _ISA08; }
        set { _ISA08 = value; }
    }

    public string ISA05
    {
        get { return _ISA05; }
        set { _ISA05 = value; }
    }

    public string ISA07
    {
        get { return _ISA07; }
        set { _ISA07 = value; }
    }

    public string GS02
    {
        get { return _GS02; }
        set { _GS02 = value; }
    }

    public string GS03
    {
        get { return _GS03; }
        set { _GS03 = value; }
    }

    public string ReceiverName
    {
        get { return _ReceiverName; }
        set { _ReceiverName = value; }
    }

    public string SubmitterName
    {
        get { return _SubmitterName; }
        set { _SubmitterName = value; }
    }

    public string SubmitterContactName
    {
        get { return _SubmitterContactName; }
        set { _SubmitterContactName = value; }
    }

    public string SubmitterContactNumber
    {
        get { return _SubmitterContactNumber; }
        set { _SubmitterContactNumber = value; }
    }

    public string ReceiverContactName
    {
        get { return _ReceiverContactName; }
        set { _ReceiverContactName = value; }
    }

    public string ReceiverContactNumber
    {
        get { return _ReceiverContactNumber; }
        set { _ReceiverContactNumber = value; }
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

    public Int64 ModifiedById
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