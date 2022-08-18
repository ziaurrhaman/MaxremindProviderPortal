using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProviderPortal_SeprateReports_PostClaimReport_PostClaim : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadPracticeLocation();
    }
    public void LoadPracticeLocation()
    {
        PracticeLocationsDB practiceLocationsDB = new PracticeLocationsDB();
        long PracticeId = Profile.PracticeId;
        DataTable dtPracticeLocation = practiceLocationsDB.GetPracticeLocationsByPractice(PracticeId);
        rptLocation.DataSource = dtPracticeLocation;
        rptLocation.DataBind();
    }
    public void LoadPlaceOfService()
    {
        PlaceOfServicesDB objPlaceOfServicesDB = new PlaceOfServicesDB();
        DataTable dtPOS = objPlaceOfServicesDB.GetAllByPractice(Profile.PracticeId);
        rptPlaceOfService.DataSource = dtPOS;
        rptPlaceOfService.DataBind();
    }
    public void LoadProvider()
    {
        ServiceProviderDB serviceProviderDB = new ServiceProviderDB();
        string PracticeLocationId = Request.Form["PracticeLocationId"];
        long PracticeId = Profile.PracticeId;
        DataTable dtPayerName = serviceProviderDB.GetProvidersByPracticeForPP(PracticeId);
        rptProviders.DataSource = dtPayerName;
        rptProviders.DataBind();
    }
    public void LoadPayersFromClaim()
    {
        InsuranceDB insuranceDB = new InsuranceDB();
        long PracticeId = Profile.PracticeId;
        string SearchValue = Request.Form["SearchValue"].ToString();
        if (SearchValue == "")
        {
            SearchValue = "";

        }

        DataTable dtPatient = insuranceDB.GetPayersByPracticeId(PracticeId, "", "");

        rptDenailPayerName.DataSource = dtPatient;
        rptDenailPayerName.DataBind();

    }

}