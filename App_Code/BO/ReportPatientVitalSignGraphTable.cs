using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ReportPatientVitalSignGraphTable
/// </summary>
public class ReportPatientVitalSignGraphTable
{
    public ReportPatientVitalSignGraphTable()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    bool _PulseGraph = false;
    bool _PulseTable = false;

    bool _TemperatureGraph = false;
    bool _TemperatureTable = false;

    bool _BloodPressureGraph = false;
    bool _BloodPressureTable = false;

    bool _RespiratoryGraph = false;
    bool _RespiratoryTable = false;

    bool _WeightGraph = false;
    bool _WeightTable = false;

    public bool PulseGraph
    {
        get { return _PulseGraph; }
        set { _PulseGraph = value; }
    }

    public bool PulseTable
    {
        get { return _PulseTable; }
        set { _PulseTable = value; }
    }

    public bool TemperatureGraph
    {
        get { return _TemperatureGraph; }
        set { _TemperatureGraph = value; }
    }

    public bool TemperatureTable
    {
        get { return _TemperatureTable; }
        set { _TemperatureTable = value; }
    }

    public bool BloodPressureGraph
    {
        get { return _BloodPressureGraph; }
        set { _BloodPressureGraph = value; }
    }

    public bool BloodPressureTable
    {
        get { return _BloodPressureTable; }
        set { _BloodPressureTable = value; }
    }

    public bool RespiratoryGraph
    {
        get { return _RespiratoryGraph; }
        set { _RespiratoryGraph = value; }
    }

    public bool RespiratoryTable
    {
        get { return _RespiratoryTable; }
        set { _RespiratoryTable = value; }
    }

    public bool WeightGraph
    {
        get { return _WeightGraph; }
        set { _WeightGraph = value; }
    }

    public bool WeightTable
    {
        get { return _WeightTable; }
        set { _WeightTable = value; }
    }

}