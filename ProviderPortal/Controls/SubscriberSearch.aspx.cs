using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProviderPortal_Controls_SubscriberSearch : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SubscriberDB objSubscriberDB = new SubscriberDB();
        long PracticeId = Profile.PracticeId;

        DataSet dsSubscriber = objSubscriberDB.GetBySearchCriteria("", "", "", "", "", PracticeId, 10, 0);

        rptSubscriber.DataSource = dsSubscriber.Tables[0];
        rptSubscriber.DataBind();

        hdnSubscriberTotalRows.Value = dsSubscriber.Tables[1].Rows[0]["TotalRows"].ToString();
    }
}