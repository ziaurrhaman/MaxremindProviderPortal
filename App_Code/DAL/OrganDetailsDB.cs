using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
/// <summary>
/// Summary description for OrganDetailsDB
/// </summary>
public class OrganDetailsDB
{
	public OrganDetailsDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public long Add(OrgansDetails objOrgansDetails, SqlTransaction objSqlTransaction = null)
    {
        DBManager objDBManager = new DBManager(objSqlTransaction);
        try
        {
            objDBManager.AddParameter("OrgansDetailsId", objOrgansDetails.OrgansDetailsId, SqlDbType.Int, 4, ParameterDirection.Output);

            objDBManager.AddParameter("OrganDetailDescription", objOrgansDetails.OrganDetailDescription);
            objDBManager.AddParameter("OrganCode", objOrgansDetails.OrganCode);
            objDBManager.AddParameter("CreatedById", objOrgansDetails.CreatedById);
            objDBManager.AddParameter("CreatedDate", objOrgansDetails.CreatedDate);
            objDBManager.AddParameter("Position", objOrgansDetails.Position);

            objDBManager.ExecuteNonQuery("OrgansDetails_Add");
            objOrgansDetails.OrgansDetailsId = long.Parse(objDBManager.Parameters[0].Value.ToString());
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return objOrgansDetails.OrgansDetailsId;
    }

    public int Update(OrgansDetails objOrgansDetails, SqlTransaction objSqlTransaction = null)
    {
        DBManager objDBManager = new DBManager(objSqlTransaction);
        int ReturnValue = 0;
        try
        {
            objDBManager.AddParameter("OrgansDetailsId", objOrgansDetails.OrgansDetailsId, SqlDbType.Int, 4);
            
            objDBManager.AddParameter("OrganDetailDescription", objOrgansDetails.OrganDetailDescription);
            objDBManager.AddParameter("OrganCode", objOrgansDetails.OrganCode);
            objDBManager.AddParameter("ModifiedById", objOrgansDetails.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objOrgansDetails.ModifiedDate);
            objDBManager.AddParameter("Position", objOrgansDetails.Position);
            
            ReturnValue = objDBManager.ExecuteNonQuery("OrgansDetails_Update");
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ReturnValue;
    }

    public int Delete(OrgansDetails objOrgansDetails, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);
            objDBManager.AddParameter("OrgansDetailsId", objOrgansDetails.OrgansDetailsId);
            objDBManager.AddParameter("ModifiedById", objOrgansDetails.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objOrgansDetails.ModifiedDate);
            return objDBManager.ExecuteNonQuery("OrgansDetails_Delete");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    public DataSet GetOrganDetails(string organCode)
    {
        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("OrganCode", organCode);
        return objDBManager.ExecuteDataSet("Chart_GetOrganDetails");
    }
    
    public DataTable GetByOrganCode(string OrganCode)
    {
        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("OrganCode", OrganCode);
        return objDBManager.ExecuteDataTable("OrganDetails_GetByOrganCode");
    }
}