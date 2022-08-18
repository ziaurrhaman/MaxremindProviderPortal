using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ReportVital
/// </summary>
public class ReportVital
{
    public ReportVital()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    //public List<ReportVitalPulse> ReportVitalPulse { get; set; }
    //public List<ReportVitalTemperature> ReportVitalTemperature { get; set; }
    //public List<ReportVitalBloodPressure> ReportVitalBloodPressure { get; set; }
    //public List<ReportVitalRespiratory> ReportVitalRespiratory { get; set; }
    //public List<ReportVitalWeight> ReportVitalWeight { get; set; }

    #region " Private Members "

    string _Date;
    string _TimeIn;
    string _HeartRate = string.Empty;
    string _Temperature = string.Empty;
    string _BP1Systolic = string.Empty;
    string _BP1Diastolic = string.Empty;
    string _RespirationRate = string.Empty;
    string _Weight = string.Empty;
    string _ServiceProviderName = string.Empty;
    #endregion

    #region " Properties "

    public string Date
    {
        get { return _Date; }
        set { _Date = value; }
    }

    public string TimeIn
    {
        get { return _TimeIn; }
        set { _TimeIn = value; }
    }

    public string HeartRate
    {
        get { return _HeartRate; }
        set { _HeartRate = value; }
    }

    public string Temperature
    {
        get { return _Temperature; }
        set { _Temperature = value; }
    }

    public string BP1Systolic
    {
        get { return _BP1Systolic; }
        set { _BP1Systolic = value; }
    }

    public string BP1Diastolic
    {
        get { return _BP1Diastolic; }
        set { _BP1Diastolic = value; }
    }

    public string RespirationRate
    {
        get { return _RespirationRate; }
        set { _RespirationRate = value; }
    }

    public string Weight
    {
        get { return _Weight; }
        set { _Weight = value; }
    }

    public string ServiceProviderName
    {
        get { return _ServiceProviderName; }
        set { _ServiceProviderName = value; }
    }

    #endregion

}