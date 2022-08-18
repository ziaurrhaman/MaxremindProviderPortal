using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProviderPortal_Controls_CallBacks_PharmacySearch : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        PharmacyDB objPharmacyDb = new PharmacyDB();
        DataSet ds = objPharmacyDb.Pharmacy_GetAllBySearchCriteria("", "", "", "", "", "", "", 10, 0, "");
        rptPharmacy.DataSource = ds.Tables[0];
        rptPharmacy.DataBind();
        hdnPharmacyTotalRows.Value = ds.Tables[1].Rows[0]["TotalRows"].ToString();
        StatesDB objStatesDB = new StatesDB();
        ddlPharmacyStates.DataSource = objStatesDB.GetAllAsDataTable();
        ddlPharmacyStates.DataValueField = "StateCode";
        ddlPharmacyStates.DataTextField = "StateName";
        ddlPharmacyStates.DataBind();
    }
}