using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class ProviderPortal_CustomerSupport_newwebform : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        CustomerSupportQuriesDB db = new CustomerSupportQuriesDB();
        DataSet ds = db.CSDropdowns(Profile.UserId);
        //txtCustomerSupportModuleTypeId.DataSource = ds.Tables[1];
        //txtCustomerSupportModuleTypeId.DataTextField = "name";
        //txtCustomerSupportModuleTypeId.DataValueField = "CustomerSupportModuleTypeId";
        //txtCustomerSupportModuleTypeId.DataBind();
        //txtCustomerSupportModuleTypeId.Items.Insert(0, new ListItem("", "0"));

    

    }
}