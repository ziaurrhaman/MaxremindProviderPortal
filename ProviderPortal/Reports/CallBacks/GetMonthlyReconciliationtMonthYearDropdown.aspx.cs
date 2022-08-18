using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProviderPortal_Reports_CallBacks_GetMonthlyReconciliationtMonthYearDropdown : System.Web.UI.Page
{

    string MRLocationId = "";
    string MRYear = ""; string ProviderType = ""; string Provider = "";
    PracticeLocationsDB practiceLocationsDB = new PracticeLocationsDB();
    long PracticeId = 0;
    protected void Page_Load(object sender, EventArgs e)
    {


        PracticeId = Profile.PracticeId;

        if (!string.IsNullOrEmpty(Request.Form["action"]) && Request.Form["action"] == "Filter")
        {
            ProviderType = Request.Form["ProviderType"].ToString();
            Provider = Request.Form["ProviderName"].ToString();
            if (!string.IsNullOrEmpty(Request.Form["MRLocationId"]))
            {
                MRLocationId = Request.Form["MRLocationId"];
                DataSet dsYear = practiceLocationsDB.GetClaimLocationYearMonth(PracticeId, MRLocationId, ProviderType, Provider, 0);
                ddlMonthlyReconciliationYear.DataSource = dsYear.Tables[1];
                ddlMonthlyReconciliationYear.DataBind();
                ddlMonthlyReconciliationYear.DataTextField = "YR";
                ddlMonthlyReconciliationYear.DataValueField = "YR";
                ddlMonthlyReconciliationYear.DataBind();
                if (ddlMonthlyReconciliationYear.Items.Count > 0)
                {
                    ddlMonthlyReconciliationYear.Items.Insert(0, new ListItem("All", "0"));
                }
                else
                {
                    ddlMonthlyReconciliationYear.Items.Insert(0, new ListItem("No Claim Posted", "0"));
                }


            }
            if (!string.IsNullOrEmpty(Request.Form["MRYear"]) && Request.Form["MRYear"] != "0")
            {
                MRYear = Request.Form["MRYear"];
                DataSet dsMonth = practiceLocationsDB.GetClaimLocationYearMonth(PracticeId, MRLocationId, ProviderType, Provider, long.Parse(MRYear));
                ddlMonthlyReconciliationMonth.DataSource = dsMonth.Tables[2];
                ddlMonthlyReconciliationMonth.DataBind();
                var month = dsMonth.Tables[2].Rows[0]["MNO"].ToString();
                if (!string.IsNullOrEmpty(month))
                {
                    ddlMonthlyReconciliationMonth.DataTextField = "MO";
                    ddlMonthlyReconciliationMonth.DataValueField = "MO";
                    ddlMonthlyReconciliationMonth.DataBind();
                    if (dsMonth.Tables[2].Rows.Count > 0)
                    {
                        ddlMonthlyReconciliationMonth.Items.Insert(0, new ListItem("All", "0"));
                    }
                    else
                    {
                        ddlMonthlyReconciliationMonth.Items.Insert(0, new ListItem("No Claim Posted", "0"));
                    }




                }

            }
        }


        if (!string.IsNullOrEmpty(Request.Form["action"]) && Request.Form["action"] == "ProviderOnLocation")
        {
            // Added By Rizwan 30April2018
            LoadAllProviderddl(); LoadYearonProvider();
        }

        if (!string.IsNullOrEmpty(Request.Form["action"]) && Request.Form["action"] == "LoadYearonProvider")
        {
            LoadYearonProvider(); LoadProviderddl();
        }

    }

    public void LoadAllProviderddl()
    {
        ServiceProviderDB serviceProviderDB = new ServiceProviderDB();
        MRLocationId = Request.Form["MRLocationId"];

        if (!string.IsNullOrEmpty(Request.Form["ProviderType"]))
        {
            ProviderType = Request.Form["ProviderType"];
        }
        else
        {
            ProviderType = "";
        }
        Provider = Request.Form["ProviderName"].ToString();


        string PracticeId = Profile.PracticeId.ToString();
        DataTable dtPayerName = serviceProviderDB.GetProvidersforMonthlyReconciliation(MRLocationId, PracticeId, ProviderType);
        ddlMonthlyReconciliationProvider.DataSource = dtPayerName;
        ddlMonthlyReconciliationProvider.DataTextField = "Providers";
        ddlMonthlyReconciliationProvider.DataValueField = "Providers";
        ddlMonthlyReconciliationProvider.DataBind();
        if (dtPayerName.Rows.Count > 0)
        {
            ddlMonthlyReconciliationProvider.Items.Insert(0, new ListItem("All", "0"));



        }
        else
        {
            ddlMonthlyReconciliationProvider.Items.Insert(0, new ListItem("No Provider available at this location", "0"));


        }



    }

    public void LoadProviderddl()
    {
        ServiceProviderDB serviceProviderDB = new ServiceProviderDB();
        MRLocationId = Request.Form["MRLocationId"];

        if (!string.IsNullOrEmpty(Request.Form["ProviderType"]))
        {
            ProviderType = Request.Form["ProviderType"];
        }
        else
        {
            ProviderType = "";
        }
        Provider = Request.Form["ProviderName"].ToString();


        string PracticeId = Profile.PracticeId.ToString();
        DataTable dtPayerName = serviceProviderDB.GetProvidersforMonthlyReconciliation(MRLocationId, PracticeId, ProviderType);
        ddlMonthlyReconciliationProvider.DataSource = dtPayerName;
        ddlMonthlyReconciliationProvider.DataTextField = "Providers";
        ddlMonthlyReconciliationProvider.DataValueField = "Providers";
        ddlMonthlyReconciliationProvider.DataBind();
        ddlMonthlyReconciliationProvider.Items.Insert(0, new ListItem(Provider, Provider));




    }
    public void LoadYearonProvider()
    {
        if (!string.IsNullOrEmpty(Request.Form["MRLocationId"]))
        {
            MRLocationId = Request.Form["MRLocationId"];
            if (!string.IsNullOrEmpty(Request.Form["ProviderType"]))
            {
                ProviderType = Request.Form["ProviderType"];
            }
            else
            {
                ProviderType = "";
            }
            Provider = Request.Form["ProviderName"];
            DataSet dsYear = practiceLocationsDB.GetClaimLocationYearMonth(PracticeId, MRLocationId, ProviderType, Provider, 0);
            ddlMonthlyReconciliationYear.DataSource = dsYear.Tables[1];
            ddlMonthlyReconciliationYear.DataBind();
            ddlMonthlyReconciliationYear.DataTextField = "YR";
            ddlMonthlyReconciliationYear.DataValueField = "YR";
            ddlMonthlyReconciliationYear.DataBind();
            if (ddlMonthlyReconciliationYear.Items.Count > 0)
            {
                ddlMonthlyReconciliationYear.Items.Insert(0, new ListItem("All", "0"));
            }
            else
            {
                ddlMonthlyReconciliationYear.Items.Insert(0, new ListItem("No Claim Posted", "0"));
            }
        }
    }
}