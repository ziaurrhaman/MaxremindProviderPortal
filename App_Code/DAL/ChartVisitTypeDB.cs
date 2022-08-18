using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ChartVisitTypeDB
/// </summary>
public class ChartVisitTypeDB
{
    public ChartVisitTypeDB()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public Int64 Add(ChartVisitType objChartVisitType)
    {

        DBManager objDbManager = new DBManager();


        try
        {
            objDbManager.AddParameter("VisitTypeId", objChartVisitType.VisitTypeId, SqlDbType.BigInt, 8,
                                      ParameterDirection.Output);
            objDbManager.AddParameter("Description", objChartVisitType.Description);
            objDbManager.AddParameter("PracticeId", objChartVisitType.PracticeId);
            objDbManager.AddParameter("CreatedById", objChartVisitType.CreatedById);
            objDbManager.AddParameter("CreatedDate", objChartVisitType.CreatedDate);
            objDbManager.AddParameter("Deleted", objChartVisitType.Deleted);
            objDbManager.ExecuteNonQuery("ChartVisitType_Add");
            objChartVisitType.VisitTypeId = Convert.ToInt64(objDbManager.Parameters[0].Value);
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return objChartVisitType.VisitTypeId;
    }

    public void Update(ChartVisitType objChartVisitType)
    {
        DBManager objDbManager = new DBManager();
        try
        {
            objDbManager.AddParameter("VisitTypeId", objChartVisitType.VisitTypeId);
            objDbManager.AddParameter("Description", objChartVisitType.Description);
            objDbManager.AddParameter("ModifiedById", objChartVisitType.ModifiedById);
            objDbManager.AddParameter("ModifiedDate", objChartVisitType.ModifiedDate);
            objDbManager.ExecuteNonQuery("ChartVisitType_Update");
        }
        catch (Exception ex)
        {
            throw ex;

        }
    }    
}