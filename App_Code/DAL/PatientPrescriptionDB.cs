using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for PatientPrescriptionDB
/// </summary>
public class PatientPrescriptionDB
{
    public PatientPrescriptionDB()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public long Add(PatientPrescription objPatientPrescription, SqlTransaction objSqlTransaction = null)
    {

        DBManager objDBManager = new DBManager(objSqlTransaction);
        try
        {
            objDBManager.AddParameter("PatientPrescriptionId", objPatientPrescription.PatientPrescriptionId, SqlDbType.BigInt, 4, ParameterDirection.Output);
            objDBManager.AddParameter("PatientId", objPatientPrescription.PatientId);
            objDBManager.AddParameter("ChartId", objPatientPrescription.ChartId);
            objDBManager.AddParameter("PrescriptionDate", objPatientPrescription.PrescriptionDate);
            objDBManager.AddParameter("PhysicianId", objPatientPrescription.PhysicianId);
            objDBManager.AddParameter("PharmacyId", objPatientPrescription.PharmacyId);
            objDBManager.AddParameter("MedicineCode", objPatientPrescription.MedicineCode);
            objDBManager.AddParameter("FormulationCode", objPatientPrescription.FormulationCode);
            objDBManager.AddParameter("Sig", objPatientPrescription.Sig);
            objDBManager.AddParameter("Dispense", objPatientPrescription.Dispense);
            objDBManager.AddParameter("DurationNo", objPatientPrescription.DurationNo);
            objDBManager.AddParameter("DurationUnit", objPatientPrescription.DurationUnit);
            objDBManager.AddParameter("Total", objPatientPrescription.Total);
            objDBManager.AddParameter("Route", objPatientPrescription.Route);
            objDBManager.AddParameter("Refill", objPatientPrescription.Refill);
            objDBManager.AddParameter("Substitute", objPatientPrescription.Substitute);
            objDBManager.AddParameter("Advice", objPatientPrescription.Advice);
            objDBManager.AddParameter("Active", objPatientPrescription.Active);
            objDBManager.AddParameter("Print", objPatientPrescription.Print);
            objDBManager.AddParameter("PrintDEA", objPatientPrescription.PrintDEA);
            objDBManager.AddParameter("RxDate", objPatientPrescription.RxDate);
            objDBManager.AddParameter("DateWritten", objPatientPrescription.DateWritten);
            objDBManager.AddParameter("DateDispensed", objPatientPrescription.DateDispensed);
            objDBManager.AddParameter("DateDiscard", objPatientPrescription.DateDiscard);
            objDBManager.AddParameter("DateExpire", objPatientPrescription.DateExpire);
            objDBManager.AddParameter("Complete", objPatientPrescription.Complete);
            objDBManager.AddParameter("PrescriptionType", objPatientPrescription.PrescriptionType);
            objDBManager.AddParameter("OverrideAdverse", objPatientPrescription.OverrideAdverse);
            objDBManager.AddParameter("OverrideReason", objPatientPrescription.OverrideReason);
            objDBManager.AddParameter("CheckContraIndication", objPatientPrescription.CheckContraIndication);
            objDBManager.AddParameter("NotesPharmacy", objPatientPrescription.NotesPharmacy);
            objDBManager.AddParameter("IsConfidential", objPatientPrescription.IsConfidential);
            objDBManager.AddParameter("PrescriptionReviewed", objPatientPrescription.PrescriptionReviewed);
            objDBManager.AddParameter("PrescriptionReviewBy", objPatientPrescription.PrescriptionReviewBy);
            objDBManager.AddParameter("PrescriptionReviewDate", objPatientPrescription.PrescriptionReviewDate);
            objDBManager.AddParameter("PrescriptionDX", objPatientPrescription.PrescriptionDX);
            objDBManager.AddParameter("ProviderInstruction", objPatientPrescription.ProviderInstruction);
            objDBManager.AddParameter("StartDate", objPatientPrescription.StartDate);
            objDBManager.AddParameter("EndDate", objPatientPrescription.EndDate);
            objDBManager.AddParameter("DrugToDrug", objPatientPrescription.DrugToDrug);
            objDBManager.AddParameter("DrugToDisease", objPatientPrescription.DrugToDisease);
            objDBManager.AddParameter("DrugToAllergy", objPatientPrescription.DrugToAllergy);
            objDBManager.AddParameter("PrescriptionStatus", objPatientPrescription.PrescriptionStatus);
            objDBManager.AddParameter("UnitCode", objPatientPrescription.UnitCode);
            objDBManager.AddParameter("EPMsgFunction", objPatientPrescription.EPMsgFunction);
            objDBManager.AddParameter("EPMsgRefNo", objPatientPrescription.EPMsgRefNo);
            objDBManager.AddParameter("EPMsgStatus", objPatientPrescription.EPMsgStatus);
            objDBManager.AddParameter("EPMsgReason", objPatientPrescription.EPMsgReason);
            objDBManager.AddParameter("EPMsgDetail", objPatientPrescription.EPMsgDetail);
            objDBManager.AddParameter("OnHold", objPatientPrescription.OnHold);
            objDBManager.AddParameter("DrugToFood", objPatientPrescription.DrugToFood);
            objDBManager.AddParameter("MedicineTrade", objPatientPrescription.MedicineTrade);
            objDBManager.AddParameter("EPFreeText", objPatientPrescription.EPFreeText);
            objDBManager.AddParameter("EPInitialRefIdentifier", objPatientPrescription.EPInitialRefIdentifier);
            objDBManager.AddParameter("EPPrescriberOrderNo", objPatientPrescription.EPPrescriberOrderNo);
            objDBManager.AddParameter("EPSureScripRefNo", objPatientPrescription.EPSureScripRefNo);
            objDBManager.AddParameter("EPTransControlNo", objPatientPrescription.EPTransControlNo);
            objDBManager.AddParameter("EPResponse_code", objPatientPrescription.EPResponse_code);
            objDBManager.AddParameter("EPResponseQualifier", objPatientPrescription.EPResponseQualifier);
            objDBManager.AddParameter("PracticeId", objPatientPrescription.PracticeId);
            objDBManager.AddParameter("PharmacyDescription", objPatientPrescription.PharmacyDescription);
            objDBManager.AddParameter("Status", objPatientPrescription.Status);
            objDBManager.AddParameter("Status_Comments", objPatientPrescription.Status_Comments);
            objDBManager.AddParameter("RxNorm", objPatientPrescription.RxNorm);
            objDBManager.AddParameter("FormularyDetailForEARReport", objPatientPrescription.FormularyDetailForEARReport);
            objDBManager.AddParameter("EligPatientIdentificationNo", objPatientPrescription.EligPatientIdentificationNo);
            objDBManager.AddParameter("EligBinLocationNumber", objPatientPrescription.EligBinLocationNumber);
            objDBManager.AddParameter("EligPayerID", objPatientPrescription.EligPayerID);
            objDBManager.AddParameter("EligPayerName", objPatientPrescription.EligPayerName);
            objDBManager.AddParameter("EligCardHolderID", objPatientPrescription.EligCardHolderID);
            objDBManager.AddParameter("EligCardHolderName", objPatientPrescription.EligCardHolderName);
            objDBManager.AddParameter("EligGroupID", objPatientPrescription.EligGroupID);
            objDBManager.AddParameter("DrugDatabaseSource", objPatientPrescription.DrugDatabaseSource);
            objDBManager.AddParameter("IsCarryForward", objPatientPrescription.IsCarryForward);
            objDBManager.AddParameter("CreatedById", objPatientPrescription.CreatedById);
            objDBManager.AddParameter("CreatedDate", objPatientPrescription.CreatedDate);
            objDBManager.AddParameter("IncludeNPI", objPatientPrescription.IncludeNPI);
            objDBManager.AddParameter("IncludeDEA", objPatientPrescription.IncludeDEA);
            objDBManager.AddParameter("IncludeStateId", objPatientPrescription.IncludeStateId);
            objDBManager.AddParameter("DispenseAs", objPatientPrescription.DispenseAs);
            objDBManager.AddParameter("Refill1Date", objPatientPrescription.Refill1Date);
            objDBManager.AddParameter("Refill2Date", objPatientPrescription.Refill2Date);
            objDBManager.AddParameter("Refill3Date", objPatientPrescription.Refill3Date);
            objDBManager.AddParameter("Refill4Date", objPatientPrescription.Refill4Date);
            objDBManager.AddParameter("Refill5Date", objPatientPrescription.Refill5Date);
            objDBManager.AddParameter("Refill6Date", objPatientPrescription.Refill6Date);
            objDBManager.ExecuteNonQuery("PatientPrescription_Add");

            objPatientPrescription.PatientPrescriptionId = long.Parse(objDBManager.Parameters[0].Value.ToString());
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return objPatientPrescription.PatientPrescriptionId;
    }

    public int Update(PatientPrescription objPatientPrescription, SqlTransaction objSqlTransaction = null)
    {
        DBManager objDBManager = new DBManager(objSqlTransaction);
        int ReturnValue = 0;
        try
        {
            objDBManager.AddParameter("PatientPrescriptionId", objPatientPrescription.PatientPrescriptionId);
            objDBManager.AddParameter("PatientId", objPatientPrescription.PatientId);
            objDBManager.AddParameter("ChartId", objPatientPrescription.ChartId);
            objDBManager.AddParameter("PrescriptionDate", objPatientPrescription.PrescriptionDate);
            objDBManager.AddParameter("PhysicianId", objPatientPrescription.PhysicianId);
            objDBManager.AddParameter("PharmacyId", objPatientPrescription.PharmacyId);
            objDBManager.AddParameter("MedicineCode", objPatientPrescription.MedicineCode);
            objDBManager.AddParameter("FormulationCode", objPatientPrescription.FormulationCode);
            objDBManager.AddParameter("Sig", objPatientPrescription.Sig);
            objDBManager.AddParameter("Dispense", objPatientPrescription.Dispense);
            objDBManager.AddParameter("DurationNo", objPatientPrescription.DurationNo);
            objDBManager.AddParameter("DurationUnit", objPatientPrescription.DurationUnit);
            objDBManager.AddParameter("Total", objPatientPrescription.Total);
            objDBManager.AddParameter("Route", objPatientPrescription.Route);
            objDBManager.AddParameter("Refill", objPatientPrescription.Refill);
            objDBManager.AddParameter("Substitute", objPatientPrescription.Substitute);
            objDBManager.AddParameter("Advice", objPatientPrescription.Advice);
            objDBManager.AddParameter("Active", objPatientPrescription.Active);
            objDBManager.AddParameter("Print", objPatientPrescription.Print);
            objDBManager.AddParameter("PrintDEA", objPatientPrescription.PrintDEA);
            objDBManager.AddParameter("RxDate", objPatientPrescription.RxDate);
            objDBManager.AddParameter("DateWritten", objPatientPrescription.DateWritten);
            objDBManager.AddParameter("DateDispensed", objPatientPrescription.DateDispensed);
            objDBManager.AddParameter("DateDiscard", objPatientPrescription.DateDiscard);
            objDBManager.AddParameter("DateExpire", objPatientPrescription.DateExpire);
            objDBManager.AddParameter("Complete", objPatientPrescription.Complete);
            objDBManager.AddParameter("PrescriptionType", objPatientPrescription.PrescriptionType);
            objDBManager.AddParameter("OverrideAdverse", objPatientPrescription.OverrideAdverse);
            objDBManager.AddParameter("OverrideReason", objPatientPrescription.OverrideReason);
            objDBManager.AddParameter("CheckContraIndication", objPatientPrescription.CheckContraIndication);
            objDBManager.AddParameter("NotesPharmacy", objPatientPrescription.NotesPharmacy);
            objDBManager.AddParameter("IsConfidential", objPatientPrescription.IsConfidential);
            objDBManager.AddParameter("PrescriptionReviewed", objPatientPrescription.PrescriptionReviewed);
            objDBManager.AddParameter("PrescriptionReviewBy", objPatientPrescription.PrescriptionReviewBy);
            objDBManager.AddParameter("PrescriptionReviewDate", objPatientPrescription.PrescriptionReviewDate);
            objDBManager.AddParameter("PrescriptionDX", objPatientPrescription.PrescriptionDX);
            objDBManager.AddParameter("ProviderInstruction", objPatientPrescription.ProviderInstruction);
            objDBManager.AddParameter("StartDate", objPatientPrescription.StartDate);
            objDBManager.AddParameter("EndDate", objPatientPrescription.EndDate);
            objDBManager.AddParameter("DrugToDrug", objPatientPrescription.DrugToDrug);
            objDBManager.AddParameter("DrugToDisease", objPatientPrescription.DrugToDisease);
            objDBManager.AddParameter("DrugToAllergy", objPatientPrescription.DrugToAllergy);
            objDBManager.AddParameter("PrescriptionStatus", objPatientPrescription.PrescriptionStatus);
            objDBManager.AddParameter("UnitCode", objPatientPrescription.UnitCode);
            objDBManager.AddParameter("EPMsgFunction", objPatientPrescription.EPMsgFunction);
            objDBManager.AddParameter("EPMsgRefNo", objPatientPrescription.EPMsgRefNo);
            objDBManager.AddParameter("EPMsgStatus", objPatientPrescription.EPMsgStatus);
            objDBManager.AddParameter("EPMsgReason", objPatientPrescription.EPMsgReason);
            objDBManager.AddParameter("EPMsgDetail", objPatientPrescription.EPMsgDetail);
            objDBManager.AddParameter("OnHold", objPatientPrescription.OnHold);
            objDBManager.AddParameter("DrugToFood", objPatientPrescription.DrugToFood);
            objDBManager.AddParameter("MedicineTrade", objPatientPrescription.MedicineTrade);
            objDBManager.AddParameter("EPFreeText", objPatientPrescription.EPFreeText);
            objDBManager.AddParameter("EPInitialRefIdentifier", objPatientPrescription.EPInitialRefIdentifier);
            objDBManager.AddParameter("EPPrescriberOrderNo", objPatientPrescription.EPPrescriberOrderNo);
            objDBManager.AddParameter("EPSureScripRefNo", objPatientPrescription.EPSureScripRefNo);
            objDBManager.AddParameter("EPTransControlNo", objPatientPrescription.EPTransControlNo);
            objDBManager.AddParameter("EPResponse_code", objPatientPrescription.EPResponse_code);
            objDBManager.AddParameter("EPResponseQualifier", objPatientPrescription.EPResponseQualifier);
            objDBManager.AddParameter("PracticeId", objPatientPrescription.PracticeId);
            objDBManager.AddParameter("PharmacyDescription", objPatientPrescription.PharmacyDescription);
            objDBManager.AddParameter("Status", objPatientPrescription.Status);
            objDBManager.AddParameter("Status_Comments", objPatientPrescription.Status_Comments);
            objDBManager.AddParameter("RxNorm", objPatientPrescription.RxNorm);
            objDBManager.AddParameter("FormularyDetailForEARReport", objPatientPrescription.FormularyDetailForEARReport);
            objDBManager.AddParameter("EligPatientIdentificationNo", objPatientPrescription.EligPatientIdentificationNo);
            objDBManager.AddParameter("EligBinLocationNumber", objPatientPrescription.EligBinLocationNumber);
            objDBManager.AddParameter("EligPayerID", objPatientPrescription.EligPayerID);
            objDBManager.AddParameter("EligPayerName", objPatientPrescription.EligPayerName);
            objDBManager.AddParameter("EligCardHolderID", objPatientPrescription.EligCardHolderID);
            objDBManager.AddParameter("EligCardHolderName", objPatientPrescription.EligCardHolderName);
            objDBManager.AddParameter("EligGroupID", objPatientPrescription.EligGroupID);
            objDBManager.AddParameter("DrugDatabaseSource", objPatientPrescription.DrugDatabaseSource);
            objDBManager.AddParameter("IsCarryForward", objPatientPrescription.IsCarryForward);
            objDBManager.AddParameter("ModifiedById", objPatientPrescription.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objPatientPrescription.ModifiedDate);
            objDBManager.AddParameter("IncludeNPI", objPatientPrescription.IncludeNPI);
            objDBManager.AddParameter("IncludeDEA", objPatientPrescription.IncludeDEA);
            objDBManager.AddParameter("IncludeStateId", objPatientPrescription.IncludeStateId);
            objDBManager.AddParameter("DispenseAs", objPatientPrescription.DispenseAs);
            objDBManager.AddParameter("Refill1Date", objPatientPrescription.Refill1Date);
            objDBManager.AddParameter("Refill2Date", objPatientPrescription.Refill2Date);
            objDBManager.AddParameter("Refill3Date", objPatientPrescription.Refill3Date);
            objDBManager.AddParameter("Refill4Date", objPatientPrescription.Refill4Date);
            objDBManager.AddParameter("Refill5Date", objPatientPrescription.Refill5Date);
            objDBManager.AddParameter("Refill6Date", objPatientPrescription.Refill6Date);
            ReturnValue = objDBManager.ExecuteNonQuery("PatientPrescription_Update");
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return ReturnValue;
    }

    public int Delete(PatientPrescription objPatientPrescription, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);
            objDBManager.AddParameter("PatientPrescriptionId", objPatientPrescription.PatientPrescriptionId);
            objDBManager.AddParameter("ModifiedById", objPatientPrescription.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objPatientPrescription.ModifiedDate);
            return objDBManager.ExecuteNonQuery("PatientPrescription_Delete");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable GetById(long PatientPrescriptionId, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);
            objDBManager.AddParameter("PatientPrescriptionId", PatientPrescriptionId);
            return objDBManager.ExecuteDataTable("PatientPrescription_GetByID");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable GetPatientPharmacy(long PatientId, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);
            objDBManager.AddParameter("PatientId", PatientId);
            return objDBManager.ExecuteDataTable("PatientPrescription_GetPatientPharmacy");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetMedicine(string medicineName)
    {
        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("MedicneName", medicineName);
        return objDBManager.ExecuteDataTable("PatientPrescription_GetMedicine");
    }

    public DataTable GetPatientMedications(long PatientId)
    {
        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("PatientId", PatientId);
        return objDBManager.ExecuteDataTable("PatientPrescription_GetPatientMedications");
    }

    public DataTable GetAllPendingByChartId(long ChartId)
    {
        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("ChartId", ChartId);
        return objDBManager.ExecuteDataTable("PatientPrescription_GetAllPendingByChartId");
    }
    public int UpdateStatusSigned(string PatientPrescriptionId, bool IncludeNPI, bool IncludeDEA, bool IncludeStateId, bool DispenseAs, long ModifiedById, DateTime ModifiedDate, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);
            objDBManager.AddParameter("PatientPrescriptionId", PatientPrescriptionId);
            objDBManager.AddParameter("IncludeNPI", IncludeNPI);
            objDBManager.AddParameter("IncludeDEA", IncludeDEA);
            objDBManager.AddParameter("IncludeStateId", IncludeStateId);
            objDBManager.AddParameter("DispenseAs", DispenseAs);
            objDBManager.AddParameter("ModifiedById", ModifiedById);
            objDBManager.AddParameter("ModifiedDate", ModifiedDate);
            return objDBManager.ExecuteNonQuery("PatientPrescription_UpdateStatusSigned");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable ReportViewByChartId(long ChartId, long PatientId)
    {
        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("PatientId", PatientId);
        objDBManager.AddParameter("ChartId", ChartId);
        return objDBManager.ExecuteDataTable("PatientPrescription_ReportViewByChartId");
    }

    public DataTable GetPatientPrescriptions(long PatientId)
    {
        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("PatientId", PatientId);
        return objDBManager.ExecuteDataTable("PatientPrescription_GetPatientPrescriptions");
    }
}