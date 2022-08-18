using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;

public partial class ProviderPortal_Controls_GetZipCityState : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
  {
        ZipCodesDB objZipCodesDb = new ZipCodesDB();
        rptZipCityState.DataSource = objZipCodesDb.GetZipCityState(Request.Form["ZipCode"], Request.Form["City"]);
        rptZipCityState.DataBind();        
    }


    public void ZipCode()
    {
        string zipcide=null;
        if (Request.Form["zipcode"] != null)
        {
            zipcide = Request.Form["zipcode"].ToString();
        }
        ZipCodesDB db = new ZipCodesDB();
     DataTable  dt = db.ShowZipCityCodes(zipcide);
     rptZipCityState.DataSource = dt;
     rptZipCityState.DataBind();

    }

}