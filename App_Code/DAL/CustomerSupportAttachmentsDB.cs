using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CustomerSupportAttachmentsDB
/// </summary>
public class CustomerSupportAttachmentsDB
{
	public CustomerSupportAttachmentsDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public long Add(CustomerSupportAttachments objCustomerSupportAttachments, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);

            objDBManager.AddParameter("CSAttachmentsId", objCustomerSupportAttachments.CSAttachmentsId, SqlDbType.BigInt, 8, ParameterDirection.Output);

            objDBManager.AddParameter("CSTicketsId", objCustomerSupportAttachments.CSTicketsId);
            objDBManager.AddParameter("AttachmentPath", objCustomerSupportAttachments.AttachmentPath);
            objDBManager.AddParameter("FileName", objCustomerSupportAttachments.FileName);
            objDBManager.AddParameter("CreatedById", objCustomerSupportAttachments.CreatedById);
            objDBManager.AddParameter("CreatedDate", objCustomerSupportAttachments.CreatedDate);
            objDBManager.AddParameter("PracticeId", objCustomerSupportAttachments.PracticeId);

            objDBManager.ExecuteNonQuery("CustomerSupportAttachments_Add");

            return long.Parse(objDBManager.Parameters[0].Value.ToString());
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int Update(CustomerSupportAttachments objCustomerSupportAttachments, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager();

            objDBManager.AddParameter("CSAttachmentsId", objCustomerSupportAttachments.CSAttachmentsId, SqlDbType.BigInt, 8);

            objDBManager.AddParameter("CSTicketsId", objCustomerSupportAttachments.CSTicketsId);
            objDBManager.AddParameter("AttachmentPath", objCustomerSupportAttachments.AttachmentPath);
            objDBManager.AddParameter("FileName", objCustomerSupportAttachments.FileName);
            objDBManager.AddParameter("ModifiedById", objCustomerSupportAttachments.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objCustomerSupportAttachments.ModifiedDate);
            objDBManager.AddParameter("PracticeId", objCustomerSupportAttachments.PracticeId);

            return objDBManager.ExecuteNonQuery("CustomerSupportAttachments_Update");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int Delete(CustomerSupportAttachments objCustomerSupportAttachments, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);

            objDBManager.AddParameter("CSAttachmentsId", objCustomerSupportAttachments.CSAttachmentsId);

            objDBManager.AddParameter("ModifiedById", objCustomerSupportAttachments.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objCustomerSupportAttachments.ModifiedDate);

            return objDBManager.ExecuteNonQuery("CustomerSupportAttachments_Delete");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable GetByID(long CustomerSupportAttachmentsId, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);

            objDBManager.AddParameter("CSAttachmentsId", CustomerSupportAttachmentsId);

            return objDBManager.ExecuteDataTable("CustomerSupportAttachments_GetByID");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet GetAllFilter(int Rows, int PageNumber, string SortBy, int CSTicketsId)
    {
        try
        {
            DBManager objDBManager = new DBManager();

            objDBManager.AddParameter("Rows", Rows);
            objDBManager.AddParameter("PageNumber", PageNumber);
         
            if (!string.IsNullOrEmpty(SortBy))
            {
                objDBManager.AddParameter("SortBy", SortBy);
            }
            objDBManager.AddParameter("@CSTicketsId", CSTicketsId);
            return objDBManager.ExecuteDataSet("CustomerSupportAttachments_GetAllFilter");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

}