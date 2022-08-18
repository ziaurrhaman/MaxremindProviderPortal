using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text.RegularExpressions;

public partial class HomeHealth_Messages_CallBacks_GetMessageDetailHandler : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        long MessageId = Convert.ToInt64(Request.Form["MessageId"].ToString());

        MessagesManager objMessagesManager = new MessagesManager();

        DataSet dsMessageDetail = objMessagesManager.GetMessageDetailByMessagesId(MessageId, Profile.UserId);

        DataTable dtMessages = dsMessageDetail.Tables[0];

        string html = "<div class='tag' id='" + dtMessages.Rows[0]["MessageFromUserId"].ToString() + "'><span>" + dtMessages.Rows[0]["FromName"].ToString() + " (" + dtMessages.Rows[0]["UserName"] + ")</span>" +
                      "<a style='display:none;' href='#' title='Removing tag' onclick='RemoveTag(this);'>&nbsp;x</a></div>";

        divMessageFromUser.InnerHtml = html;

        lblSentDate.Text = dtMessages.Rows[0]["CreatedDate"].ToString();
        lblSubject.Text = dtMessages.Rows[0]["Subject"].ToString();

        string body = dtMessages.Rows[0]["Body"].ToString();

        //body = Uri.EscapeUriString(body);
        ltrBody.Text = body;

        DataTable dtMessageTo = dsMessageDetail.Tables[1];

        rptMessageTo.DataSource = dtMessageTo;
        rptMessageTo.DataBind();

        DataTable dtMessageCc = dsMessageDetail.Tables[2];

        rptMessageCc.DataSource = dtMessageCc;
        rptMessageCc.DataBind();

        if (dsMessageDetail.Tables[3].Rows.Count > 0)
        {
            divMessageAttachment.Visible = true;
            lblAttachmentCount.Text = dsMessageDetail.Tables[3].Rows.Count.ToString();
            rptAttachmentList.DataSource = dsMessageDetail.Tables[3];
            rptAttachmentList.DataBind();
        }
        MessagesDB objMessagesDb = new MessagesDB();
        DataTable dtUnreadMessages = objMessagesDb.UnreadMessageCount(Profile.UserId);
        if (dtUnreadMessages.Rows.Count > 0)
        {
            if (dtUnreadMessages.Rows[0]["UnreadCount"].ToString() != "0")
                ltrUnreadMessageCount.Text = dtUnreadMessages.Rows[0]["UnreadCount"].ToString();
        }
        

    }

    protected void rptAttachmentList_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView drv = (DataRowView)e.Item.DataItem;
            string input = drv["FilePath"].ToString();
            Match match = Regex.Match(input.Split('.').Last(), @"((jpg|png|gif|bmp)$)", RegexOptions.IgnoreCase);
            Literal MessageAttachment = (Literal)e.Item.FindControl("ltrlAttachment");

            if (match.Success)
            {
                string html = "<div class='attachmentWrapper' attachmentname='" + drv["FileName"].ToString() + "' attachmentpath='" + drv["FilePath"].ToString() + "'><div class='imageWrapper'><img style='width:72px; height:72px;' src='" + ResolveUrl("~/PracticeDocuments/MessageAttachments/" + drv["FilePath"].ToString()) + "'></img></div><div class='downloadStrip' onclick=\"saveToDisk('" + ResolveUrl("~/PracticeDocuments/MessageAttachments/" + drv["FilePath"].ToString()) + "','" + drv["FileName"].ToString() + "')\"><span class='iconDownload'></span><a class='blue' title='" + drv["FileName"].ToString() + "'>Save</a></div></div>";
                MessageAttachment.Text = html;
            }

            else if (input.Split('.').Last() == "pdf")
            {
                string html = "<div class='attachmentWrapper' attachmentname='" + drv["FileName"].ToString() + "' attachmentpath='" + drv["FilePath"].ToString() + "'><div class='imageWrapper'><span class='iconPdf'></span></div><div class='downloadStrip' onclick=\"saveToDisk('" + ResolveUrl("~/PracticeDocuments/MessageAttachments/" + drv["FilePath"].ToString()) + "','" + drv["FileName"].ToString() + "')\"><span class='iconDownload'></span><a class='blue' title='" + drv["FileName"].ToString() + "'>Save</a></div></div>";
                MessageAttachment.Text = html;
            }

            else if (input.Split('.').Last() == "docx" || input.Split('.').Last() == "doc")
            {
                string html = "<div class='attachmentWrapper' attachmentname='" + drv["FileName"].ToString() + "' attachmentpath='" + drv["FilePath"].ToString() + "'><div class='imageWrapper'><span class='iconDoc'></span></div><div class='downloadStrip' onclick=\"saveToDisk('" + ResolveUrl("~/PracticeDocuments/MessageAttachments/" + drv["FilePath"].ToString()) + "','" + drv["FileName"].ToString() + "')\"><span class='iconDownload'></span><a class='blue' title='" + drv["FileName"].ToString() + "'>Save</a></div></div>";
                MessageAttachment.Text = html;
            }
            else if (input.Split('.').Last() == "txt")
            {
                string html = "<div class='attachmentWrapper' attachmentname='" + drv["FileName"].ToString() + "' attachmentpath='" + drv["FilePath"].ToString() + "'><div class='imageWrapper'><span class='iconTxt'></span></div><div class='downloadStrip' onclick=\"saveToDisk('" + ResolveUrl("~/PracticeDocuments/MessageAttachments/" + drv["FilePath"].ToString()) + "','" + drv["FileName"].ToString() + "')\"><span class='iconDownload'></span><a class='blue' title='" + drv["FileName"].ToString() + "'>Save</a></div></div>";
                MessageAttachment.Text = html;
            }
            else if (input.Split('.').Last() == "xls" || input.Split('.').Last() == "xlsx")
            {
                string html = "<div class='attachmentWrapper' attachmentname='" + drv["FileName"].ToString() + "' attachmentpath='" + drv["FilePath"].ToString() + "'><div class='imageWrapper'><span class='iconXLS'></span></div><div class='downloadStrip' onclick=\"saveToDisk('" + ResolveUrl("~/PracticeDocuments/MessageAttachments/" + drv["FilePath"].ToString()) + "','" + drv["FileName"].ToString() + "')\"><span class='iconDownload'></span><a class='blue' title='" + drv["FileName"].ToString() + "'>Save</a></div></div>";
                MessageAttachment.Text = html;
            }
            else if (input.Split('.').Last() == "rar" || input.Split('.').Last() == "zip")
            {
                string html = "<div class='attachmentWrapper' attachmentname='" + drv["FileName"].ToString() + "' attachmentpath='" + drv["FilePath"].ToString() + "'><div class='imageWrapper'><span class='iconZip'></span></div><div class='downloadStrip' onclick=\"saveToDisk('" + ResolveUrl("~/PracticeDocuments/MessageAttachments/" + drv["FilePath"].ToString()) + "','" + drv["FileName"].ToString() + "')\"><span class='iconDownload'></span><a class='blue' title='" + drv["FileName"].ToString() + "'>Save</a></div></div>";
                MessageAttachment.Text = html;
            }
            else
            {
                string html = "<div class='attachmentWrapper' attachmentname='" + drv["FileName"].ToString() + "' attachmentpath='" + drv["FilePath"].ToString() + "'><div class='imageWrapper'><span class='iconDefaultFile'></span></div><div class='downloadStrip' onclick=\"saveToDisk('" + ResolveUrl("~/PracticeDocuments/MessageAttachments/" + drv["FilePath"].ToString()) + "','" + drv["FileName"].ToString() + "')\"><span class='iconDownload'></span><a class='blue' title='" + drv["FileName"].ToString() + "'>Save</a></div></div>";
                MessageAttachment.Text = html;
            }
        }


    }

}