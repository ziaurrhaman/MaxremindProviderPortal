using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class AppointmentDataSource
{
    public string events { get; set; }
    public string freebusys { get; set; }
    public List<PracticeLocations> businessHours { get; set; }
    public int userLength { get; set; }
    public bool isOffDay { get; set; }
    public List<ServiceProvider> serviceProviders { get; set; }
}