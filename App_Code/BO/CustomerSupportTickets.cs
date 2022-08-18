using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CustomerSupportTickets
/// </summary>
public class CustomerSupportTickets
{
	public CustomerSupportTickets()
	{
		
	}
    #region Private Members

    int _CSTicketsId;
    long? _PracticeId;
    string _TicketType=string.Empty;
    string _ProblemRelatedTo = string.Empty;
    string _Priority = string.Empty;
    long? _PatientId ;
    long? _ClaimId;
    string _Insurance=string.Empty;
    string _PolicyNumber = string.Empty;  
    DateTime? _DOS; 
    string _Description = string.Empty;
    long? _AssignTo;
    string _Status = string.Empty;
    DateTime _CreatedDate;

    long _CreatedById;
    DateTime _ModifiedDate;
    long _ModifiedById;
    bool _Deleted;

    #endregion

    #region Properties

    public int CSTicketsId
    {
        get { return _CSTicketsId; }
        set { _CSTicketsId = value; }
    }

    public long? PracticeId
    {
        get { return _PracticeId; }
        set { _PracticeId = value; }
    }

    public string TicketType
    {
        get { return _TicketType; }
        set { _TicketType = value; }
    }

    public string ProblemRelatedTo
    {
        get { return _ProblemRelatedTo; }
        set { _ProblemRelatedTo = value; }
    }
    public string Priority
    {
        get { return _Priority; }
        set { _Priority = value; }
    }
    public long? PatientId
    {
        get { return _PatientId; }
        set { _PatientId = value; }
    }

    public long? ClaimId
    {
        get { return _ClaimId; }
        set { _ClaimId = value; }
    }
    public string Insurance 
    {
        get { return _Insurance; }
        set { _Insurance = value; }
    }
    public string PolicyNumber
    {
        get { return _PolicyNumber; }
        set { _PolicyNumber = value; }
    }

    public DateTime? DOS
    {
        get { return _DOS; }
        set { _DOS = value; }
    }

    public string Description
    {
        get { return _Description; }
        set { _Description = value; }
    }

    public long? AssignTo
    {
        get { return _AssignTo; }
        set { _AssignTo = value; }
    }

    public string Status
    {
        get { return _Status; }
        set { _Status = value; }
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