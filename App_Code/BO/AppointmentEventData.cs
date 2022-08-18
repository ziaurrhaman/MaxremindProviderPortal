using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class AppointmentEventData
{
    public string id { get; set; }
    public string PatientId { get; set; }
    public string PatientName { get; set; }
    public string start { get; set; }
    public string end { get; set; }
    public string title { get; set; }
    public string titleId { get; set; }
    public string Srv_back_color { get; set; }
    public string providerId { get; set; }
    
    public string status { get; set; }
    public string status_back_color { get; set; }
    public string reason_back_color { get; set; }
    public string statusId { get; set; }
    public List<Statuses> status_list { get; set; }
    public int userId { get; set; }
    public string reasonId { get; set; }
    public string Notes { get; set; }
    public string BookingReferenceNo { get; set; }
    
    public string EligibilityStatus { get; set; }
    public string EligibilityStatusClass { get; set; }
    
    public long ParentAppointmentId { get; set; }
    
    private bool _IsRecurrence = false;
    public bool IsRecurrence
    {
        get { return _IsRecurrence; }
        set { _IsRecurrence = value; }
    }
    
    public string RecurrenceDays { get; set; }
    public int RecurrenceFrequency { get; set; }
    public string RecurrenceUnit { get; set; }
    
    public string DateOfBirth { get; set; }
    public string Gender { get; set; }
    public string MaritalStatus { get; set; }
    public string Cell { get; set; }
    public string HomePhone { get; set; }
    public string WorkPhone { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Zip { get; set; }
    public string Address { get; set; }
    public string ImagePath { get; set; }
}