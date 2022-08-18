using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
/// <summary>
/// Summary description for PatientPhysicalExamDB
/// </summary>
public class PatientPhysicalExamDB
{
    public PatientPhysicalExamDB()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public Int64 Add(PatientPhysicalExam objPatientPhysicalExam)
    {
        DBManager objDBManager = new DBManager();
        try
        {
            objDBManager.AddParameter("PatientPhysicalExamId", objPatientPhysicalExam.PatientPhysicalExamId, SqlDbType.Int, 8, ParameterDirection.Output);
            objDBManager.AddParameter("PatientId", objPatientPhysicalExam.PatientId);
            objDBManager.AddParameter("ChartId", objPatientPhysicalExam.ChartId);
            objDBManager.AddParameter("PracticeId", objPatientPhysicalExam.PracticeId);
            objDBManager.AddParameter("PEDetails", objPatientPhysicalExam.PEDetails);
            objDBManager.AddParameter("CreatedById", objPatientPhysicalExam.CreatedById);
            objDBManager.AddParameter("CreatedDate", objPatientPhysicalExam.CreatedDate);
            objDBManager.AddParameter("Deleted", objPatientPhysicalExam.Deleted);
            objDBManager.ExecuteNonQuery("Chart_AddPatientPhysicalExam");
            objPatientPhysicalExam.PatientPhysicalExamId = Convert.ToInt64(objDBManager.Parameters[0].Value);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return objPatientPhysicalExam.PatientPhysicalExamId;
    }

    public void Update(PatientPhysicalExam objPatientPhysicalExam)
    {
        DBManager objDBManager = new DBManager();        
        try
        {
            objDBManager.AddParameter("PatientPhysicalExamId", objPatientPhysicalExam.PatientPhysicalExamId);
            objDBManager.AddParameter("PEDetails", objPatientPhysicalExam.PEDetails);
            objDBManager.AddParameter("ModifiedById", objPatientPhysicalExam.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objPatientPhysicalExam.ModifiedDate);
            objDBManager.ExecuteNonQuery("Chart_UpdatePatientPhysicalExam");
        }
        catch (Exception ex)
        {
            throw ex;
        }        
    }

    public DataTable GetPatientPhysicalExam(Int64 chartId)
    {
        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("ChartId", chartId);
        return objDBManager.ExecuteDataTable("Chart_GetPatientPhysicalExam");
    }
}