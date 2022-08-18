using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProviderPortal_Controls_CallBacks_AddSubscriberHandler : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        StatesDB objStatesDB = new StatesDB();
        DataTable GetAllStates = objStatesDB.GetAllAsDataTable();
        ddlAddSubscriberState.DataSource = GetAllStates;
        ddlAddSubscriberState.DataValueField = "StateCode";
        ddlAddSubscriberState.DataTextField = "StateName";
        ddlAddSubscriberState.DataBind();
    }
}