using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class ProviderPortal_Claim_CallBacks_FilterCriteriaChart : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        PracticeStaffDB objPracticeStaffDB = new PracticeStaffDB();
        ddlBillingProvider2.DataSource = objPracticeStaffDB.GetProvidersByPractice(Profile.PracticeId);
        ddlBillingProvider2.DataValueField = "PracticeStaffId";
        ddlBillingProvider2.DataTextField = "Name";
        ddlBillingProvider2.DataBind();

       // ddlBillingProvider2.SelectedValue = Provider;

        PracticeLocationsDB objPracticeLocationsDB = new PracticeLocationsDB();
        DataTable dtLocations = objPracticeLocationsDB.GetPracticeLocationsByPractice(Profile.PracticeId);

        ddlLocation2.DataSource = dtLocations;
        ddlLocation2.DataTextField = "Name";
        ddlLocation2.DataValueField = "PracticeLocationsId";
        ddlLocation2.DataBind();
       // ddlLocation2.SelectedValue = Location;

    }
}