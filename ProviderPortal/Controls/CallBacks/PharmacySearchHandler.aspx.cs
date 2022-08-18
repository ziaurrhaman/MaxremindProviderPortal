using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProviderPortal_Controls_CallBacks_PharmacySearchHandler : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string storeName = Request.Form["storeName"];
        string address = Request.Form["address"];
        string city = Request.Form["city"];
        string state = Request.Form["state"];
        string zip = Request.Form["zip"];
        string phone = Request.Form["phone"];
        string fax = Request.Form["fax"];

        int rows = Convert.ToInt32(Request.Form["Rows"]);

        int pageNumber = Convert.ToInt32(Request.Form["pageNumber"]);
        string sortBy = Request.Form["SortBy"];

        PharmacyDB objPharmacyDb = new PharmacyDB();
        DataSet ds = objPharmacyDb.Pharmacy_GetAllBySearchCriteria(storeName, address, city, state, zip, phone, fax, rows, pageNumber, sortBy);

        rptPharmacy.DataSource = ds.Tables[0];
        rptPharmacy.DataBind();

        ltrPharmacyRowsCount.Text = ds.Tables[1].Rows[0]["TotalRows"].ToString();
    }
}