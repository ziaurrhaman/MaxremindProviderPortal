using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProviderPortal_InsuranceCredentialing_CallBacks_InsuranceCredentialingHandler : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        GetProvider();
    }

    public void GetProvider()
    {
        InsuranceCredentialingDB db = new InsuranceCredentialingDB();
        DataTable dt = db.GetddlProviders(Profile.PracticeId);

        ddlProciders.DataSource = dt;
        ddlProciders.DataValueField = "PracticeStaffId";
        ddlProciders.DataTextField = "Name";
        ddlProciders.DataBind();
        ddlProciders.Items.Insert(0, new ListItem("-- Select Provider --", "0"));
    }
}