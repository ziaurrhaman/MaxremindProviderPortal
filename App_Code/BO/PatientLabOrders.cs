using System;

/// <summary>
/// Summary description for PatientLabOrders
/// </summary>
public class PatientLabOrders
{
	public PatientLabOrders()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    #region " Private Members "

    private Int64 _PatientOrderId ;
    private Int64 _PatientId;
    private Int64 _PracticeId;
    private Int64 _ProviderId;
    private Int64 _LabId;
    private Int64 _LocationId;
    private DateTime _OrderDate;
    private DateTime _DueDate;
    private string _AssignedTo = string.Empty;
    private string _PromptTo = string.Empty;
    private string _Fasting = string.Empty;
    private bool _Stat = false;
    private bool _PscHold = false;
    private string _Comments = string.Empty;
    private string _Status = string.Empty;
    private string _Priority = string.Empty;
    private string _BillType = string.Empty;
    private bool _NotPerformed = false;
    private string _NotPerformedReason = string.Empty;
    private bool _ReadyToSend = false;
    private bool _OrderSent = false;
    private string _OrderSentDate = string.Empty;
    private long _CreatedById;
    private DateTime _CreatedDate;
    private long _ModifiedById;
    private DateTime _ModifiedDate;
    private bool _Deleted = false;
    private long _ChartId;
    private string _OrderType = string.Empty;
    #endregion

    #region " Properties "

    public Int64 PatientOrderId
    {
        get { return _PatientOrderId; }
        set { _PatientOrderId = value; }
    }

    public Int64 PatientId
    {
        get { return _PatientId; }
        set { _PatientId = value; }
    }
   
    public Int64 PracticeId
    {
        get { return _PracticeId; }
        set { _PracticeId = value; }
    }

    public Int64 ProviderId
    {
        get { return _ProviderId; }
        set { _ProviderId = value; }
    }

    public Int64 LabId
    {
        get { return _LabId; }
        set { _LabId = value; }
    }

    public Int64 LocationId
    {
        get { return _LocationId; }
        set { _LocationId = value; }
    }

    public DateTime OrderDate
    {
        get { return _OrderDate; }
        set { _OrderDate = value; }
    }

    public DateTime DueDate
    {
        get { return _DueDate; }
        set { _DueDate = value; }
    }

    public string AssignedTo
    {
        get { return _AssignedTo; }
        set { _AssignedTo = value; }
    }

    public string PromptTo
    {
        get { return _PromptTo; }
        set { _PromptTo = value; }
    }

    public string Fasting
    {
        get { return _Fasting; }
        set { _Fasting = value; }
    }

    public bool Stat
    {
        get { return _Stat; }
        set { _Stat = value; }
    }

    public bool PscHold
    {
        get { return _PscHold; }
        set { _PscHold = value; }
    }

    public string Comments
    {
        get { return _Comments; }
        set { _Comments = value; }
    }

    public string Status
    {
        get { return _Status; }
        set { _Status = value; }
    }

    public string Priority
    {
        get { return _Priority; }
        set { _Priority = value; }
    }

    public string BillType
    {
        get { return _BillType; }
        set { _BillType = value; }
    }

    public bool NotPerformed
    {
        get { return _NotPerformed; }
        set { _NotPerformed = value; }
    }

    public string NotPerformedReason
    {
        get { return _NotPerformedReason; }
        set { _NotPerformedReason = value; }
    }

    public bool ReadyToSend
    {
        get { return _ReadyToSend; }
        set { _ReadyToSend = value; }
    }

    public bool OrderSent
    {
        get { return _OrderSent; }
        set { _OrderSent = value; }
    }

    public string OrderSentDate
    {
        get { return _OrderSentDate; }
        set { _OrderSentDate = value; }
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
    public Int64 ChartId
    {
        get { return _ChartId; }
        set { _ChartId = value; }
    }
    public string OrderType
    {
        get { return _OrderType; }
        set { _OrderType = value; }
    }
    #endregion
}