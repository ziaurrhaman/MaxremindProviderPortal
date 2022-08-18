using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Web.Script.Serialization;

//Start File Added By Rizwan kharal 16April2018
public partial class EMR_Settings_Ticketing_AddTickets : System.Web.UI.Page
{
    string PageNumber = ""; string Rows = ""; string SortBy = ""; string TicketId = ""; 
    string Category = ""; string ReportedOn = ""; string Piriority = ""; string Status = "";
    string Title = ""; string ReportedBy = ""; string DescriptionFilters = "";
    TicketingDB db = new TicketingDB();

    string title = "";
    string category = "";
    string status = "";
    string Description = "";
    string priority = "";
    protected void Page_Load(object sender, EventArgs e)
    {
       
        
        TicketingDB objTickdb = new TicketingDB();
        Ticketing objTickcs = new Ticketing();
        JavaScriptSerializer objJavaScriptSerializer = new JavaScriptSerializer();

        string action = Request.Form["action"].ToString();

        txtCategory.Items.Insert(0, new ListItem("", "0"));

        TxtDescription.Text = Description;
        txtPriority.Items.Insert(0, new ListItem("", "0"));
        txtStatus.Items.Insert(0, new ListItem("", "0"));


        if (action == "SaveTicketsData")
        {
            var TicketData = Request.Form["TicketData"].ToString();
            string AttachmentData = Request.Form["attachmentList"].ToString();
            objTickcs = objJavaScriptSerializer.Deserialize<Ticketing>(TicketData);
            List<TicketAttachment> attachmentList = objJavaScriptSerializer.Deserialize<List<TicketAttachment>>(AttachmentData);
            objTickcs.PracticeId = Profile.PracticeId.ToString();
            objTickcs.CreatedById = Profile.UserId;
            objTickcs.CreatedDate = DateTime.Now;


            objTickdb.Add(objTickcs);
           TicketId = objTickcs.TicketId.ToString();
            foreach (TicketAttachment objAttachDocuments in attachmentList)
            {
                TicketingDB objTicketingDb = new TicketingDB();

                objAttachDocuments.TicketId = Convert.ToInt64(TicketId);
                objAttachDocuments.PracticeId = Profile.PracticeId.ToString();
                objAttachDocuments.CreatedById = Convert.ToInt32(Profile.UserId);
                objAttachDocuments.CreatedDate = DateTime.Now;
                objAttachDocuments.Deleted = false; // /PracticeDocuments/MessageAttachments/1000/Tickets
               // objAttachDocuments.AttachmentPath = System.Configuration.ConfigurationManager.AppSettings["PracticePath"].ToString() + "/" + "MessageAttachments/" + Profile.PracticeId.ToString() + "/" + "Tickets";
                    //
                objTickdb.AddTicAttachment(objAttachDocuments);

            }

            ShowTicketsData();

        }

      
      

        if (action == "Ticketsdetail")
        {
            TicketId = Request.Form["TicketId"].ToString();
         
            DataSet ds = db.TicketingDetails(Profile.PracticeId, 10, 0, "", TicketId);
            title = ds.Tables[0].Rows[0]["Title"].ToString();
            category = ds.Tables[0].Rows[0]["Category"].ToString();
            priority = ds.Tables[0].Rows[0]["Priority"].ToString();
            status = ds.Tables[0].Rows[0]["Status"].ToString();
            Description = ds.Tables[0].Rows[0]["Description"].ToString();

            lblTitle.Text = title;
            lblCategory.Text = category;
            lblDescription.Text = Description;
            lblPriority.Text = priority;
            lblStatus.Text = status;

            DataSet dsAttachment = db.GetAllByTicketDocumentsByTicketId(Convert.ToInt64(TicketId));
            rptAttachment.DataSource = dsAttachment;
            rptAttachment.DataBind();
     

        }

        if (action == "Filter")
        {
            FilterTicketsData();
        }

        if (action == "DeleteTicket")
        {
            
            DeleteTickets();
            ShowTicketsData();
         
        }
        if (action == "RemoveAttachment")
        {
            RemoveAttachment();

            ShowTicketsData();
        }
        if (action == "UpdateTicketDialog")
        {
            UpdateTicketDialog();  
        }
        if (action == "UpdateTicket")
        {
            var TicketData = Request.Form["TicketData"].ToString();
           TicketId = Request.Form["TicketId"].ToString();
            string AttachmentData = Request.Form["attachmentList"].ToString();
            objTickcs = objJavaScriptSerializer.Deserialize<Ticketing>(TicketData);
            List<TicketAttachment> attachmentList = objJavaScriptSerializer.Deserialize<List<TicketAttachment>>(AttachmentData);
            objTickcs.PracticeId = Profile.PracticeId.ToString();
            objTickcs.ModifiedById = Convert.ToInt32(Profile.UserId);
            objTickcs.ModifiedDate = DateTime.Now;
            objTickcs.TicketId = Convert.ToInt64(TicketId);

            objTickdb.Update(objTickcs);

            TicketId = objTickcs.TicketId.ToString();
            foreach (TicketAttachment objAttachDocuments in attachmentList)
            {
                TicketingDB objTicketingDb = new TicketingDB();

                objAttachDocuments.TicketId = Convert.ToInt64(TicketId);
                objAttachDocuments.PracticeId = Profile.PracticeId.ToString();
                objAttachDocuments.CreatedById = Convert.ToInt32(Profile.UserId);
                objAttachDocuments.CreatedDate = DateTime.Now;
                objAttachDocuments.Deleted = false;
              //  objAttachDocuments.AttachmentPath = System.Configuration.ConfigurationManager.AppSettings["PracticePath"].ToString() + "/" + "MessageAttachments/" + Profile.PracticeId.ToString() + "/" + "Tickets";
                objTickdb.AddTicAttachment(objAttachDocuments);

            }

            ShowTicketsData();
        }
    }

    public void UpdateTicketDialog()
    {
        TicketId = Request.Form["TicketId"].ToString();

        DataSet ds = db.TicketingDetails(Profile.PracticeId, 10, 0, "", TicketId);
        title = ds.Tables[0].Rows[0]["Title"].ToString();
        category = ds.Tables[0].Rows[0]["Category"].ToString();
        priority = ds.Tables[0].Rows[0]["Priority"].ToString();
        status = ds.Tables[0].Rows[0]["Status"].ToString();
        Description = ds.Tables[0].Rows[0]["Description"].ToString();

        TxtTitle.Text = title;

        if (category.Trim() != "")
        {
            txtCategory.SelectedValue = txtCategory.Items.FindByText(category.Trim()).Value;
        }
      


        TxtDescription.Text = Description;
        if (priority.Trim() != "")
        {
            txtPriority.SelectedValue = txtPriority.Items.FindByValue(priority.Trim()).Value;
        }
        if (status.Trim() != "")
        {
            txtStatus.SelectedValue = txtStatus.Items.FindByValue(status.Trim()).Value;
        }

        DataSet dsAttachment = db.GetAllByTicketDocumentsByTicketId(Convert.ToInt64(TicketId));
        rptAttachment.DataSource = dsAttachment;
        rptAttachment.DataBind();
    }
    public void ShowTicketsData()
    {
        string PageNum = "";
        if (Request.Form["Rows"].ToString() == "")
        {
            Rows = "10";
        }
        else
        {
            Rows = Request.Form["Rows"].ToString();
        }
        string Page = Request.Form["PageNumber"].ToString();
        if (Page == "0" || Convert.ToInt32(Page) < 0)
        {
            PageNum = "0";
        }
        else
        {
           
            PageNum = Request.Form["PageNumber"].ToString();
        }
        TicketingDB db = new TicketingDB();
        DataSet ds = db.TicketingDetails(Profile.PracticeId, Convert.ToInt32(Rows), Convert.ToInt32(PageNum), "TicketId desc", "");
        if (ds.Tables[0].Rows.Count > 0)
        {
            RptTickets.DataSource = ds;
            RptTickets.DataBind();
            hdnTicketsTotalRows.Value = ds.Tables[1].Rows[0]["TotalRows"].ToString();
        }
        else
        {
            DataSet objDs = db.TicketingDetails(Profile.PracticeId, 10,0, "TicketId desc", "");
            RptTickets.DataSource = objDs;
            RptTickets.DataBind();
            hdnTicketsTotalRows.Value = objDs.Tables[1].Rows[0]["TotalRows"].ToString();
        }
      
    }

    public void FilterTicketsData()
    {
        PageNumber = Request.Form["PageNumber"].ToString();
        Rows = Request.Form["Rows"].ToString();
        SortBy = Request.Form["SortBy"].ToString();
        TicketId = Request.Form["TicketId"].ToString();
        Category = Request.Form["Category"].ToString();
        ReportedOn = Request.Form["ReportedOn"].ToString();
        Piriority = Request.Form["Piriority"].ToString();
        Status = Request.Form["Status"].ToString();
        ReportedBy = Request.Form["ReportedBy"].ToString();
        Title = Request.Form["Title"].ToString();
        TicketingDB db = new TicketingDB();
        DescriptionFilters = Request.Form["Description"].ToString();
        DataSet ds = db.FilterTicketing(Profile.PracticeId, Convert.ToInt32(Rows), Convert.ToInt32(PageNumber), SortBy, TicketId, Title, DescriptionFilters, ReportedBy, Category, ReportedOn, Piriority, Status);
        RptTickets.DataSource = ds;
        RptTickets.DataBind();
        hdnTicketsTotalRows.Value = ds.Tables[1].Rows[0]["TotalRows"].ToString();
    }

    public void DeleteTickets()
    {
        TicketingDB db = new TicketingDB();
        Ticketing cs = new Ticketing();
        TicketId = Request.Form["TicketId"].ToString();
        cs.Deleted = true;
        cs.ModifiedById = Convert.ToInt32(Profile.UserId);
        cs.ModifiedDate = DateTime.Now;
        cs.TicketId = Convert.ToInt64(TicketId);
        db.DeleteTicket(cs);

    }

    public void RemoveAttachment()
    {
        TicketingDB db = new TicketingDB();
        TicketAttachment cs = new TicketAttachment();
         string  AttachmentId = Request.Form["AttachmentId"].ToString();
        cs.Deleted = true;
        cs.ModifiedById = Convert.ToInt32(Profile.UserId);
        cs.ModifiedDate = DateTime.Now;
        cs.TicketAttachmentsId = Convert.ToInt64(AttachmentId);
        db.RemoveAttachment(cs);

    }
    protected void rptTicketsDocuments_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView drv = (DataRowView)e.Item.DataItem;
            string DocumentName = drv["FileName"].ToString();

            string AttachmentPath = drv["AttachmentPath"].ToString();
            Literal     attachment = (Literal)e.Item.FindControl("ltrAttachment");

            //Changes By Syed Sajid Ali Date:12/26/2017
            //attachment.Text = "<span onclick=\"downloadAgencyDocument('" + AttachmentPath + "','" + drv["FileName"] + "')\"> <span class='spanfile " + fileExtClass + "'></span><span class=\"spanfilename\" style='float: left;'>" + drv["FileName"] + "</span></span>";

            attachment.Text = "<span style='cursor: pointer;color: blue;padding: 3px 0 0 22px;margin-left: 5px;width: auto;' class='attachment-icon attachment-name11' title='Click to Download' onclick=\"saveToDisk('" +
                                       ResolveUrl("" + drv["AttachmentPath"]) + "','" + drv["FileName"] + "')\">" + drv["FileName"] + "</span>";

            //End By Syed Sajid Ali
        }
    }
}