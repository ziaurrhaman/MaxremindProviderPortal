using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class EMR_Settings_Ticketing_Tickets : System.Web.UI.Page
{
    //Start File Added By Rizwan kharal 13April2018
    protected void Page_Load(object sender, EventArgs e)
    {
        TicketingDB db = new TicketingDB();
        DataSet ds = db.TicketingDetails(Profile.PracticeId, 10, 0, "TicketId desc", ""); 
        RptTickets.DataSource = ds;
        RptTickets.DataBind();
        hdnTicketsTotalRows.Value = ds.Tables[1].Rows[0]["TotalRows"].ToString();
        lblTotalRecord.Text = ds.Tables[1].Rows[0]["TotalRows"].ToString();
        hdnPracticeId.Value = Profile.PracticeId.ToString();
    }
}