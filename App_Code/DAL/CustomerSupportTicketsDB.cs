using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CustomerSupportTicketsDB
/// </summary>
public class CustomerSupportTicketsDB
{
	public CustomerSupportTicketsDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public long Add(CustomerSupportTickets objCustomerSupportTickets, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);

            objDBManager.AddParameter("CSTicketsId", objCustomerSupportTickets.CSTicketsId, SqlDbType.BigInt, 8, ParameterDirection.Output);

            objDBManager.AddParameter("PracticeId", objCustomerSupportTickets.PracticeId);
            objDBManager.AddParameter("TicketType", objCustomerSupportTickets.TicketType);
            objDBManager.AddParameter("ProblemRelatedTo", objCustomerSupportTickets.ProblemRelatedTo);
          
            if (objCustomerSupportTickets.PatientId != 0)
            {
                objDBManager.AddParameter("PatientId", objCustomerSupportTickets.PatientId);
            }

            if (objCustomerSupportTickets.ClaimId != 0)
            {

                objDBManager.AddParameter("ClaimId", objCustomerSupportTickets.ClaimId);
            }
            if (objCustomerSupportTickets.Insurance != "")
            {
                objDBManager.AddParameter("Insurance", objCustomerSupportTickets.Insurance);
            }
            if (objCustomerSupportTickets.PolicyNumber != "")
            {
                objDBManager.AddParameter("PolicyNumber", objCustomerSupportTickets.PolicyNumber);
            }


            objDBManager.AddParameter("DOS", objCustomerSupportTickets.CreatedDate);
            if (objCustomerSupportTickets.Description != "")
            {
                objDBManager.AddParameter("Description", objCustomerSupportTickets.Description);
          
            }
            if (objCustomerSupportTickets.Priority != "")
            {
                objDBManager.AddParameter("Priority", objCustomerSupportTickets.Priority);

            }
            if (objCustomerSupportTickets.Status != "")
            {
                objDBManager.AddParameter("Status", objCustomerSupportTickets.Status);

            }
          
            objDBManager.AddParameter("CreatedDate", objCustomerSupportTickets.CreatedDate);
            objDBManager.AddParameter("CreatedById", objCustomerSupportTickets.CreatedById);

            objDBManager.ExecuteNonQuery("CustomerSupportTickets_Add");

            return long.Parse(objDBManager.Parameters[0].Value.ToString());
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int Update(CustomerSupportTickets objCustomerSupportTickets, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager();

            objDBManager.AddParameter("CSTicketsId", objCustomerSupportTickets.CSTicketsId, SqlDbType.BigInt, 8);

            objDBManager.AddParameter("PracticeId", objCustomerSupportTickets.PracticeId);
            objDBManager.AddParameter("TicketType", objCustomerSupportTickets.TicketType);
            objDBManager.AddParameter("ProblemRelatedTo", objCustomerSupportTickets.ProblemRelatedTo);
            objDBManager.AddParameter("PatientId", objCustomerSupportTickets.PatientId);
            objDBManager.AddParameter("DOS", objCustomerSupportTickets.DOS);
            objDBManager.AddParameter("Description", objCustomerSupportTickets.Description);

            objDBManager.AddParameter("Priority", objCustomerSupportTickets.Priority);
            objDBManager.AddParameter("ModifiedDate", objCustomerSupportTickets.ModifiedDate);
            objDBManager.AddParameter("ModifiedById", objCustomerSupportTickets.ModifiedById);

            return objDBManager.ExecuteNonQuery("CustomerSupportTickets_Update");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int Delete(CustomerSupportTickets objCustomerSupportTickets, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);

            objDBManager.AddParameter("CSTicketsId", objCustomerSupportTickets.CSTicketsId);

            objDBManager.AddParameter("ModifiedById", objCustomerSupportTickets.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objCustomerSupportTickets.ModifiedDate);

            return objDBManager.ExecuteNonQuery("CustomerSupportTickets_Delete");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable GetByID(long CustomerSupportTicketsId, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);

            objDBManager.AddParameter("CustomerSupportTicketsId", CustomerSupportTicketsId);

            return objDBManager.ExecuteDataTable("CustomerSupportTickets_GetByID");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    //	@TicketNo varchar(10)=null,
    //@DateFrom date=null,
    //@DateTo date=null

    public DataSet GetAllFilter(long PracticeId, int Rows, int PageNumber, string SortBy, int TicketNo, string DateFrom, string DateTo)
    {
        try
        {
            DBManager objDBManager = new DBManager();
            objDBManager.AddParameter("PracticeId", PracticeId);
            objDBManager.AddParameter("Rows", Rows);
            objDBManager.AddParameter("PageNumber", PageNumber);

            if (!string.IsNullOrEmpty(SortBy))
            {
                objDBManager.AddParameter("SortBy", SortBy);
            }

            if (TicketNo != 0)
            {
                objDBManager.AddParameter("TicketNo", TicketNo);
            }

            if (!string.IsNullOrEmpty(DateFrom))
            {
                objDBManager.AddParameter("DateFrom", DateFrom);
            }

            if (!string.IsNullOrEmpty(DateTo))
            {
                objDBManager.AddParameter("DateTo", DateTo);
            }

            return objDBManager.ExecuteDataSet("CustomerSupportTickets_GetAllFilter");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}