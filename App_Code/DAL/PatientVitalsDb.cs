using System;
using System.Data;


/// <summary>
/// Summary description for PatientVitalsDb
/// </summary>
public class PatientVitalsDb
{
	public PatientVitalsDb()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public Int64 Add(PatientVitals objPatientVitals)
    {
        DBManager objDBManager = new DBManager();
        try
        {
            objDBManager.AddParameter("VitalId", objPatientVitals.VitalId, SqlDbType.BigInt, 8, ParameterDirection.Output);
            objDBManager.AddParameter("PatientId", objPatientVitals.PatientId);
            objDBManager.AddParameter("ChartId", objPatientVitals.ChartId);
            objDBManager.AddParameter("PracticeId", objPatientVitals.PracticeId);
            objDBManager.AddParameter("Height", objPatientVitals.Height);
            objDBManager.AddParameter("Weight", objPatientVitals.Weight);
            objDBManager.AddParameter("Temperature", objPatientVitals.Temperature);
            objDBManager.AddParameter("Source", objPatientVitals.Source);
            objDBManager.AddParameter("SupplementalO2", objPatientVitals.SupplementalO2);
            objDBManager.AddParameter("SupplementalO2Unit", objPatientVitals.SupplementalO2Unit);
            objDBManager.AddParameter("HeadCircumference", objPatientVitals.HeadCircumference);
            objDBManager.AddParameter("NoOfLiters", objPatientVitals.NoOfLiters);
            objDBManager.AddParameter("RespirationRate", objPatientVitals.RespirationRate);
            objDBManager.AddParameter("PulseRate", objPatientVitals.PulseRate);
            objDBManager.AddParameter("OxygenSaturation", objPatientVitals.OxygenSaturation);
            objDBManager.AddParameter("HeartRate", objPatientVitals.HeartRate);
            objDBManager.AddParameter("Rhythm", objPatientVitals.Rhythm);
            objDBManager.AddParameter("Volume", objPatientVitals.Volume);
            objDBManager.AddParameter("Character", objPatientVitals.Character);
            objDBManager.AddParameter("BP1Systolic", objPatientVitals.BP1Systolic);
            objDBManager.AddParameter("BP1Diastolic", objPatientVitals.BP1Diastolic);
            objDBManager.AddParameter("BP1MonitoringPos", objPatientVitals.BP1MonitoringPos);
            objDBManager.AddParameter("BP2Systolic", objPatientVitals.BP2Systolic);
            objDBManager.AddParameter("BP2Diastolic", objPatientVitals.BP2Diastolic);
            objDBManager.AddParameter("BP2MonitoringPos", objPatientVitals.BP2MonitoringPos);
            objDBManager.AddParameter("Delay", objPatientVitals.Delay);
            objDBManager.AddParameter("LMP", objPatientVitals.LMP);
            objDBManager.AddParameter("EDD", objPatientVitals.EDD);
            objDBManager.AddParameter("PregnancyText", objPatientVitals.PregnancyText);
            objDBManager.AddParameter("LesionsSize", objPatientVitals.LesionsSize);
            objDBManager.AddParameter("TakenTime", objPatientVitals.TakenTime);
            objDBManager.AddParameter("CreatedById", objPatientVitals.CreatedById);
            objDBManager.AddParameter("CreatedDate", objPatientVitals.CreatedDate);
            objDBManager.AddParameter("PainScale", objPatientVitals.PainScale);
            objDBManager.AddParameter("PatientCondition", objPatientVitals.PatientCondition);
            objDBManager.AddParameter("Deleted", objPatientVitals.Deleted);

            objDBManager.ExecuteNonQuery("Chart_AddPatientVitals");

            objPatientVitals.VitalId = (Int64)objDBManager.Parameters[0].Value;

        }
        catch (Exception ex)
        {

            throw ex;

        }

        return objPatientVitals.VitalId;

    }

    public void Update(PatientVitals objPatientVitals)
    {

        DBManager objDBManager = new DBManager();        
        try
        {
            objDBManager.AddParameter("VitalId", objPatientVitals.VitalId);            
            objDBManager.AddParameter("Height", objPatientVitals.Height);
            objDBManager.AddParameter("Weight", objPatientVitals.Weight);
            objDBManager.AddParameter("Temperature", objPatientVitals.Temperature);
            objDBManager.AddParameter("Source", objPatientVitals.Source);
            objDBManager.AddParameter("SupplementalO2", objPatientVitals.SupplementalO2);
            objDBManager.AddParameter("SupplementalO2Unit", objPatientVitals.SupplementalO2Unit);
            objDBManager.AddParameter("HeadCircumference", objPatientVitals.HeadCircumference);
            objDBManager.AddParameter("NoOfLiters", objPatientVitals.NoOfLiters);
            objDBManager.AddParameter("RespirationRate", objPatientVitals.RespirationRate);
            objDBManager.AddParameter("PulseRate", objPatientVitals.PulseRate);
            objDBManager.AddParameter("OxygenSaturation", objPatientVitals.OxygenSaturation);
            objDBManager.AddParameter("HeartRate", objPatientVitals.HeartRate);
            objDBManager.AddParameter("Rhythm", objPatientVitals.Rhythm);
            objDBManager.AddParameter("Volume", objPatientVitals.Volume);
            objDBManager.AddParameter("Character", objPatientVitals.Character);
            objDBManager.AddParameter("BP1Systolic", objPatientVitals.BP1Systolic);
            objDBManager.AddParameter("BP1Diastolic", objPatientVitals.BP1Diastolic);
            objDBManager.AddParameter("BP1MonitoringPos", objPatientVitals.BP1MonitoringPos);
            objDBManager.AddParameter("BP2Systolic", objPatientVitals.BP2Systolic);
            objDBManager.AddParameter("BP2Diastolic", objPatientVitals.BP2Diastolic);
            objDBManager.AddParameter("BP2MonitoringPos", objPatientVitals.BP2MonitoringPos);
            objDBManager.AddParameter("Delay", objPatientVitals.Delay);
            objDBManager.AddParameter("LMP", objPatientVitals.LMP);
            objDBManager.AddParameter("EDD", objPatientVitals.EDD);
            objDBManager.AddParameter("PregnancyText", objPatientVitals.PregnancyText);
            objDBManager.AddParameter("LesionsSize", objPatientVitals.LesionsSize);
            objDBManager.AddParameter("TakenTime", objPatientVitals.TakenTime);
            objDBManager.AddParameter("ModifiedById", objPatientVitals.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objPatientVitals.ModifiedDate);
            objDBManager.AddParameter("PainScale", objPatientVitals.PainScale);
            objDBManager.AddParameter("PatientCondition", objPatientVitals.PatientCondition);
            objDBManager.ExecuteNonQuery("Chart_UpdatePatientVitals");


        }
        catch (Exception ex)
        {
            throw ex;

        }        
    }
    public DataSet GetPatientVitalByChartId(Int64 chartId)
    {
        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("ChartId", chartId);
        return objDBManager.ExecuteDataSet("Chart_GetPatientVitalByChartId");
    }
    public DataSet GetPatientVitalByPatientId(Int64 PatientId, long ChartId)
    {
        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("PatientId", PatientId);
        if (ChartId != 0)
        {
            objDBManager.AddParameter("ChartId", ChartId);
        }
        return objDBManager.ExecuteDataSet("Chart_GetPatientVitalByPatientId");
    }
    public DataTable PatientVitals_GetByPatientId(Int64 PatientId)
    {
        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("PatientId", PatientId);
        return objDBManager.ExecuteDataTable("PatientVitals_GetByPatientId");
    }
    public DataSet GetRecentVitalByPatientId(Int64 PatientId)
    {
        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("PatientId", PatientId);
        return objDBManager.ExecuteDataSet("Chart_GetRecentVitalByPatientId");
    }
    public DataSet GetRecentVitalTakenByPatient(Int64 PatientId)
    {
        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("PatientId", PatientId);
        return objDBManager.ExecuteDataSet("Chart_GetRecentVitalTakenByPatient");
    }

    public DataTable GetDataForGraph(long PatientId, string DateFrom, string DateTo)
    {
        DBManager ObjDBManager = new DBManager();

        ObjDBManager.AddParameter("PatientId", PatientId);
        ObjDBManager.AddParameter("DateFrom", DateFrom);
        ObjDBManager.AddParameter("DateTo", DateTo);

        return ObjDBManager.ExecuteDataTable("Reports_PatientVitals_GetDataForGraph");
    }

    public DataSet GetAllAsDataTable(long PatientId, string DateFrom, string DateTo, int Rows, int PageNumber, string SortBy)
    {
        DBManager ObjDBManager = new DBManager();

        ObjDBManager.AddParameter("Rows", Rows);
        ObjDBManager.AddParameter("PageNumber", PageNumber);
        ObjDBManager.AddParameter("SortBy", SortBy);

        ObjDBManager.AddParameter("PatientId", PatientId);
        ObjDBManager.AddParameter("DateFrom", DateFrom);
        ObjDBManager.AddParameter("DateTo", DateTo);

        return ObjDBManager.ExecuteDataSet("Reports_PatientVitals_GetAllAsDataTable");
    }
}