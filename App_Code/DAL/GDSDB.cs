using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for GDSDB
/// </summary>
public class GDSDB
{
	public GDSDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    
    public long Add(GDS objGDS, SqlTransaction objSqlTransaction = null)
    {
        DBManager objDBManager = new DBManager(objSqlTransaction);
        try
        {
            objDBManager.AddParameter("GDSId", objGDS.GDSId, SqlDbType.Int, 4, ParameterDirection.Output);

            objDBManager.AddParameter("PracticeId", objGDS.PracticeId);
            objDBManager.AddParameter("ChartId", objGDS.ChartId);
            objDBManager.AddParameter("PatientId", objGDS.PatientId);
            
            objDBManager.AddParameter("SatisfiedWithYourLife", objGDS.SatisfiedWithYourLife);
            objDBManager.AddParameter("DroppedActivitiesAndInterests", objGDS.DroppedActivitiesAndInterests);
            objDBManager.AddParameter("YourLifeIsEmpty", objGDS.YourLifeIsEmpty);
            objDBManager.AddParameter("GetBored", objGDS.GetBored);
            objDBManager.AddParameter("InGoodSpirits", objGDS.InGoodSpirits);
            objDBManager.AddParameter("SomethingBadIsGoingToHappen", objGDS.SomethingBadIsGoingToHappen);
            objDBManager.AddParameter("HappyMostOfTheTime", objGDS.HappyMostOfTheTime);
            objDBManager.AddParameter("FeelHelpless", objGDS.FeelHelpless);
            objDBManager.AddParameter("PreferToStayAtHome", objGDS.PreferToStayAtHome);
            objDBManager.AddParameter("ProblemsWithMemory", objGDS.ProblemsWithMemory);
            objDBManager.AddParameter("WonderfulToBeAliveNow", objGDS.WonderfulToBeAliveNow);
            objDBManager.AddParameter("PrettyWorthless", objGDS.PrettyWorthless);
            objDBManager.AddParameter("FullOfEnergy", objGDS.FullOfEnergy);
            objDBManager.AddParameter("SituationIsHopeless", objGDS.SituationIsHopeless);
            objDBManager.AddParameter("MostPeopleAreBetter", objGDS.MostPeopleAreBetter);
            
            objDBManager.AddParameter("CreatedDate", objGDS.CreatedDate);
            objDBManager.AddParameter("CreatedById", objGDS.CreatedById);
            
            objDBManager.ExecuteNonQuery("GDS_Add");
            
            objGDS.GDSId = long.Parse(objDBManager.Parameters[0].Value.ToString());
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return objGDS.GDSId;
    }
    
    public int Update(GDS objGDS, SqlTransaction objSqlTransaction = null)
    {
        DBManager objDBManager = new DBManager(objSqlTransaction);
        int ReturnValue = 0;
        try
        {
            objDBManager.AddParameter("GDSId", objGDS.GDSId);

            objDBManager.AddParameter("PracticeId", objGDS.PracticeId);
            objDBManager.AddParameter("ChartId", objGDS.ChartId);
            objDBManager.AddParameter("PatientId", objGDS.PatientId);
            
            objDBManager.AddParameter("SatisfiedWithYourLife", objGDS.SatisfiedWithYourLife);
            objDBManager.AddParameter("DroppedActivitiesAndInterests", objGDS.DroppedActivitiesAndInterests);
            objDBManager.AddParameter("YourLifeIsEmpty", objGDS.YourLifeIsEmpty);
            objDBManager.AddParameter("GetBored", objGDS.GetBored);
            objDBManager.AddParameter("InGoodSpirits", objGDS.InGoodSpirits);
            objDBManager.AddParameter("SomethingBadIsGoingToHappen", objGDS.SomethingBadIsGoingToHappen);
            objDBManager.AddParameter("HappyMostOfTheTime", objGDS.HappyMostOfTheTime);
            objDBManager.AddParameter("FeelHelpless", objGDS.FeelHelpless);
            objDBManager.AddParameter("PreferToStayAtHome", objGDS.PreferToStayAtHome);
            objDBManager.AddParameter("ProblemsWithMemory", objGDS.ProblemsWithMemory);
            objDBManager.AddParameter("WonderfulToBeAliveNow", objGDS.WonderfulToBeAliveNow);
            objDBManager.AddParameter("PrettyWorthless", objGDS.PrettyWorthless);
            objDBManager.AddParameter("FullOfEnergy", objGDS.FullOfEnergy);
            objDBManager.AddParameter("SituationIsHopeless", objGDS.SituationIsHopeless);
            objDBManager.AddParameter("MostPeopleAreBetter", objGDS.MostPeopleAreBetter);

            objDBManager.AddParameter("ModifiedDate", objGDS.ModifiedDate);
            objDBManager.AddParameter("ModifiedById", objGDS.ModifiedById);

            ReturnValue = objDBManager.ExecuteNonQuery("GDS_Update");
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ReturnValue;
    }

    public DataTable GetGDS(int PracticeId, long ChartId, long PatientId)
    {
        DBManager objDBManager = new DBManager();

        objDBManager.AddParameter("PracticeId", PracticeId);
        objDBManager.AddParameter("ChartId", ChartId);
        objDBManager.AddParameter("PatientId", PatientId);

        return objDBManager.ExecuteDataTable("GDS_GetGDS");
    }
}