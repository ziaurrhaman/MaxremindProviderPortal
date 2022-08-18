using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for ReferringPhysicianDB
/// </summary>
public class ReferringPhysicianDB
{
	public ReferringPhysicianDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    
    public long Add(ReferringPhysician objReferringPhysician)
    {

        DBManager objDBManager = new DBManager();


        try
        {
            objDBManager.AddParameter("ReferringPhysicianId", objReferringPhysician.ReferringPhysicianId, SqlDbType.BigInt, 8, ParameterDirection.Output);

            objDBManager.AddParameter("FirstName", objReferringPhysician.FirstName,  SqlDbType.VarChar, 25);
            objDBManager.AddParameter("MiddleName", objReferringPhysician.MiddleName,  SqlDbType.VarChar, 25);
            objDBManager.AddParameter("LastName", objReferringPhysician.LastName,  SqlDbType.VarChar, 25);
            objDBManager.AddParameter("UPin", objReferringPhysician.UPin,  SqlDbType.VarChar, 10);
            objDBManager.AddParameter("NPI", objReferringPhysician.NPI,  SqlDbType.VarChar, 25);
            objDBManager.AddParameter("LicenseNo", objReferringPhysician.LicenseNo,  SqlDbType.VarChar, 25);
            objDBManager.AddParameter("LicenseExpiration", objReferringPhysician.LicenseExpiration,  SqlDbType.DateTime, 3);
            objDBManager.AddParameter("CommunityCareNo", objReferringPhysician.CommunityCareNo,  SqlDbType.VarChar, 25);
            objDBManager.AddParameter("DOB", objReferringPhysician.DateOfBirth);
            objDBManager.AddParameter("Cell", objReferringPhysician.Cell);
            objDBManager.AddParameter("Gender", objReferringPhysician.Gender);
            objDBManager.AddParameter("ContactPerson", objReferringPhysician.ContactPerson,  SqlDbType.VarChar, 25);
            objDBManager.AddParameter("Address", objReferringPhysician.Address,  SqlDbType.VarChar, 100);
            objDBManager.AddParameter("Zip", objReferringPhysician.Zip,  SqlDbType.VarChar, 25);
            objDBManager.AddParameter("City", objReferringPhysician.City,  SqlDbType.VarChar, 25);
            objDBManager.AddParameter("State", objReferringPhysician.State,  SqlDbType.VarChar, 2);
            objDBManager.AddParameter("Phone", objReferringPhysician.Phone,  SqlDbType.VarChar, 30);
            objDBManager.AddParameter("Fax", objReferringPhysician.Fax,  SqlDbType.VarChar, 30);
            objDBManager.AddParameter("Email", objReferringPhysician.Email,  SqlDbType.VarChar, 50);
            objDBManager.AddParameter("ExternalReferral", objReferringPhysician.ExternalReferral,  SqlDbType.Bit, 1);
            objDBManager.AddParameter("Comments", objReferringPhysician.Comments,  SqlDbType.VarChar, 1000);
            objDBManager.AddParameter("TaxId", objReferringPhysician.TaxId,  SqlDbType.VarChar, 25);
            objDBManager.AddParameter("CreatedById", objReferringPhysician.CreatedById,  SqlDbType.Int, 4);
            objDBManager.AddParameter("CreatedDate", objReferringPhysician.CreatedDate,  SqlDbType.DateTime, 8);
            objDBManager.AddParameter("InActive", objReferringPhysician.InActive,  SqlDbType.Bit, 1);
            objDBManager.AddParameter("Deleted", objReferringPhysician.Deleted,  SqlDbType.Bit, 1);

            objDBManager.ExecuteNonQuery("ReferringPhysician_Add");

            objReferringPhysician.ReferringPhysicianId = (long) objDBManager.Parameters[0].Value;

        }
        catch (Exception ex)
        {

            throw ex;

        }

        return objReferringPhysician.ReferringPhysicianId;

    }
    
    public int Update(ReferringPhysician objReferringPhysician)
    {

        DBManager objDBManager = new DBManager();
        int ReturnValue = 0;

        try
        {

            objDBManager.AddParameter("ReferringPhysicianId", objReferringPhysician.ReferringPhysicianId, SqlDbType.BigInt, 8);

            objDBManager.AddParameter("FirstName", objReferringPhysician.FirstName,  SqlDbType.VarChar, 25);
            objDBManager.AddParameter("MiddleName", objReferringPhysician.MiddleName,  SqlDbType.VarChar, 25);
            objDBManager.AddParameter("LastName", objReferringPhysician.LastName,  SqlDbType.VarChar, 25);
            objDBManager.AddParameter("UPin", objReferringPhysician.UPin,  SqlDbType.VarChar, 10);
            objDBManager.AddParameter("NPI", objReferringPhysician.NPI,  SqlDbType.VarChar, 25);
            objDBManager.AddParameter("LicenseNo", objReferringPhysician.LicenseNo,  SqlDbType.VarChar, 25);
            objDBManager.AddParameter("LicenseExpiration", objReferringPhysician.LicenseExpiration,  SqlDbType.DateTime, 3);
            objDBManager.AddParameter("CommunityCareNo", objReferringPhysician.CommunityCareNo,  SqlDbType.VarChar, 25);
            objDBManager.AddParameter("DOB", objReferringPhysician.DateOfBirth);
            objDBManager.AddParameter("Cell", objReferringPhysician.Cell);
            objDBManager.AddParameter("Gender", objReferringPhysician.Gender);
            objDBManager.AddParameter("ContactPerson", objReferringPhysician.ContactPerson,  SqlDbType.VarChar, 25);
            objDBManager.AddParameter("Address", objReferringPhysician.Address,  SqlDbType.VarChar, 100);
            objDBManager.AddParameter("Zip", objReferringPhysician.Zip,  SqlDbType.VarChar, 25);
            objDBManager.AddParameter("City", objReferringPhysician.City,  SqlDbType.VarChar, 25);
            objDBManager.AddParameter("State", objReferringPhysician.State,  SqlDbType.VarChar, 2);
            objDBManager.AddParameter("Phone", objReferringPhysician.Phone,  SqlDbType.VarChar, 30);
            objDBManager.AddParameter("Fax", objReferringPhysician.Fax,  SqlDbType.VarChar, 30);
            objDBManager.AddParameter("Email", objReferringPhysician.Email,  SqlDbType.VarChar, 50);
            objDBManager.AddParameter("ExternalReferral", objReferringPhysician.ExternalReferral,  SqlDbType.Bit, 1);
            objDBManager.AddParameter("Comments", objReferringPhysician.Comments,  SqlDbType.VarChar, 1000);
            objDBManager.AddParameter("TaxId", objReferringPhysician.TaxId,  SqlDbType.VarChar, 25);
            objDBManager.AddParameter("CreatedById", objReferringPhysician.CreatedById,  SqlDbType.Int, 4);
            objDBManager.AddParameter("CreatedDate", objReferringPhysician.CreatedDate,  SqlDbType.DateTime, 8);
            objDBManager.AddParameter("ModifiedById", objReferringPhysician.ModifiedById,  SqlDbType.Int, 4);
            objDBManager.AddParameter("ModifiedDate", objReferringPhysician.ModifiedDate,  SqlDbType.DateTime, 8);
            objDBManager.AddParameter("InActive", objReferringPhysician.InActive,  SqlDbType.Bit, 1);
            objDBManager.AddParameter("Deleted", objReferringPhysician.Deleted,  SqlDbType.Bit, 1);

            ReturnValue = objDBManager.ExecuteNonQuery("ReferringPhysician_Update");


        }
        catch (Exception ex)
        {
            throw ex;

        }

        return ReturnValue;

    }
    
    public DataTable GetAllPhysician()
    {
        DBManager objDBManager = new DBManager();
        return objDBManager.ExecuteDataTable("ReferringPhysician_GetAll");
    }
    
    
    //haseeb
    public DataTable GetAllPhysicianByPractice(long PracticeId)
    {
        DBManager ObjDBManager = new DBManager();
        return ObjDBManager.ExecuteDataTable("ReferringPhysician_GetAllByPractice");
        
    }
}