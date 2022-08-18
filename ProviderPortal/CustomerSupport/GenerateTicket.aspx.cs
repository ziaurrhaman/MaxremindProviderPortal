using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProviderPortal_CustomerSupport_GenerateTicket : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        CustomerSupportTicketsDB db = new CustomerSupportTicketsDB();
        DataSet ds = db.GetAllFilter(Profile.PracticeId,1000000000, 0, "csticketsid DESC", 0, "", "");
        rpt_GenTic.DataSource = ds.Tables[0];
        rpt_GenTic.DataBind(); 

        hdnTotalRows.Value = ds.Tables[1].Rows[0]["TotalRows"].ToString();
        
    }


   

}