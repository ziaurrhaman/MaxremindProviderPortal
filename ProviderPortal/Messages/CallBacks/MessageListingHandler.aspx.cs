using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class HomeHealth_Messages_CallBacks_MessageListingHandler : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        string ReceiverId = Profile.UserId.ToString();

        UserMessagesDB objUserMessagesDB = new UserMessagesDB();

        string SearchValue = Request.Form["SearchValue"].ToString();

        int Rows = int.Parse(Request.Form["Rows"].ToString());
        int PageNumber = int.Parse(Request.Form["PageNumber"].ToString());
        bool IsDelete = bool.Parse(Request.Form["IsDeleted"].ToString());
        bool IsDraft = bool.Parse(Request.Form["IsDraft"].ToString());
        bool IsSentMessages = bool.Parse(Request.Form["IsSentMessages"].ToString());
        string SortBy = Request.Form["SortBy"].ToString();

        DataSet dsAllMessages = new DataSet();

        if (IsSentMessages)
        {
            dsAllMessages = objUserMessagesDB.GetSentMessagesByUserId(ReceiverId, SearchValue, Rows, PageNumber, SortBy);
            rptSentMessageList.DataSource = dsAllMessages.Tables[0];
            rptSentMessageList.DataBind();
        }
        else if (IsDelete)
        {
            dsAllMessages = objUserMessagesDB.GetAllDeleted(ReceiverId, SearchValue, Rows, PageNumber, SortBy);
            rptMessageList.DataSource = dsAllMessages.Tables[0];
            rptMessageList.DataBind();
        }
        else
        {
            dsAllMessages = objUserMessagesDB.GetAllByReceiverId(ReceiverId, SearchValue, Rows, PageNumber, SortBy, IsDelete, IsDraft);
            rptMessageList.DataSource = dsAllMessages.Tables[0];
            rptMessageList.DataBind();
        }

        ltrlRowsCount.Text = dsAllMessages.Tables[1].Rows[0]["TotalRows"].ToString();
    }

    protected void rptMessageList_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView drv = (DataRowView)e.Item.DataItem;

            string priority = drv["Priority"].ToString();

            if (priority == "L")
            {
                ((Image)e.Item.FindControl("imgPriority")).ImageUrl = "../../Images/email/PriorityLow.png";
            }
            else if (priority == "H")
            {
                ((Image)e.Item.FindControl("imgPriority")).ImageUrl = "../../Images/email/HighyPriority.png";
            }
        }
    }

    protected void rptSentMessageList_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView drv = (DataRowView)e.Item.DataItem;

            string priority = drv["Priority"].ToString();

            if (priority == "L")
            {
                ((Image)e.Item.FindControl("imgPriority")).ImageUrl = "../../Images/email/PriorityLow.png";
            }
            else if (priority == "H")
            {
                ((Image)e.Item.FindControl("imgPriority")).ImageUrl = "../../Images/email/HighyPriority.png";
            }
        }
    }
}