using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class EMR_Controls_UCMessageDialog : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        MessagesDB objMessagesDB = new MessagesDB();
        DataTable dtPracticeUserList = objMessagesDB.GetPracticeUserList(Profile.PracticeId);

        rptUserList.DataSource = dtPracticeUserList;
        rptUserList.DataBind();

        rptUserCcList.DataSource = dtPracticeUserList;
        rptUserCcList.DataBind();
    }
}