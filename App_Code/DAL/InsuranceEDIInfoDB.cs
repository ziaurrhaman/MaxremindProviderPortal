using System;
using System.Data;

/// <summary>
/// Summary description for InsuranceEDIInfoDB
/// </summary>
public class InsuranceEDIInfoDB
{
	public InsuranceEDIInfoDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}


    public int Add(InsuranceEDIInfo objInsuranceEDIInfo)
    {
        DBManager objDBManager = new DBManager();
        try
        {
            objDBManager.AddParameter("InsuranceEDIinfoID", objInsuranceEDIInfo.InsuranceEDIinfoID, SqlDbType.Int, 4, ParameterDirection.Output);
            objDBManager.AddParameter("TransactionType",objInsuranceEDIInfo.TransactionType);
            objDBManager.AddParameter("SubmitterID",objInsuranceEDIInfo.SubmitterID);
            objDBManager.AddParameter("ReceiverID",objInsuranceEDIInfo.ReceiverID);
            objDBManager.AddParameter("ISA06",objInsuranceEDIInfo.ISA06);
            objDBManager.AddParameter("ISA08",objInsuranceEDIInfo.ISA08);
            objDBManager.AddParameter("ISA05",objInsuranceEDIInfo.ISA05);
            objDBManager.AddParameter("ISA07",objInsuranceEDIInfo.ISA07);
            objDBManager.AddParameter("GS02",objInsuranceEDIInfo.GS02);
            objDBManager.AddParameter("GS03",objInsuranceEDIInfo.GS03);
            objDBManager.AddParameter("ReceiverName",objInsuranceEDIInfo.ReceiverName);
            objDBManager.AddParameter("SubmitterName",objInsuranceEDIInfo.SubmitterName);
            objDBManager.AddParameter("SubmitterContactName",objInsuranceEDIInfo.SubmitterContactName);
            objDBManager.AddParameter("SubmitterContactNumber",objInsuranceEDIInfo.SubmitterContactNumber);
            objDBManager.AddParameter("ReceiverContactName",objInsuranceEDIInfo.ReceiverContactName);
            objDBManager.AddParameter("ReceiverContactNumber",objInsuranceEDIInfo.ReceiverContactNumber);
            objDBManager.AddParameter("CreatedById",objInsuranceEDIInfo.CreatedById);
            objDBManager.AddParameter("CreatedDate",objInsuranceEDIInfo.CreatedDate);            
            objDBManager.AddParameter("Deleted",objInsuranceEDIInfo.Deleted);
            objDBManager.ExecuteNonQuery("InsuranceEDIInfo_Add");
            objInsuranceEDIInfo.InsuranceEDIinfoID = Convert.ToInt32(objDBManager.Parameters[0].Value);

        }
        catch (Exception ex)
        {

            throw ex;
        }

        return objInsuranceEDIInfo.InsuranceEDIinfoID;

    }

    public void Update(InsuranceEDIInfo objInsuranceEDIInfo)
    {
        DBManager objDBManager = new DBManager();
     
        try
        {
            objDBManager.AddParameter("InsuranceEDIinfoID", objInsuranceEDIInfo.InsuranceEDIinfoID, SqlDbType.Int, 4);
            objDBManager.AddParameter("TransactionType",objInsuranceEDIInfo.TransactionType);
            objDBManager.AddParameter("SubmitterID",objInsuranceEDIInfo.SubmitterID);
            objDBManager.AddParameter("ReceiverID",objInsuranceEDIInfo.ReceiverID);
            objDBManager.AddParameter("ISA06",objInsuranceEDIInfo.ISA06);
            objDBManager.AddParameter("ISA08",objInsuranceEDIInfo.ISA08);
            objDBManager.AddParameter("ISA05",objInsuranceEDIInfo.ISA05);
            objDBManager.AddParameter("ISA07",objInsuranceEDIInfo.ISA07);
            objDBManager.AddParameter("GS02",objInsuranceEDIInfo.GS02);
            objDBManager.AddParameter("GS03",objInsuranceEDIInfo.GS03);
            objDBManager.AddParameter("ReceiverName",objInsuranceEDIInfo.ReceiverName);
            objDBManager.AddParameter("SubmitterName",objInsuranceEDIInfo.SubmitterName);
            objDBManager.AddParameter("SubmitterContactName",objInsuranceEDIInfo.SubmitterContactName);
            objDBManager.AddParameter("SubmitterContactNumber",objInsuranceEDIInfo.SubmitterContactNumber);
            objDBManager.AddParameter("ReceiverContactName",objInsuranceEDIInfo.ReceiverContactName);
            objDBManager.AddParameter("ReceiverContactNumber",objInsuranceEDIInfo.ReceiverContactNumber);
            objDBManager.AddParameter("ModifiedById",objInsuranceEDIInfo.ModifiedById);
            objDBManager.AddParameter("ModifiedDate",objInsuranceEDIInfo.ModifiedDate);
            objDBManager.ExecuteNonQuery("InsuranceEDIInfo_Update");


        }
        catch (Exception ex)
        {
            throw ex;

        }
        }

    public DataTable GetClaimsEdiDetails(string claimsId, string InsuranceId)
    {
        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("ClaimId", claimsId);
        objDBManager.AddParameter("InsuranceId", InsuranceId);
        return objDBManager.ExecuteDataTable("InsuranceEDIInfo_GetClaimsEdiDetails");

    }
}