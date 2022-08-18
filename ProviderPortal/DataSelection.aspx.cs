using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProviderPortal_DataSelection : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Profile.IsImported != "True")
        {
            Response.Redirect(ResolveUrl("~/ProviderPortal/Home.aspx"));
        }
        else
        {
            string isimported = Request.QueryString.Get("IsImported");
            if (!string.IsNullOrEmpty(isimported))
            {
                if (isimported == "0" || isimported == "1" || isimported == "2")
                {
                    Session["IsImported"] = isimported;
                    Response.Redirect(ResolveUrl("~/ProviderPortal/Home.aspx"));
                }

            }
        }
    }

    
}