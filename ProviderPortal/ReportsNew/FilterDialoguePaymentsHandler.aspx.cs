using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProviderPortal_ReportsNew_FilterDialoguePaymentsHandler : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = "";
        if (!string.IsNullOrEmpty(Request.Form["Action"]))
        {
            action = Request.Form["Action"].ToString();

            if (action == "PatientFromERA")
            {
                LoadPatientFromERA();
            }
            else if (action == "InsuranceFromERA")
            {
                LoadPayersFromERAMasterTable();
            }
            else if (action == "PayerFromClaim")
            {
                LoadPayersFromClaim();
            }

        }


    }
    private void LoadPatientFromERA()
    {

        ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();
        long PracticeId = Profile.PracticeId;
        string SearchValue = Request.Form["SearchValue"].ToString();
        string SplitStringPram = Request.Form["SplitStringPram"].ToString();
        string SearchSplitValue = "";

        if (SearchValue == "")
        {
            SearchValue = "";
            SearchSplitValue = "";
        }
        if (SplitStringPram == "true")
        {
            SearchSplitValue = SearchValue;
            SearchValue = "";
        }
        DataTable dtPatient = objPatientReportsDB.GetAllPatientsForERAMaster(PracticeId, SearchValue, SearchSplitValue);
        rptPatientName.DataSource = dtPatient;

        rptPatientName.DataBind();

    }
    //private void LoadAppoitmentPatient()
    //{

    //    ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();
    //    long PracticeId = Profile.PracticeId;
    //    DataTable dtPatient = objPatientReportsDB.GetAllPatientsForAppointments(PracticeId);
    //    rptPatientName.DataSource = dtPatient;

    //    rptPatientName.DataBind();

    //}
    //public void LoadPatient()
    //{
    //    PatientDB patientDB = new PatientDB();
    //    long PracticeId = Profile.PracticeId;
    //    DataTable dtPatient = patientDB.GetAllPatients(PracticeId);
    //    rptPatientName.DataSource = dtPatient;

    //    rptPatientName.DataBind();

    //}


    public void LoadPayersFromERAMasterTable()
    {
        InsuranceDB insuranceDB = new InsuranceDB();
        long PracticeId = Profile.PracticeId;
        string SearchValue = Request.Form["SearchValue"].ToString();
        string SplitStringPram = Request.Form["SplitStringPram"].ToString();
        string SearchSplitValue = "";

        if (SearchValue == "")
        {
            SearchValue = "";
            SearchSplitValue = "";
        }
        if (SplitStringPram == "true")
        {
            SearchSplitValue = SearchValue;
            SearchValue = "";
        }
        DataTable dtPatient = insuranceDB.GetPayersFromERAMasterByPracticeId(PracticeId, SearchValue, SearchSplitValue);
        rptDenailPayerName.DataSource = dtPatient;
        rptDenailPayerName.DataBind();

    }


    public void LoadPayersFromClaim()
    {
        InsuranceDB insuranceDB = new InsuranceDB();
        long PracticeId = Profile.PracticeId;




        string SearchValue = Request.Form["SearchValue"];


        if (string.IsNullOrEmpty(SearchValue))
        {
            SearchValue = "";

        }

        DataTable dtPatient = insuranceDB.GetPayersByPracticeId(PracticeId, SearchValue, "");

        rptDenailPayerName.DataSource = dtPatient;
        rptDenailPayerName.DataBind();

    }

    //public void LoadDenailPayerName()
    //{
    //    InsuranceDB DenailInsuranceDB = new InsuranceDB();
    //    long PracticeId = Profile.PracticeId;
    //    DataTable dtDenailPayerName = DenailInsuranceDB.GetDenialPayerName(PracticeId);

    //    rptDenailPayerName.DataSource = dtDenailPayerName;
    //    rptDenailPayerName.DataBind();
    //}
}