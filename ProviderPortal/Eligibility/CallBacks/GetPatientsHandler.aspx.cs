using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProviderPortal_Eligibility_CallBacks_GetPatientsHandler : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadPatients();
    }
    private void LoadPatients()
    {
        long PatientId = long.Parse(Request.Form["PatientId"].ToString());
        string FirstName = Request.Form["FirstName"].ToString();
        string LastName = Request.Form["LastName"].ToString();

        int Rows = int.Parse(Request.Form["Rows"].ToString());
        int PageNumber = int.Parse(Request.Form["PageNumber"].ToString());

        string Gender = Request.Form["Gender"].ToString();

        string SortBy = Request.Form["SortBy"].ToString();
        string DOB = Request.Form["DOB"].ToString();
        long PracticeId = Profile.PracticeId;
        string Payer = Request.Form["Payer"].ToString();
        PatientDB ObjPatientDB = new PatientDB();

        DataSet dsPatients = ObjPatientDB.GetAllPatientsForEligibility(PracticeId, Rows, PageNumber, SortBy, PatientId, FirstName, LastName, Gender, DOB,Payer);

        rptPatients.DataSource = dsPatients.Tables[0];
        rptPatients.DataBind();

        ltrlPatientRowsCount.Text = dsPatients.Tables[1].Rows[0]["TotalRows"].ToString();
    }
}