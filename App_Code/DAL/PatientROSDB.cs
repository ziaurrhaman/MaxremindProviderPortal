using System;
using System.Data;

/// <summary>
/// Summary description for PatientROSDB
/// </summary>
public class PatientROSDB
{
	public PatientROSDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public Int64 Add(PatientROS objPatientRos)
    {

        DBManager objDbManager = new DBManager();


        try
        {
            objDbManager.AddParameter("PatientROSId", objPatientRos.PatientROSId,SqlDbType.BigInt, 8,ParameterDirection.Output);
            objDbManager.AddParameter("ChartId", objPatientRos.ChartId);
            objDbManager.AddParameter("PatientId", objPatientRos.PatientId);
            objDbManager.AddParameter("PracticeId", objPatientRos.PracticeId);            
            objDbManager.AddParameter("RosDetails", objPatientRos.RosDetails);                        
            objDbManager.AddParameter("CreatedById", objPatientRos.CreatedById);
            objDbManager.AddParameter("CreatedDate", objPatientRos.CreatedDate);            
            objDbManager.AddParameter("Deleted", objPatientRos.Deleted);            
            objDbManager.ExecuteNonQuery("Chart_AddPatientROS");
            objPatientRos.PatientROSId =Convert.ToInt64(objDbManager.Parameters[0].Value);

        }
        catch (Exception ex)
        {
            throw ex;
        }
        return objPatientRos.PatientROSId;
    }

    public void Update(PatientROS objPatientRos)
    {
        DBManager objDbManager = new DBManager();     
        try
        {
            objDbManager.AddParameter("PatientROSId", objPatientRos.PatientROSId);
            objDbManager.AddParameter("RosDetails", objPatientRos.RosDetails);                        
            objDbManager.AddParameter("ModifiedById", objPatientRos.ModifiedById);
            objDbManager.AddParameter("ModifiedDate", objPatientRos.ModifiedDate);            
            objDbManager.ExecuteNonQuery("Chart_UpdatePatientROS");
        }
        catch (Exception ex)
        {
            throw ex;
        }        
    }
    public DataTable GetPatientRosDetails(Int64 chartId)
    {
        DBManager objDbManager = new DBManager();
        objDbManager.AddParameter("ChartId", chartId);
        return objDbManager.ExecuteDataTable("Chart_GetPatientRosDetails");
    }
}