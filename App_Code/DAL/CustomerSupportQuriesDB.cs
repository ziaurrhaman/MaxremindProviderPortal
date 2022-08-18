
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

public class CustomerSupportQuriesDB
{
    public long Add(CustomerSupportQuries objCustomerSupportQuries, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);

            objDBManager.AddParameter("CustomerSupportQuryId", objCustomerSupportQuries.CustomerSupportQuryId, SqlDbType.BigInt, 8, ParameterDirection.Output);

            objDBManager.AddParameter("PracticeId", objCustomerSupportQuries.PracticeId);

            objDBManager.AddParameter("Subject", objCustomerSupportQuries.Subject);


            //objDBManager.AddParameter("RequestDate", objCustomerSupportQuries.RequestDate);
            //objDBManager.AddParameter("ResponseDate", objCustomerSupportQuries.ResponseDate);
            //objDBManager.AddParameter("AssignedTo", objCustomerSupportQuries.AssignedTo);
            //objDBManager.AddParameter("StatusId", objCustomerSupportQuries.ProviderStatusId); 
            //objDBManager.AddParameter("DepartmentId", objCustomerSupportQuries.DepartmentId);
            objDBManager.AddParameter("Descriptions", objCustomerSupportQuries.Descriptions);
            //objDBManager.AddParameter("Response", objCustomerSupportQuries.Response);
            //objDBManager.AddParameter("CustomerSupportCommunicationMethodId", objCustomerSupportQuries.CustomerSupportCommunicationMethodId);
            objDBManager.AddParameter("CreatedById", objCustomerSupportQuries.CreatedById);
            objDBManager.AddParameter("CreatedDate", objCustomerSupportQuries.CreatedDate);
            //if (Convert.ToString(objCustomerSupportQuries.Reminder) != "1/1/0001 12:00:00 AM")
            //{
            //	objDBManager.AddParameter("Reminder", objCustomerSupportQuries.Reminder);
            //}

            objDBManager.ExecuteNonQuery("CustomerSupportQuries_AddByProvider");

            return long.Parse(objDBManager.Parameters[0].Value.ToString());
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int Update(CustomerSupportQuries objCustomerSupportQuries, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager();

            objDBManager.AddParameter("CustomerSupportQuryId", objCustomerSupportQuries.CustomerSupportQuryId, SqlDbType.BigInt, 8);

            //objDBManager.AddParameter("PracticeId", objCustomerSupportQuries.PracticeId);
            objDBManager.AddParameter("Subject", objCustomerSupportQuries.Subject);

            objDBManager.AddParameter("ProviderStatusId", objCustomerSupportQuries.ProviderStatusId);

            objDBManager.AddParameter("Descriptions", objCustomerSupportQuries.Descriptions);
            objDBManager.AddParameter("ModifiedById", objCustomerSupportQuries.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objCustomerSupportQuries.ModifiedDate);

            return objDBManager.ExecuteNonQuery("CustomerSupportQuries_UpdateByProvider");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int Delete(CustomerSupportQuries objCustomerSupportQuries, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);

            objDBManager.AddParameter("CustomerSupportQuryId", objCustomerSupportQuries.CustomerSupportQuryId);

            objDBManager.AddParameter("ModifiedById", objCustomerSupportQuries.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objCustomerSupportQuries.ModifiedDate);

            return objDBManager.ExecuteNonQuery("CustomerSupportQuries_Delete");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet GetAllFilter(int Rows, int PageNumber, string SortBy, string PracticeId, string Subject, string RequesterId, string RequestDate, string ResponseDate
        , string StatusName, string StatusId, string ModuleTypeid, string DepartmentId, string Descriptions, string QueryAnswer, string CommunicationMethodId,
        int QueryId, string CreatedByName, string Reminder = null, string RangeDate1 = null, string RangeDate2 = null)
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
            if (!string.IsNullOrEmpty(PracticeId))
            {
                objDBManager.AddParameter("PracticeId", PracticeId);
            }
            if (!string.IsNullOrEmpty(Subject))
            {
                objDBManager.AddParameter("Subject", Subject);
            }
            if (!string.IsNullOrEmpty(RequesterId))
            {
                objDBManager.AddParameter("RequesterId", RequesterId);
            }
            if (!string.IsNullOrEmpty(RequestDate) && RequestDate != "__/__/____")
            {
                objDBManager.AddParameter("RequestDate", RequestDate);
            }
            if (!string.IsNullOrEmpty(ResponseDate) && ResponseDate != "__/__/____")
            {
                objDBManager.AddParameter("ResponseDate", ResponseDate);
            }

            if (!string.IsNullOrEmpty(StatusName))
            {
                objDBManager.AddParameter("StatusName", StatusName);
            }
            if (!string.IsNullOrEmpty(StatusId))
            {
                objDBManager.AddParameter("StatusId", Convert.ToInt16(StatusId));
            }
            //if (!string.IsNullOrEmpty(ModuleTypeid))
            //{
            //    objDBManager.AddParameter("ModuleTypeid", ModuleTypeid);
            //}
            //if (!string.IsNullOrEmpty(DepartmentId))
            //{
            //    objDBManager.AddParameter("DepartmentId", DepartmentId);
            //}
            if (!string.IsNullOrEmpty(Descriptions))
            {
                objDBManager.AddParameter("Descriptions", Descriptions);
            }
            if (!string.IsNullOrEmpty(QueryAnswer))
            {
                objDBManager.AddParameter("QueryAnswer", QueryAnswer);
            }
            if (!string.IsNullOrEmpty(CommunicationMethodId))
            {
                objDBManager.AddParameter("CommunicationMethodId", CommunicationMethodId);
            }
            if (QueryId != 0)
            {
                objDBManager.AddParameter("CustomerSupportQuryId", QueryId);
            }
            if (!string.IsNullOrEmpty(CreatedByName))
            {
                objDBManager.AddParameter("@CreatedByName", CreatedByName);
            }
            if (!string.IsNullOrEmpty(Reminder) && Reminder != "__/__/____")
            {
                objDBManager.AddParameter("Reminder", Reminder);
            }
            if (!string.IsNullOrEmpty(RangeDate1) && RangeDate1 != "__/__/____")
            {
                objDBManager.AddParameter("RangeDate1", RangeDate1);
            }
            if (!string.IsNullOrEmpty(RangeDate2) && RangeDate2 != "__/__/____")
            {
                objDBManager.AddParameter("RangeDate2", RangeDate2);
            }

            return objDBManager.ExecuteDataSet("CustomerSupportQuries_GetAllByProvider");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet CSDropdowns()
    {
        DBManager objDBManager = new DBManager();

        //objDBManager.AddParameter("UserId", UserId);
        return objDBManager.ExecuteDataSet("GetCS_Statuses");
    }

    public DataSet CustomerSupportQuriesReport(string RangeDate1 = null, string RangeDate2 = null)
    {
        DBManager objDBManager = new DBManager();
        if (!string.IsNullOrEmpty(RangeDate1))
        {
            objDBManager.AddParameter("RangeDate1", RangeDate1);
        }
        if (!string.IsNullOrEmpty(RangeDate1))
        {
            objDBManager.AddParameter("RangeDate2", RangeDate2);
        }
        return objDBManager.ExecuteDataSet("CustomerSupportQuriesReport");
    }
    public DataSet CSQReminderReminder_Report(string Today = null, string UserId = null)
    {
        DBManager objDBManager = new DBManager();
        if (!string.IsNullOrEmpty(Today))
        {
            objDBManager.AddParameter("Today", Today);
        }
        if (!string.IsNullOrEmpty(UserId))
        {
            objDBManager.AddParameter("UserId", UserId);
        }

        return objDBManager.ExecuteDataSet("CustomerSupportQuries_Reminder_Report");
    }

    public DataSet CSQTotalCountForTabs(string RangeDate1 = null, string RangeDate2 = null, string PracticeId = null, DateTime? today = null)
    {
        try
        {
            DBManager objDBManager = new DBManager();
            if (!string.IsNullOrEmpty(RangeDate1))
            {
                objDBManager.AddParameter("RangeDate1", RangeDate1);
            }
            if (!string.IsNullOrEmpty(RangeDate1))
            {
                objDBManager.AddParameter("RangeDate2", RangeDate2);
            }
            if (today.HasValue)
            {
                objDBManager.AddParameter("Today", today);
            }
            if (!string.IsNullOrEmpty(PracticeId))
            {
                objDBManager.AddParameter("PracticeId", PracticeId);
            }
            return objDBManager.ExecuteDataSet("CustomerSupportQuries_TotalCountForTabs");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable ViewALLRequester()
    {
        DBManager objDBManager = new DBManager();

        return objDBManager.ExecuteDataTable("[CSQRequester]");
    }

    public int AddRequesters(string Name, string CreatedDate, long CreatedBy)
    {
        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("@CSQRequesterId", 0);
        objDBManager.AddParameter("@Name", Name);
        objDBManager.AddParameter("@CreatedDate", CreatedDate);
        objDBManager.AddParameter("@CreatedById", CreatedBy);
        return objDBManager.ExecuteNonQuery("CSQRequester_Add");
    }
    public int UpdateRequesters(int id, string Name, string ModifiedDate, long ModifiedById)
    {
        int result = 0;
        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("@CSQRequesterId", id);
        objDBManager.AddParameter("@Name", Name);
        objDBManager.AddParameter("@ModifiedDate", ModifiedDate);
        objDBManager.AddParameter("@ModifiedById", ModifiedById);
        return result = objDBManager.ExecuteNonQuery("CSQRequester_Update");
    }
    public int DeleteRequesters(int id, string ModifiedDate, long ModifiedById)
    {

        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("@CSQRequesterId", id);
        objDBManager.AddParameter("@ModifiedDate", ModifiedDate);
        objDBManager.AddParameter("@ModifiedById", ModifiedById);
        return objDBManager.ExecuteNonQuery("CSQRequester_Delete");
    }
    public int CSQFeedBackByProvider(int id, string CustomerFeedBack, int Rating, DateTime ModifiedDate, long ModifiedById)
    {

        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("CustomerSupportQuryId", id);
        objDBManager.AddParameter("CustomerFeedBack", CustomerFeedBack);
        objDBManager.AddParameter("Rating", Rating);
        objDBManager.AddParameter("ModifiedDate", ModifiedDate);
        objDBManager.AddParameter("ModifiedById", ModifiedById);
        return objDBManager.ExecuteNonQuery("CustomerSupportQuries_FeedBackByProvider");
    }
    public long SendMessage(long practiceid, long ticketid, long userid, string username, string message, long? refersncemsgid)
    {
        DBManager dbm = new DBManager();
        long chatid = 0;
        dbm.AddParameter("@ChatId", chatid, SqlDbType.BigInt, 8, ParameterDirection.Output);
        dbm.AddParameter("@PracticeId", userid);
        dbm.AddParameter("@TicketId", ticketid);
        dbm.AddParameter("@UserName", username);
        dbm.AddParameter("@UserId", userid);
        dbm.AddParameter("@Message", message);
        dbm.AddParameter("@ReferenceMessageId", refersncemsgid);
        dbm.AddParameter("@CreatedById", userid);
        dbm.AddParameter("@CreatedDate", DateTime.Now);
        dbm.AddParameter("@IsVisibleToProvider", true);
        dbm.AddParameter("@IsVisibleToCSOfficer", false);
        dbm.ExecuteNonQuery("customersupportchat_add");
        return long.Parse(dbm.Parameters[0].Value.ToString());
    }
    public DataTable GetAllMessages(long ticketid)
    {
        DBManager dbm = new DBManager();
        dbm.AddParameter("@ModifiedById", 0);
        dbm.AddParameter("@ModifiedDate", DateTime.Now);
        dbm.AddParameter("@TicketId", ticketid);
        dbm.AddParameter("@IsVisibleToProvider", true);
        dbm.AddParameter("@IsVisibleToCSOfficer", null);
        return dbm.ExecuteDataTable("CustomerSupportChat_View");
    }
    public long FileAttachmentAdd(long TicketsId,string AttachmentPath,string FileName, long CreatedById,long PracticeId)
    {
        DBManager dbm = new DBManager();
        dbm.AddParameter("@CSAttachmentsId",0,SqlDbType.BigInt,8,ParameterDirection.Output);
        dbm.AddParameter("@CSTicketsId", TicketsId);
        dbm.AddParameter("@AttachmentPath", AttachmentPath);
        dbm.AddParameter("@FileName", FileName);
        dbm.AddParameter("@CreatedById", CreatedById);
        dbm.AddParameter("@CreatedDate", DateTime.Now);
        dbm.AddParameter("@PracticeId", PracticeId);
         dbm.ExecuteNonQuery("CustomerSupportAttachments_Add");
        return long.Parse(dbm.Parameters[0].Value.ToString());
    }

}