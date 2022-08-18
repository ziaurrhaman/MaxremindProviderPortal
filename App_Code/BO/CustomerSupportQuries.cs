
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class CustomerSupportQuries
{
    public CustomerSupportQuries()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    #region Private Members

    long _CustomerSupportQuryId;
    long? _PracticeId;
    string _Subject = string.Empty;
    DateTime? _RequestDate;
    DateTime? _ResponseDate;
    long? _AssignedTo;
    int? _StatusId;
    int? _DepartmentId;
    string _Description = string.Empty;
    string _Response = string.Empty;
    int? _CustomerSupportCommunicationMethodId;

    long _CreatedById;
    DateTime _CreatedDate;
    long _ModifiedById;
    DateTime _ModifiedDate;
    bool _Deleted;
    DateTime _Reminder;
    string _CustomerFeedback = string.Empty;
    int? _ProviderStatusId;
    int? _SupervisorStatusId;
    int? _CSOfficerStatusId;
    int? _Rating;

    #endregion

    #region Properties	

    public long CustomerSupportQuryId
    {
        get { return _CustomerSupportQuryId; }
        set { _CustomerSupportQuryId = value; }
    }

    public long? PracticeId
    {
        get { return _PracticeId; }
        set { _PracticeId = value; }
    }

    public string Subject
    {
        get { return _Subject; }
        set { _Subject = value; }
    }


    public DateTime? RequestDate
    {
        get { return _RequestDate; }
        set { _RequestDate = value; }
    }

    public DateTime? ResponseDate
    {
        get { return _ResponseDate; }
        set { _ResponseDate = value; }
    }

    public long? AssignedTo
    {
        get { return _AssignedTo; }
        set { _AssignedTo = value; }
    }

    public int? StatusId
    {
        get { return _StatusId; }
        set { _StatusId = value; }
    }



    public int? DepartmentId
    {
        get { return _DepartmentId; }
        set { _DepartmentId = value; }
    }

    public string Descriptions
    {
        get { return _Description; }
        set { _Description = value; }
    }

    public string Response
    {
        get { return _Response; }
        set { _Response = value; }
    }

    public int? CustomerSupportCommunicationMethodId
    {
        get { return _CustomerSupportCommunicationMethodId; }
        set { _CustomerSupportCommunicationMethodId = value; }
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
    public DateTime Reminder
    {
        get { return _Reminder; }
        set { _Reminder = value; }
    }
    public string CustomerFeedback
    {
        get { return _CustomerFeedback; }
        set { _CustomerFeedback = value; }
    }
    public int? ProviderStatusId
    {
        get { return _ProviderStatusId; }
        set { _ProviderStatusId = value; }
    }
    public int? SupervisorStatusId
    {
        get { return _SupervisorStatusId; }
        set { _SupervisorStatusId = value; }
    }
    public int? CSOfficerStatusId
    {
        get { return _CSOfficerStatusId; }
        set { _CSOfficerStatusId = value; }
    }
    public int? Rating
    {
        get { return _Rating; }
        set { _Rating = value; }
    }
    #endregion
}