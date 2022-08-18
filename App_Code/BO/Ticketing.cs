using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Ticketing
/// </summary>
public class Ticketing
{
    public Ticketing()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    #region " Private Members "

    private long _TicketId;
    private string _Title;
    private string _PracticeId;
    private string _Category;
    private long _ReportedBy;
    private DateTime _ReportedOn;
    private string _Priority;
    private string _Status;
    private string _Description;
    private string _Attachements;
    private DateTime _CreatedDate;
    private long _CreatedById;
    private Nullable<DateTime> _ModifiedDate;
    private Nullable<int> _ModifiedById;
    private bool _Deleted = false;

    #endregion

    #region " Properties "

    public long TicketId
    {
        get { return _TicketId; }
        set { _TicketId = value; }
    }

    public string Title
    {
        get { return _Title; }
        set { _Title = value; }
    }

    public string PracticeId 
    {
        get { return _PracticeId; }
        set { _PracticeId = value; }
    }

    public string Category
    {
        get { return _Category; }
        set { _Category = value; }
    }

    public long ReportedBy
    {
        get { return _ReportedBy; }
        set { _ReportedBy = value; }
    }

    public DateTime ReportedOn
    {
        get { return _ReportedOn; }
        set { _ReportedOn = value; }
    }
    public string Priority
    {
        get { return _Priority; }
        set { _Priority = value; }
    }
    public string Status
    {
        get { return _Status; }
        set { _Status = value; }
    }
    public string Description
    {
        get { return _Description; }
        set { _Description = value; }
    }
    public string Attachements
    {
        get { return _Attachements; }
        set { _Attachements = value; }
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

    public Nullable<DateTime> ModifiedDate
    {
        get { return _ModifiedDate; }
        set { _ModifiedDate = value; }
    }

    public Nullable<int> ModifiedById
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