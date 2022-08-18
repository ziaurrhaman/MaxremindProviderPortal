using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for ReportsPatientDB
/// </summary>
public class ReportsPatientDB
{
    public ReportsPatientDB()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataSet LoadFilterDropDowns_PatientVitals(long PracticeId)
    {
        DBManager objDBManager = new DBManager();

        objDBManager.AddParameter("PracticeId", PracticeId);

        return objDBManager.ExecuteDataSet("Reports_LoadFilterDropDowns_PatientVitals");
    }

    public DataSet PatientBalanceDue(long PracticeId, string PatientId, string PatientName, int Rows, int PageNumber, string SortBy)
    {
        try
        {
            DBManager objDBManager = new DBManager();

            objDBManager.AddParameter("PracticeId", PracticeId);

            if (PatientId != "")
            {
                objDBManager.AddParameter("PatientId", PatientId);
            }

            if (!string.IsNullOrEmpty(PatientName))
            {
                objDBManager.AddParameter("PatientName", PatientName);
            }

            objDBManager.AddParameter("Rows", Rows);
            objDBManager.AddParameter("PageNumber", PageNumber);

            if (!string.IsNullOrEmpty(SortBy))
            {
                objDBManager.AddParameter("SortBy", SortBy);
            }

            return objDBManager.ExecuteDataSet("Reports_PatientBalanceDue");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet PatientBalanceDueDetail(long PatientId)
    {
        DBManager objDBManager = new DBManager();

        objDBManager.AddParameter("PatientId", PatientId);

        return objDBManager.ExecuteDataSet("Reports_PatientBalanceDueDetail");
    }

    public DataSet PatientClaims(long PracticeId, long PatientId, string PatientName, int Rows, int PageNumber, string SortBy)
    {
        DBManager objDBManager = new DBManager();
        if (PracticeId != 0)
        {
            objDBManager.AddParameter("PracticeId", PracticeId);
        }
        if (PatientId != 0)
        {
            objDBManager.AddParameter("PatientId", PatientId);
        }

        if (!string.IsNullOrEmpty(PatientName))
        {
            objDBManager.AddParameter("PatientName", PatientName);
        }

        objDBManager.AddParameter("Rows", Rows);
        objDBManager.AddParameter("PageNumber", PageNumber);

        if (!string.IsNullOrEmpty(SortBy))
        {
            objDBManager.AddParameter("SortBy", SortBy);
        }

        return objDBManager.ExecuteDataSet("Reports_PatientClaims");
    }

    public DataSet PatientMissingAppointments(long PracticeId, long PatientId, string PatientName, int Rows, int PageNumber, string SortBy)
    {
        try
        {
            DBManager objDBManager = new DBManager();

            objDBManager.AddParameter("PracticeId", PracticeId);

            if (PatientId != 0)
            {
                objDBManager.AddParameter("PatientId", PatientId);
            }

            if (!string.IsNullOrEmpty(PatientName))
            {
                objDBManager.AddParameter("PatientName", PatientName);
            }

            objDBManager.AddParameter("Rows", Rows);
            objDBManager.AddParameter("PageNumber", PageNumber);

            if (!string.IsNullOrEmpty(SortBy))
            {
                objDBManager.AddParameter("SortBy", SortBy);
            }

            return objDBManager.ExecuteDataSet("Reports_PatientMissingAppointments");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    /************added by shahid kazmi 11/16/2017***********/

    // PatientContactList Proc (PatientClaimsList)
    public DataSet PatientClaimsList(long PracticeId, int Rows, int PageNumber, string SortBy, string Actuvity, string ProviderId, string DiagnosisCode, string ProcedureCode, string Gender, string PayerId, string DOB, string Patientid)
    {
        DBManager objDBManager = new DBManager();

        if (PracticeId != 0)
        {
            objDBManager.AddParameter("PracticeId", PracticeId);
        }


        objDBManager.AddParameter("Rows", Rows);
        objDBManager.AddParameter("PageNumber", PageNumber);

        if (!string.IsNullOrEmpty(SortBy))
        {
            objDBManager.AddParameter("SortBy", SortBy);
        }

        if (!string.IsNullOrEmpty(Actuvity))
        {
            objDBManager.AddParameter("Activity", Actuvity);
        }
        if (!string.IsNullOrEmpty(ProviderId))
        {
            objDBManager.AddParameter("Provider", ProviderId);
        }

        if (!string.IsNullOrEmpty(DiagnosisCode))
        {
            objDBManager.AddParameter("Diagnosis", DiagnosisCode);
        }

        if (!string.IsNullOrEmpty(ProcedureCode))
        {
            objDBManager.AddParameter("Procedure", ProcedureCode);
        }

        if (!string.IsNullOrEmpty(Gender))
        {
            objDBManager.AddParameter("Gender", Gender);
        }
        if (!string.IsNullOrEmpty(PayerId))
        {
            objDBManager.AddParameter("Payer", PayerId);
        }
        if (!string.IsNullOrEmpty(DOB))
        {
            objDBManager.AddParameter("DOB", DOB);
        }
        if (!string.IsNullOrEmpty(Patientid))
        {
            objDBManager.AddParameter("PatientId", Patientid);
        }

        return objDBManager.ExecuteDataSet("Report_GetPatientContactList");
    }
    public DataTable GetAllPatients(long PracticeId)
    {
        DBManager ObjDBManager = new DBManager();
        ObjDBManager.AddParameter("@PracticeId", PracticeId);
        return ObjDBManager.ExecuteDataTable("GetAllPatients");
    }
    //Rizwan kharal 7March2018
    public DataTable GetAllPatientsForAppointments(long PracticeId)
    {
        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("@PracticeId", PracticeId);
        return objDBManager.ExecuteDataTable("GetAllPatientsForAppointments");
    }

    //Rizwan kharal 8March2018
    public DataTable GetAllPatientsForAdjustments(long PracticeId)
    {
        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("@PracticeId", PracticeId);
        return objDBManager.ExecuteDataTable("AdjustmentPatient");
    }


    public DataSet PatientDetail(long PracticeId, string PatientId, string Segment)
    {
        DBManager objDBManager = new DBManager();

        if (PracticeId != 0)
        {
            objDBManager.AddParameter("PracticeId", PracticeId);
        }


        if (!string.IsNullOrEmpty(PatientId))
        {
            objDBManager.AddParameter("PatientId", PatientId);
        }
        else
        {
            objDBManager.AddParameter("PatientId", 0);

        }
        objDBManager.AddParameter("Segment", Segment);
        return objDBManager.ExecuteDataSet("Report_GetPatientDetails");
    }
    public DataTable GetTotalPatientSummary(long PracticeId, int Rows, int PageNumber, string SortBy, string DateType, string Provider, string ServiceLocationId, string Payer, string DateFrom, string DateTo)
    {
        DBManager objDBManager = new DBManager();

        if (PracticeId != 0)
        {
            objDBManager.AddParameter("PracticeId", PracticeId);
        }

        objDBManager.AddParameter("Rows", Rows);
        objDBManager.AddParameter("PageNumber", PageNumber);

        if (!string.IsNullOrEmpty(SortBy))
        {
            objDBManager.AddParameter("SortBy", SortBy);
        }

        if (!string.IsNullOrEmpty(DateType))
        {
            objDBManager.AddParameter("DateType", DateType);
        }
        if (!string.IsNullOrEmpty(Provider))
        {
            objDBManager.AddParameter("Provider", Provider);
        }
        if (!string.IsNullOrEmpty(ServiceLocationId))
        {
            objDBManager.AddParameter("ServiceLocationId", ServiceLocationId);
        }
        if (!string.IsNullOrEmpty(Payer))
        {
            objDBManager.AddParameter("Payer", Payer);
        }
        if (DateFrom != "")
        {
            objDBManager.AddParameter("DateFrom", DateFrom);
        }
        if (DateTo != "")
        {
            objDBManager.AddParameter("DateTo", DateTo);
        }
        return objDBManager.ExecuteDataTable("Report_GetPatientSummary");
    }
    public DataSet PatientSummary(long PracticeId, int Rows, int PageNumber, string SortBy, string DateType, string Provider, string ServiceLocationId, string Payer, string DateFrom, string DateTo)
    {
        DBManager objDBManager = new DBManager();

        if (PracticeId != 0)
        {
            objDBManager.AddParameter("PracticeId", PracticeId);
        }

        objDBManager.AddParameter("Rows", Rows);
        objDBManager.AddParameter("PageNumber", PageNumber);

        if (!string.IsNullOrEmpty(SortBy))
        {
            objDBManager.AddParameter("SortBy", SortBy);
        }

        if (!string.IsNullOrEmpty(DateType))
        {
            objDBManager.AddParameter("DateType", DateType);
        }
        if (!string.IsNullOrEmpty(Provider))
        {
            objDBManager.AddParameter("Provider", Provider);
        }
        if (!string.IsNullOrEmpty(ServiceLocationId))
        {
            objDBManager.AddParameter("ServiceLocationId", ServiceLocationId);
        }
        if (!string.IsNullOrEmpty(Payer))
        {
            objDBManager.AddParameter("Payer", Payer);
        }
        if (DateFrom != "")
        {
            objDBManager.AddParameter("DateFrom", DateFrom);
        }
        if (DateTo != "")
        {
            objDBManager.AddParameter("DateTo", DateTo);
        }
        return objDBManager.ExecuteDataSet("Report_GetPatientSummary");
    }
    public DataTable PatientBalanceDetail(long PracticeId, int Rows, int PageNumber, string SortBy, string PatientId, string Procedure, string Date, string AsOf)
    {
        DBManager objDBManager = new DBManager();

        if (PracticeId != 0)
        {
            objDBManager.AddParameter("PracticeId", PracticeId);
        }
        objDBManager.AddParameter("Rows", Rows);
        objDBManager.AddParameter("PageNumber", PageNumber);

        if (!string.IsNullOrEmpty(SortBy))
        {
            objDBManager.AddParameter("SortBy", SortBy);
        }

        if (PatientId != "")
        {
            objDBManager.AddParameter("PatientId", PatientId);
        }
        if (Procedure != "")
        {
            objDBManager.AddParameter("Procedure", Procedure);
        }
        if (Date != "")
        {
            objDBManager.AddParameter("Date", Date);
        }
        if (AsOf != "")
        {
            objDBManager.AddParameter("AsOf", AsOf);
        }
        return objDBManager.ExecuteDataTable("Report_GetPatientBalanceDetail");
    }

    public DataSet dsPatientBalanceDetail(long PracticeId, int Rows, int PageNumber, string SortBy, string PatientId, string Procedure, string Date, string AsOf)
    {
        DBManager objDBManager = new DBManager();

        if (PracticeId != 0)
        {
            objDBManager.AddParameter("PracticeId", PracticeId);
        }
        objDBManager.AddParameter("Rows", Rows);
        objDBManager.AddParameter("PageNumber", PageNumber);

        if (!string.IsNullOrEmpty(SortBy))
        {
            objDBManager.AddParameter("SortBy", SortBy);
        }

        if (PatientId != "")
        {
            objDBManager.AddParameter("PatientId", PatientId);
        }
        if (Procedure != "")
        {
            objDBManager.AddParameter("Procedure", Procedure);
        }
        if (Date != "")
        {
            objDBManager.AddParameter("Date", Date);
        }
        if (!string.IsNullOrEmpty(AsOf))
        {
            objDBManager.AddParameter("AsOf", AsOf);
        }

        return objDBManager.ExecuteDataSet("Report_GetPatientBalanceDetail");
    }

    public DataTable PatientBalanceSummary(long PracticeId, int Rows, int PageNumber, string SortBy, string AssignedTo, string Date, string AsOf)
    {
        DBManager objDBManager = new DBManager();

        if (PracticeId != 0)
        {
            objDBManager.AddParameter("PracticeId", PracticeId);
        }
        objDBManager.AddParameter("Rows", Rows);
        objDBManager.AddParameter("PageNumber", PageNumber);

        if (!string.IsNullOrEmpty(SortBy))
        {
            objDBManager.AddParameter("SortBy", SortBy);
        }
        if (AssignedTo != "")
        {
            objDBManager.AddParameter("AssignedTo", AssignedTo);
        }
        if (Date != "")
        {
            objDBManager.AddParameter("Date", Date);
        }
        if (AsOf != "")
        {
            objDBManager.AddParameter("AsOf", AsOf);
        }
        return objDBManager.ExecuteDataTable("Report_GetPatientBalanceSummary");
    }
    public DataSet GetTotalRowsPatientBalanceSummary(long PracticeId, int Rows, int PageNumber, string SortBy, string AssignedTo, string Date, string AsOf)
    {
        DBManager objDBManager = new DBManager();

        if (PracticeId != 0)
        {
            objDBManager.AddParameter("PracticeId", PracticeId);
        }
        objDBManager.AddParameter("Rows", Rows);
        objDBManager.AddParameter("PageNumber", PageNumber);

        if (!string.IsNullOrEmpty(SortBy))
        {
            objDBManager.AddParameter("SortBy", SortBy);
        }
        if (!string.IsNullOrEmpty(AssignedTo))
        {
            objDBManager.AddParameter("AssignedTo", AssignedTo);
        }
        if (!string.IsNullOrEmpty(Date))
        {
            objDBManager.AddParameter("Date", Date);
        }
        if (!string.IsNullOrEmpty(AsOf))
        {
            objDBManager.AddParameter("AsOf", AsOf);
        }
        return objDBManager.ExecuteDataSet("Report_GetPatientBalanceSummary");
    }
    public DataSet PatientTransactionsSummary(long PracticeId, int Rows, int PageNumber, string SortBy, string DateFrom, string DateTo, string DateType)
    {
        DBManager objDBManager = new DBManager();

        if (PracticeId != 0)
        {
            objDBManager.AddParameter("PracticeId", PracticeId);
        }


        objDBManager.AddParameter("Rows", Rows);
        objDBManager.AddParameter("PageNumber", PageNumber);

        if (!string.IsNullOrEmpty(SortBy))
        {
            objDBManager.AddParameter("SortBy", SortBy);
        }
        if (DateFrom != "")
        {
            objDBManager.AddParameter("DateFrom", DateFrom);
        }
        if (DateTo != "")
        {
            objDBManager.AddParameter("DateTo", DateTo);
        }
        if (!string.IsNullOrEmpty(DateType))
        {
            objDBManager.AddParameter("DateType", DateType);
        }
        return objDBManager.ExecuteDataSet("Report_GetPatientTransactionsSummary");
    }
    public DataSet AdjustmentsDetail(long PracticeId, int Rows, int PageNumber, string SortBy, string DateType, string Provider, string ServiceLocationId, string Payer, string AdjustmentCode, string Procedures, string PatientId, string DateFrom, string DateTo)
    {
        DBManager objDBManager = new DBManager();

        if (PracticeId != 0)
        {
            objDBManager.AddParameter("PracticeId", PracticeId);
        }


        objDBManager.AddParameter("Rows", Rows);
        objDBManager.AddParameter("PageNumber", PageNumber);

        if (!string.IsNullOrEmpty(SortBy))
        {
            objDBManager.AddParameter("SortBy", SortBy);
        }

        if (!string.IsNullOrEmpty(DateType))
        {
            objDBManager.AddParameter("DateType", DateType);
        }
        if (!string.IsNullOrEmpty(Provider))
        {
            objDBManager.AddParameter("Provider", Provider);
        }
        if (!string.IsNullOrEmpty(ServiceLocationId))
        {
            objDBManager.AddParameter("ServiceLocationId", ServiceLocationId);
        }
        if (!string.IsNullOrEmpty(Payer))
        {
            objDBManager.AddParameter("Payer", Payer);
        }
        if (!string.IsNullOrEmpty(AdjustmentCode))
        {
            objDBManager.AddParameter("AdjustmentCode", AdjustmentCode);
        }

        if (!string.IsNullOrEmpty(Procedures))
        {
            objDBManager.AddParameter("Procedures", Procedures);
        }

        if (!string.IsNullOrEmpty(PatientId))
        {
            objDBManager.AddParameter("PatientId", PatientId);
        }
        if (DateFrom != "")
        {
            objDBManager.AddParameter("DateFrom", DateFrom);
        }
        if (DateTo != "")
        {
            objDBManager.AddParameter("DateTo", DateTo);
        }
        return objDBManager.ExecuteDataSet("Report_GetAdjustmentsDetail");
    }
    public DataSet AdjustmentsSummary(long PracticeId, string DateType, string Provider, string ServiceLocationId, string Payer, string AdjustmentCode, string Procedures, string PatientId, string DateFrom, string DateTo)
    {
        DBManager objDBManager = new DBManager();

        if (PracticeId != 0)
        {
            objDBManager.AddParameter("PracticeId", PracticeId);
        }

        if (!string.IsNullOrEmpty(DateType))
        {
            objDBManager.AddParameter("DateType", DateType);
        }
        if (!string.IsNullOrEmpty(Provider))
        {
            objDBManager.AddParameter("Provider", Provider);
        }
        if (!string.IsNullOrEmpty(ServiceLocationId))
        {
            objDBManager.AddParameter("ServiceLocationId", ServiceLocationId);
        }
        if (!string.IsNullOrEmpty(Payer))
        {
            objDBManager.AddParameter("Payer", Payer);
        }
        if (!string.IsNullOrEmpty(AdjustmentCode))
        {
            objDBManager.AddParameter("AdjustmentCode", AdjustmentCode);
        }

        if (!string.IsNullOrEmpty(Procedures))
        {
            objDBManager.AddParameter("Procedures", Procedures);
        }

        if (!string.IsNullOrEmpty(PatientId))
        {
            objDBManager.AddParameter("PatientId", PatientId);
        }
        if (DateFrom != "")
        {
            objDBManager.AddParameter("DateFrom", DateFrom);
        }
        if (DateTo != "")
        {
            objDBManager.AddParameter("DateTo", DateTo);
        }
        return objDBManager.ExecuteDataSet("Report_GetAdjustmentsSummary");
    }

    public DataTable GetTotalAdjustmentsSummary(long PracticeId, string DateType, string Provider, string ServiceLocationId, string Payer, string AdjustmentCode, string Procedures, string PatientId, string DateFrom, string DateTo)
    {
        DBManager objDBManager = new DBManager();

        if (PracticeId != 0)
        {
            objDBManager.AddParameter("PracticeId", PracticeId);
        }

        if (!string.IsNullOrEmpty(DateType))
        {
            objDBManager.AddParameter("DateType", DateType);
        }
        if (!string.IsNullOrEmpty(Provider))
        {
            objDBManager.AddParameter("Provider", Provider);
        }
        if (!string.IsNullOrEmpty(ServiceLocationId))
        {
            objDBManager.AddParameter("ServiceLocationId", ServiceLocationId);
        }
        if (!string.IsNullOrEmpty(Payer))
        {
            objDBManager.AddParameter("Payer", Payer);
        }
        if (!string.IsNullOrEmpty(AdjustmentCode))
        {
            objDBManager.AddParameter("AdjustmentCode", AdjustmentCode);
        }

        if (!string.IsNullOrEmpty(Procedures))
        {
            objDBManager.AddParameter("Procedures", Procedures);
        }

        if (!string.IsNullOrEmpty(PatientId))
        {
            objDBManager.AddParameter("PatientId", PatientId);
        }
        if (DateFrom != "")
        {
            objDBManager.AddParameter("DateFrom", DateFrom);
        }
        if (DateTo != "")
        {
            objDBManager.AddParameter("DateTo", DateTo);
        }
        return objDBManager.ExecuteDataTable("Report_GetAdjustmentsSummary");
    }


    public DataSet ChargesSummary(long PracticeId, int Rows, int PageNumber, string SortBy, string DateType, string Provider, string ServiceLocationId, string Payer, string Procedures, string PatientId, string DateFrom, string DateTo)
    {
        DBManager objDBManager = new DBManager();

        if (PracticeId != 0)
        {
            objDBManager.AddParameter("PracticeId", PracticeId);
        }
        objDBManager.AddParameter("Rows", Rows);
        objDBManager.AddParameter("PageNumber", PageNumber);

        if (!string.IsNullOrEmpty(SortBy))
        {
            objDBManager.AddParameter("SortBy", SortBy);
        }
        if (!string.IsNullOrEmpty(DateType))
        {
            objDBManager.AddParameter("DateType", DateType);
        }
        if (!string.IsNullOrEmpty(Provider))
        {
            objDBManager.AddParameter("Provider", Provider);
        }
        if (!string.IsNullOrEmpty(ServiceLocationId))
        {
            objDBManager.AddParameter("ServiceLocationId", ServiceLocationId);
        }
        if (!string.IsNullOrEmpty(Payer))
        {
            objDBManager.AddParameter("Payer", Payer);
        }


        if (!string.IsNullOrEmpty(Procedures))
        {
            objDBManager.AddParameter("Procedures", Procedures);
        }

        if (!string.IsNullOrEmpty(PatientId))
        {
            objDBManager.AddParameter("PatientId", PatientId);
        }
        if (DateFrom != "")
        {
            objDBManager.AddParameter("DateFrom", DateFrom);
        }
        if (DateTo != "")
        {
            objDBManager.AddParameter("DateTo", DateTo);
        }
        return objDBManager.ExecuteDataSet("Report_GetChargesSummary");
    }

    public DataTable GetTotalChargesSummary(long PracticeId, int Rows, int PageNumber, string SortBy, string DateType, string Provider, string ServiceLocationId, string Payer, string Procedures, string PatientId, string DateFrom, string DateTo)
    {
        DBManager objDBManager = new DBManager();

        if (PracticeId != 0)
        {
            objDBManager.AddParameter("PracticeId", PracticeId);
        }
        objDBManager.AddParameter("Rows", Rows);
        objDBManager.AddParameter("PageNumber", PageNumber);

        if (!string.IsNullOrEmpty(SortBy))
        {
            objDBManager.AddParameter("SortBy", SortBy);
        }
        if (!string.IsNullOrEmpty(DateType))
        {
            objDBManager.AddParameter("DateType", DateType);
        }
        if (!string.IsNullOrEmpty(Provider))
        {
            objDBManager.AddParameter("Provider", Provider);
        }
        if (!string.IsNullOrEmpty(ServiceLocationId))
        {
            objDBManager.AddParameter("ServiceLocationId", ServiceLocationId);
        }
        if (!string.IsNullOrEmpty(Payer))
        {
            objDBManager.AddParameter("Payer", Payer);
        }


        if (!string.IsNullOrEmpty(Procedures))
        {
            objDBManager.AddParameter("Procedures", Procedures);
        }

        if (!string.IsNullOrEmpty(PatientId))
        {
            objDBManager.AddParameter("PatientId", PatientId);
        }
        if (DateFrom != "")
        {
            objDBManager.AddParameter("DateFrom", DateFrom);
        }
        if (DateTo != "")
        {
            objDBManager.AddParameter("DateTo", DateTo);
        }
        return objDBManager.ExecuteDataTable("Report_GetChargesSummary");
    }

    public DataTable GetTotalChargesDetail(long PracticeId, int Rows, int PageNumber, string SortBy, string DateType, string Provider, string ServiceLocationId, string Payer, string Procedures, string PatientId, string DateFrom, string DateTo)
    {
        DBManager objDBManager = new DBManager();

        if (PracticeId != 0)
        {
            objDBManager.AddParameter("PracticeId", PracticeId);
        }
        objDBManager.AddParameter("Rows", Rows);
        objDBManager.AddParameter("PageNumber", PageNumber);

        if (!string.IsNullOrEmpty(SortBy))
        {
            objDBManager.AddParameter("SortBy", SortBy);
        }
        if (!string.IsNullOrEmpty(DateType))
        {
            objDBManager.AddParameter("DateType", DateType);
        }
        if (!string.IsNullOrEmpty(Provider))
        {
            objDBManager.AddParameter("Provider", Provider);
        }
        if (!string.IsNullOrEmpty(ServiceLocationId))
        {
            objDBManager.AddParameter("ServiceLocationId", ServiceLocationId);
        }
        if (!string.IsNullOrEmpty(Payer))
        {
            objDBManager.AddParameter("Payer", Payer);
        }


        if (!string.IsNullOrEmpty(Procedures))
        {
            objDBManager.AddParameter("Procedures", Procedures);
        }

        if (!string.IsNullOrEmpty(PatientId))
        {
            objDBManager.AddParameter("PatientId", PatientId);
        }
        if (DateFrom != "")
        {
            objDBManager.AddParameter("DateFrom", DateFrom);
        }
        if (DateTo != "")
        {
            objDBManager.AddParameter("DateTo", DateTo);
        }
        return objDBManager.ExecuteDataTable("Report_GetChargesDetail");
    }

    public DataSet ChargesDetail(long PracticeId, int Rows, int PageNumber, string SortBy, string DateType, string Provider, string ServiceLocationId, string Payer, string Procedures, string PatientId, string DateFrom, string DateTo)
    {
        DBManager objDBManager = new DBManager();

        if (PracticeId != 0)
        {
            objDBManager.AddParameter("PracticeId", PracticeId);
        }
        objDBManager.AddParameter("Rows", Rows);
        objDBManager.AddParameter("PageNumber", PageNumber);

        if (!string.IsNullOrEmpty(SortBy))
        {
            objDBManager.AddParameter("SortBy", SortBy);
        }
        if (!string.IsNullOrEmpty(DateType))
        {
            objDBManager.AddParameter("DateType", DateType);
        }
        if (!string.IsNullOrEmpty(Provider))
        {
            objDBManager.AddParameter("Provider", Provider);
        }
        if (!string.IsNullOrEmpty(ServiceLocationId))
        {
            objDBManager.AddParameter("ServiceLocationId", ServiceLocationId);
        }
        if (!string.IsNullOrEmpty(Payer))
        {
            objDBManager.AddParameter("Payer", Payer);
        }


        if (!string.IsNullOrEmpty(Procedures))
        {
            objDBManager.AddParameter("Procedures", Procedures);
        }

        if (!string.IsNullOrEmpty(PatientId))
        {
            objDBManager.AddParameter("PatientId", PatientId);
        }
        if (DateFrom != "")
        {
            objDBManager.AddParameter("DateFrom", DateFrom);
        }
        if (DateTo != "")
        {
            objDBManager.AddParameter("DateTo", DateTo);
        }
        return objDBManager.ExecuteDataSet("Report_GetChargesDetail");
    }

    public DataSet ServiceLocations(long PracticeId, int Rows, int PageNumber, string SortBy)
    {
        DBManager objDBManager = new DBManager();

        if (PracticeId != 0)
        {
            objDBManager.AddParameter("PracticeId", PracticeId);
        }
        objDBManager.AddParameter("Rows", Rows);
        objDBManager.AddParameter("PageNumber", PageNumber);

        if (!string.IsNullOrEmpty(SortBy))
        {
            objDBManager.AddParameter("SortBy", SortBy);
        }
        return objDBManager.ExecuteDataSet("Report_GetServiceLocations");
    }
    public DataSet GetReferringPhysicians(long PracticeId, int Rows, int PageNumber, string SortBy)
    {
        DBManager objDBManager = new DBManager();

        if (PracticeId != 0)
        {
            objDBManager.AddParameter("PracticeId", PracticeId);
        }
        objDBManager.AddParameter("Rows", Rows);
        objDBManager.AddParameter("PageNumber", PageNumber);

        if (!string.IsNullOrEmpty(SortBy))
        {
            objDBManager.AddParameter("SortBy", SortBy);
        }
        return objDBManager.ExecuteDataSet("Report_GetReferringPhysicians");
    }
    public DataSet GetProviders(long PracticeId, int Rows, int PageNumber, string SortBy)
    {
        DBManager objDBManager = new DBManager();

        if (PracticeId != 0)
        {
            objDBManager.AddParameter("PracticeId", PracticeId);
        }
        objDBManager.AddParameter("Rows", Rows);
        objDBManager.AddParameter("PageNumber", PageNumber);

        if (!string.IsNullOrEmpty(SortBy))
        {
            objDBManager.AddParameter("SortBy", SortBy);
        }
        return objDBManager.ExecuteDataSet("Report_GetProviders");
    }
    public DataSet GetPaymentByProcedure(long PracticeId, int Rows, int PageNumber, string SortBy, string DateFrom, string DateTo)
    {
        DBManager objDBManager = new DBManager();

        if (PracticeId != 0)
        {
            objDBManager.AddParameter("PracticeId", PracticeId);
        }
        objDBManager.AddParameter("Rows", Rows);
        objDBManager.AddParameter("PageNumber", PageNumber);

        if (!string.IsNullOrEmpty(SortBy))
        {
            objDBManager.AddParameter("SortBy", SortBy);
        }
        if (DateFrom != "")
        {
            objDBManager.AddParameter("DateFrom", DateFrom);
        }
        if (DateTo != "")
        {
            objDBManager.AddParameter("DateTo", DateTo);
        }
        return objDBManager.ExecuteDataSet("Report_GetPaymentByProcedure");
    }
    public DataTable GetTotalPaymentByProcedure(long PracticeId, int Rows, int PageNumber, string SortBy, string DateFrom, string DateTo)
    {
        DBManager objDBManager = new DBManager();

        if (PracticeId != 0)
        {
            objDBManager.AddParameter("PracticeId", PracticeId);
        }
        objDBManager.AddParameter("Rows", Rows);
        objDBManager.AddParameter("PageNumber", PageNumber);

        if (!string.IsNullOrEmpty(SortBy))
        {
            objDBManager.AddParameter("SortBy", SortBy);
        }
        if (DateFrom != "")
        {
            objDBManager.AddParameter("DateFrom", DateFrom);
        }
        if (DateTo != "")
        {
            objDBManager.AddParameter("DateTo", DateTo);
        }
        return objDBManager.ExecuteDataTable("Report_GetPaymentByProcedure");
    }
    public DataSet GetPaymentsDetail(long PracticeId, int Rows, int PageNumber, string SortBy, string DateFrom, string DateTo, string Insurance = "", string PaymentType = "", string PaymentId = "")
    {
        DBManager objDBManager = new DBManager();

        if (PracticeId != 0)
        {
            objDBManager.AddParameter("PracticeId", PracticeId);
        }
        objDBManager.AddParameter("Rows", Rows);
        objDBManager.AddParameter("PageNumber", PageNumber);
        if (!string.IsNullOrEmpty(PaymentId))
        {
            objDBManager.AddParameter("CheckNo", PaymentId);
        }
        if (!string.IsNullOrEmpty(PaymentType))
        {
            objDBManager.AddParameter("PaymentType", PaymentType);
        }
        if (!string.IsNullOrEmpty(Insurance))
        {
            objDBManager.AddParameter("InsuranceId", Insurance);
        }
        if (!string.IsNullOrEmpty(SortBy))
        {
            objDBManager.AddParameter("SortBy", SortBy);
        }
        if (DateFrom != "")
        {
            objDBManager.AddParameter("DateFrom", DateFrom);
        }
        if (DateTo != "")
        {
            objDBManager.AddParameter("DateTo", DateTo);
        }
        return objDBManager.ExecuteDataSet("Report_GetPaymentsDetail");
    }
    public DataSet GetPaymentsSummary(long PracticeId, string DateType, string DateFrom, string DateTo, string PayerType, string Insurance, string Patient, string ProviderIdbYNPI, bool? IsImportedDataOnly)
    {
        DBManager objDBManager = new DBManager();

        if (PracticeId != 0)
        {
            objDBManager.AddParameter("PracticeId", PracticeId);
        }
        if (DateType != "")
        {
            objDBManager.AddParameter("DateType", DateType);
        }

        if (DateFrom != "")
        {
            objDBManager.AddParameter("FromDate", DateFrom);
        }
        if (DateTo != "")
        {
            objDBManager.AddParameter("ToDate", DateTo);
        }
        if (PayerType != "")
        {
            objDBManager.AddParameter("PayerType", PayerType);
        }
        if (Insurance != "")
        {
            objDBManager.AddParameter("Insurance", Insurance);
        }
        if (Patient != "")
        {
            objDBManager.AddParameter("Patient", Patient);
        }
        if (ProviderIdbYNPI != "")
        {
            objDBManager.AddParameter("@Physician", ProviderIdbYNPI);
        }
        if (IsImportedDataOnly != null)
        {
            objDBManager.AddParameter("@IsImportedDataOnly", IsImportedDataOnly);
        }
        //old sp PaymentSummary
        return objDBManager.ExecuteDataSet("ProviderWisePaymentSummary");
    }
    public DataTable GetTotalPaymentsSummary(long PracticeId, string DateType, string DateFrom, string DateTo, string PayerType, string Insurance, string Patient)
    {
        DBManager objDBManager = new DBManager();
        if (PracticeId != 0)
        {
            objDBManager.AddParameter("PracticeId", PracticeId);
        }
        if (DateType != "")
        {
            objDBManager.AddParameter("DateType", DateType);
        }

        if (DateFrom != "")
        {
            objDBManager.AddParameter("FromDate", DateFrom);
        }
        if (DateTo != "")
        {
            objDBManager.AddParameter("ToDate", DateTo);
        }
        if (PayerType != "")
        {
            objDBManager.AddParameter("PayerType", PayerType);
        }
        if (Insurance != "")
        {
            objDBManager.AddParameter("Insurance", Insurance);
        }
        if (Patient != "")
        {
            objDBManager.AddParameter("Patient", Patient);
        }
        return objDBManager.ExecuteDataTable("PaymentSummary");
    }
    public DataSet GetProcedurePaymentsSummary(long PracticeId, int Rows, int PageNumber, string SortBy, string DateFrom, string DateTo)
    {
        DBManager objDBManager = new DBManager();

        if (PracticeId != 0)
        {
            objDBManager.AddParameter("PracticeId", PracticeId);
        }
        objDBManager.AddParameter("Rows", Rows);
        objDBManager.AddParameter("PageNumber", PageNumber);

        if (!string.IsNullOrEmpty(SortBy))
        {
            objDBManager.AddParameter("SortBy", SortBy);
        }
        if (DateFrom != "")
        {
            objDBManager.AddParameter("DateFrom", DateFrom);
        }
        if (DateTo != "")
        {
            objDBManager.AddParameter("DateTo", DateTo);
        }
        return objDBManager.ExecuteDataSet("Report_GetProcedurePaymentsSummary");
    }
    public DataSet GetCPTwisePaymentDetailNEW(long PracticeId, int Rows, int PageNumber, string CPTCodes, string insuranceIds,
        string insuranceType, string CPTOne, string InsOne, bool? IsImportedDataOnly, string ProviderId = "", string Location = "")
    {
        DBManager objDBManager = new DBManager();

        objDBManager.AddParameter("PracticeId", PracticeId);
        objDBManager.AddParameter("Rows", Rows);
        objDBManager.AddParameter("PageNumber", PageNumber);
        if (!string.IsNullOrEmpty(CPTCodes))
        {
            objDBManager.AddParameter("@CPTCode", CPTCodes);
        }
        if (!string.IsNullOrEmpty(insuranceIds))
        {
            objDBManager.AddParameter("@InsuranceId", insuranceIds);
        }
        if (!string.IsNullOrEmpty(insuranceType))
        {
            objDBManager.AddParameter("@PaymentSource", insuranceType);
        }
        if (!string.IsNullOrEmpty(CPTOne))
        {
            objDBManager.AddParameter("@CPTOne", CPTOne);
        }
        if (!string.IsNullOrEmpty(ProviderId))
        {
            objDBManager.AddParameter("@ProviderId", ProviderId);
        }
        if (!string.IsNullOrEmpty(Location))
        {
            objDBManager.AddParameter("@LocationId", Location);
        }
        if (!string.IsNullOrEmpty(InsOne))
        {
            objDBManager.AddParameter("@InsOne", InsOne);
        }
        if (IsImportedDataOnly != null)
        {
            objDBManager.AddParameter("@IsImportedDataOnly", IsImportedDataOnly);
        }
        return objDBManager.ExecuteDataSet("GetCPTwisePaymentDetailNEW");
    }


    public DataSet GetContractManagementSummary(long PracticeId, int Rows, int PageNumber, string SortBy, string DateType, string Provider, string ServiceLocationId, string Procedures, string PatientId, string DateFrom, string DateTo, string InsuranceId)
    {
        DBManager objDBManager = new DBManager();

        if (PracticeId != 0)
        {
            objDBManager.AddParameter("PracticeId", PracticeId);
        }
        objDBManager.AddParameter("Rows", Rows);
        objDBManager.AddParameter("PageNumber", PageNumber);

        if (!string.IsNullOrEmpty(SortBy))
        {
            objDBManager.AddParameter("SortBy", SortBy);
        }
        if (!string.IsNullOrEmpty(DateType))
        {
            objDBManager.AddParameter("DateType", DateType);
        }
        if (!string.IsNullOrEmpty(Provider))
        {
            objDBManager.AddParameter("Provider", Provider);
        }
        if (!string.IsNullOrEmpty(ServiceLocationId))
        {
            objDBManager.AddParameter("ServiceLocationId", ServiceLocationId);
        }



        if (!string.IsNullOrEmpty(Procedures))
        {
            objDBManager.AddParameter("Procedures", Procedures);
        }

        if (!string.IsNullOrEmpty(PatientId))
        {
            objDBManager.AddParameter("PatientId", PatientId);
        }
        if (DateFrom != "")
        {
            objDBManager.AddParameter("DateFrom", DateFrom);
        }
        if (DateTo != "")
        {
            objDBManager.AddParameter("DateTo", DateTo);
        }
        if (InsuranceId != "")
        {
            objDBManager.AddParameter("InsuranceId", InsuranceId);
        }
        return objDBManager.ExecuteDataSet("Report_GetContractManagementSummary");
    }
    public DataTable GetTotalContractManagementSummary(long PracticeId, int Rows, int PageNumber, string SortBy, string DateType, string Provider, string ServiceLocationId, string Procedures, string PatientId, string DateFrom, string DateTo, long? InsuranceId)
    {
        DBManager objDBManager = new DBManager();

        if (PracticeId != 0)
        {
            objDBManager.AddParameter("PracticeId", PracticeId);
        }
        objDBManager.AddParameter("Rows", Rows);
        objDBManager.AddParameter("PageNumber", PageNumber);

        if (!string.IsNullOrEmpty(SortBy))
        {
            objDBManager.AddParameter("SortBy", SortBy);
        }
        if (!string.IsNullOrEmpty(DateType))
        {
            objDBManager.AddParameter("DateType", DateType);
        }
        if (!string.IsNullOrEmpty(Provider))
        {
            objDBManager.AddParameter("Provider", Provider);
        }
        if (!string.IsNullOrEmpty(ServiceLocationId))
        {
            objDBManager.AddParameter("ServiceLocationId", ServiceLocationId);
        }



        if (!string.IsNullOrEmpty(Procedures))
        {
            objDBManager.AddParameter("Procedures", Procedures);
        }

        if (!string.IsNullOrEmpty(PatientId))
        {
            objDBManager.AddParameter("PatientId", PatientId);
        }
        if (DateFrom != "")
        {
            objDBManager.AddParameter("DateFrom", DateFrom);
        }
        if (DateTo != "")
        {
            objDBManager.AddParameter("DateTo", DateTo);
        }
        if (InsuranceId != 0)
        {
            objDBManager.AddParameter("InsuranceId", InsuranceId);
        }
        return objDBManager.ExecuteDataTable("Report_GetContractManagementSummary");
    }

    public DataTable GetTotalContractManagementDetail(long PracticeId, int Rows, int PageNumber, string SortBy, string DateType, string Provider, string ServiceLocationId, string Payer, string Procedures, string PatientId, string DateFrom, string DateTo)
    {
        DBManager objDBManager = new DBManager();

        if (PracticeId != 0)
        {
            objDBManager.AddParameter("PracticeId", PracticeId);
        }
        objDBManager.AddParameter("Rows", Rows);
        objDBManager.AddParameter("PageNumber", PageNumber);

        if (!string.IsNullOrEmpty(SortBy))
        {
            objDBManager.AddParameter("SortBy", SortBy);
        }
        if (!string.IsNullOrEmpty(DateType))
        {
            objDBManager.AddParameter("DateType", DateType);
        }
        if (!string.IsNullOrEmpty(Provider))
        {
            objDBManager.AddParameter("Provider", Provider);
        }
        if (!string.IsNullOrEmpty(ServiceLocationId))
        {
            objDBManager.AddParameter("ServiceLocationId", ServiceLocationId);
        }
        if (!string.IsNullOrEmpty(Payer))
        {
            objDBManager.AddParameter("Payer", Payer);
        }


        if (!string.IsNullOrEmpty(Procedures))
        {
            objDBManager.AddParameter("Procedures", Procedures);
        }

        if (!string.IsNullOrEmpty(PatientId))
        {
            objDBManager.AddParameter("PatientId", PatientId);
        }
        if (DateFrom != "")
        {
            objDBManager.AddParameter("DateFrom", DateFrom);
        }
        if (DateTo != "")
        {
            objDBManager.AddParameter("DateTo", DateTo);
        }
        return objDBManager.ExecuteDataTable("Report_GetContractManagementDetail");
    }

    public DataSet GetContractManagementDetail(long PracticeId, int Rows, int PageNumber, string SortBy, string DateType, string Provider, string ServiceLocationId, string Payer, string Procedures, string PatientId, string DateFrom, string DateTo)
    {
        DBManager objDBManager = new DBManager();

        if (PracticeId != 0)
        {
            objDBManager.AddParameter("PracticeId", PracticeId);
        }
        objDBManager.AddParameter("Rows", Rows);
        objDBManager.AddParameter("PageNumber", PageNumber);

        if (!string.IsNullOrEmpty(SortBy))
        {
            objDBManager.AddParameter("SortBy", SortBy);
        }
        if (!string.IsNullOrEmpty(DateType))
        {
            objDBManager.AddParameter("DateType", DateType);
        }
        if (!string.IsNullOrEmpty(Provider))
        {
            objDBManager.AddParameter("Provider", Provider);
        }
        if (!string.IsNullOrEmpty(ServiceLocationId))
        {
            objDBManager.AddParameter("ServiceLocationId", ServiceLocationId);
        }
        if (!string.IsNullOrEmpty(Payer))
        {
            objDBManager.AddParameter("Payer", Payer);
        }


        if (!string.IsNullOrEmpty(Procedures))
        {
            objDBManager.AddParameter("Procedures", Procedures);
        }

        if (!string.IsNullOrEmpty(PatientId))
        {
            objDBManager.AddParameter("PatientId", PatientId);
        }
        if (DateFrom != "")
        {
            objDBManager.AddParameter("DateFrom", DateFrom);
        }
        if (DateTo != "")
        {
            objDBManager.AddParameter("DateTo", DateTo);
        }
        return objDBManager.ExecuteDataSet("Report_GetContractManagementDetail");
    }



    public DataSet GetMissedCopays(long PracticeId, int Rows, int PageNumber, string SortBy, string DateFrom, string DateTo)
    {
        DBManager objDBManager = new DBManager();

        if (PracticeId != 0)
        {
            objDBManager.AddParameter("PracticeId", PracticeId);
        }
        objDBManager.AddParameter("Rows", Rows);
        objDBManager.AddParameter("PageNumber", PageNumber);

        if (!string.IsNullOrEmpty(SortBy))
        {
            objDBManager.AddParameter("SortBy", SortBy);
        }
        if (DateFrom != "")
        {
            objDBManager.AddParameter("DateFrom", DateFrom);
        }
        if (DateTo != "")
        {
            objDBManager.AddParameter("DateTo", DateTo);
        }
        return objDBManager.ExecuteDataSet("Report_GetMissedCopays");
    }
    public DataSet GetPaymentApplication(long PracticeId, int Rows, int PageNumber, string SortBy, string PayerName, string CheckNumber, string DateFrom, string DateTo, string PatientId = "")
    {
        DBManager objDBManager = new DBManager();

        if (PracticeId != 0)
        {
            objDBManager.AddParameter("PracticeId", PracticeId);
        }
        objDBManager.AddParameter("PageNumber", PageNumber);
        if (Rows != 0)
        {
            objDBManager.AddParameter("Rows", Rows);
          
        }
        //if(DateType!="")
        //{
        //    objDBManager.AddParameter("DateType", DateType);
        //}

        if (!string.IsNullOrEmpty(SortBy))
        {
            objDBManager.AddParameter("SortBy", SortBy);
        }
        if (PayerName != "")
        {
            if (PayerName != "0")
            {
                objDBManager.AddParameter("PayerName", PayerName);
            }
        }
        if (CheckNumber != "")
        {
            if (CheckNumber != "0")
            {
                objDBManager.AddParameter("CheckNumber", CheckNumber);
            }
        }
        if (DateFrom != "")
        {
            objDBManager.AddParameter("DateFrom", Convert.ToDateTime(DateFrom));
        }
        if (DateTo != "")
        {
            objDBManager.AddParameter("DateTo", Convert.ToDateTime(DateTo));
        }
        if (!string.IsNullOrEmpty(PatientId))
        {
            objDBManager.AddParameter("PatientId", PatientId);
        }
        return objDBManager.ExecuteDataSet("Report_GetPaymentApplication");
    }
    public DataSet GetPaymentApplicationSummary(long PracticeId, string DateFrom, string DateTo,string DateType, string Insurance, string ProviderIdbYNPI,string PracticeLocationId)
    {
        DBManager objDBManager = new DBManager();

        if (PracticeId != 0)
        {
            objDBManager.AddParameter("PracticeId", PracticeId);
        }
        // Add by iqra 16/30/2022 Resolve Filter bugs//
        objDBManager.AddParameter("Payer", Insurance);
        objDBManager.AddParameter("Provider", ProviderIdbYNPI);
        objDBManager.AddParameter("Location", PracticeLocationId);
        // End by iqra 16/30/2022 //
        objDBManager.AddParameter("DateFrom", DateFrom);

        objDBManager.AddParameter("DateTo", DateTo);
        objDBManager.AddParameter("DateType", DateType);
        return objDBManager.ExecuteDataSet("Report_GetPaymentApplicationSummary");
    }
    public DataSet GetUnappliedAnalysis(long PracticeId, string DateFrom, string DateTo, string Payers = "", string PaymentType = "")
    {
        DBManager objDBManager = new DBManager();

        if (PracticeId != 0)
        {
            objDBManager.AddParameter("PracticeId", PracticeId);
        }
        if (DateFrom != "")
        {
            objDBManager.AddParameter("DateFrom", DateFrom);
        }
        if (DateTo != "")
        {
            objDBManager.AddParameter("DateTo", DateTo);
        }
        if (Payers != "")
        {
            objDBManager.AddParameter("Payer", Payers);
        }
        if (PaymentType != "")
        {
            objDBManager.AddParameter("PaymentType", PaymentType);
        }
        return objDBManager.ExecuteDataSet("Report_GetUnappliedAnalysis");
    }
    public DataTable GetTotalUnappliedAnalysis(long PracticeId, string DateFrom, string DateTo)
    {
        DBManager objDBManager = new DBManager();

        if (PracticeId != 0)
        {
            objDBManager.AddParameter("PracticeId", PracticeId);
        }
        if (DateFrom != "")
        {
            objDBManager.AddParameter("DateFrom", DateFrom);
        }
        if (DateTo != "")
        {
            objDBManager.AddParameter("DateTo", DateTo);
        }
        return objDBManager.ExecuteDataTable("Report_GetUnappliedAnalysis");
    }
    public DataSet GetPayerMixSummary(long PracticeId, int Rows, int PageNumber, string payer, bool? IsImportedDataOnly)
    {
        DBManager objDBManager = new DBManager();

        if (PracticeId != 0)
        {
            objDBManager.AddParameter("PracticeId", PracticeId);
        }
        objDBManager.AddParameter("Rows", Rows);
        objDBManager.AddParameter("PageNumber", PageNumber);

        if (!string.IsNullOrEmpty(payer))
        {
            objDBManager.AddParameter("Payer", payer);
        }
        if (IsImportedDataOnly != null)
        {
            objDBManager.AddParameter("@IsImportedDataOnly", IsImportedDataOnly);
        }
        
        //if (ProviderId != "")
        //{
        //    objDBManager.AddParameter("ProviderId", ProviderId);
        //}
        //if (LocationId != "")
        //{
        //    objDBManager.AddParameter("LocationId", LocationId);
        //}
        return objDBManager.ExecuteDataSet("Report_GetPayerMixSummary");
    }
    public DataSet GetARAgingSummary(long Userid, long PracticeId, string AgingBy, string Asof, string ProviderId, string LocationId, string PayerId, bool? IsImportedDataOnly)
    {
        DBManager objDBManager = new DBManager();

        if (Userid != 0)
        {
            objDBManager.AddParameter("Userid", Userid);
        }

        if (PracticeId != 0)
        {
            objDBManager.AddParameter("PracticeId", PracticeId);
        }
        if (AgingBy != "")
        {
            objDBManager.AddParameter("@AgingBy", @AgingBy);
        }
        if (Asof != "")
        {
            objDBManager.AddParameter("Asof", @Asof);
        }

        if (ProviderId != "")
        {
            objDBManager.AddParameter("ProviderId", ProviderId);
        }
        if (LocationId != "")
        {
            objDBManager.AddParameter("LocationId", LocationId);
        }
        if (PayerId != "")
        {
            objDBManager.AddParameter("PayerId ", PayerId);
        }
        if (IsImportedDataOnly != null)
        {
            objDBManager.AddParameter("IsImportedDataOnly ", IsImportedDataOnly);
        }
        return objDBManager.ExecuteDataSet("PPGetAccountReceivableAging");
    }
    public DataSet GetInsuranceCollectionDetail(long PracticeId, int Rows, int PageNumber, string SortBy, string AgingType, string AgingDate, string PracticeLocationId, string ProviderId, string PayerId, string ClaimStatus)
    {
        DBManager objDBManager = new DBManager();

        if (PracticeId != 0)
        {
            objDBManager.AddParameter("PracticeId", PracticeId);
        }
        objDBManager.AddParameter("Rows", Rows);
        objDBManager.AddParameter("PageNumber", PageNumber);

        if (!string.IsNullOrEmpty(SortBy))
        {
            objDBManager.AddParameter("SortBy", SortBy);
        }
        if (AgingType != "")
        {
            objDBManager.AddParameter("AgingType", AgingType);
        }
        if (AgingDate != "")
        {
            objDBManager.AddParameter("AgingDate ", AgingDate);
        }

        if (!string.IsNullOrEmpty(PracticeLocationId))
        {
            objDBManager.AddParameter("PracticeLocationId", PracticeLocationId);
        }
        if (ProviderId != "")
        {
            objDBManager.AddParameter("ProviderId", ProviderId);
        }
        if (PayerId != "")
        {
            objDBManager.AddParameter("PayerId", PayerId);
        }
        if (ClaimStatus != "")
        {
            objDBManager.AddParameter("ClaimStatus", ClaimStatus);
        }
        return objDBManager.ExecuteDataSet("Report_GetInsuranceCollectionDetail");
    }

    public DataSet GetInsuranceCollectionSummary(long PracticeId, int Rows, int PageNumber, string SortBy, string AgingType, string AgingDate, string PracticeLocationId, string ProviderId, string PayerId, string ClaimStatus)
    {
        DBManager objDBManager = new DBManager();

        if (PracticeId != 0)
        {
            objDBManager.AddParameter("PracticeId", PracticeId);
        }
        objDBManager.AddParameter("Rows", Rows);
        objDBManager.AddParameter("PageNumber", PageNumber);

        if (!string.IsNullOrEmpty(SortBy))
        {
            objDBManager.AddParameter("SortBy", SortBy);
        }
        if (AgingType != "")
        {
            objDBManager.AddParameter("AgingType", AgingType);
        }
        if (AgingDate != "")
        {
            objDBManager.AddParameter("AgingDate ", AgingDate);
        }

        if (!string.IsNullOrEmpty(PracticeLocationId))
        {
            objDBManager.AddParameter("PracticeLocationId", PracticeLocationId);
        }
        if (ProviderId != "")
        {
            objDBManager.AddParameter("ProviderId", ProviderId);
        }
        if (PayerId != "")
        {
            objDBManager.AddParameter("PayerId", PayerId);
        }
        if (ClaimStatus != "")
        {
            objDBManager.AddParameter("ClaimStatus", ClaimStatus);
        }
        return objDBManager.ExecuteDataSet("Report_GetInsuranceCollectionSummary");
    }
    public DataSet GetPatientCollectionSummary(long PracticeId, string AgingType, string AgingDate, string PracticeLocationId, string ProviderId, string PatientId)
    {
        DBManager objDBManager = new DBManager();

        if (PracticeId != 0)
        {
            objDBManager.AddParameter("PracticeId", PracticeId);
        }
        if (AgingType != "")
        {
            objDBManager.AddParameter("AgingType", AgingType);
        }
        if (AgingDate != "")
        {
            objDBManager.AddParameter("AgingDate ", AgingDate);
        }

        if (!string.IsNullOrEmpty(PracticeLocationId))
        {
            objDBManager.AddParameter("PracticeLocationId", PracticeLocationId);
        }
        if (ProviderId != "")
        {
            objDBManager.AddParameter("ProviderId", ProviderId);
        }
        if (PatientId != "")
        {
            objDBManager.AddParameter("PatientId", PatientId);
        }
        return objDBManager.ExecuteDataSet("Report_GetPatientCollectionSummary");
    }
    public DataSet GetPatientCollectionDetail(long PracticeId, int Rows, int PageNumber, string SortBy, string AgingType, string AgingDate, string PracticeLocationId, string ProviderId, string PatientId)
    {
        DBManager objDBManager = new DBManager();

        if (PracticeId != 0)
        {
            objDBManager.AddParameter("PracticeId", PracticeId);
        }
        objDBManager.AddParameter("Rows", Rows);
        objDBManager.AddParameter("PageNumber", PageNumber);

        if (!string.IsNullOrEmpty(SortBy))
        {
            objDBManager.AddParameter("SortBy", SortBy);
        }
        if (AgingType != "")
        {
            objDBManager.AddParameter("AgingType", AgingType);
        }
        if (AgingDate != "")
        {
            objDBManager.AddParameter("AgingDate ", AgingDate);
        }

        if (!string.IsNullOrEmpty(PracticeLocationId))
        {
            objDBManager.AddParameter("PracticeLocationId", PracticeLocationId);
        }
        if (ProviderId != "")
        {
            objDBManager.AddParameter("ProviderId", ProviderId);
        }
        if (PatientId != "")
        {
            objDBManager.AddParameter("PatientId", PatientId);
        }
        return objDBManager.ExecuteDataSet("Report_GetPatientCollectionDetail");
    }
    public DataSet GetUnpaidInsuranceClaims(long PracticeId, int Rows, int PageNumber, string SortBy, string PayerId, string ProviderId, string PracticeLocationId, int Balance, string DOSAge, string BillDateFrom, string BillDateTo, string DateType)
    {
        DBManager objDBManager = new DBManager();

        if (PracticeId != 0)
        {
            objDBManager.AddParameter("PracticeId", PracticeId);
        }
        objDBManager.AddParameter("Rows", Rows);
        objDBManager.AddParameter("PageNumber", PageNumber);

        if (!string.IsNullOrEmpty(SortBy))
        {
            objDBManager.AddParameter("SortBy", SortBy);
        }
        if (PayerId != "")
        {
            objDBManager.AddParameter("PayerId", PayerId);
        }
        if (ProviderId != "")
        {
            objDBManager.AddParameter("ProviderId", ProviderId);
        }

        if (!string.IsNullOrEmpty(PracticeLocationId))
        {
            objDBManager.AddParameter("PracticeLocationId", PracticeLocationId);
        }
        if (Balance != 0)
        {

            objDBManager.AddParameter("Balance", Balance);
        }
        if (DOSAge != "")
        {
            objDBManager.AddParameter("DOSAge", DOSAge);
        }
        if (BillDateFrom != "")
        {
            objDBManager.AddParameter("StartDate", BillDateFrom);
        }
        if (BillDateTo != "")
        {
            objDBManager.AddParameter("EndDate", BillDateTo);
        }
        if (!string.IsNullOrEmpty(DateType))
        {
            objDBManager.AddParameter("DateType", DateType);
        }
        return objDBManager.ExecuteDataSet("Report_GetUnpaidInsuranceClaims");
    }
    public DataSet GetDenialsDetail(long PracticeId, int Rows, int PageNumber, string SortBy, string DateType, string DateFrom, string DateTo, string ProviderId, string PracticeLocationId, string Payer, string AdjustmentCode)
    {
        DBManager objDBManager = new DBManager();

        if (PracticeId != 0)
        {
            objDBManager.AddParameter("PracticeId", PracticeId);
        }
        objDBManager.AddParameter("Rows", Rows);
        objDBManager.AddParameter("PageNumber", PageNumber);

        if (!string.IsNullOrEmpty(SortBy))
        {
            objDBManager.AddParameter("SortBy", SortBy);
        }
        if (DateType != "")
        {
            objDBManager.AddParameter("DateType", DateType);
        }
        if (DateFrom != "")
        {
            objDBManager.AddParameter("DateFrom", DateFrom);
        }

        if (DateTo != "")
        {
            objDBManager.AddParameter("DateTo  ", DateTo);
        }
        if (ProviderId != "")
        {
            objDBManager.AddParameter("ProviderId  ", ProviderId);
        }
        if (!string.IsNullOrEmpty(PracticeLocationId))
        {
            objDBManager.AddParameter("PracticeLocationId", PracticeLocationId);
        }
        if (Payer != "")
        {
            objDBManager.AddParameter("Payer ", Payer);
        }
        if (AdjustmentCode != "")
        {
            objDBManager.AddParameter("AdjustmentCode", AdjustmentCode);
        }
        return objDBManager.ExecuteDataSet("Report_GetDenialsDetail");
    }
    public DataSet GetDenialsSummary(long PracticeId, int Rows, int PageNumber, string SortBy, string DateType, string DateFrom, string DateTo, string ProviderId, string PracticeLocationId, string Payer, string AdjustmentCode)
    {
        DBManager objDBManager = new DBManager();

        if (PracticeId != 0)
        {
            objDBManager.AddParameter("PracticeId", PracticeId);
        }
        objDBManager.AddParameter("Rows", Rows);
        objDBManager.AddParameter("PageNumber", PageNumber);

        if (!string.IsNullOrEmpty(SortBy))
        {
            objDBManager.AddParameter("SortBy", SortBy);
        }
        if (DateType != "")
        {
            objDBManager.AddParameter("DateType", DateType);
        }
        if (DateFrom != "")
        {
            objDBManager.AddParameter("DateFrom", DateFrom);
        }

        if (DateTo != "")
        {
            objDBManager.AddParameter("DateTo  ", DateTo);
        }
        if (ProviderId != "")
        {
            objDBManager.AddParameter("ProviderId  ", ProviderId);
        }
        if (!string.IsNullOrEmpty(PracticeLocationId))
        {
            objDBManager.AddParameter("PracticeLocationId", PracticeLocationId);
        }
        if (Payer != "")
        {
            objDBManager.AddParameter("Payer ", Payer);
        }
        if (AdjustmentCode != "")
        {
            objDBManager.AddParameter("AdjustmentCode", AdjustmentCode);
        }
        return objDBManager.ExecuteDataSet("Report_GetDenialsSummary");
    }
    public DataSet GetBySearchCriteria(long PracticeId, int Rows, int PageNumber, string SortBy, string Insurance, string PaymentType, string PaymentMethodCode, string DateFrom, string DateTo)
    {
        DBManager objDBManager = new DBManager();

        if (PracticeId != 0)
        {
            objDBManager.AddParameter("PracticeId", PracticeId);
        }
        objDBManager.AddParameter("Rows", Rows);
        objDBManager.AddParameter("PageNumber", PageNumber);

        if (!string.IsNullOrEmpty(SortBy))
        {
            objDBManager.AddParameter("SortBy", SortBy);
        }
        if (Insurance != "")
        {
            objDBManager.AddParameter("Insurance", Insurance);
        }
        if (DateFrom != "")
        {
            objDBManager.AddParameter("DateFrom", DateFrom);
        }

        if (DateTo != "")
        {
            objDBManager.AddParameter("DateTo  ", DateTo);
        }
        if (PaymentType != "")
        {
            objDBManager.AddParameter("PaymentType  ", PaymentType);
        }
        if (PaymentMethodCode != "")
        {
            objDBManager.AddParameter("PaymentMethodCode ", PaymentMethodCode);
        }
        return objDBManager.ExecuteDataSet("Report_GetBySearchCriteria");
    }

    public DataSet GetPatientTransactionsDetail(long PracticeId, int Rows, int PageNumber, string SortBy, string PatientId, string DateFrom, string DateTo, string DateType, string Provider, string PracticeLocationsId, string CPTCode)
    {
        DBManager objDBManager = new DBManager();

        if (PracticeId != 0)
        {
            objDBManager.AddParameter("PracticeId", PracticeId);
        }
        objDBManager.AddParameter("Rows", Rows);
        objDBManager.AddParameter("PageNumber", PageNumber);

        if (!string.IsNullOrEmpty(SortBy))
        {
            objDBManager.AddParameter("SortBy", SortBy);
        }
        if (PatientId != "")
        {
            objDBManager.AddParameter("PatientId", PatientId);
        }
        if (DateFrom != "")
        {
            objDBManager.AddParameter("DateFrom", DateFrom);
        }

        if (DateTo != "")
        {
            objDBManager.AddParameter("DateTo  ", DateTo);
        }
        if (!string.IsNullOrEmpty(DateType))
        {
            objDBManager.AddParameter("DateType", DateType);
        }
        if (!string.IsNullOrEmpty(Provider))
        {
            objDBManager.AddParameter("Provider", Provider);
        }
        if (!string.IsNullOrEmpty(PracticeLocationsId))
        {
            objDBManager.AddParameter("LocationIds", PracticeLocationsId);
        }
        if (!string.IsNullOrEmpty(CPTCode))
        {
            objDBManager.AddParameter("Procedurecode", CPTCode);
        }
        return objDBManager.ExecuteDataSet("Report_GetPatientTransactionsDetail");
    }

    /*************end shahid kazmi 11/16/2017******************/

    // Start Rizwan Kharal 29Jan2018
    //New Reports

    //Patient Encounter Detail
    public DataSet GetEncounterDetail(long PracticeId, int Rows, int PageNumber, string SortBy, string DateType, string SubmissionStatus, string DateFrom, string DateTo, string ProviderId, string PracticeLocationId, string Payer)
    {
        DBManager objDBManager = new DBManager();

        if (PracticeId != 0)
        {
            objDBManager.AddParameter("PracticeId", PracticeId);
        }
        objDBManager.AddParameter("Rows", Rows);
        objDBManager.AddParameter("PageNumber", PageNumber);

        if (!string.IsNullOrEmpty(SortBy))
        {
            objDBManager.AddParameter("SortBy", SortBy);
        }
        if (DateType != "")
        {
            objDBManager.AddParameter("DateType", DateType);
        }

        if (SubmissionStatus != "")
        {
            objDBManager.AddParameter("Status", SubmissionStatus);
        }

        if (DateFrom != "")
        {
            objDBManager.AddParameter("DateFrom", DateFrom);
        }

        if (DateTo != "")
        {
            objDBManager.AddParameter("DateTo  ", DateTo);
        }
        if (ProviderId != "")
        {
            objDBManager.AddParameter("Provider  ", ProviderId);
        }
        if (!string.IsNullOrEmpty(PracticeLocationId))
        {
            objDBManager.AddParameter("ServiceLocationId", PracticeLocationId);
        }
        if (Payer != "")
        {
            objDBManager.AddParameter("Payer ", Payer);
        }

        return objDBManager.ExecuteDataSet("Report_EncountersDetail");
    }

    // Encounter Summary
    public DataSet GetEncounterSummary(long PracticeId, int Rows, int PageNumber, string SortBy, string DateType, string SubmissionStatus, string DateFrom, string DateTo, string ProviderId, string PracticeLocationId, string Payer)
    {
        DBManager objDBManager = new DBManager();

        if (PracticeId != 0)
        {
            objDBManager.AddParameter("PracticeId", PracticeId);
        }
        objDBManager.AddParameter("Rows", Rows);
        objDBManager.AddParameter("PageNumber", PageNumber);

        if (!string.IsNullOrEmpty(SortBy))
        {
            objDBManager.AddParameter("SortBy", SortBy);
        }
        if (DateType != "")
        {
            objDBManager.AddParameter("DateType", DateType);
        }

        if (SubmissionStatus != "")
        {
            objDBManager.AddParameter("Status", SubmissionStatus);
        }

        if (DateFrom != "")
        {
            objDBManager.AddParameter("DateFrom", DateFrom);
        }

        if (DateTo != "")
        {
            objDBManager.AddParameter("DateTo  ", DateTo);
        }
        if (ProviderId != "")
        {
            objDBManager.AddParameter("Provider  ", ProviderId);
        }
        if (!string.IsNullOrEmpty(PracticeLocationId))
        {
            objDBManager.AddParameter("ServiceLocationId", PracticeLocationId);
        }
        if (Payer != "")
        {
            objDBManager.AddParameter("Payer ", Payer);
        }

        return objDBManager.ExecuteDataSet("Report_EncountersSummary");
    }

    //Top10Diagnosis
    public DataSet Top10Diagnosis(int rows, int pageno, long PracticeId, string DiagnosisCode)
    {
        try
        {
            DBManager objDBManager = new DBManager();

            objDBManager.AddParameter("PracticeId", PracticeId);
            objDBManager.AddParameter("Rows", rows);
            objDBManager.AddParameter("PageNumber", pageno);
            if (!string.IsNullOrEmpty(DiagnosisCode))
            {
                objDBManager.AddParameter("Dxcodes", DiagnosisCode);
            }

            return objDBManager.ExecuteDataSet("TopTenDiagnosis_SummaryReport");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    //// Itemization of Charges
    public DataSet ItemizationOfcharges(int PracticeId, int Rows, int PageNumber, string SortBy, string DateType, string AsOff, string ProviderId, int PatientId, string PayerId)
    {
        DBManager objDBManager = new DBManager();

        if (PracticeId != 0)
        {
            objDBManager.AddParameter("PracticeId", PracticeId);
        }
        objDBManager.AddParameter("Rows", Rows);
        objDBManager.AddParameter("PageNumber", PageNumber);

        if (!string.IsNullOrEmpty(SortBy))
        {
            objDBManager.AddParameter("SortBy", SortBy);
        }
        if (DateType != "")
        {
            objDBManager.AddParameter("DateType", DateType);
        }

        if (AsOff != "")
        {
            objDBManager.AddParameter("@AsOff", AsOff);
        }
        if (ProviderId != "")
        {
            objDBManager.AddParameter("Provider", ProviderId);
        }

        objDBManager.AddParameter("PatientId", PatientId);

        if (PayerId != "")
        {
            objDBManager.AddParameter("Payer", PayerId);
        }

        return objDBManager.ExecuteDataSet("Reports_GetItemizationOfCharges");
    }

    public DataSet SetteledChargesSummary(long PracticeId, string DateFrom, string DateTo, string PatientId, string ProviderId, string PracticeLocation, string ProcedureCode)
    {
        DBManager objDBManager = new DBManager();

        if (PracticeId != 0)
        {
            objDBManager.AddParameter("PracticeId", PracticeId);
        }
        if (DateFrom != "")
        {
            objDBManager.AddParameter("DateFrom", DateFrom);
        }
        if (DateTo != "")
        {
            objDBManager.AddParameter("DateTo", DateTo);
        }

        if (PatientId != "")
        {
            objDBManager.AddParameter("PatientId", PatientId);
        }
        if (ProviderId != "")
        {
            objDBManager.AddParameter("Provider", ProviderId);
        }

        if (PracticeLocation != "")
        {
            objDBManager.AddParameter("ServiceLocationId", PracticeLocation);
        }

        if (ProcedureCode != "")
        {
            objDBManager.AddParameter("Procedures", ProcedureCode);
        }
        return objDBManager.ExecuteDataSet("Reports_GetSetteledChargesSummary");
    }


    public DataTable SearchPatient(long PracticeId, string PatientName)
    {
        try
        {
            DBManager objDBManager = new DBManager();

            objDBManager.AddParameter("PracticeId", PracticeId);
            objDBManager.AddParameter("PatientName", PatientName);

            return objDBManager.ExecuteDataTable("PatientSearchForReports");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet GetPostClaim(long PracticeId, int Rows, int PageNumber, string DateType, string StartDate, string EndDate, string PracticeLocationId, string POSCode, string ClaimStatus, string FileSearchId, string CPTCode, string Payer, string ReportType, bool? IsImportedDataOnly, string physicains = null, string Provider = null)
    {
        DBManager objDBManager = new DBManager();
        if (!string.IsNullOrEmpty(physicains))
        {
            objDBManager.AddParameter("physicains", physicains.TrimEnd(','));
        }
        if (PracticeId != 0)
        {
            objDBManager.AddParameter("PracticeId", PracticeId);
        }
        if (Rows != 0)
        {
            objDBManager.AddParameter("Rows", Rows);
        }

        objDBManager.AddParameter("PageNumber", PageNumber);

        if (!string.IsNullOrEmpty(DateType))
        {
            objDBManager.AddParameter("DateType", DateType);
        }
        if (!string.IsNullOrEmpty(StartDate))
        {
            objDBManager.AddParameter("StartDate", StartDate);
        }
        if (!string.IsNullOrEmpty(EndDate))
        {
            objDBManager.AddParameter("EndDate", EndDate);
        }
        if (!string.IsNullOrEmpty(PracticeLocationId))
        {
            objDBManager.AddParameter("PracticeLocationId", PracticeLocationId);
        }

        if (!string.IsNullOrEmpty(POSCode))
        {
            objDBManager.AddParameter("POSCode  ", POSCode);
        }

        if (!string.IsNullOrEmpty(CPTCode))
        {
            objDBManager.AddParameter("CPTCode  ", CPTCode);
        }

        if (!string.IsNullOrEmpty(Payer))
        {
            objDBManager.AddParameter("payer  ", Payer);
        }

        if (!string.IsNullOrEmpty(ClaimStatus))
        {
            objDBManager.AddParameter("ClaimStatus  ", ClaimStatus);
        }
        //ReportType
        if (!string.IsNullOrEmpty(ReportType))
        {
            objDBManager.AddParameter("@ClaimOrProcedurelevel", ReportType);
        }

        if (FileSearchId != "")
        {
            objDBManager.AddParameter("FileSearchId", FileSearchId);
        }
        if (!string.IsNullOrEmpty(Provider))
        {
            objDBManager.AddParameter("@Provider", Provider);
        }
        if (IsImportedDataOnly != null)
        {
            objDBManager.AddParameter("@IsImportedDataOnly", IsImportedDataOnly);
        }
        return objDBManager.ExecuteDataSet("Report_GetPostClaim_A");
    }
    /*******************added by shahid kazmi 4/11/2018**************/
    public DataSet GetMonthlyReconciliation(long PracticeId, int Rows, int PageNumber, string SortBy, string ProviderType, long practicelocationsId, string DateFrom, string DateTo, string Provider)
    {
        DBManager objDBManager = new DBManager();

        if (PracticeId != 0)
        {
            objDBManager.AddParameter("PracticeId", PracticeId);
        }
        objDBManager.AddParameter("Rows", Rows);
        objDBManager.AddParameter("PageNumber", PageNumber);
        if (practicelocationsId != 0)
        {
            objDBManager.AddParameter("practicelocationsId", practicelocationsId);
        }
        if (!string.IsNullOrEmpty(ProviderType))
        {
            objDBManager.AddParameter("ProviderType", ProviderType);
        }
        if (!string.IsNullOrEmpty(SortBy))
        {
            objDBManager.AddParameter("SortBy", SortBy);
        }
        if (!string.IsNullOrEmpty(DateFrom))
        {
            objDBManager.AddParameter("DateFrom", DateFrom);
        }
        if (!string.IsNullOrEmpty(DateTo))
        {
            objDBManager.AddParameter("DateTo", DateTo);
        }
        if (!string.IsNullOrEmpty(Provider))
        {
            objDBManager.AddParameter("Provider", Provider);
        }
        return objDBManager.ExecuteDataSet("Report_GetMonthlyReconciliation");
    }
    /******************end shahid kazmi 4/11/2018********************/


    // Start Added By Rizwan kharal 26April2018
    //Rejected denied Cliams
    public DataSet GetRejectedDeniedClaims(long PracticeId, string Isnurance, string BilledAs, string Status, string aging, bool? IsImportedDataOnly, string Location = "", string ProviderId = "")
    {
        DBManager objDBManager = new DBManager();

        if (PracticeId != 0)
        {
            objDBManager.AddParameter("PracticeId", PracticeId);
        }

        if (!string.IsNullOrEmpty(Isnurance))
        {
            objDBManager.AddParameter("Insurance", Isnurance);
        }
        if (!string.IsNullOrEmpty(Location))
        {
            objDBManager.AddParameter("LocationId", Location);
        }
        if (!string.IsNullOrEmpty(ProviderId))
        {
            objDBManager.AddParameter("ProviderId", ProviderId);
        }
        if (!string.IsNullOrEmpty(BilledAs))
        {
            objDBManager.AddParameter("BilledAs", BilledAs);
        }


        if (!string.IsNullOrEmpty(Status))
        {
            objDBManager.AddParameter("Status", Status);
        }
        if (!string.IsNullOrEmpty(aging))
        {
            objDBManager.AddParameter("@Aging", aging);
        }

        if (IsImportedDataOnly != null)
        {
            objDBManager.AddParameter("@IsImportedDataOnly", IsImportedDataOnly);
        }
        return objDBManager.ExecuteDataSet("RepClaim_CPTWithRejectedDeniedNEW");
    }
    // End Added By Rizwan kharal 26April2018


    // Start Added By Rizwan kharal 27April2018
    //ThirtyPlusDaysAfterSubmission

    public DataSet GetThirtyPlusDaysAfterSubmission(long PracticeId, int Rows, int PageNumber, string SortBy, string Isnurance, string DateType, string DateFrom, string DateTo)
    {
        DBManager objDBManager = new DBManager();

        if (PracticeId != 0)
        {
            objDBManager.AddParameter("PracticeId", PracticeId);
        }
        objDBManager.AddParameter("Rows", Rows);
        objDBManager.AddParameter("PageNumber", PageNumber);

        if (!string.IsNullOrEmpty(SortBy))
        {
            objDBManager.AddParameter("SortBy", SortBy);
        }
        if (!string.IsNullOrEmpty(Isnurance))
        {
            objDBManager.AddParameter("Insurance", Isnurance);
        }
        if (!string.IsNullOrEmpty(DateType))
        {
            objDBManager.AddParameter("DateType", DateType);
        }
        if (!string.IsNullOrEmpty(DateFrom))
        {
            objDBManager.AddParameter("DateFrom", DateFrom);
        }
        if (!string.IsNullOrEmpty(DateTo))
        {
            objDBManager.AddParameter("DateTo", DateTo);
        }
        return objDBManager.ExecuteDataSet("RepClaim_GetThirtyPlusDaysAfterSubmission");
    }
    // End Added By Rizwan kharal 27April2018

    public DataSet GetUserClaimSummary(long PracticeId, string CreatedById, string DateType, string DateFrom, string DateTo)
    {
        DBManager objDBManager = new DBManager();


        objDBManager.AddParameter("PracticeId", PracticeId);

        if (!string.IsNullOrEmpty(CreatedById))
        {
            objDBManager.AddParameter("CreatedById", CreatedById);
        }
        if (!string.IsNullOrEmpty(DateType))
        {
            objDBManager.AddParameter("DateType", DateType);
        }
        if (!string.IsNullOrEmpty(DateFrom))
        {
            objDBManager.AddParameter("StartDate", DateFrom);
        }
        if (!string.IsNullOrEmpty(DateTo))
        {
            objDBManager.AddParameter("EndDate", DateTo);
        }
        return objDBManager.ExecuteDataSet("GetUserClaimsSummary");
    }
    //Added By Syed Sajid Ali Date:09/11/2018 Des:Get All Ready for Submission claim Details
    public DataSet GetAllRFS_ClaimsDetail(long PracticeId, int PageNumber, int Row, string SortBy, string DateType, string StartDate, string EndDate)
    {
        DBManager objDBManager = new DBManager();

        objDBManager.AddParameter("PracticeId", PracticeId);
        objDBManager.AddParameter("PageNumber", PageNumber);
        objDBManager.AddParameter("Rows", Row);
        objDBManager.AddParameter("SortBy", SortBy);
        objDBManager.AddParameter("DateType", DateType);
        objDBManager.AddParameter("StartDate", StartDate);
        objDBManager.AddParameter("EndDate", EndDate);

        return objDBManager.ExecuteDataSet("GetAllRFSClaimsDetail");
    }
    //End By Syed Sajid Ali


    public DataSet GetPostClaimGrid(long PracticeId, int Rows, int PageNumber, long PatientId, long ClaimId, string PatName, string DOB, string DOS, string CptCode,
        int PriSubStatus, string FileName, int Insurance, string PolicyNumber, int POS, int Location, string PostDate, double Charges)
    {
        DBManager objDBManager = new DBManager();

        if (PracticeId != 0)
        {
            objDBManager.AddParameter("PracticeId", PracticeId);
        }
        if (Rows != 0)
        {
            objDBManager.AddParameter("Rows", Rows);
        }
        if (PatientId != 0)
        {
            objDBManager.AddParameter("@PatientId", PatientId);
        }
        if (ClaimId != 0)
        {
            objDBManager.AddParameter("@ClaimId", ClaimId);
        }
        if (!string.IsNullOrEmpty(PatName))
        {
            objDBManager.AddParameter("@PatientName", PatName);
        }
        objDBManager.AddParameter("PageNumber", PageNumber);

        if (!string.IsNullOrEmpty(DOB))
        {
            objDBManager.AddParameter("@DOB", DOB);
        }

        if (!string.IsNullOrEmpty(DOS))
        {
            objDBManager.AddParameter("@DOSDate", DOS);
        }
        if (!string.IsNullOrEmpty(CptCode))
        {
            objDBManager.AddParameter("CptCode", CptCode);
        }
        if (PriSubStatus != 0)
        {
            objDBManager.AddParameter("@ClaimStatusId", PriSubStatus);
        }
        if (!string.IsNullOrEmpty(FileName))
        {
            objDBManager.AddParameter("@FileName", FileName);
        }
        if (Insurance != 0)
        {
            objDBManager.AddParameter("@InsuranceId", Insurance);
        }
        if (!string.IsNullOrEmpty(PolicyNumber))
        {
            objDBManager.AddParameter("@PolicyNumber", PolicyNumber);
        }
        if (POS != 0)
        {
            objDBManager.AddParameter("@POSId", POS);
        }
        if (Location != 0)
        {
            objDBManager.AddParameter("@PracticeLocationId", Location);
        }


        if (!string.IsNullOrEmpty(PostDate))
        {
            objDBManager.AddParameter("@PostDate", PostDate);
        }
        if (Charges != 0)
        {
            objDBManager.AddParameter("@Charges", Charges);
        }
        return objDBManager.ExecuteDataSet("GetPostClaim_Grid");
    }
    public DataSet GetClaimTotalDaysASub(long PracticeId, long? ClaimId, int PageNumber, int Row, string SortBy, string CreatedDate, string FirstSubmissionDate, string Totaldays, string IsSubimitted)
    {
        DBManager objDBManager = new DBManager();

        objDBManager.AddParameter("PracticeId", PracticeId);
        objDBManager.AddParameter("ClaimId", ClaimId);
        objDBManager.AddParameter("PageNumber", PageNumber);
        objDBManager.AddParameter("Rows", Row);
        objDBManager.AddParameter("SortBy", SortBy);
        objDBManager.AddParameter("CreatedDate", CreatedDate);
        objDBManager.AddParameter("FirstSubmissionDate", FirstSubmissionDate);
        objDBManager.AddParameter("Totaldays", Totaldays);
        objDBManager.AddParameter("IsSubimitted", IsSubimitted);
        return objDBManager.ExecuteDataSet("CountClaimSubmission_Totaldays");
    }

    public DataTable GetAllPatientsForERAMaster(long PracticeId, string SearchValue, string SearchSplitValue)
    {
        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("@PracticeId", PracticeId);
        if (SearchValue != "")
        {
            objDBManager.AddParameter("@SearchValue", SearchValue);
        }
        if (SearchSplitValue != "")
        {
            objDBManager.AddParameter("@SearchSplitValue", SearchSplitValue);
        }

        return objDBManager.ExecuteDataTable("GetPatientPayerNameFromERATable");
    }

    public DataSet GetUnpostedPaymentsSummary(long PracticeId, string PayerType, string DateType, string DateFrom, string DateTo,
        string checknumber, string selectedType, bool? IsImportedDataOnly, string Payers = "", string Location = "", string Provider = "")
    {
        DBManager objDBManager = new DBManager();

        if (PracticeId != 0)
        {
            objDBManager.AddParameter("PracticeId", PracticeId);
        }
        if (DateType != "")
        {
            objDBManager.AddParameter("DateType", DateType);
        }

        if (DateFrom != "")
        {
            objDBManager.AddParameter("FromDate", DateFrom);
        }
        if (DateTo != "")
        {
            objDBManager.AddParameter("ToDate", DateTo);
        }
        if (PayerType != "")
        {
            objDBManager.AddParameter("PayerType", PayerType);
        }
        if (checknumber != "")
        {
            objDBManager.AddParameter("CheckNo", checknumber);
        }
        if (IsImportedDataOnly != null)
        {
            objDBManager.AddParameter("@IsImportedDataOnly", IsImportedDataOnly);
        }
        if (!string.IsNullOrEmpty(Payers))
        {
            objDBManager.AddParameter("Payers", Payers);

        }
        if (!string.IsNullOrEmpty(Location))
        {
            objDBManager.AddParameter("LocationIds", Location);

        }
        if (!string.IsNullOrEmpty(Provider))
        {
            objDBManager.AddParameter("Provider", Provider);

        }
        return objDBManager.ExecuteDataSet("UnPostedPayments");
    }


    public DataSet AccountsReceivableAgingTAB(long UserId, string PracticeId, string AgingBy, string Asof, string ProviderId, string LocationId, string PayerId, bool? IsImportedDataOnly)
    {

        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("@UserId", UserId);
        if (!string.IsNullOrEmpty(PracticeId))
        {
            objDBManager.AddParameter("@PracticeId", PracticeId);
        }
        if (!string.IsNullOrEmpty(AgingBy))
        {
            objDBManager.AddParameter("@AgingBy", AgingBy);
        }

        if (!string.IsNullOrEmpty(Asof))
        {
            objDBManager.AddParameter("@Asof", Asof);
        }
        if (!string.IsNullOrEmpty(ProviderId))
        {
            objDBManager.AddParameter("@StaffNPI", ProviderId);
        }

        if (!string.IsNullOrEmpty(LocationId))
        {
            objDBManager.AddParameter("@LocationId", LocationId);
        }
        if (!string.IsNullOrEmpty(PayerId))
        {
            objDBManager.AddParameter("@PayerId", PayerId);
        }
        if (IsImportedDataOnly != null)
        {
            objDBManager.AddParameter("@IsImportedDataOnly", IsImportedDataOnly);
        }
        return objDBManager.ExecuteDataSet("PPGetARAgingbyARType");
    }
    public DataSet ARSummaryInsuranceDetailsTAB(long UserId, string PracticeId, string Sortby, string AgingBy, string Asof, string ProviderId, string LocationId, string PayerId, string LastPaidAmount,
  string Current, string t3160, string t6190, string t91120, string t120, string TotalOutStanding, string InsuranceName, string BilledAs, string SelectedAgging = null)
    {

        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("@UserId", UserId);
        if (!string.IsNullOrEmpty(PracticeId))
        {
            objDBManager.AddParameter("@PracticeId", PracticeId);
        }
        objDBManager.AddParameter("@SortBy", Sortby);
        if (!string.IsNullOrEmpty(AgingBy))
        {
            objDBManager.AddParameter("@AgingBy", AgingBy);
        }

        if (!string.IsNullOrEmpty(Asof))
        {
            objDBManager.AddParameter("@Asof", Asof);
        }
        if (!string.IsNullOrEmpty(ProviderId))
        {
            objDBManager.AddParameter("@ProviderId", ProviderId);
        }

        if (!string.IsNullOrEmpty(LocationId))
        {
            objDBManager.AddParameter("@LocationId", LocationId);
        }
        if (!string.IsNullOrEmpty(PayerId))
        {
            objDBManager.AddParameter("@PayerId", PayerId);
        }
        if (!string.IsNullOrEmpty(LastPaidAmount) && LastPaidAmount != "__/__/____")
        {
            objDBManager.AddParameter("@LastPaidAmount", LastPaidAmount);
        }
        if (!string.IsNullOrEmpty(Current))
        {
            objDBManager.AddParameter("@Current", Current);
        }
        if (!string.IsNullOrEmpty(t3160))
        {
            objDBManager.AddParameter("@t3160", t3160);
        }
        if (!string.IsNullOrEmpty(t6190))
        {
            objDBManager.AddParameter("@t6190", t6190);
        }
        if (!string.IsNullOrEmpty(t91120))
        {
            objDBManager.AddParameter("@t91120", t91120);
        }
        if (!string.IsNullOrEmpty(t120))
        {
            objDBManager.AddParameter("@t120", t120);
        }
        if (!string.IsNullOrEmpty(TotalOutStanding))
        {
            objDBManager.AddParameter("@TotalOutStanding", TotalOutStanding);
        }
        if (!string.IsNullOrEmpty(InsuranceName))
        {
            objDBManager.AddParameter("@InsuranceName", InsuranceName);
        }
        if (!string.IsNullOrEmpty(BilledAs))
        {
            objDBManager.AddParameter("@BilledAs", BilledAs);
        }
        if (!string.IsNullOrEmpty(SelectedAgging))
        {
            objDBManager.AddParameter("@SelectedAgging", SelectedAgging);
        }
        return objDBManager.ExecuteDataSet("MGEMRGetARAgingByInsuranceType");

    }

    public DataSet ARSummaryPatientsDetails(long UserId, string PracticeId, string PracticeName, string Sortby, string AgingBy, string Asof, string ProviderId, string LocationId, string PatIds, string LastPaidAmount,
       string Current, string t3160, string t6190, string t91120, string t120, string TotalOutStanding, bool? IsImportedDataOnly, string SelectedAgging = null, int Rows = 10, int PageNumber = 0)
    {

        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("@UserId", UserId);
        objDBManager.AddParameter("@Rows", Rows);
        objDBManager.AddParameter("@PageNumber", PageNumber);

        if (!string.IsNullOrEmpty(PracticeId))
        {
            objDBManager.AddParameter("@PracticeId", PracticeId);
        }
        if (!string.IsNullOrEmpty(PracticeName))
        {
            objDBManager.AddParameter("@PracticeNameShort", PracticeName);
        }

        objDBManager.AddParameter("@SortBy", Sortby);
        if (!string.IsNullOrEmpty(AgingBy))
        {
            objDBManager.AddParameter("@AgingBy", AgingBy);
        }

        if (!string.IsNullOrEmpty(Asof))
        {
            objDBManager.AddParameter("@Asof", Asof);
        }
        if (!string.IsNullOrEmpty(ProviderId))
        {
            objDBManager.AddParameter("@ProviderId", ProviderId);
        }

        if (!string.IsNullOrEmpty(LocationId))
        {
            objDBManager.AddParameter("@LocationId", LocationId);
        }
        if (!string.IsNullOrEmpty(PatIds))
        {
            objDBManager.AddParameter("@PatientName", PatIds);
        }
        if (!string.IsNullOrEmpty(LastPaidAmount))
        {
            objDBManager.AddParameter("@LastPaiddate", LastPaidAmount);
        }
        if (!string.IsNullOrEmpty(Current))
        {
            objDBManager.AddParameter("@Current", Current);
        }
        if (!string.IsNullOrEmpty(t3160))
        {
            objDBManager.AddParameter("@t3160", t3160);
        }
        if (!string.IsNullOrEmpty(t6190))
        {
            objDBManager.AddParameter("@t6190", t6190);
        }
        if (!string.IsNullOrEmpty(t91120))
        {
            objDBManager.AddParameter("@t91120", t91120);
        }
        if (!string.IsNullOrEmpty(t120))
        {
            objDBManager.AddParameter("@t120", t120);
        }
        if (!string.IsNullOrEmpty(TotalOutStanding))
        {
            objDBManager.AddParameter("@TotalOutStanding", TotalOutStanding);
        }
        if (IsImportedDataOnly != null)
        {
            objDBManager.AddParameter("@IsImportedDataOnly", IsImportedDataOnly);
        }
        if (!string.IsNullOrEmpty(SelectedAgging))
        {
            objDBManager.AddParameter("@SelectedAgging", SelectedAgging);
        }

        return objDBManager.ExecuteDataSet("PPGetAccountReceivableAgingByPatient");

    }


    public DataSet GetARInsuranceDetailFromTABDB(long UserId, string PracticeId, string Sortby, string AgingBy, string Asof, string ProviderId, string LocationId, string PayerId,
        string Patient, string ClaimId, string DOS, string FBD, string LBD, string PPD, string Aging, string ProcedureCode, string TotalCharges
        , string PatientPayment, string InsurancePayment, string TotalOutStanding, string AgingType, string BilledAs, string PracticeName, bool? IsImportedDataOnly, int Rows, int PageNumber)
    {

        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("@UserId", UserId);
        objDBManager.AddParameter("@Rows", Rows);
        objDBManager.AddParameter("@PageNumber", PageNumber);

        if (!string.IsNullOrEmpty(PracticeId))
        {
            objDBManager.AddParameter("@PracticeId", PracticeId);
        }
        objDBManager.AddParameter("@Sortby", Sortby);
        if (!string.IsNullOrEmpty(Aging))
        {
            objDBManager.AddParameter("@Aging", Aging);
        }
        if (!string.IsNullOrEmpty(PracticeName))
        {
            objDBManager.AddParameter("@PracticeName", PracticeName);
        }
        if (!string.IsNullOrEmpty(AgingBy))
        {
            objDBManager.AddParameter("@AgingBy", AgingBy);
        }
        if (!string.IsNullOrEmpty(Asof))
        {
            objDBManager.AddParameter("@Asof", Asof);
        }
        if (!string.IsNullOrEmpty(ProviderId))
        {
            objDBManager.AddParameter("@ProviderId", ProviderId);
        }

        if (!string.IsNullOrEmpty(LocationId))
        {
            objDBManager.AddParameter("@LocationId", LocationId);
        }
        if (!string.IsNullOrEmpty(PayerId))
        {
            objDBManager.AddParameter("@PayerId", PayerId);
        }

        if (!string.IsNullOrEmpty(Patient))
        {
            objDBManager.AddParameter("@PatientName", Patient);
        }

        if (!string.IsNullOrEmpty(ClaimId))
        {
            objDBManager.AddParameter("@ClaimId", ClaimId);
        }

        if (!string.IsNullOrEmpty(DOS))
        {
            objDBManager.AddParameter("@DOS", DOS);
        }
        // Edit Start By SarmadFayyaz 31/01/2020
        if (!string.IsNullOrEmpty(FBD))
        {
            objDBManager.AddParameter("@FBD", FBD);
        }
        if (!string.IsNullOrEmpty(LBD))
        {
            objDBManager.AddParameter("@LBD", LBD);
        }
        if (!string.IsNullOrEmpty(PPD))
        {
            objDBManager.AddParameter("@PPD", PPD);
        }
        // Edit End By SarmadFayyaz 31/01/2020
        if (!string.IsNullOrEmpty(Aging))
        {
            objDBManager.AddParameter("@Aging", Aging);
        }

        if (!string.IsNullOrEmpty(ProcedureCode))
        {
            objDBManager.AddParameter("@ProcedureCode", ProcedureCode);
        }

        if (!string.IsNullOrEmpty(TotalCharges))
        {
            objDBManager.AddParameter("@TotalCharges", TotalCharges);
        }

        if (!string.IsNullOrEmpty(PatientPayment))
        {
            objDBManager.AddParameter("@PatientPayment", PatientPayment);
        }
        if (!string.IsNullOrEmpty(InsurancePayment))
        {
            objDBManager.AddParameter("@InsurancePayment", InsurancePayment);
        }
        if (!string.IsNullOrEmpty(TotalOutStanding))
        {
            objDBManager.AddParameter("@TotalOutStanding", TotalOutStanding);
        }
        if (!string.IsNullOrEmpty(AgingType))
        {
            objDBManager.AddParameter("@AgingType", AgingType);
        }
        if (!string.IsNullOrEmpty(BilledAs))
        {
            objDBManager.AddParameter("@BilledAs", BilledAs);
        }
        if (IsImportedDataOnly != null)
        {
            objDBManager.AddParameter("@IsImportedDataOnly", IsImportedDataOnly);
        }

        return objDBManager.ExecuteDataSet("PPGetARAginginsuranceTypeDetail");

    }
    ///Modified By Irfan Mahmood 03/Feb/2022
    public DataSet ProviderCollectionReport(long PracticeId, int Rows, int PageNumber, string StartDate, string EndDate, string Practicestaffid, string PracticeLocationId = null, string DateType = null, string CheckAssociated = null, string Payers = null)
    {
        DBManager objDBManager = new DBManager();
        if (!string.IsNullOrEmpty(StartDate))
        {
            objDBManager.AddParameter("@StartDate", StartDate);
        }
        if (!string.IsNullOrEmpty(EndDate))
        {
            objDBManager.AddParameter("@Enddate", EndDate);
        }
        objDBManager.AddParameter("@Rows", Rows);
        objDBManager.AddParameter("@PageNumber", PageNumber);
        if (!string.IsNullOrEmpty(Payers))
        {
            objDBManager.AddParameter("@PayerId", Payers);
        }
        objDBManager.AddParameter("PracticeId", PracticeId);
        if (!string.IsNullOrEmpty(Practicestaffid))
        {
            objDBManager.AddParameter("@staffnpi", Practicestaffid);
        }
        if (!string.IsNullOrEmpty(PracticeLocationId))
        {
            objDBManager.AddParameter("@practicelocationid", PracticeLocationId);
        }
        if (!string.IsNullOrEmpty(DateType))
        {
            objDBManager.AddParameter("@DateType", DateType);
        }
        if (!string.IsNullOrEmpty(CheckAssociated))
        {
            objDBManager.AddParameter("@CheckAssociated", CheckAssociated);
        }
        return objDBManager.ExecuteDataSet("ProviderWiseCollectionReportSummary");
        //return objDBManager.ExecuteDataSet("Providercollectionmonthlyreport");

    }
    ///End Modified By Irfan Mahmood 03/Feb/2022
    public DataSet GetARInsuranceDetailFromDB(long UserId, string PracticeId, string Sortby, string AgingBy, string Asof, string ProviderId, string LocationId, string PayerId,
       string Patient, string ClaimId, string DOS, string FBD, string LBD, string PPD, string Aging, string ProcedureCode, string TotalCharges
       , string PatientPayment, string InsurancePayment, string TotalOutStanding, string AgingType, bool? IsImportedDataOnly)
    {

        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("@UserId", UserId);
        if (!string.IsNullOrEmpty(PracticeId))
        {
            objDBManager.AddParameter("@PracticeId", PracticeId);
        }
        objDBManager.AddParameter("@Sortby", Sortby);

        if (!string.IsNullOrEmpty(AgingBy))
        {
            objDBManager.AddParameter("@AgingBy", AgingBy);
        }

        if (!string.IsNullOrEmpty(Asof))
        {
            objDBManager.AddParameter("@Asof", Asof);
        }
        if (!string.IsNullOrEmpty(ProviderId))
        {
            objDBManager.AddParameter("@ProviderId", ProviderId);
        }

        if (!string.IsNullOrEmpty(LocationId))
        {
            objDBManager.AddParameter("@LocationId", LocationId);
        }
        if (!string.IsNullOrEmpty(PayerId))
        {
            objDBManager.AddParameter("@PayerId", PayerId);
        }

        if (!string.IsNullOrEmpty(Patient))
        {
            objDBManager.AddParameter("@PatientName", Patient);
        }

        if (!string.IsNullOrEmpty(ClaimId))
        {
            objDBManager.AddParameter("@ClaimId", ClaimId);
        }

        if (!string.IsNullOrEmpty(DOS))
        {
            objDBManager.AddParameter("@DOS", DOS);
        }
        // Edit Start By SarmadFayyaz 31/01/2020
        if (!string.IsNullOrEmpty(FBD))
        {
            objDBManager.AddParameter("@FBD", FBD);
        }
        if (!string.IsNullOrEmpty(LBD))
        {
            objDBManager.AddParameter("@LBD", LBD);
        }
        if (!string.IsNullOrEmpty(PPD))
        {
            objDBManager.AddParameter("@PPD", PPD);
        }
        // Edit End By SarmadFayyaz 31/01/2020
        if (!string.IsNullOrEmpty(Aging))
        {
            objDBManager.AddParameter("@Aging", Aging);
        }

        if (!string.IsNullOrEmpty(ProcedureCode))
        {
            objDBManager.AddParameter("@ProcedureCode", ProcedureCode);
        }

        if (!string.IsNullOrEmpty(TotalCharges))
        {
            objDBManager.AddParameter("@TotalCharges", TotalCharges);
        }

        if (!string.IsNullOrEmpty(PatientPayment))
        {
            objDBManager.AddParameter("@PatientPayment", PatientPayment);
        }
        if (!string.IsNullOrEmpty(InsurancePayment))
        {
            objDBManager.AddParameter("@InsurancePayment", InsurancePayment);
        }
        if (!string.IsNullOrEmpty(TotalOutStanding))
        {
            objDBManager.AddParameter("@TotalOutStanding", TotalOutStanding);
        }
        if (!string.IsNullOrEmpty(AgingType))
        {
            objDBManager.AddParameter("@AgingType", AgingType);
        }
        if (IsImportedDataOnly != null)
        {
            objDBManager.AddParameter("@IsImportedDataOnly", IsImportedDataOnly);
        }
        return objDBManager.ExecuteDataSet("MGEMRGetARAgingByRiskSol");

    }
    public DataSet DuplicateChecks(long PracticeId, long UserId, int Rows = 10, int PageNumber = 0, string DateFrom = "", string DateTo = "", string InsuranceID = "", string CheckNo = "")
    {
        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("Rows", Rows);
        objDBManager.AddParameter("PageNumber", PageNumber);
        objDBManager.AddParameter("UserId", UserId);
        objDBManager.AddParameter("PracticeId", PracticeId);

        if (DateFrom == "")
        {
            objDBManager.AddParameter("DateFrom", DBNull.Value);
        }
        else
        {
            objDBManager.AddParameter("DateFrom", Convert.ToDateTime(DateFrom));
        }
        if (DateTo == "")
        {
            objDBManager.AddParameter("DateTo", DBNull.Value);
        }
        else
        {
            objDBManager.AddParameter("DateTo", Convert.ToDateTime(DateTo));

        }
        if (!string.IsNullOrEmpty(InsuranceID))
        {
            objDBManager.AddParameter("InsuranceID", InsuranceID);
        }
        if (!string.IsNullOrEmpty(CheckNo))
        {
            objDBManager.AddParameter("CheckNo", CheckNo);
        }
        return objDBManager.ExecuteDataSet("DuplicateChecks");
    }
}