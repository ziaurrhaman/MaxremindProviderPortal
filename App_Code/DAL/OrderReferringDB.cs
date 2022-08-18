using System;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for OrderReferringDB
/// </summary>
public class OrderReferringDB
{
	public OrderReferringDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    
    public DataTable GetAllByFilter(string NPI, string FirstName, string LastName, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);

            if (string.IsNullOrEmpty(NPI) && string.IsNullOrEmpty(FirstName) && string.IsNullOrEmpty(LastName))
            {
                return new DataTable();
            }

            string NPIEqual = "";
            if (!string.IsNullOrEmpty(NPI))
            {
                NPIEqual = " ODR.NPI = '" + NPI + "'";
            }
            
            string LastNameLIKE = "";
            if (!string.IsNullOrEmpty(LastName))
            {
                if (NPIEqual != "")
                {
                    LastNameLIKE = " OR ( ODR.LastName LIKE '" + LastName + "%' ";
                }
                else
                {
                    LastNameLIKE = " ODR.LastName LIKE '" + LastName + "%' ";
                }
            }
            
            string FirstNameLIKE = "";
            if (!string.IsNullOrEmpty(FirstName))
            {
                if (NPIEqual == "" && LastNameLIKE == "")
                {
                    FirstNameLIKE = " ODR.FirsName LIKE '" + FirstName + "%'";
                }
                else
                {
                    FirstNameLIKE = " and ODR.FirsName LIKE '" + FirstName + "%' ) ";
                }
            }
            
            string sqlString = "SELECT " +
                                   "ODR.LastName," +
                                   "ODR.FirsName," +
                                   "ODR.NPI " +
                               "FROM " +
                                   "OrderReferring ODR " +
                               "WHERE" +
                                   NPIEqual + LastNameLIKE + FirstNameLIKE;
            
            objDBManager.AddParameter("sqlString", sqlString);
            
            return objDBManager.ExecuteDataTable("OrderReferring_GetAllByFilter");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable GetServiceProviderDetail(string npi,string firstName,string lastName)
    {
        DBManager ObjDBManager = new DBManager();
        if (!string.IsNullOrEmpty(npi))
            ObjDBManager.AddParameter("NPI", npi);

        if (!string.IsNullOrEmpty(firstName))
            ObjDBManager.AddParameter("FirstName", firstName);

        if (!string.IsNullOrEmpty(lastName))
            ObjDBManager.AddParameter("LastName", lastName);

        return ObjDBManager.ExecuteDataTable("OrderReferring_GetByNPI");
    }
}