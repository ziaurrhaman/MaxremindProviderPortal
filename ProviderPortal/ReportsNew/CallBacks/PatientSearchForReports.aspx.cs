using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class ProviderPortal_Controls_PatientSearchForReports : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ReportsPatientDB db = new ReportsPatientDB();
        long PracticeId = Profile.PracticeId;
        string PatientName = Request.Form["PatientName"]; 
            string Filter = Request.Form["Action"];
        if (Filter== "Patient")
        {
            rptPatientSearch.DataSource = db.SearchPatient(PracticeId, PatientName);
            rptPatientSearch.DataBind();
        }
        else
        {
            CustomizePatient.DataSource = db.SearchPatient(PracticeId, PatientName);
            CustomizePatient.DataBind();
        }

        
    }
}