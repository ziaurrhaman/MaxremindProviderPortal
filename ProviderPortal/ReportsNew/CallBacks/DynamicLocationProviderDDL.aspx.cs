using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProviderPortal_ReportsNew_CallBacks_DynamicLocationProviderDDL : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string Action = Request.Form["action"];
        if (Action == "FilterProviders")
        {
            FilterProviders();
        }
        if (Action == "FilterLocations")
        {
            FilterLocations();
        }
        if (Action == "LoadDDLProvider")
        {
            LoadDDLProvider();
        }
        if (Action == "LoadDDLLocation")
        {
            LoadDDLPracticeLocation();
        }

    }
    protected void FilterProviders()
    {

        string PracticeLocationId = Request.Form["PracticeLocationId"];

        ReportsDB db = new ReportsDB();
        DataTable ds = db.GetPracticeStaffLocationNameDropDown(Profile.PracticeId, PracticeLocationId);
        DynamicProviders.DataSource = ds;
        DynamicProviders.DataBind();

    }
    protected void FilterLocations()
    {

        string NPI = Request.Form["NPI"];

        ReportsDB db = new ReportsDB();
        DataTable ds = db.GetLocationNamePracticestaffDropDown(Profile.PracticeId, NPI);
        DynamicLocations.DataSource = ds;
        DynamicLocations.DataBind();

    }
    public void LoadDDLProvider()
    {
        ReportsDB db = new ReportsDB();
        string PracticeLocationId = Request.Form["PracticeLocationId"];
        long PracticeId = Convert.ToInt32((Profile.PracticeId));
        DataTable dtPayerName = db.GetProvidersByDefault(PracticeId);
        rptProviders.DataSource = dtPayerName;
        rptProviders.DataBind();
    }
    public void LoadDDLPracticeLocation()
    {
        long PracticeId = Profile.PracticeId;
        ReportsDB db = new ReportsDB();

        DataTable dtPracticeLocation = db.GetLocationsByDefault(PracticeId);
        rptLocation.DataSource = dtPracticeLocation;
        rptLocation.DataBind();
    }


}