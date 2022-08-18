using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class HomeHealth_Messages_Messages : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string ReceiverId = Profile.UserId.ToString();

        UserMessagesDB objUserMessagesDB = new UserMessagesDB();

        DataSet dsAllMessages = objUserMessagesDB.GetAllByReceiverId(ReceiverId, "", 10, 0, "", false, false);
        rptMessageList.DataSource = dsAllMessages.Tables[0];
        rptMessageList.DataBind();

        hdnTotalRows.Value = dsAllMessages.Tables[1].Rows[0]["TotalRows"].ToString();

        PatientContactMessagesDB objPatientContactMessagesDB = new PatientContactMessagesDB();
        DataSet dsPatientContact = objPatientContactMessagesDB.GetAllFilter("", "", 0, "", Profile.PracticeId, 10, 0, "");
        rptPatientMessages.DataSource = dsPatientContact.Tables[0];
        rptPatientMessages.DataBind();
        hdnPatientMessageTotalRows.Value = dsPatientContact.Tables[1].Rows[0]["TotalRows"].ToString();
        
        MessagesDB objMessagesDB = new MessagesDB();
        DataTable dtUnreadMessages = objMessagesDB.UnreadMessageCount(Profile.UserId);
        if (dtUnreadMessages.Rows.Count > 0)
        {
            if (dtUnreadMessages.Rows[0]["UnreadCount"].ToString() != "0")
                lblUnreadMessageCount1.Text = "( " + dtUnreadMessages.Rows[0]["UnreadCount"].ToString() + " )";
        }

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

}