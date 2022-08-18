using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for TicketingDB
/// </summary>
/// 
//File Added By Rizwan kharal 16April2018
public class TicketingDB
{
    public TicketingDB()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public long Add(Ticketing objTicketing)
    {

        DBManager objDBManager = new DBManager();

        try
        {

            objDBManager.AddParameter("TicketId", objTicketing.TicketId, SqlDbType.BigInt, 8, ParameterDirection.Output);
            objDBManager.AddParameter("Title", objTicketing.Title);
            objDBManager.AddParameter("PracticeId", objTicketing.PracticeId);
            objDBManager.AddParameter("Category", objTicketing.Category);
            objDBManager.AddParameter("ReportedBy", objTicketing.ReportedBy);
            objDBManager.AddParameter("Priority", objTicketing.Priority);
            objDBManager.AddParameter("Status", objTicketing.Status);
            objDBManager.AddParameter("Description", objTicketing.Description);
            objDBManager.AddParameter("CreatedById", objTicketing.CreatedById);
            objDBManager.AddParameter("CreatedDate", objTicketing.CreatedDate);
            objDBManager.AddParameter("Deleted", objTicketing.Deleted, SqlDbType.Bit, 1);

            objDBManager.ExecuteNonQuery("Ticket_Add");

            objTicketing.TicketId = Convert.ToInt32(objDBManager.Parameters[0].Value);

        }
        catch (Exception ex)
        {


            throw ex;

        }

        return (long)Convert.ToInt32(objTicketing.TicketId);

    }
    public long AddTicAttachment(TicketAttachment objTicketingAttch)
    {

        DBManager objDBManager = new DBManager();

        try
        {
            objDBManager.AddParameter("TicketAttachmentsId", objTicketingAttch.TicketAttachmentsId, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("PracticeId", objTicketingAttch.PracticeId, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("TicketId", objTicketingAttch.TicketId, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("AttachmentPath", objTicketingAttch.AttachmentPath, SqlDbType.VarChar, 250);
            objDBManager.AddParameter("FileName", objTicketingAttch.FileName, SqlDbType.VarChar, 250);
            objDBManager.AddParameter("Notes", objTicketingAttch.Notes, SqlDbType.VarChar, 250);
            objDBManager.AddParameter("CreatedById", objTicketingAttch.CreatedById, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("CreatedDate", objTicketingAttch.CreatedDate);
            objDBManager.AddParameter("Deleted", objTicketingAttch.Deleted, SqlDbType.Bit, 1);
            objDBManager.ExecuteNonQuery("TicketAttachments_Add");

            objTicketingAttch.TicketAttachmentsId = Convert.ToInt32(objDBManager.Parameters[0].Value);
        }
        catch (Exception ex)
        {


            throw ex;

        }

        return (long)Convert.ToInt32(objTicketingAttch.TicketAttachmentsId);

    }
    public long Update(Ticketing objTicketing, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager();

            objDBManager.AddParameter("TicketId", objTicketing.TicketId, SqlDbType.BigInt, 8);

            objDBManager.AddParameter("Title", objTicketing.Title);
            //objDBManager.AddParameter("Agency", objTicketing.Agency, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("Category", objTicketing.Category);
            objDBManager.AddParameter("ReportedBy", objTicketing.ReportedBy);
            objDBManager.AddParameter("Priority", objTicketing.Priority);
            objDBManager.AddParameter("Status", objTicketing.Status);
            objDBManager.AddParameter("Description", objTicketing.Description);
            objDBManager.AddParameter("Attachements", objTicketing.Attachements);
            objDBManager.AddParameter("ModifiedById", objTicketing.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objTicketing.ModifiedDate);
            //objDBManager.AddParameter("Deleted", objTicketing.Deleted, SqlDbType.Bit, 1);

            objDBManager.ExecuteNonQuery("TicketForm_Update");
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return objTicketing.TicketId;
    }

    #region 'Added By:Syed Sajia Ali'
    public DataSet TicketingDetails(long PracticeId, int Rows, int PageNumber, string SortBy, string TicketId)
    {
        DBManager ObjDBManager = new DBManager();
        ObjDBManager.AddParameter("@PracticeId", PracticeId);

        ObjDBManager.AddParameter("@Rows", Rows);
        ObjDBManager.AddParameter("@PageNumber", PageNumber);

        ObjDBManager.AddParameter("@SortBy", SortBy);

        if (!string.IsNullOrEmpty(TicketId))
        {
            ObjDBManager.AddParameter("@TicketId", TicketId);
        }

        return ObjDBManager.ExecuteDataSet("GetTicketDetailsBy_PracticeId");
    }




    public DataSet GetAllByTicketDocumentsByTicketId(long AttachmentTicketId)
    {
        DBManager ObjDBManager = new DBManager();
        ObjDBManager.AddParameter("@AttachmentTicketId", AttachmentTicketId);
        //ObjDBManager.AddParameter("@AgencyId", AgencyId);

        return ObjDBManager.ExecuteDataSet("GetTicketAttachmentDetailsBy_TicketId");
    }


    public int DeleteTicket(Ticketing objTicket, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);
            objDBManager.AddParameter("TicketId", objTicket.TicketId);
            objDBManager.AddParameter("ModifiedById", objTicket.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objTicket.ModifiedDate);
            return objDBManager.ExecuteNonQuery("DeleteTicketByTicketId");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    #endregion

    public DataSet FilterTicketing(long PracticeId, int Rows, int PageNumber, string SortBy, string TicketId, string Title, string Description, string ReportedBy, string Category, string ReportedOn, string Piriority, string Status)
    {
        DBManager ObjDBManager = new DBManager();
        ObjDBManager.AddParameter("@PracticeId", PracticeId);

        ObjDBManager.AddParameter("@Rows", Rows);
        ObjDBManager.AddParameter("@PageNumber", PageNumber);

        ObjDBManager.AddParameter("@SortBy", SortBy);

        if (!string.IsNullOrEmpty(TicketId))
        {
            ObjDBManager.AddParameter("@TicketId", TicketId);
        }
        if (!string.IsNullOrEmpty(Title))
        {
            ObjDBManager.AddParameter("@Title", Title);
        }

        if (!string.IsNullOrEmpty(Description))
        {
            ObjDBManager.AddParameter("@Description", Description);
        }


        if (!string.IsNullOrEmpty(ReportedBy))
        {
            ObjDBManager.AddParameter("@ReportedBy", ReportedBy);
        }
        if (!string.IsNullOrEmpty(Category))
        {
            ObjDBManager.AddParameter("Category", Category);
        }
        if (!string.IsNullOrEmpty(ReportedOn))
        {
            ObjDBManager.AddParameter("ReportedOn", ReportedOn);
        } if (!string.IsNullOrEmpty(Piriority))
        {
            ObjDBManager.AddParameter("Piriority", Piriority);
        }
        if (!string.IsNullOrEmpty(Status))
        {
            ObjDBManager.AddParameter("Status", Status);
        }

        return ObjDBManager.ExecuteDataSet("GetTicketDetailsBy_PracticeId");
    }

    public int RemoveAttachment(TicketAttachment objAttachment, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);
            objDBManager.AddParameter("AttachmentId", objAttachment.TicketAttachmentsId);
            objDBManager.AddParameter("ModifiedById", objAttachment.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objAttachment.ModifiedDate);
            return objDBManager.ExecuteNonQuery("DeleteAttachmentByAttachmentId");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetPendingFileByAttachmentTicketId(long AttachmentTicketId, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);

            objDBManager.AddParameter("@AttachmentTicketId", @AttachmentTicketId);

            return objDBManager.ExecuteDataTable("GetTicketAttachmentDetailsBy_TicketId");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}