using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class ProviderPortal_Controls_PatientBoxSearch : System.Web.UI.Page
{ 
    protected void Page_Load(object sender, EventArgs e)
    {
        FilterPatients();
    }
    
    private void FilterPatients()
    {
        string LastName = Request.Form["LastName"];
        string FirstName = Request.Form["FirstName"];
        string Phone = Request.Form["Phone"];
        
        PatientDB objPatientDB = new PatientDB();
        
        DataTable dtPatients = objPatientDB.FilterPatientsByName(Profile.PracticeId, LastName, FirstName, Phone);
        
        rptPatients.DataSource = dtPatients;
        rptPatients.DataBind();
    }
}