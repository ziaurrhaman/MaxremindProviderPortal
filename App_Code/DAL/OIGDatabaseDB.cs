using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for OIGDatabaseDB
/// </summary>
public class OIGDatabaseDB
{
	public OIGDatabaseDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    
    public DataTable GetAllByFilter(string NPI, string FirstName, string LastName, string Zip, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);
            //objDBManager.AddParameter("NPI", NPI);
            //objDBManager.AddParameter("FirstName", FirstName);
            //objDBManager.AddParameter("LastName", LastName);
            //objDBManager.AddParameter("Zip", Zip);


            if (string.IsNullOrEmpty(NPI) && string.IsNullOrEmpty(FirstName) && string.IsNullOrEmpty(LastName) && string.IsNullOrEmpty(Zip))
            {
                return new DataTable();
            }

            string NPIEqual = "";
            if (!string.IsNullOrEmpty(NPI))
            {
                NPIEqual = " OIG.NPI = '" + NPI + "'";
            }

            string LastNameLIKE = "";
            if (!string.IsNullOrEmpty(LastName))
            {
                if (NPIEqual != "")
                {
                    LastNameLIKE = " OR OIG.LASTNAME LIKE '" + LastName + "%' ";
                }
                else
                {
                    LastNameLIKE = " OIG.LASTNAME LIKE '" + LastName + "%' ";
                }
            }

            string FirstNameLIKE = "";
            if (!string.IsNullOrEmpty(FirstName))
            {
                if (NPIEqual == "" && LastNameLIKE == "")
                {
                    FirstNameLIKE = " OIG.FIRSTNAME LIKE '" + FirstName + "%'";
                }
                else
                {
                    FirstNameLIKE = " OR OIG.FIRSTNAME LIKE '" + FirstName + "%'";
                }
            }

            string ZipEqual = "";
            if (!string.IsNullOrEmpty(Zip))
            {
                if (NPIEqual == "" && LastNameLIKE == "" && FirstNameLIKE == "")
                {
                    ZipEqual = " OIG.ZIP = '" + Zip + "'";
                }
                else
                {
                    ZipEqual = " OR OIG.ZIP = '" + Zip + "'";
                }
            }

            string sqlString = "SELECT " +
                                   "OIG.LASTNAME," +
                                   "OIG.FIRSTNAME," +
                                   "OIG.SPECIALTY, " +
                                   "OIG.UPIN, " +
                                   "OIG.NPI, " +
                                   "Convert(varchar(10), OIG.DOB, 101) AS DOB, " +
                                   "OIG.ADDRESS, " +
                                   "OIG.CITY, " +
                                   "OIG.STATE, " +
                                   "OIG.ZIP " +
                               "FROM " +
                                   "OIGDatabase OIG " +
                               "WHERE" +
                                   NPIEqual + LastNameLIKE + FirstNameLIKE + ZipEqual;

            objDBManager.AddParameter("sqlString", sqlString);
            
            return objDBManager.ExecuteDataTable("OIGDatabase_GetAllByFilter");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    
    public DataTable GetAllHospitalByFilter(string NPI, string Name, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);
            //objDBManager.AddParameter("NPI", NPI);
            //objDBManager.AddParameter("Name", Name);

            if (string.IsNullOrEmpty(NPI) && string.IsNullOrEmpty(Name))
            {
                return new DataTable();
            }

            string NPIEqual = "";
            if (!string.IsNullOrEmpty(NPI))
            {
                NPIEqual = " OIG.NPI = '" + NPI + "'";
            }

            string NameLIKE = "";
            if (!string.IsNullOrEmpty(Name))
            {
                if (NPIEqual != "")
                {
                    NameLIKE = " OR OIG.BUSNAME LIKE '" + Name + "%' ";
                }
                else
                {
                    NameLIKE = " OIG.BUSNAME LIKE '" + Name + "%' ";
                }
            }


            string sqlString = "SELECT " +
                                   "OIG.BUSNAME," +
                                   "OIG.UPIN," +
                                   "OIG.NPI, " +
                                   "OIG.CITY, " +
                                   "OIG.STATE, " +
                                   "OIG.ZIP " +
                               "FROM " +
                                   "OIGDatabase OIG " +
                               "WHERE" +
                                   NPIEqual + NameLIKE;

            objDBManager.AddParameter("sqlString", sqlString);
            
            return objDBManager.ExecuteDataTable("OIGDatabase_GetAllHospitalByFilter");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    
}