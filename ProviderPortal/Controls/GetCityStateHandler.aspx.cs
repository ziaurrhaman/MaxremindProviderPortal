using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProviderPortal_Controls_GetCityStateHandler : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string zipCode = Request.Form["ZipCode"];
        ZipCodesDB objZipCodesDb = new ZipCodesDB();

        DataTable dtCityState = objZipCodesDb.GetCityStateByZipCode(zipCode);

        if (dtCityState.Rows.Count > 0)
        {
            ltrlCity.Text = dtCityState.Rows[0]["City"].ToString();
            ltrlState.Text = dtCityState.Rows[0]["State"].ToString();
        }
    }
}