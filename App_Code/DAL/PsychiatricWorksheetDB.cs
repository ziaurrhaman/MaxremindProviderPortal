using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for PsychiatricWorksheetDB
/// </summary>
public class PsychiatricWorksheetDB
{
	public PsychiatricWorksheetDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public long Add(PsychiatricWorksheet objPsychiatricWorksheet, SqlTransaction objSqlTransaction = null)
    {
        DBManager objDBManager = new DBManager(objSqlTransaction);
        try
        {
            objDBManager.AddParameter("PsychiatricWorksheetId", objPsychiatricWorksheet.PsychiatricWorksheetId, SqlDbType.Int, 4, ParameterDirection.Output);

            objDBManager.AddParameter("PracticeId", objPsychiatricWorksheet.PracticeId);
            objDBManager.AddParameter("PatientId", objPsychiatricWorksheet.PatientId);
            objDBManager.AddParameter("ChartId", objPsychiatricWorksheet.ChartId);

            objDBManager.AddParameter("MariageStatus", objPsychiatricWorksheet.MariageStatus);
            objDBManager.AddParameter("SignificantChange", objPsychiatricWorksheet.SignificantChange);
            objDBManager.AddParameter("DetailsSignificantChange", objPsychiatricWorksheet.DetailsSignificantChange);
            objDBManager.AddParameter("DeathOfLoved", objPsychiatricWorksheet.DeathOfLoved);
            objDBManager.AddParameter("DetailsDeathOfLoved", objPsychiatricWorksheet.DetailsDeathOfLoved);
            objDBManager.AddParameter("ChangedJobs", objPsychiatricWorksheet.ChangedJobs);
            objDBManager.AddParameter("DetailsChangedJobs", objPsychiatricWorksheet.DetailsChangedJobs);
            objDBManager.AddParameter("StatusChanged", objPsychiatricWorksheet.StatusChanged);
            objDBManager.AddParameter("DetailsStatusChanged", objPsychiatricWorksheet.DetailsStatusChanged);
            objDBManager.AddParameter("LegalIssues", objPsychiatricWorksheet.LegalIssues);
            objDBManager.AddParameter("DetailsLegalIssues", objPsychiatricWorksheet.DetailsLegalIssues);
            objDBManager.AddParameter("HobbiesInterests", objPsychiatricWorksheet.HobbiesInterests);
            objDBManager.AddParameter("PSHAbuse", objPsychiatricWorksheet.PSHAbuse);
            objDBManager.AddParameter("AlcoholAmount", objPsychiatricWorksheet.AlcoholAmount);
            objDBManager.AddParameter("AlcoholFrequency", objPsychiatricWorksheet.AlcoholFrequency);
            objDBManager.AddParameter("AlcoholTimePeriod", objPsychiatricWorksheet.AlcoholTimePeriod);
            objDBManager.AddParameter("MarijuanaAmount", objPsychiatricWorksheet.MarijuanaAmount);
            objDBManager.AddParameter("MarijuanaFrequency", objPsychiatricWorksheet.MarijuanaFrequency);
            objDBManager.AddParameter("MarijuanaTimePeriod", objPsychiatricWorksheet.MarijuanaTimePeriod);
            objDBManager.AddParameter("CocaineAmount", objPsychiatricWorksheet.CocaineAmount);
            objDBManager.AddParameter("CocaineFrequency", objPsychiatricWorksheet.CocaineFrequency);
            objDBManager.AddParameter("CocaineTimePeriod", objPsychiatricWorksheet.CocaineTimePeriod);
            objDBManager.AddParameter("InhalantsAmount", objPsychiatricWorksheet.InhalantsAmount);
            objDBManager.AddParameter("InhalantsFrequency", objPsychiatricWorksheet.InhalantsFrequency);
            objDBManager.AddParameter("InhalantsTimePeriod", objPsychiatricWorksheet.InhalantsTimePeriod);
            objDBManager.AddParameter("StimulantsAmount", objPsychiatricWorksheet.StimulantsAmount);
            objDBManager.AddParameter("StimulantsFrequency", objPsychiatricWorksheet.StimulantsFrequency);
            objDBManager.AddParameter("StimulantsTimePeriod", objPsychiatricWorksheet.StimulantsTimePeriod);
            objDBManager.AddParameter("HallucinogensAmount", objPsychiatricWorksheet.HallucinogensAmount);
            objDBManager.AddParameter("HallucinogensFrequency", objPsychiatricWorksheet.HallucinogensFrequency);
            objDBManager.AddParameter("HallucinogensTimePeriod", objPsychiatricWorksheet.HallucinogensTimePeriod);
            objDBManager.AddParameter("HeroinAmount", objPsychiatricWorksheet.HeroinAmount);
            objDBManager.AddParameter("HeroinFrequency", objPsychiatricWorksheet.HeroinFrequency);
            objDBManager.AddParameter("HeroinTimePeriod", objPsychiatricWorksheet.HeroinTimePeriod);
            objDBManager.AddParameter("PrescriptionAmount", objPsychiatricWorksheet.PrescriptionAmount);
            objDBManager.AddParameter("PrescriptionFrequency", objPsychiatricWorksheet.PrescriptionFrequency);
            objDBManager.AddParameter("PrescriptionTimePeriod", objPsychiatricWorksheet.PrescriptionTimePeriod);
            objDBManager.AddParameter("OtherAmount", objPsychiatricWorksheet.OtherAmount);
            objDBManager.AddParameter("OtherFrequency", objPsychiatricWorksheet.OtherFrequency);
            objDBManager.AddParameter("OtherTimePeriod", objPsychiatricWorksheet.OtherTimePeriod);
            objDBManager.AddParameter("HospitalizationsFromDate", objPsychiatricWorksheet.HospitalizationsFromDate);
            objDBManager.AddParameter("HospitalizationsToDate", objPsychiatricWorksheet.HospitalizationsToDate);
            objDBManager.AddParameter("HospitalizationsDuration", objPsychiatricWorksheet.HospitalizationsDuration);
            objDBManager.AddParameter("HospitalizationsTreatment", objPsychiatricWorksheet.HospitalizationsTreatment);
            objDBManager.AddParameter("HospitalizationsComments", objPsychiatricWorksheet.HospitalizationsComments);
            objDBManager.AddParameter("PsychiatricPsychotherapyFromDate", objPsychiatricWorksheet.PsychiatricPsychotherapyFromDate);
            objDBManager.AddParameter("PsychiatricPsychotherapyToDate", objPsychiatricWorksheet.PsychiatricPsychotherapyToDate);
            objDBManager.AddParameter("PsychiatricPsychotherapyDuration", objPsychiatricWorksheet.PsychiatricPsychotherapyDuration);
            objDBManager.AddParameter("PsychiatricPsychotherapyTreatment", objPsychiatricWorksheet.PsychiatricPsychotherapyTreatment);
            objDBManager.AddParameter("PsychiatricPsychotherapyComments", objPsychiatricWorksheet.PsychiatricPsychotherapyComments);
            objDBManager.AddParameter("PsychiatricTreatmentFromDate", objPsychiatricWorksheet.PsychiatricTreatmentFromDate);
            objDBManager.AddParameter("PsychiatricTreatmentToDate", objPsychiatricWorksheet.PsychiatricTreatmentToDate);
            objDBManager.AddParameter("PsychiatricTreatmentDuration", objPsychiatricWorksheet.PsychiatricTreatmentDuration);
            objDBManager.AddParameter("PsychiatricTreatmentTreatment", objPsychiatricWorksheet.PsychiatricTreatmentTreatment);
            objDBManager.AddParameter("PsychiatricTreatmentComments", objPsychiatricWorksheet.PsychiatricTreatmentComments);
            objDBManager.AddParameter("PatientPsychiatricHistory", objPsychiatricWorksheet.PatientPsychiatricHistory);
            objDBManager.AddParameter("FamilyPsychiatricHistory", objPsychiatricWorksheet.FamilyPsychiatricHistory);
            objDBManager.AddParameter("PatientMedicalHistory", objPsychiatricWorksheet.PatientMedicalHistory);
            objDBManager.AddParameter("FamilyMedicalHistory", objPsychiatricWorksheet.FamilyMedicalHistory);
            objDBManager.AddParameter("Appearance", objPsychiatricWorksheet.Appearance);
            objDBManager.AddParameter("Affect", objPsychiatricWorksheet.Affect);
            objDBManager.AddParameter("Posture", objPsychiatricWorksheet.Posture);
            objDBManager.AddParameter("Perception", objPsychiatricWorksheet.Perception);
            objDBManager.AddParameter("BodyMovements", objPsychiatricWorksheet.BodyMovements);
            objDBManager.AddParameter("Cognitive", objPsychiatricWorksheet.Cognitive);
            objDBManager.AddParameter("Speech", objPsychiatricWorksheet.Speech);
            objDBManager.AddParameter("Judgement", objPsychiatricWorksheet.Judgement);
            objDBManager.AddParameter("Attitude", objPsychiatricWorksheet.Attitude);
            objDBManager.AddParameter("ThoughtContent", objPsychiatricWorksheet.ThoughtContent);
            objDBManager.AddParameter("Orientation", objPsychiatricWorksheet.Orientation);
            objDBManager.AddParameter("LevelOfInsight", objPsychiatricWorksheet.LevelOfInsight);
            objDBManager.AddParameter("ScoreBPRS", objPsychiatricWorksheet.ScoreBPRS);
            objDBManager.AddParameter("NotIndicatedBPRS", objPsychiatricWorksheet.NotIndicatedBPRS);
            objDBManager.AddParameter("ScoreCSDD", objPsychiatricWorksheet.ScoreCSDD);
            objDBManager.AddParameter("NotIndicatedCSDD", objPsychiatricWorksheet.NotIndicatedCSDD);
            objDBManager.AddParameter("ScoreGDS", objPsychiatricWorksheet.ScoreGDS);
            objDBManager.AddParameter("NotIndicatedGDS", objPsychiatricWorksheet.NotIndicatedGDS);
            objDBManager.AddParameter("ScoreHAMA", objPsychiatricWorksheet.ScoreHAMA);
            objDBManager.AddParameter("NotIndicatedHAMA", objPsychiatricWorksheet.NotIndicatedHAMA);
            objDBManager.AddParameter("ScoreSPMSQ", objPsychiatricWorksheet.ScoreSPMSQ);
            objDBManager.AddParameter("NotIndicatedSPMSQ", objPsychiatricWorksheet.NotIndicatedSPMSQ);
            objDBManager.AddParameter("ScoreAIMS", objPsychiatricWorksheet.ScoreAIMS);
            objDBManager.AddParameter("NotIndicatedAIMS", objPsychiatricWorksheet.NotIndicatedAIMS);
            objDBManager.AddParameter("ScoreSLUMS", objPsychiatricWorksheet.ScoreSLUMS);
            objDBManager.AddParameter("NotIndicatedSLUMS", objPsychiatricWorksheet.NotIndicatedSLUMS);
            objDBManager.AddParameter("ScorePHQ2", objPsychiatricWorksheet.ScorePHQ2);
            objDBManager.AddParameter("NotIndicatedPHQ2", objPsychiatricWorksheet.NotIndicatedPHQ2);
            objDBManager.AddParameter("ScorePHQ9", objPsychiatricWorksheet.ScorePHQ9);
            objDBManager.AddParameter("NotIndicatedPHQ9", objPsychiatricWorksheet.NotIndicatedPHQ9);
            objDBManager.AddParameter("ScoreGAD7", objPsychiatricWorksheet.ScoreGAD7);
            objDBManager.AddParameter("NotIndicatedGAD7", objPsychiatricWorksheet.NotIndicatedGAD7);
            
            objDBManager.AddParameter("CreatedDate", objPsychiatricWorksheet.CreatedDate);
            objDBManager.AddParameter("CreatedById", objPsychiatricWorksheet.CreatedById);

            objDBManager.ExecuteNonQuery("PsychiatricWorksheet_Add");

            objPsychiatricWorksheet.PsychiatricWorksheetId = long.Parse(objDBManager.Parameters[0].Value.ToString());
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return objPsychiatricWorksheet.PsychiatricWorksheetId;
    }
    
    public int Update(PsychiatricWorksheet objPsychiatricWorksheet, SqlTransaction objSqlTransaction = null)
    {
        DBManager objDBManager = new DBManager(objSqlTransaction);
        int ReturnValue = 0;

        try
        {
            objDBManager.AddParameter("PsychiatricWorksheetId", objPsychiatricWorksheet.PsychiatricWorksheetId);

            objDBManager.AddParameter("PracticeId", objPsychiatricWorksheet.PracticeId);
            objDBManager.AddParameter("PatientId", objPsychiatricWorksheet.PatientId);
            objDBManager.AddParameter("ChartId", objPsychiatricWorksheet.ChartId);
            
            objDBManager.AddParameter("MariageStatus", objPsychiatricWorksheet.MariageStatus);
            objDBManager.AddParameter("SignificantChange", objPsychiatricWorksheet.SignificantChange);
            objDBManager.AddParameter("DetailsSignificantChange", objPsychiatricWorksheet.DetailsSignificantChange);
            objDBManager.AddParameter("DeathOfLoved", objPsychiatricWorksheet.DeathOfLoved);
            objDBManager.AddParameter("DetailsDeathOfLoved", objPsychiatricWorksheet.DetailsDeathOfLoved);
            objDBManager.AddParameter("ChangedJobs", objPsychiatricWorksheet.ChangedJobs);
            objDBManager.AddParameter("DetailsChangedJobs", objPsychiatricWorksheet.DetailsChangedJobs);
            objDBManager.AddParameter("StatusChanged", objPsychiatricWorksheet.StatusChanged);
            objDBManager.AddParameter("DetailsStatusChanged", objPsychiatricWorksheet.DetailsStatusChanged);
            objDBManager.AddParameter("LegalIssues", objPsychiatricWorksheet.LegalIssues);
            objDBManager.AddParameter("DetailsLegalIssues", objPsychiatricWorksheet.DetailsLegalIssues);
            objDBManager.AddParameter("HobbiesInterests", objPsychiatricWorksheet.HobbiesInterests);
            objDBManager.AddParameter("PSHAbuse", objPsychiatricWorksheet.PSHAbuse);
            objDBManager.AddParameter("AlcoholAmount", objPsychiatricWorksheet.AlcoholAmount);
            objDBManager.AddParameter("AlcoholFrequency", objPsychiatricWorksheet.AlcoholFrequency);
            objDBManager.AddParameter("AlcoholTimePeriod", objPsychiatricWorksheet.AlcoholTimePeriod);
            objDBManager.AddParameter("MarijuanaAmount", objPsychiatricWorksheet.MarijuanaAmount);
            objDBManager.AddParameter("MarijuanaFrequency", objPsychiatricWorksheet.MarijuanaFrequency);
            objDBManager.AddParameter("MarijuanaTimePeriod", objPsychiatricWorksheet.MarijuanaTimePeriod);
            objDBManager.AddParameter("CocaineAmount", objPsychiatricWorksheet.CocaineAmount);
            objDBManager.AddParameter("CocaineFrequency", objPsychiatricWorksheet.CocaineFrequency);
            objDBManager.AddParameter("CocaineTimePeriod", objPsychiatricWorksheet.CocaineTimePeriod);
            objDBManager.AddParameter("InhalantsAmount", objPsychiatricWorksheet.InhalantsAmount);
            objDBManager.AddParameter("InhalantsFrequency", objPsychiatricWorksheet.InhalantsFrequency);
            objDBManager.AddParameter("InhalantsTimePeriod", objPsychiatricWorksheet.InhalantsTimePeriod);
            objDBManager.AddParameter("StimulantsAmount", objPsychiatricWorksheet.StimulantsAmount);
            objDBManager.AddParameter("StimulantsFrequency", objPsychiatricWorksheet.StimulantsFrequency);
            objDBManager.AddParameter("StimulantsTimePeriod", objPsychiatricWorksheet.StimulantsTimePeriod);
            objDBManager.AddParameter("HallucinogensAmount", objPsychiatricWorksheet.HallucinogensAmount);
            objDBManager.AddParameter("HallucinogensFrequency", objPsychiatricWorksheet.HallucinogensFrequency);
            objDBManager.AddParameter("HallucinogensTimePeriod", objPsychiatricWorksheet.HallucinogensTimePeriod);
            objDBManager.AddParameter("HeroinAmount", objPsychiatricWorksheet.HeroinAmount);
            objDBManager.AddParameter("HeroinFrequency", objPsychiatricWorksheet.HeroinFrequency);
            objDBManager.AddParameter("HeroinTimePeriod", objPsychiatricWorksheet.HeroinTimePeriod);
            objDBManager.AddParameter("PrescriptionAmount", objPsychiatricWorksheet.PrescriptionAmount);
            objDBManager.AddParameter("PrescriptionFrequency", objPsychiatricWorksheet.PrescriptionFrequency);
            objDBManager.AddParameter("PrescriptionTimePeriod", objPsychiatricWorksheet.PrescriptionTimePeriod);
            objDBManager.AddParameter("OtherAmount", objPsychiatricWorksheet.OtherAmount);
            objDBManager.AddParameter("OtherFrequency", objPsychiatricWorksheet.OtherFrequency);
            objDBManager.AddParameter("OtherTimePeriod", objPsychiatricWorksheet.OtherTimePeriod);
            objDBManager.AddParameter("HospitalizationsFromDate", objPsychiatricWorksheet.HospitalizationsFromDate);
            objDBManager.AddParameter("HospitalizationsToDate", objPsychiatricWorksheet.HospitalizationsToDate);
            objDBManager.AddParameter("HospitalizationsDuration", objPsychiatricWorksheet.HospitalizationsDuration);
            objDBManager.AddParameter("HospitalizationsTreatment", objPsychiatricWorksheet.HospitalizationsTreatment);
            objDBManager.AddParameter("HospitalizationsComments", objPsychiatricWorksheet.HospitalizationsComments);
            objDBManager.AddParameter("PsychiatricPsychotherapyFromDate", objPsychiatricWorksheet.PsychiatricPsychotherapyFromDate);
            objDBManager.AddParameter("PsychiatricPsychotherapyToDate", objPsychiatricWorksheet.PsychiatricPsychotherapyToDate);
            objDBManager.AddParameter("PsychiatricPsychotherapyDuration", objPsychiatricWorksheet.PsychiatricPsychotherapyDuration);
            objDBManager.AddParameter("PsychiatricPsychotherapyTreatment", objPsychiatricWorksheet.PsychiatricPsychotherapyTreatment);
            objDBManager.AddParameter("PsychiatricPsychotherapyComments", objPsychiatricWorksheet.PsychiatricPsychotherapyComments);
            objDBManager.AddParameter("PsychiatricTreatmentFromDate", objPsychiatricWorksheet.PsychiatricTreatmentFromDate);
            objDBManager.AddParameter("PsychiatricTreatmentToDate", objPsychiatricWorksheet.PsychiatricTreatmentToDate);
            objDBManager.AddParameter("PsychiatricTreatmentDuration", objPsychiatricWorksheet.PsychiatricTreatmentDuration);
            objDBManager.AddParameter("PsychiatricTreatmentTreatment", objPsychiatricWorksheet.PsychiatricTreatmentTreatment);
            objDBManager.AddParameter("PsychiatricTreatmentComments", objPsychiatricWorksheet.PsychiatricTreatmentComments);
            objDBManager.AddParameter("PatientPsychiatricHistory", objPsychiatricWorksheet.PatientPsychiatricHistory);
            objDBManager.AddParameter("FamilyPsychiatricHistory", objPsychiatricWorksheet.FamilyPsychiatricHistory);
            objDBManager.AddParameter("PatientMedicalHistory", objPsychiatricWorksheet.PatientMedicalHistory);
            objDBManager.AddParameter("FamilyMedicalHistory", objPsychiatricWorksheet.FamilyMedicalHistory);
            objDBManager.AddParameter("Appearance", objPsychiatricWorksheet.Appearance);
            objDBManager.AddParameter("Affect", objPsychiatricWorksheet.Affect);
            objDBManager.AddParameter("Posture", objPsychiatricWorksheet.Posture);
            objDBManager.AddParameter("Perception", objPsychiatricWorksheet.Perception);
            objDBManager.AddParameter("BodyMovements", objPsychiatricWorksheet.BodyMovements);
            objDBManager.AddParameter("Cognitive", objPsychiatricWorksheet.Cognitive);
            objDBManager.AddParameter("Speech", objPsychiatricWorksheet.Speech);
            objDBManager.AddParameter("Judgement", objPsychiatricWorksheet.Judgement);
            objDBManager.AddParameter("Attitude", objPsychiatricWorksheet.Attitude);
            objDBManager.AddParameter("ThoughtContent", objPsychiatricWorksheet.ThoughtContent);
            objDBManager.AddParameter("Orientation", objPsychiatricWorksheet.Orientation);
            objDBManager.AddParameter("LevelOfInsight", objPsychiatricWorksheet.LevelOfInsight);
            objDBManager.AddParameter("ScoreBPRS", objPsychiatricWorksheet.ScoreBPRS);
            objDBManager.AddParameter("NotIndicatedBPRS", objPsychiatricWorksheet.NotIndicatedBPRS);
            objDBManager.AddParameter("ScoreCSDD", objPsychiatricWorksheet.ScoreCSDD);
            objDBManager.AddParameter("NotIndicatedCSDD", objPsychiatricWorksheet.NotIndicatedCSDD);
            objDBManager.AddParameter("ScoreGDS", objPsychiatricWorksheet.ScoreGDS);
            objDBManager.AddParameter("NotIndicatedGDS", objPsychiatricWorksheet.NotIndicatedGDS);
            objDBManager.AddParameter("ScoreHAMA", objPsychiatricWorksheet.ScoreHAMA);
            objDBManager.AddParameter("NotIndicatedHAMA", objPsychiatricWorksheet.NotIndicatedHAMA);
            objDBManager.AddParameter("ScoreSPMSQ", objPsychiatricWorksheet.ScoreSPMSQ);
            objDBManager.AddParameter("NotIndicatedSPMSQ", objPsychiatricWorksheet.NotIndicatedSPMSQ);
            objDBManager.AddParameter("ScoreAIMS", objPsychiatricWorksheet.ScoreAIMS);
            objDBManager.AddParameter("NotIndicatedAIMS", objPsychiatricWorksheet.NotIndicatedAIMS);
            objDBManager.AddParameter("ScoreSLUMS", objPsychiatricWorksheet.ScoreSLUMS);
            objDBManager.AddParameter("NotIndicatedSLUMS", objPsychiatricWorksheet.NotIndicatedSLUMS);
            objDBManager.AddParameter("ScorePHQ2", objPsychiatricWorksheet.ScorePHQ2);
            objDBManager.AddParameter("NotIndicatedPHQ2", objPsychiatricWorksheet.NotIndicatedPHQ2);
            objDBManager.AddParameter("ScorePHQ9", objPsychiatricWorksheet.ScorePHQ9);
            objDBManager.AddParameter("NotIndicatedPHQ9", objPsychiatricWorksheet.NotIndicatedPHQ9);
            objDBManager.AddParameter("ScoreGAD7", objPsychiatricWorksheet.ScoreGAD7);
            objDBManager.AddParameter("NotIndicatedGAD7", objPsychiatricWorksheet.NotIndicatedGAD7);
            
            objDBManager.AddParameter("ModifiedDate", objPsychiatricWorksheet.ModifiedDate);
            objDBManager.AddParameter("ModifiedById", objPsychiatricWorksheet.ModifiedById);

            ReturnValue = objDBManager.ExecuteNonQuery("PsychiatricWorksheet_Update");
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ReturnValue;
    }

    public DataTable GetByChartId(long PatientId, long ChartId)
    {
        DBManager objDBManager = new DBManager();

        objDBManager.AddParameter("PatientId", PatientId);
        objDBManager.AddParameter("ChartId", ChartId);

        return objDBManager.ExecuteDataTable("PsychiatricWorksheet_GetByChartId");
    }

}