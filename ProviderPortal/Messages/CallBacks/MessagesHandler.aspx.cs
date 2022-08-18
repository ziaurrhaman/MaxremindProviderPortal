using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using System.Configuration;
using System.Net.Mail;
using System.Data;
using System.IO;

public partial class HomeHealth_Messages_CallBacks_MessagesHandler : System.Web.UI.Page
{
    int userId;

    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.Form["action"].ToString();
        MessagesDB objMessagesDb = new MessagesDB();
        userId = Convert.ToInt32(Profile.UserId);

        if (action == "Add")
        {
            string MessageType = Request.Form["MessageType"].ToString();

            if (MessageType == "Internal")
            {
                MessageSendInternal();
            }
            else if (MessageType == "External")
            {
                MessageSendExternal();
            }
            else if (MessageType == "InternalExternal")
            {

                MessageSendInternal();
                if (Request.Form["ExternalTo"] != null)
                {
                    if (!string.IsNullOrEmpty(Request.Form["ExternalTo"].ToString()))
                        MessageSendExternal();
                }   
            }
        }
        else if (action == "Reply")
        {
            MessageReply();
        }
        else if (action == "Delete")
        {
            string deleteFromaction = Request.Form["DeleteFromaction"];
            string messagesId = Request.Form["MessagesId"];
            
            if (deleteFromaction.Contains("Deleted"))
                deleteFromaction = "ShowInDeleted";
            else if (deleteFromaction.Contains("Sent Item"))
                deleteFromaction = "ShowInSent";
            else if (deleteFromaction.Contains("Draft"))
                deleteFromaction = "IsDraft";

            objMessagesDb.Delete(messagesId, Profile.UserId, deleteFromaction);
        }
        DataTable dtUnreadMessages = objMessagesDb.UnreadMessageCount(Profile.UserId);
        if (dtUnreadMessages.Rows.Count > 0)
        {
            if (dtUnreadMessages.Rows[0]["UnreadCount"].ToString() != "0")
                ltrUnreadMessageCount.Text = dtUnreadMessages.Rows[0]["UnreadCount"].ToString();
        }
        

    }

    public void MessageSendInternal()
    {
        string emailTo = Request.Form["emailTo"].ToString();
        string emailCC = Request.Form["emailCC"].ToString();
        string subject = Request.Form["subject"].ToString();
        string priority = Request.Form["priority"].ToString();
        string body = Request.Form["body"].ToString();
        bool isDraft = bool.Parse(Request.Form["isDraft"].ToString());

        JavaScriptSerializer serializer = new JavaScriptSerializer();
        List<MessageAttachments> attachmentList = serializer.Deserialize<List<MessageAttachments>>(Request.Form["attachmentList"]);

        string messageCode = Guid.NewGuid().ToString();

        //Insert into messages Table
        Messages objMessages = new Messages();
        objMessages.MessageCode = messageCode;
        objMessages.Subject = subject;
        objMessages.Body = body;
        objMessages.IsDraft = isDraft;
        objMessages.ShowInSent = !(isDraft);
        objMessages.MessageFromUserId = userId.ToString();
        objMessages.Priority = priority;
        objMessages.CreatedById = userId;
        objMessages.CreatedDate = DateTime.Now;
        objMessages.Deleted = false;

        MessagesManager objMessagesManager = new MessagesManager();
        long messageId = objMessagesManager.Add(objMessages);
        ltrMessageId.Text = messageId.ToString();
        //Insert into usermessages Table

        string[] emailToUsers = emailTo.Split(',');

        UserMessages objUserMessages;
        UserMessagesManager objUserMessagesManager = new UserMessagesManager(); ;

        for (int i = 0; i < emailToUsers.Length - 1; i++)
        {
            objUserMessages = new UserMessages();
            objUserMessages.MessageCode = messageCode;
            objUserMessages.MessagesId = messageId;
            objUserMessages.ReceiverId = int.Parse(emailToUsers[i]);
            objUserMessages.ReceiverType = "To";
            objUserMessages.MessageStatus = "Unread";
            objUserMessages.CreatedById = userId;
            objUserMessages.CreatedDate = DateTime.Now;
            objUserMessages.Deleted = false;

            objUserMessagesManager.Add(objUserMessages);
        }

        string[] emailCCUsers = emailCC.Split(',');
        for (int i = 0; i < emailCCUsers.Length - 1; i++)
        {
            objUserMessages = new UserMessages();
            objUserMessages.MessageCode = messageCode;
            objUserMessages.MessagesId = messageId;
            objUserMessages.ReceiverId = int.Parse(emailCCUsers[i]);
            objUserMessages.ReceiverType = "CC";
            objUserMessages.MessageStatus = "Unread";
            objUserMessages.CreatedById = Profile.UserId;
            objUserMessages.CreatedDate = DateTime.Now;
            objUserMessages.Deleted = false;

            objUserMessagesManager.Add(objUserMessages);
        }

        //Insert into messagesAttachment Table
        MessageAttachmentsManager objMessageAttachmentsManager = new MessageAttachmentsManager();

        foreach (MessageAttachments objMessageAttachments in attachmentList)
        {
            objMessageAttachments.MessagesId = messageId;
            objMessageAttachments.CreatedById = userId;
            objMessageAttachments.CreatedDate = DateTime.Now;
            objMessageAttachments.Deleted = false;
            objMessageAttachmentsManager.Add(objMessageAttachments);
        }
        ltrReturnValue.Text = "Success: Message Sent!";
    }

    public void MessageReply()
    {

    }


    public void MessageSendExternal()
    {
        string emailToStr = Request.Form["ExternalTo"].ToString();
        string emailCCStr = Request.Form["ExternalCC"].ToString();

        string subject = Request.Form["subject"].ToString();
        string priority = Request.Form["priority"].ToString();
        string body = Request.Form["emailMessage"].ToString();

        emailToStr = emailToStr.TrimEnd(',');

        emailCCStr = emailCCStr.TrimEnd(',');

        JavaScriptSerializer serializer = new JavaScriptSerializer();
        List<MessageAttachments> attachmentList = serializer.Deserialize<List<MessageAttachments>>(Request.Form["attachmentList"]);
        bool CopyAttachments = false;
        if (!string.IsNullOrEmpty(Request.Form["CopyAttachments"]))
            CopyAttachments = bool.Parse(Request.Form["CopyAttachments"]);

        if (CopyAttachments)
        {

            string messageDirectory = ConfigurationManager.AppSettings["DocumentsPath"].ToString() + "/MessageAttachments";
            string messageDirectoryPath = Server.MapPath(messageDirectory);

            string documentDirectory = "~/ProviderPortal/PatientDocument/UploadedFiles";
            string documentDirectoryPath = Server.MapPath(documentDirectory);

            foreach (MessageAttachments objMessageAttachments in attachmentList)
            {
                string sourceFile = documentDirectoryPath + "\\" + objMessageAttachments.FilePath;
                string destinationFile = messageDirectoryPath + "\\" + objMessageAttachments.FilePath;

                if (File.Exists(sourceFile))
                {
                    try
                    {
                        File.Copy(sourceFile, destinationFile, false);
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                }
            }
        }
        SendEmail(body, subject, emailToStr, emailCCStr, attachmentList);
        ltrReturnValue.Text = "Success: Message Sent!";
    }

    private bool SendEmail(string msg, string sub, string dtEmailTo, string dtEmailCC, List<MessageAttachments> attachmentList)
    {
        string UserName = "EhtashamNasir@mremind.com";
        string password = "asdf!@#$%^";
        string host = "smtpout.secureserver.net";
        string port = "25";

        try
        {
            SmtpClient client = new SmtpClient();
            client.UseDefaultCredentials = true;
            client.Credentials = new System.Net.NetworkCredential(UserName, password);
            client.Port = int.Parse(port);
            client.Host = host;
            client.EnableSsl = false;


            string documentDirectory = ConfigurationManager.AppSettings["DocumentsPath"].ToString();
            documentDirectory += "/" + Profile.PracticeId + "/PracticeDocumentFiles";
            string documentDirectoryPath = Server.MapPath(documentDirectory);
            string[] emailTo = dtEmailTo.Split(',');
            for (int i = 0; i < emailTo.Length; i++)
            {
                MailMessage mail = new MailMessage(UserName, emailTo[i].ToString(), sub, msg);
                mail.IsBodyHtml = true;

                foreach (MessageAttachments objMessageAttachments in attachmentList)
                {
                    string sourceFile = documentDirectoryPath + "/" + objMessageAttachments.FilePath;
                    var attachFile = new Attachment(sourceFile);
                    mail.Attachments.Add(attachFile);
                }

                client.Send(mail);
            }
            string[] emailCC = dtEmailCC.Split(',');
            for (int i = 0; i < emailCC.Length; i++)
            {
                MailMessage mail = new MailMessage(UserName, emailCC[i].ToString(), sub, msg);
                mail.IsBodyHtml = true;

                foreach (MessageAttachments objMessageAttachments in attachmentList)
                {
                    string sourceFile = documentDirectoryPath + "/" + objMessageAttachments.FilePath;
                    var attachFile = new Attachment(sourceFile);
                    mail.Attachments.Add(attachFile);
                }

                client.Send(mail);
            }


            //Thread.Sleep(500);
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }
}