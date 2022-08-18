using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class ProviderPortal_PendingTransitions_CallBacks_PendingTransitionPatienthandler : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e) 
   {
        long PatientId = long.Parse(Request.Form["PatientId"].ToString());
        string FirstName = Request.Form["FirstName"].ToString();
        string LastName = Request.Form["LastName"].ToString();

        int Rows = int.Parse(Request.Form["Rows"].ToString());
        int PageNumber = int.Parse(Request.Form["PageNumber"].ToString());

        string Gender = Request.Form["Gender"].ToString();
        string Address = Request.Form["Address"].ToString();
        string PhoneNumber = Request.Form["Phone"].ToString();

        string SortBy = Request.Form["SortBy"].ToString();
        string DOB = Request.Form["DOB"].ToString();
        long PracticeId = Profile.PracticeId;
       string PtlReasons= Request.Form["PtlReasons"];

        bool IsPTL = false;

        if (Request.Form["IsPTL"] != null)
        {
            IsPTL = bool.Parse(Request.Form["IsPTL"]);
        }

        PatientDB ObjPatientDB = new PatientDB();

        DataSet dsPatients = ObjPatientDB.PendingTransitionFilterPatients(PatientId, FirstName, LastName, DOB, PhoneNumber, Gender, Address, PtlReasons, PracticeId, Rows, PageNumber, SortBy, IsPTL);

        rptPatients.DataSource = dsPatients.Tables[0];
        rptPatients.DataBind();

        ltrlPatientRowsCount.Text = dsPatients.Tables[1].Rows[0]["TotalRows"].ToString();
        hdnTotalRowsPatients.Value = dsPatients.Tables[1].Rows[0]["TotalRows"].ToString();  
    }
}