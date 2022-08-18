using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PatientChartsDB
/// </summary>
public class PatientChartsDB
{
    public PatientChartsDB()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public long Add(PatientCharts objPatientCharts)
    {
        DBManager objDbManager = new DBManager();
        try
        {
            objDbManager.AddParameter("ChartId", objPatientCharts.ChartId, SqlDbType.BigInt, 8, ParameterDirection.Output);
            objDbManager.AddParameter("PatientId", objPatientCharts.PatientId);
            objDbManager.AddParameter("AppointmentsId", objPatientCharts.AppointmentsId);
            objDbManager.AddParameter("VisitDate", objPatientCharts.VisitDate);
            objDbManager.AddParameter("VisitTypeId", objPatientCharts.VisitTypeId);
            objDbManager.AddParameter("LocationId", objPatientCharts.LocationId);
            objDbManager.AddParameter("ApprovedByProviderId", objPatientCharts.ApprovedByProviderId);
            objDbManager.AddParameter("SeenByProviderId", objPatientCharts.SeenByProviderId);
            objDbManager.AddParameter("PracticeId", objPatientCharts.PracticeId);
            objDbManager.AddParameter("CreatedById", objPatientCharts.CreatedById);
            objDbManager.AddParameter("CreatedDate", objPatientCharts.CreatedDate);
            objDbManager.AddParameter("PresentIllness", objPatientCharts.PresentIllness);
            objDbManager.AddParameter("ReviewOfSystem", objPatientCharts.ReviewOfSystem);
            objDbManager.AddParameter("PastMedicalHistory", objPatientCharts.PastMedicalHistory);
            objDbManager.AddParameter("SocialHistory", objPatientCharts.SocialHistory);
            objDbManager.AddParameter("TobaccoUse", objPatientCharts.TobaccoUse);
            objDbManager.AddParameter("PacksPerDay", objPatientCharts.PacksPerDay);
            objDbManager.AddParameter("YearsSmoked", objPatientCharts.YearsSmoked);
            objDbManager.AddParameter("FamilyHistory", objPatientCharts.FamilyHistory);
            objDbManager.AddParameter("ReasonOfVisit", objPatientCharts.ReasonOfVisit);
            objDbManager.AddParameter("ReasonForOutPatient", objPatientCharts.ReasonForOutPatient);
            objDbManager.AddParameter("PlaceOfService", objPatientCharts.PlaceOfService);
            objDbManager.ExecuteNonQuery("Chart_AddPatientChart");
            objPatientCharts.ChartId = long.Parse(objDbManager.Parameters[0].Value.ToString());
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return objPatientCharts.ChartId;
    }

    public void Update(PatientCharts objPatientCharts)
    {
        DBManager objDbManager = new DBManager();
        try
        {
            objDbManager.AddParameter("ChartId", objPatientCharts.ChartId);
            objDbManager.AddParameter("PatientId", objPatientCharts.PatientId);
            objDbManager.AddParameter("VisitDate", objPatientCharts.VisitDate);
            objDbManager.AddParameter("VisitTypeId", objPatientCharts.VisitTypeId);
            objDbManager.AddParameter("LocationId", objPatientCharts.LocationId);
            objDbManager.AddParameter("ApprovedByProviderId", objPatientCharts.ApprovedByProviderId);
            objDbManager.AddParameter("SeenByProviderId", objPatientCharts.SeenByProviderId);
            objDbManager.AddParameter("ModifiedById", objPatientCharts.ModifiedById);
            objDbManager.AddParameter("ModifiedDate", objPatientCharts.ModifiedDate);
            objDbManager.AddParameter("PresentIllness", objPatientCharts.PresentIllness);
            objDbManager.AddParameter("ReviewOfSystem", objPatientCharts.ReviewOfSystem);
            objDbManager.AddParameter("PastMedicalHistory", objPatientCharts.PastMedicalHistory);
            objDbManager.AddParameter("SocialHistory", objPatientCharts.SocialHistory);
            objDbManager.AddParameter("TobaccoUse", objPatientCharts.TobaccoUse);
            objDbManager.AddParameter("PacksPerDay", objPatientCharts.PacksPerDay);
            objDbManager.AddParameter("YearsSmoked", objPatientCharts.YearsSmoked);
            objDbManager.AddParameter("FamilyHistory", objPatientCharts.FamilyHistory);
            objDbManager.AddParameter("ReasonOfVisit", objPatientCharts.ReasonOfVisit);
            objDbManager.AddParameter("ReasonForOutPatient", objPatientCharts.ReasonForOutPatient);
            objDbManager.AddParameter("PlaceOfService", objPatientCharts.PlaceOfService);
            objDbManager.ExecuteNonQuery("Chart_UpdatePatientChart");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable GetPatientCharts(long patientId, bool deleted, string chartType)
    {
        DBManager objDbManager = new DBManager();
        objDbManager.AddParameter("PatientId", patientId);
        objDbManager.AddParameter("Deleted", deleted);
        objDbManager.AddParameter("ChartType", chartType);
        return objDbManager.ExecuteDataTable("Chart_GetPatientCharts");
    }

    public void DeletePatientChart(long chartId, long patientId)
    {
        DBManager objDbManager = new DBManager();
        objDbManager.AddParameter("ChartId", chartId);
        objDbManager.AddParameter("PatientId", patientId);
        objDbManager.ExecuteNonQuery("Chart_DeletePatientChart");
    }

    public void RestoreChart(long chartId, long patientId)
    {
        DBManager objDbManager = new DBManager();
        objDbManager.AddParameter("ChartId", chartId);
        objDbManager.AddParameter("PatientId", patientId);
        objDbManager.ExecuteNonQuery("Chart_RestoreChart");
    }

    public void ChangeChartStatus(long chartId, long patientId, string status, long modifiedBy)
    {
        DBManager objDbManager = new DBManager();
        objDbManager.AddParameter("ChartId", chartId);
        objDbManager.AddParameter("PatientId", patientId);
        objDbManager.AddParameter("Status", status);
        objDbManager.AddParameter("date", DateTime.Now);
        objDbManager.AddParameter("ModifiedBy", modifiedBy);
        objDbManager.ExecuteNonQuery("Chart_ChangeChartStatus");
    }

    public DataSet GetVisitType_Providers_Locations(long practiceId)
    {
        DBManager objDbManager = new DBManager();
        objDbManager.AddParameter("PracticeId", practiceId);
        return objDbManager.ExecuteDataSet("Chart_GetVisitType_Providers_Locations");
    }

    public DataSet GetChart_VisitType_Providers_Locations(long patientId, long ChartId)
    {
        DBManager objDbManager = new DBManager();
        objDbManager.AddParameter("PatientId", patientId);
        if (ChartId != 0)
        {
            objDbManager.AddParameter("ChartId", ChartId);
        }
        return objDbManager.ExecuteDataSet("Chart_GetChart_VisitType_Providers_Locations");
    }

    public DataSet GetChartIdByAppointments(long AppointmentsId)
    {
        DBManager objDbManager = new DBManager();

        objDbManager.AddParameter("AppointmentsId", AppointmentsId);

        return objDbManager.ExecuteDataSet("PatientCharts_GetChartIdByAppointments");
    }

    public DataSet Chart_GetChartPrintDetails(long patientId, long ChartId)
    {
        DBManager objDbManager = new DBManager();
        objDbManager.AddParameter("PatientId", patientId);
        objDbManager.AddParameter("ChartId", ChartId);
        return objDbManager.ExecuteDataSet("Chart_GetChartPrintDetails");
    }
    public DataTable Chart_CheckRecentChart(long patientId)
    {
        DBManager objDbManager = new DBManager();
        objDbManager.AddParameter("PatientId", patientId);
        return objDbManager.ExecuteDataTable("Chart_CheckRecentChart");
    }
}