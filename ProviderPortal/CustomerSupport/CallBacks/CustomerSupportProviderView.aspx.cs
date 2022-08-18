using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class ProviderPortal_CustomerSupport_CallBacks_CustomerSupportProviderView : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       int QueryId = 0;
        if (Convert.ToInt32(Request.Form["QueryId"])>0)
        {
        QueryId =Convert.ToInt32( Request.Form["QueryId"]);
        }
        CustomerSupportQuriesDB db = new CustomerSupportQuriesDB();
        DataSet ds = db.CSDropdowns();
        ddlstatus.DataSource = ds.Tables[0];
       ddlstatus.DataTextField = "StatusName";
       ddlstatus.DataValueField = "StatusId";
       ddlstatus.DataBind();
        
        DataSet ds1 = db.GetAllFilter(1000000, 0, "CustomerSupportQuryId DESC", Profile.PracticeId.ToString(), "", "", "", "", "", "", "", "", "", "", "", QueryId, "", "", "", "");
        
        if (QueryId > 0)
        {

            string subject = ds1.Tables[0].Rows[0]["Subject"].ToString();
            string descriptions = ds1.Tables[0].Rows[0]["Descriptions"].ToString();
            string statusid = ds1.Tables[0].Rows[0]["StatusId"].ToString();
            string lblticket = ds1.Tables[0].Rows[0]["CustomerSupportQuryId"].ToString();

            ddlallticket.Text = QueryId.ToString();
            subject1.Text = subject;
            description1.Text = descriptions;                                                                                                                                     
            ddlstatus.Text = statusid;
            lblTitleNo.Text = lblticket;
        }
        ddlAllTickets();
    }

    private void ddlAllTickets() {
       
        CustomerSupportQuriesDB db = new CustomerSupportQuriesDB();
        DataSet ds = db.GetAllFilter(1000000, 0, "CustomerSupportQuryId ASC", Profile.PracticeId.ToString(), "", "", "", "", "", "", "", "", "", "", "", 0, "", "", "", "");
        ddlallticket.DataSource = ds.Tables[0];
        ddlallticket.DataTextField = "ticketname";
        ddlallticket.DataValueField = "CustomerSupportQuryId";
        ddlallticket.DataBind();
    }
}